using CommonService.Common;
using Context;
using Maticsoft.Common;
using NPOI.XWPF.Extractor;
using NPOI.XWPF.UserModel;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.CaseManager.Controllers
{
    /// <summary>
    /// 案件控制器
    /// </summary>
    public class CaseController : BaseController
    {
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.CaseManager.IB_Case_link _caselinkWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.IC_Region _regionWCF;
        private readonly ICommonService.FlowManager.IP_Flow _flowWCF;
        private readonly ICommonService.SysManager.IC_Role_Role_Power _roleRolePowerWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;
        private readonly ICommonService.IC_Court _courtWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow_form _businessFlowFormWCF;
        private readonly ICommonService.CaseManager.IB_CaseLevelchange _caseLevelchangeWCF;
        private readonly ICommonService.CaseManager.IB_CaseLevelChangeRecords _caseLevelChangeRecordsWCF;
        private readonly ICommonService.SysManager.IC_Userinfo_area _userinfo_areaWCF;
        private readonly ICommonService.IC_Customer _customerWCF;
        private readonly ICommonService.SysManager.IC_Organization_post_user_region _organizationPostUerRegionWCF;
        public CaseController()
        {
            #region 服务初始化
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _caselinkWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case_link>("Case_linkWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
            _flowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow>("FlowWCF");
            _roleRolePowerWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Role_Role_Power>("Role_Role_PowerWCF");
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            _courtWCF = ServiceProxyFactory.Create<ICommonService.IC_Court>("CourtWCF");
            _businessFlowFormWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow_form>("Business_flow_formWCF");
            _caseLevelchangeWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_CaseLevelchange>("CaseLevelchangeWCF");
            _caseLevelChangeRecordsWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_CaseLevelChangeRecords>("CaseLevelChangeRecordsWCF");
            _userinfo_areaWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo_area>("Userinfo_areaWCF");
            _customerWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer>("CustomerWCF");
            _organizationPostUerRegionWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization_post_user_region>("C_Organization_post_user_regionWCF");
            #endregion
        }
        //
        // GET: /CaseManager/Case/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 案件tab
        /// </summary>
        /// <returns></returns>
        public ActionResult CaseTab()
        {
            /***
             * author:hety
             * date:2016-01-25
             * description:按岗位进行划分案件Tab页签(一人多岗位，每个岗位角色权限可以不一样)(内置系统管理员不需要按Tab页签划分)           
             ***/
           
            if (UIContext.Current.IsPreSetManager)
            {
                if (Request.QueryString["caseType"] != null)
                {
                    return RedirectToAction("list", new { caseType = Request.QueryString["caseType"] });
                }
                else
                {
                    return RedirectToAction("list");
                }                
            }

            string caseType = "-100";//代表无此参数
            if (Request.QueryString["caseType"] != null)
            {
                caseType = Request.QueryString["caseType"];
            }
            ViewBag.CaseType = caseType;//案件列表类型

            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string customerCode)
        {
            InitializationPageParameter();
            //创建初始化案件实体
            CommonService.Model.CaseManager.B_Case bcase = new CommonService.Model.CaseManager.B_Case();
            bcase.B_Case_code = Guid.NewGuid();
            bcase.B_Case_state = Convert.ToInt32(BusinessFlowStatus.未开始);
            bcase.B_Case_registerTime = DateTime.Now;
            bcase.B_Case_creator = Context.UIContext.Current.UserCode;
            bcase.B_Case_createTime = DateTime.Now;
            bcase.B_Case_isDelete = 0;
            bcase.B_Case_consultant_code = Context.UIContext.Current.UserCode;
            bcase.B_Case_consultant_name = Context.UIContext.Current.UserName;
            List<CommonService.Model.SysManager.C_Organization_post_user_region> userinfoRegion = _organizationPostUerRegionWCF.GetListByUserinfoCode(Context.UIContext.Current.UserCode.Value);
            //List<CommonService.Model.SysManager.C_Userinfo_region> userinfoRegion = _userinfo_areaWCF.GetListByUserinfoCode(Context.UIContext.Current.UserCode.Value);
            CommonService.Model.C_Region regionModel = new CommonService.Model.C_Region();
            List<CommonService.Model.C_Region> regionList = new List<CommonService.Model.C_Region>();
            if (userinfoRegion.Count() > 0)
            {
                regionModel.C_Region_code = userinfoRegion.FirstOrDefault().C_region_code;
                regionModel.C_Region_name = userinfoRegion.FirstOrDefault().C_region_name;
                regionList.Add(regionModel);
            }
            if (regionList.Count() == 0)
            {
                regionList = _regionWCF.GetAllSpecialList();
            }
            ViewBag.RegionList = regionList;
            return View(bcase);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string B_Case_code)
        {
            InitializationPageParameter();
            CommonService.Model.CaseManager.B_Case bcase = _caseWCF.GetModel(new Guid(B_Case_code));

            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.RegionList = regionList;

            return View("Create", bcase);
        }


        /// <summary>
        /// 编辑其他要求
        /// </summary>
        /// <returns></returns>
        public ActionResult CaseEditRequirement(string caseCode)
        {
            CommonService.Model.CaseManager.B_Case bcase = _caseWCF.GetModel(new Guid(caseCode));
            bcase.B_Case_number = bcase.B_Case_number == null ? bcase.B_Case_number : bcase.B_Case_number.Substring(0, bcase.B_Case_number.Length - 4);
            return View(bcase);
        }

        /// <summary>
        /// 其他要求详细
        /// </summary>
        /// <returns></returns>
        public ActionResult RequirementDetail(string caseCode)
        {
            CommonService.Model.CaseManager.B_Case bcase = _caseWCF.GetModel(new Guid(caseCode));
            return View(bcase);
        }

        /// <summary>
        /// 编辑计划任务
        /// </summary>
        /// <returns></returns>
        public ActionResult CaseEditPlantask(string caseCode)
        {
            List<CommonService.Model.SysManager.C_Userinfo> users = _userinfoWCF.GetFirstOrMiniterList(2);

            List<CommonService.Model.SysManager.C_Userinfo> firstUsers = _userinfoWCF.GetFirstOrMiniterList(1);
            //CommonService.Model.SysManager.C_Userinfo loginUser = firstUsers.FirstOrDefault(x => x.C_Userinfo_code == Context.UIContext.Current.UserCode);
            //if (loginUser != null)
            //    ViewBag.loginUser = loginUser.C_Userinfo_Organization_name + "->" + loginUser.C_Userinfo_post_name + "->" + loginUser.C_Userinfo_name;
            //else
            //    ViewBag.loginUser = string.Empty;
            ViewBag.loginUser = Context.UIContext.Current.UserCode.ToString();
            CommonService.Model.CaseManager.B_Case bcase = _caseWCF.GetModel(new Guid(caseCode));

            #region 只取案件所在区域的首席专家和部长
            //if (bcase != null&&!Context.UIContext.Current.IsPreSetManager)
            //{
            //    List<CommonService.Model.CaseManager.B_Case_link> bLists = _caselinkWCF.GetCaseLinksByCaseAndType(bcase.B_Case_code.Value, Convert.ToInt32(CaselinkEnum.所属区域));
            //    if (bLists.Count() > 0)
            //    {
            //        CommonService.Model.CaseManager.B_Case_link model = new CommonService.Model.CaseManager.B_Case_link();
            //        model = bLists[0];
            //        firstUsers = firstUsers.Where(p => p.C_Userinfo_Regioncode == model.C_FK_code).ToList();
            //        users = users.Where(p => p.C_Userinfo_Regioncode == model.C_FK_code).ToList();
                    //for (int i = 0; i < firstUsers.Count(); i++)
                    //{
                    //    if (firstUsers[i].C_Userinfo_Regioncode != model.C_FK_code)
                    //    {
                    //        firstUsers.Remove(firstUsers[i]);
                    //    }
                    //}
                    //for (int i = 0; i < users.Count(); i++)
                    //{
                    //    if (users[i].C_Userinfo_Regioncode != model.C_FK_code)
                    //    {
                    //        users.Remove(users[i]);
                    //    }
                    //}
            //    }
            //}
            #endregion
            ViewBag.firstUsers = firstUsers;
            ViewBag.users = users;
            bcase.B_Case_number = bcase.B_Case_number == null ? bcase.B_Case_number : bcase.B_Case_number.Substring(0, bcase.B_Case_number.Length - 4);
            return View(bcase);
        }

        /// <summary>
        /// 启动案件任务
        /// </summary>
        /// <returns></returns>
        public ActionResult StartCase(string caseCode)
        {
            CommonService.Model.CaseManager.B_Case case_info = _caseWCF.GetModel(new Guid(caseCode));
            List<CommonService.Model.FlowManager.P_Business_flow> businessFlows = _bussinessFlowWCF.GetListByFkCode(new Guid(caseCode));
            if (businessFlows.Count == 0)
            {
                return Json(TipHelper.JsonData("此案件沒有配置阶段，无法启动！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            if (case_info.B_Case_state == Convert.ToInt32(BusinessFlowStatus.未开始))
            {
                bool isUpdateSuccess = _caseWCF.UpdateState(new Guid(caseCode), Context.UIContext.Current.UserCode.Value);
                if (isUpdateSuccess)
                {
                    //保存成功提示固定写法
                    return Json(TipHelper.JsonData("成功启动案件任务！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
                }
                else
                {
                    //保存失败固定写法
                    return Json(TipHelper.JsonData("启动案件任务失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
            }
            else
            {
                return Json(TipHelper.JsonData("不可重复启动！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }

        }

        /// <summary>
        /// tab 页签
        /// </summary>
        /// <returns></returns>
        public ActionResult TabDetails(string caseCode)
        {
            ViewBag.caseCode = caseCode;
            return View();
        }

        /// <summary>
        /// 案件详细
        /// </summary>
        /// <returns></returns>
        public ActionResult Details(string caseCode)
        {
            CommonService.Model.CaseManager.B_Case cases = _caseWCF.GetModel(new Guid(caseCode));
            InitializationPageParameter(cases);
            return View(cases);
        }

        /// <summary>
        /// 案件信息
        /// </summary>
        /// <param name="caseCode">案件Code</param>
        /// <param name="type">1、修改按钮  2、案件计划</param>
        /// <returns></returns>
        public ActionResult CaseTabDetails(string caseCode, int type)
        {
            ViewBag.CaseCode = caseCode;
            ViewBag.Type = type;

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View();
        }


        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form, int? page = 1)
        {
            InitializationPageParameter();

            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //案件查询模型
            CommonService.Model.CaseManager.B_Case caseConditon = new CommonService.Model.CaseManager.B_Case();
            //案件查询模型传递到前端视图中
            caseConditon.B_Case_oprationtype = 1;
            List<CommonService.Model.C_Parameters> casesta = _parameterWCF.GetChildrenByParentId(198);
            ViewBag.casesta = casesta;
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.RegionList = regionList;
            List<CommonService.Model.FlowManager.P_Flow> flowList = _flowWCF.GetListByFlowType(Convert.ToInt32(FlowTypeEnum.案件));
            List<CommonService.Model.FlowManager.P_Flow> casestage = new List<CommonService.Model.FlowManager.P_Flow>();
            flowList = SetSingleTopFlow(flowList, casestage);

            int caseType = 1;//默认全部案件
            if (!String.IsNullOrEmpty(form["caseType"]))
            {
                caseType = Convert.ToInt32(form["caseType"]);
            }
            if (Request.QueryString["caseType"] != null)
            {
                caseType = Convert.ToInt32(Request.QueryString["caseType"]);
            }
            this.AddressUrlParameters = "?caseType=" + caseType;
            ViewBag.caseType = caseType;

            #region  业务查询条件

            //针对律师案件列表(我的未开始、我的在办、我的已结案件列表)的固定查询模型
            CommonService.Model.Customer.V_LawyerCondition vLawyerCond = null;
            int lawyerType = 0;//律师类型
            if (caseType == 2 || caseType == 3 || caseType == 4)
            {
                if (!String.IsNullOrEmpty(form["lawyerType"]))
                {
                    lawyerType = Convert.ToInt32(form["lawyerType"]);
                }
                if (Request.QueryString["lawyerType"] != null)
                {
                    lawyerType = Convert.ToInt32(Request.QueryString["lawyerType"]);
                }
                this.AddressUrlParameters += "&lawyerType=" + lawyerType;
                if (vLawyerCond == null)
                    vLawyerCond = new CommonService.Model.Customer.V_LawyerCondition();
                vLawyerCond.LawyerCode = Context.UIContext.Current.UserCode;
                vLawyerCond.LawyerType = lawyerType;

                if (caseType == 2)//我的未开始
                    vLawyerCond.OperateStatus = Convert.ToInt32(BusinessFlowStatus.未开始);
                else if (caseType == 3)//我的在办
                    vLawyerCond.OperateStatus = Convert.ToInt32(BusinessFlowStatus.正在进行);
                else if (caseType == 4)//我的已结
                    vLawyerCond.OperateStatus = Convert.ToInt32(BusinessFlowStatus.已结束);

                ViewBag.caseType = caseType;
            }
            else if (caseType == 5)
            { //未开始案件
                ViewBag.caseType = 5;
                caseConditon.B_Case_state = Convert.ToInt32(BusinessFlowStatus.未开始);
            }
            else if (caseType == 6)
            { //在办案件
                ViewBag.caseType = 6;
                caseConditon.B_Case_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
            }
            else if (caseType == 7)
            { //已结案件
                ViewBag.caseType = 7;
                caseConditon.B_Case_state = Convert.ToInt32(BusinessFlowStatus.已结束);
            }
            else if (caseType == 8)
            {//重大难案
                ViewBag.caseType = 8;
                caseConditon.B_Case_Majordifficult = 2;
            }

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
            if (!String.IsNullOrEmpty(form["B_Case_sureDate"]))
            {//确认时间查询条件
                caseConditon.B_Case_sureDate = Convert.ToDateTime(form["B_Case_sureDate"]);
            }
            if (!String.IsNullOrEmpty(form["B_Case_sureDateEnd"]))
            {//确认时间查询条件
                caseConditon.B_Case_sureDateEnd = Convert.ToDateTime(form["B_Case_sureDateEnd"]);
            }
            if (!String.IsNullOrEmpty(form["B_Case_Level"]) && (form["B_Case_Level"].ToString()) != "全部")
            {//案件级别
                caseConditon.B_Case_isNotAudited = Convert.ToInt32(form["B_Case_Level"]);
            }
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
                this.AddressUrlParameters += "&orgCode=" + orgCode;
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
            ViewBag.PostCode=postCode;
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

            ViewBag.LawyerType = lawyerType;
            ViewBag.casestage = flowList;
            ViewBag.CaseConditon = caseConditon;
            #endregion

            //获取案件总记录数
            this.TotalRecordCount = _caseWCF.GetPowerRecordCount(vLawyerCond, caseConditon, UIContext.Current.IsPreSetManager, UIContext.Current.UserCode,
                postCode, orgCode);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取案件数据信息
            List<CommonService.Model.CaseManager.B_Case> banks = _caseWCF.GetPowerListByPage(vLawyerCond, caseConditon,
                "B_Case_isNotAudited desc,B_Case_id desc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, postCode, orgCode);

            #region 分布式权限以及初始化用户登录信息
            this.DistributedInitButtonsPower(orgCode, postCode);
            this.DistributedInitLogin(orgCode, postCode, postGroupCode);
            #endregion

            return View(banks);
        }

        /// <summary>
        /// 关联案件的获取
        /// </summary>
        /// <param name="form"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult ListLink(FormCollection form, string customerCode, int type, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //案件查询模型
            CommonService.Model.CaseManager.B_Case caseConditon = new CommonService.Model.CaseManager.B_Case();
 
            List<CommonService.Model.C_Parameters> casesta = _parameterWCF.GetChildrenByParentId(198);
            ViewBag.casesta = casesta;
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.RegionList = regionList;
            List<CommonService.Model.FlowManager.P_Flow> flowList = _flowWCF.GetListByFlowType(Convert.ToInt32(FlowTypeEnum.案件));
            List<CommonService.Model.FlowManager.P_Flow> casestage = new List<CommonService.Model.FlowManager.P_Flow>();
            flowList = SetSingleTopFlow(flowList, casestage);
            string _customerCode = String.Empty;
            if (!String.IsNullOrEmpty(form["customerCode"]))
            {
                _customerCode = form["customerCode"];
            }
            if (Request.QueryString["customerCode"] != null)
            {
                _customerCode = Request.QueryString["customerCode"];
            }
            ViewBag.CustomerCode = _customerCode;
            this.AddressUrlParameters = "?customerCode=" + _customerCode;//地址栏参数

            int _type = 0;
            if (!String.IsNullOrEmpty(form["type"]))
            {
                _type = Convert.ToInt32(form["type"]);
            }
            if (Request.QueryString["type"] != null)
            {
                _type = Convert.ToInt32(Request.QueryString["type"]);
            }
            ViewBag.Type = _type;
            this.AddressUrlParameters += "&type=" + _type;//累加地址栏参数
 
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

            //涉案项目
            if (type == 6)
            {
                caseConditon.C_Project_code = customerCode;
            }
            else
            {
                if (!String.IsNullOrEmpty(form["projectlookup.Code"]))
                {//涉案项目查询条件
                    caseConditon.C_Project_code = form["projectlookup.Code"];
                    caseConditon.C_Project_name = form["projectlookup.Name"];
                }
            }
            if (type == 5)
            {
                caseConditon.B_Case_courtFirst = new Guid(customerCode);
            }
            else
            {
                if (!String.IsNullOrEmpty(form["courtlookupOne.Code"]))
                {//法院查询条件
                    caseConditon.B_Case_courtFirst = new Guid(form["courtlookupOne.Code"]);
                    caseConditon.B_Case_courtFirstName = form["courtlookupOne.Name"];
                }
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
            if (type == 1)
            {

                if (customerCode != null && customerCode != "" && type == 1)
                {
                    caseConditon.C_Customer_code = customerCode;

                }
                else
                {
                    if (!String.IsNullOrEmpty(form["customermulitylookup.Code"]))
                    {//客户查询条件
                        caseConditon.C_Customer_code = form["customermulitylookup.Code"];
                        caseConditon.C_Customer_name = form["customermulitylookup.Name"];
                    }
                }
            }


            //委托人查询条件
            if (type == 3)
            {
                if (customerCode != null && customerCode != "" && type == 3)
                {
                    caseConditon.C_Client_code = customerCode;

                }
                else
                {
                    if (!String.IsNullOrEmpty(form["clientmulitylookup.Code"]))
                    {
                        caseConditon.C_Client_code = form["clientmulitylookup.Code"];
                        caseConditon.C_Client_name = form["clientmulitylookup.Name"];
                    }
                }

            }

            if (type == 4)
            {
                caseConditon.B_Case_Rival_code = customerCode;
            }
            else
            {
                if (!String.IsNullOrEmpty(form["rivallookupParty.Code"]))
                {//对方当事人查询条件
                    caseConditon.B_Case_Rival_code = form["rivallookupParty.Code"];
                    caseConditon.B_Case_Rival_name = form["rivallookupParty.Name"];
                    caseConditon.C_Person_type = form["rivallookupParty.Type"];
                }
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
            ViewBag.casestage = flowList;
            ViewBag.CaseConditon = caseConditon;
            #endregion
            this.PageSize = 10;
            //获取案件总记录数
            this.TotalRecordCount = _caseWCF.GetPowerRecordCount(null, caseConditon, true,UIContext.Current.UserCode,
                null, null);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取案件数据信息
            List<CommonService.Model.CaseManager.B_Case> Cases = _caseWCF.GetPowerListByPage(null, caseConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, true, 
                UIContext.Current.UserCode, null, null);

            return View(Cases);
        }

        #region 办案阶段流程
        private List<CommonService.Model.FlowManager.P_Flow> SetSingleTopFlow(List<CommonService.Model.FlowManager.P_Flow> flowList, List<CommonService.Model.FlowManager.P_Flow> casestage)
        {
            var topFlowCaseList = from allList in flowList
                                  where allList.P_Flow_level == 1
                                  orderby allList.P_Flow_order ascending
                                  select allList;

            foreach (CommonService.Model.FlowManager.P_Flow flow in topFlowCaseList)
            {
                casestage.Add(flow);
                SetSignleRecursion(flowList, flow.P_Flow_code.Value, casestage);
            }
            return casestage;
        }
        private List<CommonService.Model.FlowManager.P_Flow> SetSignleRecursion(List<CommonService.Model.FlowManager.P_Flow> flowList, Guid flowCode, List<CommonService.Model.FlowManager.P_Flow> casestage)
        {
            foreach (CommonService.Model.FlowManager.P_Flow flow in flowList)
            {
                if (flow.P_Flow_parent == flowCode)
                {
                    casestage.Add(flow);
                    SetSignleRecursion(flowList, flow.P_Flow_code.Value, casestage);
                }
            }
            return casestage;
        }
        #endregion

        /// <summary>
        /// 关联案件列表(这个方法，好像已作废，在2016-2-1,变动时，没有检测到此调用处，固先作废掉,hety)
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult FKRelationCaseList(FormCollection form, string relationCode, int? page = 1)
        {
            InitializationPageParameter();

            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //案件查询模型
            CommonService.Model.CaseManager.B_Case caseConditon = new CommonService.Model.CaseManager.B_Case();

            if (!String.IsNullOrEmpty(form["B_Case_name"]))
            {//案件名称查询条件
                caseConditon.B_Case_name = form["B_Case_name"].Trim();
            }
            if (!String.IsNullOrEmpty(form["B_Case_relationCode"]))
            {//案件名称查询条件
                caseConditon.B_Case_relationCode = new Guid(form["B_Case_relationCode"].Trim());
            }
            if (caseConditon.B_Case_relationCode == null)
            {//关联GUID
                if (String.IsNullOrEmpty(relationCode))
                {
                    caseConditon.B_Case_relationCode = Guid.Empty;
                }
                else
                {
                    caseConditon.B_Case_relationCode = new Guid(relationCode);
                    this.AddressUrlParameters = "?relationCode=" + relationCode;
                }
            }
            //案件查询模型传递到前端视图中
            ViewBag.CaseConditon = caseConditon;
            caseConditon.B_Case_oprationtype = 2;

            #endregion

            //获取案件总记录数
            this.TotalRecordCount = _caseWCF.GetRecordCount(caseConditon, UIContext.Current.IsPreSetManager, null, UIContext.Current.UserCode,
                null, null);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            this.PageSize = 10;

            //获取案件数据信息
            List<CommonService.Model.CaseManager.B_Case> bCases = _caseWCF.GetListByPage(caseConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, UIContext.Current.IsPreSetManager, null, UIContext.Current.UserCode,
                null, null);

            return View(bCases);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.CaseManager.B_Case bcase)
        {
            int caseId = 0;

            bcase.B_Case_courtFirst = String.IsNullOrEmpty(form["courtlookupOne.Code"]) ? Guid.Empty : new Guid(form["courtlookupOne.Code"]);
            bcase.B_Case_courtSecond = String.IsNullOrEmpty(form["courtlookupTwo.Code"]) ? Guid.Empty : new Guid(form["courtlookupTwo.Code"]);
            bcase.B_Case_courtExec = String.IsNullOrEmpty(form["courtlookupThree.Code"]) ? Guid.Empty : new Guid(form["courtlookupThree.Code"]);
            bcase.B_Case_Trial = String.IsNullOrEmpty(form["courtlookupFourth.Code"]) ? Guid.Empty : new Guid(form["courtlookupFourth.Code"]);
            //bcase.B_Case_consultant_code = new Guid(form["salesconsultantlook.Code"]); 
            #region 案件名称赋值

            string[] clientNames = form["clientmulitylookup.Name"].Split(',');
            foreach (var clientName in clientNames)
            {
                bcase.B_Case_name += clientName + "+";
            }
            bcase.B_Case_name = bcase.B_Case_name.Substring(0, bcase.B_Case_name.Length - 1);
            CommonService.Model.C_Parameters Case_type = _parameterWCF.GetModel(bcase.B_Case_type.Value);
            bcase.B_Case_name += "_" + Case_type.C_Parameters_name + "_";
            string[] rivalNames = form["rivallookupParty.Name"].Split(',');
            foreach (var rivalName in rivalNames)
            {
                bcase.B_Case_name += rivalName + "+";
            }
            bcase.B_Case_name = bcase.B_Case_name.Substring(0, bcase.B_Case_name.Length - 1);

            #endregion

            #region 参照值处理

            List<CommonService.Model.CaseManager.B_Case_link> CaseLinks = new List<CommonService.Model.CaseManager.B_Case_link>();

            #region 客户集合
            string[] customerCodes = form["customermulitylookup.Code"].Split(',');
            foreach (var customer_code in customerCodes)
            {
                CommonService.Model.CaseManager.B_Case_link caselink = new CommonService.Model.CaseManager.B_Case_link();
                caselink.B_Case_code = bcase.B_Case_code;
                caselink.C_FK_code = new Guid(customer_code);
                caselink.B_Case_link_type = Convert.ToInt32(CaselinkEnum.客户);
                caselink.B_Case_link_creator = Context.UIContext.Current.UserCode;
                caselink.B_Case_link_createTime = DateTime.Now;
                caselink.B_Case_link_isDelete = 0;

                CaseLinks.Add(caselink);
            }
            #endregion

            #region 委托人集合
            string[] clientCodes = form["clientmulitylookup.Code"].Split(',');
            foreach (var client_code in clientCodes)
            {
                CommonService.Model.CaseManager.B_Case_link caselink = new CommonService.Model.CaseManager.B_Case_link();
                caselink.B_Case_code = bcase.B_Case_code;
                caselink.C_FK_code = new Guid(client_code);
                caselink.B_Case_link_type = Convert.ToInt32(CaselinkEnum.委托人);
                caselink.B_Case_link_creator = Context.UIContext.Current.UserCode;
                caselink.B_Case_link_createTime = DateTime.Now;
                caselink.B_Case_link_isDelete = 0;
                CaseLinks.Add(caselink);
            }
            #endregion

            #region 对方当事人
            string[] partyCodes = form["rivallookupParty.Code"].Split(',');
            string[] partyType = form["rivallookupParty.Type"].Split(',');
            int i = 0;
            foreach (var party_code in partyCodes)
            {
                CommonService.Model.CaseManager.B_Case_link thisPerson = new CommonService.Model.CaseManager.B_Case_link();
                thisPerson.B_Case_code = bcase.B_Case_code;
                thisPerson.C_FK_code = new Guid(party_code);
                thisPerson.B_Case_link_type = Convert.ToInt32(partyType[i]);
                thisPerson.B_Case_link_creator = Context.UIContext.Current.UserCode;
                thisPerson.B_Case_link_createTime = DateTime.Now;
                thisPerson.B_Case_link_isDelete = 0;
                CaseLinks.Add(thisPerson);
                i++;
            }
            #endregion

            #region 被执行人
            string[] beexecutedCodes = form["rivallookupBeexecuted.Code"].Split(',');
            if (beexecutedCodes[0] != "")
            {
                string[] beexecutedType = form["rivallookupBeexecuted.Type"].Split(',');
                int j = 0;
                foreach (var beexecuted_code in beexecutedCodes)
                {
                    CommonService.Model.CaseManager.B_Case_link executer = new CommonService.Model.CaseManager.B_Case_link();
                    executer.B_Case_code = bcase.B_Case_code;
                    executer.C_FK_code = new Guid(beexecuted_code);
                    executer.B_Case_link_type = Convert.ToInt32(beexecutedType[j]);
                    executer.B_Case_link_creator = Context.UIContext.Current.UserCode;
                    executer.B_Case_link_createTime = DateTime.Now;
                    executer.B_Case_link_isDelete = 0;
                    CaseLinks.Add(executer);
                    j++;
                }
            }

            #endregion

            #region 工程
            string[] projectCodes = form["projectlookup.Code"].Split(',');
            foreach (var project_code in projectCodes)
            {
                CommonService.Model.CaseManager.B_Case_link project = new CommonService.Model.CaseManager.B_Case_link();
                project.B_Case_code = bcase.B_Case_code;
                project.C_FK_code = new Guid(project_code);
                project.B_Case_link_type = Convert.ToInt32(CaselinkEnum.工程);
                project.B_Case_link_creator = Context.UIContext.Current.UserCode;
                project.B_Case_link_createTime = DateTime.Now;
                project.B_Case_link_isDelete = 0;

                CaseLinks.Add(project);
            }
            #endregion

            #region 区域
            string[] regionCodes = bcase.C_Region_code.Split(',');
            foreach (var region_code in regionCodes)
            {
                CommonService.Model.CaseManager.B_Case_link area = new CommonService.Model.CaseManager.B_Case_link();
                area.B_Case_code = bcase.B_Case_code;
                area.C_FK_code = new Guid(region_code);
                area.B_Case_link_type = Convert.ToInt32(CaselinkEnum.所属区域);
                area.B_Case_link_creator = Context.UIContext.Current.UserCode;
                area.B_Case_link_createTime = DateTime.Now;
                area.B_Case_link_isDelete = 0;

                CaseLinks.Add(area);
            }
            #endregion

            _caselinkWCF.OperateList(CaseLinks);

            #endregion

            string region = regionCodes.First();
            string regionAbbreviation = _regionWCF.GetModelByCode(new Guid(region)).C_Region_abbreviation;
            string caseType = _parameterWCF.GetModel(bcase.B_Case_type.Value).C_Parameters_abbreviation;

            if (bcase.B_Case_id > 0)
            {//修改
                //bcase.B_Case_number = "BC" + DateTime.Now.ToString("yyyy") + regionAbbreviation + "MS" + caseType;
                bool isUpdateSuccess = _caseWCF.Update(bcase);
                if (isUpdateSuccess)
                {
                    caseId = bcase.B_Case_id;
                }
            }
            else
            {//新增

                bcase.B_Case_number = "BC" + DateTime.Now.ToString("yyyy") + regionAbbreviation + "MS" + caseType;
                caseId = _caseWCF.Add(bcase);
            }

            if (caseId > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    if (bcase.B_Case_id != 0)
                    {
                        return Json(TipHelper.JsonData("保存案件信息成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshGrandpa));//仅仅保存
                    }
                    else
                    {
                        return Json(TipHelper.JsonData("保存案件信息成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
                    }
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存案件信息成功", "/CaseManager/case/create", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存案件信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存案件信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveCase(FormCollection form, CommonService.Model.CaseManager.B_Case bcase)
        {
            if (DateTime.Compare(bcase.B_Case_planStartTime.Value, bcase.B_Case_planEndTime.Value) < 0)
            {
                if (form["B_Case_firstClassResponsiblePerson"] != "请选择")
                {
                    bcase.B_Case_firstClassResponsiblePerson = new Guid(form["B_Case_firstClassResponsiblePerson"]);
                }
                else
                {
                    bcase.B_Case_firstClassResponsiblePerson = null;
                }
                if (form["B_Case_person"] != "请选择")
                {
                    bcase.B_Case_person = new Guid(form["B_Case_person"]);
                }
                else
                {
                    bcase.B_Case_person = null;
                }
                bcase.B_Case_planStartTime = Convert.ToDateTime(form["B_Case_planStartTime"]);
                bcase.B_Case_planEndTime = Convert.ToDateTime(form["B_Case_planEndTime"]);
                //bcase.B_Case_isSure = form["B_Case_isSure"] == "1" ? true : false;
                bool isUpdateSuccess = false;
                if (UIContext.Current.UserCode == bcase.B_Case_firstClassResponsiblePerson) //确认人如果是首席专家
                {
                    isUpdateSuccess = _caseWCF.ChiefUpdate(bcase);
                }
                else
                {
                    isUpdateSuccess = _caseWCF.Update(bcase);
                }

                if (isUpdateSuccess)
                {
                    //保存成功提示固定写法
                    return Json(TipHelper.JsonData("保存案件信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
                }
                else
                {
                    //保存失败固定写法
                    return Json(TipHelper.JsonData("保存案件信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
            }
            else
            {
                return Json(TipHelper.JsonData("计划开始时间不能大于计划结束时间！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="bankCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string B_Case_code)
        {
            bool isSuccess = _caseWCF.Delete(new Guid(B_Case_code));

            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除案件信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除案件信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 案件转移
        /// </summary>
        /// <returns></returns>
        public ActionResult CaseTransfer()
        {
            InitializationPageParameter();
            List<CommonService.Model.C_Court> courts = _courtWCF.GetAllList();
            ViewBag.courts = courts;
            return View();
        }
        [HttpPost]
        public ActionResult Transfer(FormCollection form)
        {
            bool isSuccess = false;
            string lawyer = form["mainLawyerlookup.Code"];//在办律师
            string TransferTo = form["consultantlookup.Code"];//转移给
            string transferType = form["CaseTransferType"];//转移类型
            string courtCodes = form["courtCode"];//法院Guid
            courtCodes = courtCodes == "" ? courtCodes : courtCodes.Substring(0, courtCodes.Length - 1);
            isSuccess = _caseWCF.CaseTransfer(new Guid(lawyer), new Guid(TransferTo), transferType, courtCodes);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("案件信息转移成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshParent));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("案件信息转移失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 案件转化
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <param name="source">source=1：案件列表点击弹出 2：消息列表点击弹出</param>
        /// <returns></returns>
        public ActionResult CaseTransformation(string caseCode, int? type)
        {
            InitializationPageParameter();
            ViewBag.type = type;
            CommonService.Model.CaseManager.B_Case bcase = _caseWCF.GetModel(new Guid(caseCode));

            #region 案件变更
            if (type == 2)
            {
                List<CommonService.Model.CaseManager.B_CaseLevelchange> caseLevelChanges = _caseLevelchangeWCF.GetListByCaseCode(new Guid(caseCode), 1);//1-获取待审核记录
                ViewBag.caseLevelChanges = caseLevelChanges;
                CommonService.Model.CaseManager.B_CaseLevelChangeRecords caseLevelChangeRecords = _caseLevelChangeRecordsWCF.GetModelByCaseCode(new Guid(caseCode));
                ViewBag.caseLevelChangeRecords = caseLevelChangeRecords;
            }
            else
            {
                bool isChange = _caseLevelchangeWCF.IsChange(new Guid(caseCode));
                List<CommonService.Model.CaseManager.B_CaseLevelchange> caseLevelChanges = _caseLevelchangeWCF.GetListByCaseCode(new Guid(caseCode), isChange ? 2 : 1);//1-获取待审核记录
                ViewBag.caseLevelChanges = caseLevelChanges;
            }
            #endregion

            #region 部门人员
            CommonService.Model.SysManager.C_Userinfo userinfo = new CommonService.Model.SysManager.C_Userinfo();
            if (bcase.B_Consultant_code != null && bcase.B_Consultant_code != "")
            {
                string[] consultantStr = bcase.B_Consultant_code.Split(',');
                userinfo = _userinfoWCF.GetModelByUserCode(new Guid(consultantStr[0]));
                ViewBag.userinfo = userinfo;
            }
            else
            {
                ViewBag.userinfo = userinfo;
            }
            #endregion

            #region 预期收益 文书收入 逾期收入
            List<CommonService.Model.FlowManager.P_Business_flow> BusinessFlows = _bussinessFlowWCF.GetListByFkCodeAndLevel(new Guid(caseCode), 1);
            //预期收益
            string expectedGrant = "0";
            //文书
            string DocumValue = "0";
            string yqsrValue = "0";
            if (BusinessFlows.Count > 0)
            {
                foreach (var item in BusinessFlows.OrderBy(p => p.P_Business_createTime).ToList())
                {
                    var flowformlist = _businessFlowFormWCF.GetBusinessFlowForms(item.P_Business_flow_code.Value);
                    //128EBF60-F58E-4AE2-B3B7-826DD62A0960(预期收益计算)
                    expectedGrant = BindFormValue(expectedGrant, flowformlist, Guid.Parse("128EBF60-F58E-4AE2-B3B7-826DD62A0960"), "预期收入额");
                    // 诉讼办案小结2E091784-C303-4BA5-99E6-DB33C29E48B2
                    DocumValue = BindFormValue(DocumValue, flowformlist, Guid.Parse("2E091784-C303-4BA5-99E6-DB33C29E48B2"), "文书收入(元)");
                    //执行方案 321694F2-853F-434B-B255-91A907586523
                    yqsrValue = BindFormValue(yqsrValue, flowformlist, Guid.Parse("321694F2-853F-434B-B255-91A907586523"), "逾期收入(元)");
                }
            }
            ViewBag.expectedGrant = expectedGrant;
            ViewBag.DocumValue = DocumValue;
            ViewBag.yqsrValue = yqsrValue;
            ViewBag.BusinessFlows = BusinessFlows;
            #endregion

            return View(bcase);
        }
        private string BindFormValue(string expectedGrant, List<CommonService.Model.FlowManager.P_Business_flow_form> flowformlist, Guid F_Form_code, string F_FormProperty_showName)
        {
            if (flowformlist.Count > 0 && flowformlist.Where(p => p.F_Form_code == F_Form_code).Count() > 0)
            {
                //当该流程存在表单的时候
                foreach (var item2 in flowformlist)
                {
                    string formvalue = _caseWCF.GetFormValue(item2.P_Business_flow_form_code.Value.ToString(), F_FormProperty_showName, F_Form_code.ToString());

                    if (formvalue != null && formvalue != "")
                    {
                        expectedGrant = formvalue.Replace(".00", "");
                        break;
                    }
                }
            }
            return expectedGrant;
        }

        [HttpPost]
        public ActionResult Transformation(FormCollection form)
        {
            bool isSuccess = false;
            int type = Convert.ToInt32(form["type"]);//类型 1、申请转化 2、转化审核
            string caseCode = form["CaseCode"];//案件Guid
            string applicationPerson = Context.UIContext.Current.UserCode.ToString();//申请人
            string TransformationType = form["TransformationTypeId"];//转化类型
            string Reason = form["Reason"];//理由
            TransformationType = TransformationType == "" ? TransformationType : TransformationType.Substring(0, TransformationType.Length - 1);
            bool isChiefExpert = false;//是否首席专家
            if (Context.UIContext.Current.PostGroupCode == PostGroup.ChiefExpert)
            {
                isChiefExpert = true;
            }
            if (type == 1)
            {//案件转化
                isSuccess = _caseWCF.CaseTransformation(new Guid(caseCode), new Guid(applicationPerson), TransformationType, Reason, Context.UIContext.Current.IsPreSetManager, isChiefExpert);
            }
            else
            {//转化审核
                string CaseLevelchangeCodeStr = form["CaseLevelchangeCodeStr"];//案件级别变更Guid
                string CaseLevelchangeRecord = form["CaseLevelchangeRecord"];//案件级别变更记录Guid
                string ConversionReasons = form["ConversionReasons"];//审核理由
                string caseLevelChangeState = form["state"];//审核状态
                isSuccess = _caseWCF.CaseTransformationCheck(CaseLevelchangeCodeStr, Context.UIContext.Current.UserCode.Value, new Guid(CaseLevelchangeRecord), ConversionReasons, Context.UIContext.Current.IsPreSetManager, Convert.ToInt32(caseLevelChangeState));
            }
            if (isSuccess)
            {//成功
                string jsonStr = "案件转化信息已提交，待首席审核！";
                if (type == 2 || Context.UIContext.Current.PostGroupCode == PostGroup.ChiefExpert || Context.UIContext.Current.IsPreSetManager)
                {//首席专家和管理员直接审核通过
                    jsonStr = "案件转化信息审核通过！";
                }
                return Json(TipHelper.JsonData(jsonStr, "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshParent));
            }
            else
            {//失败
                string jsonStr = "案件转化信息提交失败！";
                if (type == 2 || Context.UIContext.Current.PostGroupCode == PostGroup.ChiefExpert || Context.UIContext.Current.IsPreSetManager)
                {
                    jsonStr = "案件转化信息审核失败！";
                }
                return Json(TipHelper.JsonData(jsonStr, "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// 根据客户获得客户信息
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        public JsonResult GetContacter(string customerCode)
        {
            CommonService.Model.C_Customer model = _customerWCF.Get(new Guid(customerCode));
            if (model != null&&model.C_Customer_consultant_name!=null)
            {
                return Json(model.C_Customer_consultant_name);
            }
            else
            {
                return Json("");
            }
            
        }
        /// <summary>
        /// 根据案件Guid查询是否有待审核的变更数据
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        public ActionResult IsNotAudited(string caseCode)
        {
            bool isSuccess = _caseLevelchangeWCF.IsNotAudited(new Guid(caseCode));
            return Json(isSuccess.ToString());
        }
        /// <summary>
        /// 案件级别变更记录
        /// </summary>
        /// <param name="caseCode">案件Guid</param>
        /// <returns></returns>
        public ActionResult ChangeRecordLevel(string caseCode)
        {
            List<CommonService.Model.CaseManager.B_CaseLevelChangeRecords> levelChangeRecords = _caseLevelChangeRecordsWCF.GetListByCaseCode(new Guid(caseCode));
            return View(levelChangeRecords);
        }
        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //案件类型参数集合
            List<CommonService.Model.C_Parameters> Case_type = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.案件类型));
            ViewBag.Case_type = Case_type;
            //案件性质参数集合
            List<CommonService.Model.C_Parameters> Case_nature = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.案件性质));
            ViewBag.Case_nature = Case_nature;
            //客户类型参数集合
            List<CommonService.Model.C_Parameters> Case_customerType = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.客户类型));
            ViewBag.Case_customerType = Case_customerType;
            //进行状态参数集合
            List<CommonService.Model.C_Parameters> Case_state = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(BusinessFlowEnum.业务流程状态));
            ViewBag.Case_state = Case_state;
            //转移类型参数集合
            List<CommonService.Model.C_Parameters> TransferType = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseTransferType.转移类型));
            ViewBag.TransferType = TransferType;
            //案件级别参数集合
            List<CommonService.Model.C_Parameters> CaseLevel = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.案件级别));
            ViewBag.CaseLevel = CaseLevel;
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        /// <param name="crival">个人对象</param>
        private void InitializationPageParameter(CommonService.Model.CaseManager.B_Case cases)
        {
            //案件类型参数集合
            CommonService.Model.C_Parameters Case_type = _parameterWCF.GetModel(cases.B_Case_type.Value);
            ViewBag.Case_type = Case_type;
            //案件性质参数集合
            CommonService.Model.C_Parameters Case_nature = _parameterWCF.GetModel(cases.B_Case_nature.Value);
            ViewBag.Case_nature = Case_nature;
            //客户类型参数集合
            CommonService.Model.C_Parameters Case_customerType = _parameterWCF.GetModel(cases.B_Case_customerType.Value);
            ViewBag.Case_customerType = Case_customerType;
        }

        #region 数据导出功能
        public FileResult Export(FormCollection form, int? page = 1)
        {
            InitializationPageParameter();

            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //案件查询模型
            CommonService.Model.CaseManager.B_Case caseConditon = new CommonService.Model.CaseManager.B_Case();

            //案件查询模型传递到前端视图中
            caseConditon.B_Case_oprationtype = 1;
            List<CommonService.Model.C_Parameters> casesta = _parameterWCF.GetChildrenByParentId(198);
            ViewBag.casesta = casesta;
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.RegionList = regionList;
            List<CommonService.Model.FlowManager.P_Flow> flowList = _flowWCF.GetListByFlowType(Convert.ToInt32(FlowTypeEnum.案件));
            List<CommonService.Model.FlowManager.P_Flow> casestage = new List<CommonService.Model.FlowManager.P_Flow>();
            flowList = SetSingleTopFlow(flowList, casestage);

            int caseType = 1;//默认全部案件
            if (!String.IsNullOrEmpty(form["caseType"]))
            {
                caseType = Convert.ToInt32(form["caseType"]);
            }
            if (Request.QueryString["caseType"] != null)
            {
                caseType = Convert.ToInt32(Request.QueryString["caseType"]);
            }
            this.AddressUrlParameters = "?caseType=" + caseType;
            ViewBag.caseType = caseType;

            #region  业务查询条件
            //针对律师案件列表(我的未开始、我的在办、我的已结案件列表)的固定查询模型
            CommonService.Model.Customer.V_LawyerCondition vLawyerCond = null;
            int lawyerType = 0;//律师类型
            if (caseType == 2 || caseType == 3 || caseType == 4)
            {
                if (!String.IsNullOrEmpty(form["lawyerType"]))
                {
                    lawyerType = Convert.ToInt32(form["lawyerType"]);
                }
                if (Request.QueryString["lawyerType"] != null)
                {
                    lawyerType = Convert.ToInt32(Request.QueryString["lawyerType"]);
                }
                this.AddressUrlParameters += "&lawyerType=" + lawyerType;
                if (vLawyerCond == null)
                    vLawyerCond = new CommonService.Model.Customer.V_LawyerCondition();
                vLawyerCond.LawyerCode = Context.UIContext.Current.UserCode;
                vLawyerCond.LawyerType = lawyerType;

                if (caseType == 2)//我的未开始
                    vLawyerCond.OperateStatus = Convert.ToInt32(BusinessFlowStatus.未开始);
                else if (caseType == 3)//我的在办
                    vLawyerCond.OperateStatus = Convert.ToInt32(BusinessFlowStatus.正在进行);
                else if (caseType == 4)//我的已结
                    vLawyerCond.OperateStatus = Convert.ToInt32(BusinessFlowStatus.已结束);

                ViewBag.caseType = caseType;
            }
            else if (caseType == 5)
            { //未开始案件
                ViewBag.caseType = 5;
                caseConditon.B_Case_state = Convert.ToInt32(BusinessFlowStatus.未开始);
            }
            else if (caseType == 6)
            { //在办案件
                ViewBag.caseType = 6;
                caseConditon.B_Case_state = Convert.ToInt32(BusinessFlowStatus.正在进行);
            }
            else if (caseType == 7)
            { //已结案件
                ViewBag.caseType = 7;
                caseConditon.B_Case_state = Convert.ToInt32(BusinessFlowStatus.已结束);
            }

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

            ViewBag.casestage = casestage;
            ViewBag.CaseConditon = caseConditon;
            #endregion

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取案件数据信息
            List<CommonService.Model.CaseManager.B_Case> cases = _caseWCF.ExportPowerListByPage(vLawyerCond, caseConditon,
                "", 1, 1000000, UIContext.Current.IsPreSetManager, 
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);

            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("案件信息");

            //貌似这里可以设置各种样式字体颜色背景等，但是不是很方便，这里就不设置了

            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);

            row1.CreateCell(0).SetCellValue("案件级别");
            row1.CreateCell(1).SetCellValue("原告");
            row1.CreateCell(2).SetCellValue("被告");
            row1.CreateCell(3).SetCellValue("稽查情况");
            row1.CreateCell(4).SetCellValue("进程状态");
            row1.CreateCell(5).SetCellValue("任务阶段");
            row1.CreateCell(6).SetCellValue("预收案时间");
            row1.CreateCell(7).SetCellValue("区域");
            row1.CreateCell(8).SetCellValue("案件类型");
            row1.CreateCell(9).SetCellValue("专业顾问");
            row1.CreateCell(10).SetCellValue("案件状态");
            row1.CreateCell(11).SetCellValue("案件编码");
            row1.CreateCell(12).SetCellValue("所属商机");
            row1.CreateCell(13).SetCellValue("预期收入(元)");
            row1.CreateCell(14).SetCellValue("文书收入(元)");       
            row1.CreateCell(15).SetCellValue("逾期收入(元)");
            //....N行

            //将数据逐步写入sheet1各个行
            StringBuilder entry_Statistics_Details = new StringBuilder();//进程情况           
            for (int i = 0; i < cases.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(cases[i].B_Case_caseGrade);

                string[] yuanBeiGao = cases[i].B_Case_name.Split('_');

                rowtemp.CreateCell(1).SetCellValue(yuanBeiGao[0]);//原告
                rowtemp.CreateCell(2).SetCellValue(yuanBeiGao.Length >= 3 ? yuanBeiGao[2] : "");//被告

                if (cases[i].B_Case_IsCheckAuthority)
                {
                    rowtemp.CreateCell(3).SetCellValue("被稽查");
                }
                else
                {
                    rowtemp.CreateCell(3).SetCellValue("");
                }
                #region 进程情况
                entry_Statistics_Details.Clear();
                if (cases[i].B_Case_Delay_Entry_Statistics_Count > 0)
                {                
                    entry_Statistics_Details.Append("有延期 ");
                }
                if (cases[i].B_Case_HandlingState_Entry_Statistics_Count > 0 && cases[i].B_Case_WarningSituation_Entry_Statistics_Count > 0)
                {                   
                    entry_Statistics_Details.Append("已超时");
                }
                else if (cases[i].B_Case_HandlingState_Entry_Statistics_Count > 0 && cases[i].B_Case_WarningSituation_Entry_Statistics_Count <= 0)
                {
                    entry_Statistics_Details.Append("已超时");                  
                }
                else if (cases[i].B_Case_HandlingState_Entry_Statistics_Count <= 0 && cases[i].B_Case_WarningSituation_Entry_Statistics_Count > 0)
                {
                    entry_Statistics_Details.Append("预警");                  
                }
                rowtemp.CreateCell(4).SetCellValue(entry_Statistics_Details.ToString());
                #endregion
                rowtemp.CreateCell(5).SetCellValue(cases[i].B_Case_StageName);//任务阶段
                rowtemp.CreateCell(6).SetCellValue(cases[i].B_Case_registerTime == null ? "" : cases[i].B_Case_registerTime.Value.ToString("yyyy-MM-dd"));
                rowtemp.CreateCell(7).SetCellValue(cases[i].C_Region_name);//区域
                rowtemp.CreateCell(8).SetCellValue(cases[i].B_Case_type_name);//案件类型
                rowtemp.CreateCell(9).SetCellValue(cases[i].B_Case_consultant_name);//专业顾问
                rowtemp.CreateCell(10).SetCellValue(cases[i].B_Case_state_name);//案件状态
                rowtemp.CreateCell(11).SetCellValue(cases[i].B_Case_number);
                rowtemp.CreateCell(12).SetCellValue(cases[i].B_Case_businessChance_Name);
                rowtemp.CreateCell(13).SetCellValue(cases[i].B_Case_expectedGrant == null ? "" : cases[i].B_Case_expectedGrant.Value.ToString("0.00"));//预期收入
                rowtemp.CreateCell(14).SetCellValue(cases[i].B_Case_wenshuInCome == null ? "" : cases[i].B_Case_wenshuInCome.Value.ToString("0.00"));//文书收入              
                rowtemp.CreateCell(15).SetCellValue(cases[i].B_Case_yuqiInCome == null ? "" : cases[i].B_Case_yuqiInCome.Value.ToString("0.00"));//逾期收入
 
                //....N行
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "案件列表" + dateTime + ".xls";
            return File(ms, "application/vnd.ms-excel", fileName);
        }
        #endregion

        #region 生成文书导出功能

        public void ExeWrite(string caseCode)
        {
            InitializationPageParameter();


            #region 权限
            this.InitializationButtonsPower();
            #endregion

            CommonService.Model.CaseManager.B_Case bcase = _caseWCF.GetModel(new Guid(caseCode));
            var dbcontext = bcase;


            String templatePath = "F:\\TFS_Server\\WebCollection\\KZERP\\CommonServiceNew\\Portal\\npoi\\templete\\民事起诉状模板.docx";
            FileStream ist = new FileStream(templatePath, FileMode.Open);
            XWPFDocument doc = new XWPFDocument(ist);
            XWPFWordExtractor extractor = new XWPFWordExtractor(doc);



            extractor.Text.Replace("${param1}", "高俊");



            var fname = dbcontext.B_Case_number;
            ////保存文件到磁盘
            //FileStream out1 = new FileStream(fname + ".docx", FileMode.Create);
            //doc.Write(out1);
            //out1.Close();
            // Response.TransmitFile(fname + ".docx");
            Response.ContentType = "docx";
            Response.Write(extractor.Text);
            Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fname + ".docx", System.Text.Encoding.UTF8));
            Response.End();













            ////创建document对象
            //XWPFDocument doc = new XWPFDocument();
            ////创建段落对象
            //XWPFParagraph p1 = doc.CreateParagraph();
            //p1.SetAlignment(ParagraphAlignment.CENTER);
            ////创建run对象
            ////本节提到的所有样式都是基于XWPFRun的，
            ////你可以把XWPFRun理解成一小段文字的描述对象，
            ////这也是Word文档的特征，即文本描述性文档。
            ////来自Tony Qu http://tonyqus.sinaapp.com/archives/609
            //XWPFRun r1 = p1.CreateRun();          
            //r1.SetBold(true);
            //r1.SetText("民事起诉状");
            //r1.SetFontFamily("Arial");//设置雅黑字体
            //r1.SetFontSize(36);
            ////创建表格对象列数写死了，可根据自己需要改进或者自己想想解决方案
            //XWPFRun r2 = p1.CreateRun();

            //r2.SetBold(true);
            //r2.SetText("原告：");
            //r2.SetFontSize(12);
            //var fname = dbcontext.B_Case_number;
            ////保存文件到磁盘
            //FileStream out1 = new FileStream(fname + ".docx", FileMode.Create);
            //doc.Write(out1);

            //out1.Close();
            //Response.TransmitFile(out1.Name);
            //Response.ContentType = "docx";
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fname + ".docx", System.Text.Encoding.UTF8));
            //Response.End();
        }








        #endregion
    }
}