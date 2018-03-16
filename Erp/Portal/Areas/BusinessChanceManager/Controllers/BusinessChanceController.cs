using CommonService.Common;
using Context;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.BusinessChanceManager.Controllers
{
    /// <summary>
    /// 商机控制器
    /// </summary>
    public class BusinessChanceController : BaseController
    {
        private readonly ICommonService.BusinessChanceManager.IB_BusinessChance _businessChanceWCF;
        private readonly ICommonService.BusinessChanceManager.IB_BusinessChance_link _businessChance_linkWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.IC_Region _regionWCF;
        private readonly ICommonService.SysManager.IC_Role_Role_Power _roleRolePowerWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.FlowManager.IP_Flow _flowWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;
        private readonly ICommonService.IC_Customer_ChangHistory _customer_ChangHistoryWCF;
        private readonly ICommonService.IC_Messages _messageWCF;
        private readonly ICommonService.SysManager.IC_Userinfo_area _userinfo_areaWCF;
        private readonly ICommonService.IC_Customer _customerWCF;

        public BusinessChanceController()
        {
            #region 服务初始化
            _businessChanceWCF = ServiceProxyFactory.Create<ICommonService.BusinessChanceManager.IB_BusinessChance>("BusinessChanceWCF");
            _businessChance_linkWCF = ServiceProxyFactory.Create<ICommonService.BusinessChanceManager.IB_BusinessChance_link>("BusinessChance_linkWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
            _roleRolePowerWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Role_Role_Power>("Role_Role_PowerWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _flowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow>("FlowWCF");
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            _customer_ChangHistoryWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer_ChangHistory>("Customer_ChangHistoryWCF");
            _messageWCF = ServiceProxyFactory.Create<ICommonService.IC_Messages>("MessagesWCF");
            _userinfo_areaWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo_area>("Userinfo_areaWCF");
            _customerWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer>("CustomerWCF");
            #endregion
        }
        //
        // GET: /BusinessChanceManager/BusinessChance/
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 案件tab
        /// </summary>
        /// <returns></returns>
        public ActionResult BusinessChanceTab()
        {
            /***
             * author:崔慧栋
             * date:2016-01-26
             * description:按岗位进行划分案件Tab页签(一人多岗位，每个岗位角色权限可以不一样)(内置系统管理员不需要按Tab页签划分)           
             ***/
            if (UIContext.Current.IsPreSetManager)
            {
                return RedirectToAction("list");
            }            

            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            InitializationPageParameter();
            //创建初始化案件实体
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = new CommonService.Model.BusinessChanceManager.B_BusinessChance();
            businessChance.B_BusinessChance_code = Guid.NewGuid();
            businessChance.B_BusinessChance_state = Convert.ToInt32(BusinessFlowStatus.未开始);
            businessChance.B_BusinessChance_checkStatus = Convert.ToInt32(BusinessChanceCheckEnum.未审查);
            businessChance.B_BusinessChance_registerTime = DateTime.Now;
            businessChance.B_BusinessChance_obtainTime = DateTime.Now;
            businessChance.B_BusinessChance_creator = Context.UIContext.Current.UserCode;
            businessChance.B_BusinessChance_createTime = DateTime.Now;
            businessChance.B_BusinessChance_isDelete = 0;
            List<CommonService.Model.SysManager.C_Userinfo_region> userinfoRegion = _userinfo_areaWCF.GetListByUserinfoCode(Context.UIContext.Current.UserCode.Value);
            CommonService.Model.C_Region regionModel = new CommonService.Model.C_Region();
            List<CommonService.Model.C_Region> regionList = new List<CommonService.Model.C_Region>();
            if (userinfoRegion.Count() > 0)
            {
                regionModel.C_Region_code = userinfoRegion.FirstOrDefault().C_Region_code;
                regionModel.C_Region_name = userinfoRegion.FirstOrDefault().C_Region_name;
                regionList.Add(regionModel);
            }
            if (regionList.Count() == 0)
            {
                regionList = _regionWCF.GetAllSpecialList();
            }
            ViewBag.RegionList = regionList;

            return View(businessChance);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string businessChance_code)
        {
            InitializationPageParameter();
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(new Guid(businessChance_code));

            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.RegionList = regionList;

            return View("Create", businessChance);
        }

        /// <summary>
        /// 编辑其他要求
        /// </summary>
        /// <returns></returns>
        public ActionResult BusinessChanceEditRequirement(string businessChance_code)
        {
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(new Guid(businessChance_code));
            //bcase.B_Case_number = bcase.B_Case_number == null ? bcase.B_Case_number : bcase.B_Case_number.Substring(0, bcase.B_Case_number.Length - 4);
            return View(businessChance);
        }

        /// <summary>
        /// 其他要求详细
        /// </summary>
        /// <returns></returns>
        public ActionResult RequirementDetail(string businessChance_code)
        {
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(new Guid(businessChance_code));
            return View(businessChance);
        }

        /// <summary>
        /// 编辑计划任务
        /// </summary>
        /// <returns></returns>
        public ActionResult BusinessChanceEditPlantask(string businessChanceCode)
        {
            List<CommonService.Model.SysManager.C_Userinfo> users = _userinfoWCF.GetFirstOrMiniterList(2);
            List<CommonService.Model.SysManager.C_Userinfo> firstUsers = _userinfoWCF.GetFirstOrMiniterList(1);
            ViewBag.loginUser = Context.UIContext.Current.UserCode;
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(new Guid(businessChanceCode));
            #region 只取商机所在区域的首席专家和部长
            if (businessChance != null)
            {
                List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> bLists = _businessChance_linkWCF.GetBusinessChanceLinks(businessChance.B_BusinessChance_code.Value, Convert.ToInt32(BusinessChancelinkEnum.区域));
                if (bLists.Count() > 0)
                {
                    CommonService.Model.BusinessChanceManager.B_BusinessChance_link model = new CommonService.Model.BusinessChanceManager.B_BusinessChance_link();
                    model = bLists[0];
                    for (int i = 0; i < firstUsers.Count(); i++)
                    {
                        if (firstUsers[i].C_Userinfo_Regioncode != model.C_FK_code)
                        {
                            firstUsers.Remove(firstUsers[i]);
                        }
                    }
                    for (int i = 0; i < users.Count(); i++)
                    {
                        if (users[i].C_Userinfo_Regioncode != model.C_FK_code)
                        {
                            users.Remove(users[i]);
                        }
                    }
                }
            }
            #endregion
            ViewBag.firstUsers = firstUsers;
            ViewBag.users = users;
            return View(businessChance);
        }

        /// <summary>
        /// 启动商机任务
        /// </summary>
        /// <returns></returns>
        public ActionResult StartBusinessChance(string businessChanceCode)
        {
            CommonService.Model.BusinessChanceManager.B_BusinessChance buinessChance = _businessChanceWCF.GetModel(new Guid(businessChanceCode));
            if (buinessChance.B_BusinessChance_state == Convert.ToInt32(BusinessFlowStatus.未开始))
            {
                bool isUpdateSuccess = _businessChanceWCF.UpdateState(new Guid(businessChanceCode), Context.UIContext.Current.UserCode.Value);
                if (isUpdateSuccess)
                {
                    //保存成功提示固定写法
                    return Json(TipHelper.JsonData("成功启动商机任务！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
                }
                else
                {
                    //保存失败固定写法
                    return Json(TipHelper.JsonData("启动商机任务失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
            }
            else
            {
                return Json(TipHelper.JsonData("不可重复启动！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }

        }

        /// <summary>
        /// 商机信息
        /// </summary>
        /// <param name="businessChanceCode">商机Code</param>
        /// <param name="type">1、修改按钮  2、商机计划</param>
        /// <returns></returns>
        public ActionResult BusinessChanceTabDetails(string businessChanceCode, int type)
        {
            ViewBag.BusinessChanceCode = businessChanceCode;
            ViewBag.Type = type;

            #region 权限
            List<CommonService.Model.SysManager.C_Role_Role_Power> roleRolePowers;
            if (Context.UIContext.Current.IsPreSetManager)
            {
                roleRolePowers = new List<CommonService.Model.SysManager.C_Role_Role_Power>();
            }
            else
            {
                roleRolePowers = _roleRolePowerWCF.GetRolePowersByOrgPostUserCode(Context.UIContext.Current.OrgCode, Context.UIContext.Current.UserCode, Context.UIContext.Current.PostCode);
            }
            ViewBag.RoleRolePowers = roleRolePowers;

            this.InitializationButtonsPower();
            #endregion

            return View();
        }

        /// <summary>
        /// 商机详细信息
        /// </summary>
        /// <param name="businessChanceCode"></param>
        /// <returns></returns>
        public ActionResult TabDetails(string businessChanceCode, string type)
        {
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(new Guid(businessChanceCode));
            if (businessChance.B_BusinessChance_state == 1)
            {
                ViewBag.state = true;
            }
            else
            {
                ViewBag.state = false;
            }
            ViewBag.BusinessChanceCode = businessChanceCode;
            ViewBag.businessChancePerson = businessChance.B_BusinessChance_person;
            ViewBag.type = type;
            return View();
        }

        /// <summary>
        /// 商机详细
        /// </summary>
        /// <param name="businessChanceCode"></param>
        /// <returns></returns>
        public ActionResult Details(string businessChanceCode)
        {
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(new Guid(businessChanceCode));
            InitializationPageParameter(businessChance);
            return View(businessChance);
        }

        /// <summary>
        /// 计划商机Action
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <returns></returns>
        public ActionResult BusinessChancePlan(string businessChanceCode)
        {
            ViewBag.BusinessChangeCode = businessChanceCode;
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

            //商机查询模型
            CommonService.Model.BusinessChanceManager.B_BusinessChance bChanceConditon = new CommonService.Model.BusinessChanceManager.B_BusinessChance();

            List<CommonService.Model.FlowManager.P_Flow> casestage = _flowWCF.GetListByFlowType(Convert.ToInt32(FlowTypeEnum.商机));
            ViewBag.casestage = casestage;
            bChanceConditon.B_BusinessChance_oprationtype = 1;
            //商机名称查询条件
            if (!String.IsNullOrEmpty(form["B_BusinessChance_name"]))
            {
                bChanceConditon.B_BusinessChance_name = form["B_BusinessChance_name"].Trim();
            }
            //商机编码
            if (!String.IsNullOrEmpty(form["B_BusinessChance_number"]))
            {
                bChanceConditon.B_BusinessChance_number = form["B_BusinessChance_number"].Trim();
            }
            //收案时间
            if ((!String.IsNullOrEmpty(form["B_BusinessChance_registerTime"])) && (!String.IsNullOrEmpty(form["B_BusinessChance_regiendTime"])))
            {
                bChanceConditon.B_BusinessChance_registerTime = Convert.ToDateTime(form["B_BusinessChance_registerTime"]);
                bChanceConditon.B_BusinessChance_registerTime2 = Convert.ToDateTime(form["B_BusinessChance_regiendTime"]);
            }
            //委托人
            if (!String.IsNullOrEmpty(form["clientmulitylookup.Code"]))
            {
                bChanceConditon.B_BusinessChance_Client_code = form["clientmulitylookup.Code"];
                bChanceConditon.B_BusinessChance_Client_name = form["clientmulitylookup.Name"];
            }
            //当事人
            if (!String.IsNullOrEmpty(form["rivallookupParty.Code"]))
            {
                bChanceConditon.B_BusinessChance_Person_code = form["rivallookupParty.Code"];
                bChanceConditon.B_BusinessChance_Person_name = form["rivallookupParty.Name"];
                bChanceConditon.B_BusinessChance_Person_type = form["rivallookupParty.Type"];
            }
            //专业顾问
            if (!String.IsNullOrEmpty(form["mainLawyerlookup.Code"]))
            {
                bChanceConditon.B_BusinessChance_consultant_code = form["mainLawyerlookup.Code"];
                bChanceConditon.B_BusinessChance_consultant_name = form["mainLawyerlookup.Name"];
            }
            //涉案项目
            if (!String.IsNullOrEmpty(form["projectlookup.Code"]))
            {
                bChanceConditon.B_BusinessChance_Project_code = form["projectlookup.Code"];
                bChanceConditon.B_BusinessChance_Project_name = form["projectlookup.Name"];
            }
            //案件状态
            if (!String.IsNullOrEmpty(form["B_BusinessChance_state"]) && form["B_BusinessChance_state"].ToString() != "全部")
            {
                bChanceConditon.B_BusinessChance_state = Convert.ToInt32(form["B_BusinessChance_state"]);
            }
            //商机审查状态
            if (!String.IsNullOrEmpty(form["B_BusinessChance_checkStatus"]) && form["B_BusinessChance_checkStatus"].ToString() != "全部")
            {
                bChanceConditon.B_BusinessChance_checkStatus = Convert.ToInt32(form["B_BusinessChance_checkStatus"]);
            }
            //法院
            if (!String.IsNullOrEmpty(form["courtlookupOne.Code"]))
            {
                bChanceConditon.B_BusinessChance_courtFirst = new Guid(form["courtlookupOne.Code"]);
                bChanceConditon.B_BusinessChance_courtFirstName = form["courtlookupOne.Name"];
            }
            //商机类型
            if (!String.IsNullOrEmpty(form["B_BusinessChance_type"]) && form["B_BusinessChance_type"].ToString() != "全部")
            {
                bChanceConditon.B_BusinessChance_type = Convert.ToInt32(form["B_BusinessChance_type"]);
            }
            //办案阶段
            if (!String.IsNullOrEmpty(form["B_BusinessChance_stage"]) && form["B_BusinessChance_stage"].ToString() != "全部")
            {
                bChanceConditon.B_BusinessChance_stage = form["B_BusinessChance_stage"];
            }
            //标的范围
            if ((!String.IsNullOrEmpty(form["B_BusinessChance_transferTargetMoney"])) && (!String.IsNullOrEmpty(form["B_BusinessChance_execMoney2"])))
            {
                bChanceConditon.B_BusinessChance_transferTargetMoney = Convert.ToDecimal(form["B_BusinessChance_transferTargetMoney"]);
                bChanceConditon.B_BusinessChance_execMoney2 = Convert.ToDecimal(form["B_BusinessChance_execMoney2"]);
            }
            //客户
            if (!String.IsNullOrEmpty(form["customermulitylookup.Code"]))
            {
                bChanceConditon.B_BusinessChance_Customer_code = form["customermulitylookup.Code"];
                bChanceConditon.B_BusinessChance_Customer_name = form["customermulitylookup.Name"];
            }
            //商机查询模型传递到前端视图中
            ViewBag.BChanceConditon = bChanceConditon;

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

            //获取客户地址总记录数
            this.TotalRecordCount = _businessChanceWCF.GetPowerRecordCount(bChanceConditon, UIContext.Current.IsPreSetManager, UIContext.Current.UserCode,
                postCode, orgCode);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取客户地址数据信息
            List<CommonService.Model.BusinessChanceManager.B_BusinessChance> buinessChance = _businessChanceWCF.GetPowerListByPage(bChanceConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, UIContext.Current.IsPreSetManager, UIContext.Current.UserCode, postCode, orgCode);


            #region 权限
            this.DistributedInitButtonsPower(orgCode, postCode);
            this.DistributedInitLogin(orgCode, postCode, postGroupCode);
            #endregion

            return View(buinessChance);
        }

        /// <summary>
        /// 列表关联商机
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult ListLink(FormCollection form, string customerCode, int type, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //商机查询模型
            CommonService.Model.BusinessChanceManager.B_BusinessChance bChanceConditon = new CommonService.Model.BusinessChanceManager.B_BusinessChance();

            List<CommonService.Model.FlowManager.P_Flow> casestage = _flowWCF.GetListByFlowType(Convert.ToInt32(FlowTypeEnum.商机));
            ViewBag.casestage = casestage;
            bChanceConditon.B_BusinessChance_oprationtype = 1;

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

            //商机名称查询条件
            if (!String.IsNullOrEmpty(form["B_BusinessChance_name"]))
            {
                bChanceConditon.B_BusinessChance_name = form["B_BusinessChance_name"].Trim();
            }
            //商机编码
            if (!String.IsNullOrEmpty(form["B_BusinessChance_number"]))
            {
                bChanceConditon.B_BusinessChance_number = form["B_BusinessChance_number"].Trim();
            }
            //收案时间
            if ((!String.IsNullOrEmpty(form["B_BusinessChance_registerTime"])) && (!String.IsNullOrEmpty(form["B_BusinessChance_regiendTime"])))
            {
                bChanceConditon.B_BusinessChance_registerTime = Convert.ToDateTime(form["B_BusinessChance_registerTime"]);
                bChanceConditon.B_BusinessChance_registerTime2 = Convert.ToDateTime(form["B_BusinessChance_regiendTime"]);
            }
            //委托人
            if (type == 3)
            {
                if (customerCode != null && customerCode != "" && type == 3)
                {
                    bChanceConditon.B_BusinessChance_Client_code = customerCode;

                }

                else
                {
                    if (!String.IsNullOrEmpty(form["clientmulitylookup.Code"]))
                    {
                        bChanceConditon.B_BusinessChance_Client_code = form["clientmulitylookup.Code"];
                        bChanceConditon.B_BusinessChance_Client_name = form["clientmulitylookup.Name"];
                    }
                }
            }
            if (type == 4)
            {
                bChanceConditon.B_BusinessChance_Person_code = customerCode;
            }
            else
            {
                if (!String.IsNullOrEmpty(form["rivallookupParty.Code"]))
                {//对方当事人查询条件
                    bChanceConditon.B_BusinessChance_Person_code = form["rivallookupParty.Code"];
                    bChanceConditon.B_BusinessChance_Person_name = form["rivallookupParty.Name"];
                    bChanceConditon.B_BusinessChance_Person_type = form["rivallookupParty.Type"];
                }
            }

            //专业顾问
            if (!String.IsNullOrEmpty(form["mainLawyerlookup.Code"]))
            {
                bChanceConditon.B_BusinessChance_consultant_code = form["mainLawyerlookup.Code"];
                bChanceConditon.B_BusinessChance_consultant_name = form["mainLawyerlookup.Name"];
            }
            //涉案项目
            if (type == 6)
            {
                bChanceConditon.B_BusinessChance_Project_code = customerCode;
            }
            else
            {
                if (!String.IsNullOrEmpty(form["projectlookup.Code"]))
                {
                    bChanceConditon.B_BusinessChance_Project_code = form["projectlookup.Code"];
                    bChanceConditon.B_BusinessChance_Project_name = form["projectlookup.Name"];
                }
            }

            //案件状态
            if (!String.IsNullOrEmpty(form["B_BusinessChance_state"]) && form["B_BusinessChance_state"].ToString() != "全部")
            {
                bChanceConditon.B_BusinessChance_state = Convert.ToInt32(form["B_BusinessChance_state"]);
            }
            if (type == 5)
            {
                bChanceConditon.B_BusinessChance_courtFirst = new Guid(customerCode);
            }
            else
            {
                if (!String.IsNullOrEmpty(form["courtlookupOne.Code"]))
                {//法院查询条件
                    bChanceConditon.B_BusinessChance_courtFirst = new Guid(form["courtlookupOne.Code"]);
                    bChanceConditon.B_BusinessChance_courtFirstName = form["courtlookupOne.Name"];
                }
            }

            //商机类型
            if (!String.IsNullOrEmpty(form["B_BusinessChance_type"]) && form["B_BusinessChance_type"].ToString() != "全部")
            {
                bChanceConditon.B_BusinessChance_type = Convert.ToInt32(form["B_BusinessChance_type"]);
            }
            //办案阶段
            if (!String.IsNullOrEmpty(form["B_BusinessChance_stage"]) && form["B_BusinessChance_stage"].ToString() != "全部")
            {
                bChanceConditon.B_BusinessChance_stage = form["B_BusinessChance_stage"];
            }
            //标的范围
            if ((!String.IsNullOrEmpty(form["B_BusinessChance_transferTargetMoney"])) && (!String.IsNullOrEmpty(form["B_BusinessChance_execMoney2"])))
            {
                bChanceConditon.B_BusinessChance_transferTargetMoney = Convert.ToDecimal(form["B_BusinessChance_transferTargetMoney"]);
                bChanceConditon.B_BusinessChance_execMoney2 = Convert.ToDecimal(form["B_BusinessChance_execMoney2"]);
            }
            //客户
            if (type == 2)
            {

                if (customerCode != null && customerCode != "" && type == 2)
                {
                    bChanceConditon.B_BusinessChance_Customer_code = customerCode;

                }
                else
                {
                    if (!String.IsNullOrEmpty(form["customermulitylookup.Code"]))
                    {//客户查询条件
                        bChanceConditon.B_BusinessChance_Customer_code = form["customermulitylookup.Code"];

                    }
                }
            }


            //商机查询模型传递到前端视图中
            ViewBag.BChanceConditon = bChanceConditon;

            #endregion
            this.PageSize = 10;
            //获取客户地址总记录数
            this.TotalRecordCount = _businessChanceWCF.GetPowerRecordCount(bChanceConditon, true, UIContext.Current.UserCode,
                null, null);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取客户地址数据信息
            List<CommonService.Model.BusinessChanceManager.B_BusinessChance> buinessChance = _businessChanceWCF.GetPowerListByPage(bChanceConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, true,
                UIContext.Current.UserCode, null, null);


            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View("ListLink", buinessChance);
        }

        /// <summary>
        /// 列表关联商机
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <returns></returns>

        #region 数据导出功能
        public FileResult Export(FormCollection form, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //商机查询模型
            CommonService.Model.BusinessChanceManager.B_BusinessChance bChanceConditon = new CommonService.Model.BusinessChanceManager.B_BusinessChance();

            List<CommonService.Model.FlowManager.P_Flow> casestage = _flowWCF.GetListByFlowType(Convert.ToInt32(FlowTypeEnum.商机));
            ViewBag.casestage = casestage;
            bChanceConditon.B_BusinessChance_oprationtype = 1;
            //商机名称查询条件
            if (!String.IsNullOrEmpty(form["B_BusinessChance_name"]))
            {
                bChanceConditon.B_BusinessChance_name = form["B_BusinessChance_name"].Trim();
            }
            //商机编码
            if (!String.IsNullOrEmpty(form["B_BusinessChance_number"]))
            {
                bChanceConditon.B_BusinessChance_number = form["B_BusinessChance_number"].Trim();
            }
            //收案时间
            if ((!String.IsNullOrEmpty(form["B_BusinessChance_registerTime"])) && (!String.IsNullOrEmpty(form["B_BusinessChance_regiendTime"])))
            {
                bChanceConditon.B_BusinessChance_registerTime = Convert.ToDateTime(form["B_BusinessChance_registerTime"]);
                bChanceConditon.B_BusinessChance_registerTime2 = Convert.ToDateTime(form["B_BusinessChance_regiendTime"]);
            }
            //委托人
            if (!String.IsNullOrEmpty(form["clientmulitylookup.Code"]))
            {
                bChanceConditon.B_BusinessChance_Client_code = form["clientmulitylookup.Code"];
                bChanceConditon.B_BusinessChance_Client_name = form["clientmulitylookup.Name"];
            }
            //当事人
            if (!String.IsNullOrEmpty(form["rivallookupParty.Code"]))
            {
                bChanceConditon.B_BusinessChance_Person_code = form["rivallookupParty.Code"];
                bChanceConditon.B_BusinessChance_Person_name = form["rivallookupParty.Name"];
                bChanceConditon.B_BusinessChance_Person_type = form["rivallookupParty.Type"];
            }
            //专业顾问
            if (!String.IsNullOrEmpty(form["mainLawyerlookup.Code"]))
            {
                bChanceConditon.B_BusinessChance_consultant_code = form["mainLawyerlookup.Code"];
                bChanceConditon.B_BusinessChance_consultant_name = form["mainLawyerlookup.Name"];
            }
            //涉案项目
            if (!String.IsNullOrEmpty(form["projectlookup.Code"]))
            {
                bChanceConditon.B_BusinessChance_Project_code = form["projectlookup.Code"];
                bChanceConditon.B_BusinessChance_Project_name = form["projectlookup.Name"];
            }
            //案件状态
            if (!String.IsNullOrEmpty(form["B_BusinessChance_state"]) && form["B_BusinessChance_state"].ToString() != "全部")
            {
                bChanceConditon.B_BusinessChance_state = Convert.ToInt32(form["B_BusinessChance_state"]);
            }
            //法院
            if (!String.IsNullOrEmpty(form["courtlookupOne.Code"]))
            {
                bChanceConditon.B_BusinessChance_courtFirst = new Guid(form["courtlookupOne.Code"]);
                bChanceConditon.B_BusinessChance_courtFirstName = form["courtlookupOne.Name"];
            }
            //商机类型
            if (!String.IsNullOrEmpty(form["B_BusinessChance_type"]) && form["B_BusinessChance_type"].ToString() != "全部")
            {
                bChanceConditon.B_BusinessChance_type = Convert.ToInt32(form["B_BusinessChance_type"]);
            }
            //办案阶段
            if (!String.IsNullOrEmpty(form["B_BusinessChance_stage"]) && form["B_BusinessChance_stage"].ToString() != "全部")
            {
                bChanceConditon.B_BusinessChance_stage = form["B_BusinessChance_stage"];
            }
            //标的范围
            if ((!String.IsNullOrEmpty(form["B_BusinessChance_execMoney"])) && (!String.IsNullOrEmpty(form["B_BusinessChance_execMoney2"])))
            {
                bChanceConditon.B_BusinessChance_execMoney = Convert.ToDecimal(form["B_BusinessChance_execMoney"]);
                bChanceConditon.B_BusinessChance_execMoney2 = Convert.ToDecimal(form["B_BusinessChance_execMoney2"]);
            }
            //客户
            if (!String.IsNullOrEmpty(form["customermulitylookup.Code"]))
            {
                bChanceConditon.B_BusinessChance_Customer_code = form["customermulitylookup.Code"];
                bChanceConditon.B_BusinessChance_Customer_name = form["customermulitylookup.Name"];
            }
            //商机查询模型传递到前端视图中
            ViewBag.BChanceConditon = bChanceConditon;

            #endregion


            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取案件数据信息
            List<CommonService.Model.BusinessChanceManager.B_BusinessChance> checkList = _businessChanceWCF.GetListByPage(bChanceConditon,
                "", 1, 1000000);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            //貌似这里可以设置各种样式字体颜色背景等，但是不是很方便，这里就不设置了

            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("商机名称");
            row1.CreateCell(1).SetCellValue("业务类型");
            row1.CreateCell(2).SetCellValue("预开庭时间");
            row1.CreateCell(3).SetCellValue("成功概率");
            row1.CreateCell(4).SetCellValue("执行标的(元)");
            row1.CreateCell(5).SetCellValue("商机概述");

            row1.CreateCell(6).SetCellValue("商机获取时间");
            row1.CreateCell(7).SetCellValue("商机进度");

            //....N行

            //将数据逐步写入sheet1各个行
            for (int i = 0; i < checkList.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(checkList[i].B_BusinessChance_name.ToString());

                if (checkList[i].B_BusinessChance_type == 142)
                {
                    rowtemp.CreateCell(1).SetCellValue("钢材");
                }
                else if (checkList[i].B_BusinessChance_type == 143)
                {
                    rowtemp.CreateCell(1).SetCellValue("架管");
                }
                else if (checkList[i].B_BusinessChance_type == 144)
                {
                    rowtemp.CreateCell(1).SetCellValue("混凝土");
                }
                else if (checkList[i].B_BusinessChance_type == 145)
                {
                    rowtemp.CreateCell(1).SetCellValue("其它");
                }
                rowtemp.CreateCell(2).SetCellValue(checkList[i].B_BusinessChance_registerTime.ToString());
                rowtemp.CreateCell(3).SetCellValue(checkList[i].B_BusinessChance_successProbability.ToString());
                rowtemp.CreateCell(4).SetCellValue(checkList[i].B_BusinessChance_execMoney.ToString());
                rowtemp.CreateCell(5).SetCellValue(checkList[i].B_BusinessChance_Outline.ToString());
                rowtemp.CreateCell(6).SetCellValue(checkList[i].B_BusinessChance_obtainTime.ToString());

                if (checkList[i].B_BusinessChance_state == 199)
                {
                    rowtemp.CreateCell(7).SetCellValue("未开始");
                }
                else if (checkList[i].B_BusinessChance_state == 200)
                {
                    rowtemp.CreateCell(7).SetCellValue("正在进行");
                }
                else if (checkList[i].B_BusinessChance_state == 201)
                {
                    rowtemp.CreateCell(7).SetCellValue("已结束");
                }

                //....N行
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "商机列表" + dateTime + ".xls";
            return File(ms, "application/vnd.ms-excel", fileName);
        }
        #endregion


        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance)
        {
            if (_businessChanceWCF.ExistsByName(businessChance))
            {//判断商机名称是否存在
                return Json(TipHelper.JsonData("此商机名称已存在！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            //服务方法调用
            int businessChance_id = 0;
            string regionCode = "";//区域Guid
            string regionAbbreviation = "";//区域简称
            string caseType = "";//商机类型简称
            businessChance.B_BusinessChance_courtFirst = String.IsNullOrEmpty(form["courtlookupOne.Code"]) ? Guid.Empty : new Guid(form["courtlookupOne.Code"]);
            businessChance.B_BusinessChance_courtSecond = String.IsNullOrEmpty(form["courtlookupTwo.Code"]) ? Guid.Empty : new Guid(form["courtlookupTwo.Code"]);
            businessChance.B_BusinessChance_courtExec = String.IsNullOrEmpty(form["courtlookupThree.Code"]) ? Guid.Empty : new Guid(form["courtlookupThree.Code"]);
            businessChance.B_BusinessChance_Competitor = String.IsNullOrEmpty(form["competitorlookup.Code"]) ? Guid.Empty : new Guid(form["competitorlookup.Code"]);
            string customerCodeStr = form["customermulitylookup.Code"];//客户Guid
            string customerNameStr = form["customermulitylookup.Name"];//客户名称
            string clientCodeStr = form["clientmulitylookup.Code"];//委托人Guid
            string clientNameStr = form["clientmulitylookup.Name"];//委托人名称
            string projectCodeStr = form["projectlookup.Code"];//工程Guid
            string projectNameStr = form["projectlookup.Name"];//工程名称
            string rivalCodeStr = form["rivallookupParty.Code"];//对方当事人Guid
            string rivalTypeStr = form["rivallookupParty.Type"];//对方当事人类型
            string rivalNameStr = form["rivallookupParty.Name"];//对方当事人名称
            string competitorName = form["competitorlookup.Name"];//竞争对手名称
            #region 参照值处理
            if (businessChance.B_BusinessChance_id == 0 || UIContext.Current.PostGroupCode == PostGroup.ChiefExpert || UIContext.Current.PostGroupCode == PostGroup.Minister || UIContext.Current.IsPreSetManager)
            {
                List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link> BusinessChanceLinks = new List<CommonService.Model.BusinessChanceManager.B_BusinessChance_link>();

                #region 客户集合
                if (!String.IsNullOrEmpty(customerCodeStr))
                {
                    string[] customerCodes = customerCodeStr.Split(',');
                    foreach (var customer_code in customerCodes)
                    {
                        CommonService.Model.BusinessChanceManager.B_BusinessChance_link businessChancelink = new CommonService.Model.BusinessChanceManager.B_BusinessChance_link();
                        businessChancelink.B_BusinessChance_code = businessChance.B_BusinessChance_code;
                        businessChancelink.C_FK_code = new Guid(customer_code);
                        businessChancelink.B_BusinessChance_link_type = Convert.ToInt32(BusinessChancelinkEnum.客户);
                        businessChancelink.B_BusinessChance_link_creator = Context.UIContext.Current.UserCode;
                        businessChancelink.B_BusinessChance_link_createTime = DateTime.Now;
                        businessChancelink.B_BusinessChance_link_isDelete = 0;

                        BusinessChanceLinks.Add(businessChancelink);
                        
                    }
                }
                #endregion

                #region 委托人集合
                if (!String.IsNullOrEmpty(clientCodeStr))
                {
                    string[] clientCodes = clientCodeStr.Split(',');
                    foreach (var client_code in clientCodes)
                    {
                        CommonService.Model.BusinessChanceManager.B_BusinessChance_link businessChancelink = new CommonService.Model.BusinessChanceManager.B_BusinessChance_link();
                        businessChancelink.B_BusinessChance_code = businessChance.B_BusinessChance_code;
                        businessChancelink.C_FK_code = new Guid(client_code);
                        businessChancelink.B_BusinessChance_link_type = Convert.ToInt32(BusinessChancelinkEnum.委托人);
                        businessChancelink.B_BusinessChance_link_creator = Context.UIContext.Current.UserCode;
                        businessChancelink.B_BusinessChance_link_createTime = DateTime.Now;
                        businessChancelink.B_BusinessChance_link_isDelete = 0;
                        BusinessChanceLinks.Add(businessChancelink);
                    }
                }
                #endregion

                #region 工程
                if (!String.IsNullOrEmpty(projectCodeStr))
                {
                    string[] projectCodes = projectCodeStr.Split(',');
                    foreach (var project_code in projectCodes)
                    {
                        CommonService.Model.BusinessChanceManager.B_BusinessChance_link project = new CommonService.Model.BusinessChanceManager.B_BusinessChance_link();
                        project.B_BusinessChance_code = businessChance.B_BusinessChance_code;
                        project.C_FK_code = new Guid(project_code);
                        project.B_BusinessChance_link_type = Convert.ToInt32(BusinessChancelinkEnum.工程);
                        project.B_BusinessChance_link_creator = Context.UIContext.Current.UserCode;
                        project.B_BusinessChance_link_createTime = DateTime.Now;
                        project.B_BusinessChance_link_isDelete = 0;

                        BusinessChanceLinks.Add(project);
                    }
                }
                #endregion

                #region 对方当事人
                if (!String.IsNullOrEmpty(rivalCodeStr))
                {
                    string[] partyCodes = rivalCodeStr.Split(',');
                    string[] partyType = rivalTypeStr.Split(',');
                    int i = 0;
                    if (partyCodes[0] != "")
                    {
                        foreach (var party_code in partyCodes)
                        {
                            CommonService.Model.BusinessChanceManager.B_BusinessChance_link thisPerson = new CommonService.Model.BusinessChanceManager.B_BusinessChance_link();
                            thisPerson.B_BusinessChance_code = businessChance.B_BusinessChance_code;
                            thisPerson.C_FK_code = new Guid(party_code);
                            thisPerson.B_BusinessChance_link_type = Convert.ToInt32(partyType[i]);
                            thisPerson.B_BusinessChance_link_creator = Context.UIContext.Current.UserCode;
                            thisPerson.B_BusinessChance_link_createTime = DateTime.Now;
                            thisPerson.B_BusinessChance_link_isDelete = 0;
                            BusinessChanceLinks.Add(thisPerson);
                            i++;
                        }
                    }
                }
                #endregion

                #region 区域
                string[] regionCodes = businessChance.B_BusinessChance_Region_code.Split(',');
                foreach (var region_code in regionCodes)
                {
                    CommonService.Model.BusinessChanceManager.B_BusinessChance_link region = new CommonService.Model.BusinessChanceManager.B_BusinessChance_link();
                    region.B_BusinessChance_code = businessChance.B_BusinessChance_code;
                    region.C_FK_code = new Guid(region_code);
                    region.B_BusinessChance_link_type = Convert.ToInt32(BusinessChancelinkEnum.区域);
                    region.B_BusinessChance_link_creator = Context.UIContext.Current.UserCode;
                    region.B_BusinessChance_link_createTime = DateTime.Now;
                    region.B_BusinessChance_link_isDelete = 0;

                    BusinessChanceLinks.Add(region);
                }
                #endregion

                _businessChance_linkWCF.OperateList(BusinessChanceLinks);

                regionCode = regionCodes.First();
                regionAbbreviation = _regionWCF.GetModelByCode(new Guid(regionCode)).C_Region_abbreviation;
                caseType = _parameterWCF.GetModel(businessChance.B_BusinessChance_type.Value).C_Parameters_abbreviation;
            }
            #endregion

            if (businessChance.B_BusinessChance_id > 0)
            {//修改
                businessChance.B_BusinessChance_Customer_code = customerCodeStr;
                businessChance.B_BusinessChance_Customer_name = customerNameStr;
                businessChance.B_BusinessChance_Client_code = clientCodeStr;
                businessChance.B_BusinessChance_Client_name = clientNameStr;
                businessChance.B_BusinessChance_Project_code = projectCodeStr;
                businessChance.B_BusinessChance_Project_name = projectNameStr;
                businessChance.B_BusinessChance_Person_code = rivalCodeStr;
                businessChance.B_BusinessChance_Person_name = rivalNameStr;
                businessChance.B_BusinessChance_Person_type = rivalTypeStr;
                businessChance.B_BusinessChance_Competitor_name = competitorName;
                businessChance.B_BusinessChance_courtFirstName = form["courtlookupOne.Name"];
                businessChance.B_BusinessChance_courtSecondName = form["courtlookupTwo.Name"];
                businessChance.B_BusinessChance_courtExecName = form["courtlookupThree.Name"];
                bool isUpdateSuccess = businessChanceChange(businessChance);
                if (isUpdateSuccess)
                {
                    businessChance_id = businessChance.B_BusinessChance_id;
                }
            }
            else
            {//添加
                businessChance.B_BusinessChance_number = "BO" + DateTime.Now.ToString("yyyy") + regionAbbreviation + "MS" + caseType;
                businessChance.B_BusinessChance_createTime = DateTime.Now;
                businessChance_id = _businessChanceWCF.Add(businessChance);
            }

            if (businessChance_id > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存商机信息成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存商机信息成功", "/BusinessChanceManager/BusinessChance/create", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存商机信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存商机信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 记录修改后的商机信息
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <returns></returns>
        private bool businessChanceChange(CommonService.Model.BusinessChanceManager.B_BusinessChance newBusinessChance)
        {
            CommonService.Model.BusinessChanceManager.B_BusinessChance oldBusinessChance = _businessChanceWCF.GetModel(newBusinessChance.B_BusinessChance_code.Value);
            List<CommonService.Model.C_Customer_ChangHistory> customerChangHistoryList = new List<CommonService.Model.C_Customer_ChangHistory>();

            //新商机实体
            Type newCustomerType = newBusinessChance.GetType();
            System.Reflection.PropertyInfo[] newBusinessChancePs = newCustomerType.GetProperties();
            //老商机实体
            Type oldCustomerType = oldBusinessChance.GetType();
            System.Reflection.PropertyInfo[] oldBusinessChancePs = oldCustomerType.GetProperties();

            #region 记录修改后的商机信息
            for (int i = 0; i < newBusinessChancePs.Count(); i++)
            {
                object oldObj = oldBusinessChancePs[i].GetValue(oldBusinessChance, null);
                //string oldName = oldCustomerPs[i].Name;
                object newObj = newBusinessChancePs[i].GetValue(newBusinessChance, null);
                //string newName = newCustomerPs[i].Name;
                if (newObj != null && newObj != "")
                {
                    if (!newObj.Equals(oldObj))
                    {
                        CommonService.Model.C_Customer_ChangHistory customerChangHistory = new CommonService.Model.C_Customer_ChangHistory();
                        customerChangHistory.C_Customer_ChangHistory_code = Guid.NewGuid();
                        customerChangHistory.C_Customer_ChangHistory_customer = newBusinessChance.B_BusinessChance_code.Value;
                        customerChangHistory.C_Customer_ChangHistory_type = Convert.ToInt32(ChangHistoryTypeEnum.商机);
                        customerChangHistory.C_Customer_ChangHistory_field = newBusinessChancePs[i].Name;
                        if (newBusinessChancePs[i].Name == "B_BusinessChance_Customer_name" //客户名称
                            || newBusinessChancePs[i].Name == "B_BusinessChance_Client_name"//委托人名称
                            || newBusinessChancePs[i].Name == "B_BusinessChance_Competitor_name"//竞争对手名称
                            || newBusinessChancePs[i].Name == "B_BusinessChance_Project_name"//工程名称
                            || newBusinessChancePs[i].Name == "B_BusinessChance_Person_name"//对方当事人名称
                            || newBusinessChancePs[i].Name == "B_BusinessChance_Person_type"//对方当事人类型
                            || newBusinessChancePs[i].Name == "B_BusinessChance_courtFirstName"//一审管辖法院名称
                            || newBusinessChancePs[i].Name == "B_BusinessChance_courtSecondName"//二审管辖法院名称
                            || newBusinessChancePs[i].Name == "B_BusinessChance_courtExecName")//执行管辖法院名称
                        {
                            continue;
                        }
                        switch (newBusinessChancePs[i].Name)
                        {
                            case "B_BusinessChance_name":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "商机名称";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "B_BusinessChance_type": customerChangHistory.C_Customer_ChangHistory_fieldName = "商机类型";
                                List<CommonService.Model.C_Parameters> BusinessChance_type = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.案件类型));
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : BusinessChance_type.Where(c => c.C_Parameters_id == Convert.ToInt32(oldObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = BusinessChance_type.Where(c => c.C_Parameters_id == Convert.ToInt32(newObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "B_BusinessChance_customerType": customerChangHistory.C_Customer_ChangHistory_fieldName = "客户类型";
                                List<CommonService.Model.C_Parameters> Case_customerType = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.客户类型));
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : Case_customerType.Where(c => c.C_Parameters_id == Convert.ToInt32(oldObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = Case_customerType.Where(c => c.C_Parameters_id == Convert.ToInt32(newObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "B_BusinessChance_Customer_code": customerChangHistory.C_Customer_ChangHistory_fieldName = "客户名称";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldBusinessChance.B_BusinessChance_Customer_name;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newBusinessChance.B_BusinessChance_Customer_name;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "B_BusinessChance_Competitor": customerChangHistory.C_Customer_ChangHistory_fieldName = "竞争对手";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldBusinessChance.B_BusinessChance_Competitor_name;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newBusinessChance.B_BusinessChance_Competitor_name;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "B_BusinessChance_registerTime":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "预收案时间";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "B_BusinessChance_Project_code":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "关联工程";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldBusinessChance.B_BusinessChance_Project_name;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newBusinessChance.B_BusinessChance_Project_name;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "B_BusinessChance_expectedTarget":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "预期标的";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "B_BusinessChance_Region_code": customerChangHistory.C_Customer_ChangHistory_fieldName = "所属区域";
                                List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : regionList.Where(c => c.C_Region_code.ToString() == oldObj.ToString()).FirstOrDefault().C_Region_name;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = regionList.Where(c => c.C_Region_code.ToString() == oldObj.ToString()).FirstOrDefault().C_Region_name;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "B_BusinessChance_successProbability":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "成功概率";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "B_BusinessChance_Person_code":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "对方当事人";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldBusinessChance.B_BusinessChance_Person_name;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : (oldObj.ToString() + "+" + oldBusinessChance.B_BusinessChance_Person_type);
                                customerChangHistory.C_Customer_ChangHistory_newValue = newBusinessChance.B_BusinessChance_Person_name;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString() + "+" + newBusinessChance.B_BusinessChance_Person_type;
                                break;
                            case "B_BusinessChance_Client_code": customerChangHistory.C_Customer_ChangHistory_fieldName = "委托人";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldBusinessChance.B_BusinessChance_Client_name;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newBusinessChance.B_BusinessChance_Client_name;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "B_BusinessChance_obtainTime": customerChangHistory.C_Customer_ChangHistory_fieldName = "商机获取时间";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "B_BusinessChance_Case_nature": customerChangHistory.C_Customer_ChangHistory_fieldName = "案件性质";
                                List<CommonService.Model.C_Parameters> Case_nature = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.案件性质));
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : Case_nature.Where(c => c.C_Parameters_id == Convert.ToInt32(oldObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = Case_nature.Where(c => c.C_Parameters_id == Convert.ToInt32(newObj.ToString())).FirstOrDefault().C_Parameters_name;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "B_BusinessChance_courtFirst": customerChangHistory.C_Customer_ChangHistory_fieldName = "一审管辖法院";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldBusinessChance.B_BusinessChance_courtFirstName;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newBusinessChance.B_BusinessChance_courtFirstName;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "B_BusinessChance_courtSecond": customerChangHistory.C_Customer_ChangHistory_fieldName = "二审管辖法院";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldBusinessChance.B_BusinessChance_courtSecondName;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newBusinessChance.B_BusinessChance_courtSecondName;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "B_BusinessChance_courtExec": customerChangHistory.C_Customer_ChangHistory_fieldName = "执行管辖法院";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldBusinessChance.B_BusinessChance_courtExecName;
                                customerChangHistory.C_Customer_ChangHistory_oldLdentification = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newBusinessChance.B_BusinessChance_courtExecName;
                                customerChangHistory.C_Customer_ChangHistory_newLdentification = newObj.ToString();
                                break;
                            case "B_BusinessChance_transferTargetMoney":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "移交标的金额";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "B_BusinessChance_transferTargetOther":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "移交标的其他";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "B_BusinessChance_expectedGrant":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "业务预期收益";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "B_BusinessChance_execMoney":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "执行标的金额";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "B_BusinessChance_execOther":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "执行标的其他";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "B_BusinessChance_Outline":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "商机概述";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                            case "B_BusinessChance_remark":
                                customerChangHistory.C_Customer_ChangHistory_fieldName = "商机备注";
                                customerChangHistory.C_Customer_ChangHistory_oldValue = oldObj == null ? null : oldObj.ToString();
                                customerChangHistory.C_Customer_ChangHistory_newValue = newObj.ToString();
                                break;
                        }
                        customerChangHistory.C_Customer_ChangHistory_submitPerson = Context.UIContext.Current.UserCode;
                        customerChangHistory.C_Customer_ChangHistory_submitDate = DateTime.Now;
                        customerChangHistory.C_Customer_ChangHistory_isDelete = false;
                        customerChangHistory.C_Customer_ChangHistory_creator = Context.UIContext.Current.UserCode;
                        customerChangHistory.C_Customer_ChangHistory_createTime = DateTime.Now;

                        if (UIContext.Current.PostGroupCode == PostGroup.ChiefExpert || UIContext.Current.PostGroupCode == PostGroup.Minister || UIContext.Current.IsPreSetManager)
                        {//首席专家、专家部长不用审核，直接通过，审核人为自己
                            customerChangHistory.C_Customer_ChangHistory_state = Convert.ToInt32(CustomerChangHistoryStateEnum.已通过);
                            customerChangHistory.C_Customer_ChangHistory_checkPerson = UIContext.Current.UserCode;
                            customerChangHistory.C_Customer_ChangHistory_checkDate = DateTime.Now;
                        }
                        else
                        {
                            customerChangHistory.C_Customer_ChangHistory_state = Convert.ToInt32(CustomerChangHistoryStateEnum.待审核);
                            customerChangHistory.C_Customer_ChangHistory_checkPerson = newBusinessChance.B_BusinessChance_person;
                        }

                        customerChangHistoryList.Add(customerChangHistory);
                    }
                }
            }

            bool isSuccess = false;
            isSuccess = _customer_ChangHistoryWCF.OpreateList(customerChangHistoryList);
            #endregion

            if (UIContext.Current.PostGroupCode == PostGroup.ChiefExpert || UIContext.Current.PostGroupCode == PostGroup.Minister || UIContext.Current.IsPreSetManager)
            {//首席专家、专家部长不用审核，直接通过，审核人为自己
                isSuccess = _businessChanceWCF.Update(newBusinessChance);
            }
            else
            {
                if (customerChangHistoryList.Count > 0 && isSuccess)
                {
                    #region 给商机负责人发送消息
                    if (newBusinessChance.B_BusinessChance_person != null)
                    {
                        CommonService.Model.C_Messages message = new CommonService.Model.C_Messages();
                        message.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.商机);
                        message.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.商机变更申请);
                        message.C_Messages_link = newBusinessChance.B_BusinessChance_code;
                        message.C_Messages_createTime = DateTime.Now;
                        message.C_Messages_person = newBusinessChance.B_BusinessChance_person;
                        message.C_Messages_isRead = 0;
                        message.C_Messages_content = "";
                        message.C_Messages_isValidate = 1;

                        _messageWCF.Add(message);
                    }
                    #endregion
                }
            }

            return isSuccess;
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveCase(FormCollection form, CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance)
        {
            if (DateTime.Compare(businessChance.B_BusinessChance_planStartTime.Value, businessChance.B_BusinessChance_planEndTime.Value) < 0)
            {
                if (form["B_BusinessChance_firstClassResponsiblePerson"] != "请选择")
                {
                    businessChance.B_BusinessChance_firstClassResponsiblePerson = new Guid(form["B_BusinessChance_firstClassResponsiblePerson"]);
                }
                else
                {
                    businessChance.B_BusinessChance_firstClassResponsiblePerson = null;
                }
                if (form["B_BusinessChance_person"] != "请选择")
                {
                    businessChance.B_BusinessChance_person = new Guid(form["B_BusinessChance_person"]);
                }
                else
                {
                    businessChance.B_BusinessChance_person = null;
                }
                businessChance.B_BusinessChance_planStartTime = Convert.ToDateTime(form["B_BusinessChance_planStartTime"]);
                businessChance.B_BusinessChance_planEndTime = Convert.ToDateTime(form["B_BusinessChance_planEndTime"]);
                bool isUpdateSuccess = _businessChanceWCF.Update(businessChance);
                if (isUpdateSuccess)
                {
                    //保存成功提示固定写法
                    return Json(TipHelper.JsonData("保存信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
                }
                else
                {
                    //保存失败固定写法
                    return Json(TipHelper.JsonData("保存信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
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
        /// <param name="companyCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string businessChance_code)
        {
            bool isSuccess = _businessChanceWCF.Delete(new Guid(businessChance_code));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除商机信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除商机信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 检查是否已设置了商机的计划时间
        /// </summary>
        /// <param name="businessChanceCode">商机Guid</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CheckIsSetPlanTime(string businessChanceCode)
        {
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(new Guid(businessChanceCode));
            ArrayList arrayPlanTime = new ArrayList();
            //是否已经设置了计划开始时间
            if (businessChance.B_BusinessChance_planStartTime != null)
            {
                arrayPlanTime.Add("1");
            }
            else
            {
                arrayPlanTime.Add("0");
            }
            //是否已经设置了计划结束时间
            if (businessChance.B_BusinessChance_planEndTime != null)
            {
                arrayPlanTime.Add("1");
            }
            else
            {
                arrayPlanTime.Add("0");
            }

            return Json(arrayPlanTime);
        }

        #region 商机转案件

        public ActionResult BusinessChanceConvertCase(string businessChanceCode)
        {
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(new Guid(businessChanceCode));
            ViewBag.businessChance = businessChance;
            return View();
        }

        /// <summary>
        /// 商机转案件Action
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveBusinessChanceConvertCase(FormCollection form)
        {
            string businessChanceCode = form["businessChanceCode"];
            string levelType = form["levelType"];
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(new Guid(businessChanceCode));
            if (businessChance.B_BusinessChance_firstClassResponsiblePerson == Context.UIContext.Current.UserCode || UIContext.Current.IsPreSetManager)
            {
                bool isSuccess = false;
                int Prompt = 0;
                if (businessChance.B_BusinessChance_state == Convert.ToInt32(BusinessFlowStatus.已结束))
                {
                    Prompt = 1;
                }
                if (businessChance.B_BusinessChance_state == Convert.ToInt32(BusinessFlowStatus.正在进行))
                {
                    List<CommonService.Model.FlowManager.P_Business_flow> businessFlows = _bussinessFlowWCF.GetListByFkCode(new Guid(businessChanceCode));
                    foreach (CommonService.Model.FlowManager.P_Business_flow businessFlow in businessFlows)
                    {
                        CommonService.Model.FlowManager.P_Flow flow = _flowWCF.GetModel(businessFlow.P_Flow_code.Value);
                        Prompt = 2;
                        if (flow.P_Flow_IsCrossForm == true)
                        {
                            Prompt = 3;
                            if (businessFlow.P_Business_state == Convert.ToInt32(BusinessFlowStatus.正在进行) || businessFlow.P_Business_state == Convert.ToInt32(BusinessFlowStatus.已结束))
                            {
                                isSuccess = _businessChanceWCF.BusinessChanceConvertCase(new Guid(businessChanceCode), levelType);
                                break;
                            }
                        }
                    }
                }
                if (isSuccess)
                {//成功
                    return Json(TipHelper.JsonData("操作成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
                }
                else if (Prompt == 0)
                {//失败
                    return Json(TipHelper.JsonData("当前商机未开始，暂不能转换为案件！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
                else if (Prompt == 1)
                {
                    return Json(TipHelper.JsonData("当前商机已结束，暂不能转换为案件！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
                else if (Prompt == 2)
                {
                    return Json(TipHelper.JsonData("当前商机暂未启动交单阶段，暂不<br>能转换为案件！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
                else if (Prompt == 3)
                {
                    return Json(TipHelper.JsonData("当前商机未开始交单阶段，暂不能<br>转换为案件！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
                {
                    return Json(TipHelper.JsonData("操作失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }

            }
            else
            {
                return Json(TipHelper.JsonData("您没有权限执行此操作！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        #endregion


        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //商机类型参数集合
            List<CommonService.Model.C_Parameters> BusinessChance_type = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.案件类型));
            ViewBag.BusinessChance_type = BusinessChance_type;
            //案件性质参数集合
            List<CommonService.Model.C_Parameters> Case_nature = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.案件性质));
            ViewBag.Case_nature = Case_nature;
            //客户类型参数集合
            List<CommonService.Model.C_Parameters> Case_customerType = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.客户类型));
            ViewBag.Case_customerType = Case_customerType;
            //进行状态参数集合
            List<CommonService.Model.C_Parameters> Case_state = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(BusinessFlowEnum.业务流程状态));
            ViewBag.Case_state = Case_state;
            //审查状态参数集合
            List<CommonService.Model.C_Parameters> CheckStatus = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(BusinessChanceEnum.商机审查状态));
            ViewBag.CheckStatus = CheckStatus;
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        /// <param name="crival">个人对象</param>
        private void InitializationPageParameter(CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance)
        {
            //商机类型参数集合
            CommonService.Model.C_Parameters BusinessChance_type = _parameterWCF.GetModel(businessChance.B_BusinessChance_type.Value);
            ViewBag.BusinessChance_type = BusinessChance_type;
            //案件性质参数集合
            CommonService.Model.C_Parameters Case_nature = _parameterWCF.GetModel(businessChance.B_BusinessChance_Case_nature.Value);
            ViewBag.Case_nature = Case_nature;
            //客户类型参数集合
            CommonService.Model.C_Parameters Case_customerType = _parameterWCF.GetModel(businessChance.B_BusinessChance_customerType.Value);
            ViewBag.Case_customerType = Case_customerType;
        }
    }
}