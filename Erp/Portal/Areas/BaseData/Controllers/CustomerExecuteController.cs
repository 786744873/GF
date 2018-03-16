using CommonService.Common;
using Context;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.BaseData.Controllers
{
    /// <summary>
    /// 客户生命周期控制器
    /// </summary>
    public class CustomerExecuteController : BaseController
    {
        private readonly ICommonService.IC_Customer _customerWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.SysManager.IC_Role_Role_Power _roleRolePowerWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;

        public CustomerExecuteController()
        {
            //服务初始化话
            _customerWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer>("CustomerWCF");
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _roleRolePowerWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Role_Role_Power>("Role_Role_PowerWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
        }

        //
        // GET: /BaseData/CustomerExecute/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 客户执行布局页Action
        /// </summary>
        /// <param name="customerCode">客户Guid</param>
        /// <returns></returns>
        public ActionResult DefaultLayout(string customerCode)
        {
            List<CommonService.Model.FlowManager.P_Business_flow> BusinessFlows = _bussinessFlowWCF.GetListByFkCodeAndLevel(new Guid(customerCode), 1);
            CommonService.Model.C_Customer Customer = _customerWCF.Get(new Guid(customerCode));
            this.InitializationPageParameter(Customer);

            ViewBag.Customer = Customer;//客户数据模型
            ViewBag.FkType = Convert.ToInt32(FlowTypeEnum.客户);//流程类型

            #region 数据权限
            List<CommonService.Model.SysManager.C_Role_Role_Power> roleRolePowers;
            if (Context.UIContext.Current.IsPreSetManager)
            {
                roleRolePowers = new List<CommonService.Model.SysManager.C_Role_Role_Power>();
            }
            else
            {
                roleRolePowers = _roleRolePowerWCF.GetRolePowersByOrgPostUserCode(Context.UIContext.Current.OrgCode,
                    Context.UIContext.Current.UserCode,Context.UIContext.Current.PostCode);
            }
            ViewBag.RoleRolePowers = roleRolePowers;

            bool isCustomerConsultant = false;//当前登录用户是否此客户专业顾问
            if (!Context.UIContext.Current.IsPreSetManager)
            {
                //当前客户专业顾问
                if (Customer.C_Customer_consultant != null && Context.UIContext.Current.UserCode == Customer.C_Customer_consultant)
                {
                    isCustomerConsultant = true;
                }
            }

            ViewBag.IsCustomerConsultant = isCustomerConsultant;
            #endregion

            #region 按钮权限

            /**
             * author:hety
             * date:2015-11-24
             * descption:
             * 在客户未启动的情况下，"客户启动"按钮，根据当前用户是否拥有此按钮的权限来控制(内置系统管理员除外)
             ***/
            bool isShowStartBtn = false;//是否显示"客户启动"按钮
            if (Customer != null)
            {
                if (Customer.C_Customer_goingStatus == Convert.ToInt32(BusinessFlowStatus.未开始))
                {
                    if (Context.UIContext.Current.IsPreSetManager)
                    {
                        isShowStartBtn = true;
                    }
                    else
                    {
                        this.DistributedInitButtonsPower(Context.UIContext.Current.OrgCode,Context.UIContext.Current.PostCode);
                        List<CommonService.Model.SysManager.C_Role_button> RoleButtons = ViewBag.RoleButtons;
                        if (RoleButtons.Where(r => r.C_Menu_buttons_id == 1163).Count() != 0)
                        {//存在"启动任务"的按钮，按钮标识为：1163
                            isShowStartBtn = true;
                        }
                    }
                }
            }
            ViewBag.IsShowStartBtn = isShowStartBtn;
            #endregion

            return View(BusinessFlows);
        }

        #region 客户计划相关

        /// <summary>
        /// 显示设置客户计划
        /// </summary>       
        /// <param name="customerCode">客户Guid</param>
        /// <returns></returns>
        public ActionResult ShowSetCustomerPlan(string customerCode)
        {
            /**
             * 查看此界面时，要将老客户里面的负责人和首席专家根据专业顾问添加相应的数据 --cyj
             * 
             * **/
            _customerWCF.SetMinisterAndChiefResponsible(customerCode, UIContext.Current.OrgCode);
            CommonService.Model.C_Customer Customer = _customerWCF.Get(new Guid(customerCode));//客户数据模型  
            //负责人
            List<CommonService.Model.SysManager.C_Userinfo> responsiblePersons = _userinfoWCF.GetAllChildList(1);
            if (responsiblePersons.Count() == 0)
            {
                if (Customer.C_Customer_responsiblePerson != null)
                {
                    CommonService.Model.SysManager.C_Userinfo uModel = _userinfoWCF.GetModelByUserCode(Customer.C_Customer_responsiblePerson.Value);
                    if (uModel != null)
                    {
                        responsiblePersons.Add(uModel);
                    }
                }

            }
            ViewBag.ResponsiblePersons = responsiblePersons;

            //首席负责人
            List<CommonService.Model.SysManager.C_Userinfo> chiefResponsiblePersons = _userinfoWCF.GetAllChildList(2);
            if (chiefResponsiblePersons.Count() == 0)
            {
                if (Customer.C_Customer_chiefResponsiblePerson != null)
                {
                    CommonService.Model.SysManager.C_Userinfo uModel = _userinfoWCF.GetModelByUserCode(Customer.C_Customer_chiefResponsiblePerson.Value);
                    if (uModel != null)
                    {
                        chiefResponsiblePersons.Add(uModel);
                    }
                }

            }
            ViewBag.CiefResponsiblePersons = chiefResponsiblePersons;



            #region 是否显示"保存"按钮(客户负责人或者客户首席负责人或专业顾问或内置系统管理员有此按钮权限)
            bool isShowSaveBtn = false;
            if (Context.UIContext.Current.IsPreSetManager)
            {
                isShowSaveBtn = true;
            }
            else
            {
                if (Customer.C_Customer_responsiblePerson != null)
                {//客户负责人
                    if (Customer.C_Customer_responsiblePerson == Context.UIContext.Current.UserCode)
                    {
                        isShowSaveBtn = true;
                    }
                }
                if (Customer.C_Customer_chiefResponsiblePerson != null)
                {//客户首席负责人
                    if (Customer.C_Customer_chiefResponsiblePerson == Context.UIContext.Current.UserCode)
                    {
                        isShowSaveBtn = true;
                    }
                }
                if (!isShowSaveBtn)
                {//专业顾问                   
                    if (Customer.C_Customer_consultant != null && Customer.C_Customer_consultant == Context.UIContext.Current.UserCode)
                    {
                        isShowSaveBtn = true;
                    }
                }

            }
            ViewBag.IsShowSaveBtn = isShowSaveBtn;
            #endregion

            #region 客户首席负责人或内置系统管理员，拥有所有修改页面数据的权限；而客户负责人或专业顾问，只可以修改计划时间
            int editPagePropertyType = 0;//修改页面元素类型
            if (Context.UIContext.Current.IsPreSetManager)
            {
                editPagePropertyType = 1;//代表修改所有元素
            }
            else
            {
                if (Customer.C_Customer_responsiblePerson != null)
                {//客户负责人
                    if (Customer.C_Customer_responsiblePerson == Context.UIContext.Current.UserCode)
                    {
                        editPagePropertyType = 2;//只可修改计划时间
                    }
                }

                if (editPagePropertyType != 2)
                {//专业顾问

                    if (Customer.C_Customer_consultant != null && Customer.C_Customer_consultant == Context.UIContext.Current.UserCode)
                    {
                        editPagePropertyType = 2;//只可修改计划时间
                    }
                }

                if (Customer.C_Customer_chiefResponsiblePerson != null)
                {//客户首席负责人
                    if (Customer.C_Customer_chiefResponsiblePerson == Context.UIContext.Current.UserCode)
                    {
                        editPagePropertyType = 1;//代表修改所有元素
                    }
                }
            }
            ViewBag.EditPagePropertyType = editPagePropertyType;
            #endregion

            return View("ShowSetCustomerPlan", Customer);
        }

        /// <summary>
        /// 保存客户计划
        /// </summary>
        /// <param name="form"></param>
        /// <param name="customer">客户数据模型</param>
        /// <returns></returns>
        public ActionResult SetCustomerPlan(FormCollection form, CommonService.Model.C_Customer customer)
        {
            if (DateTime.Compare(customer.C_Customer_planStartTime.Value, customer.C_Customer_planEndTime.Value) < 0)
            {
                if (form["C_Customer_chiefResponsiblePerson"] != "请选择")
                {
                    customer.C_Customer_chiefResponsiblePerson = new Guid(form["C_Customer_chiefResponsiblePerson"]);
                }
                else
                {
                    customer.C_Customer_chiefResponsiblePerson = null;
                }
                if (form["C_Customer_responsiblePerson"] != "请选择")
                {
                    customer.C_Customer_responsiblePerson = new Guid(form["C_Customer_responsiblePerson"]);
                }
                else
                {
                    customer.C_Customer_responsiblePerson = null;
                }
                customer.C_Customer_planStartTime = Convert.ToDateTime(form["C_Customer_planStartTime"]);
                customer.C_Customer_planEndTime = Convert.ToDateTime(form["C_Customer_planEndTime"]);
                bool isUpdateSuccess = _customerWCF.SetCustomerPlan(customer);
                if (isUpdateSuccess)
                {
                    //保存成功提示固定写法
                    return Json(TipHelper.JsonData("设定计划信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
                }
                else
                {
                    //保存失败固定写法
                    return Json(TipHelper.JsonData("设定计划信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ParentPage, OperateTypeAfterTip.NoAction));
                }
            }
            else
            {
                return Json(TipHelper.JsonData("计划开始时间不能大于计划结束时间！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ParentPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 检查是否已设置了客户的计划时间
        /// </summary>
        /// <param name="customerCode">客户Guid</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CheckIsSetPlanTime(string customerCode)
        {
            CommonService.Model.C_Customer customer = _customerWCF.Get(new Guid(customerCode));
            ArrayList arrayPlanTime = new ArrayList();
            //是否已经设置了计划开始时间
            if (customer.C_Customer_planStartTime != null)
            {
                arrayPlanTime.Add("1");
            }
            else
            {
                arrayPlanTime.Add("0");
            }
            //是否已经设置了计划结束时间
            if (customer.C_Customer_planEndTime != null)
            {
                arrayPlanTime.Add("1");
            }
            else
            {
                arrayPlanTime.Add("0");
            }

            return Json(arrayPlanTime);
        }


        #endregion

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        /// <param name="customer">客户对象</param>
        private void InitializationPageParameter(CommonService.Model.C_Customer customer)
        {
            //客户类型参数
            CommonService.Model.C_Parameters CustomerType = new CommonService.Model.C_Parameters();
            if (customer.C_Customer_type != null)
            {
                CustomerType = _parameterWCF.GetModel(customer.C_Customer_type.Value);
            }
            ViewBag.CustomerType = CustomerType;

            //客户类别参数
            CommonService.Model.C_Parameters Category = new CommonService.Model.C_Parameters();
            if (customer.C_Customer_Category != null)
            {
                Category = _parameterWCF.GetModel(customer.C_Customer_Category.Value);
            }
            ViewBag.CustomerCategory = Category;

            //客户状态参数
            CommonService.Model.C_Parameters State = new CommonService.Model.C_Parameters();
            if (customer.C_Customer_State != null)
            {
                State = _parameterWCF.GetModel(customer.C_Customer_State.Value);
            }
            ViewBag.State = State;

            //行业参数
            CommonService.Model.C_Parameters Industry = new CommonService.Model.C_Parameters();
            if (customer.C_Customer_industryCode != null)
            {
                Industry = _parameterWCF.GetModel(customer.C_Customer_industryCode.Value);
            }
            ViewBag.Industry = Industry;

            //客户来源参数
            CommonService.Model.C_Parameters CustomerSource = new CommonService.Model.C_Parameters();
            if (customer.C_Customer_source != null)
            {
                CustomerSource = _parameterWCF.GetModel(customer.C_Customer_source.Value);
            }
            ViewBag.CustomerSource = CustomerSource;

            //客户级别参数
            CommonService.Model.C_Parameters CustomerLevel = new CommonService.Model.C_Parameters();
            if (customer.C_Customer_level != null)
            {
                CustomerLevel = _parameterWCF.GetModel(customer.C_Customer_level.Value);
            }
            ViewBag.CustomerLevel = CustomerLevel;

            //是否签约客户状态参数
            CommonService.Model.C_Parameters IsSignedState = new CommonService.Model.C_Parameters();
            if (customer.C_Customer_isSignedState != null)
            {
                IsSignedState = _parameterWCF.GetModel(customer.C_Customer_isSignedState.Value);
            }
            ViewBag.IsSignedState = IsSignedState;

            //签约客户状态参数
            CommonService.Model.C_Parameters SignedState = new CommonService.Model.C_Parameters();
            if (customer.C_Customer_signedState != null)
            {
                SignedState = _parameterWCF.GetModel(customer.C_Customer_signedState.Value);
            }
            ViewBag.SignedState = SignedState;

            //客户忠诚度参数
            CommonService.Model.C_Parameters CustomerLoyalty = new CommonService.Model.C_Parameters();
            if (customer.C_Customer_loyalty != null)
            {
                CustomerLoyalty = _parameterWCF.GetModel(customer.C_Customer_loyalty.Value);
            }
            ViewBag.CustomerLoyalty = CustomerLoyalty;

            //专业顾问
            CommonService.Model.SysManager.C_Userinfo Consultant = new CommonService.Model.SysManager.C_Userinfo();
            if (customer.C_Customer_consultant != null)
            {
                Consultant = _userinfoWCF.GetModelByUserCode(customer.C_Customer_consultant.Value);
            }
            ViewBag.Consultant = Consultant;
        }

    }
}