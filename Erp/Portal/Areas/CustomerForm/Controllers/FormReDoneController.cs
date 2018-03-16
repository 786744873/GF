using CommonService.Common;
using Context;
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
    /// 表单重做控制器
    /// </summary>
    public class FormReDoneController : BaseController
    {
        private readonly ICommonService.CustomerForm.IF_FormProperty _formPropertyWCF;
        private readonly ICommonService.CustomerForm.IF_FormReDone _formReDoneWCF;
        private readonly ICommonService.Customer.IV_User _vUserWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow_form _businessFlowFormWCF;

        public FormReDoneController()
        {
            _formPropertyWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormProperty>("FormPropertyWCF");
            _formReDoneWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormReDone>("FormReDoneWCF");
            _vUserWCF = ServiceProxyFactory.Create<ICommonService.Customer.IV_User>("VUserWCF");
            _businessFlowFormWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow_form>("Business_flow_formWCF");
        }

        //
        // GET: /CustomerForm/FormReDone/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 生成表单重做局部视图Action
        /// </summary>
        /// <param name="formUiType">表单UI类型</param>
        /// <param name="fkType">流程类型(案件或者商机)</param>
        /// <param name="pkCode">案件guid或者商机guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid(可能属于"已作废的表单")</param>
        /// <param name="formStatus">表单状态(可能属于"已作废的表单")</param>
        /// <param name="isSwitchFormHistoryRecordUrl">此触发是否为从表单重做历史记录中切换过来的(1代表是，0代表否),如果为是，则默认打开"表单重做历史记录"</param>
        /// <returns></returns>
        public PartialViewResult GenerateReDoneForm(string formUiType, string fkType, string pkCode, string businessFlowCode, string formCode, string businessFlowFormCode, int formStatus, int isSwitchFormHistoryRecordUrl)
        {
            ViewBag.FormUiType = formUiType;
            ViewBag.fkType = fkType;
            ViewBag.pkCode = pkCode;
            ViewBag.BusinessFlowCode = businessFlowCode;
            ViewBag.FormCode = formCode;            
            ViewBag.BusinessFlowFormCode = businessFlowFormCode;
            ViewBag.FormStatus = formStatus;

            string effectData = this.GetEffectBusinessFlowFormCode(new Guid(businessFlowCode), new Guid(formCode));//有效的"业务流程表单关联Guid"+"表单状态值"
            string effectBusinessFlowFormCode = String.Empty;//有效的"业务流程表单关联Guid"
            int effectBusinessFlowFormStatus = Convert.ToInt32(FormStatusEnum.已作废);//有效的"表单状态值"(默认"已作废")

            if (!string.IsNullOrEmpty(effectData))
            {
                string[] effectDataGroup = effectData.Split(',');
                effectBusinessFlowFormCode = effectDataGroup[0];
                effectBusinessFlowFormStatus = Convert.ToInt32(effectDataGroup[1]);
            }

            ViewBag.EffectBusinessFlowFormCode = effectBusinessFlowFormCode;
            ViewBag.defaultIsOpenFormHistoryRecord = isSwitchFormHistoryRecordUrl == 1 ? true : false;//是否默认打开"表单重做历史记录"标识
            if (Request.QueryString["isView"] != null)
            {//这种情况，代表是从查看页面中加载的局部视图，因此不可以有"重做表单"按钮的权限
                ViewBag.IsHasReDoneFormPower = false;
            }
            else
            {
                ViewBag.IsHasReDoneFormPower = this.ExistsHasReDoneFormPower(effectBusinessFlowFormStatus, new Guid(effectBusinessFlowFormCode));
            }
           
            ViewBag.IsHasViewHistoryFormPower = this.ExistsHasViewHistoryFormPower(new Guid(businessFlowCode), new Guid(formCode));

            return PartialView("ReDoneFormPartial");
        }

        /// <summary>
        /// 确认重做表单
        /// </summary>
        /// <param name="fkType">流程类型(案件或商机或客户)</param>
        /// <param name="pkCode">案件guid或者商机guid或客户guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>
        public ActionResult ConfirmReDoneForm(string fkType,string pkCode, string formCode, string businessFlowCode, string businessFlowFormCode)
        {
            Guid newBusinessFlowCode = Guid.NewGuid();//新生成的业务流程表单关联Guid
            int status = _formReDoneWCF.ReDoneForm(Convert.ToInt32(fkType), new Guid(formCode), new Guid(businessFlowCode), new Guid(businessFlowFormCode),newBusinessFlowCode,
                UIContext.Current.UserCode.Value);

            string forwardUrl = "/CustomerForm/FormPropertyValue/LayoutRootTabs?businessFlowCode=" + businessFlowCode + "&pkCode=" + pkCode + "&fkType=" + fkType + "&isFromReDoneFormNav=1&reDoneBusinessFormCode=" + newBusinessFlowCode.ToString();
            if (int.Parse(fkType) == Convert.ToInt32(FlowTypeEnum.客户))
            {
                forwardUrl = "/CustomerForm/CustomerFormPropertyValue/LayoutRootTabs?businessFlowCode=" + businessFlowCode + "&pkCode=" + pkCode + "&fkType=" + fkType + "&isFromReDoneFormNav=1&reDoneBusinessFormCode=" + newBusinessFlowCode.ToString();
            }
            if (status == 1)
            {
                return Json(TipHelper.JsonData("重做表单成功！", forwardUrl, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ParentPageGoAnotherPage));
            }
            else
            {
                return Json(TipHelper.JsonData("重做表单失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }

        }

        /// <summary>
        /// 重做表单历史记录
        /// </summary>
        /// <param name="formUiType">自定义表单UI类型("普通编辑表单"或"含有主子结构的表单"或......)</param>
        /// <param name="fkType">流程类型(案件或商机)</param>
        /// <param name="pkCode">案件guid或者商机guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <param name="thisBusinessFlowFormCode">当前业务流程表单关联Guid</param>
        /// <returns></returns>
        public ActionResult FormHistoryRecord(string formUiType, string fkType, string pkCode, string businessFlowCode, string formCode, string thisBusinessFlowFormCode)
        {
            if (formUiType == "1")
            {//普通编辑表单
                return RedirectToAction("EditFormHistoryRecord", new { fkType = fkType, pkCode = pkCode, businessFlowCode = businessFlowCode, formCode = formCode, thisBusinessFlowFormCode = thisBusinessFlowFormCode });
            }
            else if (formUiType == "3")
            {//含有主子结构的表单
                return RedirectToAction("HeadAndMulityItemFormHistoryRecord", new { fkType = fkType, pkCode = pkCode, businessFlowCode = businessFlowCode, formCode = formCode, thisBusinessFlowFormCode = thisBusinessFlowFormCode });
            }
            return View();
        }

        /// <summary>
        /// 编辑表单重做表单历史记录
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <param name="thisBusinessFlowFormCode">当前业务流程表单关联Guid</param>
        /// <param name="fkType">流程类型(案件或商机)</param>
        /// <param name="pkCode">案件guid或者商机guid</param>
        /// <returns></returns>
        public ActionResult EditFormHistoryRecord(string fkType, string pkCode, string businessFlowCode, string formCode, string thisBusinessFlowFormCode)
        {
            ViewBag.FkType = fkType;
            ViewBag.PkCode = pkCode;
            ViewBag.BusinessFlowCode = businessFlowCode;
            ViewBag.FormCode = formCode;
            ViewBag.ThisBusinessFlowFormCode = thisBusinessFlowFormCode;
            ViewBag.FormUiType = "1";//代表普通编辑表单

            //获取表单属性及其属性值
            List<CommonService.Model.CustomerForm.F_FormProperty> formPropertys = _formPropertyWCF.GetEditFormHistorRecord(new Guid(businessFlowCode), new Guid(formCode));

            return View("FormHistoryRecord", formPropertys);
        }

        /// <summary>
        /// 主子结构表单重做表单历史记录
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <param name="thisBusinessFlowFormCode">当前业务流程表单关联Guid</param>
        /// <param name="fkType">流程类型(案件或商机)</param>
        /// <param name="pkCode">案件guid或者商机guid</param>
        /// <returns></returns>
        public ActionResult HeadAndMulityItemFormHistoryRecord(string fkType, string pkCode, string businessFlowCode, string formCode, string thisBusinessFlowFormCode)
        {
            ViewBag.FkType = fkType;
            ViewBag.PkCode = pkCode;
            ViewBag.BusinessFlowCode = businessFlowCode;
            ViewBag.FormCode = formCode;
            ViewBag.ThisBusinessFlowFormCode = thisBusinessFlowFormCode;
            ViewBag.FormUiType = "3";//代表主子结构表单

            //获取表单头编辑属性及其属性值
            List<CommonService.Model.CustomerForm.F_FormProperty> editFormPropertys = _formPropertyWCF.GetHeadEditFormHistoryRecord(new Guid(businessFlowCode), new Guid(formCode));

            return View("FormHistoryRecord", editFormPropertys);
        }


        /// <summary>
        /// 获取有效的业务流程表单关联Guid,及其状态
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <returns>返回有效业务流程表单关联Guid</returns>
        private string GetEffectBusinessFlowFormCode(Guid businessFlowCode, Guid formCode)
        {
            return _businessFlowFormWCF.GetEffectBusinessFlowFormCode(businessFlowCode, formCode);
        }

        /// <summary>
        /// 检查当前登录用户是否有重做表单的权限(只针对当前有效表单)
        /// </summary>
        /// <param name="formStatus">表单状态</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <returns></returns>
        private bool ExistsHasReDoneFormPower(int formStatus, Guid businessFlowFormCode)
        {
            bool isHasReDonePower = false;//没有重做表单的权限

            /**
             * author:hety
             * date:2015-10-09
             * description:
             * (1)、如果为内置管理员，则只受状态权限的限制
             * (2)、只有表单状态为"未提交"或者"已通过"或者"未通过"时，才可能会有重做表单的权限
             * (3)、只有关联当前表单的"主办律师"和"协办律师"才可以有重做表单的权限
             * */

            if (Context.UIContext.Current.IsPreSetManager)
            {
                if (formStatus == Convert.ToInt32(FormStatusEnum.未提交) || formStatus == Convert.ToInt32(FormStatusEnum.未通过) || formStatus == Convert.ToInt32(FormStatusEnum.已通过))
                {
                    isHasReDonePower = true;
                }                
            }
            else
            {
                if (formStatus == Convert.ToInt32(FormStatusEnum.未提交) || formStatus == Convert.ToInt32(FormStatusEnum.未通过) || formStatus == Convert.ToInt32(FormStatusEnum.已通过))
                {
                    List<CommonService.Model.Customer.V_User> V_User = _vUserWCF.GetSaveOwnFormUsers(businessFlowFormCode);
                    var powerUserList = from allList in V_User
                                        where allList.UserCode == Context.UIContext.Current.UserCode
                                        select allList;
                    if (powerUserList.Count() != 0)
                    {
                        isHasReDonePower = true;//代表"允许当前登录用户重做"
                    }
                }
            }

            //isHasReDonePower = false;

            return isHasReDonePower;
        }

        /// <summary>
        /// 检查是否有查看"重做表单历史记录"的权限
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessFlowCode">表单Guid</param>
        /// <returns></returns>
        private bool ExistsHasViewHistoryFormPower(Guid businessFlowCode,Guid formCode)
        {
            //只有关联表单有重做时，才可以显示"查看历史记录"按钮
            bool isExists = false;
            isExists = _businessFlowFormWCF.ExistsRelDoneFormByBusinessflowCodeAndFormCode(businessFlowCode, formCode);

            //isExists = false;

            return isExists;
        }

	}
}