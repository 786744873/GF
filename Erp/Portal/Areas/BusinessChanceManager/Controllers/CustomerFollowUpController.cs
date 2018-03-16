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
    /// <summary>
    /// 客户跟踪列表控制器
    /// cyj
    /// 2015年12月21日11:04:32
    /// </summary>
    public class CustomerFollowUpController : BaseController
    {
        //
        // GET: /BusinessChanceManager/CustomerFollowUp/
        private readonly ICommonService.IC_Customer _customerWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.IC_Customer_Customer _customerClientWCF;
        private readonly ICommonService.IC_Customer_Region _customerRegionWCF;
        private readonly ICommonService.FlowManager.IP_Flow _flowWCF;
        private readonly ICommonService.IC_Customer_Follow _customer_FollowWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;

        public CustomerFollowUpController()
        {
            #region 服务初始化
            _customerWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer>("CustomerWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _customerClientWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer_Customer>("CustomerClientWCF");
            _customerRegionWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer_Region>("Customer_RegionWCF");
            _flowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow>("FlowWCF");
            _customer_FollowWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer_Follow>("CustomerFollowWCF");
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            #endregion

        }
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 添加客户跟进
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            InitializationPageParameter();
            CommonService.Model.C_Customer_Follow model = new CommonService.Model.C_Customer_Follow();
            model.C_Customer_Follow_code = Guid.NewGuid();
            model.C_Customer_Follow_isDelete = 0;
            model.C_Customer_Follow_createTime = DateTime.Now;
            model.C_Customer_Follow_creator = Context.UIContext.Current.UserCode;
            return View(model);
        }
        /// <summary>
        /// 修改客户跟进
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int customer_Follow_id)
        {
            InitializationPageParameter();
            CommonService.Model.C_Customer_Follow customerFollow = _customer_FollowWCF.GetModel(customer_Follow_id);
            List<CommonService.Model.C_Contacts> contactsList = _customerWCF.GetContactsListByCustomerCode(new Guid(customerFollow.C_Customer_code.ToString()));
            ViewBag.contactsList = contactsList;
            return View("Create", customerFollow);
        }
        /// <summary>
        /// 客户跟进详细
        /// </summary>
        /// <param name="customer_follow_code"></param>
        /// <returns></returns>
        public ActionResult Details(int customer_Follow_id)
        {
            CommonService.Model.C_Customer_Follow customerFollow = _customer_FollowWCF.GetModel(customer_Follow_id);
            return View(customerFollow);
        }
        /// <summary>
        /// 客户跟进详细
        /// </summary>
        /// <param name="customer_follow_code"></param>
        /// <returns></returns>
        public ActionResult GetModel(int customer_Follow_id)
        {
            CommonService.Model.C_Customer_Follow customerFollow = _customer_FollowWCF.GetModel(customer_Follow_id);
            return Json(customerFollow);
        }
        /// <summary>
        /// 客户跟踪tab
        /// </summary>
        /// <returns></returns>
        public ActionResult ListTab()
        {
            /***
             * author:崔慧栋
             * date:2016-03-02     
             ***/

            if (UIContext.Current.IsPreSetManager)
            {
                return RedirectToAction("list");
            }

            return View();
        }
        /// <summary>
        /// 客户跟进列表
        /// </summary>
        /// <returns></returns>
        public ActionResult List(FormCollection form, int? page = 1)
        {           
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)
            //客户跟进查询模型
            CommonService.Model.C_Customer_Follow Conditon = new CommonService.Model.C_Customer_Follow();
            //客户查询模型
            CommonService.Model.C_Customer customerConditon = new CommonService.Model.C_Customer();
            if (!String.IsNullOrEmpty(form["C_Customer_name"]))
            {//客户名称查询条件
                customerConditon.C_Customer_name = form["C_Customer_name"].Trim();
            }
            #region   高级查询条件
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
            if (!String.IsNullOrEmpty(form["C_Customer_Follow_contactInformation"]) && form["C_Customer_Follow_contactInformation"].ToString() != "全部")
            {//联系方式查询条件
                Conditon.C_Customer_Follow_contactInformation = Convert.ToInt32(form["C_Customer_Follow_contactInformation"]);
            }
            #endregion

            //查询模型传递到前端视图中
            ViewBag.Conditon = Conditon;
            ViewBag.customerConditon = customerConditon;
            #endregion

            //用户所属部门
            Guid? orgCode = GetOrgCode(form);
            //用户所属岗位
            Guid? postCode = GetPostCode(form);
            //用户所属岗位组
            Guid? postGroupCode = GetPostGroupCode(form);

            //获取总记录数
            this.TotalRecordCount = _customer_FollowWCF.GetRecordCount2(Conditon, customerConditon, Context.UIContext.Current.IsPreSetManager, Context.UIContext.Current.UserCode, postGroupCode);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 20;

            List<CommonService.Model.C_Customer_Follow> customerFollow = _customer_FollowWCF.GetListByPage2(Conditon, customerConditon, Context.UIContext.Current.IsPreSetManager, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, Context.UIContext.Current.UserCode, postGroupCode);

            #region 权限
            this.DistributedInitButtonsPower(orgCode, postCode);
            this.DistributedInitLogin(orgCode, postCode, postGroupCode);
            #endregion

            return View(customerFollow);
        }
        /// <summary>
        /// 获取客户的联系人
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetContacterList(string customerCode)
        {
            List<CommonService.Model.C_Contacts> contactsList = _customerWCF.GetContactsListByCustomerCode(new Guid(customerCode));
            return Json(contactsList);          
        }
        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.C_Customer_Follow customerFollow)
        {
            //获取该用户下的正在进行的流程（客户生命周期）
            CommonService.Model.FlowManager.P_Business_flow Fmodel = _bussinessFlowWCF.GetCustomerIngBusinessFlow(Convert.ToInt32(FlowTypeEnum.客户), new Guid(form["customermulitylookup.Code"].ToString()), Convert.ToInt32(BusinessFlowStatus.正在进行));
            customerFollow.C_Customer_code = new Guid(form["customermulitylookup.Code"].ToString());
            customerFollow.C_Customer_Follow_contacter = new Guid(form["C_Customer_Follow_contacter"].ToString());
            //服务方法调用
            int customerFollowId = 0;

            if (customerFollow.C_Customer_Follow_id > 0)
            {//修改
                bool isUpdateSuccess = _customer_FollowWCF.Update(customerFollow);
                if (isUpdateSuccess)
                {
                    customerFollowId = customerFollow.C_Customer_Follow_id;
                }
            }
            else
            {//添加
                if (Fmodel != null)
                {
                    customerFollow.C_Customer_Business_Flow = Fmodel.P_Business_flow_code;
                }
                customerFollow.C_Customer_Follow_createTime = DateTime.Now;
                customerFollowId = _customer_FollowWCF.Add(customerFollow);
                //添加完成后更新客户的最后接触时间
                CommonService.Model.C_Customer model = _customerWCF.Get(new Guid(customerFollow.C_Customer_code.ToString()));
                model.C_Customer_lastContactDate = customerFollow.C_Customer_Follow_createTime;
                if (!_customerWCF.Update(model))
                    customerFollowId = -1;
            }

            if (customerFollowId >= 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存客户跟进信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存客户跟进信息成功", "/BusinessChanceManager/CustomerFollowUp/create", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存客户跟进信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存客户跟进信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
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
            //联系方式参数集合
            List<CommonService.Model.C_Parameters> contactInformations = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFollowEnum.联系方式));
            ViewBag.ContactInformations = contactInformations;
            //跟进阶段参数集合
            List<CommonService.Model.C_Parameters> Customer_Follow_Stages = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFollowEnum.跟进阶段));
            ViewBag.Customer_Follow_Stages = Customer_Follow_Stages;

        }

        #region 用户所属部门岗位

        /// <summary>
        /// 用户所属部门
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Guid? GetOrgCode(FormCollection form)
        {
            Guid? orgCode = null;
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
                this.AddressUrlParameters += "&orgCode=" + orgCode;
            ViewBag.OrgCode = orgCode;

            return orgCode;
        }
        /// <summary>
        /// 用户所属岗位
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Guid? GetPostCode(FormCollection form)
        {
            Guid? postCode = null;

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

            return postCode;
        }
        /// <summary>
        /// 获取所属岗位组
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public Guid? GetPostGroupCode(FormCollection form)
        {
            Guid? postGroupCode = null;

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

            return postGroupCode;
        }

        #endregion

	}
}