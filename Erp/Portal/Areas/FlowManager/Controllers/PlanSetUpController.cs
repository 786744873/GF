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
    /// 计划设定控制器
    /// </summary>
    public class PlanSetUpController : BaseController
    {
        private readonly ICommonService.FlowManager.IP_Business_flow_form _businessFlowFormWCF;

        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;
        public PlanSetUpController()
        {
            #region 服务初始化
            _businessFlowFormWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow_form>("Business_flow_formWCF");
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");

            #endregion
        }

        //
        // GET: /FlowManager/PlanSetUp/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建或修改
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessFlowFormCode">业务流程表单关联Guid</param>
        /// <param name="type">调用此Action来源：1代表案件；2代表商机；3代表客户</param>
        /// <returns></returns>
        public ActionResult Create(string businessFlowCode, string businessFlowFormCode,string type)
        {
            CommonService.Model.Customer.V_FormPlan formPlan = _businessFlowFormWCF.GetPlanSet(new Guid(businessFlowCode), new Guid(businessFlowFormCode));
            CommonService.Model.FlowManager.P_Business_flow flow = _bussinessFlowWCF.Get(new Guid(businessFlowCode));
            if (flow == null)
                flow = new CommonService.Model.FlowManager.P_Business_flow();
            ViewBag.flowmodel = flow;
            formPlan.Creator = Context.UIContext.Current.UserCode;

            ViewBag.type = type;
            return View(formPlan);
        }

        public ActionResult Operatecreate(string businessFlowCode, string businessFlowFormCodes,string type)
        {
            //查看批量设定的时候是多选还是单选一个，如果是单选一个，就把值给调出来，如果是多个则清空
            CommonService.Model.Customer.V_FormPlan formPlan = new CommonService.Model.Customer.V_FormPlan();  
            if (!businessFlowFormCodes.Contains(','))
            {
                formPlan = _businessFlowFormWCF.GetPlanSet(new Guid(businessFlowCode), new Guid(businessFlowFormCodes));
            }
         
              
            formPlan.BusinessFlowCode = new Guid(businessFlowCode);
            formPlan.MulityBusinessFlowFormCode = businessFlowFormCodes;
            CommonService.Model.FlowManager.P_Business_flow flow = _bussinessFlowWCF.Get(new Guid(businessFlowCode));
            if (flow == null)
                flow = new CommonService.Model.FlowManager.P_Business_flow();
            ViewBag.flowmodel = flow;

            ViewBag.type = type;
            return View(formPlan);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="form"></param>
        /// <param name="formPlan"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.Customer.V_FormPlan formPlan)
        {
            string type=form["type"];
            string mainLawyerCode = form["mainLawyerlookup.Code"];
            string assistLawyerCodes = form["assistLawyermulitylookup.Code"];
            formPlan.MainLawyerCode = new Guid(mainLawyerCode);
            formPlan.AssistLawyerCodes = assistLawyerCodes;
            CommonService.Model.FlowManager.P_Business_flow flow = _bussinessFlowWCF.Get(new Guid(formPlan.BusinessFlowCode.ToString()));
            bool flag = true;
            if (formPlan.PlanStartTime == null) {
                formPlan.PlanStartTime = flow.P_Business_flow_planStartTime;
            }
            if (formPlan.PlanEndTime == null) {
                formPlan.PlanEndTime = flow.P_Business_flow_planEndTime;
            }
            //取流程开始、结束
            if (DateTime.Compare(formPlan.PlanStartTime.Value, formPlan.PlanEndTime.Value) <= 0)
            {
                #region
                if (!string.IsNullOrEmpty(formPlan.PlanStartTime.ToString()))
                {
                    if (DateTime.Compare(Convert.ToDateTime(formPlan.PlanStartTime), Convert.ToDateTime(flow.P_Business_flow_planStartTime)) <0 || DateTime.Compare(Convert.ToDateTime(formPlan.PlanStartTime), Convert.ToDateTime(flow.P_Business_flow_planEndTime)) >0)
                    {
                        flag = false;
                    }
                }
                if (!string.IsNullOrEmpty(formPlan.PlanEndTime.ToString()))
                {
                    if (DateTime.Compare(Convert.ToDateTime(formPlan.PlanEndTime), Convert.ToDateTime(flow.P_Business_flow_planStartTime)) < 0 || DateTime.Compare(Convert.ToDateTime(formPlan.PlanEndTime), Convert.ToDateTime(flow.P_Business_flow_planEndTime))> 0)
                    {
                        flag = false;
                    }
                }
                #endregion
                if (flag)
                {
                    bool isSuccess = _businessFlowFormWCF.SavePlanSet(formPlan,type);
                    if (isSuccess)
                    {
                        //保存成功提示固定写法
                        return Json(TipHelper.JsonData("保存计划设定成功", "iframe_businessFlowForm", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshIframeChildren));
                    }
                    else
                    {
                        //保存失败固定写法
                        return Json(TipHelper.JsonData("保存计划设定失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                    }
                }
                else
                {
                    return Json(TipHelper.JsonData("时间超出了流程的计划开始和结束时间！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
            }else
            {
                return Json(TipHelper.JsonData("计划开始时间不能大于计划结束时间，<br>并且不能超出流程的计划开始和结束的<br>时间范围！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="form"></param>
        /// <param name="formPlan"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult OperateSave(FormCollection form, CommonService.Model.Customer.V_FormPlan formPlan)
        {
            string type=form["type"];
            string mainLawyerCode = form["mainLawyerlookup.Code"];
            string assistLawyerCodes = form["assistLawyermulitylookup.Code"];
            formPlan.MainLawyerCode = new Guid(mainLawyerCode);
            formPlan.AssistLawyerCodes = assistLawyerCodes;
            CommonService.Model.FlowManager.P_Business_flow flow = _bussinessFlowWCF.Get(new Guid(formPlan.BusinessFlowCode.ToString()));
            bool flag = true;
            if (DateTime.Compare(formPlan.PlanStartTime.Value, formPlan.PlanEndTime.Value) < 0)
            {
                #region
                if (!string.IsNullOrEmpty(formPlan.PlanStartTime.ToString()))
                {
                    if (DateTime.Compare(Convert.ToDateTime(formPlan.PlanStartTime), Convert.ToDateTime(flow.P_Business_flow_planStartTime)) < 0 || DateTime.Compare(Convert.ToDateTime(formPlan.PlanStartTime), Convert.ToDateTime(flow.P_Business_flow_planEndTime)) > 0)
                    {
                        flag = false;
                    }
                }
                if (!string.IsNullOrEmpty(formPlan.PlanEndTime.ToString()))
                {
                    if (DateTime.Compare(Convert.ToDateTime(formPlan.PlanEndTime), Convert.ToDateTime(flow.P_Business_flow_planStartTime)) < 0 || DateTime.Compare(Convert.ToDateTime(formPlan.PlanEndTime), Convert.ToDateTime(flow.P_Business_flow_planEndTime)) > 0)
                    {
                        flag = false;
                    }
                }
                #endregion
                if (flag)
                {
                    bool isSuccess = _businessFlowFormWCF.OperateSavePlanSet(formPlan,type);
                    if (isSuccess)
                    {
                        //保存成功提示固定写法
                        return Json(TipHelper.JsonData("保存计划设定成功", "iframe_businessFlowForm", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshIframeChildren));
                    }
                    else
                    {
                        //保存失败固定写法
                        return Json(TipHelper.JsonData("保存计划设定失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                    }
                }
                else
                {
                    return Json(TipHelper.JsonData("时间超出了流程的计划开始和结束时间！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
            }else
            {
                return Json(TipHelper.JsonData("计划开始时间不能大于计划结束时间，<br>并且不能超出流程的计划开始和结束的<br>时间范围！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

    }
}