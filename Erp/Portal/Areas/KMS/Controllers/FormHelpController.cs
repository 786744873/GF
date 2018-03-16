using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.KMS.Controllers
{
    public class FormHelpController : BaseController
    {
        private readonly ICommonService.KMS.IK_PorblemAndResources_LinkCase _porblemAndResources_LinkCaseWCF;
        private readonly ICommonService.KMS.IK_Resources _resourcesWCF;
        private readonly ICommonService.KMS.IK_Problem _problemWCF;
        private readonly ICommonService.FlowManager.IP_Flow _flowWCF;
        private readonly ICommonService.CustomerForm.IF_Form _formWCF;
        private readonly ICommonService.CaseManager.IB_Case_Typicalcase _typicalCaseWCF;
        private readonly ICommonService.CaseManager.IB_Case _b_caseWCF;
        private readonly ICommonService.IC_Court _courtWCF;
        private readonly ICommonService.FlowManager.IP_Flow_form _flowformWCF;
        private readonly ICommonService.IC_Region _regionWCF;
        private readonly ICommonService.KMS.IK_Knowledge _knowledgeWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow _businessFlowWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow_form _businessFlowFormWCF;
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;
        public FormHelpController()
        {
            #region 服务初始化
            _resourcesWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Resources>("K_ResourcesWCF");
            _porblemAndResources_LinkCaseWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_PorblemAndResources_LinkCase>("K_PorblemAndResources_LinkCaseWCF");
            _problemWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Problem>("K_ProblemWCF");
            _flowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow>("FlowWCF");
            _formWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_Form>("FormWCF");
            _typicalCaseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case_Typicalcase>("B_Case_TypicalcaseWCF");
            _b_caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
            _courtWCF = ServiceProxyFactory.Create<ICommonService.IC_Court>("CourtWCF");
            _flowformWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow_form>("Flow_formWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
            _knowledgeWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Knowledge>("K_KnowledgeWCF");
            _businessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
            _businessFlowFormWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow_form>("Business_flow_formWCF");

            #endregion

        }
        //
        // GET: /KMS/FormHelp/
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 表单帮助页面
        /// </summary>
        /// <param name="court">法院code</param>
        /// <param name="flow">流程code</param>
        /// <param name="form">表单code</param>
        /// <param name="caseArea">案件区域code</param>
        /// <returns></returns>
        public ActionResult DefaultLayout(string court, string flow, string form, string caseArea)
        {            
            ViewBag.businessFlow = flow;
            ViewBag.businessForm = form;
            CommonService.Model.CaseManager.B_Case_Typicalcase typicalConditon = new CommonService.Model.CaseManager.B_Case_Typicalcase();
            typicalConditon.P_Business_flow_code = new Guid(flow);
            typicalConditon.P_Business_flow_form_code = new Guid(form);
            CommonService.Model.FlowManager.P_Business_flow flowModel1 = _businessFlowWCF.Get(new Guid(flow));
            ViewBag.caseCode = flowModel1.P_Fk_code.Value.ToString();
            flow = flowModel1.P_Flow_code.ToString();
            CommonService.Model.FlowManager.P_Business_flow_form flowformModel = _businessFlowFormWCF.Get(new Guid(form));
            form = flowformModel.F_Form_code.ToString();          
            if (!string.IsNullOrEmpty(flow))
            {
                CommonService.Model.FlowManager.P_Flow flowModel = _flowWCF.GetModel(new Guid(flow));
                if (flowModel != null)
                {
                    ViewBag.flowName = flowModel.P_Flow_name;
                }
            }
            if (!string.IsNullOrEmpty(form))
            {
                CommonService.Model.CustomerForm.F_Form formModel = _formWCF.Get(new Guid(form));
                if (formModel != null)
                {
                    ViewBag.formName = formModel.F_Form_chineseName;
                }
            }
            CommonService.Model.KMS.K_PorblemAndResources_LinkCase condtion = new CommonService.Model.KMS.K_PorblemAndResources_LinkCase();
            if (!string.IsNullOrEmpty(court))
            {
                string courts = "";
                string[] courtitems = court.Split(',');
                for (int i = 0; i < courtitems.Count(); i++)
                {
                    courts += "'" + courtitems[i] + "',";
                }
                if (courts.Length > 0)
                {
                    courts = courts.Substring(0, courts.Length - 1);
                }
                condtion.K_ProblemAndResources_LinkCase_CourtListcode = courts;
            }
            ViewBag.court = court;
            ViewBag.flow = flow;
            ViewBag.form = form;
            ViewBag.caseArea = caseArea;
            if (!string.IsNullOrEmpty(flow))
                condtion.K_ProblemAndResources_LinkCase_BusinessFlowcode = new Guid(flow);
            if (!string.IsNullOrEmpty(form))
                condtion.K_ProblemAndResources_LinkCase_Formcode = new Guid(form);
            condtion.K_ProblemAndResources_LinkCase_type = 1;//得到资源列表
            List<CommonService.Model.KMS.K_PorblemAndResources_LinkCase> listR = _porblemAndResources_LinkCaseWCF.GetListByModel(condtion);
            condtion.K_ProblemAndResources_LinkCase_type = 2;//得到问题列表
            List<CommonService.Model.KMS.K_PorblemAndResources_LinkCase> listP = _porblemAndResources_LinkCaseWCF.GetListByModel(condtion);
            condtion.K_ProblemAndResources_LinkCase_type = 3;//得到视频列表
            List<CommonService.Model.KMS.K_PorblemAndResources_LinkCase> listM = _porblemAndResources_LinkCaseWCF.GetListByModel(condtion);
            string Resources = "";
            foreach (var item in listR)
            {
                Resources += "'" + item.C_FK_code + "',";
            }
            if (Resources.Length > 0)
            {
                Resources = Resources.Substring(0, Resources.Length - 1);
                string types = "";
                types += "'" + Convert.ToInt32(ResourcesTypeEnum.excel).ToString() + "',";
                types += "'" + Convert.ToInt32(ResourcesTypeEnum.pdf).ToString() + "',";
                types += "'" + Convert.ToInt32(ResourcesTypeEnum.ppt).ToString() + "',";
                types += "'" + Convert.ToInt32(ResourcesTypeEnum.word).ToString() + "',";
                types += "'" + Convert.ToInt32(ResourcesTypeEnum.图片).ToString() + "',";
                types = types.Substring(0, types.Length - 1);
                List<CommonService.Model.KMS.K_Resources> listResources = _resourcesWCF.GetListByCodeList(Resources, types);
                ViewBag.listResources = listResources;
            }
            string Problems = "";
            foreach (var item in listP)
            {
                Problems += "'" + item.C_FK_code + "',";
            }
            if (Problems.Length > 0)
            {
                Problems = Problems.Substring(0, Problems.Length - 1);
                List<CommonService.Model.KMS.K_Problem> listProblem = _problemWCF.GetListByCodeList(Problems);
                ViewBag.listProblem = listProblem;
            }
            string Movies = "";
            foreach (var item in listM)
            {
                Movies += "'" + item.C_FK_code + "',";
            }
            if (Movies.Length > 0)
            {
                Movies = Movies.Substring(0, Movies.Length - 1);
                List<CommonService.Model.KMS.K_Resources> listMovies = _resourcesWCF.GetListByCodeList(Movies, Convert.ToInt32(ResourcesTypeEnum.视频).ToString());
                ViewBag.listMovies = listMovies;
            }
            List<CommonService.Model.CaseManager.B_Case_Typicalcase> listTypicals = _typicalCaseWCF.GetListByPage(typicalConditon,
                "", 0, 10000);
            ViewBag.listTypicals = listTypicals;
            return View();
        }
        /// <summary>
        /// 创建典型案例
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="form"></param>
        /// <param name="caseArea"></param>
        /// <returns></returns>
        public ActionResult CreateTypical(string caseCode, string flowCode, string formCode)
        {
            CommonService.Model.KMS.K_PorblemAndResources_LinkCase linkModel = new CommonService.Model.KMS.K_PorblemAndResources_LinkCase();
            if (!string.IsNullOrEmpty(flowCode))
            {
                CommonService.Model.FlowManager.P_Business_flow pFlow = _businessFlowWCF.Get(new Guid(flowCode));
                linkModel.K_ProblemAndResources_LinkCase_BusinessFlowcode = pFlow.P_Flow_code.Value;
            }
            if (!string.IsNullOrEmpty(formCode))
            {
                CommonService.Model.FlowManager.P_Business_flow_form pForm = _businessFlowFormWCF.Get(new Guid(formCode));
                linkModel.K_ProblemAndResources_LinkCase_Formcode = pForm.F_Form_code.Value;
            }
            InitializationPageParameter(linkModel.K_ProblemAndResources_LinkCase_BusinessFlowcode.ToString());
            ViewBag.linkModel = linkModel;
            CommonService.Model.CaseManager.B_Case caseModel = new CommonService.Model.CaseManager.B_Case();
            caseModel = _b_caseWCF.GetModel(new Guid(caseCode));
            ViewBag.caseModel = caseModel;
            CommonService.Model.CaseManager.B_Case_Typicalcase model = new CommonService.Model.CaseManager.B_Case_Typicalcase();
            model.B_Case_Typicalcase_code = Guid.NewGuid();
            model.B_Case_code = new Guid(caseCode);
            model.P_Business_flow_code = new Guid(flowCode);
            model.P_Business_flow_form_code = new Guid(formCode);
            model.B_Case_Typicalcase_isDelete = 0;
            model.B_Case_Typicalcase_creator = Context.UIContext.Current.UserCode;
            return View(model);
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
            typical.B_Case_Typicalcase_description = form["B_Case_Typicalcase_description"];
            typical.B_Case_Typicalcase_title = form["B_Case_Typicalcase_title"];
            typical.B_Case_Typicalcase_createTime = DateTime.Now;

            if (_typicalCaseWCF.Add(typical) > 0)
                return Json(TipHelper.JsonData("保存成功！", "", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            else
                return Json(TipHelper.JsonData("保存失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
        }
        public ActionResult Details(string typicalCode)
        {
            CommonService.Model.CaseManager.B_Case_Typicalcase model = _typicalCaseWCF.GetModelByCode(new Guid(typicalCode));
            CommonService.Model.CaseManager.B_Case caseModel = _caseWCF.GetModel(model.B_Case_code.Value);
            ViewBag.caseModel = caseModel;
            CommonService.Model.FlowManager.P_Business_flow flowModel = _businessFlowWCF.Get(model.P_Business_flow_code.Value);
            ViewBag.flowModel = flowModel;
            CommonService.Model.FlowManager.P_Business_flow_form flowformModel = _businessFlowFormWCF.Get(model.P_Business_flow_form_code.Value);
            ViewBag.flowformModel = flowformModel;
            return View(model);
        }
        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter(string flowCode)
        {
            List<CommonService.Model.KMS.K_Knowledge> knowledgeList = _knowledgeWCF.GetAllList();
            ViewBag.KnowlwedgeList = knowledgeList;
            //法院集合
            List<CommonService.Model.C_Court> CourtItems = _courtWCF.GetAllList();
            string userHtml = "";
            userHtml += "<option value='all'>全部</option>";
            foreach (var court in CourtItems)
            {
                userHtml += "<option value=" + court.C_Court_code + ">" + court.C_Court_name + "</option>";
            }
            ViewBag.userhtml = userHtml;
            //业务流程集合
            List<CommonService.Model.FlowManager.P_Flow> FlowItems = _flowWCF.GetListByFlowType(Convert.ToInt32(FlowTypeEnum.案件));
            ViewBag.flowItems = FlowItems;
            List<CommonService.Model.FlowManager.P_Flow_form> formItems = _flowformWCF.GetListByFlowCode(new Guid(flowCode));
            ViewBag.formItem = formItems;
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.regionList = regionList;
        }
    }
}