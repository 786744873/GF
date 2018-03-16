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
    /// 表单审核控制器
    /// </summary>
    public class FormCheckController : BaseController
    {
        private readonly ICommonService.CustomerForm.IF_FormCheck _formCheckWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow_form _businessFlowFormWCF;
        public FormCheckController()
        {
            #region 服务初始化
            _formCheckWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormCheck>("FormCheckWCF");
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            _businessFlowFormWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow_form>("Business_flow_formWCF");     
            #endregion
        }

        //
        // GET: /CustomerForm/FormCheck/
        public override ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 根据业务流程Guid，获取业务流程关联所有表单
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public ActionResult LayoutSubmit(string businessFlowCode,string fkType)
        {
            CommonService.Model.FlowManager.P_Business_flow businessFlow = _bussinessFlowWCF.Get(new Guid(businessFlowCode));
            if(businessFlow.P_Business_person != null)
            {
                ViewBag.personIsNull = true;
            }else
            {
                ViewBag.personIsNull = false;
            }
            ViewBag.BusinessFlowCode = businessFlowCode;
            ViewBag.fkType = fkType;
            return View();
        }

        /// <summary>
        ///提交业务流程表单
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SubmitBusinessFlowForm(FormCollection form)
        {
            string fkType=form["fkType"];
            string submitInfo = form["submitInfo"];
            string businessFlowFormCodes = form["checkedBusinessFlowForms"];
            string[] businessFlowFormCodesGroup = businessFlowFormCodes.Split(',');
            DateTime now = DateTime.Now;

            List<CommonService.Model.CustomerForm.F_FormCheck> formChecks = new List<CommonService.Model.CustomerForm.F_FormCheck>();

            for (int i = 0; i < businessFlowFormCodesGroup.Length; i++)
            {
                CommonService.Model.CustomerForm.F_FormCheck formCheck = new CommonService.Model.CustomerForm.F_FormCheck();
                formCheck.F_FormCheck_code = Guid.NewGuid();
                formCheck.F_FormCheck_business_flow_form_code = new Guid(businessFlowFormCodesGroup[i]);
                formCheck.F_FormCheck_isFirstSubmit = true;
                formCheck.F_FormCheck_submitInfo = submitInfo;
                formCheck.F_FormCheck_isDelete = false;
                formCheck.F_FormCheck_creator = Context.UIContext.Current.UserCode;
                formCheck.F_FormCheck_createTime = now;

                formChecks.Add(formCheck);
            }
            bool IsValidate = _formCheckWCF.IsValidate(businessFlowFormCodes);
            if(IsValidate)
            {//表单值中包含必填项未填写的
                return Json(TipHelper.JsonData("表单数据不完整，请检查表单</br>后重新提交！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            int status = _formCheckWCF.SubmitForm(formChecks, fkType);

            if (status==1)
            {
                //保存成功提示固定写法
                return Json(TipHelper.JsonData("提交表单成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
            else if (status == -1)
            {
                return Json(TipHelper.JsonData("提交表单所属阶段</br>存在没有设置负责人的情况！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("没有符合条件可以提交的表单！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 业务流程表单提交历史记录
        /// </summary>
        /// <param name="businessFlowFormCode"></param>
        /// <returns></returns>
        public ActionResult BusinessFlowFormSubmitRecord(string businessFlowFormCode, string businessflowcode)
        {
            List<CommonService.Model.CustomerForm.F_FormCheck> FormChecks;
            if (String.IsNullOrEmpty(businessFlowFormCode))
            {
                FormChecks = _formCheckWCF.GetFirstTimeFormCheckRecordForflowcode(new Guid(businessflowcode));
            }
            else
            {
                FormChecks = _formCheckWCF.GetFirstTimeFormCheckRecord(new Guid(businessFlowFormCode));
            }
     
            return View(FormChecks);
        }

        /// <summary>
        /// 根据业务流程Guid，获取业务流程关联所有表单
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public ActionResult LayoutCheck(string businessFlowCode,string fkType)
        {
            ViewBag.BusinessFlowCode = businessFlowCode;
            ViewBag.FkType = fkType;

            return View();
        }

        /// <summary>
        /// 审核业务流程表单
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CheckBusinessFlowForm(FormCollection form)
        {
            string businessFlowCode = form["businessFlowCode"];//业务流程
            string fkType=form["fkType"];
            string checkInfo = form["checkInfo"];
            string businessFlowFormCodes = form["checkedBusinessFlowForms"];
            string[] businessFlowFormCodesGroup = businessFlowFormCodes.Split(',');
            string checkStatus = form["checkStatus"];

            List<CommonService.Model.CustomerForm.F_FormCheck> formChecks = new List<CommonService.Model.CustomerForm.F_FormCheck>();

            for (int i = 0; i < businessFlowFormCodesGroup.Length; i++)
            {
                DateTime now = DateTime.Now;               
                CommonService.Model.CustomerForm.F_FormCheck formCheck = new CommonService.Model.CustomerForm.F_FormCheck();
                formCheck.F_FormCheck_code = Guid.NewGuid();
                formCheck.F_FormCheck_business_flow_form_code = new Guid(businessFlowFormCodesGroup[i]);
                formCheck.F_FormCheck_isFirstSubmit = false;
                formCheck.F_FormCheck_checkPerson = Context.UIContext.Current.UserCode;//当前登录用户Guid
                formCheck.F_FormCheck_checkDate = now;
                formCheck.F_FormCheck_state = Convert.ToInt32(checkStatus);
                formCheck.F_FormCheck_content = checkInfo;
                formCheck.F_FormCheck_isDelete = false;
                formCheck.F_FormCheck_creator = Context.UIContext.Current.UserCode;//当前登录用户Guid
                formCheck.F_FormCheck_createTime = now;

                formChecks.Add(formCheck);
            }

            int status = _formCheckWCF.CheckForm(formChecks,fkType);

            if (status == 1)
            {
                CommonService.Model.FlowManager.P_Business_flow businessFlow = _bussinessFlowWCF.Get(new Guid(businessFlowCode));
                if (businessFlow.P_Business_state == Convert.ToInt32(BusinessFlowStatus.已结束))
                {
                    //保存成功提示固定写法
                    return Json(TipHelper.JsonData("审核表单成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshGrandpa));
                }
                else
                {
                    //保存成功提示固定写法
                    return Json(TipHelper.JsonData("审核表单成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
                }
            }
            else if (status == 2)
            {               
                return Json(TipHelper.JsonData("'预期收益表单'尚未裁定</br>不可以进行审核！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("没有符合条件可以审核的表单！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
    }
}