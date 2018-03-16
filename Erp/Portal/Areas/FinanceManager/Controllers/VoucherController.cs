using CommonService.Common;
using Context;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.FinanceManager.Controllers
{
    public class VoucherController : BaseController
    {
        private readonly ICommonService.FinanceManager.IC_Voucher _voucherWCF;
        private readonly ICommonService.FinanceManager.IC_Voucher_Form _voucherFormWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.CustomerForm.IF_FormProperty _formPropertyWCF;
        private readonly ICommonService.CustomerForm.IF_FormPropertyValue _formPropertyValueWCF;
        private readonly ICommonService.SysManager.IC_Organization _organizationWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;
        private readonly ICommonService.BusinessChanceManager.IB_BusinessChance _businessChanceWCF;
        CommonService.Common.RMBCapitalization rmbCapitalization = new CommonService.Common.RMBCapitalization();
        private readonly ICommonService.SysManager.IC_Role_Role_Power _roleRolePower;

        public VoucherController()
        {
            #region 服务初始化
            _voucherWCF = ServiceProxyFactory.Create<ICommonService.FinanceManager.IC_Voucher>("VoucherWCF");
            _voucherFormWCF = ServiceProxyFactory.Create<ICommonService.FinanceManager.IC_Voucher_Form>("Voucher_FormWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _formPropertyWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormProperty>("FormPropertyWCF");
            _formPropertyValueWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormPropertyValue>("FormPropertyValueWCF");
            _organizationWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization>("OrganizationWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
            _businessChanceWCF = ServiceProxyFactory.Create<ICommonService.BusinessChanceManager.IB_BusinessChance>("BusinessChanceWCF");
            _roleRolePower = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Role_Role_Power>("Role_Role_PowerWCF");
            #endregion
        }
        //
        // GET: /FinanceManager/Voucher/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form,int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.FinanceManager.C_Voucher Conditon = new CommonService.Model.FinanceManager.C_Voucher();
            //条件
            if (!UIContext.Current.IsPreSetManager)
            {
                Conditon.C_Voucher_applicationPerson = Context.UIContext.Current.UserCode;
            }
            if (!String.IsNullOrEmpty(form["C_Voucher_applicationPersonName"]))
            {//申请人名称查询条件
                Conditon.C_Voucher_applicationPersonName = form["C_Voucher_applicationPersonName"];
            }
            if (!String.IsNullOrEmpty(form["C_Voucher_applicationTime"]) && !String.IsNullOrEmpty(form["C_Voucher_applicationTime1"]))
            {//申请时间
                Conditon.C_Voucher_applicationTime = Convert.ToDateTime(form["C_Voucher_applicationTime"]);
                Conditon.C_Voucher_applicationTime1 = Convert.ToDateTime(form["C_Voucher_applicationTime1"]);
            }
            if (!String.IsNullOrEmpty(form["C_Voucher_amounts"]) && !String.IsNullOrEmpty(form["C_Voucher_amounts1"]))
            {//金额
                Conditon.C_Voucher_amounts =Convert.ToDecimal(form["C_Voucher_amounts"].Trim());
                Conditon.C_Voucher_amounts1 = Convert.ToDecimal(form["C_Voucher_amounts1"].Trim());
            }
            if (!String.IsNullOrEmpty(form["C_Voucher_number"]))
            {//编号
                Conditon.C_Voucher_number = form["C_Voucher_number"].Trim();
            }
            if (!String.IsNullOrEmpty(form["C_Voucher_FeeLoanOrFeeReimbursementNumber"]))
            {//借款/报销编号
                Conditon.C_Voucher_FeeLoanOrFeeReimbursementNumber = form["C_Voucher_FeeLoanOrFeeReimbursementNumber"].Trim();
            }
            if (!String.IsNullOrEmpty(form["C_Voucher_confirmTime"]) && !String.IsNullOrEmpty(form["C_Voucher_confirmTime1"]))
            {//确认时间
                Conditon.C_Voucher_confirmTime = Convert.ToDateTime(form["C_Voucher_confirmTime"]);
                Conditon.C_Voucher_confirmTime1 = Convert.ToDateTime(form["C_Voucher_confirmTime1"]);
            }
            if (!String.IsNullOrEmpty(form["C_Voucher_CaseNumber"]))
            {//案号
                Conditon.C_Voucher_CaseNumber = form["C_Voucher_CaseNumber"].Trim();
            }
            if (!String.IsNullOrEmpty(form["C_Voucher_CaseName"]))
            {//案件名称
                Conditon.C_Voucher_CaseName = form["C_Voucher_CaseName"].Trim();
            }
            if (!UIContext.Current.IsPreSetManager)
            {
                Conditon.C_Voucher_applicationPerson = UIContext.Current.UserCode;
            }
            //查询模型传递到前端视图中
            ViewBag.Conditon = Conditon;

            #endregion

            string rolePowerIds=GetRolePowers();
            //ERP的查询条件
            Conditon.C_Voucher_type = 1;
            //获取总记录数
            this.TotalRecordCount = _voucherWCF.GetRecordCount(Conditon, rolePowerIds);
            this.PageSize = 17;

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取数据信息
            List<CommonService.Model.FinanceManager.C_Voucher> voucher = _voucherWCF.GetListByPage(Conditon, rolePowerIds,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(voucher);
        }

        /// <summary>
        /// 还原单
        /// </summary>
        /// <param name="voucherCode"></param>
        /// <returns></returns>
        public ActionResult RestoreOrder(FormCollection form,string voucherCode,int? page=1)
        {
            CommonService.Model.FinanceManager.C_Voucher voucher = _voucherWCF.GetModel(new Guid(voucherCode));
            this.AddressUrlParameters = "?voucherCode=" + voucherCode;
            List<CommonService.Model.FinanceManager.C_Voucher_Form> voucherFormList = _voucherFormWCF.GetListByVoucherCode(new Guid(voucherCode));

            List<CommonService.Model.CaseManager.B_Case> caseList = _caseWCF.GetModelList(string.Empty);
            ViewBag.caseList = caseList;
            if (voucher.C_Voucher_documentType == Convert.ToInt32(DocumentTypeEnum.报销))
            {
                InitializationPageParameter();

                #region 查询拼接条件设置,查询条件根据实际业务进行相应更改)

                string formCode = "4B483102-0B05-418A-ACC0-41313D5D083E";//费用报销单Guid(固定值)
                string condition = "1=1 ";//查询条件

                string formPropertyValueGroupStr = "";
                foreach(CommonService.Model.FinanceManager.C_Voucher_Form voucherForm in voucherFormList)
                {
                    formPropertyValueGroupStr += "'" + voucherForm.F_Form_code+ "',";
                }
                if (!String.IsNullOrEmpty(formPropertyValueGroupStr))
                {
                    formPropertyValueGroupStr = formPropertyValueGroupStr.Substring(0, formPropertyValueGroupStr.Length - 1);
                }
                condition += "and formPropertyValueGroup in (" + formPropertyValueGroupStr + ")";
                
                #endregion


                //获取表单明细属性
                List<CommonService.Model.CustomerForm.F_FormProperty> itemFormPropertys = _formPropertyWCF.GetList(new Guid(formCode));

                this.TotalRecordCount = _formPropertyValueWCF.DynamicLoadFeeFormListCount(new Guid(formCode), condition);
                this.PageSize = 10;
                //初始化页面信息(固定写法)
                this.InitializationPageInfo(form, page.Value);

                //获取表单明细属性值
                DataSet itemFormPropertyValues = _formPropertyValueWCF.DynamicLoadFeeFormListValues(new Guid(formCode), (this.ThisPageIndex - 1) * this.PageSize + 1,
                    this.ThisPageIndex * this.PageSize, condition);
                ViewBag.DynamicItemFormPropertyValues = itemFormPropertyValues;

                return View(itemFormPropertys);
            }else
            {
                InitializationPageParameter();

                #region 查询拼接条件设置,查询条件根据实际业务进行相应更改)

                string formCode = "373A0905-5797-41E0-BB6A-BBC53990B835";//费用借款单Guid(固定值)
                string condition = "1=1 ";//查询条件

                string formPropertyValueGroupStr = "";
                foreach (CommonService.Model.FinanceManager.C_Voucher_Form voucherForm in voucherFormList)
                {
                    formPropertyValueGroupStr += "'" + voucherForm.F_Form_code + "',";
                }
                if (!String.IsNullOrEmpty(formPropertyValueGroupStr))
                {
                    formPropertyValueGroupStr = formPropertyValueGroupStr.Substring(0, formPropertyValueGroupStr.Length - 1);
                }
                condition += "and formPropertyValueGroup in (" + formPropertyValueGroupStr + ")";

                #endregion


                //获取表单明细属性
                List<CommonService.Model.CustomerForm.F_FormProperty> itemFormPropertys = _formPropertyWCF.GetList(new Guid(formCode));

                this.TotalRecordCount = _formPropertyValueWCF.DynamicLoadFeeFormListCount(new Guid(formCode), condition);
                this.PageSize = 10;
                //初始化页面信息(固定写法)
                this.InitializationPageInfo(form, page.Value);

                //获取表单明细属性值
                DataSet itemFormPropertyValues = _formPropertyValueWCF.DynamicLoadFeeFormListValues(new Guid(formCode), (this.ThisPageIndex - 1) * this.PageSize + 1,
                    this.ThisPageIndex * this.PageSize, condition);
                ViewBag.DynamicItemFormPropertyValues = itemFormPropertyValues;

                return View(itemFormPropertys);
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="voucherCode"></param>
        /// <returns></returns>
        public ActionResult GeneratingDocuments(string voucherCode)
        {
            //List<CommonService.Model.CustomerForm.F_FormPropertyValue> formpropertyValues = _formPropertyValueWCF.GetListByFormPropertyValueGroup(new Guid(formPropertyValueGroup));

            CommonService.Model.FinanceManager.C_Voucher voucher = _voucherWCF.GetModel(new Guid(voucherCode));
            ViewBag.voucher = voucher;
            string formCode = "4B483102-0B05-418A-ACC0-41313D5D083E";//费用报销单Guid(固定值)
            if(voucher.C_Voucher_documentType==Convert.ToInt32(DocumentTypeEnum.借款))
            {
                formCode = "373A0905-5797-41E0-BB6A-BBC53990B835";
            }
            
            string condition = "1=1 ";
            DataSet itemFormPropertyValue = null;
            List<CommonService.Model.FinanceManager.C_Voucher_Form> voucherFormList = _voucherFormWCF.GetListByVoucherCode(new Guid(voucherCode));

            string formPropertyValueGroupStr = "";
            foreach (var voucherForm in voucherFormList)
            {
                formPropertyValueGroupStr += "'" + voucherForm.F_Form_code + "',";
            }
            if (formPropertyValueGroupStr != "")
            {
                formPropertyValueGroupStr = formPropertyValueGroupStr.Substring(0, formPropertyValueGroupStr.Length - 1);
                condition += "and formPropertyValueGroup in (" + formPropertyValueGroupStr + ")";

                itemFormPropertyValue = _formPropertyValueWCF.DynamicLoadFeeFormListValues(new Guid(formCode), 1,
                10000, condition);
            }

            DataTable dt = itemFormPropertyValue.Tables[0];

            Guid applyPerson = Guid.Empty;
            if (!String.IsNullOrEmpty(dt.Rows[0]["O_Form_applyPerson"].ToString()))
            {
                applyPerson = new Guid(dt.Rows[0]["O_Form_applyPerson"].ToString());
            }
            CommonService.Model.SysManager.C_Userinfo userinfo = _userinfoWCF.GetModelByUserCode(applyPerson);
            ViewBag.userinfo = userinfo;
            //发票种类参数集合
            List<CommonService.Model.C_Parameters> InvoiceType1 = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFormEnum.费用类型));
            List<CommonService.Model.C_Parameters> InvoiceType2 = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFormEnum.垫付款类型));
            List<CommonService.Model.C_Parameters> InvoiceType = InvoiceType1.Concat(InvoiceType2).ToList();
            //摘要
            List<CommonService.Model.Customer.V_Abstract> abstractList = new List<CommonService.Model.Customer.V_Abstract>();
            List<string> caseArrayList = new List<string>();
            Decimal TotalAmount = 0;
            DateTime? applyTime = null;
            string manager = "";
            foreach (DataRow dr in dt.Rows)
            {
                CommonService.Model.FlowManager.P_Business_flow businessFlow = new CommonService.Model.FlowManager.P_Business_flow();
                string number = "";
                if (!String.IsNullOrEmpty(dr["P_Business_flow_code"].ToString()))
                {
                    businessFlow = _bussinessFlowWCF.Get(new Guid(dr["P_Business_flow_code"].ToString()));
                    CommonService.Model.CaseManager.B_Case bcase = _caseWCF.GetModel(businessFlow.P_Fk_code.Value);
                    if (bcase != null)
                    {
                        number = bcase.B_Case_number;
                        if (bcase.B_Case_person != null)
                        {
                            manager = _userinfoWCF.GetModelByUserCode(bcase.B_Case_person.Value).C_Userinfo_name;
                        }
                    }
                    else
                    {
                        CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(businessFlow.P_Fk_code.Value);
                        number = businessChance.B_BusinessChance_number;
                        manager = businessChance.B_Businesschance_personName;
                    }
                }
                CommonService.Model.C_Parameters parameter = new CommonService.Model.C_Parameters();
                string InvoiceValue = "";
                if (voucher.C_Voucher_documentType == Convert.ToInt32(DocumentTypeEnum.报销))
                {
                    parameter = InvoiceType.Where(p => p.C_Parameters_id == Convert.ToInt32(dr["801E7FA0-F768-478A-BA73-C418F0D763CF"])).FirstOrDefault();
                    InvoiceValue = dr["B03DAD36-EF37-44E1-8F58-2CB1F2B716F5"].ToString();
                }else
                {
                    parameter = InvoiceType.Where(p => p.C_Parameters_id == Convert.ToInt32(dr["B4C29E0B-524C-44A7-8FC6-5CCB91796003"])).FirstOrDefault();
                    InvoiceValue = dr["90AF36AE-AC98-4503-8F76-B43FDDE07CD7"].ToString();
                }
                CommonService.Model.Customer.V_Abstract vabstract = new CommonService.Model.Customer.V_Abstract();
                vabstract.Number = number;
                vabstract.InvoiceType = parameter.C_Parameters_name;
                vabstract.InvoiceValue = Convert.ToDecimal(InvoiceValue);
                CommonService.Model.Customer.V_Abstract v_abstract = abstractList.Where(a => a.Number == vabstract.Number).FirstOrDefault();
                if (v_abstract != null)
                {
                    if (v_abstract.InvoiceType == vabstract.InvoiceType)
                    {
                        v_abstract.InvoiceValue = v_abstract.InvoiceValue + vabstract.InvoiceValue;
                        int i = abstractList.FindIndex(a => a.Number == v_abstract.Number);
                        abstractList[i].InvoiceValue = v_abstract.InvoiceValue;
                    }
                    else
                    {
                        abstractList.Add(vabstract);
                    }
                }
                else
                {
                    abstractList.Add(vabstract);
                }
                //caseArrayList.Add(number + "：" + parameter.C_Parameters_name + "：" + InvoiceValue);
                TotalAmount += Convert.ToDecimal(InvoiceValue);
                if (dr["O_Form_applyTime"].ToString() != "")
                {
                    applyTime = Convert.ToDateTime(dr["O_Form_applyTime"]);
                }
            }
            string TotalAmountToUppercaseAmount = rmbCapitalization.RMBAmount(Convert.ToDouble(TotalAmount));
            ViewBag.TotalAmount = TotalAmount;
            ViewBag.TotalAmountToUppercaseAmount = TotalAmountToUppercaseAmount;
            string abstractStr;
            foreach (CommonService.Model.Customer.V_Abstract abstractItem in abstractList)
            {
                List<CommonService.Model.Customer.V_Abstract> items = abstractList.Where(a => a.Number == abstractItem.Number).ToList();
                abstractStr = abstractItem.Number + "：";
                string abstracts = "";
                foreach (CommonService.Model.Customer.V_Abstract item in items)
                {
                    abstracts += item.InvoiceType + "：" + item.InvoiceValue + "  ";
                }
                abstractStr = abstractStr + abstracts;
                if (!caseArrayList.Contains(abstractStr))
                {
                    caseArrayList.Add(abstractStr);
                }
            }
            ViewBag.caseArrayList = caseArrayList;
            ViewBag.applyTime = applyTime;
            ViewBag.Manager = manager;
            ViewBag.regionName = voucher.C_Voucher_regionName;
            ViewBag.DynamicItemFormPropertyValue = itemFormPropertyValue;
            return View();
        }

        /// <summary>
        /// 确认付款
        /// </summary>
        /// <param name="voucherCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ConfirmationOfPayment(string voucherCode)
        {
            CommonService.Model.FinanceManager.C_Voucher voucher = _voucherWCF.GetModel(new Guid(voucherCode));
            int i = 1;

            #region
            if (voucher.C_Voucher_auditStatus == Convert.ToInt32(FormApprovalTypeEnum.未审核))
            {
                i = 2;
                if(voucher.C_Voucher_state==0)
                {
                    i = 3;
                    List<CommonService.Model.FinanceManager.C_Voucher_Form> voucherFormList = _voucherFormWCF.GetListByVoucherCode(new Guid(voucherCode));
                    int count = voucherFormList.Count();
                    int num = 0;
                    foreach(CommonService.Model.FinanceManager.C_Voucher_Form voucherForm in voucherFormList)
                    {
                        if(voucher.C_Voucher_documentType==Convert.ToInt32(DocumentTypeEnum.报销))
                        {
                            string formCode = "4B483102-0B05-418A-ACC0-41313D5D083E";//费用报销单Guid(固定值)
                            string condition = "1=1 ";
                            DataSet itemFormPropertyValue = null;

                            condition += "and formPropertyValueGroup ='" + voucherForm.F_Form_code + "'";
                            itemFormPropertyValue = _formPropertyValueWCF.DynamicLoadFeeFormListValues(new Guid(formCode), 1, 10, condition);
                            DataTable dt = itemFormPropertyValue.Tables[0];
                            
                            if (dt.Rows[0]["0EACB483-D8EF-4141-A767-229DCD71F55A"].ToString() != "")
                            {
                                if (Convert.ToInt32(dt.Rows[0]["0EACB483-D8EF-4141-A767-229DCD71F55A"]) == 597)
                                {
                                    num++;
                                }
                            }
                        }else
                        {
                            string formCode = "373A0905-5797-41E0-BB6A-BBC53990B835";//费用借款单Guid(固定值)
                            string condition = "1=1 ";
                            DataSet itemFormPropertyValue = null;

                            condition += "and formPropertyValueGroup ='" + voucherForm.F_Form_code + "'";
                            itemFormPropertyValue = _formPropertyValueWCF.DynamicLoadFeeFormListValues(new Guid(formCode), 1, 10, condition);
                            DataTable dt = itemFormPropertyValue.Tables[0];

                            if (dt.Rows[0]["8A8A572F-66FC-4399-9DEB-C3107E085E3C"].ToString() != "")
                            {
                                if (Convert.ToInt32(dt.Rows[0]["8A8A572F-66FC-4399-9DEB-C3107E085E3C"]) == 597)
                                {
                                    num++;
                                }
                            }
                        }
                    }
                    if(count==num)
                    {
                        i = 4;
                        List<CommonService.Model.CustomerForm.F_FormPropertyValue> formPropertyValueList = new List<CommonService.Model.CustomerForm.F_FormPropertyValue>();
                        foreach (CommonService.Model.FinanceManager.C_Voucher_Form voucherForm in voucherFormList)
                        {
                            if (voucher.C_Voucher_documentType == Convert.ToInt32(DocumentTypeEnum.报销))
                            {
                                CommonService.Model.CustomerForm.F_FormPropertyValue formPropertyValue = _formPropertyValueWCF.GetModelByFormPropertyValueGroupAndFormProperty(voucherForm.F_Form_code.Value, new Guid("0EACB483-D8EF-4141-A767-229DCD71F55A"));
                                formPropertyValue.F_FormPropertyValue_value = "598";//已付款
                                formPropertyValueList.Add(formPropertyValue);
                            }else
                            {
                                CommonService.Model.CustomerForm.F_FormPropertyValue formPropertyValue = _formPropertyValueWCF.GetModelByFormPropertyValueGroupAndFormProperty(voucherForm.F_Form_code.Value, new Guid("8A8A572F-66FC-4399-9DEB-C3107E085E3C"));
                                formPropertyValue.F_FormPropertyValue_value = "598";//已付款
                                formPropertyValueList.Add(formPropertyValue);
                            }
                        }
                        _formPropertyValueWCF.OperateUpdate(formPropertyValueList);

                        voucher.C_Voucher_state = 1;
                        voucher.C_Voucher_auditStatus = Convert.ToInt32(FormApprovalTypeEnum.已通过);
                        voucher.C_Voucher_financeConfirmPerson = Context.UIContext.Current.UserCode;
                        voucher.C_Voucher_confirmTime = DateTime.Now;
                        _voucherWCF.Update(voucher);
                    }else
                    {
                        voucher.C_Voucher_state = 2;
                        _voucherWCF.Update(voucher);
                    }
                }
            }
            #endregion

            if (i==1)
            {
                return Json(TipHelper.JsonData("审核状态必须是未审核！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }else if(i==2)
            {
                return Json(TipHelper.JsonData("状态必须是未付！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }else if(i==3)
            {
                return Json(TipHelper.JsonData("还原单中的数据状态必须全部为未付！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }else
            {
                return Json(TipHelper.JsonData("确认付款成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
        }

        /// <summary>
        /// 驳回
        /// </summary>
        /// <param name="voucherCode"></param>
        /// <returns></returns>
        public ActionResult Reject(string voucherCode)
        {
            CommonService.Model.FinanceManager.C_Voucher voucher = _voucherWCF.GetModel(new Guid(voucherCode));
            return View(voucher);
        }

        /// <summary>
        /// 保存驳回信息
        /// </summary>
        /// <param name="voucherCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveReject(CommonService.Model.FinanceManager.C_Voucher voucher)
        {
            bool isSuccess = false;
            voucher.C_Voucher_auditStatus = Convert.ToInt32(FormApprovalTypeEnum.已驳回);
            isSuccess = _voucherWCF.Update(voucher);
            if (isSuccess)
            {
                return Json(TipHelper.JsonData("驳回信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
            else
            {
                return Json(TipHelper.JsonData("驳回信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string voucherCode)
        {
            bool isSuccess = _voucherWCF.Delete(new Guid(voucherCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除凭证信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除凭证信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 获取最新一条数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetNewestModel()
        {
            CommonService.Model.FinanceManager.C_Voucher voucher = _voucherWCF.GetNewestModel(UIContext.Current.UserCode.Value);
            return Json(voucher.C_Voucher_number);
        }

        /// <summary>
        /// 获取当前登录用户关联角色权限
        /// </summary>
        /// <returns></returns>
        private string GetRolePowers()
        {
            //如果为内置系统管理员，则不允许查关联角色权限
            string rolePowerIds = String.Empty;
            if (!UIContext.Current.IsPreSetManager)
            {
                List<CommonService.Model.SysManager.C_Role_Role_Power> Role_RolePowers = _roleRolePower.GetRolePowersByUserCode(Context.UIContext.Current.UserCode);
                foreach (CommonService.Model.SysManager.C_Role_Role_Power role_RolePower in Role_RolePowers)
                {
                    rolePowerIds += role_RolePower.C_Role_Power_id.Value.ToString() + ",";
                }
            }
            if (rolePowerIds != "")
            {
                rolePowerIds = "," + rolePowerIds;
            }

            return rolePowerIds;
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //费用种类参数集合
            List<CommonService.Model.C_Parameters> FeeTypes = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFormEnum.费用种类));
            ViewBag.FeeTypes = FeeTypes;
            //发票种类参数集合
            List<CommonService.Model.C_Parameters> InvoiceType1 = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFormEnum.费用类型));
            List<CommonService.Model.C_Parameters> InvoiceType2 = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFormEnum.垫付款类型));
            List<CommonService.Model.C_Parameters> InvoiceType = InvoiceType1.Concat(InvoiceType2).ToList();
            ViewBag.InvoiceType = InvoiceType;
            //付款状态参数集合
            List<CommonService.Model.C_Parameters> PayStatus = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFormEnum.付款状态));
            ViewBag.PayStatus = PayStatus;
        }
	}
}