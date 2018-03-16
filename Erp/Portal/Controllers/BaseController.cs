using Maticsoft.Common;
using Portal.Filter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Controllers
{
    /// <summary>
    /// 公共控制器
    /// </summary>   
    [CustomerAuthorizeFilter]
    [CustomerErrorFilter]
    public class BaseController : UserAuthenticationController
    {
        private readonly ICommonService.SysManager.IC_Role_button _roleButtonWCF;
        private readonly ICommonService.SysManager.IC_Role_Role_Power _roleRolePower;

        /// <summary>
        /// 一页显示记录数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int ThisPageIndex { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalRecordCount { get; set; }
        /// <summary>
        /// 总页码数
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        /// 地址栏url参数(格式为:?year=3&age=25,默认为空字符串，代表没有url参数),不包括分页条件
        /// </summary>
        public string AddressUrlParameters { get; set; }
        /// <summary>
        /// 表单查询FormId(针对分页控件)
        /// </summary>
        private string SearchFormID { get; set; }
        /// <summary>
        /// 是否已执行过表单查询
        /// </summary>
        public bool IsExcutedFormSearch { get; set; }

        public BaseController()
        {
            //一页显示记录数
            PageSize = 20;
            TotalPages = 0;
            AddressUrlParameters = "";
            IsExcutedFormSearch = false;

            _roleButtonWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Role_button>("Role_buttonWCF");
            _roleRolePower = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Role_Role_Power>("Role_Role_PowerWCF");
        }

        //
        // GET: /Base/
        public virtual ActionResult Index()
        {

            return View();
        }

        /// <summary>
        /// 初始化页码信息
        /// </summary>
        /// <param name="form">查询form表单</param>
        /// <param name="thisPageIndex">地址栏传入当前页码</param>
        public void InitializationPageInfo(FormCollection form, int thisPageIndex)
        {
            //默认当前页码赋值
            this.ThisPageIndex = thisPageIndex;

            if (!String.IsNullOrEmpty(form["ThisPageIndex"]))
            {//当前页码条件(固定写法)
                this.ThisPageIndex = Convert.ToInt32(form["ThisPageIndex"]);
            }
            if (!String.IsNullOrEmpty(form["IsExcutedFormSearch"]))
            {//是否已执行过点击表单查询(固定写法)
                this.IsExcutedFormSearch = true;
            }

            ViewData["currentPageIndex"] = this.ThisPageIndex;
            ViewData["totalCount"] = this.TotalRecordCount;

            //计算总页数
            if (this.TotalRecordCount % this.PageSize == 0)
            {
                this.TotalPages = this.TotalRecordCount / this.PageSize;
            }
            else
            {
                this.TotalPages = this.TotalRecordCount / this.PageSize + 1;
            }
            ViewData["totalPages"] = this.TotalPages;//总页码数

            ViewData["addressUrlParameters"] = this.AddressUrlParameters;//地址栏查询参数

            SearchFormID = Request.Url.PathAndQuery.ToLower().Split('?')[0].Replace("/", "");//去掉url参数
            ViewBag.ThisPageIndex = this.ThisPageIndex;
            ViewBag.SearchFormID = this.SearchFormID;
            ViewBag.IsExcutedFormSearch = this.IsExcutedFormSearch == true ? 1 : 0;
        }

        /// <summary>
        /// 初始化按钮权限(采用对按钮进行编号方式处理)(通用列表按钮)
        /// </summary>
        public void InitializationButtonsPower()
        {

            List<CommonService.Model.SysManager.C_Role_button> RoleButtons;
            if (Context.UIContext.Current.IsPreSetManager)
            {//内置系统管理员拥有所有按钮权限
                RoleButtons = new List<CommonService.Model.SysManager.C_Role_button>();
            }
            else
            {
                RoleButtons = _roleButtonWCF.GetButtonsListByRolesId(Context.UIContext.Current.UserRoles);
            }      
     
            ViewBag.RoleButtons = RoleButtons;

            //把按钮权限集合转换为字符串
            string roleButtonIds = String.Empty;
            foreach (var item in RoleButtons)
            {
                roleButtonIds += item.C_Menu_buttons_id.Value + ",";
            }
            if (roleButtonIds != "")
            {
                roleButtonIds = roleButtonIds.Substring(0, roleButtonIds.Length-1);
            }
            ViewBag.RoleButtonIds = roleButtonIds;
        }

        /// <summary>
        /// 分布式初始化按钮权限(采用对按钮进行编号方式处理)(只针对 “通过组织机构Guid+用户Guid+岗位Guid” 进行初始化的列表按钮)
        /// </summary>
        public void DistributedInitButtonsPower(Guid? orgCode,Guid? postCode)
        {
            List<CommonService.Model.SysManager.C_Role_button> RoleButtons;
            if (Context.UIContext.Current.IsPreSetManager)
            {//内置系统管理员拥有所有按钮权限
                RoleButtons = new List<CommonService.Model.SysManager.C_Role_button>();                
            }
            else
            {
                RoleButtons = _roleButtonWCF.GetButtonsListByOrgUserPostCode(orgCode, Context.UIContext.Current.RootUserCode,postCode);             
            }          

            ViewBag.RoleButtons = RoleButtons;

            //把按钮权限集合转换为字符串
            string roleButtonIds = String.Empty;
            foreach (var item in RoleButtons)
            {
                roleButtonIds += item.C_Menu_buttons_id.Value + ",";
            }
            if (roleButtonIds != "")
            {
                roleButtonIds = roleButtonIds.Substring(0, roleButtonIds.Length - 1);
            }
            ViewBag.RoleButtonIds = roleButtonIds;
        }

        /// <summary>
        /// 分布式初始化用户登录信息
        /// </summary>
        /// <param name="orgCode">当前组织机构Guid</param>
        /// <param name="postCode">当前岗位Guid</param>
        /// <param name="postGroupCode">当前岗位组Guid</param>
        public void DistributedInitLogin(Guid? orgCode, Guid? postCode,Guid? postGroupCode)
        {
            if (!Context.UIContext.Current.IsPreSetManager)
            {
                this.RefreshOnlineOwinAuth(orgCode, postCode, postGroupCode);
            }
        }

        /// <summary>
        /// 初始化用户角色权限(只根据用户标识进行初始化)
        /// </summary>
        public void InitializationRolePower()
        {
            //如果为内置系统管理员，则不允许查关联角色权限
            List<CommonService.Model.SysManager.C_Role_Role_Power> Role_RolePowers;
            if (Context.UIContext.Current.IsPreSetManager)
            {
                Role_RolePowers = new List<CommonService.Model.SysManager.C_Role_Role_Power>();

            }
            else
            {
                Role_RolePowers = _roleRolePower.GetRolePowersByUserCode(Context.UIContext.Current.UserCode);
            }

            ViewBag.RoleRolePowers = Role_RolePowers;
        }

        #region OA
        /// <summary>
        /// OA内容页面头部Action
        /// </summary>
        /// <returns></returns>
        public PartialViewResult OAContentPageHead()
        {
            return PartialView("_OAContentPageHeadPartial");
        }
        /// <summary>
        /// OA内容页面头部Action
        /// </summary>
        /// <returns></returns>
        public PartialViewResult ReportingContentPageHead()
        {
            return PartialView("_ReportingContentPageHeadPartial");
        }
        #endregion

    }
}