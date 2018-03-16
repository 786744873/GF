using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.CustomerForm.Controllers
{
    /// <summary>
    /// 客户表单属性值控制器
    /// </summary>
    public class CustomerFormPropertyValueController : BaseController
    {
        private readonly ICommonService.FlowManager.IP_Business_flow _businessFlowWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow_form _businessFlowFormWCF;
        private readonly ICommonService.CustomerForm.IF_FormCheck _formCheckWCF;
        private readonly ICommonService.BusinessChanceManager.IB_BusinessChance _businessChanceWCF;
        private readonly ICommonService.Customer.IV_User _vUserWCF;
        private readonly ICommonService.IC_Customer _customerWCF;

        public CustomerFormPropertyValueController()
        {
            _businessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            _businessFlowFormWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow_form>("Business_flow_formWCF");
            _formCheckWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormCheck>("FormCheckWCF");
            _businessChanceWCF = ServiceProxyFactory.Create<ICommonService.BusinessChanceManager.IB_BusinessChance>("BusinessChanceWCF");
            _vUserWCF = ServiceProxyFactory.Create<ICommonService.Customer.IV_User>("VUserWCF");
            _customerWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer>("CustomerWCF");
        }

        //
        // GET: /CustomerForm/CustomerFormPropertyValue/
        public override ActionResult Index()
        {            
            return View();
        }

        /// <summary>
        /// 业务流程关联自定义表单Tab布局Action
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="pkCode">关联Guid，如客户Guid</param>
        /// <param name="fkType">关联Guid类型,客户=901</param>
        /// <returns></returns>
        public ActionResult LayoutRootTabs(string businessFlowCode, string pkCode, string fkType)
        {
            #region 处理此触发点是否为通过重做表单调用

            /**
             * author:hety
             * date:2015-11-27
             * descption:这个逻辑主要是为了处理表单重做后，在刷新父页面后，当前被重做的表单切换到最新的表单(业务流程表单关联Guid)(相应关联业务逻辑也切换到最新的表单，比如财务报销单...)
             * 
             ***/

            bool isFromReDoneFormNav = false;//是否来自重做表单调用标识
            string reDoneBusinessFormCode = String.Empty;//重做业务流程表单Guid
            if (Request.QueryString["isFromReDoneFormNav"] != null)
            {//来自重做表单调用
                isFromReDoneFormNav = true;
                reDoneBusinessFormCode = Request.QueryString["reDoneBusinessFormCode"];
            }
            ViewBag.IsFromReDoneFormNav = isFromReDoneFormNav;//是否来自重做表单调用标识
            ViewBag.ReDoneBusinessFormCode = reDoneBusinessFormCode;//重做业务流程表单Guid
            #endregion

            ViewBag.BusinessFlowCode = businessFlowCode;//当前业务流程Guid
            ViewBag.PkCode = pkCode;//主业务Guid,客户Guid
            ViewBag.fkType = fkType;//业务流程类型,客户=901

            CommonService.Model.C_Customer customer = _customerWCF.Get(new Guid(pkCode));//客户数据模型
            CommonService.Model.FlowManager.P_Business_flow businessFlow = _businessFlowWCF.Get(new Guid(businessFlowCode));//业务流程数据模型
            List<CommonService.Model.FlowManager.P_Business_flow_form> BusinessFlowForms = _businessFlowFormWCF.GetBusinessFlowFormsWithFormType(new Guid(businessFlowCode));
        
            ViewBag.IsHasSubmitFormPower = this.IsHasSubmitFormPower(new Guid(businessFlowCode));//是否有提交表单的权限
            ViewBag.IsHasCheckFormPower = this.IsHasCheckFormPower(new Guid(businessFlowCode));//是否有审核表单的权限
            ViewBag.IsHasConfigureFormPower = this.IsHasConfigureFormPower(customer.C_Customer_responsiblePerson, businessFlow.P_Business_person);//是否有配置表单的权限
            ViewBag.BusinessFlow = businessFlow;//业务流程数据模型

            #region 表单提交审核记录
            List<CommonService.Model.CustomerForm.F_FormCheck> custlist = new List<CommonService.Model.CustomerForm.F_FormCheck>();
            //获取提交纪要及审核记录表
            custlist.AddRange(_formCheckWCF.GetFirstTimeFormCheckRecordForflowcode(Guid.Parse(businessFlowCode)));

            //格式化表单名称
            foreach (var item in custlist)
            {
                var fmodel = BusinessFlowForms.Where(p => p.P_Business_flow_form_code == item.F_FormCheck_business_flow_form_code).FirstOrDefault();
                if (fmodel != null)
                {
                    item.F_FormCheck_business_flow_form_name = fmodel.F_Form_chineseName;
                }
            }
            //提交信息
            ViewBag.F_FormCheckList = custlist;
            //审核信息
            ViewBag.F_FormCheckList_Audt = custlist.Where(p => p.F_FormCheck_checkDate != null).ToList();
            #endregion

            return View(BusinessFlowForms);
        }

        /// <summary>
        /// 检查当前用户是否有"进入下一流程"的权限
        /// </summary>
        /// <param name="pkCode">关联Guid，比如客户Guid</param>
        /// <returns></returns>
        private bool IsHasEnterNextBusinessFlowPower(Guid pkCode)
        {
            /**
             * author:hety 
             * date:2015-06-18
             * description:
             * (1)、目前只有一级负责人才有"进入下一流程"的权限，比如客户负责人
             * (2)、内置系统管理员用户为万能用户，不受任何权限限制
             **/
            bool isHasEnter = false;
            if (Context.UIContext.Current.IsPreSetManager)
            {
                isHasEnter = true;
            }
            else
            {
                CommonService.Model.C_Customer customer = _customerWCF.Get(pkCode);
                if (customer != null)
                {
                    if (customer.C_Customer_responsiblePerson == Context.UIContext.Current.UserCode)
                    {
                        isHasEnter = true;
                    }
                }
            }
            return isHasEnter;
        }

        /// <summary>
        /// 检查当前用户是否有"提交表单"的权限
        /// </summary>
        /// <param name="businessFlowCode"></param>
        /// <returns></returns>
        private bool IsHasSubmitFormPower(Guid businessFlowCode)
        {
            /**
             * author:hety 
             * date:2015-11-27
             * description:
             * (1)、目前只有表单的主办律师才有"提交"的权限
             * (2)、内置系统管理员用户为万能用户，不受任何权限限制
            **/
            bool isHasSubmitForm = false;

            if (Context.UIContext.Current.IsPreSetManager)
            {
                isHasSubmitForm = true;
            }
            else
            {
                List<CommonService.Model.Customer.V_User> V_User = _vUserWCF.GetSubmitOwnFormUsers(businessFlowCode);
                var powerUserList = from allList in V_User
                                    where allList.UserCode == Context.UIContext.Current.UserCode
                                    select allList;
                if (powerUserList.Count() != 0)
                {
                    isHasSubmitForm = true;//代表"允许当前登录用户提交"
                }
            }

            return isHasSubmitForm;
        }

        /// <summary>
        /// 检查当前用户是否有"审核表单"的权限
        /// </summary>
        /// <param name="businessFlowCode"></param>
        /// <returns></returns>
        private bool IsHasCheckFormPower(Guid businessFlowCode)
        {
            /**
             * author:hety 
             * date:2015-11-27
             * description:
             * (1)、只要当前登录用户在当前业务流程关联的表单中审核进度中(对应F_FormCheck表)，并且审核状态为"未审核"的话，就有"审核"的权限
             * (2)、内置系统管理员用户为万能用户，不受任何权限限制
             **/
            bool isHasCheckForm = false;

            if (Context.UIContext.Current.IsPreSetManager)
            {
                isHasCheckForm = true;
            }
            else
            {
                List<CommonService.Model.Customer.V_User> V_User = _vUserWCF.GetCheckOwnFormUsers(businessFlowCode);
                var powerUserList = from allList in V_User
                                    where allList.UserCode == Context.UIContext.Current.UserCode
                                    select allList;
                if (powerUserList.Count() != 0)
                {
                    isHasCheckForm = true;//代表"允许当前登录用户审核"
                }
            }

            return isHasCheckForm;
        }

        /// <summary>
        /// 检查当前用户是否有"配置表单"的权限
        /// </summary>
        /// <param name="customerResponsiblePerson">客户负责人</param>
        /// <param name="businessFlowResponsiblePerson">业务流程负责人</param>
        /// <returns></returns>
        public bool IsHasConfigureFormPower(Guid? customerResponsiblePerson, Guid? businessFlowResponsiblePerson)
        {
            /***
             * author:hety
             * date:2015-11-27
             * description:检查当前用户是否有"配置表单"的权限
             * (1)、内置系统管理员或者客户负责人或者业务流程负责人，拥有此权限
             ***/
            bool isConfigureForm = false;
            if (Context.UIContext.Current.IsPreSetManager)
            {
                isConfigureForm = true;
            }
            else
            {
                if (Context.UIContext.Current.UserCode == customerResponsiblePerson)
                {
                    isConfigureForm = true;
                }
                if (Context.UIContext.Current.UserCode == businessFlowResponsiblePerson)
                {
                    isConfigureForm = true;
                }
            }
            return isConfigureForm;
        }
	}
}