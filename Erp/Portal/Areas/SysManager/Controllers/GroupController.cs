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
        /// 分组控制器
        /// 作者：崔慧栋
        /// 日期：2015/05/28
        /// </summary>
    public class GroupController : BaseController
    {
         private readonly ICommonService.SysManager.IC_Group _groupWCF;
         private readonly ICommonService.SysManager.IC_Roles _rolesWCF;
         public GroupController()
        {
            #region 服务初始化
            _groupWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Group>("GroupWCF");
            _rolesWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Roles>("RolesWCF");
            #endregion
        }
        //
        // GET: /SysManager/Group/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string groupCode)
        {
            //创建初始化菜单实体
            CommonService.Model.SysManager.C_Group group = new CommonService.Model.SysManager.C_Group();
            List<CommonService.Model.SysManager.C_Roles> roles = _rolesWCF.GetAllList();
            ViewBag.Roles = roles;
            if (!String.IsNullOrEmpty(groupCode))
            {
                group.C_Group_parent =new Guid(groupCode);
            }
            group.C_Group_code = Guid.NewGuid();
            group.C_Group_isDelete = 0;
            group.C_Group_creator = Context.UIContext.Current.UserCode;
            group.C_Group_createTime = DateTime.Now;

            if (group.C_Group_parent == null)
            {
                ViewBag.SelectedGroupCode = "";
            }
            else
            {
                ViewBag.SelectedGroupCode = groupCode;
            }

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(group);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string groupCode)
        {
            if (String.IsNullOrEmpty(groupCode))
            {
                return RedirectToAction("Create");
            }
            CommonService.Model.SysManager.C_Group group = _groupWCF.GetModelByCode(new Guid(groupCode));
            ViewBag.SelectedGroupCode = groupCode;
            List<CommonService.Model.SysManager.C_Roles> roles = _rolesWCF.GetAllList();
            ViewBag.Roles = roles;

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View("Create", group);
        }

        /// <summary>
        /// 布局TreeList
        /// </summary>
        /// <returns></returns>
        public ActionResult LayoutTreeList()
        {
            return View();
        }

        /// <summary>
        /// 生成分组树Action
        /// </summary>
        /// <returns></returns>
        public ActionResult Tree(int sourceType)
        {
            SetSingleGroup(sourceType);
            ViewBag.SourceType = sourceType;
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
            CommonService.Model.SysManager.C_Group menuConditon = new CommonService.Model.SysManager.C_Group();

            if (!String.IsNullOrEmpty(form["C_Menu_name"]))
            {//菜单名称查询条件
                menuConditon.C_Group_name = form["C_Menu_name"].Trim(); ;
            }

            //菜单查询模型传递到前端视图中
            ViewBag.OrgConditon = menuConditon;

            #endregion

            //获取菜单总记录数
            this.TotalRecordCount = _groupWCF.GetRecordCount(menuConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取菜单数据信息
            List<CommonService.Model.SysManager.C_Group> menus = _groupWCF.GetListByPage(menuConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            return View(menus);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(CommonService.Model.SysManager.C_Group group)
        {
            //服务方法调用
            int groupId = 0;

            if (group.C_Group_id > 0)
            {//修改
                bool isUpdateSuccess = _groupWCF.Update(group);
                if (isUpdateSuccess)
                {
                    groupId = group.C_Group_id;
                }
            }
            else
            {//添加
                groupId = _groupWCF.Add(group);
            }

            if (groupId > 0)
            {
                //保存成功提示固定写法
                return Json(TipHelper.JsonData("保存分组信息成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshParent));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存分组信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string groupCode)
        {
            bool isSuccess = _groupWCF.Delete(new Guid(groupCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除分组信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshParent));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除分组信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        #region 不含checkbox的组织机构递归

        /// <summary>
        ///  装载全部组织机构信息
        /// </summary>
        private void SetSingleGroup(int sourceType)
        {
            List<CommonService.Model.SysManager.C_Group> groups = _groupWCF.GetAllList();
            SetSingleTopGroup(groups, sourceType);
        }

        /// <summary>
        /// 装载顶级组织机构
        /// </summary>
        /// <param name="organizationList">组织机构集合</param>
        /// <param name="sourceType">调用组织机构来源:1 代表组织机构页面自身调用；2 代表业务流程分配负责人页面调用</param>
        private void SetSingleTopGroup(List<CommonService.Model.SysManager.C_Group> groupList, int sourceType)
        {
            string groupTreeHtml = "";
            string preTreeHtml = "<ul>";//树前缀
            string backTreeHtml = "</ul>";//树后缀
            var topGroupList = from allList in groupList
                                      where allList.C_Group_parent == null
                                      orderby allList.C_Group_id ascending
                                      select allList;
            /*
             *
             *说明：只要在<li>标签上加上 class=jstree-open, 默认就会打开树,hety,2015-05-19
             */
            foreach (CommonService.Model.SysManager.C_Group group in topGroupList)
            {
                string href = "";
                switch (sourceType)
                {
                    case 1://组织机构页面自身调用
                        //href = "/sysmanager/group/edit?groupId=" + group.C_Group_id;
                        href = "?{groupCode}=" + group.C_Group_code;
                        break;
                }
                string uniqueId = group.C_Group_code.ToString();
                groupTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + group.C_Group_name + "</a>";
                SetSignleRecursionTree(group.C_Group_code.Value, ref groupTreeHtml, groupList, sourceType);
                groupTreeHtml += "</li>";
            }
            ViewBag.SingleGroupTreeHtml = preTreeHtml + groupTreeHtml + backTreeHtml;
        }

        /// <summary>
        /// 递归加载所有组织机构
        /// </summary>
        /// <param name="parentCode">上级组织机构Code</param>
        /// <param name="organizationTreeHtml">组织机构Tree Html</param>
        /// <param name="organizationList">组织机构集合</param>
        private void SetSignleRecursionTree(Guid parentCode, ref string groupTreeHtml, List<CommonService.Model.SysManager.C_Group> groupList, int sourceType)
        {
            var lowgroupList = from allList in groupList
                                      where allList.C_Group_parent == parentCode
                                      orderby allList.C_Group_id ascending
                                      select allList;
            if (lowgroupList.Count() != 0)
            {
                groupTreeHtml += "<ul>";
            }
            /*
             *
             *说明：只要在<li>标签上加上 class=jstree-open, 默认就会打开树,hety,2015-05-19
             */
            foreach (CommonService.Model.SysManager.C_Group group in lowgroupList)
            {
                string href = "";

                switch (sourceType)
                {
                    case 1://组织机构页面自身调用
                        //href = "/sysmanager/group/edit?groupId=" + group.C_Group_id;
                        href = "?{groupCode}=" + group.C_Group_code;
                        break;
                }

                string uniqueId = group.C_Group_code.ToString();
                groupTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + group.C_Group_name + "</a>";
                SetSignleRecursionTree(group.C_Group_code.Value, ref groupTreeHtml, groupList, sourceType);
                groupTreeHtml += "</li>";
            }
            if (lowgroupList.Count() != 0)
            {
                groupTreeHtml += "</ul>";
            }
        }

        #endregion

        public ActionResult Test()
        {
            return View();
        }
	}
}