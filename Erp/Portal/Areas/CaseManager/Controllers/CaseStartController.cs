using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.CaseManager.Controllers
{
    /// <summary>
    /// 案件启动控制器
    /// </summary>
    public class CaseStartController : BaseController
    {
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;

        public CaseStartController()
        {
            #region 服务初始化
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            #endregion
        }

        //
        // GET: /CaseManager/CaseStart/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 布局Action
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="pkCode">关联Guid，如案件Guid</param>
        /// <returns></returns>
        public ActionResult DefaultLayout(string businessFlowCode, string pkCode, string fkType)
        {
            CommonService.Model.FlowManager.P_Business_flow BusinessFlows = _bussinessFlowWCF.Get(new Guid(businessFlowCode));
            ViewBag.BusinessFlowCode = businessFlowCode;
            ViewBag.PkCode = pkCode;
            ViewBag.FkType = fkType;
            return View(BusinessFlows);
        }

        /// <summary>
        ///提交"进入下一流程"Action
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult StartBusinessFlow(FormCollection form)
        {
            string fkType = form["fkType"];
            string startReason = form["P_Business_startReason"];
            string startBusinessFlowCodes = form["startBusinessFlows"];
            string[] startBusinessFlowCodesGroup = startBusinessFlowCodes.Split(',');
            DateTime now = DateTime.Now;

            List<CommonService.Model.FlowManager.P_Business_flow> businessFlows = new List<CommonService.Model.FlowManager.P_Business_flow>();

            for (int i = 0; i < startBusinessFlowCodesGroup.Length; i++)
            {
                CommonService.Model.FlowManager.P_Business_flow businessFlow = new CommonService.Model.FlowManager.P_Business_flow();          
                businessFlow.P_Business_flow_code = new Guid(startBusinessFlowCodesGroup[i]);
                businessFlow.P_Business_startReason = startReason;
                businessFlow.P_Business_startPerson = Context.UIContext.Current.UserCode;
                businessFlow.P_Business_startTime = now;
                businessFlow.P_Business_flow_factStartTime = now;
                businessFlow.P_Business_state = Convert.ToInt32(fkType)==Convert.ToInt32(FlowTypeEnum.案件) ? Convert.ToInt32(BusinessFlowStatus.正在进行) : Convert.ToInt32(BusinessFlowStatus.未开始);
                businessFlows.Add(businessFlow);
            }

            int status = _bussinessFlowWCF.StartBusinessFlow(businessFlows, fkType);

            if (status == 1)
            {
                string jsonData = Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件) ? "" : "申请";
                //保存成功提示固定写法
                return Json(TipHelper.JsonData(jsonData+"开启业务流程成功！", "iframe_childreBusinessFlow", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshGrandpa));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("没有符合条件可以开启的业务流程！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }


        /// <summary>
        ///商机审核流程Action
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CheckBusinessFlow(string businessFlowCode, string fkType)
        {
            List<CommonService.Model.FlowManager.P_Business_flow> businessFlows = new List<CommonService.Model.FlowManager.P_Business_flow>();
            CommonService.Model.FlowManager.P_Business_flow businessFlow = _bussinessFlowWCF.Get(new Guid(businessFlowCode));
            businessFlows.Add(businessFlow);
            int status = _bussinessFlowWCF.StartBusinessFlow(businessFlows, fkType);
            
            if (status == 1)
            {
                //保存成功提示固定写法
                return Json(TipHelper.JsonData("操作成功！", "iframe_childreBusinessFlow", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshIframeChildren));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("操作失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
	}
}