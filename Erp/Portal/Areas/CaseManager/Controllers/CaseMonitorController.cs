using CommonService.Common;
using Context;
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
    /// 案件监控中心控制器
    /// 作者：崔慧栋
    /// 日期：2015/06/27
    /// </summary>
    public class CaseMonitorController : BaseController
    {
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;
        private readonly ICommonService.Customer.IV_MonitorCenter _vmonitorCenterWCF;
        private readonly ICommonService.FlowManager.IP_Flow _flowWCF;
        private readonly ICommonService.IC_Region _regionWCF;
        public CaseMonitorController()
        {
            #region 服务初始化
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            _vmonitorCenterWCF = ServiceProxyFactory.Create<ICommonService.Customer.IV_MonitorCenter>("VMonitorCenterWCF");
            _flowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow>("FlowWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
            #endregion
        }
        //
        // GET: /CaseManager/CaseMonitor/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 监控中心tab
        /// </summary>
        /// <returns></returns>
        public ActionResult CaseTab()
        {
            /***
             * author:hety
             * date:2016-01-26
             * description:按岗位进行划分案件维护Tab页签(一人多岗位，每个岗位角色权限可以不一样)(内置系统管理员不需要按Tab页签划分)           
             ***/

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

            //案件查询模型
            CommonService.Model.CaseManager.B_Case caseConditon = new CommonService.Model.CaseManager.B_Case();
            string flowCode = Guid.Empty.ToString();
            List<CommonService.Model.C_Parameters> casesta = _parameterWCF.GetChildrenByParentId(198);
            ViewBag.casesta = casesta;
            List<CommonService.Model.FlowManager.P_Flow> casestage = _flowWCF.GetAllList();
            ViewBag.casestage = casestage;
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.RegionList = regionList;
          
            #region  业务查询条件

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

            ViewBag.IsPreSetManager = UIContext.Current.IsPreSetManager.ToString();
            ViewBag.UserCode = UIContext.Current.UserCode;
       
            #endregion

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
                int a = 0;
                if ((!int.TryParse(form["B_Case_pricesta"].ToString().Trim(), out a)) || (!int.TryParse(form["B_Case_priceend"].ToString().Trim(), out a)))
                {
                    caseConditon.B_Case_transferTargetMoney = null;
                    caseConditon.B_Case_execMoney2 = null;
                }
                else
                {
                    caseConditon.B_Case_transferTargetMoney = Convert.ToDecimal(form["B_Case_pricesta"].ToString().Trim());
                    caseConditon.B_Case_execMoney2 = Convert.ToDecimal(form["B_Case_priceend"].ToString().Trim());
                }
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
            if (!String.IsNullOrEmpty(form["consultantlookup.Code"]))
            {//专业顾问
                caseConditon.B_Consultant_code = form["consultantlookup.Code"];
                caseConditon.B_Case_consultant_name = form["consultantlookup.Name"];
            }
            if (!String.IsNullOrEmpty(form["C_Region_code"]) && (form["C_Region_code"].ToString()) != "全部")
            {//区域
                caseConditon.C_Region_code = form["C_Region_code"];
            }
            if (!String.IsNullOrEmpty(form["responsibleDeptlookup.Code"]))
            {//部门
                caseConditon.B_Case_organizationCode = form["responsibleDeptlookup.Code"];
                caseConditon.B_Case_organizationName = form["responsibleDeptlookup.Name"];
            }
            if (!String.IsNullOrEmpty(form["mainLawyerlookup.Code"]))
            {//承办律师
                caseConditon.B_Case_lawyerCode = new Guid(form["mainLawyerlookup.Code"]);
                caseConditon.B_Case_lawyerName = form["mainLawyerlookup.Name"];
            }
            #endregion
            
            if (!String.IsNullOrEmpty(form["flowCode"]))
            {//流程Guid查询条件
                if (!form["flowCode"].Equals(Guid.Empty.ToString()))
                {
                    caseConditon.B_Case_relationCode = new Guid(form["flowCode"].Trim());
                    flowCode = caseConditon.B_Case_relationCode.Value.ToString();
                    caseConditon.B_Case_Stage = form["flowCode"].Trim();
                }
                else
                {
                    caseConditon.B_Case_Stage = null;
                }
            }

            //案件查询模型传递到前端视图中

            ViewBag.CaseConditon = caseConditon;
            ViewBag.FlowCode = flowCode;
            caseConditon.B_Case_oprationtype = 1;

            #endregion
            //获取业务流程阶段
            List<CommonService.Model.Customer.V_MonitorCenter> MontiorCenters = _vmonitorCenterWCF.GetMonitorCenterFlows(Convert.ToInt32(FlowTypeEnum.案件), caseConditon);

            //获取案件总记录数
            this.TotalRecordCount = _caseWCF.GetPowerRecordCount(null, caseConditon, UIContext.Current.IsPreSetManager, UIContext.Current.UserCode,
                postCode, orgCode);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取案件数据信息
            List<CommonService.Model.CaseManager.B_Case> banks = _caseWCF.GetPowerListByPage(null, caseConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, postCode, orgCode);

            CommonService.Model.Customer.V_MonitorCenter allMonitorCenter = new CommonService.Model.Customer.V_MonitorCenter();
            allMonitorCenter.FlowCode = Guid.Empty;
            allMonitorCenter.FlowName = "全部";

            if (!String.IsNullOrEmpty(form["TotalRecordCountOut"]))
            {
                if (caseConditon.B_Case_relationCode != null)
                {
                    allMonitorCenter.CaseNumber = Convert.ToInt32(form["TotalRecordCountOut"]);
                    ViewBag.TotalRecordCountOut = allMonitorCenter.CaseNumber;
                    //  allMonitorCenter.CaseNumber = banks.Count();
                }

                else
                {
                    if (Convert.ToInt32(form["TotalRecordCountOut"]) > banks.Count())
                        allMonitorCenter.CaseNumber = Convert.ToInt32(form["TotalRecordCountOut"]);
                    else
                        allMonitorCenter.CaseNumber = this.TotalRecordCount;
                }
            }
            else
                allMonitorCenter.CaseNumber = TotalRecordCount;

            MontiorCenters.Insert(0, allMonitorCenter);

            ViewBag.montiorCenters = MontiorCenters;

            if (caseConditon.B_Case_relationCode == null)
                ViewBag.TotalRecordCountOut = TotalRecordCount;
            else
            {
                this.TotalRecordCount = banks.Count();
            }

            #region 分布式初始化用户登录信息         
            this.DistributedInitLogin(orgCode, postCode, postGroupCode);
            #endregion

            return View(banks);
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //案件类型参数集合
            List<CommonService.Model.C_Parameters> Case_type = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.案件类型));
            ViewBag.Case_type = Case_type;
            //进行状态参数集合
            List<CommonService.Model.C_Parameters> Case_state = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(BusinessFlowEnum.业务流程状态));
            ViewBag.Case_state = Case_state;
        }



        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public int List_ByFlowCount(FormCollection form, string GJflowCode, bool IsPreSetManager, Guid? UserCode, Guid? PostCode, Guid? OrgCode, int? page = 1)
        {
            InitializationPageParameter();
            if (GJflowCode != "00000000-0000-0000-0000-000000000000")
            { 
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //案件查询模型
            CommonService.Model.CaseManager.B_Case caseConditon = new CommonService.Model.CaseManager.B_Case();

            List<CommonService.Model.C_Parameters> casesta = _parameterWCF.GetChildrenByParentId(198);
            ViewBag.casesta = casesta;
            List<CommonService.Model.FlowManager.P_Flow> casestage = _flowWCF.GetAllList();
            ViewBag.casestage = casestage;
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.RegionList = regionList;
        
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
                int a = 0;
                if ((!int.TryParse(form["B_Case_pricesta"].ToString().Trim(), out a)) || (!int.TryParse(form["B_Case_priceend"].ToString().Trim(), out a)))
                {
                    caseConditon.B_Case_transferTargetMoney = null;
                    caseConditon.B_Case_execMoney2 = null;
                }
                else
                {
                    caseConditon.B_Case_transferTargetMoney = Convert.ToDecimal(form["B_Case_pricesta"].ToString().Trim());
                    caseConditon.B_Case_execMoney2 = Convert.ToDecimal(form["B_Case_priceend"].ToString().Trim());
                }
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
            if (!String.IsNullOrEmpty(form["consultantlookup.Code"]))
            {//专业顾问
                caseConditon.B_Consultant_code = form["consultantlookup.Code"];
                caseConditon.B_Case_consultant_name = form["consultantlookup.Name"];
            }
            if (!String.IsNullOrEmpty(form["C_Region_code"]) && (form["C_Region_code"].ToString()) != "全部")
            {//区域
                caseConditon.C_Region_code = form["C_Region_code"];
            }
            if (!String.IsNullOrEmpty(form["responsibleDeptlookup.Code"]))
            {//部门
                caseConditon.B_Case_organizationCode = form["responsibleDeptlookup.Code"];
                caseConditon.B_Case_organizationName = form["responsibleDeptlookup.Name"];
            }
            if (!String.IsNullOrEmpty(form["mainLawyerlookup.Code"]))
            {//承办律师
                caseConditon.B_Case_lawyerCode = new Guid(form["mainLawyerlookup.Code"]);
                caseConditon.B_Case_lawyerName = form["mainLawyerlookup.Name"];
            }

            #endregion
            if (!String.IsNullOrEmpty(GJflowCode))
            {//流程Guid查询条件

                caseConditon.B_Case_relationCode = new Guid(GJflowCode);
                GJflowCode = caseConditon.B_Case_relationCode.Value.ToString();
                caseConditon.B_Case_Stage = GJflowCode;
               
            }
            //caseConditon.B_Case_state = Convert.ToInt32(BusinessFlowStatus.正在进行);

            //案件查询模型传递到前端视图中

            ViewBag.CaseConditon = caseConditon;
            ViewBag.FlowCode = GJflowCode;
            caseConditon.B_Case_oprationtype = 1;

            #endregion
            //获取案件总记录数
            this.TotalRecordCount = _caseWCF.GetPowerRecordCount(null, caseConditon, IsPreSetManager, UserCode,
                PostCode, OrgCode);


            return TotalRecordCount;
            }
            else
            {   //案件查询模型
                CommonService.Model.CaseManager.B_Case caseConditon = new CommonService.Model.CaseManager.B_Case();

                List<CommonService.Model.C_Parameters> casesta = _parameterWCF.GetChildrenByParentId(198);
                ViewBag.casesta = casesta;
                List<CommonService.Model.FlowManager.P_Flow> casestage = _flowWCF.GetAllList();
                ViewBag.casestage = casestage;
                List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
                ViewBag.RegionList = regionList;
             
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
                    int a = 0;
                    if ((!int.TryParse(form["B_Case_pricesta"].ToString().Trim(), out a)) || (!int.TryParse(form["B_Case_priceend"].ToString().Trim(), out a)))
                    {
                        caseConditon.B_Case_transferTargetMoney = null;
                        caseConditon.B_Case_execMoney2 = null;
                    }
                    else
                    {
                        caseConditon.B_Case_transferTargetMoney = Convert.ToDecimal(form["B_Case_pricesta"].ToString().Trim());
                        caseConditon.B_Case_execMoney2 = Convert.ToDecimal(form["B_Case_priceend"].ToString().Trim());
                    }
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
                if (!String.IsNullOrEmpty(form["consultantlookup.Code"]))
                {//专业顾问
                    caseConditon.B_Consultant_code = form["consultantlookup.Code"];
                    caseConditon.B_Case_consultant_name = form["consultantlookup.Name"];
                }
                if (!String.IsNullOrEmpty(form["C_Region_code"]) && (form["C_Region_code"].ToString()) != "全部")
                {//区域
                    caseConditon.C_Region_code = form["C_Region_code"];
                }
                if (!String.IsNullOrEmpty(form["responsibleDeptlookup.Code"]))
                {//部门
                    caseConditon.B_Case_organizationCode = form["responsibleDeptlookup.Code"];
                    caseConditon.B_Case_organizationName = form["responsibleDeptlookup.Name"];
                }
                if (!String.IsNullOrEmpty(form["mainLawyerlookup.Code"]))
                {//承办律师
                    caseConditon.B_Case_lawyerCode = new Guid(form["mainLawyerlookup.Code"]);
                    caseConditon.B_Case_lawyerName = form["mainLawyerlookup.Name"];
                }
    
                #endregion
                caseConditon.B_Case_oprationtype = 1;
                this.TotalRecordCount = _caseWCF.GetPowerRecordCount(null, caseConditon, IsPreSetManager, UserCode,
               PostCode, OrgCode);


                return TotalRecordCount;
            }


          

        }
    }
}