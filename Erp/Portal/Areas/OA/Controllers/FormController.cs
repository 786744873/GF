using CommonService.Common;
using Maticsoft.Common;
using Microsoft.AspNet.SignalR;
using Portal.Controllers;
using Portal.Hubs;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.OA.Controllers
{
    /// <summary>
    /// 表单控制器
    /// </summary>
    public class FormController : BaseController
    {
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.OA.IO_Form _oFormWCF;
        private readonly ICommonService.OA.IO_Flow _flowWCF;
        private readonly ICommonService.OA.IO_FlowSet _flowsetWCF;
        private readonly ICommonService.CustomerForm.IF_Form _formWCF;
        private readonly ICommonService.CustomerForm.IF_FormProperty _formPropertyWCF;
        private readonly ICommonService.CustomerForm.IF_FormPropertyValue _formPropertyValueWCF;
        private readonly ICommonService.OA.IO_FlowSet_AuditPerson _flowSetAuditPersonWCF;
        private readonly ICommonService.IC_Messages _messageWCF;
        private readonly ICommonService.OA.IO_Form_AuditFlow _oformAuditFlowWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow_form _businessFlowFormWCF;
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;
        private readonly ICommonService.SysManager.IC_Userinfo_area _userinfo_areaWCF;
        private readonly ICommonService.IC_Region _regionWCF;

        public FormController()
        {
            #region 服务初始化
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _oFormWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Form>("oFormWCF");
            _flowWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Flow>("oFlowWCF");
            _flowsetWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_FlowSet>("oFlowSetWCF");
            _formWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_Form>("FormWCF");
            _formPropertyWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormProperty>("FormPropertyWCF");
            _formPropertyValueWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormPropertyValue>("FormPropertyValueWCF");
            _flowSetAuditPersonWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_FlowSet_AuditPerson>("oFlowSet_AuditPersonWCF");
            _messageWCF = ServiceProxyFactory.Create<ICommonService.IC_Messages>("MessagesWCF");
            _oformAuditFlowWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Form_AuditFlow>("oForm_AuditFlowWCF");
            _businessFlowFormWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow_form>("Business_flow_formWCF");
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
            _userinfo_areaWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo_area>("Userinfo_areaWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
            #endregion
        }

        //
        // GET: /OA/Form/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// ERP系统跳转并且导航过来的Action(创建并且保存)
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateAndSave()
        {
            string businessFlowform = Request["id"];//业务流程表单关联Guid
            string nav = Request["nav"];
            Guid fForm = Guid.Empty;

            #region ERP表单固定赋值
            if (nav.Contains("_feereimbursement_"))
            {//费用报销单(Guid)
                fForm = new Guid("4B483102-0B05-418A-ACC0-41313D5D083E");
            }
            else if (nav.Contains("_feeLoan_"))
            {//费用借款单(Guid)
                fForm = new Guid("373A0905-5797-41E0-BB6A-BBC53990B835");
            }
            #endregion

            CommonService.Model.OA.O_Form model = _oFormWCF.GetModelByBusinessFlowformCode(new Guid(businessFlowform), fForm, new Guid(Context.UIContext.Current.UserCode.ToString()));
            if (model == null)
            {//如果之前的表单已经提交，则从新再建一个表单
                model = new CommonService.Model.OA.O_Form();
                model.O_Form_code = Guid.NewGuid();
                model.O_Form_f_form = fForm;
                model.O_Form_businessFlowform = new Guid(businessFlowform);
                model.O_Form_isDelete = false;
                model.O_Form_creator = Context.UIContext.Current.UserCode;
                model.O_Form_createTime = DateTime.Now;
                model.O_Form_applyStatus = Convert.ToInt32(FormApplyTypeEnum.未提交);
                _oFormWCF.Add(model);
            }
            return RedirectToAction("LayoutRootTabs", new { fFormCode = model.O_Form_f_form.ToString(), oFormCode = model.O_Form_code.ToString() });
        }

        /// <summary>
        /// 创建表单
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            CommonService.Model.OA.O_Form model = new CommonService.Model.OA.O_Form();
            model.O_Form_code = Guid.NewGuid();
            model.O_Form_isDelete = false;
            model.O_Form_creator = Context.UIContext.Current.UserCode;
            model.O_Form_applyStatus = Convert.ToInt32(FormApplyTypeEnum.未提交);
            InitializationPageParameter();
            return View(model);
        }
        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="formmodel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection form, CommonService.Model.OA.O_Form formmodel)
        {
            //服务方法调用
            bool flag = true;
            CommonService.Model.OA.O_Flow flowmodel = _flowWCF.Get(new Guid(formmodel.O_Form_flow.ToString()));
            if (formmodel.O_Form_id > 0)
            { //修改
                if (flowmodel.O_Flow_isFree)
                {//自由流程
                    if (!_oFormWCF.Update(formmodel))
                        flag = false;
                }
                else
                { //不是自由流程
                    if (!_oFormWCF.UpdateOrAddList(formmodel, 2))
                        flag = false;
                }
            }
            else
            { //添加
                if (flowmodel.O_Flow_isFree)
                {//自由流程
                    formmodel.O_Form_createTime = DateTime.Now;
                    formmodel.O_Form_applyStatus = Convert.ToInt32(FormApplyTypeEnum.未提交);
                    if (!(_oFormWCF.Add(formmodel) > 0))
                        flag = false;
                }
                else
                { //不是自由流程
                    formmodel.O_Form_applyStatus = Convert.ToInt32(FormApplyTypeEnum.未提交);
                    if (!_oFormWCF.UpdateOrAddList(formmodel, 1))
                        flag = false;
                }
            }

            if (flag)
            {
                /*
                 * description:标签这个页面比较特殊，因为它不是列表形式，所以这里要在对应ajaxdone.js里单独处理，来刷新页面,并且刷新页面的唯一标识，要以"ajaxify_sidebar_"开头
                 * author:hety
                 * date:2015-08-05
                **/
                return Json(TipHelper.JsonData("创建表单成功！", "ajaxify_trigger|/oa/form/layoutroottabs?fFormCode=" + formmodel.O_Form_f_form.ToString() + "&oFormCode=" + formmodel.O_Form_code.ToString(), IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageGoAnotherPage));
            }
            else
            {
                //表单提交失败固定写法
                return Json(TipHelper.JsonData("创建表单失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }


        /// <summary>
        /// 表单不同UI类型分支处理Action
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <returns></returns>

        public ActionResult LayoutRootTabs(string fFormCode, string oFormCode, string msgID)
        {
            if (String.IsNullOrEmpty(fFormCode))
            {
                CommonService.Model.OA.O_Form oForm = _oFormWCF.Get(new Guid(oFormCode));
                fFormCode = oForm.O_Form_f_form.Value.ToString();
            }
            if (!string.IsNullOrEmpty(msgID))
            {
                //处理消息为已读
                CommonService.Model.C_Messages model = _messageWCF.GetModel(Convert.ToInt32(msgID));
                if (model.C_Messages_isRead == 0)
                {
                    _messageWCF.ReadMessage(Convert.ToInt32(msgID));
                    model.C_Messages_isRead = 1;
                    var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                    var touser = ChatHub.userlist.FirstOrDefault(x => x.userCode == model.C_Messages_person.ToString());//查询消息人信息
                    context.Clients.Client(touser.ConnectionId).removeFormSubMsg(msgID);//接收消息人的数据集合
                }
            }
            //表单UI类型
            int formCustomerType = _oFormWCF.GetFormCustomerType(new Guid(fFormCode));

            if (formCustomerType == 2)
            {
                return RedirectToAction("GenerateHeadItems", new { fFormCode = fFormCode, oFormCode = oFormCode, random = Guid.NewGuid().ToString() });
            }
            else if (formCustomerType == 3)
            {
                return RedirectToAction("GenerateSingleItems", new { fFormCode = fFormCode, oFormCode = oFormCode, random = Guid.NewGuid().ToString() });
            }
            else
            {
                return RedirectToAction("GenerateSingleEidt", new { fFormCode = fFormCode, oFormCode = oFormCode, random = Guid.NewGuid().ToString() });
            }
        }

        /// <summary>
        /// 动态生成复选框
        /// </summary>
        /// <param name="formPropertyValue">表单属性值实体</param>
        /// <returns></returns>
        public PartialViewResult GenerateCheckbox(CommonService.Model.CustomerForm.F_FormProperty formPropertyValue)
        {
            int parentId = -1;
            if (!String.IsNullOrEmpty(formPropertyValue.F_FormProperty_dataSource_conditionValue))
            {
                parentId = Convert.ToInt32(formPropertyValue.F_FormProperty_dataSource_conditionValue);
            }
            List<CommonService.Model.C_Parameters> childrenParameters = this.InitializationParameter(parentId);
            ViewBag.FormPropertyValue = formPropertyValue;
            return PartialView("CheckboxPartial", childrenParameters);
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
        /// 动态生成下拉框
        /// </summary>
        /// <param name="formPropertyValue">表单属性值实体</param>
        /// <returns></returns>
        public PartialViewResult GenerateDropDown(CommonService.Model.CustomerForm.F_FormProperty formPropertyValue)
        {
            int parentId = -1;
            if (!String.IsNullOrEmpty(formPropertyValue.F_FormProperty_dataSource_conditionValue))
            {
                parentId = Convert.ToInt32(formPropertyValue.F_FormProperty_dataSource_conditionValue);
            }
            List<CommonService.Model.C_Parameters> childrenParameters = this.InitializationParameter(parentId);
            ViewBag.FormPropertyValue = formPropertyValue;
            return PartialView("DropDownPartial", childrenParameters);
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


        public ActionResult MulityItems()
        {
            return View();
        }

        public ActionResult LayoutHeadAndMulityItems()
        {
            return View();
        }

        /// <summary>
        /// 生成只有编辑界面的Action
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <returns></returns>
        public ActionResult GenerateSingleEidt(string fFormCode, string oFormCode)
        {
            CommonService.Model.OA.O_Form oForm = _oFormWCF.Get(new Guid(oFormCode));
            CommonService.Model.OA.O_Flow flow = _flowWCF.Get(oForm.O_Form_flow.Value);
            CommonService.Model.CustomerForm.F_Form fForm = _formWCF.Get(new Guid(fFormCode));

            ViewBag.FormName = fForm.F_Form_chineseName;
            ViewBag.IsFreeFlow = flow.O_Flow_isFree;
            ViewBag.OFormCode = oFormCode;
            ViewBag.ApplyStatus = oForm.O_Form_applyStatus.Value;

            //获取表单属性及其属性值
            List<CommonService.Model.CustomerForm.F_FormProperty> formPropertys = _formPropertyWCF.GetOAEditFormPropertyValueList(new Guid(fFormCode), new Guid(oFormCode));
            return View(formPropertys);
        }

        /// <summary>
        /// 生成只有普通子表界面的Action
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <returns></returns>
        public ActionResult GenerateSingleItems(string fFormCode, string oFormCode)
        {
            bool isFreeFlow = false;//是否自由流程
            string businessFlowFormCode = String.Empty;//业务流程表单关联Guid
            CommonService.Model.OA.O_Form oForm = _oFormWCF.Get(new Guid(oFormCode));
            if (oForm.O_Form_businessFlowform != null)
            {//此属性如果有值的话，代表关联了ERP中业务流程表单关联Guid，默认赋值为非自由流程
                isFreeFlow = false;
                businessFlowFormCode = oForm.O_Form_businessFlowform.ToString();
            }
            else
            {
                CommonService.Model.OA.O_Flow flow = _flowWCF.Get(oForm.O_Form_flow.Value);
                isFreeFlow = flow.O_Flow_isFree;
            }

            CommonService.Model.CustomerForm.F_Form fForm = _formWCF.Get(new Guid(fFormCode));

            ViewBag.FormName = fForm.F_Form_chineseName;
            ViewBag.IsFreeFlow = isFreeFlow;
            ViewBag.OFormCode = oFormCode;
            ViewBag.FFormCode = fFormCode;
            ViewBag.ApplyStatus = oForm.O_Form_applyStatus.Value;
            ViewBag.BusinessFlowFormCode = businessFlowFormCode;

            //获取表单属性
            List<CommonService.Model.CustomerForm.F_FormProperty> formPropertys = _formPropertyWCF.GetList(new Guid(fFormCode));
            if (oForm.O_Form_businessFlowform != null)
            {
                CommonService.Model.CaseManager.B_Case caseModel = _caseWCF.GetModelbyFormcode(new Guid(oForm.O_Form_businessFlowform.ToString()));
                ViewBag.caseModel = caseModel;
            }
            else
            {
                ViewBag.caseModel = null;
            }

            //获取属性值
            DataSet formPropertyValues = _formPropertyValueWCF.DynamicLoadCustmerFormListValues(new Guid(fFormCode), new Guid(oFormCode));
            ViewBag.DynamicFormPropertyValues = formPropertyValues;
            return View(formPropertys);
        }

        /// <summary>
        /// 生成主子表界面的Action
        /// </summary>
        /// <param name="fFormCode">ERP表单Guid</param>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <returns></returns>
        public ActionResult GenerateHeadItems(string fFormCode, string oFormCode)
        {
            CommonService.Model.OA.O_Form oForm = _oFormWCF.Get(new Guid(oFormCode));
            CommonService.Model.OA.O_Flow flow = _flowWCF.Get(oForm.O_Form_flow.Value);
            CommonService.Model.CustomerForm.F_Form fForm = _formWCF.Get(new Guid(fFormCode));

            ViewBag.FormName = fForm.F_Form_chineseName;
            ViewBag.IsFreeFlow = flow.O_Flow_isFree;
            ViewBag.OFormCode = oFormCode;
            ViewBag.FFormCode = fFormCode;
            ViewBag.ApplyStatus = oForm.O_Form_applyStatus.Value;

            //获取表单头编辑属性及其属性值
            List<CommonService.Model.CustomerForm.F_FormProperty> editFormPropertys = _formPropertyWCF.GetOAHeadEditFormPropertyValueList(new Guid(fFormCode), new Guid(oFormCode));
            ViewBag.EditFormPropertys = editFormPropertys;

            //获取表单明细属性
            List<CommonService.Model.CustomerForm.F_FormProperty> itemFormPropertys = _formPropertyWCF.GetList(new Guid(fFormCode));
            //获取表单明细属性值
            DataSet itemFormPropertyValues = _formPropertyValueWCF.DynamicLoadCustmerFormListValues(new Guid(fFormCode), new Guid(oFormCode));
            ViewBag.DynamicItemFormPropertyValues = itemFormPropertyValues;
            return View(itemFormPropertys);
        }

        /// <summary>
        /// 提交只有编辑页面的表单
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveSingleEdit(FormCollection form)
        {
            string oFormCode = form["oFormCode"];//协同办公表单Guid
            string operateType = form["operateType"];//按钮操作类型，1代表保存，2代表保存并且提交
            string isFreeFlow = form["isFreeFlow"];//是否自由流程，1代表是，0代表否
            bool isSaveSuccess = false;
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
                    {//代表 普通表单元素(文本框，日期框，单选按钮，下拉框，复选框)
                        CommonService.Model.Customer.V_FormPropertyValue propertyValue = new CommonService.Model.Customer.V_FormPropertyValue();
                        //这里表单属性值Id之所以这么赋值，是因为 UI 中 Form 的"表单元素 name 值"已关联到了表单属性值Id
                        propertyValue.FormPropertyValue_Id = int.Parse(formKeyGroup[1]);
                        propertyValue.FormPropertyValue_Value = form[formKey];
                        V_FormPropertyValues.Add(propertyValue);
                    }
                    else
                    {//代表 其它UI控件

                    }
                }
            }

            isSaveSuccess = _formPropertyValueWCF.UpdateFormPropertyValueByPropertyId(V_FormPropertyValues);
            if (isSaveSuccess)
            {//成功
                if (operateType == "1")
                {
                    return Json(TipHelper.JsonData("保存表单成功！", "ajaxify_trigger|/oa/form/layoutroottabs?oFormCode=" + oFormCode, IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageGoAnotherPage));
                }
                else
                {
                    if (isFreeFlow == "1")
                    {//对于自由流程表单,在提交的时候会先打开提交页面
                        return Json(TipHelper.JsonData("保存表单成功！", "atarget_trigger|baseLargeModal|/oa/freeformaudit/createsubmit?oFormCode=" + oFormCode, IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageOpenAnotherPage));
                    }
                    else
                    {//非自由流程表单，提交
                        CommonService.Model.OA.O_Form oForm = _oFormWCF.Get(new Guid(oFormCode));
                        oForm.O_Form_applyPerson = Context.UIContext.Current.UserCode;
                        oForm.O_Form_applyStatus = Convert.ToInt32(FormApplyTypeEnum.已提交);
                        oForm.O_Form_applyTime = DateTime.Now;
                        _oFormWCF.Update(oForm);
                        sendMSG(oFormCode);
                        return Json(TipHelper.JsonData("提交表单成功！", "ajaxify_trigger|/oa/form/layoutroottabs?oFormCode=" + oFormCode, IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageGoAnotherPage));
                    }
                }
            }
            else
            {//失败
                if (operateType == "1")
                {
                    return Json(TipHelper.JsonData("保存表单失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
                else
                {
                    return Json(TipHelper.JsonData("提交表单失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
            }
        }

        /// <summary>
        /// 提交只有普通子表页面的表单
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveSingleItem(FormCollection form)
        {
            /*
             * author:hety
             * date:2015-08-12
             * description:处理一个或多个普通子表保存逻辑
             **/
            bool isSaveSuccess = false;
            string fFormCode = form["fFormCode"];//ERP表单Guid
            string oFormCode = form["oFormCode"];//协同办公表单Guid
            string operateType = form["operateType"];//按钮操作类型，1代表保存，2代表保存并且提交
            string isFreeFlow = form["isFreeFlow"];//是否自由流程，1代表是，0代表否
            string businessFlowFormCode = form["businessFlowFormCode"];//ERP业务流程表单关联Guid
            DateTime now = DateTime.Now;

            #region 获取当前用户区域
            string RegionAbbreviation = "";
            Guid userCode = new Guid(Context.UIContext.Current.UserCode.ToString());
            List<CommonService.Model.SysManager.C_Userinfo_region> userinfoRegions = _userinfo_areaWCF.GetListByUserinfoCode(userCode);
            CommonService.Model.C_Region region = new CommonService.Model.C_Region();
            if (userinfoRegions.Count != 0)
            {
                region = _regionWCF.GetModelByCode(userinfoRegions[0].C_Region_code.Value);
                RegionAbbreviation = region.C_Region_abbreviation;
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

            if (form.AllKeys.Length == (5 + itemGroup.Count))
            {
                return Json(TipHelper.JsonData("请您填写明细信息！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }

            #region 处理表单属性值
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

            int num = 0;
            foreach (KeyValuePair<string, int> dict in itemGroup)
            {
                for (int i = 0; i < form.AllKeys.Length; i++)
                {
                    if (form.AllKeys[i].StartsWith("items_" + dict.Key + "_"))
                    {
                        /*
                         * 自定义table表单元素属性名称格式："items_"+"父亲属性Id(即普通子表属性)_"+"行索引_"+"属性字段名称_"+"属性id"(如何对应行数据已保存，则还需要+"_属性值Id")
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
                            propertyValue.F_FormPropertyValue_formProperty_id = int.Parse(formPropertyNameGroup[4]);
                            propertyValue.F_FormPropertyValue_BusinessFlowFormCode = new Guid(oFormCode);
                            DateTime dt = DateTime.Now;
                            string year = dt.ToString("yyyy-MM-dd HH:mm:ss").Substring(2, 2);
                            string month = dt.ToString("yyyy-MM-dd HH:mm:ss").Substring(5, 2);
                            if (form.AllKeys[i].Contains("_4509"))
                            {//这里是处理财务报销表单中的"编号"字段.目前采用写死的做法
                                string formPropertyCode = "0DDD0794-DC54-45BF-9BFF-FD595EA09AA3";//费用报销表单编号Guid
                                CommonService.Model.CustomerForm.F_FormPropertyValue formPropertyValue = _formPropertyValueWCF.GetMaxModelByFormAndFormProperty(propertyValue.F_FormPropertyValue_form.Value, new Guid(formPropertyCode));
                                string number = formPropertyValue.F_FormPropertyValue_value;
                                string RendStr = "";

                                if (num != 0)
                                {
                                    num++;
                                }
                                else
                                {
                                    num = formPropertyValue != null ? Convert.ToInt32(number.Substring(number.Length - 4, 4)) + 1 : 001;
                                }

                                if (number.Substring(number.Length - 6, 2) != month && num == 0)
                                {
                                    RendStr = "BX" + RegionAbbreviation + year + month + "0001";
                                    num = 1;
                                }
                                else
                                {
                                    if (num.ToString().Length == 1)
                                    {
                                        RendStr = "BX" + RegionAbbreviation + year + month + "000" + num;
                                    }
                                    else if (num.ToString().Length == 2)
                                    {
                                        RendStr = "BX" + RegionAbbreviation + year + month + "00" + num;
                                    }
                                    else if (num.ToString().Length == 3)
                                    {
                                        RendStr = "BX" + RegionAbbreviation + year + month + "0" + num;
                                    }
                                    else
                                    {
                                        RendStr = "BX" + RegionAbbreviation + year + month + num;
                                    }
                                }

                                propertyValue.F_FormPropertyValue_value = RendStr;
                            }
                            else if (form.AllKeys[i].Contains("_4510"))
                            {//这里是处理财务借款表单中的"编号"字段.目前采用写死的做法
                                string formPropertyCode = "6A96222B-1814-451E-9C96-569363CA52F9";//费用借款表单编号Guid
                                CommonService.Model.CustomerForm.F_FormPropertyValue formPropertyValue = _formPropertyValueWCF.GetMaxModelByFormAndFormProperty(propertyValue.F_FormPropertyValue_form.Value, new Guid(formPropertyCode));
                                string number = formPropertyValue.F_FormPropertyValue_value;
                                string RendStr = "";
                                if (num != 0)
                                {
                                    num++;
                                }
                                else
                                {
                                    num = formPropertyValue != null ? Convert.ToInt32(number.Substring(number.Length - 4, 4)) + 1 : 001;
                                }

                                if (number.Substring(number.Length - 6, 2) != month && num == 0)
                                {
                                    RendStr = "JK" + RegionAbbreviation + year + month + "0001";
                                    num = 1;
                                }
                                else
                                {
                                    if (num.ToString().Length == 1)
                                    {
                                        RendStr = "JK" + RegionAbbreviation + year + month + "000" + num;
                                    }
                                    else if (num.ToString().Length == 2)
                                    {
                                        RendStr = "JK" + RegionAbbreviation + year + month + "00" + num;
                                    }
                                    else if (num.ToString().Length == 3)
                                    {
                                        RendStr = "JK" + RegionAbbreviation + year + month + "0" + num;
                                    }
                                    else
                                    {
                                        RendStr = "JK" + RegionAbbreviation + year + month + num;
                                    }
                                }

                                propertyValue.F_FormPropertyValue_value = RendStr;
                            }
                            else
                            {
                                propertyValue.F_FormPropertyValue_value = form[i];
                            }

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

            isSaveSuccess = _formPropertyValueWCF.SaveOAItemsFormPropertyValue(FormPropertyValues, new Guid(fFormCode), new Guid(oFormCode), 1);

            if (isSaveSuccess)
            {//成功
                if (operateType == "1")
                {
                    return Json(TipHelper.JsonData("保存表单成功！", "ajaxify_trigger|/oa/form/layoutroottabs?oFormCode=" + oFormCode, IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageGoAnotherPage));
                }
                else
                {
                    if (isFreeFlow == "1")
                    {//对于自由流程表单,在提交的时候会先打开提交页面
                        return Json(TipHelper.JsonData("保存表单成功！", "atarget_trigger|baseLargeModal|/oa/freeformaudit/createsubmit?oFormCode=" + oFormCode, IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageOpenAnotherPage));
                    }
                    else
                    {//非自由流程表单，提交
                        if (!String.IsNullOrEmpty(businessFlowFormCode))
                        {//费用报销单或费用借款单预置流程提交审批
                            isSaveSuccess = _oFormWCF.SubmitFinanceForm(new Guid(fFormCode), new Guid(oFormCode), new Guid(businessFlowFormCode), Context.UIContext.Current.UserCode.Value);
                            if (isSaveSuccess)
                            {
                                sendMSG(oFormCode);
                                return Json(TipHelper.JsonData("提交表单成功！", "ajaxify_trigger|/oa/form/layoutroottabs?oFormCode=" + oFormCode, IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageGoAnotherPage));
                            }
                            else
                            {
                                return Json(TipHelper.JsonData("提交表单失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                            }
                        }
                        else
                        {//普通预置流程提交审批
                            CommonService.Model.OA.O_Form oForm = _oFormWCF.Get(new Guid(oFormCode));
                            oForm.O_Form_applyPerson = Context.UIContext.Current.UserCode;
                            oForm.O_Form_applyStatus = Convert.ToInt32(FormApplyTypeEnum.已提交);
                            oForm.O_Form_applyTime = DateTime.Now;
                            _oFormWCF.Update(oForm);
                            sendMSG(oFormCode);
                        }
                        return Json(TipHelper.JsonData("提交表单成功！", "ajaxify_trigger|/oa/form/layoutroottabs?oFormCode=" + oFormCode, IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageGoAnotherPage));
                    }
                }
            }
            else
            {//失败
                if (operateType == "1")
                {
                    return Json(TipHelper.JsonData("保存表单失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
                else
                {
                    return Json(TipHelper.JsonData("提交表单失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
            }
        }

        /// <summary>
        /// 提交主子表页面的表单
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveHeadItem(FormCollection form)
        {
            /*
             * author:hety
             * date:2015-08-14
             * description:
            **/
            bool isSaveSuccess = false;
            string fFormCode = form["fFormCode"];//ERP表单Guid
            string oFormCode = form["oFormCode"];//协同办公表单Guid
            string operateType = form["operateType"];//按钮操作类型，1代表保存，2代表保存并且提交
            string isFreeFlow = form["isFreeFlow"];//是否自由流程，1代表是，0代表否
            string formKey = String.Empty;
            DateTime now = DateTime.Now;

            #region 处理表单头属性值
            int headPropertyCount = 0;//单头属性数量
            List<CommonService.Model.Customer.V_FormPropertyValue> V_FormPropertyValues = new List<CommonService.Model.Customer.V_FormPropertyValue>();
            for (int i = 0; i < form.AllKeys.Length; i++)
            {
                formKey = form.AllKeys[i];
                if (formKey.StartsWith("formproperty_"))
                {//表明为正规自定义表单属性
                    string[] formKeyGroup = formKey.Split('_');
                    if (formKeyGroup.Length == 2)
                    {//代表 普通表单元素(文本框，日期框，单选按钮，下拉框，复选框)
                        CommonService.Model.Customer.V_FormPropertyValue propertyValue = new CommonService.Model.Customer.V_FormPropertyValue();
                        //这里表单属性值Id之所以这么赋值，是因为 UI 中 Form 的"表单元素 name 值"已关联到了表单属性值Id
                        propertyValue.FormPropertyValue_Id = int.Parse(formKeyGroup[1]);
                        propertyValue.FormPropertyValue_Value = form[formKey];
                        V_FormPropertyValues.Add(propertyValue);
                    }
                    else
                    {//代表 其它UI控件

                    }
                    headPropertyCount++;
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

            if (form.AllKeys.Length == (4 + itemGroup.Count + headPropertyCount))
            {
                return Json(TipHelper.JsonData("请您填写明细信息！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
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
                         * 自定义table表单元素属性名称格式："items_"+"父亲属性Id(即普通子表属性)_"+"行索引_"+"属性字段名称_"+"属性id"(如何对应行数据已保存，则还需要+"_属性值Id")
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
                            propertyValue.F_FormPropertyValue_formProperty_id = int.Parse(formPropertyNameGroup[4]);
                            propertyValue.F_FormPropertyValue_BusinessFlowFormCode = new Guid(oFormCode);
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

            isSaveSuccess = _formPropertyValueWCF.SaveOAHeadItemsFormPropertyValue(V_FormPropertyValues, FormPropertyValues, new Guid(fFormCode), new Guid(oFormCode));

            if (isSaveSuccess)
            {//成功
                if (operateType == "1")
                {
                    return Json(TipHelper.JsonData("保存表单成功！", "ajaxify_trigger|/oa/form/layoutroottabs?oFormCode=" + oFormCode, IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageGoAnotherPage));
                }
                else
                {
                    if (isFreeFlow == "1")
                    {//对于自由流程表单,在提交的时候会先打开提交页面
                        return Json(TipHelper.JsonData("保存表单成功！", "atarget_trigger|baseLargeModal|/oa/freeformaudit/createsubmit?oFormCode=" + oFormCode, IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageOpenAnotherPage));
                    }
                    else
                    {//非自由流程表单，提交
                        CommonService.Model.OA.O_Form oForm = _oFormWCF.Get(new Guid(oFormCode));
                        oForm.O_Form_applyPerson = Context.UIContext.Current.UserCode;
                        oForm.O_Form_applyStatus = Convert.ToInt32(FormApplyTypeEnum.已提交);
                        oForm.O_Form_applyTime = DateTime.Now;
                        _oFormWCF.Update(oForm);
                        sendMSG(oFormCode);
                        return Json(TipHelper.JsonData("提交表单成功！", "ajaxify_trigger|/oa/form/layoutroottabs?oFormCode=" + oFormCode, IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageGoAnotherPage));
                    }
                }
            }
            else
            {//失败
                if (operateType == "1")
                {
                    return Json(TipHelper.JsonData("保存表单失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
                else
                {
                    return Json(TipHelper.JsonData("提交表单失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
            }
        }

        /// <summary>
        /// 默认列表Action(菜单超链接打开)
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            InitializationPageParameter();
            return View();
        }

        /// <summary>
        /// 报销借款列表Action(菜单超链接打开)
        /// </summary>
        /// <returns></returns>
        public ActionResult ReimbursementLoanList()
        {
            InitializationPageParameter();
            return View();
        }

        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult AjaxList(jQueryDataTableParamModel param)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //表单查询模型
            CommonService.Model.OA.O_Form oFormConditon = new CommonService.Model.OA.O_Form();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_title");
                if (title != null && title != "")
                {
                    oFormConditon.O_Form_f_form_name = title;
                }
                #endregion
            }
            if (!Context.UIContext.Current.IsPreSetManager)
            {
                oFormConditon.O_Form_creator = new Guid(Context.UIContext.Current.UserCode.ToString());
            }
            //创建人模型
            //oFormConditon.O_Form_creator = Context.UIContext.Current.UserCode;
            #endregion

            #region 分页数据处理

            //总记录数
            this.TotalRecordCount = _oFormWCF.GetRecordCount(oFormConditon);
            //数据信息
            List<CommonService.Model.OA.O_Form> oForms = _oFormWCF.GetListByPage(oFormConditon,
                "O_Form_applyTime Desc", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            //转化数据格式
            var result = from c in oForms
                         select new[] { 
                 c.O_Form_code.Value.ToString(), 
                 c.O_Form_flow==null ? "" : c.O_Form_flow.Value.ToString(), 
                 c.O_Form_f_form_name,
                 c.O_Form_flow_name,
                 c.O_Form_applyPerson_name==null?"": c.O_Form_applyPerson_name,
                 c.O_Form_applyTime==null?"":c.O_Form_applyTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                 c.O_Form_applyStatus_name==null?"":c.O_Form_applyStatus_name 
            };
            //返回json数据
            return Json(
                new
                {
                    sEcho = param.sEcho,
                    iTotalRecords = this.TotalRecordCount,
                    iTotalDisplayRecords = this.TotalRecordCount,
                    aaData = result
                }
            );

            #endregion
        }

        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult AjaxReimbursementLoanList(jQueryDataTableParamModel param)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //表单查询模型
            CommonService.Model.OA.O_Form oFormConditon = new CommonService.Model.OA.O_Form();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_title");
                if (title != null && title != "")
                {
                    oFormConditon.O_Form_f_form_name = title;
                }
                #endregion
            }
            if (!Context.UIContext.Current.IsPreSetManager)
            {
                oFormConditon.O_Form_creator = new Guid(Context.UIContext.Current.UserCode.ToString());
            }
            oFormConditon.O_Form_businessFlowform = Guid.NewGuid();
            //创建人模型
            //oFormConditon.O_Form_creator = Context.UIContext.Current.UserCode;
            #endregion

            #region 分页数据处理

            //总记录数
            this.TotalRecordCount = _oFormWCF.GetRecordCount(oFormConditon);
            //数据信息
            List<CommonService.Model.OA.O_Form> oForms = _oFormWCF.GetListByPage(oFormConditon,
                "O_Form_applyTime Desc", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            //转化数据格式
            var result = from c in oForms
                         select new[] { 
                 c.O_Form_code.Value.ToString(), 
                 c.O_Form_flow==null ? "" : c.O_Form_flow.Value.ToString(), 
                 c.O_Form_f_form_name,
                 c.O_Form_relation_name,
                 c.O_Form_businessFlow_name,
                 c.O_Form_businessFlowform_name,
                 c.O_Form_applyPerson_name==null?"": c.O_Form_applyPerson_name,
                 c.O_Form_applyTime==null?"":c.O_Form_applyTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                 c.O_Form_applyStatus_name==null?"":c.O_Form_applyStatus_name 
            };
            //返回json数据
            return Json(
                new
                {
                    sEcho = param.sEcho,
                    iTotalRecords = this.TotalRecordCount,
                    iTotalDisplayRecords = this.TotalRecordCount,
                    aaData = result
                }
            );

            #endregion
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            CommonService.Model.OA.O_Flow model = new CommonService.Model.OA.O_Flow();
            List<CommonService.Model.OA.O_Flow> flowlist = _flowWCF.GetListByPage(model, "", 0, 1000);
            ViewBag.flowList = flowlist;//所属流程list
            CommonService.Model.CustomerForm.F_Form formConditon = new CommonService.Model.CustomerForm.F_Form();
            formConditon.F_Form_type = Convert.ToInt32(FormTypeEnum.协同办公表单);
            List<CommonService.Model.CustomerForm.F_Form> formslist = _formWCF.GetListByPage(formConditon,
            "F_Form_createTime Desc", 0, 1000);
            ViewBag.formList = formslist;//表单list
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="formCode"></param>
        /// <returns></returns>
        public ActionResult Delete(string formCode)
        {
            if (!string.IsNullOrEmpty(formCode))
            {
                if (_oFormWCF.Delete(new Guid(formCode)))
                {
                    return Json(TipHelper.JsonData("删除表单成功！", "formList", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
                }
                else
                {
                    return Json(TipHelper.JsonData("删除表单失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
            }
            return View();
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
        /// 表单提交，，发送消息
        /// </summary>
        /// <param name="formCode"></param>
        private void sendMSG(string formCode)
        {
            #region  根据审核人所在的预设流程，如果是第一级预设的话，就给第一级预设流程中的所有审核人推送消息
            List<CommonService.Model.OA.O_Form_AuditFlow> flowsetPerList = _oformAuditFlowWCF.GetListByFormCode(new Guid(formCode));//所有的审核人
            var AFset = flowsetPerList.FirstOrDefault(p => p.O_Form_AuditFlow_flowSet_order == 1);
            int a = 1;
            if (AFset.O_Form_AuditFlow_auditStatus == Convert.ToInt32(FormAuditTypeEnum.已通过))
            {        //特殊处理（财务报销和借款的情况下，审核人是自己，那就不需要给自己发送消息，因为默认是通过的,需要给下一级审核人发送消息！）
                a++;
            }
            foreach (var item in flowsetPerList)
            {
                //根据审核人所在的预设流程，如果是第一级预设的话，就给审核人推送消息
                if (item.O_Form_AuditFlow_flowSet_order == a)
                {
                    //先向消息表中添加消息
                    CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                    msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.OA表单消息);
                    msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.OA表单提交);
                    msgModel.C_Messages_link = item.O_Form_AuditFlow_code;
                    msgModel.C_Messages_createTime = DateTime.Now;
                    msgModel.C_Messages_person = item.O_Form_AuditPerson_auditPerson;
                    msgModel.C_Messages_isRead = 0;
                    msgModel.C_Messages_isValidate = 1;
                    _messageWCF.Add(msgModel);
                    //添加消息后  发送给审核人信息
                    CommonService.Model.OA.O_Form_AuditFlow FAFModel = _oformAuditFlowWCF.GetModelByAuditFlowcode(new Guid(item.O_Form_AuditFlow_code.ToString()), 1);//表单未审核审批流程信息
                    if (FAFModel != null)
                    {
                        var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                        var touser = ChatHub.userlist.FirstOrDefault(x => x.userCode == item.O_Form_AuditPerson_auditPerson.ToString());//查询审核人是否在线
                        if (touser != null)
                        {
                            JsonHelper jh = new JsonHelper();
                            context.Clients.Client(touser.ConnectionId).sendFormSubMsg(jh.EntityToJson(FAFModel));//接收消息人的数据集合
                        }
                    }
                }
            }
            #endregion
        }

    }
}