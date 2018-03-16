using CommonService.Common;
using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.CaseManager.Controllers
{
    public class CaseprogramController : Controller
    {
        //办案方案控制器
        //
        // GET: /CaseManager/Caseprogram/
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;
        private readonly ICommonService.CaseManager.IB_Case_plan _casesplanWCF;
        private readonly ICommonService.CaseManager.IB_Case_link _caselinkWCF;
        private readonly ICommonService.CaseManager.IB_Case_plan_Evidence _caseplanEvidenceWCF;
        private readonly ICommonService.IC_Parameters _parametersWCF;
        private readonly ICommonService.CaseManager.IB_Case_plan_Litigation _case_plan_litigationWCF;
        private readonly ICommonService.SysManager.IC_Role_Role_Power _roleRolePowerWCF;
        public CaseprogramController()
        {
            #region 服务初始化
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
            _casesplanWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case_plan>("Case_PlanWCF");
            _caselinkWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case_link>("Case_linkWCF");
            _caseplanEvidenceWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case_plan_Evidence>("Case_plan_EvidenceWCF");
            _parametersWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _case_plan_litigationWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case_plan_Litigation>("Case_plan_LitigationWCF");
            _roleRolePowerWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Role_Role_Power>("Role_Role_PowerWCF");
            #endregion
        }
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 办案方案页面初始化
        /// </summary>
        /// <param name="caseCode">关联案件GUID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string caseCode)
        {
            CommonService.Model.CaseManager.B_Case Case = _caseWCF.GetModel(new Guid(caseCode));
            Guid B_case_code = new Guid(caseCode);
            CommonService.Model.CaseManager.B_Case_plan caseplan = _casesplanWCF.GetModelByCode(B_case_code);
            //string casetypeid = Case.B_Case_type.ToString();//得到案件类型（钢材/混凝土。。）
            //string casetypename = _parametersWCF.GetModel(Convert.ToInt32(casetypeid)).C_Parameters_name;//得到案件类型的名称
            //int Childrentype_id = _parametersWCF.GetModelByParmentname(Convert.ToInt32(casetypeid), casetypename).C_Parameters_id;
            //List<CommonService.Model.CaseManager.B_Case_plan_Litigation> caseLitigations=_case_plan_litigationWCF.GetListByCasecodeAndParameterId(Childrentype_id,B_case_code);
            caseplan.B_Case_code = B_case_code;
            ViewBag.Case = Case;
            ViewBag.casecode = Case.B_Case_code;
            //ViewBag.caseLitigations=caseLitigations;

            #region 权限
            bool isHasSaveFormPower = false;
            List<CommonService.Model.SysManager.C_Role_Role_Power> roleRolePowers;
            if (Context.UIContext.Current.IsPreSetManager)
            {
                roleRolePowers = new List<CommonService.Model.SysManager.C_Role_Role_Power>();
                isHasSaveFormPower = true;
            }
            else
            {
                roleRolePowers = _roleRolePowerWCF.GetRolePowersByOrgPostUserCode(Context.UIContext.Current.OrgCode,
                    Context.UIContext.Current.UserCode,Context.UIContext.Current.PostCode);
                if (roleRolePowers.Where(p => p.C_Role_Power_id == 11).Count() != 0)
                {
                    isHasSaveFormPower = true;
                }
            }
            ViewBag.IsHasSaveFormPower = isHasSaveFormPower;
            #endregion

            return View(caseplan);
        }
        /// <summary>
        /// 提交办案方案表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.CaseManager.B_Case_plan caseplan)
        {
            int caseplanid = 0;
            Guid Court_code = new Guid(form["courtlookup.Code"]);//法院guid
            string B_Case_plan_plaintiff_Customer_code = form["customermulitylookup.Code"];//原告guid
            string B_Case_plan_plaintiff_Customer_name = form["customermulitylookup.Name"];//原告名称
            string B_Case_plan_defendant_Customer_code = form["rivallookupdefendant.Code"];//被告guid
            string B_Case_plan_defendant_Customer_name = form["rivallookupdefendant.Name"];//被告名称

            caseplan.B_Case_plan_Court_code = Court_code;
            caseplan.B_Case_plan_plaintiff_Customer_code = B_Case_plan_plaintiff_Customer_code;
            caseplan.B_Case_plan_plaintiff_Customer_name = B_Case_plan_plaintiff_Customer_name;
            caseplan.B_Case_plan_defendant_Customer_code = B_Case_plan_defendant_Customer_code;
            caseplan.B_Case_plan_defendant_Customer_name = B_Case_plan_defendant_Customer_name;
            #region 参照值处理
            List<CommonService.Model.CaseManager.B_Case_link> CaseLinks = new List<CommonService.Model.CaseManager.B_Case_link>();
            List<CommonService.Model.CaseManager.B_Case_plan_Evidence> Caseplan_Evences = new List<CommonService.Model.CaseManager.B_Case_plan_Evidence>();
            #region 客户集合
            string[] customerCodes = form["customermulitylookup.Code"].Split(',');
            foreach (var customer_code in customerCodes)
            {
                CommonService.Model.CaseManager.B_Case_link caselink = new CommonService.Model.CaseManager.B_Case_link();
                caselink.B_Case_code = caseplan.B_Case_code;
                caselink.C_FK_code = new Guid(customer_code);
                caselink.B_Case_link_type = Convert.ToInt32(CaselinkEnum.原告);
                caselink.B_Case_link_creator = Guid.NewGuid();
                caselink.B_Case_link_createTime = DateTime.Now;
                caselink.B_Case_link_isDelete = 0;

                CaseLinks.Add(caselink);
            }
            #endregion
            #region 被告
            CommonService.Model.CaseManager.B_Case_link thisPerson = new CommonService.Model.CaseManager.B_Case_link();
            thisPerson.B_Case_code = caseplan.B_Case_code;
            thisPerson.C_FK_code = new Guid(form["rivallookupdefendant.Code"].Trim());
            thisPerson.B_Case_link_type = Convert.ToInt32(form["rivallookupdefendant.Type"]);
            thisPerson.B_Case_link_creator = Guid.NewGuid();
            thisPerson.B_Case_link_createTime = DateTime.Now;
            thisPerson.B_Case_link_isDelete = 0;
            CaseLinks.Add(thisPerson);
            #endregion
            #region 立案提交的证据集合
            string[] filescode = form["EvidencesubmittedList.Code"].Split(',');//立案提交的证据
            foreach (var file_code in filescode)
            {
                CommonService.Model.CaseManager.B_Case_plan_Evidence Caseplan_Evence = new CommonService.Model.CaseManager.B_Case_plan_Evidence();
                Caseplan_Evence.B_Case_plan_code = caseplan.B_Case_code;
                Caseplan_Evence.B_Case_plan_Evidence_code = Guid.NewGuid();
                Caseplan_Evence.B_Case_paln_Evidence_type = 1;//1：立案提交的证据
                Caseplan_Evence.B_Case_plan_Evidence_file_code = new Guid(file_code);
                Caseplan_Evence.B_Case_plan_Evidence_creator = Context.UIContext.Current.UserCode;
                Caseplan_Evence.B_Case_plan_Evidence_createTime = DateTime.Now;
                Caseplan_Evence.B_Case_plan_Evidence_isDelete = 0;
                Caseplan_Evence.B_Case_plan_Evidence_Parameters_id = null;
                Caseplan_Evences.Add(Caseplan_Evence);
            }
            #endregion
            #region 诉讼提交的证据
            string[] filecode2 = form["EvidenceProceedingsList.Code"].Split(',');//诉讼提交的证据
            foreach (var file_code in filecode2)
            {
                CommonService.Model.CaseManager.B_Case_plan_Evidence Caseplan_Evence = new CommonService.Model.CaseManager.B_Case_plan_Evidence();
                Caseplan_Evence.B_Case_plan_code = caseplan.B_Case_code;
                Caseplan_Evence.B_Case_plan_Evidence_code = Guid.NewGuid();
                Caseplan_Evence.B_Case_paln_Evidence_type = 2;//1：诉讼提交的证据
                Caseplan_Evence.B_Case_plan_Evidence_file_code = new Guid(file_code);
                Caseplan_Evence.B_Case_plan_Evidence_creator = Context.UIContext.Current.UserCode;
                Caseplan_Evence.B_Case_plan_Evidence_createTime = DateTime.Now;
                Caseplan_Evence.B_Case_plan_Evidence_isDelete = 0;
                Caseplan_Evence.B_Case_plan_Evidence_Parameters_id = null;
                Caseplan_Evences.Add(Caseplan_Evence);
            }
            #endregion 需要补充的证据
            #region 需要补充的证据
            string[] c_parameters = form["ParametersList.Code"].Split(',');
            foreach (var parameter in c_parameters)
            {
                CommonService.Model.CaseManager.B_Case_plan_Evidence Caseplan_Evence = new CommonService.Model.CaseManager.B_Case_plan_Evidence();
                Caseplan_Evence.B_Case_plan_code = caseplan.B_Case_code;
                Caseplan_Evence.B_Case_plan_Evidence_code = Guid.NewGuid();
                Caseplan_Evence.B_Case_paln_Evidence_type = 3;//1：需要补充的证据
                Caseplan_Evence.B_Case_plan_Evidence_file_code = null;
                Caseplan_Evence.B_Case_plan_Evidence_creator = Context.UIContext.Current.UserCode;
                Caseplan_Evence.B_Case_plan_Evidence_createTime = DateTime.Now;
                Caseplan_Evence.B_Case_plan_Evidence_isDelete = 0;
                Caseplan_Evence.B_Case_plan_Evidence_Parameters_id = Convert.ToInt32(parameter);
                Caseplan_Evences.Add(Caseplan_Evence);
            }          
            #endregion
            _caselinkWCF.OperateList(CaseLinks);
            _caseplanEvidenceWCF.OperateList(Caseplan_Evences);
            #endregion
            if (caseplan.B_Case_plan_id > 0)
            {//修改
                bool isUpdateSuccess = _casesplanWCF.Update(caseplan);
                if (isUpdateSuccess)
                {
                    caseplanid = caseplan.B_Case_plan_id;
                }
            }
            else
            {//新增
                caseplan.B_Case_plan_isDelete = 0;
                caseplan.B_Case_plan_createTime = DateTime.Now;
                caseplan.B_Case_plan_creator = Context.UIContext.Current.UserCode;
                caseplanid = _casesplanWCF.Add(caseplan);
            }

            if (caseplanid > 0)
            {
                //保存成功提示固定写法
                return Json(TipHelper.JsonData("保存案件信息成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存案件信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }

        }
        /// <summary>
        /// 诉讼请求列表
        /// </summary>
        /// <param name="caseCode"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MulityCallbackRef(string caseCode)
        {
            CommonService.Model.CaseManager.B_Case Case = _caseWCF.GetModelNo(new Guid(caseCode));
            Guid B_case_code = new Guid(caseCode);
            string casetypeid = Case.B_Case_type.ToString();//得到案件类型（钢材/混凝土。。）
            string casetypename = _parametersWCF.GetModel(Convert.ToInt32(casetypeid)).C_Parameters_name;//得到案件类型的名称
            int Childrentype_id = _parametersWCF.GetModelByParmentname(Convert.ToInt32(casetypeid), casetypename).C_Parameters_id;
            List<CommonService.Model.CaseManager.B_Case_plan_Litigation> menus = _case_plan_litigationWCF.GetListByCasecodeAndParameterId(Childrentype_id, B_case_code);
            ViewBag.casecode = caseCode;
            return View(menus);
        }
        /// <summary>
        /// 诉讼请求编辑
        /// </summary>
        /// <param name="ParameterId"></param>
        /// <param name="casecode"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit_Litigation(string ParameterId, string casecode)
        {
            //根据parameterid和案件code获取B_Case_plan_Litigation信息
            CommonService.Model.CaseManager.B_Case_plan_Litigation litigation =_case_plan_litigationWCF.GetModelByParameterAndCasecode(Convert.ToInt32(ParameterId), new Guid(casecode));
            if (litigation!=null)
            {
                litigation.B_Case_plan_litigation_parameter_name = _parametersWCF.GetModel(Convert.ToInt32(ParameterId)).C_Parameters_name;
            }
            ViewBag.casecode = casecode;
            ViewBag.ParameterId = ParameterId;
            if (litigation == null) {
                litigation = new CommonService.Model.CaseManager.B_Case_plan_Litigation();

                litigation.B_Case_plan_Litigation_code = Guid.NewGuid();
                litigation.B_Case_code = new Guid(casecode);
                litigation.B_Case_plan_Litigation_ParameterId = Convert.ToInt32(ParameterId);
                litigation.B_Case_plan_litigation_parameter_name = _parametersWCF.GetModel(Convert.ToInt32(ParameterId)).C_Parameters_name;
                litigation.B_Case_plan_Litigation_creator = Context.UIContext.Current.UserCode;
                litigation.B_Case_plan_Litigation_createTime = DateTime.Now;
                litigation.B_Case_plan_Litigation_isDelete = 0;
            }
            return View(litigation);
        }
        [HttpPost]
        public ActionResult SaveEdit(CommonService.Model.CaseManager.B_Case_plan_Litigation litigation)
        {
            int caseplanid = 0;

            if (litigation.B_Case_plan_Litigation_id > 0)
            {//修改
                bool isUpdateSuccess = _case_plan_litigationWCF.Update(litigation);
                if (isUpdateSuccess)
                {
                    caseplanid = litigation.B_Case_plan_Litigation_id;
                }
            }
            else
            {//新增
                caseplanid = _case_plan_litigationWCF.Add(litigation);
            }

            if (caseplanid > 0)
            {
                //保存成功提示固定写法
                return Json(TipHelper.JsonData("保存诉讼请求信息成功", "iframe_LitigationForm", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshIframeChildren));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存诉讼请求信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
    }
}