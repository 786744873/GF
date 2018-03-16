using CommonService.Common;
using Context;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.IndividuationForm.Controllers
{
    /// <summary>
    /// 预期收益计算表单(个性化)
    /// </summary>
    public class ExpectProfitFormController : BaseController
    {
        private readonly ICommonService.FlowManager.IP_Business_flow _businessFlowWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow_form _businessFlowFormWCF;
        private readonly ICommonService.CustomerForm.IF_FormPropertyValue _formPropertyValueWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.CaseManager.IB_Case_link _caselinkWCF;
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;
        private readonly ICommonService.IC_Messages _messageWCF;
        private readonly ICommonService.CaseManager.IB_CaseLevelchange _caseLevelChangeWCF;
        private readonly ICommonService.CaseManager.IB_CaseLevelChangeRecords _caseLevelChangeRecordsWCF;
        private readonly ICommonService.CustomerForm.IF_FormCheck _formCheckWCF;
        public ExpectProfitFormController()
        {
            _businessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            _businessFlowFormWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow_form>("Business_flow_formWCF");
            _formPropertyValueWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormPropertyValue>("FormPropertyValueWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _caselinkWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case_link>("Case_linkWCF");
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
            _messageWCF = ServiceProxyFactory.Create<ICommonService.IC_Messages>("MessagesWCF");
            _caseLevelChangeWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_CaseLevelchange>("CaseLevelchangeWCF");
            _caseLevelChangeRecordsWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_CaseLevelChangeRecords>("CaseLevelChangeRecordsWCF");
            _formCheckWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormCheck>("FormCheckWCF");
        }

        //
        // GET: /IndividuationForm/ExpectProfitForm/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 通过Message，打开预期收益表单
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>
        public ActionResult OpenViewByMessage(string businessFlowFormCode)
        {
            string formCode = "128EBF60-F58E-4AE2-B3B7-826DD62A0960";//表单Guid            
            string businessFlowCode = String.Empty;//业务流程Guid
            string fkType = Convert.ToInt32(FlowTypeEnum.案件).ToString(); //流程类型
            string fkCode = String.Empty;//案件guid

            CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm = _businessFlowFormWCF.Get(new Guid(businessFlowFormCode));
            if (businessFlowForm != null)
            {//业务流程guid赋值
                businessFlowCode = businessFlowForm.P_Business_flow_code.Value.ToString();
            }

            if (!String.IsNullOrEmpty(businessFlowCode))
            {//案件guid赋值
                CommonService.Model.FlowManager.P_Business_flow businessFlow = _businessFlowWCF.Get(new Guid(businessFlowCode));
                if (businessFlow != null)
                {
                    fkCode = businessFlow.P_Fk_code.Value.ToString();
                }
            }
            //重新跳转到"生成一个普通编辑界面表单"的地址
            return RedirectToAction("GenerateSingleEidt", "FormPropertyValue", new { area = "CustomerForm", formCode = formCode, businessFlowFormCode = businessFlowFormCode, businessFlowCode = businessFlowCode, fkType = fkType, pkCode = fkCode ,isView=1});
        }

        /// <summary>
        /// 提交预期收益表单信息
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveEditInfo(FormCollection form)
        {
            bool isSaveSuccess = false;
            string formOperateType = form["formOperateType"];//表单操作类型(根据不同的操作类型，对不同的属性值进行数据库更新)
            Guid businessFlowCode = new Guid(form["businessFlowCode"]);
            Guid businessFlowFormCode = new Guid(form["businessFlowFormCode"]);//业务流程表单关联Guid
            Guid caseCode = this.GetCaseCode(businessFlowCode);//关联案件Guid
            string fkType = form["fkType"];
            string formKey = String.Empty;

            bool isFirstZygwSave = true;//是否为首次专业顾问审核，如果为首次，需要发送消息
            bool isFirstZhzxSave = true;//是否为首次指挥中心(也为专家部长)裁定，如果为首次，需要发送消息
            bool isFirstCwSave = true;//是否为首次财务裁定，如果为首次，需要发送消息
            bool isFirstSxzjSave = true;//是否为首次首席专家裁定，如果为首次，需要发送消息

            //处理Form表单属性
            List<CommonService.Model.Customer.V_FormPropertyValue> V_FormPropertyValues = new List<CommonService.Model.Customer.V_FormPropertyValue>();
            for (int i = 0; i < form.AllKeys.Length; i++)
            {
                formKey = form.AllKeys[i];
                if (formKey.Contains("formproperty_"))
                {//表明为正规自定义表单属性
                    string[] formKeyGroup = formKey.Split('_');

                    #region 根据不同的表单操作类型，对不同的属性值进行数据库更新
                    if (formOperateType.ToLower() == "onlysave")
                    {//专业顾问元素、指挥中心元素、财务元素不进行数据库保存
                        //专业顾问元素
                        if (formKeyGroup[2].ToLower() == "28105e12-c30c-4128-9076-622677affe9f" || formKeyGroup[2].ToLower() == "f05bdb72-4a70-46e3-8f6c-f5b1b9023169"
                            || formKeyGroup[2].ToLower() == "e8db6dc3-e19c-49a0-9982-bb20765f5d02" || formKeyGroup[2].ToLower() == "a191678e-d8e2-4cee-b163-2679e88a3d89"
                            || formKeyGroup[2].ToLower() == "df183515-eedd-452d-a519-a1b2acf6e542")
                        {
                            continue;
                        }
                        //指挥中心元素
                        if (formKeyGroup[2].ToLower() == "7b13ca2b-1b19-44cd-8259-d9c473a4d06c" || formKeyGroup[2].ToLower() == "06e7d142-b5bb-4115-8329-89f3d85dd3ca"
                            || formKeyGroup[2].ToLower() == "ed4a185a-76dc-4dd3-bcf1-d6000cd8bf64" || formKeyGroup[2].ToLower() == "ab21dc0e-5ad0-4959-9410-611dde6a7d99")
                        {
                            continue;
                        }
                        //财务元素
                        if (formKeyGroup[2].ToLower() == "1f5a41eb-ed9b-4753-84b9-8277d8eaf8c4" || formKeyGroup[2].ToLower() == "1f810b74-6a31-47db-83eb-a56d880fd3b7"
                          || formKeyGroup[2].ToLower() == "6b6bcb4e-7b3a-4cf9-bb5d-37f4a576d752")
                        {
                            continue;
                        }
                        //首席专家元素
                        if (formKeyGroup[2].ToLower() == "6cda7b58-b098-4597-8847-14d2de3d2956" || formKeyGroup[2].ToLower() == "9367c08b-bbe0-4bca-ae6a-82123419e9ae"
                            || formKeyGroup[2].ToLower() == "e16ec45b-e0e6-40cc-8f8d-1fcad9d54cab" || formKeyGroup[2].ToLower() == "74cf159b-d291-4e18-a8f9-ac96b4cde904")
                        {
                            continue;
                        }
                    }
                    else if (formOperateType.ToLower() == "zygwsave")
                    {//只进行专业顾问元素数据库保存
                        if (formKeyGroup[2].ToLower() == "28105e12-c30c-4128-9076-622677affe9f" || formKeyGroup[2].ToLower() == "f05bdb72-4a70-46e3-8f6c-f5b1b9023169"
                            || formKeyGroup[2].ToLower() == "e8db6dc3-e19c-49a0-9982-bb20765f5d02" || formKeyGroup[2].ToLower() == "a191678e-d8e2-4cee-b163-2679e88a3d89"
                            || formKeyGroup[2].ToLower() == "df183515-eedd-452d-a519-a1b2acf6e542")
                        {                         
                            //处理专业顾问审核人，审核时间
                            if (formKeyGroup[2].ToLower() == "a191678e-d8e2-4cee-b163-2679e88a3d89")
                            {//审核人
                                form[formKey] = UIContext.Current.UserCode.ToString();
                            }
                            if (formKeyGroup[2].ToLower() == "df183515-eedd-452d-a519-a1b2acf6e542")
                            {//审核时间
                                form[formKey] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            }

                            if (isFirstZygwSave)
                            {
                                //发送待审核的消息
                                this.SendUnCheckedMessageToZhzx(caseCode);
                            }
                            isFirstZygwSave = false;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (formOperateType.ToLower() == "zhzxsave")
                    {//只进行指挥中心元素数据库保存
                        if (formKeyGroup[2].ToLower() == "7b13ca2b-1b19-44cd-8259-d9c473a4d06c" || formKeyGroup[2].ToLower() == "06e7d142-b5bb-4115-8329-89f3d85dd3ca"
                            || formKeyGroup[2].ToLower() == "ed4a185a-76dc-4dd3-bcf1-d6000cd8bf64" || formKeyGroup[2].ToLower() == "ab21dc0e-5ad0-4959-9410-611dde6a7d99")
                        {
                            //处理指挥中心审核人，审核时间
                            if (formKeyGroup[2].ToLower() == "ed4a185a-76dc-4dd3-bcf1-d6000cd8bf64")
                            {//审核人
                                form[formKey] = UIContext.Current.UserCode.ToString();
                            }
                            if (formKeyGroup[2].ToLower() == "ab21dc0e-5ad0-4959-9410-611dde6a7d99")
                            {//审核时间
                                form[formKey] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            }

                            if (isFirstZhzxSave)
                            {
                                //发送审核通过的消息
                                this.SendCheckedPassMessageToLawer(caseCode, businessFlowFormCode);
                                this.SendCheckedPassMessageToZygw(caseCode);
                                //给财务发送需要"复核"的消息
                                this.SendMessageToFinance(caseCode, businessFlowFormCode);
                            }
                            isFirstZhzxSave = false;
 
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (formOperateType.ToLower() == "cwsave")
                    {//只进行财务元素数据库保存
                        if (formKeyGroup[2].ToLower() == "1f5a41eb-ed9b-4753-84b9-8277d8eaf8c4" || formKeyGroup[2].ToLower() == "1f810b74-6a31-47db-83eb-a56d880fd3b7"
                            || formKeyGroup[2].ToLower() == "6b6bcb4e-7b3a-4cf9-bb5d-37f4a576d752")
                        {
                            //处理财务审核人，审核时间
                            if (formKeyGroup[2].ToLower() == "1f5a41eb-ed9b-4753-84b9-8277d8eaf8c4")
                            {//审核人
                                form[formKey] = UIContext.Current.UserCode.ToString();
                            }
                            if (formKeyGroup[2].ToLower() == "1f810b74-6a31-47db-83eb-a56d880fd3b7")
                            {//审核时间
                                form[formKey] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            }

                            if (isFirstCwSave)
                            {
                                //发送审核通过的消息
                                this.SendCheckedPassMessageToLawer(caseCode, businessFlowFormCode);
                                this.SendCheckedPassMessageToZygw(caseCode);
                                this.SendCheckedPassMessageToZhzx(caseCode);
                            }
                            isFirstCwSave = false;

                            //在财务裁定金额(预期收益金额)>=100000.00时，需要发送待审核消息给首席专家
                            if (formKeyGroup[2].ToLower() == "6b6bcb4e-7b3a-4cf9-bb5d-37f4a576d752")
                            {
                                decimal yuqishouyiMoney = 0.00M;
                                if (decimal.TryParse(form[formKey], out yuqishouyiMoney))
                                {
                                    if (yuqishouyiMoney >= 100000.00M)
                                    {
                                        this.SendUnCheckedMessageToSxzj(caseCode);
                                    }
                                    else
                                    {//更改案件预期收益金额
                                        _caseWCF.UpdateExpectedGrant(caseCode, yuqishouyiMoney);
                                        _formCheckWCF.IndividuationCheckForm(businessFlowFormCode,Context.UIContext.Current.UserCode.Value);
                                        //this.SendMessageToFinance(caseCode, businessFlowFormCode);
                                    }
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (formOperateType.ToLower() == "sxzjsave")
                    {//只进行首席专家元素数据库保存
                        if (formKeyGroup[2].ToLower() == "6cda7b58-b098-4597-8847-14d2de3d2956" || formKeyGroup[2].ToLower() == "9367c08b-bbe0-4bca-ae6a-82123419e9ae"
                           || formKeyGroup[2].ToLower() == "e16ec45b-e0e6-40cc-8f8d-1fcad9d54cab" || formKeyGroup[2].ToLower() == "74cf159b-d291-4e18-a8f9-ac96b4cde904"
                           )
                        {
                            //处理首席专家审核人，审核时间
                            if (formKeyGroup[2].ToLower() == "6cda7b58-b098-4597-8847-14d2de3d2956")
                            {//审核人
                                form[formKey] = UIContext.Current.UserCode.ToString();
                            }
                            if (formKeyGroup[2].ToLower() == "9367c08b-bbe0-4bca-ae6a-82123419e9ae")
                            {//审核时间
                                form[formKey] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            }

                            if (isFirstSxzjSave)
                            {
                                //发送审核通过的消息
                                this.SendCheckedPassMessageToLawer(caseCode, businessFlowFormCode);
                                this.SendCheckedPassMessageToZygw(caseCode);
                                this.SendCheckedPassMessageToZhzx(caseCode);
                                this.SendMessageToFinance(caseCode,businessFlowFormCode);
                            }
                            isFirstSxzjSave = false;
                            //更改案件预期收益金额
                            if (formKeyGroup[2].ToLower() == "e16ec45b-e0e6-40cc-8f8d-1fcad9d54cab")
                            {
                                decimal yuqishouyiMoney = 0.00M;
                                if (decimal.TryParse(form[formKey], out yuqishouyiMoney))
                                {
                                    if (yuqishouyiMoney >= 200000.00M)
                                    {
                                        bool IsMajorAdjustment = _caseLevelChangeWCF.IsHardToAdjust(caseCode, Convert.ToInt32(CaseLevelEnum.大案));//案件是否进行大案调整
                                        if(!IsMajorAdjustment)
                                        {
                                            #region 变更记录表中插入数据
                                            CommonService.Model.CaseManager.B_CaseLevelChangeRecords caseLevelChangeRecords = new CommonService.Model.CaseManager.B_CaseLevelChangeRecords();
                                            caseLevelChangeRecords.B_CaseLevelChangeRecords_code = Guid.NewGuid();
                                            caseLevelChangeRecords.B_Case_code = caseCode;
                                            caseLevelChangeRecords.B_CaseLevelChangeRecords_type = Convert.ToInt32(CaseLevelChangeRecordTypeEnum.自动);
                                            caseLevelChangeRecords.B_CaseLevelChangeRecords_applicationData = DateTime.Now;
                                            caseLevelChangeRecords.B_CaseLevelChangeRecords_actualChangeDate = DateTime.Now;
                                            caseLevelChangeRecords.B_CaseLevelChangeRecords_createTime = DateTime.Now;
                                            caseLevelChangeRecords.B_CaseLevelChangeRecords_isDelete = false;
                                            caseLevelChangeRecords.B_CaseLevelChangeRecords_isAudit = true;
                                            string yqsyMoneyStr = (yuqishouyiMoney / 10000).ToString()+"W";
                                            caseLevelChangeRecords.B_CaseLevelChangeRecords_conversionReasons = "预期收益" + yqsyMoneyStr + ">20W，转为‘大案’";

                                            _caseLevelChangeRecordsWCF.Add(caseLevelChangeRecords);
                                            #endregion

                                            #region 案件级别变更表插入数据
                                            CommonService.Model.CaseManager.B_CaseLevelchange caseLevelChange = new CommonService.Model.CaseManager.B_CaseLevelchange();
                                            caseLevelChange.B_CaseLevelchange_code = Guid.NewGuid();
                                            caseLevelChange.B_Case_code = caseCode;
                                            caseLevelChange.B_CaseLevelchange_type = Convert.ToInt32(CaseLevelEnum.大案);
                                            caseLevelChange.B_CaseLevelchange_changeRecord = caseLevelChangeRecords.B_CaseLevelChangeRecords_code.Value;
                                            caseLevelChange.B_CaseLevelchange_state = Convert.ToInt32(CaseLevelChangeStateEnum.通过);
                                            caseLevelChange.B_CaseLevelchange_IsValid = true;
                                            caseLevelChange.B_CaseLevelchange_createTime = DateTime.Now;
                                            caseLevelChange.B_CaseLevelchange_isDelete = false;

                                            _caseLevelChangeWCF.Add(caseLevelChange);
                                            #endregion
                                        }
                                    }
                                    _caseWCF.UpdateExpectedGrant(caseCode, yuqishouyiMoney);
                                    _formCheckWCF.IndividuationCheckForm(businessFlowFormCode, Context.UIContext.Current.UserCode.Value);
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    #endregion

                    #region 表单自定义属性值处理

                    if (formKeyGroup.Length == 3)
                    {//代表 普通表单元素(文本框，日期框，单选按钮，下拉框)
                        CommonService.Model.Customer.V_FormPropertyValue propertyValue = new CommonService.Model.Customer.V_FormPropertyValue();
                        //这里表单属性值Guid之所以这么赋值，是因为 UI 中 Form 的"表单元素 name 值"已关联到了表单属性值Guid
                        propertyValue.FormPropertyValue_Code = new Guid(formKeyGroup[1]);
                        propertyValue.FormPropertyValue_Value = form[formKey];
                        V_FormPropertyValues.Add(propertyValue);
                    }

                    #endregion

                }
            }

            isSaveSuccess = _formPropertyValueWCF.UpdateFormPropertyValueByPropertyCode(V_FormPropertyValues);

            if (isSaveSuccess)
            {
                if (formOperateType.ToLower() == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTip));//仅仅保存
                }
                else
                {
                    return Json(TipHelper.JsonData("审核信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));//审核
                }
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 生成审核人
        /// </summary>
        /// <param name="userCode">审核人Guid</param>
        /// <returns></returns>
        public string GenerateAuditPerson(string userCode)
        {
            string auditPerson = String.Empty;
            if (!String.IsNullOrEmpty(userCode))
            {
                CommonService.Model.SysManager.C_Userinfo user = _userinfoWCF.GetUserinfoByCode(new Guid(userCode));
                if (user != null)
                {
                    auditPerson = user.C_Userinfo_name;
                }
            }

            if (String.IsNullOrEmpty(auditPerson))
            {//如果没有审核人，则默认当前登录人
                auditPerson = UIContext.Current.UserName;
            }

            return auditPerson;
        }

        /// <summary>
        /// 根据业务流程Guid，获取关联案件Guid
        /// </summary>
        /// <param name="businessFlowCode">业务流程GUid</param>
        /// <returns></returns>
        private Guid GetCaseCode(Guid businessFlowCode)
        {
            Guid caseCode = Guid.Empty;

            CommonService.Model.FlowManager.P_Business_flow businessFlow = _businessFlowWCF.Get(businessFlowCode);
            if (businessFlow != null)
            {
                caseCode = businessFlow.P_Fk_code.Value;
            }

            return caseCode;
        }

        /// <summary>
        /// 给专业顾问发消息(审核通过)
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        private void SendCheckedPassMessageToZygw(Guid caseCode)
        {
            DateTime now = DateTime.Now;
            List<CommonService.Model.CaseManager.B_Case_link> caseLinks = _caselinkWCF.GetCaseLinksByCaseAndType(caseCode, Convert.ToInt32(CaselinkEnum.销售顾问));
            foreach (CommonService.Model.CaseManager.B_Case_link caseLink in caseLinks)
            {
                CommonService.Model.C_Messages message = new CommonService.Model.C_Messages();
                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                message.C_Messages_link = caseCode;
                message.C_Messages_createTime = now;
                message.C_Messages_person = caseLink.C_FK_code;
                message.C_Messages_isRead = 0;
                message.C_Messages_content = "";
                message.C_Messages_isValidate = 1;

                _messageWCF.Add(message);
            }
        }

        /// <summary>
        /// 给指挥中心(专家顾问)发消息(审核通过)
        /// </summary>
        /// <returns>案件Guid</returns>
        private void SendCheckedPassMessageToZhzx(Guid caseCode)
        {
            DateTime now = DateTime.Now;
            CommonService.Model.CaseManager.B_Case bCase = _caseWCF.GetModel(caseCode);
            if (bCase != null)
            {             
                CommonService.Model.C_Messages message = new CommonService.Model.C_Messages();
                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                message.C_Messages_link = caseCode;
                message.C_Messages_createTime = now;
                message.C_Messages_person = bCase.B_Case_person;
                message.C_Messages_isRead = 0;
                message.C_Messages_content = "";
                message.C_Messages_isValidate = 1;

                _messageWCF.Add(message);
            }
        }

        /// <summary>
        /// 给表单主办律师法消息(审核通过)
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        private void SendCheckedPassMessageToLawer(Guid caseCode, Guid businessFlowFormCode)
        {
            DateTime now = DateTime.Now;
            CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm = _businessFlowFormWCF.Get(businessFlowFormCode);
            if (businessFlowForm != null)
            {
                CommonService.Model.C_Messages message = new CommonService.Model.C_Messages();
                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.审核通过);
                message.C_Messages_link = caseCode;
                message.C_Messages_createTime = now;
                message.C_Messages_person = businessFlowForm.P_Business_flow_form_person;
                message.C_Messages_isRead = 0;
                message.C_Messages_content = "";
                message.C_Messages_isValidate = 1;

                _messageWCF.Add(message);
            }
        }

        /// <summary>
        /// 给指挥中心(专家顾问)发消息(待审核)
        /// </summary>
        /// <returns>案件Guid</returns>
        private void SendUnCheckedMessageToZhzx(Guid caseCode)
        {
            DateTime now = DateTime.Now;
            CommonService.Model.CaseManager.B_Case bCase = _caseWCF.GetModel(caseCode);
            if (bCase != null)
            {
                CommonService.Model.C_Messages message = new CommonService.Model.C_Messages();
                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                message.C_Messages_link = caseCode;
                message.C_Messages_createTime = now;
                message.C_Messages_person = bCase.B_Case_person;
                message.C_Messages_isRead = 0;
                message.C_Messages_content = "";
                message.C_Messages_isValidate = 1;

                _messageWCF.Add(message);
            }
        }


        /// <summary>
        /// 给首席专家发消息(待审核)
        /// </summary>
        /// <returns>案件Guid</returns>
        private void SendUnCheckedMessageToSxzj(Guid caseCode)
        {
            DateTime now = DateTime.Now;
            CommonService.Model.CaseManager.B_Case bCase = _caseWCF.GetModel(caseCode);
            if (bCase != null)
            {
                CommonService.Model.C_Messages message = new CommonService.Model.C_Messages();
                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.案件);
                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.表单审核);
                message.C_Messages_link = caseCode;
                message.C_Messages_createTime = now;
                message.C_Messages_person = bCase.B_Case_firstClassResponsiblePerson;
                message.C_Messages_isRead = 0;
                message.C_Messages_content = "";
                message.C_Messages_isValidate = 1;

                _messageWCF.Add(message);
            }
        }

        /// <summary>
        /// 发送消息给财务
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        private void SendMessageToFinance(Guid caseCode, Guid businessFlowFormCode)
        {
            DateTime now = DateTime.Now;
            List<CommonService.Model.SysManager.C_Userinfo> users = _userinfoWCF.GetPowerUsersByCase(caseCode);
            foreach (CommonService.Model.SysManager.C_Userinfo user in users)
            {
                CommonService.Model.C_Messages message = new CommonService.Model.C_Messages();
                message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.财务消息);
                message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.预期收益);
                message.C_Messages_link = businessFlowFormCode;
                message.C_Messages_createTime = now;
                message.C_Messages_person = user.C_Userinfo_code;
                message.C_Messages_isRead = 0;
                message.C_Messages_content = "";
                message.C_Messages_isValidate = 1;

                _messageWCF.Add(message);
            }
        }


    }
}