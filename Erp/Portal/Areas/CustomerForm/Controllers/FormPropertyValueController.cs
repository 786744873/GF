using CommonService.Common;
using Context;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.CustomerForm.Controllers
{
    /// <summary>
    /// 表单属性值控制器
    /// </summary>
    public class FormPropertyValueController : BaseController
    {
        private readonly ICommonService.CustomerForm.IF_FormProperty _formPropertyWCF;
        private readonly ICommonService.CustomerForm.IF_FormPropertyValue _formPropertyValueWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow_form _businessFlowFormWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow _businessFlowWCF;
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.Customer.IV_User _vUserWCF;
        private readonly ICommonService.CustomerForm.IF_FormCheck _formCheckWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.CustomerForm.IF_Form _formWCF;
        private readonly ICommonService.BusinessChanceManager.IB_BusinessChance _businessChanceWCF;
        private readonly ICommonService.BusinessChanceManager.IB_BusinessChance_check _businessChance_checkWCF;
        private readonly ICommonService.CaseManager.IB_Case_link _caselinkWCF;
        private readonly ICommonService.FlowManager.IP_Flow _flowWCF;
        private readonly ICommonService.SysManager.IC_Role_Role_Power _roleRolePowerWCF;
        public FormPropertyValueController()
        {
            #region 服务初始化
            _formPropertyWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormProperty>("FormPropertyWCF");
            _formPropertyValueWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormPropertyValue>("FormPropertyValueWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
            _businessFlowFormWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow_form>("Business_flow_formWCF");
            _businessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            _vUserWCF = ServiceProxyFactory.Create<ICommonService.Customer.IV_User>("VUserWCF");
            _formCheckWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormCheck>("FormCheckWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _formWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_Form>("FormWCF");
            _businessChanceWCF = ServiceProxyFactory.Create<ICommonService.BusinessChanceManager.IB_BusinessChance>("BusinessChanceWCF");
            _businessChance_checkWCF = ServiceProxyFactory.Create<ICommonService.BusinessChanceManager.IB_BusinessChance_check>("B_BusinessChance_checkWCF");
            _caselinkWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case_link>("Case_linkWCF");
            _flowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow>("FlowWCF");
            _roleRolePowerWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Role_Role_Power>("Role_Role_PowerWCF");
            #endregion
        }

        //
        // GET: /CustomerForm/FormPropertyValue/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 业务流程关联自定义表单Tab布局Action
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="pkCode">关联Guid，如案件Guid</param>
        /// <param name="fkType">关联Guid类型,案件=153;商机=154</param>
        /// <returns></returns>
        public ActionResult LayoutRootTabs(string businessFlowCode, string pkCode, string fkType)
        {
            #region 处理此触发点是否为通过重做表单调用

            /**
             * author:hety
             * date:2015-10-13
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
            ViewBag.IsFromReDoneFormNav = isFromReDoneFormNav;
            ViewBag.ReDoneBusinessFormCode = reDoneBusinessFormCode;
            #endregion

            this.InitializationRolePower();

            //区分稽查人：  运营总监、分公司总经理、首席、部长 以上身份有权限看到稽查按钮
            if (Context.UIContext.Current.PostGroupCode == PostGroup.GeneralManager || Context.UIContext.Current.PostGroupCode == PostGroup.ChiefExpert || Context.UIContext.Current.PostGroupCode == PostGroup.Minister || Context.UIContext.Current.PostGroupCode == PostGroup.BranchGeneralManager)
            {
                ViewBag.Fstate = 1;
            }
            else
            {
                ViewBag.Fstate = 0;
            }

            bool isShowEndCaseBtn = false; //是否显示"结案确认"按钮(只有案件才有此功能)
            bool isShowSubmitCheckBtn = false;//是否显示"提交审查"按钮(只有商机才拥有)
            bool isShowMinisterCheckBtn = false;//是否显示"部长审查"按钮(只有商机才拥有)
            bool isShowChiefCheckBtn = false;//是否显示"首席审查"按钮(只有商机才拥有)

            if (businessFlowCode != null && businessFlowCode != "")
            {
                List<CommonService.Model.FlowManager.P_Business_flow_form> BusinessFlowForms = _businessFlowFormWCF.GetBusinessFlowFormsWithFormType(new Guid(businessFlowCode));
                ViewBag.BusinessFlowCode = businessFlowCode;
                ViewBag.PkCode = pkCode;
                ViewBag.fkType = fkType;
                CommonService.Model.FlowManager.P_Business_flow businessFlowModel = _businessFlowWCF.Get(new Guid(businessFlowCode));
                if (Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.商机))
                {
                    #region 商机处理
                    CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(new Guid(pkCode));
                    List<CommonService.Model.FlowManager.P_Business_flow> businessFlowList = _businessFlowWCF.GetListByFkCode(businessChance.B_BusinessChance_code.Value);
                    foreach (CommonService.Model.FlowManager.P_Business_flow businessFlowItem in businessFlowList)
                    {
                        if (businessFlowItem.P_Business_flow_applicationStatus == Convert.ToInt32(BusinessFlowApplicationStatueType.已提交))
                        {
                            ViewBag.businessFlowName = businessFlowItem.P_Business_flow_name;
                            break;
                        }
                    }
                    CommonService.Model.FlowManager.P_Flow flow = _flowWCF.GetModel(businessFlowModel.P_Flow_code.Value);
                    if (flow.P_Flow_id == 1167)
                    {
                        ViewBag.IsPresentation = true;
                    }
                    else
                    {
                        ViewBag.IsPresentation = false;
                    }
                    if (businessFlowModel.P_Business_state == Convert.ToInt32(BusinessFlowStatus.正在进行) && businessChance.B_BusinessChance_person == Context.UIContext.Current.UserCode)
                    {
                        ViewBag.IsBusinessFlowStatus = true;
                    }
                    else
                    {
                        ViewBag.IsBusinessFlowStatus = false;
                    }
                    if (businessChance.B_BusinessChance_person == Context.UIContext.Current.UserCode)
                    {
                        ViewBag.IsBusinessChancePerson = true;
                    }
                    else
                    {
                        ViewBag.IsBusinessChancePerson = false;
                    }

                    #region 处理商机“交单”业务逻辑
                    /*
                     * author:hety
                     * date:2015-10-30
                     * description:
                     * (1)、当前业务流程关联流程中的"是否交单"值必须为"true"，并且当前登录用户必须为业务流程的"负责人"(内置系统管理员除外)并且商机进行状态为"正在进行"，并且
                     *      商机审查状态为"未审查"时，才可以显示"提交审查"按钮
                     * (2)、处理"部长审查"按钮权限
                     * (3)、处理"首席审查"按钮权限
                     * */

                    if (flow != null)
                    {
                        #region 处理业务(1)
                        if (flow.P_Flow_IsCrossForm && businessFlowModel.P_Business_state == Convert.ToInt32(BusinessFlowStatus.正在进行) &&
                            businessChance.B_BusinessChance_checkStatus == Convert.ToInt32(BusinessChanceCheckEnum.未审查))
                        {
                            if (UIContext.Current.IsPreSetManager)
                            {
                                isShowSubmitCheckBtn = true;
                            }
                            else
                            {
                                if (businessFlowModel.P_Business_person != null)
                                {
                                    if (businessFlowModel.P_Business_person == UIContext.Current.UserCode)
                                    {
                                        isShowSubmitCheckBtn = true;
                                    }
                                }
                            }
                        }
                        #endregion

                        #region 处理业务(2)
                        if (flow.P_Flow_IsCrossForm && businessFlowModel.P_Business_state == Convert.ToInt32(BusinessFlowStatus.正在进行) &&
                            businessChance.B_BusinessChance_checkStatus == Convert.ToInt32(BusinessChanceCheckEnum.审查中))
                        {
                            isShowMinisterCheckBtn = this.ExistsHasMinisterCheckPower(businessChance.B_BusinessChance_code.Value, businessChance.B_BusinessChance_person);
                        }
                        #endregion

                        #region 处理业务(3)
                        if (flow.P_Flow_IsCrossForm && businessFlowModel.P_Business_state == Convert.ToInt32(BusinessFlowStatus.正在进行) &&
                            businessChance.B_BusinessChance_checkStatus == Convert.ToInt32(BusinessChanceCheckEnum.审查中))
                        {
                            isShowChiefCheckBtn = this.ExistsHasChiefCheckPower(businessChance.B_BusinessChance_code.Value, businessChance.B_BusinessChance_firstClassResponsiblePerson);
                        }
                        #endregion
                    }

                    #endregion

                    #endregion
                }
                else
                {
                    #region 案件处理
                    CommonService.Model.CaseManager.B_Case caseModel = _caseWCF.GetModel(new Guid(pkCode));
                    if (caseModel.B_Case_person == Context.UIContext.Current.UserCode)
                    {
                        ViewBag.IsCasePerson = true;
                    }
                    else
                    {
                        ViewBag.IsCasePerson = false;
                    }
                    //当前案件负责人
                    if (caseModel != null)
                    {
                        ViewBag.casePer = caseModel.B_Case_person.ToString();
                        //专业顾问
                        CommonService.Model.CaseManager.B_Case_link bModel = _caselinkWCF.GetCaseLinksByCaseAndType(new Guid(caseModel.B_Case_code.ToString()), 11).FirstOrDefault();
                        if (bModel != null)
                        {
                            ViewBag.caseGw = bModel.C_FK_code.ToString();
                        }
                        else
                        {
                            ViewBag.caseGw = null;
                        }
                        //案件所属区域
                        CommonService.Model.CaseManager.B_Case_link aModel = _caselinkWCF.GetCaseLinksByCaseAndType(new Guid(caseModel.B_Case_code.ToString()), 6).FirstOrDefault();
                        if (aModel != null)
                        {
                            ViewBag.caseArea = aModel.C_FK_code.ToString();
                        }
                        else
                        {
                            ViewBag.caseArea = null;
                        }
                        string courtItems = "";
                        if (caseModel.B_Case_courtFirst != null && caseModel.B_Case_courtFirst.ToString() != "" && caseModel.B_Case_courtFirst!=Guid.Empty)
                        {
                            courtItems += caseModel.B_Case_courtFirst.ToString() + ",";
                        }
                        if (caseModel.B_Case_courtSecond != null && caseModel.B_Case_courtSecond.ToString() != "" && caseModel.B_Case_courtSecond != Guid.Empty)
                        {
                            courtItems += caseModel.B_Case_courtSecond.ToString() + ",";
                        }
                        if (caseModel.B_Case_courtExec != null && caseModel.B_Case_courtExec.ToString() != "" && caseModel.B_Case_courtExec != Guid.Empty)
                        {
                            courtItems += caseModel.B_Case_courtExec.ToString() + ",";
                        }
                        if (caseModel.B_Case_Trial != null && caseModel.B_Case_Trial.ToString() != "" && caseModel.B_Case_Trial != Guid.Empty)
                        {
                            courtItems += caseModel.B_Case_Trial.ToString() + ",";
                        }
                        if (!string.IsNullOrEmpty(courtItems))
                        {
                            courtItems = courtItems.Substring(0, courtItems.Length - 1); 
                        }
                        ViewBag.courtItems = courtItems;
                    }
                    else
                    {
                        ViewBag.casePer = null;
                        ViewBag.caseGw = null;
                    }

                    #region 处理案件“大结案”业务逻辑
                    /*
                     * author:hety
                     * date:2015-09-22
                     * description:
                     * (1)、当前业务流程关联流程中的"是否交单"值必须为"true"，并且当前登录用户必须为案件的"首席专家"时，才可以显示"结案确认"按钮(内置系统管理员拥有此按钮)
                     * */
                    CommonService.Model.FlowManager.P_Flow flow = _flowWCF.GetModel(businessFlowModel.P_Flow_code.Value);
                    if (UIContext.Current.IsPreSetManager)
                    {
                        if (flow != null)
                        {
                            if (flow.P_Flow_IsCrossForm)
                            {
                                isShowEndCaseBtn = true;
                            }
                        }
                    }
                    else
                    {
                        if (flow != null && caseModel != null)
                        {
                            if (flow.P_Flow_IsCrossForm && caseModel.B_Case_firstClassResponsiblePerson == UIContext.Current.UserCode)
                            {
                                isShowEndCaseBtn = true;
                            }
                        }
                    }
                    #endregion

                    #endregion
                }

                if (businessFlowModel.P_Business_person == Context.UIContext.Current.UserCode)
                {
                    ViewBag.IsBusinessPerson = true;
                }
                else
                {
                    ViewBag.IsBusinessPerson = false;
                }
                ViewBag.IsHasEnterNextBusinessFlowPower = this.IsHasEnterNextBusinessFlowPower(new Guid(pkCode), int.Parse(fkType));
                ViewBag.IsHasSubmitFormPower = this.IsHasSubmitFormPower(new Guid(businessFlowCode));
                ViewBag.IsHasCheckFormPower = this.IsHasCheckFormPower(new Guid(businessFlowCode));

                CommonService.Model.FlowManager.P_Business_flow businessFlow = _businessFlowWCF.Get(new Guid(businessFlowCode));
                ViewBag.BusinessFlow = businessFlow;
                //当前流程负责人
                if (businessFlow != null)
                    ViewBag.flowPer = businessFlow.P_Business_person.ToString();
                else
                    ViewBag.flowPer = null;
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
                //是否显示"结案确认"按钮(只有案件才有此功能)
                ViewBag.IsShowEndCaseBtn = isShowEndCaseBtn;
                //是否显示"提交审查"按钮(只有商机才有此功能)
                ViewBag.IsShowSubmitCheckBtn = isShowSubmitCheckBtn;
                //是否显示"部长审查"按钮(只有商机才有此功能)
                ViewBag.IsShowMinisterCheckBtn = isShowMinisterCheckBtn;
                //是否显示"首席审查"按钮(只有商机才有此功能)
                ViewBag.IsShowChiefCheckBtn = isShowChiefCheckBtn;

                return View(BusinessFlowForms);
            }
            else
            {
                List<CommonService.Model.FlowManager.P_Business_flow_form> BusinessFlowForms = new List<CommonService.Model.FlowManager.P_Business_flow_form>();
                return View(BusinessFlowForms);
            }
        }

        /// <summary>
        /// 自定义表单tab属性布局Action
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="formPropertyCode">表单属性Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public ActionResult LayoutChildrenTabs(string formCode, string businessFlowFormCode, string formPropertyCode, string businessFlowCode)
        {
            List<CommonService.Model.CustomerForm.F_FormProperty> formPropertys = _formPropertyWCF.GetFormPropertysByFormCodeAndParentPropertyCode(new Guid(formCode), new Guid(formPropertyCode));
            ViewBag.BusinessFlowFormCode = businessFlowFormCode;
            ViewBag.BusinessFlowCode = businessFlowCode;
            return View(formPropertys);
        }

        /// <summary>
        /// 生成主子结构界面的表单
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="fkType">流程类型(案件或者商机)</param>
        /// <param name="pkCode">案件Guid或者商机Guid</param>
        /// <returns></returns>
        public ActionResult LayoutHeadAndMulityItems(string formCode, string businessFlowFormCode, string businessFlowCode, string fkType, string pkCode)
        {
            CommonService.Model.CustomerForm.F_Form formvalue = _formWCF.Get(new Guid(formCode));
            ViewBag.formCon = formvalue;
            ViewBag.BusinessFlowCode = businessFlowCode;
            ViewBag.FkType = fkType;
            ViewBag.PkCode = pkCode;
            ViewBag.FormCode = formCode;
            ViewBag.BusinessFlowFormCode = businessFlowFormCode;
            int formStatus = Convert.ToInt32(FormStatusEnum.已提交);
            //获取业务流程关联表单
            CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm = _businessFlowFormWCF.Get(new Guid(businessFlowFormCode));
            if (businessFlowForm != null)
            {
                formStatus = businessFlowForm.P_Business_flow_form_status.Value;
            }
            ViewBag.FormStatus = formStatus;
            ViewBag.IsHasSaveFormPower = this.ExistIsHasSaveFormPower(formStatus, new Guid(businessFlowFormCode));

            //获取表单头编辑属性及其属性值
            List<CommonService.Model.CustomerForm.F_FormProperty> editFormPropertys = _formPropertyWCF.GetOAHeadEditFormPropertyValueList(new Guid(formCode), new Guid(businessFlowFormCode));
            ViewBag.EditFormPropertys = editFormPropertys;
            //获取表单明细属性
            List<CommonService.Model.CustomerForm.F_FormProperty> itemFormPropertys = _formPropertyWCF.GetList(new Guid(formCode));
            //获取表单明细属性值
            DataSet itemFormPropertyValues = _formPropertyValueWCF.DynamicLoadCustmerFormListValues(new Guid(formCode), new Guid(businessFlowFormCode));
            ViewBag.DynamicItemFormPropertyValues = itemFormPropertyValues;

            #region 处理关联重做表单业务逻辑
            bool isSwitchFormHistoryRecordUrl = false;
            if (Request.QueryString["isSwitchFormHistoryRecordUrl"] != null)
            {//代表此触发为从表单重做历史记录中切换过来的
                isSwitchFormHistoryRecordUrl = true;
            }
            ViewBag.IsSwitchFormHistoryRecordUrl = isSwitchFormHistoryRecordUrl;
            #endregion

            #region 这里处理个性化的表单，加载不同的试图(比如保全表单)
            if (formCode.ToUpper() == "E2BB5A8D-A151-456B-86DD-006770B765C4")
            {//个性化保全表单
                return View("~/Areas/IndividuationForm/Views/SecurityForm/CreateOrEdit.cshtml", itemFormPropertys);//加载另外一个Area下的某个控制器下的某个试图(固定写法)
            }
            else if (formCode.ToUpper() == "1D39BB10-0459-494F-BE47-C59896156562")
            {//个性化附件表单(只是用来显示老数据附件,新系统中无此功能,hety,2015-09-06)
                return View("~/Areas/IndividuationForm/Views/AttachmentForm/ViewDetails.cshtml", itemFormPropertys);//加载另外一个Area下的某个控制器下的某个试图(固定写法)
            }
            else if (formCode.ToUpper() == "EBD190B4-FD91-4B11-9146-7EB1C11E0D17")
            {//个性化收款监督表单
                return View("~/Areas/IndividuationForm/Views/CollectSupervisionForm/CreateOrEdit.cshtml", itemFormPropertys);//加载另外一个Area下的某个控制器下的某个试图(固定写法)
            }
            else if (formCode.ToUpper() == "D20A4FF3-6063-456D-8656-28382923029A")
            {//个性化诉讼方案表单
                //获取客户信息
                return View("~/Areas/IndividuationForm/Views/LegalPlanForm/CreateOrEdit.cshtml", itemFormPropertys);//加载另外一个Area下的某个控制器下的某个试图(固定写法)
            }

            #endregion

            return View(itemFormPropertys);
        }

        /// <summary>
        /// 生成只有一个普通编辑界面的表单
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="fkType">流程类型(案件或者商机)</param>
        /// <param name="pkCode">案件Guid或者商机Guid</param>
        /// <returns></returns>
        public ActionResult GenerateSingleEidt(string formCode, string businessFlowFormCode, string businessFlowCode, string fkType, string pkCode)
        {
            ViewBag.fkType = fkType;
            ViewBag.PkCode = pkCode;
            ViewBag.FormCode = formCode;
            ViewBag.BusinessFlowCode = businessFlowCode;
            ViewBag.BusinessFlowFormCode = businessFlowFormCode;

            int formStatus = Convert.ToInt32(FormStatusEnum.已提交);

            //获取表单属性及其属性值
            List<CommonService.Model.CustomerForm.F_FormProperty> formPropertys = _formPropertyWCF.GetEditFormPropertyValueList(new Guid(formCode), new Guid(businessFlowFormCode));
            //获取业务流程关联表单
            CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm = _businessFlowFormWCF.Get(new Guid(businessFlowFormCode));
            //获取表单
            CommonService.Model.CustomerForm.F_Form formvalue = _formWCF.Get(new Guid(formCode));
            ViewBag.formCon = formvalue;
            if (businessFlowForm != null)
            {
                formStatus = businessFlowForm.P_Business_flow_form_status.Value;
            }
            ViewBag.FormStatus = formStatus;
            ViewBag.IsHasSaveFormPower = this.ExistIsHasSaveFormPower(formStatus, new Guid(businessFlowFormCode));

            #region 处理关联重做表单业务逻辑
            bool isSwitchFormHistoryRecordUrl = false;
            if (Request.QueryString["isSwitchFormHistoryRecordUrl"] != null)
            {//代表此触发为从表单重做历史记录中切换过来的
                isSwitchFormHistoryRecordUrl = true;
            }
            ViewBag.IsSwitchFormHistoryRecordUrl = isSwitchFormHistoryRecordUrl;
            #endregion

            #region 这里处理个性化的表单，加载不同的试图(比如预期收益计算表单)
            if (formCode.ToUpper() == "128EBF60-F58E-4AE2-B3B7-826DD62A0960")
            {//个性化预期收益计算表单
                CommonService.Model.FlowManager.P_Business_flow businessFlow = _businessFlowWCF.Get(new Guid(businessFlowCode));
                ViewBag.IsHasZyGwPower = this.ExistsHasZyGwPower(businessFlow == null ? Guid.Empty : businessFlow.P_Fk_code.Value);
                ViewBag.IsHasZhzxPower = this.ExistsHasZhzxPower(businessFlow == null ? Guid.Empty : businessFlow.P_Fk_code.Value);
                ViewBag.isHasSxzjPower = this.ExistsHasSxzjPower(businessFlow == null ? Guid.Empty : businessFlow.P_Fk_code.Value);
                ViewBag.isHasCwPower = this.ExistsHasFinancePower(businessFlow == null ? Guid.Empty : businessFlow.P_Fk_code.Value);

                if (Request.QueryString["isView"] != null)
                {//这种情况，代表只可以查看
                    return View("~/Areas/IndividuationForm/Views/ExpectProfitForm/Details.cshtml", formPropertys);
                }
                else
                {
                    return View("~/Areas/IndividuationForm/Views/ExpectProfitForm/CreateOrEdit.cshtml", formPropertys);//加载另外一个Area下的某个控制器下的某个试图(固定写法)
                }
            }
            #endregion

            return View(formPropertys);
        }

        /// <summary>
        /// 根据表单code，和流程code获取该表单的数据
        /// </summary>
        /// <param name="formCode"></param>
        /// <param name="businessFlowFormCode"></param>
        /// <returns></returns>
        public JsonResult GetSingleForm(string formCode, string businessFlowFormCode)
        {
            //获取表单属性及其属性值
            List<CommonService.Model.CustomerForm.F_FormProperty> formPropertys = _formPropertyWCF.GetEditFormPropertyValueList(new Guid(formCode), new Guid(businessFlowFormCode));

            ArrayList ars = new ArrayList();
            if (formPropertys != null && formPropertys.Count > 0)
            {
                //计划开始时间
                var jhmodel_1 = formPropertys.Where(p => p.F_FormProperty_showName == "计划开始时间").FirstOrDefault();
                if (jhmodel_1 != null)
                {
                    if (!String.IsNullOrEmpty(jhmodel_1.V_FormPropertyValue_Value))
                    {
                        ars.Add(DateTime.Parse(jhmodel_1.V_FormPropertyValue_Value).ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    else
                    {
                        ars.Add("");

                    }
                }


                //计划结束时间
                var jhmodel_2 = formPropertys.Where(p => p.F_FormProperty_showName == "计划结束时间").FirstOrDefault();
                if (jhmodel_2 != null)
                {
                    if (!String.IsNullOrEmpty(jhmodel_2.V_FormPropertyValue_Value))
                    {
                        ars.Add(DateTime.Parse(jhmodel_2.V_FormPropertyValue_Value).ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    else
                    {
                        ars.Add("");

                    }
                }




                //实际开始时间
                var jhmodel_3 = formPropertys.Where(p => p.F_FormProperty_showName == "实际开始时间").FirstOrDefault();
                if (jhmodel_3 != null)
                {
                    if (!String.IsNullOrEmpty(jhmodel_3.V_FormPropertyValue_Value))
                    {
                        ars.Add(DateTime.Parse(jhmodel_3.V_FormPropertyValue_Value).ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    else
                    {
                        ars.Add("");

                    }
                }





                //实际结束时间
                var jhmodel_4 = formPropertys.Where(p => p.F_FormProperty_showName == "实际结束时间").FirstOrDefault();
                if (jhmodel_4 != null)
                    if (!String.IsNullOrEmpty(jhmodel_4.V_FormPropertyValue_Value))
                    {
                        ars.Add(DateTime.Parse(jhmodel_4.V_FormPropertyValue_Value).ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    else
                    {
                        ars.Add("");

                    }
            }
            else
            {
                ars.Add("");
                ars.Add("");
                ars.Add("");
                ars.Add("");
            }




            //获取业务流程关联表单
            CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm = _businessFlowFormWCF.Get(new Guid(businessFlowFormCode));
            if (businessFlowForm != null && businessFlowForm.P_Business_flow_form_person != null)
            {
                //获取到人员名称
                var Umodel = _userinfoWCF.GetModelByUserCode(businessFlowForm.P_Business_flow_form_person.Value);
                if (Umodel != null)
                    ars.Add(Umodel.C_Userinfo_name);
            }


            else
            {
                ars.Add("");

            }


            return Json(ars);
        }

        /// <summary>
        /// 生成只有一个tab编辑界面的表单
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="formPropertyCode">表单属性Guid</param>
        /// <returns></returns>
        public ActionResult GenerateTabSingleEidt(string formCode, string businessFlowFormCode, string formPropertyCode)
        {
            int formStatus = Convert.ToInt32(FormStatusEnum.已提交);
            //获取表单属性及其属性值
            List<CommonService.Model.CustomerForm.F_FormProperty> formPropertys = _formPropertyWCF.GetTabEditFormPropertyValueList(new Guid(formCode), new Guid(businessFlowFormCode), new Guid(formPropertyCode));
            //获取业务流程关联表单
            CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm = _businessFlowFormWCF.Get(new Guid(businessFlowFormCode));
            if (businessFlowForm != null)
            {
                formStatus = businessFlowForm.P_Business_flow_form_status.Value;
            }
            ViewBag.FormStatus = formStatus;
            ViewBag.IsHasSaveFormPower = this.ExistIsHasSaveFormPower(formStatus, new Guid(businessFlowFormCode));
            return View("GenerateSingleEidt", formPropertys);
        }

        /// <summary>
        /// 动态生成下拉框
        /// </summary>
        /// <param name="formPropertyValue">表单属性值实体</param>
        /// <returns></returns>
        public PartialViewResult GenerateDropDownList(CommonService.Model.CustomerForm.F_FormProperty formPropertyValue)
        {
            int parentId = -1;
            if (!String.IsNullOrEmpty(formPropertyValue.F_FormProperty_dataSource_conditionValue))
            {
                parentId = Convert.ToInt32(formPropertyValue.F_FormProperty_dataSource_conditionValue);
            }
            List<CommonService.Model.C_Parameters> childrenParameters = this.InitializationParameter(parentId);
            ViewBag.FormPropertyValue = formPropertyValue;
            return PartialView("DropDownListPartial", childrenParameters);
        }

        /// <summary>
        /// 动态生成(Table Edit List 中)下拉框(html串)
        /// </summary>
        /// <param name="formPropertyValue">表单属性值实体</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>
        public string GenerateTableEditListDropDownHtmls(CommonService.Model.CustomerForm.F_FormProperty formPropertyValue, string businessFlowFormCode)
        {
            int parentId = -1;
            string dropItems = String.Empty;

            if (formPropertyValue.F_FormProperty_dataSource_type == Convert.ToInt32(CustomerFormDataSourceType.参数表))
            {
                #region
                if (!String.IsNullOrEmpty(formPropertyValue.F_FormProperty_dataSource_conditionValue))
                {
                    parentId = Convert.ToInt32(formPropertyValue.F_FormProperty_dataSource_conditionValue);
                }
                List<CommonService.Model.C_Parameters> childrenParameters = this.InitializationParameter(parentId);
                foreach (CommonService.Model.C_Parameters p in childrenParameters)
                {
                    if (String.IsNullOrEmpty(formPropertyValue.V_FormPropertyValue_Value))
                    {
                        dropItems += "<option value=" + p.C_Parameters_id + ">" + p.C_Parameters_name + "</option>";
                    }
                    else
                    {
                        if (p.C_Parameters_id.ToString().Equals(formPropertyValue.V_FormPropertyValue_Value))
                        {
                            dropItems += "<option selected=selected value=" + p.C_Parameters_id + ">" + p.C_Parameters_name + "</option>";
                        }
                        else
                        {
                            dropItems += "<option value=" + p.C_Parameters_id + ">" + p.C_Parameters_name + "</option>";
                        }
                    }
                }
                #endregion
            }
            else if (formPropertyValue.F_FormProperty_dataSource_type == Convert.ToInt32(CustomerFormDataSourceType.自定义表单))
            {
                #region
                List<CommonService.Model.CustomerForm.F_FormPropertyValue> dataSourceFormPropertyValues = _formPropertyValueWCF.GetCustFormPropertyValues(formPropertyValue.F_FormProperty_form.Value,
                    formPropertyValue.F_FormProperty_code.Value, new Guid(businessFlowFormCode));
                foreach (CommonService.Model.CustomerForm.F_FormPropertyValue dataSourcePropertyValue in dataSourceFormPropertyValues)
                {
                    if (String.IsNullOrEmpty(formPropertyValue.V_FormPropertyValue_Value))
                    {
                        dropItems += "<option value=" + dataSourcePropertyValue.F_FormPropertyValue_code.ToString() + ">" + dataSourcePropertyValue.F_FormPropertyValue_value + "</option>";
                    }
                    else
                    {
                        if (dataSourcePropertyValue.F_FormPropertyValue_code.ToString().Equals(formPropertyValue.V_FormPropertyValue_Value))
                        {
                            dropItems += "<option selected=selected value=" + dataSourcePropertyValue.F_FormPropertyValue_code.ToString() + ">" + dataSourcePropertyValue.F_FormPropertyValue_value + "</option>";
                        }
                        else
                        {
                            dropItems += "<option value=" + dataSourcePropertyValue.F_FormPropertyValue_code.ToString() + ">" + dataSourcePropertyValue.F_FormPropertyValue_value + "</option>";
                        }
                    }
                }
                #endregion
            }


            return dropItems;
        }

        /// <summary>
        /// 动态生成(Table Edit List 中)下拉框(json串)
        /// </summary>
        /// <param name="formPropertyValue">表单属性值实体</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>
        public string GenerateTableEditListDropDownJsons(CommonService.Model.CustomerForm.F_FormProperty formPropertyValue, string businessFlowFormCode)
        {
            int parentId = -1;
            string dropItems = String.Empty;
            dropItems = "[";

            if (formPropertyValue.F_FormProperty_dataSource_type == Convert.ToInt32(CustomerFormDataSourceType.参数表))
            {
                #region
                if (!String.IsNullOrEmpty(formPropertyValue.F_FormProperty_dataSource_conditionValue))
                {
                    parentId = Convert.ToInt32(formPropertyValue.F_FormProperty_dataSource_conditionValue);
                }
                List<CommonService.Model.C_Parameters> childrenParameters = this.InitializationParameter(parentId);
                foreach (CommonService.Model.C_Parameters p in childrenParameters)
                {
                    if (String.IsNullOrEmpty(formPropertyValue.V_FormPropertyValue_Value))
                    {
                        //dropItems += "<option value=" + p.C_Parameters_id + ">" + p.C_Parameters_name + "</option>";
                        dropItems += "{\"key\":\"" + p.C_Parameters_id + "\",\"value\":\"" + p.C_Parameters_name + "\"},";
                    }
                }
                #endregion
            }
            else if (formPropertyValue.F_FormProperty_dataSource_type == Convert.ToInt32(CustomerFormDataSourceType.自定义表单))
            {
                #region
                List<CommonService.Model.CustomerForm.F_FormPropertyValue> dataSourceFormPropertyValues = _formPropertyValueWCF.GetCustFormPropertyValues(formPropertyValue.F_FormProperty_form.Value,
                    formPropertyValue.F_FormProperty_code.Value, new Guid(businessFlowFormCode));
                foreach (CommonService.Model.CustomerForm.F_FormPropertyValue dataSourcePropertyValue in dataSourceFormPropertyValues)
                {
                    if (String.IsNullOrEmpty(formPropertyValue.V_FormPropertyValue_Value))
                    {
                        //dropItems += "<option value=" + dataSourcePropertyValue.F_FormPropertyValue_code.ToString() + ">" + dataSourcePropertyValue.F_FormPropertyValue_value + "</option>";
                        dropItems += "{\"key\":\"" + dataSourcePropertyValue.F_FormPropertyValue_code.ToString() + "\",\"value\":\"" + dataSourcePropertyValue.F_FormPropertyValue_value + "\"},";
                    }
                }
                #endregion
            }

            if (dropItems != "[")
            {
                dropItems = dropItems.Substring(0, dropItems.Length - 1);
            }

            dropItems += "]";

            return dropItems;
        }

        /// <summary>
        /// 动态生成(Table Edit List 中)单选框(json串)
        /// </summary>
        /// <param name="formPropertyValue">表单属性值实体</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>
        public string GenerateTableEditListRadioJsons(CommonService.Model.CustomerForm.F_FormProperty formPropertyValue, string businessFlowFormCode)
        {
            int parentId = -1;
            string radioItems = "[";

            if (formPropertyValue.F_FormProperty_dataSource_type == Convert.ToInt32(CustomerFormDataSourceType.参数表))
            {
                #region
                if (!String.IsNullOrEmpty(formPropertyValue.F_FormProperty_dataSource_conditionValue))
                {
                    parentId = Convert.ToInt32(formPropertyValue.F_FormProperty_dataSource_conditionValue);
                }
                List<CommonService.Model.C_Parameters> childrenParameters = this.InitializationParameter(parentId);
                foreach (CommonService.Model.C_Parameters p in childrenParameters)
                {
                    if (String.IsNullOrEmpty(formPropertyValue.V_FormPropertyValue_Value))
                    {
                        radioItems += "{\"key\":\"" + p.C_Parameters_id + "\",\"value\":\"" + p.C_Parameters_name + "\",\"ischecked\":\"0\"},";

                    }
                    else
                    {
                        if (p.C_Parameters_id.ToString().Equals(formPropertyValue.V_FormPropertyValue_Value))
                        {
                            radioItems += "{\"key\":\"" + p.C_Parameters_id + "\",\"value\":\"" + p.C_Parameters_name + "\",\"ischecked\":\"1\"},";
                        }
                        else
                        {
                            radioItems += "{\"key\":\"" + p.C_Parameters_id + "\",\"value\":\"" + p.C_Parameters_name + "\",\"ischecked\":\"0\"},";
                        }
                    }
                }
                #endregion
            }
            else if (formPropertyValue.F_FormProperty_dataSource_type == Convert.ToInt32(CustomerFormDataSourceType.自定义表单))
            {

            }
            if (radioItems != "[")
            {
                radioItems = radioItems.Substring(0, radioItems.Length - 1);
            }
            radioItems += "]";

            return radioItems;
        }


        /// <summary>
        /// 动态生成单选框
        /// </summary>
        /// <param name="formPropertyValue">表单属性值实体</param>
        /// <returns></returns>
        public PartialViewResult GenerateRadio(CommonService.Model.CustomerForm.F_FormProperty formPropertyValue)
        {
            int parentId = -1;
            if (!String.IsNullOrEmpty(formPropertyValue.F_FormProperty_dataSource_conditionValue))
            {
                parentId = Convert.ToInt32(formPropertyValue.F_FormProperty_dataSource_conditionValue);
            }
            List<CommonService.Model.C_Parameters> childrenParameters = this.InitializationParameter(parentId);
            ViewBag.FormPropertyValue = formPropertyValue;
            return PartialView("RadioPartial", childrenParameters);
        }

        /// <summary>
        /// 动态生成复选框
        /// </summary>
        /// <param name="formPropertyValue">表单属性值实体</param>
        /// <returns></returns>
        public PartialViewResult GenerateCheckbox(CommonService.Model.CustomerForm.F_FormProperty formPropertyValue)
        {
            return PartialView("CheckboxPartial");
        }

        /// <summary>
        /// 动态生成单选弹出框(只应用于普通编辑页面中)
        /// </summary>
        /// <param name="formPropertyValue">表单属性值实体</param>
        /// <param name="htmlAttributes">验证信息</param>
        /// <returns></returns>
        public PartialViewResult GenerateSingleCallbackRefList(CommonService.Model.CustomerForm.F_FormProperty formPropertyValue, string htmlAttributes)
        {
            ViewBag.FormPropertyValue = formPropertyValue;
            ViewBag.HtmlAttributes = htmlAttributes;
            return PartialView("SingleCallbackRefList");
        }

        /// <summary>
        /// 动态生成单选弹出框(只应用于列表编辑页面中)
        /// </summary>
        /// <param name="formPropertyValue">表单属性值实体</param>
        /// <param name="htmlAttributes">验证信息</param>
        /// <returns></returns>
        public PartialViewResult GenerateSingleCallbackRefList_List(CommonService.Model.CustomerForm.F_FormProperty formPropertyValue, string htmlAttributes)
        {
            ViewBag.FormPropertyValue = formPropertyValue;
            ViewBag.HtmlAttributes = htmlAttributes;
            return PartialView("SingleCallbackRefList_List");
        }

        /// <summary>
        /// 动态生成多选弹出框
        /// </summary>
        /// <param name="formPropertyValue">表单属性值实体</param>
        /// <param name="htmlAttributes">验证信息</param>
        /// <returns></returns>
        public PartialViewResult GenerateMulityCallbackRefList(CommonService.Model.CustomerForm.F_FormProperty formPropertyValue, string htmlAttributes)
        {
            ViewBag.FormPropertyValue = formPropertyValue;
            ViewBag.HtmlAttributes = htmlAttributes;
            return PartialView("MulityCallbackRefList");
        }

        /// <summary>
        /// 动态生成单选弹出树
        /// </summary>
        /// <param name="formPropertyValue">表单属性值实体</param>
        /// <param name="htmlAttributes">验证信息</param>
        /// <returns></returns>
        public PartialViewResult GenerateSingleCallbackRefTree(CommonService.Model.CustomerForm.F_FormProperty formPropertyValue, string htmlAttributes)
        {
            ViewBag.FormPropertyValue = formPropertyValue;
            ViewBag.HtmlAttributes = htmlAttributes;
            return PartialView("SingleCallbackRefTree");
        }

        /// <summary>
        /// 动态生成多选弹出文本框
        /// </summary>
        /// <param name="formPropertyValue">表单属性值实体</param>
        /// <param name="htmlAttributes">验证信息</param>
        /// <returns></returns>
        public PartialViewResult GenerateMulityCallbackRefEdit(CommonService.Model.CustomerForm.F_FormProperty formPropertyValue, string htmlAttributes)
        {
            ViewBag.FormPropertyValue = formPropertyValue;
            ViewBag.HtmlAttributes = htmlAttributes;
            return PartialView("MulityCallbackRefEdit");
        }

        /// <summary>
        /// 动态生成(Ajax下拉框(html串)
        /// </summary>       
        /// <param name="conditionValue">业务流程表单关联Guid</param>
        /// <param name="dataSourceType">关联自定义表单数据源类型</param>
        /// <returns></returns>
        [HttpPost]
        public ContentResult GenerateAjaxDropDownHtmls(string conditionValue, int? dataSourceType = 118)
        {
            int parentId = -1;
            string dropItems = String.Empty;

            if (Convert.ToInt32(dataSourceType) == Convert.ToInt32(CustomerFormDataSourceType.参数表))
            {
                #region
                if (!String.IsNullOrEmpty(conditionValue))
                {
                    parentId = Convert.ToInt32(conditionValue);
                }
                List<CommonService.Model.C_Parameters> childrenParameters = this.InitializationParameter(parentId);
                foreach (CommonService.Model.C_Parameters p in childrenParameters)
                {
                    dropItems += "<option value=" + p.C_Parameters_id + ">" + p.C_Parameters_name + "</option>";
                }
                #endregion
            }
            else if (Convert.ToInt32(dataSourceType) == Convert.ToInt32(CustomerFormDataSourceType.自定义表单))
            {

            }

            return Content(dropItems);
        }


        /// <summary>
        /// 初始化自定义表单属性值
        /// </summary>
        /// <param name="formCode">表单Guid</param>
        /// <param name="flowCode"> 流程Guid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InitializationFormPropertyValue(string formCode, string flowCode)
        {
            bool isSuccess = _formPropertyValueWCF.InitializationFormPropertyValue(new Guid(formCode), new Guid(flowCode), Context.UIContext.Current.UserCode.Value);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("分配表单成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("分配表单失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 初始化参数
        /// </summary>
        private List<CommonService.Model.C_Parameters> InitializationParameter(int parentId)
        {
            //参数集合
            List<CommonService.Model.C_Parameters> childrenParameters = _parameterWCF.GetChildrenByParentId(parentId);
            if (childrenParameters.Count == 0)
            {
                childrenParameters = new List<CommonService.Model.C_Parameters>();
            }
            return childrenParameters;
        }

        /// <summary>
        /// 提交编辑表单信息
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveEditInfo(FormCollection form)
        {
            bool isSaveSuccess = false;
            Guid businessFlowCode = new Guid(form["businessFlowCode"]);
            string fkType = form["fkType"];
            string formKey = String.Empty;
            //处理Form表单属性
            List<CommonService.Model.Customer.V_FormPropertyValue> V_FormPropertyValues = new List<CommonService.Model.Customer.V_FormPropertyValue>();
            for (int i = 0; i < form.AllKeys.Length; i++)
            {
                formKey = form.AllKeys[i];
                if (formKey.Contains("formproperty_"))
                {//表明为正规自定义表单属性
                    string[] formKeyGroup = formKey.Split('_');
                    if (formKeyGroup.Length == 2)
                    {//代表 普通表单元素(文本框，日期框，单选按钮，下拉框)
                        CommonService.Model.Customer.V_FormPropertyValue propertyValue = new CommonService.Model.Customer.V_FormPropertyValue();
                        //这里表单属性值Guid之所以这么赋值，是因为 UI 中 Form 的"表单元素 name 值"已关联到了表单属性值Guid
                        propertyValue.FormPropertyValue_Code = new Guid(formKeyGroup[1]);
                        propertyValue.FormPropertyValue_Value = form[formKey];
                        V_FormPropertyValues.Add(propertyValue);
                    }
                    else if (formKeyGroup.Length == 3)
                    {//代表 单选弹出框
                        //这种情况是虚拟属性，只是用来在UI中显示名称的，不需要保存到数据中
                        if (formKey.Contains(".Name_formproperty_")) { continue; }
                        if (formKey.Contains(".Code_formproperty_"))
                        {
                            CommonService.Model.Customer.V_FormPropertyValue propertyValue = new CommonService.Model.Customer.V_FormPropertyValue();
                            //这里表单属性值Guid之所以这么赋值，是因为 UI 中 Form 的"表单元素 name 值"已关联到了表单属性值Guid
                            propertyValue.FormPropertyValue_Code = new Guid(formKeyGroup[2]);
                            propertyValue.FormPropertyValue_Value = form[formKey];
                            V_FormPropertyValues.Add(propertyValue);
                        }
                    }
                    else if (formKeyGroup.Length == 4)
                    {//此种属性附加了UI控件类型值
                        if (formKeyGroup[3] == Convert.ToInt32(UiControlType.多选弹出文本框).ToString())
                        {
                            //这种情况是虚拟属性，只是用来在UI中显示名称的，不需要保存到数据中
                            if (formKey.Contains(".Name_formproperty_")) { continue; }
                            if (formKey.Contains(".Code_formproperty_"))
                            {
                                CommonService.Model.Customer.V_FormPropertyValue propertyValue = new CommonService.Model.Customer.V_FormPropertyValue();
                                //这里表单属性值Guid之所以这么赋值，是因为 UI 中 Form 的"表单元素 name 值"已关联到了表单属性值Guid
                                propertyValue.FormPropertyValue_Code = new Guid(formKeyGroup[2]);
                                propertyValue.FormPropertyValue_Value = form[formKey] + "&" + form[formKey.Replace(".Code_", ".Name_")];//这种情况存入的值，需要累加特殊性，否则会和弹出编辑框UI对应不上
                                V_FormPropertyValues.Add(propertyValue);
                            }
                        }
                    }
                }
            }

            isSaveSuccess = _formPropertyValueWCF.UpdateFormPropertyValueByPropertyCode(V_FormPropertyValues);

            if (isSaveSuccess)
            {
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTip));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存信息成功！", "/customerform/formcheck/layoutsubmit?businessFlowCode=" + businessFlowCode + "&fkType=" + fkType, IsAlertTip.No, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageOpenAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存信息成功！", ""));//默认仅仅保存
                }
                //保存成功提示固定写法
                //return Json(TipHelper.JsonData("保存信息成功！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTip));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 提交主子结构表单
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveHeadItems(FormCollection form)
        {
            bool isSaveSuccess = false;
            string fFormCode = form["fFormCode"];//表单Guid
            string businessFlowCode = form["businessFlowCode"];//业务流程Guid
            string businessFlowFormCode = form["businessFlowFormCode"];//业务流程表单关联Guid       
            string fkType = form["fkType"];//流程类型(案件或者商机类型)

            string formKey = String.Empty;
            DateTime now = DateTime.Now;

            #region 处理虚拟属性数量(虚拟属性不会做数据库处理)
            int virtualPropertyCount = 0;//虚拟属性数量
            for (int i = 0; i < form.AllKeys.Length; i++)
            {
                formKey = form.AllKeys[i];
                if (formKey.StartsWith("virtualField_"))
                {
                    virtualPropertyCount++;
                }
            }
            #endregion

            #region 处理表单头属性值
            int headPropertyCount = 0;//单头属性数量
            List<CommonService.Model.Customer.V_FormPropertyValue> V_FormPropertyValues = new List<CommonService.Model.Customer.V_FormPropertyValue>();
            for (int i = 0; i < form.AllKeys.Length; i++)
            {
                formKey = form.AllKeys[i];
                if (formKey.Contains("formproperty_") && !formKey.StartsWith("items_"))//去除列表属性
                {//表明为正规自定义表单属性
                    string[] formKeyGroup = formKey.Split('_');
                    if (formKeyGroup.Length == 2)
                    {//代表 普通表单元素(文本框，日期框，单选按钮，下拉框，复选框)
                        CommonService.Model.Customer.V_FormPropertyValue propertyValue = new CommonService.Model.Customer.V_FormPropertyValue();
                        //这里表单属性值Id之所以这么赋值，是因为 UI 中 Form 的"表单元素 name 值"已关联到了表单属性值Guid
                        propertyValue.FormPropertyValue_Code = new Guid(formKeyGroup[1]);
                        propertyValue.FormPropertyValue_Value = form[formKey];
                        V_FormPropertyValues.Add(propertyValue);
                        headPropertyCount++;
                    }
                    else
                    {//代表 弹出参照UI控件
                        //这种情况是虚拟属性，只是用来在UI中显示名称的，不需要保存到数据中
                        if (formKey.Contains(".Name_formproperty_"))
                        {
                            headPropertyCount++;
                            continue;
                        }
                        if (formKey.Contains(".Code_formproperty_"))
                        {
                            CommonService.Model.Customer.V_FormPropertyValue propertyValue = new CommonService.Model.Customer.V_FormPropertyValue();
                            //这里表单属性值Guid之所以这么赋值，是因为 UI 中 Form 的"表单元素 name 值"已关联到了表单属性值Guid
                            propertyValue.FormPropertyValue_Code = new Guid(formKeyGroup[2]);
                            propertyValue.FormPropertyValue_Value = form[formKey];
                            V_FormPropertyValues.Add(propertyValue);
                            headPropertyCount++;
                        }
                    }

                }
            }
            #endregion

            #region 处理 table 数量
            Dictionary<string, int> itemGroup = new Dictionary<string, int>();
            for (int i = 0; i < form.AllKeys.Length; i++)
            {
                if (form.AllKeys[i].StartsWith("itemGroup_"))
                {
                    string itemGroupValue = form[i];
                    itemGroup.Add(itemGroupValue.Split('_')[0], int.Parse(itemGroupValue.Split('_')[1]));
                }
            }
            #endregion

            if (form.AllKeys.Length == (4 + itemGroup.Count + headPropertyCount + virtualPropertyCount))
            {
                return Json(TipHelper.JsonData("请您填写明细信息！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }

            #region 处理表单子表属性值
            List<CommonService.Model.CustomerForm.F_FormPropertyValue> FormPropertyValues = new List<CommonService.Model.CustomerForm.F_FormPropertyValue>();//表单属性值集合

            #region 新增时，处理行转列的分组标识
            Dictionary<string, string> rowToColumnGroup = new Dictionary<string, string>();
            for (int i = 0; i < form.AllKeys.Length; i++)
            {
                if (form.AllKeys[i].StartsWith("items_"))
                {
                    string formPropertyName = form.AllKeys[i];//表单属性名称
                    string[] formPropertyNameGroup = formPropertyName.Split('_');
                    if (!rowToColumnGroup.Keys.Contains("items_" + formPropertyNameGroup[1] + "_" + formPropertyNameGroup[2]))
                    {
                        rowToColumnGroup.Add("items_" + formPropertyNameGroup[1] + "_" + formPropertyNameGroup[2], Guid.NewGuid().ToString());
                    }
                }
            }

            #endregion

            foreach (KeyValuePair<string, int> dict in itemGroup)
            {
                for (int i = 0; i < form.AllKeys.Length; i++)
                {
                    if (form.AllKeys[i].StartsWith("items_" + dict.Key + "_"))
                    {
                        /*
                         * 自定义table表单元素属性名称格式："items_"+"父亲属性Guid(即普通子表属性)_"+"行索引_"+"属性字段名称_"+"属性Guid"(如果对应行数据已保存，则还需要+"_属性值Id")
                         * 通过表单属性名称中是否包含"_属性值Id"来确定操作是新增还是修改
                         **/
                        string formPropertyName = form.AllKeys[i];//表单属性名称
                        string[] formPropertyNameGroup = formPropertyName.Split('_');
                        string rowToColumnKey = "items_" + formPropertyNameGroup[1] + "_" + formPropertyNameGroup[2];
                        if (formPropertyNameGroup.Length == 5)
                        {//新增                           
                            CommonService.Model.CustomerForm.F_FormPropertyValue propertyValue = new CommonService.Model.CustomerForm.F_FormPropertyValue();
                            propertyValue.F_FormPropertyValue_code = Guid.NewGuid();
                            propertyValue.F_FormPropertyValue_form = new Guid(fFormCode);
                            propertyValue.F_FormPropertyValue_formProperty = new Guid(formPropertyNameGroup[4]);
                            propertyValue.F_FormPropertyValue_BusinessFlowFormCode = new Guid(businessFlowFormCode);
                            propertyValue.F_FormPropertyValue_value = form[i];
                            propertyValue.F_FormPropertyValue_isDelete = false;
                            propertyValue.F_FormPropertyValue_creator = Context.UIContext.Current.UserCode;
                            propertyValue.F_FormPropertyValue_createTime = now;
                            propertyValue.F_FormPropertyValue_group = new Guid(rowToColumnGroup[rowToColumnKey]);//行转列分组标识

                            FormPropertyValues.Add(propertyValue);
                        }
                        else if (formPropertyNameGroup.Length == 6)
                        {//修改                            
                            CommonService.Model.CustomerForm.F_FormPropertyValue propertyValue = new CommonService.Model.CustomerForm.F_FormPropertyValue();
                            propertyValue.F_FormPropertyValue_id = int.Parse(formPropertyNameGroup[5]);
                            propertyValue.F_FormPropertyValue_value = form[i];
                            FormPropertyValues.Add(propertyValue);
                        }
                    }
                }

            }
            #endregion

            isSaveSuccess = _formPropertyValueWCF.SaveHeadItemsFormPropertyValue(V_FormPropertyValues, FormPropertyValues, new Guid(fFormCode), new Guid(businessFlowFormCode));

            if (isSaveSuccess)
            {
                return Json(TipHelper.JsonData("保存信息成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 检查当前登录用户是否有保存表单的权限
        /// </summary>
        /// <param name="formStatus">表单状态</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>
        private bool ExistIsHasSaveFormPower(int formStatus, Guid businessFlowFormCode)
        {
            bool isHasSavePower = false;//没有保存表单的权限

            /**
             * author:hety
             * date:2015-06-18
             * description:
             * (1)、如果为内置管理员，则不受任何权限的限制
             * (2)、只有表单状态为"未提交"或者"未通过"时，才可能会有保存表单的权限
             * (3)、只有关联当前表单的"主办律师"和"协办律师"才可以有保存表单的权限
             * */

            if (Context.UIContext.Current.IsPreSetManager)
            {
                isHasSavePower = true;
            }
            else
            {
                if (formStatus == Convert.ToInt32(FormStatusEnum.未提交) || formStatus == Convert.ToInt32(FormStatusEnum.未通过))
                {
                    List<CommonService.Model.Customer.V_User> V_User = _vUserWCF.GetSaveOwnFormUsers(businessFlowFormCode);
                    var powerUserList = from allList in V_User
                                        where allList.UserCode == Context.UIContext.Current.UserCode
                                        select allList;
                    if (powerUserList.Count() != 0)
                    {
                        isHasSavePower = true;//代表"允许当前登录用户保存"
                    }
                }
            }
            return isHasSavePower;
        }

        /// <summary>
        /// 检查当前用户是否有"进入下一流程"的权限
        /// </summary>
        /// <param name="pkCode">关联Guid，比如商机Guid或者案件Guid</param>
        /// <param name="pkType">关联Guid类型，案件=153;商机=154</param>
        /// <returns></returns>
        private bool IsHasEnterNextBusinessFlowPower(Guid pkCode, int pkType)
        {
            /**
             * author:hety 
             * date:2015-06-18
             * description:
             * (1)、目前只有一级负责人才有"进入下一流程"的权限，比如案件负责人
             * (2)、内置系统管理员用户为万能用户，不受任何权限限制
             **/
            bool isHasEnter = false;
            if (Context.UIContext.Current.IsPreSetManager)
            {
                isHasEnter = true;
            }
            else
            {
                if (pkType == Convert.ToInt32(FlowTypeEnum.案件))
                {
                    CommonService.Model.CaseManager.B_Case bcase = _caseWCF.GetModel(pkCode);
                    if (bcase != null)
                    {
                        if (bcase.B_Case_person == Context.UIContext.Current.UserCode)
                        {
                            isHasEnter = true;
                        }
                    }
                }
                else if (pkType == Convert.ToInt32(FlowTypeEnum.商机))
                {
                    CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(pkCode);
                    if (businessChance != null)
                    {
                        if (businessChance.B_BusinessChance_person == Context.UIContext.Current.UserCode)
                        {
                            isHasEnter = true;
                        }
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
             * date:2015-06-18
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
             * date:2015-06-18
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
        /// 检查当前登录用户是否为此案件的专业顾问
        /// </summary>
        /// <returns></returns>
        private bool ExistsHasZyGwPower(Guid caseCode)
        {
            bool isHasPower = false;

            if (UIContext.Current.IsPreSetManager)
            {//内置系统管理员拥有此权限
                isHasPower = true;
            }
            else
            {
                List<CommonService.Model.CaseManager.B_Case_link> caseLinks = _caselinkWCF.GetCaseLinksByCaseAndType(caseCode, Convert.ToInt32(CaselinkEnum.销售顾问));
                foreach (CommonService.Model.CaseManager.B_Case_link caseLink in caseLinks)
                {
                    if (caseLink.C_FK_code == Context.UIContext.Current.UserCode)
                    {//当前登录用户为此案件的专业顾问
                        isHasPower = true;
                        break;
                    }
                }
            }
            return isHasPower;
        }

        /// <summary>
        /// 检查当前登录用户是否为此案件的负责人
        /// </summary>
        /// <returns></returns>
        private bool ExistsHasZhzxPower(Guid caseCode)
        {
            bool isHasPower = false;

            if (UIContext.Current.IsPreSetManager)
            {//内置系统管理员拥有此权限
                isHasPower = true;
            }
            else
            {
                CommonService.Model.CaseManager.B_Case bCase = _caseWCF.GetModel(caseCode);
                if (bCase != null)
                {
                    if (bCase.B_Case_person == Context.UIContext.Current.UserCode)
                    {//当前登录用户为此案件的负责人
                        isHasPower = true;
                    }
                }
            }
            return isHasPower;
        }

        /// <summary>
        /// 检查当前登录用户是否为此案件的首席专家(案件一级负责人)
        /// </summary>
        /// <returns></returns>
        private bool ExistsHasSxzjPower(Guid caseCode)
        {
            bool isHasPower = false;

            if (UIContext.Current.IsPreSetManager)
            {//内置系统管理员拥有此权限
                isHasPower = true;
            }
            else
            {
                CommonService.Model.CaseManager.B_Case bCase = _caseWCF.GetModel(caseCode);
                if (bCase != null)
                {
                    if (bCase.B_Case_firstClassResponsiblePerson == Context.UIContext.Current.UserCode)
                    {//当前登录用户为此案件的一级负责人
                        isHasPower = true;
                    }
                }
            }
            return isHasPower;
        }

        /// <summary>
        /// 是否有案件财务的权限
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        private bool ExistsHasFinancePower(Guid caseCode)
        {
            bool isHasPower = false;

            if (UIContext.Current.IsPreSetManager)
            {//内置系统管理员拥有此权限
                isHasPower = true;
            }
            else
            {
                List<CommonService.Model.SysManager.C_Userinfo> users = _userinfoWCF.GetPowerUsersByCase(caseCode);
                var defaultFinance = users.Where(p => p.C_Userinfo_code == Context.UIContext.Current.UserCode).FirstOrDefault();
                if (defaultFinance != null)
                {
                    isHasPower = true;
                }
            }
            return isHasPower;
        }

        /// <summary>
        /// 检查是否有部长审查的权限(只针对商机)
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <param name="ministerUserCode">部长Guid</param>
        /// <returns></returns>
        private bool ExistsHasMinisterCheckPower(Guid businessChanceCode, Guid? ministerUserCode)
        {
            bool isHasPower = false;
            CommonService.Model.BusinessChanceManager.B_BusinessChance_check businessChanceCheck = _businessChance_checkWCF.GetUnCheckedChanceCheck(businessChanceCode, Convert.ToInt32(BusinessChanceCheckPersonTypeEnum.部长));
            if (businessChanceCheck != null)
            {
                if (UIContext.Current.IsPreSetManager)
                {
                    isHasPower = true;
                }
                else
                {
                    if (ministerUserCode == UIContext.Current.UserCode)
                    {
                        isHasPower = true;
                    }
                }
            }
            return isHasPower;
        }

        /// <summary>
        /// 检查是否有首席审查的权限(只针对商机)
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <param name="chiefUserCode">首席Guid</param>
        /// <returns></returns>
        private bool ExistsHasChiefCheckPower(Guid businessChanceCode, Guid? chiefUserCode)
        {
            bool isHasPower = false;
            CommonService.Model.BusinessChanceManager.B_BusinessChance_check businessChanceCheck = _businessChance_checkWCF.GetUnCheckedChanceCheck(businessChanceCode, Convert.ToInt32(BusinessChanceCheckPersonTypeEnum.首席));
            if (businessChanceCheck != null)
            {
                if (UIContext.Current.IsPreSetManager)
                {
                    isHasPower = true;
                }
                else
                {
                    if (chiefUserCode == UIContext.Current.UserCode)
                    {
                        isHasPower = true;
                    }
                }
            }
            return isHasPower;
        }
    }
}