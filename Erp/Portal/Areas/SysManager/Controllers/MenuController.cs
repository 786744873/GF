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
    /// 菜单控制器
    /// 作者：崔慧栋
    /// 日期：2015/05/26
    /// </summary>
    public class MenuController : BaseController
    {
        private readonly ICommonService.SysManager.IC_Menu _menuWCF;

        public MenuController()
        {
            #region 服务初始化
            _menuWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Menu>("menuWCF");
            #endregion
        }
        //
        // GET: /SysManager/Menu/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int? menuId)
        {
            //创建初始化菜单实体
            CommonService.Model.SysManager.C_Menu menu = new CommonService.Model.SysManager.C_Menu();
            menu.C_Menu_isDelete = false;
            menu.C_Menu_parent = menuId == null ? 0 : menuId;
            menu.C_Menu_creator = Context.UIContext.Current.UserCode;
            menu.C_Menu_createTime = DateTime.Now;
            menu.C_Menu_order = 0;
            menu.C_Menu_state = 1;
            menu.C_Menu_type = 1;
            return View(menu);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int menuId)
        {
            CommonService.Model.SysManager.C_Menu menu = _menuWCF.GetModel(menuId);
            return View("Create", menu);
        }

        /// <summary>
        /// 业务流程布局结构Action
        /// </summary>
        /// <returns></returns>
        public ActionResult DefaultLayout()
        {
            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View();
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="form">查询条件表单</param>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //菜单查询模型
            CommonService.Model.SysManager.C_Menu menuConditon = new CommonService.Model.SysManager.C_Menu();

            if (!String.IsNullOrEmpty(form["C_Menu_name"]))
            {//菜单名称查询条件
                menuConditon.C_Menu_name = form["C_Menu_name"].Trim(); ;
            }

            //菜单查询模型传递到前端视图中
            ViewBag.OrgConditon = menuConditon;

            #endregion

            //获取菜单总记录数
            this.TotalRecordCount = _menuWCF.GetRecordCount(menuConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取菜单数据信息
            List<CommonService.Model.SysManager.C_Menu> menus = _menuWCF.GetListByPage(menuConditon,
                "T.C_Menu_order Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(menus);
        }

        /// <summary>
        /// 向前移动菜单Action
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MoveForward(int menuId)
        {
            bool isSuccess = _menuWCF.MoveForward(menuId);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("上移菜单成功！", "", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.MoveMenu));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("上移菜单失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 向后移动菜单Action
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MoveBackward(int menuId)
        {
            bool isSuccess = _menuWCF.MoveBackward(menuId);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("下移菜单成功！", "", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.MoveMenu));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("下移菜单失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }


        public ActionResult Tree(int? menuId)
        {
            SetSingleMenu(menuId);
            return View();
        }

        public ActionResult NoTargetTree()
        {
            SetSingleMenu(null);
            return View();
        }

        #region 不含checkbox的业务流程递归

        /// <summary>
        /// 根据关联外键Guid，获取关联所有业务流程信息
        /// </summary>
        /// <param name="pkCode">关联外键Guid</param>
        private void SetSingleMenu(int? menuId)
        {
            List<CommonService.Model.SysManager.C_Menu> menus = _menuWCF.GetAllList();
            SetSingleTopMenu(menus,menuId);
        }

        /// <summary>
        /// 装载顶级业务流程
        /// </summary>
        /// <param name="businessFlowList">业务流程集合</param>
        private void SetSingleTopMenu(List<CommonService.Model.SysManager.C_Menu> menuList, int? menuId)
        {
            string menuTreeHtml = "";
            string preTreeHtml = "<ul>";//树前缀
            string backTreeHtml = "</ul>";//树后缀
            var topMenuList = from allList in menuList
                                      where allList.C_Menu_parent == 0
                                      orderby allList.C_Menu_order ascending
                                      select allList;
            /*
             *
             *说明：只要在<li>标签上加上 class=jstree-open, 默认就会打开树,hety,2015-05-19
             */
            foreach (CommonService.Model.SysManager.C_Menu menu in topMenuList)
            {
                string href = "?{menuId}=" + menu.C_Menu_id.ToString();
                string uniqueId = menu.C_Menu_id.ToString();
                string defaultSelect = string.Empty;
                if (menuId != null)
                {
                    if (menu.C_Menu_id == menuId)
                    {
                        defaultSelect = "class=\"jstree-anchor jstree-clicked\"";
                    }
                }
                menuTreeHtml += "<li class=\"jstree-open\"><a " + defaultSelect + " uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + menu.C_Menu_name + "</a>";
                SetSignleRecursionTree(menu.C_Menu_id, ref menuTreeHtml, menuList,menuId);
                menuTreeHtml += "</li>";
            }
            ViewBag.SingleMenuTreeHtml = preTreeHtml + menuTreeHtml + backTreeHtml;
        }

        /// <summary>
        /// 递归加载所有业务流程
        /// </summary>
        /// <param name="parentCode">上级流程Code</param>
        /// <param name="businessFlowTreeHtml">业务流程 Tree Html</param>
        /// <param name="businessFlowList">业务流程集合</param>
        private void SetSignleRecursionTree(int parentId, ref string menuTreeHtml, List<CommonService.Model.SysManager.C_Menu> menuList, int? menuId)
        {
            var lowmenuList = from allList in menuList
                                      where allList.C_Menu_parent == parentId
                                      orderby allList.C_Menu_order ascending
                                      select allList;
            if (lowmenuList.Count() != 0)
            {
                menuTreeHtml += "<ul>";
            }
            /*
             *
             *说明：只要在<li>标签上加上 class=jstree-open, 默认就会打开树,hety,2015-05-19
             */
            foreach (CommonService.Model.SysManager.C_Menu menuFlow in lowmenuList)
            {
                string href = "?{menuId}=" + menuFlow.C_Menu_id.ToString();
                string uniqueId = menuFlow.C_Menu_id.ToString();
                string defaultSelect = string.Empty;
                if (menuId != null)
                {
                    if (menuFlow.C_Menu_id == menuId)
                    {
                        defaultSelect = "class=\"jstree-anchor jstree-clicked\"";
                    }
                }
                menuTreeHtml += "<li class=\"jstree-open\"><a " + defaultSelect + " uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + menuFlow.C_Menu_name + "</a>";
                SetSignleRecursionTree(menuFlow.C_Menu_id, ref menuTreeHtml, menuList,menuId);
                menuTreeHtml += "</li>";
            }
            if (lowmenuList.Count() != 0)
            {
                menuTreeHtml += "</ul>";
            }
        }

        #endregion

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.SysManager.C_Menu menu)
        {
            //服务方法调用
            int menuId = 0;

            if (menu.C_Menu_id > 0)
            {//修改
                bool isUpdateSuccess = _menuWCF.Update(menu);
                if (isUpdateSuccess)
                {
                    menuId = menu.C_Menu_id;
                }
            }
            else
            {//添加
                menuId = _menuWCF.Add(menu);
            }

            if (menuId > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存菜单信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存菜单信息成功", "/sysmanager/menu/create?menuId="+menu.C_Menu_parent, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存菜单信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存菜单信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int menuId)
        {
            bool isSuccess = _menuWCF.Delete(menuId);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除菜单信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除菜单信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        public ActionResult Test()
        {
            return View();
        }
	}
}