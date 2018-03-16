using CommonService.Common;
using Context;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.BusinessChanceManager.Controllers
{
    public class CustomerController : BaseController
    {
        //
        // GET: /BusinessChanceManager/Custerm/
        private readonly ICommonService.IC_Customer _customerWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.IC_Customer_Customer _customerClientWCF;
        private readonly ICommonService.IC_Customer_Region _customerRegionWCF;
        private readonly ICommonService.FlowManager.IP_Flow _flowWCF;
        private readonly ICommonService.IC_Region _regionWCF;
        public CustomerController()
        {
            #region 服务初始化
            _customerWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer>("CustomerWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _customerClientWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer_Customer>("CustomerClientWCF");
            _customerRegionWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer_Region>("Customer_RegionWCF");
            _flowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow>("FlowWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");

            #endregion
        }
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 客户tab
        /// </summary>
        /// <returns></returns>
        public ActionResult ListTab()
        {
            /***
             * author:hety
             * date:2016-01-25
             * description:按岗位进行划分客户Tab页签(一人多岗位，每个岗位角色权限可以不一样)(内置系统管理员不需要按Tab页签划分)           
             ***/

            if (UIContext.Current.IsPreSetManager)
            {
                return RedirectToAction("list");
            }

            return View();
        }
        public ActionResult List(FormCollection form, int? page = 1, int? type = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //客户查询模型
            CommonService.Model.C_Customer customerConditon = new CommonService.Model.C_Customer();

            customerConditon.C_Customer_Region_code = Guid.Empty.ToString();
            if (!String.IsNullOrEmpty(form["C_Customer_name"]))
            {//客户名称查询条件
                customerConditon.C_Customer_name = form["C_Customer_name"].Trim();
            }
            if (!String.IsNullOrEmpty(form["C_Customer_type"]))
            {//客户名称查询条件
                customerConditon.C_Customer_type = Convert.ToInt32(form["C_Customer_type"].Trim());
            }
            if (!String.IsNullOrEmpty(form["C_Customer_Follow_time_type"]))
            {//客户名称查询条件
                customerConditon.C_Customer_Follow_time_type = Convert.ToInt32(form["C_Customer_Follow_time_type"].Trim());
            }
            customerConditon.C_Customer_businessType = Convert.ToInt32(CustomerBusiness.客户);
            //客户查询模型传递到前端视图中
            switch (type)
            {
                case 2:
                    customerConditon.C_Customer_type = Convert.ToInt32(CustomertypeEnum.单位);
                    break;
                case 3:
                    customerConditon.C_Customer_type = Convert.ToInt32(CustomertypeEnum.个体户);
                    break;
                case 4:
                    customerConditon.C_Customer_Follow_time_type = 1;
                    break;
                case 5:
                    customerConditon.C_Customer_Follow_time_type = 2;
                    break;
                case 6:
                    customerConditon.C_Customer_Follow_time_type = 3;
                    break;
                case 7:
                    customerConditon.C_Customer_Follow_time_type = 4;
                    break;
            }
            #region   新增高级查询条件
            if (!String.IsNullOrEmpty(form["C_Customer_level"]) && form["C_Customer_level"].ToString() != "全部")
            {//客户级别查询条件
                customerConditon.C_Customer_level = Convert.ToInt32(form["C_Customer_level"]);
            }
            if (!String.IsNullOrEmpty(form["C_Customer_lastContactDate"]))
            {//最后跟进日期开始时间查询条件
                customerConditon.C_Customer_lastContactDate = Convert.ToDateTime(form["C_Customer_lastContactDate"]);
            }
            if (!String.IsNullOrEmpty(form["C_Customer_lastContactendDate"]))
            {//最后跟进日期结束时间查询条件
                customerConditon.C_Customer_lastContactEndDate = Convert.ToDateTime(form["C_Customer_lastContactendDate"]);
            }
            if (!String.IsNullOrEmpty(form["mainLawyerlookup.Code"]))
            {//专业顾问查询条件
                customerConditon.C_Customer_consultant = new Guid(form["mainLawyerlookup.Code"].ToString());
                customerConditon.C_Customer_consultant_name = form["mainLawyerlookup.Name"];
            }
            if (!String.IsNullOrEmpty(form["C_Customer_Category"]) && form["C_Customer_Category"].ToString() != "全部")
            {//客户类别查询条件
                customerConditon.C_Customer_Category = Convert.ToInt32(form["C_Customer_Category"]);
            }
            if (!String.IsNullOrEmpty(form["C_Customer_Open"]) && form["C_Customer_Open"].ToString() != "全部")
            {//客户开发阶段查询条件
                customerConditon.C_Customer_Open = new Guid(form["C_Customer_Open"]);
            }
            if (!String.IsNullOrEmpty(form["C_Customer_source"]) && form["C_Customer_source"].ToString() != "全部")
            {//客户来源查询条件
                customerConditon.C_Customer_source = Convert.ToInt32(form["C_Customer_source"]);
            }
            if (!String.IsNullOrEmpty(form["C_Customer_loyalty"]) && form["C_Customer_loyalty"].ToString() != "全部")
            {//客户忠诚度查询条件
                customerConditon.C_Customer_loyalty = Convert.ToInt32(form["C_Customer_loyalty"]);
            }
            if (!String.IsNullOrEmpty(form["C_Customer_isSignedState"]) && form["C_Customer_isSignedState"].ToString() != "全部")
            {//是否签约查询条件
                customerConditon.C_Customer_isSignedState = Convert.ToInt32(form["C_Customer_isSignedState"]);
            }
            if (!String.IsNullOrEmpty(form["C_Customer_signedState"]) && form["C_Customer_signedState"].ToString() != "全部")
            {//签约状态查询条件
                customerConditon.C_Customer_signedState = Convert.ToInt32(form["C_Customer_signedState"]);
            }
            if (!String.IsNullOrEmpty(form["C_Region_code"]) && form["C_Region_code"].ToString() != "全部")
            {//区域查询条件
                customerConditon.C_Customer_Region_code = form["C_Region_code"];
            }
            if (!String.IsNullOrEmpty(form["responsibleDeptlookup.Code"]) && form["responsibleDeptlookup.Code"].ToString() != "全部")
            {//组织架构查询条件
                customerConditon.C_Customer_responsibleDept = new Guid(form["responsibleDeptlookup.Code"]);
                customerConditon.C_Customer_responsibleDept_Name = form["responsibleDeptlookup.Name"];
            }
            #endregion

            #region 用户所属部门岗位处理
            Guid? orgCode = null;
            Guid? postCode = null;
            Guid? postGroupCode = null;
            //所属部门Guid
            if (!String.IsNullOrEmpty(form["orgCode"]))
            {
                orgCode = new Guid(form["orgCode"]);
            }
            if (Request.QueryString["orgCode"] != null)
            {
                orgCode = new Guid(Request.QueryString["orgCode"]);
            }
            if (orgCode != null)
                this.AddressUrlParameters = "?orgCode=" + orgCode;
            ViewBag.OrgCode = orgCode;
            //所属岗位Guid
            if (!String.IsNullOrEmpty(form["postCode"]))
            {
                postCode = new Guid(form["postCode"]);
            }
            if (Request.QueryString["postCode"] != null)
            {
                postCode = new Guid(Request.QueryString["postCode"]);
            }
            if (postCode != null)
                this.AddressUrlParameters += "&postCode=" + postCode;
            ViewBag.PostCode = postCode;
            //所属岗位组
            if (!String.IsNullOrEmpty(form["postGroupCode"]))
            {
                postGroupCode = new Guid(form["postGroupCode"]);
            }
            if (Request.QueryString["postGroupCode"] != null)
            {
                postGroupCode = new Guid(Request.QueryString["postGroupCode"]);
            }
            if (postGroupCode != null)
                this.AddressUrlParameters += "&postGroupCode=" + postGroupCode;
            ViewBag.PostGroupCode = postGroupCode;
            #endregion

            ViewBag.CustomerConditon = customerConditon;
            #endregion

            //this.AddressUrlParameters = "?type=" + type;
            //获取客户总记录数
            this.TotalRecordCount = _customerWCF.GetCustomerListCount(customerConditon, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, postCode, orgCode);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取客户数据信息
            List<CommonService.Model.C_Customer> customers = _customerWCF.GetCustomerListByPage(customerConditon,
                "C_Customer_id Asc,T.C_Customer_name Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, postCode, orgCode);

            #region 权限
            this.DistributedInitButtonsPower(orgCode, postCode);
            this.DistributedInitLogin(orgCode, postCode, postGroupCode);
            #endregion

            return View(customers);
        }
        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //客户类型参数集合
            List<CommonService.Model.C_Parameters> CustomerTypes = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户类型));
            ViewBag.CustomerTypes = CustomerTypes;
            //行业参数集合
            List<CommonService.Model.C_Parameters> Industrys = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.行业));
            ViewBag.Industrys = Industrys;
            //客户来源参数集合
            List<CommonService.Model.C_Parameters> CustomerSources = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户来源));
            ViewBag.CustomerSources = CustomerSources;
            //客户级别参数集合
            List<CommonService.Model.C_Parameters> CustomerLevels = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户级别));
            ViewBag.CustomerLevels = CustomerLevels;
            //是否签约客户状态参数集合
            List<CommonService.Model.C_Parameters> IsSignedStates = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.是否签约客户));
            ViewBag.IsSignedStates = IsSignedStates;
            //签约客户状态参数集合
            List<CommonService.Model.C_Parameters> SignedStates = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.签约客户状态));
            ViewBag.SignedStates = SignedStates;
            //客户忠诚度参数集合
            List<CommonService.Model.C_Parameters> CustomerLoyaltys = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户忠诚度));
            ViewBag.CustomerLoyaltys = CustomerLoyaltys;
            //客户状态参数集合
            List<CommonService.Model.C_Parameters> State = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户状态));
            ViewBag.State = State;
            //客户类别参数集合
            List<CommonService.Model.C_Parameters> Category = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerEnum.客户类别));
            ViewBag.Category = Category;
            List<CommonService.Model.FlowManager.P_Flow> Flows = _flowWCF.GetListByFlowType(Convert.ToInt32(FlowTypeEnum.客户));
            ViewBag.Flows = Flows;
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.RegionList = regionList;
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        /// <param name="customer">客户对象</param>
        private void InitializationPageParameter(CommonService.Model.C_Customer customer)
        {
            //客户类型参数集合
            CommonService.Model.C_Parameters CustomerType = _parameterWCF.GetModel(customer.C_Customer_type.Value);
            ViewBag.CustomerType = CustomerType;
            //行业参数集合
            CommonService.Model.C_Parameters Industry = new CommonService.Model.C_Parameters();
            if (customer.C_Customer_industryCode == null)
            {
                ViewBag.Industry = Industry;
            }
            else
            {
                Industry = _parameterWCF.GetModel(customer.C_Customer_industryCode.Value);
                ViewBag.Industry = Industry;
            }
            //客户来源参数集合
            CommonService.Model.C_Parameters CustomerSource = _parameterWCF.GetModel(customer.C_Customer_source.Value);
            ViewBag.CustomerSource = CustomerSource;
            //客户级别参数集合
            CommonService.Model.C_Parameters CustomerLevel = _parameterWCF.GetModel(customer.C_Customer_level.Value);
            ViewBag.CustomerLevel = CustomerLevel;
            //是否签约客户状态参数集合
            CommonService.Model.C_Parameters IsSignedState = new CommonService.Model.C_Parameters();
            if (customer.C_Customer_isSignedState == null)
            {
                ViewBag.IsSignedState = IsSignedState;
            }
            else
            {
                IsSignedState = _parameterWCF.GetModel(customer.C_Customer_isSignedState.Value);
                ViewBag.IsSignedState = IsSignedState;
            }
            //签约客户状态参数集合
            CommonService.Model.C_Parameters SignedState = new CommonService.Model.C_Parameters();
            if (customer.C_Customer_signedState == null)
            {
                ViewBag.SignedState = SignedState;
            }
            else
            {
                SignedState = _parameterWCF.GetModel(customer.C_Customer_signedState.Value);
                ViewBag.SignedState = SignedState;
            }
            //客户忠诚度参数集合
            CommonService.Model.C_Parameters CustomerLoyalty = _parameterWCF.GetModel(customer.C_Customer_loyalty.Value);
            ViewBag.CustomerLoyalty = CustomerLoyalty;
            //客户状态参数集合
            CommonService.Model.C_Parameters State = new CommonService.Model.C_Parameters();
            if (customer.C_Customer_State == null)
            {
                ViewBag.State = State;
            }
            else
            {
                State = _parameterWCF.GetModel(customer.C_Customer_State.Value);
                ViewBag.State = State;
            }
            //客户类别参数集合
            CommonService.Model.C_Parameters Category = new CommonService.Model.C_Parameters();
            if (customer.C_Customer_Category == null)
            {
                ViewBag.Category = Category;
            }
            else
            {
                Category = _parameterWCF.GetModel(customer.C_Customer_Category.Value);
                ViewBag.Category = Category;
            }
        }
    }
}