using CommonService.Common;
using Context;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.MonitorManager.Controllers
{
    /// <summary>
    ///条目统计表控制器
    ///作者：崔慧栋
    ///日期：2015/06/11
    /// </summary>
    public class Entry_StatisticsController : BaseController
    {
        private readonly ICommonService.MonitorManager.IM_Entry_Statistics _entry_StatisticsWCF;
        private readonly ICommonService.MonitorManager.IM_Entry _entryWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.FlowManager.IP_Flow _flowWCF;
        private readonly ICommonService.IC_Region _regionWCF;
        public Entry_StatisticsController()
        {
            #region 服务初始化
            _entry_StatisticsWCF = ServiceProxyFactory.Create<ICommonService.MonitorManager.IM_Entry_Statistics>("Entry_StatisticsWCF");
            _entryWCF = ServiceProxyFactory.Create<ICommonService.MonitorManager.IM_Entry>("EntryWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _flowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow>("FlowWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
            #endregion
        }
        //
        // GET: /MonitorManager/Entry_Statistics/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 案件条目tab
        /// </summary>
        /// <returns></returns>
        public ActionResult ListTab()
        {
            if (UIContext.Current.IsPreSetManager)
            {
                    return RedirectToAction("list");
            }

            return View();
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.MonitorManager.M_Entry_Statistics Conditon = new CommonService.Model.MonitorManager.M_Entry_Statistics();

            //案件查询模型
            CommonService.Model.CaseManager.B_Case caseConditon = new CommonService.Model.CaseManager.B_Case();

            List<CommonService.Model.MonitorManager.M_Entry> entryList = _entryWCF.GetAllList();
            ViewBag.EntryList = entryList;
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.RegionList = regionList;
            List<CommonService.Model.C_Parameters> casesta = _parameterWCF.GetChildrenByParentId(198);
            ViewBag.casesta = casesta;
            List<CommonService.Model.FlowManager.P_Flow> casestage = _flowWCF.GetAllList();
            ViewBag.casestage = casestage;
            List<CommonService.Model.C_Parameters> Case_state = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(BusinessFlowEnum.业务流程状态));
            ViewBag.Case_state = Case_state;
            if ((!String.IsNullOrEmpty(form["M_Entry_code"])) && (form["M_Entry_code"].ToString()) != "全部")
            {//条目名称查询条件
                Conditon.M_Entry_code = new Guid(form["M_Entry_code"]);
            }
            //条目查询模型传递到前端视图中
            #region  业务查询条件
            if (!String.IsNullOrEmpty(form["B_Case_name"]))
            {//案件名称查询条件
                caseConditon.B_Case_name = form["B_Case_name"].Trim();
            }
            if ((!String.IsNullOrEmpty(form["B_Case_registerTime"])) && (!String.IsNullOrEmpty(form["B_Case_regiendTime"])))
            {//收案年份查询条件
                caseConditon.B_Case_registerTime = Convert.ToDateTime(form["B_Case_registerTime"]);
                caseConditon.B_Case_registerTime2 = Convert.ToDateTime(form["B_Case_regiendTime"]);
            }
            if (!String.IsNullOrEmpty(form["B_Case_number"]))
            {//案件编码查询条件
                caseConditon.B_Case_number = form["B_Case_number"].Trim();
            }
             
            if (!String.IsNullOrEmpty(form["consultantlookup.Code"]))
            {//专业顾问查询条件
                caseConditon.B_Case_consultant_code =new Guid(form["consultantlookup.Code"]);
                caseConditon.B_Case_consultant_name = form["consultantlookup.Name"].Trim();
            }
            if ((!String.IsNullOrEmpty(form["B_Case_state"])) && (form["B_Case_state"].ToString()) != "全部")
            {//案件状态查询条件
                caseConditon.B_Case_state = Convert.ToInt32(form["B_Case_state"]);
            }
            if (!String.IsNullOrEmpty(form["projectlookup.Code"]))
            {//涉案项目查询条件
                caseConditon.C_Project_code = form["projectlookup.Code"];
                caseConditon.C_Project_name = form["projectlookup.Name"];
            }
            if (!String.IsNullOrEmpty(form["courtlookupOne.Code"]))
            {//法院查询条件
                caseConditon.B_Case_courtFirst = new Guid(form["courtlookupOne.Code"]);
                caseConditon.B_Case_courtFirstName = form["courtlookupOne.Name"];
            }
            if ((!String.IsNullOrEmpty(form["B_Case_type"])) && (form["B_Case_type"].ToString()) != "全部")
            {//案件类型查询条件
                caseConditon.B_Case_type = Convert.ToInt32(form["B_Case_type"]);
            }
            if ((!String.IsNullOrEmpty(form["B_Case_Stage"])) && (form["B_Case_Stage"].ToString()) != "全部")
            {//办案阶段查询条件
                caseConditon.B_Case_Stage = form["B_Case_Stage"];
            }
            if ((!String.IsNullOrEmpty(form["B_Case_pricesta"])) && (!String.IsNullOrEmpty(form["B_Case_priceend"])))
            {//标的范围查询条件
                caseConditon.B_Case_transferTargetMoney = Convert.ToDecimal(form["B_Case_pricesta"].ToString().Trim());
                caseConditon.B_Case_execMoney2 = Convert.ToDecimal(form["B_Case_priceend"].ToString().Trim());
            }
            if (!String.IsNullOrEmpty(form["customerlookup.Code"]))
            {//客户查询条件
                caseConditon.C_Customer_code = form["customerlookup.Code"];
                caseConditon.C_Customer_name = form["customerlookup.Name"];
            }
            if (!String.IsNullOrEmpty(form["clientmulitylookup.Code"]))
            {//委托人查询条件
                caseConditon.C_Client_code = form["clientmulitylookup.Code"];
                caseConditon.C_Client_name = form["clientmulitylookup.Name"];
            }
            if (!String.IsNullOrEmpty(form["rivallookupParty.Code"]))
            {//对方当事人查询条件
                caseConditon.B_Case_Rival_code = form["rivallookupParty.Code"];
                caseConditon.B_Case_Rival_name = form["rivallookupParty.Name"];
                caseConditon.C_Person_type = form["rivallookupParty.Type"];
            }
            if (!String.IsNullOrEmpty(form["salesconsultantlook.Code"]))
            {//销售顾问
                //caseConditon.B_Case_consultant_code = new Guid(form["salesconsultantlook.Code"]);
                //caseConditon.B_Case_consultant_name = form["salesconsultantlook.Name"];
            }
            if (!String.IsNullOrEmpty(form["C_Region_code"]) && (form["C_Region_code"].ToString()) != "全部")
            {//区域
                caseConditon.C_Region_code = form["C_Region_code"];
            }
            if (!string.IsNullOrEmpty(form["M_Entry_Statistics_status"]))
            {//条目统计状态
                Conditon.M_Entry_Statistics_status = Convert.ToInt32(form["M_Entry_Statistics_status"]);
            }
            if ((!string.IsNullOrEmpty(form["B_Case_expectedGrant"])) && (!string.IsNullOrEmpty(form["B_Case_expectedGrant2"])))
            {//预期收益范围
                caseConditon.B_Case_expectedGrant = Convert.ToDecimal(form["B_Case_expectedGrant"]);
                caseConditon.B_Case_expectedGrant2 = Convert.ToDecimal(form["B_Case_expectedGrant2"]);
            }
            if (!String.IsNullOrEmpty(form["M_Entry_Statistics_HandlingState"]) && (form["M_Entry_Statistics_HandlingState"].ToString()) != "全部")
            {//办理状态
                Conditon.M_Entry_Statistics_HandlingState = Convert.ToInt32(form["M_Entry_Statistics_HandlingState"]);
            }
            if ((!String.IsNullOrEmpty(form["M_Entry_Statistics_Management"])) && (!String.IsNullOrEmpty(form["M_Entry_Statistics_Management1"])))
            {//办理情况
                Conditon.M_Entry_Statistics_Management = Convert.ToInt32(form["M_Entry_Statistics_Management"].Trim());
                Conditon.M_Entry_Statistics_Management1 = Convert.ToInt32(form["M_Entry_Statistics_Management1"].Trim());
            }
            #endregion
            ViewBag.Conditon = Conditon;
            ViewBag.CaseConditon = caseConditon;
            #endregion

            #region 用户所属部门岗位处理
            Guid? orgCode = null;
            Guid? postCode = null;
            Guid? postGroupCode = null;
            //所属部门Guid
            if (!String.IsNullOrEmpty(form["orgCode"]))
            {
                orgCode = new Guid(form["orgCode"]);
            }
            if (Request.QueryString["orgCode"] != null)
            {
                orgCode = new Guid(Request.QueryString["orgCode"]);
            }
            if (orgCode != null)
                this.AddressUrlParameters = "?orgCode=" + orgCode;
            ViewBag.OrgCode = orgCode;
            //所属岗位Guid
            if (!String.IsNullOrEmpty(form["postCode"]))
            {
                postCode = new Guid(form["postCode"]);
            }
            if (Request.QueryString["postCode"] != null)
            {
                postCode = new Guid(Request.QueryString["postCode"]);
            }
            if (postCode != null)
                this.AddressUrlParameters += "&postCode=" + postCode;
            ViewBag.PostCode = postCode;
            //所属岗位组Guid
            if (!String.IsNullOrEmpty(form["postGroupCode"]))
            {
                postGroupCode = new Guid(form["postGroupCode"]);
            }
            if (Request.QueryString["postGroupCode"] != null)
            {
                postGroupCode = new Guid(Request.QueryString["postGroupCode"]);
            }
            if (postGroupCode != null)
                this.AddressUrlParameters += "&postGroupCode=" + postGroupCode;
            ViewBag.PostGroupCode = postGroupCode;
            #endregion

            //获取总记录数
            this.TotalRecordCount = _entry_StatisticsWCF.GetRecordCount(Conditon, caseConditon, "", UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, postCode, orgCode, "(select count(*) from B_CaseMaintain where T.B_Case_code=B_CaseMaintain.B_Case_code)>0");

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取数据信息
            List<CommonService.Model.MonitorManager.M_Entry_Statistics> entrys = _entry_StatisticsWCF.GetListByPage(Conditon, caseConditon,
                "(select C_Parameters_order from C_Parameters where C_Parameters_id=T.M_Entry_Statistics_HandlingState) desc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, postCode, orgCode, "(select count(*) from B_CaseMaintain where T.B_Case_code=B_CaseMaintain.B_Case_code)>0");

            #region 权限
            this.DistributedInitButtonsPower(orgCode, postCode);
            this.DistributedInitLogin(orgCode, postCode, postGroupCode);
            #endregion

            return View(entrys);
        }

        /// <summary>
        /// 手工结束
        /// </summary>
        /// <returns></returns>
        public ActionResult HandOver(string M_Entry_Statistics_code)
        {
            string entryStatisticsCode = M_Entry_Statistics_code.Split(',')[1];
            string warningSituation="";

            CommonService.Model.MonitorManager.M_Entry_Statistics entryStatistics = _entry_StatisticsWCF.GetModel(new Guid(entryStatisticsCode));
            warningSituation = entryStatistics.M_Entry_Statistics_warningSituation.ToString();
            if (warningSituation == "464")
            {
                bool isSuccess = _entry_StatisticsWCF.UpdateHandlingState(new Guid(entryStatisticsCode));
                if (isSuccess)
                {

                    return Json(TipHelper.JsonData("成功手工结束条目！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
                }
                else
                {
                    //保存失败固定写法
                    return Json(TipHelper.JsonData("手工结束条目失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }

            }
            else
            {
                return Json(TipHelper.JsonData("只有预警状态才可以手工结束！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }

        }

        /// <summary>
        /// 根据案件Guid，检查是否有延期条目统计信息
        /// </summary>
        /// <param name="pkCode">案件Guid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ExistsDelayByPkCode(string pkCode)
        {
            string statusCode = "0";
            bool isHas = _entry_StatisticsWCF.ExistsDelayByPkCode(new Guid(pkCode));
            if (isHas)
            {
                statusCode = "1";
            }
            return Content(statusCode);
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //案件类型参数集合
            List<CommonService.Model.C_Parameters> Case_type = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.案件类型));
            ViewBag.Case_type = Case_type;
            //预警类型参数集合
            List<CommonService.Model.C_Parameters> warningType = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(EntrylEnum.预警类型));
            ViewBag.warningType = warningType;
            //办案状态参数集合
            List<CommonService.Model.C_Parameters> handlingState = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(EntrylEnum.监控状态));
            ViewBag.handlingState = handlingState;
            //预警情况参数集合
            List<CommonService.Model.C_Parameters> warningSituation = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(EntrylEnum.预警情况));
            ViewBag.warningSituation = warningSituation;
            //是否有效 
            List<CommonService.Model.C_Parameters> Statistics = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(EntryStatisticsEnum.条目统计状态));
            ViewBag.Statistics = Statistics;
        }
    }
}