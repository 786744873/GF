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
    public class VoucherController : BaseController
    {
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.CustomerForm.IF_FormPropertyValue _formPropertyValueWCF;
        private readonly ICommonService.OA.IO_Form _oFormWCF;
        private readonly ICommonService.SysManager.IC_Role_Role_Power _roleRolePower;
        private readonly ICommonService.CustomerForm.IF_FormProperty _formPropertyWCF;
        CommonService.Common.RMBCapitalization rmbCapitalization = new CommonService.Common.RMBCapitalization();
        private readonly ICommonService.FinanceManager.IC_Voucher _voucherWCF;
        private readonly ICommonService.FinanceManager.IC_Voucher_Form _voucherFormWCF;
        private readonly ICommonService.SysManager.IC_Organization _organizationWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;


        public VoucherController()
        {
            _formPropertyWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormProperty>("FormPropertyWCF");
            _formPropertyValueWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormPropertyValue>("FormPropertyValueWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _oFormWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Form>("oFormWCF");
            _roleRolePower = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Role_Role_Power>("Role_Role_PowerWCF");
            _voucherWCF = ServiceProxyFactory.Create<ICommonService.FinanceManager.IC_Voucher>("VoucherWCF");
            _voucherFormWCF = ServiceProxyFactory.Create<ICommonService.FinanceManager.IC_Voucher_Form>("Voucher_FormWCF");
            _organizationWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization>("OrganizationWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");

        }
        //
        // GET: /OA/Voucher/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            List<CommonService.Model.C_Parameters> PayStatus = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CustomerFormEnum.付款状态));
            ViewBag.PayStatus = PayStatus;
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

            //查询模型
            CommonService.Model.FinanceManager.C_Voucher Conditon = new CommonService.Model.FinanceManager.C_Voucher();
            //条件
            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {
                if (!UIContext.Current.IsPreSetManager)
                {
                    Conditon.C_Voucher_applicationPerson = Context.UIContext.Current.UserCode;
                }

                if (!String.IsNullOrEmpty(Request.Params.Get("s_title")))
                {//编号
                    Conditon.C_Voucher_number = Request.Params.Get("s_title").Trim();
                }
                string stste = Request.Params.Get("i_state");//付款状态
                if (!String.IsNullOrEmpty(stste) && stste.ToString() != "-1")
                {
                    Conditon.C_Voucher_state = Convert.ToInt32(stste) == 597 ? 0 : 1;
                }
                //查询模型传递到前端视图中
                ViewBag.Conditon = Conditon;
            }
            //OA的查询条件
            Conditon.C_Voucher_type = 2;
            if (!UIContext.Current.IsPreSetManager)
            Conditon.C_Voucher_applicationPerson = UIContext.Current.UserCode;
            #endregion

            string rolePowerIds = GetRolePowers();

            //获取总记录数
            this.TotalRecordCount = _voucherWCF.GetRecordCount(Conditon, rolePowerIds);
            this.PageSize = 15;

            //获取数据信息
            List<CommonService.Model.FinanceManager.C_Voucher> voucher = _voucherWCF.GetListByPage(Conditon, rolePowerIds,
                "", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            //转化数据格式
            var result = from c in voucher
                         select new[] { 
                             c.C_Voucher_code.ToString(),
                             c.C_Voucher_number,
                             c.C_Voucher_state==0 ?"未付":"已付",
                             c.C_Voucher_applicationTime==null?null:c.C_Voucher_applicationTime.Value.ToString(),
                             c.C_Voucher_applicationPersonName,
                             c.C_Voucher_documentType==600?"报销":"借款",
                             c.C_Voucher_departmentName,
                             c.C_Voucher_amounts==null?null:c.C_Voucher_amounts.ToString(),
                             c.C_Voucher_superiorAuditPersonName,
                             c.C_Voucher_financeConfirmPersonName,
                             c.C_Voucher_confirmTime==null?null:c.C_Voucher_confirmTime.ToString()
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
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string voucherCode)
        {
            bool isSuccess = _voucherWCF.Delete(new Guid(voucherCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除凭证信息成功！", "voucherList", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除凭证信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
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
            if(voucher.C_Voucher_state==1)
                return Json(TipHelper.JsonData("不需要重复操作！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            #region
            if (voucher.C_Voucher_auditStatus == Convert.ToInt32(FormApprovalTypeEnum.未审核))
            {
                i = 2;
                if (voucher.C_Voucher_state == 0)
                {
                    i = 3;
                    List<CommonService.Model.FinanceManager.C_Voucher_Form> voucherFormList = _voucherFormWCF.GetListByVoucherCode(new Guid(voucherCode));
                    int count = voucherFormList.Count();
                    int num = 0;
                    foreach (CommonService.Model.FinanceManager.C_Voucher_Form voucherForm in voucherFormList)
                    {
                        if (voucher.C_Voucher_documentType == Convert.ToInt32(DocumentTypeEnum.报销))
                        {
                            string formCode = "77119C9F-113E-44DF-B1B1-E09AB85A9CF4";//费用报销单Guid(固定值)
                            string condition = "1=1 ";
                            DataSet itemFormPropertyValue = null;

                            condition += "and formPropertyValueGroup ='" + voucherForm.F_Form_code + "'";
                            itemFormPropertyValue = _formPropertyValueWCF.DynamicLoadOAFeeFormListValues(new Guid(formCode), 1, 10, condition);
                            DataTable dt = itemFormPropertyValue.Tables[0];

                            if (dt.Rows[0]["5F2D1E75-DC49-491A-B8C3-4FDFDBD47827"].ToString() != "")
                            {
                                if (Convert.ToInt32(dt.Rows[0]["5F2D1E75-DC49-491A-B8C3-4FDFDBD47827"]) == 597)
                                {
                                    num++;
                                }
                            }
                        }
                        else
                        {
                            string formCode = "76D963E9-BE8D-42D0-87F8-657CB294108B";//费用借款单Guid(固定值)
                            string condition = "1=1 ";
                            DataSet itemFormPropertyValue = null;

                            condition += "and formPropertyValueGroup ='" + voucherForm.F_Form_code + "'";
                            itemFormPropertyValue = _formPropertyValueWCF.DynamicLoadFeeFormListValues(new Guid(formCode), 1, 10, condition);
                            DataTable dt = itemFormPropertyValue.Tables[0];

                            if (dt.Rows[0]["390C588F-998B-437A-940A-7198FA536023"].ToString() != "")
                            {
                                if (Convert.ToInt32(dt.Rows[0]["390C588F-998B-437A-940A-7198FA536023"]) == 597)
                                {
                                    num++;
                                }
                            }
                        }
                    }
                    if (count == num)
                    {
                        i = 4;
                        voucher.C_Voucher_state = 1;
                        voucher.C_Voucher_auditStatus = Convert.ToInt32(FormApprovalTypeEnum.已通过);
                        voucher.C_Voucher_financeConfirmPerson = Context.UIContext.Current.UserCode;
                        voucher.C_Voucher_confirmTime = DateTime.Now;
                        _voucherWCF.Update(voucher);

                        List<CommonService.Model.CustomerForm.F_FormPropertyValue> formPropertyValueList = new List<CommonService.Model.CustomerForm.F_FormPropertyValue>();
                        foreach (CommonService.Model.FinanceManager.C_Voucher_Form voucherForm in voucherFormList)
                        {
                            if (voucher.C_Voucher_documentType == Convert.ToInt32(DocumentTypeEnum.报销))
                            {
                                CommonService.Model.CustomerForm.F_FormPropertyValue formPropertyValue = _formPropertyValueWCF.GetModelByFormPropertyValueGroupAndFormProperty(voucherForm.F_Form_code.Value, new Guid("5F2D1E75-DC49-491A-B8C3-4FDFDBD47827"));
                                formPropertyValue.F_FormPropertyValue_value = "598";//已付款
                                formPropertyValueList.Add(formPropertyValue);
                            }
                            else
                            {
                                CommonService.Model.CustomerForm.F_FormPropertyValue formPropertyValue = _formPropertyValueWCF.GetModelByFormPropertyValueGroupAndFormProperty(voucherForm.F_Form_code.Value, new Guid("390C588F-998B-437A-940A-7198FA536023"));
                                formPropertyValue.F_FormPropertyValue_value = "598";//已付款
                                formPropertyValueList.Add(formPropertyValue);
                            }
                        }
                        _formPropertyValueWCF.OperateUpdate(formPropertyValueList);
                    }
                }
            }
            #endregion

            if (i == 1)
            {
                return Json(TipHelper.JsonData("审核状态必须是未审核！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            else if (i == 2)
            {
                return Json(TipHelper.JsonData("状态必须是未付！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            else if (i == 3)
            {
                return Json(TipHelper.JsonData("还原单中的数据状态必须全部为未付！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            else
            {
                return Json(TipHelper.JsonData("确认付款成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="voucherCode"></param>
        /// <returns></returns>
        public ActionResult Print(string voucherCode)
        {
            CommonService.Model.FinanceManager.C_Voucher voucher = _voucherWCF.GetModel(new Guid(voucherCode));
            ViewBag.number = voucher.C_Voucher_number;
            ViewBag.applydate = voucher.C_Voucher_applicationTime;
            ViewBag.pattype = voucher.C_Voucher_paymentMethod;
            string formCode = "77119C9F-113E-44DF-B1B1-E09AB85A9CF4";//费用报销单Guid(固定值)
            if (voucher.C_Voucher_documentType == Convert.ToInt32(DocumentTypeEnum.借款))
            {
                formCode = "76D963E9-BE8D-42D0-87F8-657CB294108B";
            }
            ViewBag.type = voucher.C_Voucher_documentType;
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

                itemFormPropertyValue = _formPropertyValueWCF.DynamicLoadOAFeeFormListValues(new Guid(formCode), 1,
                10, condition);

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
                        if (formCode == "77119C9F-113E-44DF-B1B1-E09AB85A9CF4")//报销单
                        {
                            for (int i = 0; i < itemFormPropertyValue.Tables[0].Rows.Count; i++)
                            {
                                string paytype = listP.FirstOrDefault(p => p.C_Parameters_id == Convert.ToInt32(itemFormPropertyValue.Tables[0].Rows[i][2])).C_Parameters_name;//费用类型
                                string mony = "";//费用金额
                                if (itemFormPropertyValue.Tables[0].Rows[i][4] != null)
                                {
                                    mony = itemFormPropertyValue.Tables[0].Rows[i][4].ToString();
                                    monyreslt = monyreslt + Convert.ToDecimal(mony);
                                }
                                strZy = strZy + paytype + ":" + mony + ",";
                            }
                        }
                        else
                        {
                            for (int i = 0; i < itemFormPropertyValue.Tables[0].Rows.Count; i++)
                            {
                                string paytype = listP.FirstOrDefault(p => p.C_Parameters_id == Convert.ToInt32(itemFormPropertyValue.Tables[0].Rows[i][5])).C_Parameters_name;//费用类型
                                string mony = "";//费用金额
                                if (itemFormPropertyValue.Tables[0].Rows[i][7] != null)
                                {
                                    mony = itemFormPropertyValue.Tables[0].Rows[i][7].ToString();
                                    monyreslt = monyreslt + Convert.ToDecimal(mony);
                                }
                                strZy = strZy + paytype + ":" + mony + ",";
                            }
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
    }
}