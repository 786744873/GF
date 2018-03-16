using CommonService.Common;
using Context;
using Maticsoft.Common;
using Portal.Controllers;
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
    /// 财务报销控制器
    /// </summary>
    public class ReimbursementController : BaseController
    {
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.CustomerForm.IF_FormPropertyValue _formPropertyValueWCF;
        private readonly ICommonService.OA.IO_Form _oFormWCF;
        private readonly ICommonService.SysManager.IC_Role_Role_Power _roleRolePower;
        private readonly ICommonService.CustomerForm.IF_FormProperty _formPropertyWCF;
        private readonly ICommonService.FinanceManager.IC_Voucher _voucherWCF;
        private readonly ICommonService.FinanceManager.IC_Voucher_Form _voucherFormWCF;
        CommonService.Common.RMBCapitalization rmbCapitalization = new CommonService.Common.RMBCapitalization();
        public ReimbursementController()
        {
            _formPropertyWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormProperty>("FormPropertyWCF");
            _formPropertyValueWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormPropertyValue>("FormPropertyValueWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _oFormWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Form>("oFormWCF");
            _roleRolePower = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Role_Role_Power>("Role_Role_PowerWCF");
            _voucherWCF = ServiceProxyFactory.Create<ICommonService.FinanceManager.IC_Voucher>("VoucherWCF");
            _voucherFormWCF = ServiceProxyFactory.Create<ICommonService.FinanceManager.IC_Voucher_Form>("Voucher_FormWCF");
        }
        //
        // GET: /OA/Reimbursement/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            List<CommonService.Model.C_Parameters> PayStatus = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFormEnum.付款状态));
            ViewBag.PayStatus = PayStatus;
            List<CommonService.Model.C_Parameters> FeeTypes = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFormEnum.费用种类));
            ViewBag.FeeTypes = FeeTypes;
            //发票种类参数集合
            List<CommonService.Model.C_Parameters> InvoiceType1 = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFormEnum.费用类型));
            List<CommonService.Model.C_Parameters> InvoiceType2 = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFormEnum.垫付款类型));
            List<CommonService.Model.C_Parameters> InvoiceType = InvoiceType1.Concat(InvoiceType2).ToList();
            ViewBag.InvoiceType = InvoiceType;
            return View();
        }

        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult AjaxList(jQueryDataTableParamModel param)
        {
            #region 查询拼接条件设置,查询条件根据实际业务进行相应更改)

            string formCode = "77119C9F-113E-44DF-B1B1-E09AB85A9CF4";//报销单Guid(固定值)
            string condition = "1=1";//查询条件
            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string stste = Request.Params.Get("i_state");//付款状态
                if (!String.IsNullOrEmpty(stste) && stste.ToString() != "-1")
                {
                    condition = condition + "and \"5F2D1E75-DC49-491A-B8C3-4FDFDBD47827\" = " + Convert.ToInt32(stste);
                }
                string state_type = Request.Params.Get("i_state_type");//发票类型
                if (!String.IsNullOrEmpty(state_type) && state_type.ToString() != "-1")
                {
                    condition = condition + "and \"2E4B3398-1AA6-4D2E-B8ED-46CAF78FFBE7\" = " + Convert.ToInt32(state_type);
                }

                #endregion
            }
            #region 列表数据权限处理
            if (!UIContext.Current.IsPreSetManager)
            {
                condition = condition + "and O_Form_creator ='" + UIContext.Current.UserCode + "' ";
            }
            //if (!UIContext.Current.IsPreSetManager)
            //{
            //    StringBuilder strPowerSql = new StringBuilder();
            //    string rolePowerIds = this.GetRolePowers();
            //    strPowerSql.Append(" and (1<>1 ");
            //    strPowerSql.Append(" or (O_Form_applyPerson='" + Context.UIContext.Current.UserCode + "') ");
            //    if (rolePowerIds.Contains(",18,"))
            //    {//专业顾问数据权限               

            //    }
            //    else if (rolePowerIds.Contains(",19,"))
            //    {//可以看到自己的和自己负责流程下所有表单负责人的               
            //        strPowerSql.Append(" or exists(select 1 from P_Business_flow As PF with(nolock) where PF.P_Business_flow_code=TT.P_Business_flow_code and PF.P_Business_isdelete=0 and PF.P_Business_person='" + UIContext.Current.UserCode + "' ) ");
            //    }
            //    else if (rolePowerIds.Contains(",20,"))
            //    {//可以看到自己的

            //    }
            //    else if (rolePowerIds.Contains(",21,"))
            //    {//可以看到自己负责所有案件下所有表单中的
            //        strPowerSql.Append(" or exists(select 1 from B_Case As B with(nolock) where B.B_Case_isDelete=0 and B.B_Case_code=TT.P_Fk_code and B.B_Case_person='" + UIContext.Current.UserCode + "' ) ");
            //    }
            //    else if (rolePowerIds.Contains(",6,"))
            //    {//可以看到自己负责所有区域内的
            //        strPowerSql.Append("or exists(select 1 from C_Userinfo_region As CRR with(nolock),B_Case_link As BCL with(nolock) ");
            //        strPowerSql.Append("where CRR.C_Region_code=BCL.C_FK_code ");
            //        strPowerSql.Append("and CRR.C_Userinfo_code='" + UIContext.Current.UserCode + "' ");
            //        strPowerSql.Append("and BCL.B_Case_link_type=6 ");
            //        strPowerSql.Append("and BCL.B_Case_link_isDelete=0 ");
            //        strPowerSql.Append("and BCL.B_Case_code=TT.P_Fk_code) ");
            //    }
            //    strPowerSql.Append(") ");
            //    condition = condition + strPowerSql;
            //}
            #endregion



            //if (!String.IsNullOrEmpty(Request.Params.Get("isExecutedSearch"))
            //{//编号
            //    condition = condition + "and \"6A96222B-1814-451E-9C96-569363CA52F9\" like '%" + form["FeeReimbursementNumber"].Trim() + "%'";
            //    ViewBag.FeeReimbursementNumber = form["FeeReimbursementNumber"];
            //}

            //if (!String.IsNullOrEmpty(form["PaymentStatus"]) && form["PaymentStatus"].ToString() != "全部")
            //{//付款状态
            //    condition = condition + "and \"8A8A572F-66FC-4399-9DEB-C3107E085E3C\" = " + form["PaymentStatus"].Trim();
            //    ViewBag.PaymentStatus = form["PaymentStatus"];
            //}

            #endregion

            this.TotalRecordCount = _formPropertyValueWCF.DynamicLoadOAFeeFormListCount(new Guid(formCode), condition);

            //获得参数表中的数据
            CommonService.Model.C_Parameters modelP = new CommonService.Model.C_Parameters();
            List<CommonService.Model.C_Parameters> listP = _parameterWCF.GetListByPage(modelP, "", 0, 10000);

            //获取表单明细属性值
            DataSet itemFormPropertyValues = _formPropertyValueWCF.DynamicLoadOAFeeFormListValues(new Guid(formCode), param.iDisplayStart + 1,
                param.iDisplayStart + param.iDisplayLength, condition);
            List<CommonService.Model.Customer.V_Loan> listsLoan = new List<CommonService.Model.Customer.V_Loan>();
            if (itemFormPropertyValues.Tables.Count != 0)
            {
                for (int i = 0; i < itemFormPropertyValues.Tables[0].Rows.Count; i++)
                {
                    CommonService.Model.Customer.V_Loan model = new CommonService.Model.Customer.V_Loan();
                    if (itemFormPropertyValues.Tables[0].Rows[i]["O_Form_code"] != null && itemFormPropertyValues.Tables[0].Rows[i]["O_Form_code"].ToString() != "")
                    {
                        model.Formcode = itemFormPropertyValues.Tables[0].Rows[i]["O_Form_code"].ToString();
                    }
                    if (itemFormPropertyValues.Tables[0].Rows[i]["D3643E61-7612-4749-B868-C9E08F818E4D"] != null && itemFormPropertyValues.Tables[0].Rows[i]["D3643E61-7612-4749-B868-C9E08F818E4D"].ToString() != "")
                    {
                        model.Consttype = itemFormPropertyValues.Tables[0].Rows[i]["D3643E61-7612-4749-B868-C9E08F818E4D"].ToString();
                        model.Consttype = listP.FirstOrDefault(p => p.C_Parameters_id == Convert.ToInt32(model.Consttype)).C_Parameters_name;
                    }
                    if (itemFormPropertyValues.Tables[0].Rows[i]["2E4B3398-1AA6-4D2E-B8ED-46CAF78FFBE7"] != null && itemFormPropertyValues.Tables[0].Rows[i]["2E4B3398-1AA6-4D2E-B8ED-46CAF78FFBE7"].ToString() != "")
                    {
                        model.Invoicetype = itemFormPropertyValues.Tables[0].Rows[i]["2E4B3398-1AA6-4D2E-B8ED-46CAF78FFBE7"].ToString();
                        model.Invoicetype = listP.FirstOrDefault(p => p.C_Parameters_id == Convert.ToInt32(model.Invoicetype)).C_Parameters_name;
                    }

                    if (itemFormPropertyValues.Tables[0].Rows[i]["445A808A-9776-45D0-8E75-7B296AF45DC1"] != null && itemFormPropertyValues.Tables[0].Rows[i]["445A808A-9776-45D0-8E75-7B296AF45DC1"].ToString() != "")
                    {
                        model.Invoicevalue = itemFormPropertyValues.Tables[0].Rows[i]["445A808A-9776-45D0-8E75-7B296AF45DC1"].ToString();

                    }
                    if (itemFormPropertyValues.Tables[0].Rows[i]["DD67E06E-E543-42E3-8FF2-C52CFD00809B"] != null && itemFormPropertyValues.Tables[0].Rows[i]["DD67E06E-E543-42E3-8FF2-C52CFD00809B"].ToString() != "")
                    {
                        model.Abstracts = itemFormPropertyValues.Tables[0].Rows[i]["DD67E06E-E543-42E3-8FF2-C52CFD00809B"].ToString();

                    }
                    if (itemFormPropertyValues.Tables[0].Rows[i]["1890777A-641A-41D0-ABC1-AC0A58AC831D"] != null && itemFormPropertyValues.Tables[0].Rows[i]["1890777A-641A-41D0-ABC1-AC0A58AC831D"].ToString() != "")
                    {
                        model.Dateofcost = itemFormPropertyValues.Tables[0].Rows[i]["1890777A-641A-41D0-ABC1-AC0A58AC831D"].ToString();

                    }
                    if (itemFormPropertyValues.Tables[0].Rows[i]["O_Form_applyTime"] != null && itemFormPropertyValues.Tables[0].Rows[i]["O_Form_applyTime"].ToString() != "")
                    {
                        model.Applydate = itemFormPropertyValues.Tables[0].Rows[i]["O_Form_applyTime"].ToString();

                    }
                    if (itemFormPropertyValues.Tables[0].Rows[i]["O_Form_applyStatus"] != null && itemFormPropertyValues.Tables[0].Rows[i]["O_Form_applyStatus"].ToString() != "")
                    {
                        model.Formstatus = itemFormPropertyValues.Tables[0].Rows[i]["O_Form_applyStatus"].ToString();
                        model.Formstatus = listP.FirstOrDefault(p => p.C_Parameters_id == Convert.ToInt32(model.Formstatus)).C_Parameters_name;
                    }
                    if (itemFormPropertyValues.Tables[0].Rows[i]["5F2D1E75-DC49-491A-B8C3-4FDFDBD47827"] != null && itemFormPropertyValues.Tables[0].Rows[i]["5F2D1E75-DC49-491A-B8C3-4FDFDBD47827"].ToString() != "")
                    {
                        model.Paymentstatus = itemFormPropertyValues.Tables[0].Rows[i]["5F2D1E75-DC49-491A-B8C3-4FDFDBD47827"].ToString();
                        model.Paymentstatus = listP.FirstOrDefault(p => p.C_Parameters_id == Convert.ToInt32(model.Paymentstatus)).C_Parameters_name;
                    }
                    if (itemFormPropertyValues.Tables[0].Rows[i]["O_Form_applyPerson_name"] != null && itemFormPropertyValues.Tables[0].Rows[i]["O_Form_applyPerson_name"].ToString() != "")
                    {
                        model.FormapplyPerson_name = itemFormPropertyValues.Tables[0].Rows[i]["O_Form_applyPerson_name"].ToString();
                    }
                    if (itemFormPropertyValues.Tables[0].Rows[i]["formPropertyValueGroup"] != null && itemFormPropertyValues.Tables[0].Rows[i]["formPropertyValueGroup"].ToString() != "")
                    {
                        model.FormPropertyValueGroup = itemFormPropertyValues.Tables[0].Rows[i]["formPropertyValueGroup"].ToString();
                    }
                    listsLoan.Add(model);
                }

            }
            //转化数据格式
            var result = from c in listsLoan
                         select new[] { 
                             c.Formcode,
                             c.FormPropertyValueGroup,
                             c.Consttype,
                             c.Invoicetype,
                             c.Invoicevalue,
                             c.Formstatus,
                             c.Dateofcost,
                             c.Applydate,
                             c.Abstracts,
                             c.Paymentstatus,
                             c.FormapplyPerson_name

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

        }
        /// <summary>
        /// 生成单据
        /// </summary>
        /// <param name="formCode">生成的表单字符串</param>
        /// <returns></returns>
        public ActionResult Create(string formCode)
        {
            string reimCode = "77119C9F-113E-44DF-B1B1-E09AB85A9CF4";//报销单Guid(固定值)
            string condition = "1=1 ";
            ViewBag.formPropertyValueGroup = formCode;
            if (!String.IsNullOrEmpty(formCode))
            {
                string formPropertyValueGroupStr = "";
                string[] groups = formCode.Split(',');
                foreach (var group in groups)
                {
                    formPropertyValueGroupStr += "'" + group + "',";
                }
                if (formPropertyValueGroupStr != "")
                {
                    formPropertyValueGroupStr = formPropertyValueGroupStr.Substring(0, formPropertyValueGroupStr.Length - 1);
                }
                condition += "and formPropertyValueGroup in (" + formPropertyValueGroupStr + ")";

                DataSet itemFormPropertyValue = _formPropertyValueWCF.DynamicLoadOAFeeFormListValues(new Guid(reimCode), 1,
                10, condition);

                //申请时间
                ViewBag.date = DateTime.Now.ToLongDateString().ToString();
                if (itemFormPropertyValue.Tables.Count != 0)
                {
                    if (itemFormPropertyValue.Tables[0].Rows.Count != 0)
                    {
                        //申请人名称
                        ViewBag.applypersonname = itemFormPropertyValue.Tables[0].Rows[0]["O_Form_applyPerson_name"] == null ? null : itemFormPropertyValue.Tables[0].Rows[0]["O_Form_applyPerson_name"].ToString();
                        //申请人guid
                        ViewBag.applyperson = itemFormPropertyValue.Tables[0].Rows[0]["O_Form_applyPerson"] == null ? null : itemFormPropertyValue.Tables[0].Rows[0]["O_Form_applyPerson"].ToString();
                        //申请人部门
                        ViewBag.applyOrgname = itemFormPropertyValue.Tables[0].Rows[0]["O_Form_applyOrg_name"] == null ? null : itemFormPropertyValue.Tables[0].Rows[0]["O_Form_applyOrg_name"].ToString();
                        //申请时间
                        ViewBag.applyTime = itemFormPropertyValue.Tables[0].Rows[0]["O_Form_applyTime"] == null ? null : itemFormPropertyValue.Tables[0].Rows[0]["O_Form_applyTime"].ToString();
                        //部门guid
                        ViewBag.applyOrg = itemFormPropertyValue.Tables[0].Rows[0]["O_Form_applyOrg"] == null ? null : itemFormPropertyValue.Tables[0].Rows[0]["O_Form_applyOrg"].ToString();
                        //参数集合
                        CommonService.Model.C_Parameters modelP = new CommonService.Model.C_Parameters();
                        List<CommonService.Model.C_Parameters> listP = _parameterWCF.GetListByPage(modelP, "", 0, 10000);
                        //摘要
                        string strZy = "";
                        decimal monyreslt = 0;
                        for (int i = 0; i < itemFormPropertyValue.Tables[0].Rows.Count; i++)
                        {
                            string paytype = listP.FirstOrDefault(p => p.C_Parameters_id == Convert.ToInt32(itemFormPropertyValue.Tables[0].Rows[i]["2E4B3398-1AA6-4D2E-B8ED-46CAF78FFBE7"])).C_Parameters_name;//费用类型
                            string mony="";//费用金额
                            if (itemFormPropertyValue.Tables[0].Rows[i]["445A808A-9776-45D0-8E75-7B296AF45DC1"] != null)
                            {
                                mony = itemFormPropertyValue.Tables[0].Rows[i]["445A808A-9776-45D0-8E75-7B296AF45DC1"].ToString();
                               monyreslt = monyreslt+Convert.ToDecimal(mony);
                            }
                            strZy = strZy + paytype + ":" + mony + ",";
                        }
                        strZy = strZy.Substring(0, strZy.Length - 1);
                        //摘要
                        ViewBag.zy = strZy;
                        //金额大写
                        ViewBag.monyL = rmbCapitalization.RMBAmount(Convert.ToDouble(monyreslt));
                        //金额小写
                        ViewBag.monyS = monyreslt.ToString();
                    }
                }
            }
            return View();
        }
        /// <summary>
        /// 生成单据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form)
        {
            int isSuccess = 0;
            string formPropertyValueGroup = form["formPropertyValueGroup"];
            string applyPerson = form["O_Form_applyPerson"];//申请人
            string applyTime = form["applytime"];//申请时间
            string organizationCode = form["applyOrg"];//部门
            string paymentMethod = form["paymentMethod"];//付款方式
            string TotalAmount = form["mony"];//金额

            List<CommonService.Model.FinanceManager.C_Voucher> vouchers = _voucherWCF.GetAllList();
            string number = "";
            int num = 001;
            if (vouchers.Count() != 0)
            {
                number = vouchers.FirstOrDefault().C_Voucher_number;
                num = int.Parse(number.Substring(number.Length - 3, 3)) + 1;
            }
            CommonService.Model.FinanceManager.C_Voucher voucher = new CommonService.Model.FinanceManager.C_Voucher();
            voucher.C_Voucher_code = Guid.NewGuid();
            voucher.C_Voucher_number = "SC" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + num.ToString("000");
            voucher.C_Voucher_state = 0;
            voucher.C_Voucher_applicationTime = DateTime.Now;
            if (applyPerson != null)
            {
                voucher.C_Voucher_applicationPerson = new Guid(applyPerson);
            }
            voucher.C_Voucher_documentType = Convert.ToInt32(DocumentTypeEnum.报销);
            if (!String.IsNullOrEmpty(organizationCode))
            {
                voucher.C_Voucher_department = new Guid(organizationCode);
            }
            voucher.C_Voucher_amounts = Convert.ToDecimal(TotalAmount);
            voucher.C_Voucher_auditStatus = Convert.ToInt32(FormApprovalTypeEnum.未审核);
            voucher.C_Voucher_paymentMethod = Convert.ToInt32(paymentMethod);
            voucher.C_Voucher_isDelete = false;
            voucher.C_Voucher_creator = Context.UIContext.Current.UserCode;
            voucher.C_Voucher_createTime = DateTime.Now;
            voucher.C_Voucher_type = 2;//2是oa
            isSuccess = _voucherWCF.Add(voucher);

            //凭证信息—子表单中间表
            List<CommonService.Model.FinanceManager.C_Voucher_Form> voucherFormList = new List<CommonService.Model.FinanceManager.C_Voucher_Form>();
            string[] formPropertyValueGroups = formPropertyValueGroup.Split(',');
            foreach (var group in formPropertyValueGroups)
            {
                CommonService.Model.FinanceManager.C_Voucher_Form voucherForm = new CommonService.Model.FinanceManager.C_Voucher_Form();
                voucherForm.F_Form_code = new Guid(group);
                voucherForm.C_Voucher_code = voucher.C_Voucher_code;

                voucherFormList.Add(voucherForm);
            }
            _voucherFormWCF.OperateList(voucherFormList);
            if (isSuccess > 0)
            {
                //保存成功提示固定写法
                return Json(TipHelper.JsonData("生成单据成功！", "", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("生成单据失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

    }
}