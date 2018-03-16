using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.FlowManager.Controllers
{
    /// <summary>
    /// 业务流程关联表单控制器
    /// </summary>
    public class BusinessFlowFormController : BaseController
    {
        private readonly ICommonService.FlowManager.IP_Business_flow_form _businessFlowFormWCF;
        private readonly ICommonService.Customer.IV_User _vUserWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;

        public BusinessFlowFormController()
        {
            #region 服务初始化
            _businessFlowFormWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow_form>("Business_flow_formWCF");
            _vUserWCF = ServiceProxyFactory.Create<ICommonService.Customer.IV_User>("VUserWCF");
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            #endregion
        }

        //
        // GET: /FlowManager/BusinessFlowForm/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 业务流程关联所有表单Action(已配置表单Action)
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public ActionResult BusinessFlowRelationFormList(string businessFlowCode)
        {
            List<CommonService.Model.FlowManager.P_Business_flow_form> businessFlowForms;
            if (businessFlowCode == "{sid_Iterm}" || businessFlowCode == "" || businessFlowCode == "{sid_item}")
            {
                businessFlowForms = new List<CommonService.Model.FlowManager.P_Business_flow_form>();
            }
            else
            {
                businessFlowForms = _businessFlowFormWCF.GetBusinessFlowForms(new Guid(businessFlowCode));
            }
            return View(businessFlowForms);
        }

        /// <summary>
        /// 业务流程关联所有表单Action(多选)(提交表单或者审核表单多选Action)
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public ActionResult MulityBusinessFlowRelationFormList(string businessFlowCode, string sourceType)
        {
            List<CommonService.Model.FlowManager.P_Business_flow_form> businessFlowForms = _businessFlowFormWCF.GetEffectiveBusinessFlowForms(new Guid(businessFlowCode));
            ViewBag.SourceType = sourceType;
            if (sourceType != "submitform")
            {
                ViewBag.AllowCheckForms = AllowCheckForms(new Guid(businessFlowCode));
            }
            else
            {
                List<CommonService.Model.Customer.V_User> V_CheckForms = new List<CommonService.Model.Customer.V_User>();
                ViewBag.AllowCheckForms = V_CheckForms;
            }

            return View(businessFlowForms);
        }

        /// <summary>
        /// 增加业务流程表单
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="formCode">表单Guid</param>
        /// <param name="type">1、案件  2、商机  3、客户</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddBusinessFlowForm(string businessFlowCode, string formCode, string isDefault, int type)
        {
            string[] strbu = formCode.Split(',');
            int p_Business_flow_form_id = 0;
            CommonService.Model.FlowManager.P_Business_flow businessFlow = _bussinessFlowWCF.Get(new Guid(businessFlowCode));
            foreach (var item in strbu)
            {
                if (item == "") continue;

                bool isSuccess = _businessFlowFormWCF.ExistsByBusinessflowCodeAndFormCode(new Guid(businessFlowCode), new Guid(item));
                if (isSuccess)
                {
                    return Json(TipHelper.JsonData("右侧已配置表单中已存在该表单！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
                else
                {
                    //排序列在业务访问层中处理
                    CommonService.Model.FlowManager.P_Business_flow_form businessFlowForm = new CommonService.Model.FlowManager.P_Business_flow_form();
                    businessFlowForm.P_Business_flow_form_code = Guid.NewGuid();
                    businessFlowForm.P_Business_flow_code = new Guid(businessFlowCode);
                    businessFlowForm.F_Form_code = new Guid(item);
                    businessFlowForm.P_Business_flow_form_isDefault = isDefault == "1" ? 1 : 0;
                    businessFlowForm.P_Business_flow_form_state = Convert.ToInt32(BusinessFlowStatus.未开始);
                    businessFlowForm.P_Business_flow_form_status = Convert.ToInt32(FormStatusEnum.未提交);
                    businessFlowForm.P_Business_flow_form_isdelete = 0;
                    businessFlowForm.P_Business_flow_form_creator = Context.UIContext.Current.UserCode;
                    businessFlowForm.P_Business_flow_form_createTime = DateTime.Now;
                    businessFlowForm.P_Business_flow_form_isPlan = false;

                    p_Business_flow_form_id += _businessFlowFormWCF.Add(businessFlowForm, type);


                }
            }
            if (p_Business_flow_form_id > 0)
            {//成功
                return Json(TipHelper.JsonData("右移左侧办案阶段选中表单成功！", "iframe_flowForm,iframe_businessFlowForm", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("右移左侧办案阶段选中表单失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }

        }

        /// <summary>
        /// 删除业务流程关联表单
        /// </summary>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <param name="type">调用此Action来源类型：1为案件；2为商机；3为客户</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteBusinessFlowForm(string businessFlowFormCode,string type)
        {
            if (!_businessFlowFormWCF.GetisNoDefault(businessFlowFormCode))
            { //必填表单不能删除
                return Json(TipHelper.JsonData("必填表单不可删除！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            else
            {
                bool flag = _businessFlowFormWCF.Delete(businessFlowFormCode, int.Parse(type));
                if (flag)
                {//成功
                    return Json(TipHelper.JsonData("删除已选中配置表单成功！", "iframe_flowForm,iframe_businessFlowForm", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
                }
                else
                {//失败
                    return Json(TipHelper.JsonData("删除已选中配置表单失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
            }
        }

        /// <summary>
        /// 向前移动业务流程关联表单Action
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MoveForward(string businessFlowCode, string businessFlowFormCode)
        {
            bool isSuccess = _businessFlowFormWCF.MoveForward(new Guid(businessFlowCode), new Guid(businessFlowFormCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("上移表单成功！", "iframe_businessFlowForm", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("上移表单失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 向后移动业务流程关联表单Action
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessFlowFormCode">业务流程关联表单Guid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MoveBackward(string businessFlowCode, string businessFlowFormCode)
        {
            bool isSuccess = _businessFlowFormWCF.MoveBackward(new Guid(businessFlowCode), new Guid(businessFlowFormCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("下移表单成功！", "iframe_businessFlowForm", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("下移表单失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 检查当前用户是否有"审核表单"的权限
        /// </summary>
        /// <param name="businessFlowCode"></param>
        /// <returns></returns>
        private List<CommonService.Model.Customer.V_User> AllowCheckForms(Guid businessFlowCode)
        {
            /**
             * author:hety 
             * date:2015-06-19
             * description:
             * (1)、当前登录用户，只可以审核当前业务流程关联表单中，审核人为自己的表单
             **/

            List<CommonService.Model.Customer.V_User> V_CheckForms = _vUserWCF.GetCheckOwnFormsByUser(businessFlowCode, Context.UIContext.Current.UserCode.Value);

            return V_CheckForms;
        }

    }
}