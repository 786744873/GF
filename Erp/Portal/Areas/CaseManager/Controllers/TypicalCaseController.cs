using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.CaseManager.Controllers
{
    public class TypicalCaseController : BaseController
    {
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow_form _businessFlowFormWCF;
        private readonly ICommonService.CaseManager.IB_Case_link _caselinkWCF;
        private readonly ICommonService.CaseManager.IB_Case_Typicalcase _typicalCaseWCF;
        public TypicalCaseController()
        {
            #region 服务初始化
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            _businessFlowFormWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow_form>("Business_flow_formWCF");
            _caselinkWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case_link>("Case_linkWCF");
            _typicalCaseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case_Typicalcase>("B_Case_TypicalcaseWCF");
            #endregion

        }
        //
        // GET: /CaseManager/TypicalCase/
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="caseCode">案件code</param>
        /// <param name="businessflowCode">业务流程code </param>
        /// <param name="businessflowFormCode">业务流程关联表单code</param>
        /// <returns></returns>
        public ActionResult DefauleLayout(string caseCode,string businessflowCode,string businessflowFormCode)
        {
            CommonService.Model.CaseManager.B_Case caseModel = _caseWCF.GetModel(new Guid(caseCode));
            ViewBag.caseModel = caseModel;
            CommonService.Model.FlowManager.P_Business_flow flowModel = _bussinessFlowWCF.Get(new Guid(businessflowCode));
            ViewBag.flowModel = flowModel;
            CommonService.Model.FlowManager.P_Business_flow_form flowformModel = _businessFlowFormWCF.Get(new Guid(businessflowFormCode));
            ViewBag.flowformModel = flowformModel;

            CommonService.Model.CaseManager.B_Case_Typicalcase model = new CommonService.Model.CaseManager.B_Case_Typicalcase();
            model.B_Case_Typicalcase_code = Guid.NewGuid();
            model.B_Case_code = new Guid(caseCode);
            model.P_Business_flow_code = new Guid(businessflowCode);
            model.P_Business_flow_form_code = new Guid(businessflowFormCode);
            model.B_Case_Typicalcase_isDelete = 0;
            model.B_Case_Typicalcase_creator = Context.UIContext.Current.UserCode;
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection form, CommonService.Model.CaseManager.B_Case_Typicalcase typical)
        {
            string a = form["ckeditdata"];
            typical.B_Case_Typicalcase_description = a;
            typical.B_Case_Typicalcase_createTime = DateTime.Now;
            if (_typicalCaseWCF.Add(typical) > 0)
            {
                return Json(TipHelper.JsonData("保存案例信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {
                return Json(TipHelper.JsonData("保存案例信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

	}
}