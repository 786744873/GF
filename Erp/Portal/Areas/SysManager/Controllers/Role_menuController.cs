using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.SysManager.Controllers
{
    /// <summary>
    /// 角色--菜单中间表控制器
    /// 作者：崔慧栋
    /// 日期：2015/06/02
    /// </summary>
    public class Role_menuController : BaseController
    {
        private readonly ICommonService.SysManager.IC_Role_menu _role_menuWCF;

         public Role_menuController()
        {
            #region 服务初始化
            _role_menuWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Role_menu>("Role_menuWCF");
            #endregion
        }
        //
        // GET: /SysManager/Role_menu/
        public override ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int? roleId)
        {
            ViewBag.roleId = roleId;
            return View();
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="form">查询条件表单</param>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form,int? roleId, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.SysManager.C_Role_menu roleConditon = new CommonService.Model.SysManager.C_Role_menu();

            if (roleId!=null)
            {//角色ID查询条件
                roleConditon.C_Roles_id =roleId;
            }

            //查询模型传递到前端视图中
            ViewBag.RoleConditon = roleConditon;

            #endregion

            //获取总记录数
            this.TotalRecordCount = _role_menuWCF.GetRecordCount(roleConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取数据信息
            List<CommonService.Model.SysManager.C_Role_menu> menus = _role_menuWCF.GetListByPage(roleConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(menus);
        }

        public ActionResult Tree(int roleId)
        {
            SetSingleRoleMenu(roleId);
            return View();
        }

        public ActionResult relationRoleMenu(int roleId,string menuId)
        {
            bool isSuccess = false;
            string[] menu_ids = menuId.Split(',');
            if (menuId != null)
            {//关联菜单
                for (int i = 0; i < menu_ids.Length; i++)
                {
                    if (!String.IsNullOrEmpty(menu_ids[i]))
                    {
                        CommonService.Model.SysManager.C_Role_menu roleMenu = new CommonService.Model.SysManager.C_Role_menu();
                        roleMenu.C_Roles_id = roleId;
                        roleMenu.C_Menu_id =int.Parse(menu_ids[i]);
                        _role_menuWCF.Add(roleMenu);
                        isSuccess = true;
                    }
                }
            }


            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("关联菜单信息成功！", "iframe_allocatedMenuTree", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("关联菜单信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int roleId, int menuId)
        {
            bool isSuccess = _role_menuWCF.Delete(roleId, menuId);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除关联菜单信息成功！", "iframe_allocatedMenuTree", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除关联菜单信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        #region 不含checkbox的业务流程递归

        /// <summary>
        /// 根据关联外键Guid，获取关联所有业务流程信息
        /// </summary>
        /// <param name="pkCode">关联外键Guid</param>
        private void SetSingleRoleMenu(int roleId)
        {
            List<CommonService.Model.SysManager.C_Role_menu> role_menus = _role_menuWCF.GetListByRoleId(roleId);
            SetSingleTopRoleMenu(role_menus);
        }

        /// <summary>
        /// 装载顶级业务流程
        /// </summary>
        /// <param name="businessFlowList">业务流程集合</param>
        private void SetSingleTopRoleMenu(List<CommonService.Model.SysManager.C_Role_menu> rolemenuList)
        {
            string rolemenuTreeHtml = "";
            string preTreeHtml = "<ul>";//树前缀
            string backTreeHtml = "</ul>";//树后缀
            var topRoleMenuList = from allList in rolemenuList
                              where allList.C_Menu_parent == 0
                              orderby allList.C_Menu_id ascending
                              select allList;
            /*
             *
             *说明：只要在<li>标签上加上 class=jstree-open, 默认就会打开树,hety,2015-05-19
             */
            foreach (CommonService.Model.SysManager.C_Role_menu rolemenu in topRoleMenuList)
            {
                string href = "?{menuId}=" + rolemenu.C_Menu_id.ToString();
                string uniqueId = rolemenu.C_Menu_id.ToString();
                rolemenuTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + rolemenu.C_Menu_name + "</a>";
                SetSignleRecursionTree(rolemenu.C_Menu_id.Value, ref rolemenuTreeHtml, rolemenuList);
                rolemenuTreeHtml += "</li>";
            }
            ViewBag.SingleRoleMenuTreeHtml = preTreeHtml + rolemenuTreeHtml + backTreeHtml;
        }

        /// <summary>
        /// 递归加载所有业务流程
        /// </summary>
        /// <param name="parentCode">上级流程Code</param>
        /// <param name="businessFlowTreeHtml">业务流程 Tree Html</param>
        /// <param name="businessFlowList">业务流程集合</param>
        private void SetSignleRecursionTree(int parentId, ref string rolemenuTreeHtml, List<CommonService.Model.SysManager.C_Role_menu> rolemenuList)
        {
            var lowrolemenuList = from allList in rolemenuList
                              where allList.C_Menu_parent == parentId
                              orderby allList.C_Menu_id ascending
                              select allList;
            if (lowrolemenuList.Count() != 0)
            {
                rolemenuTreeHtml += "<ul>";
            }
            /*
             *
             *说明：只要在<li>标签上加上 class=jstree-open, 默认就会打开树,hety,2015-05-19
             */
            foreach (CommonService.Model.SysManager.C_Role_menu rolemenu in lowrolemenuList)
            {
                string href = "?{menuId}=" + rolemenu.C_Menu_id.ToString();
                string uniqueId = rolemenu.C_Menu_id.ToString();
                rolemenuTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + rolemenu.C_Menu_name + "</a>";
                SetSignleRecursionTree(rolemenu.C_Menu_id.Value, ref rolemenuTreeHtml, rolemenuList);
                rolemenuTreeHtml += "</li>";
            }
            if (lowrolemenuList.Count() != 0)
            {
                rolemenuTreeHtml += "</ul>";
            }
        }

        #endregion
	}
}