using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.TypicalCase.Controllers
{
    public class TypicalCaseController : BaseController
    {
        private readonly ICommonService.CaseManager.IB_Case_Typicalcase _typicalCaseWCF;
        private readonly ICommonService.IC_Region _regionWCF;
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow_form _businessFlowFormWCF;
        private readonly ICommonService.IC_Court _courtWCF;
        //
        // GET: /TypicalCase/TypicalCase/
        public TypicalCaseController()
        {
            #region 服务初始化
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
            _typicalCaseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case_Typicalcase>("B_Case_TypicalcaseWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            _businessFlowFormWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow_form>("Business_flow_formWCF");
            _courtWCF = ServiceProxyFactory.Create<ICommonService.IC_Court>("CourtWCF");
            #endregion
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(string businessflowCode, string flowformCode)
        {
            ViewBag.businessflowCode = businessflowCode;
            ViewBag.flowformCode = flowformCode;
            List<CommonService.Model.C_Region> typicalList = _regionWCF.GetAllList();
            ViewBag.typicalList = typicalList;         
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
            CommonService.Model.CaseManager.B_Case_Typicalcase typicalConditon = new CommonService.Model.CaseManager.B_Case_Typicalcase();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string flowname = Request.Params.Get("s_flow");
                if (flowname != null && flowname != "")
                {
                    typicalConditon.P_Businessflow_name = flowname;
                }
                string formname = Request.Params.Get("s_form");
                if (formname != null && formname != "")
                {
                    typicalConditon.P_Businessflow_form_name = formname;
                }
                string regionname = Request.Params.Get("i_region");
                if (regionname != null && regionname != "-1")
                {
                    typicalConditon.Region_name = regionname;
                }
                #endregion
            }
            string businessflowCode = Request.Params.Get("businessflowCode");
            if (businessflowCode != null && businessflowCode != "")
            {
                typicalConditon.P_Business_flow_code = new Guid(businessflowCode);
            }
            string flowformCode = Request.Params.Get("flowformCode");
            if (flowformCode != null && flowformCode != "")
            {
                typicalConditon.P_Business_flow_form_code = new Guid(flowformCode);
            }
            string courtName = Request.Params.Get("s_court");
            if (courtName != null && courtName != "")
            {
                typicalConditon.B_Case_court =courtName;
            }
            #endregion

            #region 分页数据处理

            //总记录数
            this.TotalRecordCount = _typicalCaseWCF.GetRecordCount(typicalConditon);
            //数据信息
            List<CommonService.Model.CaseManager.B_Case_Typicalcase> typicals = _typicalCaseWCF.GetListByPage(typicalConditon,
                "", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            //转化数据格式
            var result = from c in typicals
                         select new[] { 
                            c.B_Case_Typicalcase_code.ToString(),
                            c.B_Case_Typicalcase_code.ToString(),
                            c.B_Case_name,
                            c.B_Case_Typicalcase_title,
                            c.P_Businessflow_name,
                            c.P_Businessflow_form_name,
                            FilterHtml.StripHTML(c.B_Case_Typicalcase_description)
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

            #endregion
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="typicalCodes"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string typicalCodes)
        {
            if (_typicalCaseWCF.MutilyDelete(typicalCodes))
                return Json(TipHelper.JsonData("删除案例信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
            else
                return Json(TipHelper.JsonData("删除案例信息失败！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
        }
        /// <summary>
        /// 详细
        /// </summary>
        /// <param name="typicalCodes"></param>
        /// <returns></returns>
        public ActionResult Details(string typicalCode)
        {
            CommonService.Model.CaseManager.B_Case_Typicalcase model = _typicalCaseWCF.GetModelByCode(new Guid(typicalCode));
            CommonService.Model.CaseManager.B_Case caseModel = _caseWCF.GetModel(model.B_Case_code.Value);
            ViewBag.caseModel = caseModel;
            CommonService.Model.FlowManager.P_Business_flow flowModel = _bussinessFlowWCF.Get(model.P_Business_flow_code.Value);
            ViewBag.flowModel = flowModel;
            CommonService.Model.FlowManager.P_Business_flow_form flowformModel = _businessFlowFormWCF.Get(model.P_Business_flow_form_code.Value);
            ViewBag.flowformModel = flowformModel;
            return View(model);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="typicalCode"></param>
        /// <returns></returns>
        public ActionResult Edit(string typicalCode)
        {
            CommonService.Model.CaseManager.B_Case_Typicalcase model = _typicalCaseWCF.GetModelByCode(new Guid(typicalCode));
            CommonService.Model.CaseManager.B_Case caseModel = _caseWCF.GetModel(model.B_Case_code.Value);
            ViewBag.caseModel = caseModel;
            CommonService.Model.FlowManager.P_Business_flow flowModel = _bussinessFlowWCF.Get(model.P_Business_flow_code.Value);
            ViewBag.flowModel = flowModel;
            CommonService.Model.FlowManager.P_Business_flow_form flowformModel = _businessFlowFormWCF.Get(model.P_Business_flow_form_code.Value);
            ViewBag.flowformModel = flowformModel;
            return View(model);
        }
        /// <summary>
        /// 提交表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection form, CommonService.Model.CaseManager.B_Case_Typicalcase model)
        {
            if (_typicalCaseWCF.Update(model))
                return Json(TipHelper.JsonData("修改案例信息成功！", "", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            else
                return Json(TipHelper.JsonData("修改案例信息失败！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));

        }
    }
}