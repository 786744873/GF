using CommonService.Common;
using Context;
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
    /// 业务流程控制器
    /// </summary>
    public class BusinessFlowController : BaseController
    {
        private readonly ICommonService.FlowManager.IP_Flow _flowWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow_applyRecord _applyRecordWCF;
        private readonly ICommonService.Customer.IV_User _vUserWCF;
        private readonly ICommonService.SysManager.IC_Role_Role_Power _roleRolePowerWCF;
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow_form _businessFlowFormWCF;
        private readonly ICommonService.CustomerForm.IF_FormCheck _formCheckWCF;
        private readonly ICommonService.BusinessChanceManager.IB_BusinessChance _businessChanceWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.IC_Customer _customerWCF;

        public BusinessFlowController()
        {
            #region 服务初始化
            _flowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow>("FlowWCF");
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            _applyRecordWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow_applyRecord>("P_Business_flow_applyRecordWCF");
            _vUserWCF = ServiceProxyFactory.Create<ICommonService.Customer.IV_User>("VUserWCF");
            _roleRolePowerWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Role_Role_Power>("Role_Role_PowerWCF");
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
            _businessFlowFormWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow_form>("Business_flow_formWCF");
            _formCheckWCF = ServiceProxyFactory.Create<ICommonService.CustomerForm.IF_FormCheck>("FormCheckWCF");
            _businessChanceWCF = ServiceProxyFactory.Create<ICommonService.BusinessChanceManager.IB_BusinessChance>("BusinessChanceWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _customerWCF = ServiceProxyFactory.Create<ICommonService.IC_Customer>("CustomerWCF");
            #endregion
        }

        //
        // GET: /FlowManager/BusinessFlow/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建Action
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="fkCode">关联Guid比如案件、商机Guid等</param>
        /// <param name="flowCode">流程Guid</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string businessFlowCode, string fkCode, string flowCode, int type)
        {
            //创建初始化业务流程实体
            CommonService.Model.FlowManager.P_Business_flow businessFlow = new CommonService.Model.FlowManager.P_Business_flow();
            if (!String.IsNullOrEmpty(flowCode))
            {
                CommonService.Model.FlowManager.P_Flow flow = _flowWCF.GetModel(new Guid(flowCode));
                /*
                 ** 业务流程实体关联流程实体关键属性重新赋值
                 ****/
                businessFlow.P_Flow_code = flow.P_Flow_code;
                businessFlow.P_Business_flow_name = flow.P_Flow_name;
                businessFlow.P_Business_flow_require = flow.P_Flow_require;
            }
            if (type == 1)
            {//代表案件
                CommonService.Model.CaseManager.B_Case casemodel = _caseWCF.GetModel(new Guid(fkCode));
                ViewBag.casemodel = casemodel;
                //阶段的计划开始和结束时间为案件的时间
                businessFlow.P_Business_flow_planStartTime = casemodel.B_Case_planStartTime;
                businessFlow.P_Business_flow_planEndTime = casemodel.B_Case_planEndTime;
            }
            else if (type == 2)
            {//代表商机
                CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(new Guid(fkCode));
                ViewBag.businessChanceModel = businessChance;
                //阶段的计划开始和结束时间为商机的时间
                businessFlow.P_Business_flow_planStartTime = businessChance.B_BusinessChance_planStartTime;
                businessFlow.P_Business_flow_planEndTime = businessChance.B_BusinessChance_planEndTime;
                businessFlow.P_Business_flow_applicationStatus = Convert.ToInt32(BusinessFlowApplicationStatueType.申请配置);
                //商机业务流程负责人默认为商机的专业顾问
                if (!string.IsNullOrEmpty(businessChance.B_BusinessChance_consultant_code))
                    businessFlow.P_Business_person = new Guid(businessChance.B_BusinessChance_consultant_code.Split(',').First());
                if (!string.IsNullOrEmpty(businessChance.B_BusinessChance_consultant_name))
                    businessFlow.P_Business_person_name = businessChance.B_BusinessChance_consultant_name.Split(',').First();
            }
            else if (type == 3)
            {//代表客户
                CommonService.Model.C_Customer customer = _customerWCF.Get(new Guid(fkCode));
                ViewBag.customerModel = customer;
                //阶段的计划开始和结束时间为客户的时间
                businessFlow.P_Business_flow_planStartTime = customer.C_Customer_planStartTime;
                businessFlow.P_Business_flow_planEndTime = customer.C_Customer_planEndTime;
                businessFlow.P_Business_flow_applicationStatus = Convert.ToInt32(BusinessFlowApplicationStatueType.申请配置);
                //客户业务流程负责人默认为客户的专业顾问
                if (customer.C_Customer_consultant != null)
                {
                    businessFlow.P_Business_person = customer.C_Customer_consultant;
                    businessFlow.P_Business_person_name = customer.C_Customer_consultant_name;
                }
            }
            ViewBag.Type = type;
            ViewBag.FlowCode = flowCode;

            businessFlow.P_Business_flow_code = Guid.NewGuid();
            businessFlow.P_Fk_code = new Guid(fkCode);
            if (!String.IsNullOrEmpty(businessFlowCode))
            {
                businessFlow.P_Flow_parent = new Guid(businessFlowCode);
            }

            businessFlow.P_Business_flow_auditType = Convert.ToInt32(BusinessFlowAuditType.完全监控);
            businessFlow.P_Business_state = Convert.ToInt32(BusinessFlowStatus.未开始);
            businessFlow.P_Business_isdelete = false;
            businessFlow.P_Business_creator = Context.UIContext.Current.UserCode;
            businessFlow.P_Business_createTime = DateTime.Now;

            return View(businessFlow);
        }

        /// <summary>
        /// 流程树编辑带入默认数据
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="flowCode">流程Guid</param>
        /// <returns></returns>
        public ActionResult Edit(string businessFlowCode, string flowCode, int type)
        {
            CommonService.Model.FlowManager.P_Business_flow businessFlow = _bussinessFlowWCF.Get(new Guid(businessFlowCode));
            CommonService.Model.FlowManager.P_Flow flow = _flowWCF.GetModel(new Guid(flowCode));
            if (type == 1)
            {//代表案件
                CommonService.Model.CaseManager.B_Case casemodel = _caseWCF.GetModel(new Guid(businessFlow.P_Fk_code.ToString()));
                ViewBag.casemodel = casemodel;
            }
            else if (type == 2)
            {//代表上级
                CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(new Guid(businessFlow.P_Fk_code.ToString()));
                ViewBag.businessChanceModel = businessChance;
            }
            else if (type == 3)
            {//代表客户
                CommonService.Model.C_Customer customer = _customerWCF.Get(new Guid(businessFlow.P_Fk_code.ToString()));
                ViewBag.customerModel = customer;
            }
            ViewBag.Type = type;
            /*
             ** 业务流程实体关联流程实体关键属性重新赋值
             ****/
            businessFlow.P_Flow_code = flow.P_Flow_code;
            businessFlow.P_Business_flow_name = flow.P_Flow_name;
            businessFlow.P_Business_flow_require = flow.P_Flow_require;

            return View("Create", businessFlow);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public ActionResult Modify(string businessFlowCode, int type)
        {
            CommonService.Model.FlowManager.P_Business_flow businessFlow = _bussinessFlowWCF.Get(new Guid(businessFlowCode));
            if (type == 1)
            {//代表案件
                CommonService.Model.CaseManager.B_Case casemodel = _caseWCF.GetModel(new Guid(businessFlow.P_Fk_code.ToString()));
                ViewBag.casemodel = casemodel;
            }
            else if (type == 2)
            {//代表商机
                CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(new Guid(businessFlow.P_Fk_code.ToString()));
                ViewBag.businessChanceModel = businessChance;
            }
            else if (type == 3)
            {//代表客户
                CommonService.Model.C_Customer customer = _customerWCF.Get(new Guid(businessFlow.P_Fk_code.ToString()));
                ViewBag.customerModel = customer;
            }
            ViewBag.Type = type;
            ViewBag.FlowCode = businessFlow.P_Flow_code;
            return View("Create", businessFlow);
        }

        /// <summary>
        /// 业务流程布局结构Action
        /// </summary>
        /// <param name="fkCode">关联案件Guid</param>
        /// <returns></returns>
        public ActionResult DefaultLayout(string fkCode, int type, string businessFlowCode)
        {
            ViewBag.businessFlowCode = businessFlowCode;
            CommonService.Model.CaseManager.B_Case bcase = _caseWCF.GetModel(new Guid(fkCode));
            ViewBag.Case_person = bcase.B_Case_person;
            ViewBag.CurrentUser = Context.UIContext.Current.UserCode;
            ViewBag.FkCode = fkCode;
            ViewBag.Type = type;
            ViewBag.state = bcase.B_Case_state;    

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
            ViewBag.caseCode = fkCode;
            this.DistributedInitButtonsPower(Context.UIContext.Current.OrgCode, Context.UIContext.Current.PostCode);
            #endregion

            return View();
        }

        /// <summary>
        /// 业务流程布局结构Action(商机)
        /// </summary>
        /// <param name="fkCode">关联商机Guid</param>
        /// <returns></returns>
        public ActionResult BusinessChanceDefaultLayout(string fkCode)
        {
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(new Guid(fkCode));
            if (businessChance.B_BusinessChance_planStartTime != null)
            {
                ViewBag.planTime = 1;
            }
            else
            {
                ViewBag.planTime = 0;
            }
            ViewBag.state = businessChance.B_BusinessChance_state;
            ViewBag.FkCode = fkCode;
            ViewBag.BusinessChance_person = businessChance.B_BusinessChance_person;
            ViewBag.CurrentUser = Context.UIContext.Current.UserCode;

            #region 权限
            List<CommonService.Model.SysManager.C_Role_Role_Power> roleRolePowers;
            if (Context.UIContext.Current.IsPreSetManager)
            {
                roleRolePowers = new List<CommonService.Model.SysManager.C_Role_Role_Power>();
            }
            else
            {
                roleRolePowers = _roleRolePowerWCF.GetRolePowersByOrgPostUserCode(Context.UIContext.Current.OrgCode.Value, Context.UIContext.Current.UserCode.Value, Context.UIContext.Current.PostCode.Value);
            }
            ViewBag.RoleRolePowers = roleRolePowers;
            ViewBag.caseCode = fkCode;
            this.InitializationButtonsPower();
            #endregion

            return View();
        }

        /// <summary>
        /// 业务流程布局结构Action(商机)(简洁)
        /// </summary>
        /// <param name="fkCode">关联商机Guid</param>
        /// <returns></returns>
        public ActionResult BusinessChanceDefaultLayout_brief(string fkCode, string flowCode)
        {
            if (flowCode != "{sid_item}")
            {
                ViewBag.flowCodeSelect = flowCode;
            }
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(new Guid(fkCode));
            ViewBag.state = businessChance.B_BusinessChance_state;
            ViewBag.FkCode = fkCode;
            ViewBag.BusinessChance_person = businessChance.B_BusinessChance_person;
            ViewBag.CurrentUser = Context.UIContext.Current.UserCode;

            #region 权限
            //List<CommonService.Model.SysManager.C_Role_Role_Power> roleRolePowers;
            //if (Context.UIContext.Current.IsPreSetManager)
            //{
            //    roleRolePowers = new List<CommonService.Model.SysManager.C_Role_Role_Power>();
            //}
            //else
            //{
            //    roleRolePowers = _roleRolePowerWCF.GetRolePowersByRoleId(Context.UIContext.Current.RoleId.Value);
            //}
            //ViewBag.RoleRolePowers = roleRolePowers;
            //ViewBag.caseCode = fkCode;
            //this.InitializationButtonsPower();
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
            ViewBag.caseCode = fkCode;
            this.DistributedInitButtonsPower(Context.UIContext.Current.OrgCode, Context.UIContext.Current.PostCode);
            #endregion

            return View();
        }

        /// <summary>
        /// 业务流程布局结构Action(客户)(简洁)
        /// </summary>
        /// <param name="fkCode">关联客户Guid</param>
        /// <returns></returns>
        public ActionResult CustomerDefaultLayout_brief(string fkCode, string flowCode)
        {
            CommonService.Model.C_Customer customer = _customerWCF.Get(new Guid(fkCode));
            ViewBag.state = customer.C_Customer_goingStatus;
            ViewBag.FkCode = fkCode;
            ViewBag.BusinessChance_person = customer.C_Customer_responsiblePerson;
            ViewBag.CurrentUser = Context.UIContext.Current.UserCode;
            ViewBag.selectflowCode = flowCode;
            #region 权限
            List<CommonService.Model.SysManager.C_Role_Role_Power> roleRolePowers;
            if (Context.UIContext.Current.IsPreSetManager)
            {
                roleRolePowers = new List<CommonService.Model.SysManager.C_Role_Role_Power>();
            }
            else
            {
                roleRolePowers = _roleRolePowerWCF.GetRolePowersByOrgPostUserCode(Context.UIContext.Current.OrgCode.Value, Context.UIContext.Current.UserCode.Value, Context.UIContext.Current.PostCode.Value);
            }
            ViewBag.RoleRolePowers = roleRolePowers;
            this.InitializationButtonsPower();
            #endregion

            return View();
        }

        /// <summary>
        /// 布局TreeList(frameset布局)
        /// </summary>
        /// <param name="businessFlowCode">流程Guid</param>
        /// <param name="fkCode">关联Guid比如案件、商机Guid等</param>
        /// <param name="operatetype">操作类型</param>
        /// <param name="type">调用才Action来源类型：1为案件；2为商机；3为客户</param>
        /// <returns></returns>
        public ActionResult LayoutTreeList(string businessFlowCode, string fkCode, string operatetype, int type)
        {
            ViewBag.BusinessFlowCode = businessFlowCode;
            ViewBag.FkCode = fkCode;
            ViewBag.OperateType = operatetype;
            ViewBag.Type = type;
            return View();
        }

        public ActionResult BusinesFlowFormList(string businessFlowCode)
        {
            List<CommonService.Model.C_Parameters> BusinessFlowState = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(FormEnum.表单状态));
            ViewBag.BusinessFlowState = BusinessFlowState;
            List<CommonService.Model.FlowManager.P_Business_flow_form> businessFlowForms = _businessFlowFormWCF.GetBusinessFlowForms(new Guid(businessFlowCode));
            return View(businessFlowForms);
        }

        /// <summary>
        /// 业务流程树Action
        /// </summary>
        /// <param name="pkCode">案件Guid或商机Guid</param>
        /// <param name="type">调用此Action来源:1代表案件；2代表上级；3代表客户</param>
        /// <returns></returns>
        public ActionResult Tree(string pkCode, int type, string selectFlowCode)
        {
            SetSingleBusinessFlow(new Guid(pkCode), type, selectFlowCode);
            return View();
        }

        #region 不含checkbox的业务流程递归

        /// <summary>
        /// 根据关联外键Guid，获取关联所有业务流程信息
        /// </summary>
        /// <param name="pkCode">关联外键Guid</param>
        private void SetSingleBusinessFlow(Guid pkCode, int type, string selectFlowCode)
        {
            List<CommonService.Model.FlowManager.P_Business_flow> businessFlows = _bussinessFlowWCF.GetListByFkCode(pkCode);
            SetSingleTopBusinessFlow(businessFlows, pkCode, type, selectFlowCode);
        }

        /// <summary>
        /// 装载顶级业务流程
        /// </summary>
        /// <param name="businessFlowList">业务流程集合</param>
        private void SetSingleTopBusinessFlow(List<CommonService.Model.FlowManager.P_Business_flow> businessFlowList, Guid pkCode, int type, string selectFlowCode)
        {
            if (selectFlowCode == "{businessFlowCode}")
                selectFlowCode = string.Empty;
            string nodeName = "";
            string businessFlowTreeHtml = "";
            string preTreeHtml = "<ul>";//树前缀
            string backTreeHtml = "</ul>";//树后缀
            var topBusinessFlowList = from allList in businessFlowList
                                      where allList.P_Business_flow_level == 1
                                      orderby allList.P_Business_order ascending
                                      select allList;
            /*
             *
             *说明：只要在<li>标签上加上 class=jstree-open, 默认就会打开树,hety,2015-05-19
             */
            string caseName = "";
            string person = "";//案件或商机负责人
            if (type == 1)
            {//案件
                CommonService.Model.CaseManager.B_Case bcase = _caseWCF.GetModel(pkCode);
                caseName = bcase.B_Case_name;
                if (bcase.B_Case_person != null)
                {
                    person = bcase.B_Case_person.Value.ToString();
                }
            }
            else if (type == 2)
            {//商机
                CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(pkCode);
                caseName = businessChance.B_BusinessChance_name;
                if (businessChance.B_BusinessChance_person != null)
                {
                    person = businessChance.B_BusinessChance_person.Value.ToString();
                }
            }
            else if (type == 3)
            {//客户
                CommonService.Model.C_Customer customer = _customerWCF.Get(pkCode);
                caseName = customer.C_Customer_name;
                if (customer.C_Customer_responsiblePerson != null)
                {
                    person = customer.C_Customer_responsiblePerson.Value.ToString();
                }
            }

            if (!String.IsNullOrEmpty(caseName) && caseName.Length > 25)
            {
                caseName = caseName.Substring(0, 25) + "......";
            }
            string defaultSelect = "";
            if (string.IsNullOrEmpty(selectFlowCode) || (type == 1 && string.IsNullOrEmpty(selectFlowCode)))
            {
                defaultSelect = "jstree-clicked";
            }
            businessFlowTreeHtml += "<li class=\"jstree-open\" ><a class=\"jstree-anchor " + defaultSelect + " \" uniqueid=\"\" href=\"\">" + caseName + "</a>";
            businessFlowTreeHtml += "<ul>";

            foreach (CommonService.Model.FlowManager.P_Business_flow businessFlow in topBusinessFlowList)
            {
                string href = "?{flowCode}=" + businessFlow.P_Flow_code.Value.ToString();
                string uniqueId = businessFlow.P_Business_flow_code.Value.ToString();
                nodeName = businessFlow.P_Business_flow_name;
                //如果已分配负责人，则节点中应该把负责人显示出来
                if (!String.IsNullOrEmpty(businessFlow.P_Business_person_name))
                {
                    nodeName += "(" + businessFlow.P_Business_person_name + ")";
                }
                bool flag = true;
                string disabled = "";
                if (businessFlow.P_Business_state == Convert.ToInt32(BusinessFlowStatus.已结束) && !UIContext.Current.IsPreSetManager)
                {
                    disabled = "class=\"jstree-disabled\"";
                    flag = false;
                }
                string cssSelect = "";
                if (!String.IsNullOrEmpty(selectFlowCode))
                {
                    if (businessFlow.P_Business_flow_code.ToString() == selectFlowCode)
                        cssSelect = "class=\"jstree-clicked\"";
                }
                if (flag)
                {
                    disabled = cssSelect;
                }
                if (UIContext.Current.IsPreSetManager)
                {
                    businessFlowTreeHtml += "<li class=\"jstree-open\"  ><a " + disabled + " uniqueid=\"" + uniqueId + "\" href=\"" + href + "\" level=\"" + businessFlow.P_Business_flow_level + "\">" + nodeName + "</a>";
                    //businessFlowTreeHtml += "<li class=\"jstree-open\"  ><a " + disabled + " uniqueid=\"" + uniqueId + "\" href=\"" + href + "\" level=\"" + businessFlow.P_Business_flow_level + "\">" + nodeName + "</a>";
                }
                else if (person == Context.UIContext.Current.UserCode.ToString())
                {
                    businessFlowTreeHtml += "<li class=\"jstree-open\"  ><a " + disabled + " uniqueid=\"" + uniqueId + "\" href=\"" + href + "\" level=\"" + businessFlow.P_Business_flow_level + "\">" + nodeName + "</a>";
                }
                else if (businessFlow.P_Business_person == Context.UIContext.Current.UserCode)
                {
                    businessFlowTreeHtml += "<li class=\"jstree-open\"  ><a " + disabled + " uniqueid=\"" + uniqueId + "\" href=\"" + href + "\" level=\"" + businessFlow.P_Business_flow_level + "\">" + nodeName + "</a>";
                }
                else
                {
                    businessFlowTreeHtml += "<li class=\"jstree-open\"  ><a class=\"jstree-disabled\" uniqueid=\"" + uniqueId + "\" href=\"" + href + "\" level=\"" + businessFlow.P_Business_flow_level + "\">" + nodeName + "</a>";
                }
                SetSignleRecursionTree(businessFlow.P_Business_flow_code.Value, ref businessFlowTreeHtml, businessFlowList, type, selectFlowCode);
                businessFlowTreeHtml += "</li>";
            }
            businessFlowTreeHtml += "</ul>";
            businessFlowTreeHtml += "</li>";

            ViewBag.SingleBusinessFlowTreeHtml = preTreeHtml + businessFlowTreeHtml + backTreeHtml;
        }

        /// <summary>
        /// 递归加载所有业务流程
        /// </summary>
        /// <param name="parentCode">上级流程Code</param>
        /// <param name="businessFlowTreeHtml">业务流程 Tree Html</param>
        /// <param name="businessFlowList">业务流程集合</param>
        private void SetSignleRecursionTree(Guid parentCode, ref string businessFlowTreeHtml, List<CommonService.Model.FlowManager.P_Business_flow> businessFlowList, int type, string selectFlowCode)
        {
            string nodeName = "";
            var lowbusinessFlowList = from allList in businessFlowList
                                      where allList.P_Flow_parent == parentCode
                                      orderby allList.P_Business_order ascending
                                      select allList;

            var parentBusinessCode = businessFlowList.Where(b => b.P_Business_flow_code == parentCode).FirstOrDefault();
            if (lowbusinessFlowList.Count() != 0)
            {
                businessFlowTreeHtml += "<ul>";
            }
            /*
             *
             *说明：只要在<li>标签上加上 class=jstree-open, 默认就会打开树,hety,2015-05-19
             */
            string person = "";//案件或商机负责人
            if (type == 1)
            {//案件
                CommonService.Model.CaseManager.B_Case bcase = _caseWCF.GetModel(parentBusinessCode.P_Fk_code.Value);
                if (bcase.B_Case_person != null)
                {
                    person = bcase.B_Case_person.Value.ToString();
                }
            }
            else if (type == 2)
            {//商机
                CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(parentBusinessCode.P_Fk_code.Value);

                if (businessChance.B_BusinessChance_person != null)
                {
                    person = businessChance.B_BusinessChance_person.Value.ToString();
                }
            }
            else if (type == 3)
            {//客户
                CommonService.Model.C_Customer customer = _customerWCF.Get(parentBusinessCode.P_Fk_code.Value);
                if (customer.C_Customer_responsiblePerson != null)
                {
                    person = customer.C_Customer_responsiblePerson.Value.ToString();
                }
            }
            foreach (CommonService.Model.FlowManager.P_Business_flow businessFlow in lowbusinessFlowList)
            {
                string href = "?{flowCode}=" + businessFlow.P_Flow_code.Value.ToString();
                string uniqueId = businessFlow.P_Business_flow_code.Value.ToString();
                nodeName = businessFlow.P_Business_flow_name;
                //如果已分配负责人，则节点中应该把负责人显示出来
                if (!String.IsNullOrEmpty(businessFlow.P_Business_person_name))
                {
                    nodeName += "(" + businessFlow.P_Business_person_name + ")";
                }
                bool flag = true;
                string disabled = "";
                if (businessFlow.P_Business_state == Convert.ToInt32(BusinessFlowStatus.已结束) && !UIContext.Current.IsPreSetManager)
                {
                    disabled = "class=\"jstree-disabled\"";
                    flag = false;
                }
                string cssSelect = "";
                if (!String.IsNullOrEmpty(selectFlowCode))
                {
                    if (businessFlow.P_Business_flow_code.ToString() == selectFlowCode)
                        cssSelect = "class=\"jstree-clicked\"";
                }
                if (flag)
                {
                    disabled = cssSelect;
                }
                if (UIContext.Current.IsPreSetManager)
                {
                    businessFlowTreeHtml += "<li class=\"jstree-open\"  ><a " + disabled + " uniqueid=\"" + uniqueId + "\" href=\"" + href + "\" level=\"" + businessFlow.P_Business_flow_level + "\">" + nodeName + "</a>";
                }
                else if (person == Context.UIContext.Current.UserCode.ToString())
                {
                    businessFlowTreeHtml += "<li class=\"jstree-open\"  ><a " + disabled + " uniqueid=\"" + uniqueId + "\" href=\"" + href + "\" level=\"" + businessFlow.P_Business_flow_level + "\">" + nodeName + "</a>";
                }
                else if (parentBusinessCode.P_Business_person == Context.UIContext.Current.UserCode || businessFlow.P_Business_person == Context.UIContext.Current.UserCode)
                {
                    businessFlowTreeHtml += "<li class=\"jstree-open\"  ><a " + disabled + " uniqueid=\"" + uniqueId + "\" href=\"" + href + "\" level=\"" + businessFlow.P_Business_flow_level + "\">" + nodeName + "</a>";
                }
                else
                {
                    businessFlowTreeHtml += "<li class=\"jstree-open\"  ><a class=\"jstree-disabled\" uniqueid=\"" + uniqueId + "\" href=\"" + href + "\" level=\"" + businessFlow.P_Business_flow_level + "\">" + nodeName + "</a>";
                }
                //businessFlowTreeHtml += "<li class=\"jstree-open\"><a " + disabled + " uniqueid=\"" + uniqueId + "\" href=\"" + href + "\" level=\"" + businessFlow.P_Business_flow_level + "\">" + nodeName + "</a>";
                SetSignleRecursionTree(businessFlow.P_Business_flow_code.Value, ref businessFlowTreeHtml, businessFlowList, type, selectFlowCode);
                businessFlowTreeHtml += "</li>";
            }
            if (lowbusinessFlowList.Count() != 0)
            {
                businessFlowTreeHtml += "</ul>";
            }
        }

        #endregion

        /// <summary>
        /// 案件Guid或商机Guid关联业务流程递归列表
        /// </summary>
        /// <param name="pkCode">案件Guid或商机Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="fkType">案件或商机类型，案件=153;商机=154</param>
        /// <returns></returns>
        public ActionResult PKRelationBusinessFlowList(string pkCode, string businessFlowCode, int fkType, int? fstate)
        {
            SetBusiFlowByPKCodeAndRootBusiFlow(pkCode, businessFlowCode, fkType);
            ViewBag.fkType = fkType;
            ViewBag.pkCode = pkCode;
            ViewBag.Fstate = fstate;
            return View();
        }

        /// <summary>
        /// 业务流程申请记录
        /// </summary>
        /// <param name="fkType">流程类型(案件或者商机)</param>
        /// <param name="fkCode">业务Guid，案件Guid或者商机Guid</param>
        /// <returns></returns>
        public PartialViewResult BusinesFlowApplyRecord(int fkType, string fkCode)
        {
            List<CommonService.Model.FlowManager.P_Business_flow_applyRecord> ApplyRecords = _applyRecordWCF.GetListByKpCode(new Guid(fkCode));
            return PartialView("ApplyRecordPartial", ApplyRecords);
        }

        #region 查看任务
        public ActionResult PKRelationBusinessFlowList2(string pkCode, string businessFlowCode, int fkType)
        {
            SetBusiFlowByPKCodeAndRootBusiFlow2(pkCode, businessFlowCode, fkType);
            return View();
        }
        private void SetBusiFlowByPKCodeAndRootBusiFlow2(string pkCode, string businessFlowCode, int fkType)
        {
            List<CommonService.Model.FlowManager.P_Business_flow> businessFlows = _bussinessFlowWCF.GetListByFkCode(new Guid(pkCode));
            SetTopListBusinessFlow2(businessFlows, businessFlowCode, pkCode, fkType);
        }
        private void SetTopListBusinessFlow2(List<CommonService.Model.FlowManager.P_Business_flow> businessFlowList, string businessFlowCode, string pkCode, int fkType)
        {
            string businessFlowListHtml = "";
            string preListHtml = "";//前缀
            string backListHtml = "";//后缀
            string isAllowOpenCustomerForm = "1";//是否允许打开业务流程关联自定义表单(该业务流程必须处于“正在进行”或者“已结束”的才有可以打开的机会，因为最终还有人员权限的限制)
            int businessFlowSequence = 1;//业务流程序号
            string trClass = "";


            if (!String.IsNullOrEmpty(businessFlowCode))
            {//从当前根级业务流程起
                var topBusinessFlowList = from allList in businessFlowList
                                          where allList.P_Business_flow_code == new Guid(businessFlowCode)
                                          select allList;
                if (topBusinessFlowList.Count() != 0)
                {
                    ///是否有自己需要负责的流程
                    string isResponsibleImg = "";
                    isAllowOpenCustomerForm = "1";
                    if (topBusinessFlowList.FirstOrDefault().P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.未开始))
                    {
                        trClass = "grey";
                        isAllowOpenCustomerForm = "0";
                    }
                    else if (topBusinessFlowList.FirstOrDefault().P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.正在进行))
                    {
                        trClass = "yellow";
                        isResponsibleImg = CheckResponsible(topBusinessFlowList.FirstOrDefault().P_Business_flow_code.Value, isResponsibleImg);
                    }
                    else if (topBusinessFlowList.FirstOrDefault().P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.已结束))
                    {
                        trClass = "blue";
                    }

                    businessFlowListHtml += "<tr class=\"" + trClass + "\"  target=\"sid_Iterm\" rel=\"" + topBusinessFlowList.FirstOrDefault().P_Business_flow_code + "\">";

                    businessFlowListHtml += "<td>" + businessFlowSequence + "</td>";
                    businessFlowListHtml += "<td>" + topBusinessFlowList.FirstOrDefault().P_Business_flow_name + "</td>";


                    if (Context.UIContext.Current.IsPreSetManager)
                    {//如果为系统内置管理员，则不受到任何权限限制
                        isAllowOpenCustomerForm = "1";
                    }
                    businessFlowListHtml += "<td >" + topBusinessFlowList.FirstOrDefault().P_Business_state_name + "</td>";
                    businessFlowListHtml += "</tr>";

                    SetRecursionList2(topBusinessFlowList.FirstOrDefault().P_Business_flow_code.Value, ref businessFlowListHtml, businessFlowList, businessFlowSequence.ToString(), pkCode, fkType);
                }
            }
            else
            {//所有关联业务流程
                var topBusinessFlowList = from allList in businessFlowList
                                          where allList.P_Business_flow_level == 1
                                          orderby allList.P_Business_order ascending
                                          select allList;
                foreach (CommonService.Model.FlowManager.P_Business_flow businessFlow in topBusinessFlowList)
                {
                    ///是否有自己需要负责的流程
                    string isResponsibleImg = "";
                    isAllowOpenCustomerForm = "1";
                    if (businessFlow.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.未开始))
                    {
                        trClass = "grey";
                        isAllowOpenCustomerForm = "0";
                    }
                    else if (businessFlow.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.正在进行))
                    {
                        trClass = "yellow";
                        isResponsibleImg = CheckResponsible(businessFlow.P_Business_flow_code.Value, isResponsibleImg);

                    }
                    else if (businessFlow.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.已结束))
                    {
                        trClass = "blue";
                    }
                    businessFlowListHtml += "<tr class=\"" + trClass + "\"  target=\"sid_Iterm\" rel=\"" + businessFlow.P_Business_flow_code + "\">";

                    businessFlowListHtml += "<td>" + businessFlowSequence + "</td>";
                    businessFlowListHtml += "<td>" + businessFlow.P_Business_flow_name + "</td>";


                    if (Context.UIContext.Current.IsPreSetManager)
                    {//如果为系统内置管理员，则不受到任何权限限制
                        isAllowOpenCustomerForm = "1";
                    }
                    businessFlowListHtml += "<td>" + businessFlow.P_Business_state_name + "</td>";
                    businessFlowListHtml += "</tr>";

                    SetRecursionList2(businessFlow.P_Business_flow_code.Value, ref businessFlowListHtml, businessFlowList, businessFlowSequence.ToString(), pkCode, fkType);

                    businessFlowSequence++;
                }
            }

            ViewBag.BusinessFlowListHtml = preListHtml + businessFlowListHtml + backListHtml;
        }

        #endregion
        /// <summary>
        /// 案件Guid或商机Guid关联业务流程递归列表(多选)
        /// </summary>
        /// <param name="pkCode">案件Guid或商机Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public ActionResult MulityPKRelationBusinessFlowList(string pkCode, string businessFlowCode, string fkType)
        {
            SetMulityBusiFlowByPKCodeAndRootBusiFlow(pkCode, businessFlowCode, fkType);
            ViewBag.FkType = fkType;
            return View();
        }

        #region 案件Guid或商机Guid关联业务流程递归列表

        /// <summary>
        /// 根据关联外键Guid和根级业务流程，获取关联所有业务流程信息
        /// </summary>
        /// <param name="pkCode">关联外键Guid</param>
        private void SetBusiFlowByPKCodeAndRootBusiFlow(string pkCode, string businessFlowCode, int fkType)
        {
            List<CommonService.Model.FlowManager.P_Business_flow> businessFlows = _bussinessFlowWCF.GetListByFkCode(new Guid(pkCode));
            SetTopListBusinessFlow(businessFlows, businessFlowCode, pkCode, fkType);
        }

        /// <summary>
        /// 装载顶级业务流程列表
        /// </summary>
        /// <param name="businessFlowList">业务流程集合</param>
        private void SetTopListBusinessFlow(List<CommonService.Model.FlowManager.P_Business_flow> businessFlowList, string businessFlowCode, string pkCode, int fkType)
        {
            string businessFlowListHtml = "";
            string preListHtml = "";//前缀
            string backListHtml = "";//后缀
            string isAllowOpenCustomerForm = "1";//是否允许打开业务流程关联自定义表单(该业务流程必须处于“正在进行”或者“已结束”的才有可以打开的机会，因为最终还有人员权限的限制)
            int businessFlowSequence = 1;//业务流程序号
            string trClass = "";

            if (!String.IsNullOrEmpty(businessFlowCode))
            {//从当前根级业务流程起
                var topBusinessFlowList = from allList in businessFlowList
                                          where allList.P_Business_flow_code == new Guid(businessFlowCode)
                                          select allList;
                if (topBusinessFlowList.Count() != 0)
                {
                    ///是否有自己需要负责的流程
                    string isResponsibleImg = "";
                    isAllowOpenCustomerForm = "1";
                    if (topBusinessFlowList.FirstOrDefault().P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.未开始))
                    {
                        trClass = "grey";
                        isAllowOpenCustomerForm = "0";
                    }
                    else if (topBusinessFlowList.FirstOrDefault().P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.正在进行))
                    {
                        trClass = "yellow";
                        isResponsibleImg = CheckResponsible(topBusinessFlowList.FirstOrDefault().P_Business_flow_code.Value, isResponsibleImg);
                    }
                    else if (topBusinessFlowList.FirstOrDefault().P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.已结束))
                    {
                        trClass = "blue";
                    }
                    if (string.IsNullOrEmpty(isResponsibleImg))
                    {
                        isResponsibleImg = this.GetEndCaseIdentityByFlow(topBusinessFlowList.FirstOrDefault().P_Flow_code.Value);
                    }
                    businessFlowListHtml += "<tr class=\"" + trClass + "\" target=\"sid_Iterm\" rel=\"" + topBusinessFlowList.FirstOrDefault().P_Business_flow_code + "\" ondblclick=\"parent.openOwnDefineForm('" + topBusinessFlowList.FirstOrDefault().P_Business_flow_code + "','" + pkCode + "','" + fkType + "','" + isAllowOpenCustomerForm + "','" + ExistsIsHasOpenFormsPower(topBusinessFlowList.FirstOrDefault().P_Business_flow_code.Value, fkType) + "','" + IsNullBusinessFlowForm(topBusinessFlowList.FirstOrDefault().P_Business_flow_code.Value) + "')\">";
                    businessFlowListHtml += "<td>" + isResponsibleImg + "</td>";
                    businessFlowListHtml += "<td>" + businessFlowSequence + "</td>";
                    businessFlowListHtml += "<td>" + topBusinessFlowList.FirstOrDefault().P_Business_flow_name + "</td>";
                    businessFlowListHtml += "<td>" + topBusinessFlowList.FirstOrDefault().P_Flow_name + "</td>";
                    if (topBusinessFlowList.FirstOrDefault().P_Business_flow_planStartTime == null)
                    {
                        businessFlowListHtml += "<td></td>";
                    }
                    else
                    {
                        businessFlowListHtml += "<td>" + topBusinessFlowList.FirstOrDefault().P_Business_flow_planStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "</td>";
                    }
                    if (topBusinessFlowList.FirstOrDefault().P_Business_flow_planEndTime == null)
                    {
                        businessFlowListHtml += "<td></td>";
                    }
                    else
                    {
                        businessFlowListHtml += "<td>" + topBusinessFlowList.FirstOrDefault().P_Business_flow_planEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "</td>";
                    }
                    if (Context.UIContext.Current.IsPreSetManager)
                    {//如果为系统内置管理员，则不受到任何权限限制
                        isAllowOpenCustomerForm = "1";
                    }
                    //任务表单
                    businessFlowListHtml += "<td><a title=\"查看表单\" id=\"Td_" + topBusinessFlowList.FirstOrDefault().P_Business_flow_code + "\" onmouseout=\"omout_Tj2()\" onclick=\"omover_Tj2('Td_" + topBusinessFlowList.FirstOrDefault().P_Business_flow_code + "', 'tjjyDetails','/flowmanager/businessflow/BusinesFlowFormList?businessFlowCode=" + topBusinessFlowList.FirstOrDefault().P_Business_flow_code + "')\"  >查看表单</a></td>";
                    if (fkType == Convert.ToInt32(FlowTypeEnum.案件))
                    {
                        businessFlowListHtml += "<td>" + topBusinessFlowList.FirstOrDefault().P_Business_flow_fixPrice + "</td>";
                    }
                    businessFlowListHtml += "<td>" + topBusinessFlowList.FirstOrDefault().P_Business_state_name + "</td>";
                    if (fkType == Convert.ToInt32(FlowTypeEnum.商机) || fkType == Convert.ToInt32(FlowTypeEnum.客户))
                    {
                        businessFlowListHtml += "<td>" + topBusinessFlowList.FirstOrDefault().P_Business_flow_applicationStatusName + "</td>";
                    }
                    businessFlowListHtml += "<td class=\"operate\">";
                    if (fkType == Convert.ToInt32(FlowTypeEnum.商机))
                    {
                        businessFlowListHtml += "" + this.GetChanceBusinessFlowOperateBtnHtmls(fkType, new Guid(pkCode), topBusinessFlowList.FirstOrDefault().P_Business_flow_code.Value,
                           topBusinessFlowList.FirstOrDefault().P_Business_flow_applicationStatus == null ? 0 : topBusinessFlowList.FirstOrDefault().P_Business_flow_applicationStatus.Value, topBusinessFlowList.FirstOrDefault().P_Business_state.Value);
                    }
                    else if (fkType == Convert.ToInt32(FlowTypeEnum.客户))
                    {
                        businessFlowListHtml += "" + this.GetCustomerBusinessFlowOperateBtnHtmls(fkType, new Guid(pkCode), topBusinessFlowList.FirstOrDefault().P_Business_flow_code.Value,
                           topBusinessFlowList.FirstOrDefault().P_Business_flow_applicationStatus == null ? 0 : topBusinessFlowList.FirstOrDefault().P_Business_flow_applicationStatus.Value, topBusinessFlowList.FirstOrDefault().P_Business_state.Value);
                    }
                    businessFlowListHtml += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.openOwnDefineForm('" + topBusinessFlowList.FirstOrDefault().P_Business_flow_code + "','" + pkCode + "','" + fkType + "','" + isAllowOpenCustomerForm + "','" + ExistsIsHasOpenFormsPower(topBusinessFlowList.FirstOrDefault().P_Business_flow_code.Value, fkType) + "','" + IsNullBusinessFlowForm(topBusinessFlowList.FirstOrDefault().P_Business_flow_code.Value) + "')\">打开</a>";
                    businessFlowListHtml += "</td>";
                    businessFlowListHtml += "</tr>";

                    SetRecursionList(topBusinessFlowList.FirstOrDefault().P_Business_flow_code.Value, ref businessFlowListHtml, businessFlowList, businessFlowSequence.ToString(), pkCode, fkType);
                }
            }
            else
            {//所有关联业务流程
                var topBusinessFlowList = from allList in businessFlowList
                                          where allList.P_Business_flow_level == 1
                                          orderby allList.P_Business_order ascending
                                          select allList;
                foreach (CommonService.Model.FlowManager.P_Business_flow businessFlow in topBusinessFlowList)
                {
                    ///是否有自己需要负责的流程
                    string isResponsibleImg = "";
                    isAllowOpenCustomerForm = "1";
                    if (businessFlow.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.未开始))
                    {
                        trClass = "grey";
                        isAllowOpenCustomerForm = "0";
                    }
                    else if (businessFlow.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.正在进行))
                    {
                        trClass = "yellow";
                        isResponsibleImg = CheckResponsible(businessFlow.P_Business_flow_code.Value, isResponsibleImg);
                    }
                    else if (businessFlow.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.已结束))
                    {
                        trClass = "blue";
                    }
                    if (string.IsNullOrEmpty(isResponsibleImg))
                    {
                        isResponsibleImg = this.GetEndCaseIdentityByFlow(businessFlow.P_Flow_code.Value);
                    }
                    businessFlowListHtml += "<tr class=\"" + trClass + "\" target=\"sid_Iterm\" rel=\"" + businessFlow.P_Business_flow_code + "\" ondblclick=\"parent.openOwnDefineForm('" + businessFlow.P_Business_flow_code + "','" + pkCode + "','" + fkType + "','" + isAllowOpenCustomerForm + "','" + ExistsIsHasOpenFormsPower(businessFlow.P_Business_flow_code.Value, fkType) + "','" + IsNullBusinessFlowForm(businessFlow.P_Business_flow_code.Value) + "')\">";
                    businessFlowListHtml += "<td>" + isResponsibleImg + "</td>";
                    businessFlowListHtml += "<td>" + businessFlowSequence + "</td>";
                    businessFlowListHtml += "<td>" + businessFlow.P_Business_flow_name + "</td>";
                    businessFlowListHtml += "<td>" + businessFlow.P_Flow_name + "</td>";
                    if (businessFlow.P_Business_flow_planStartTime == null)
                    {
                        businessFlowListHtml += "<td></td>";
                    }
                    else
                    {
                        businessFlowListHtml += "<td>" + businessFlow.P_Business_flow_planStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "</td>";
                    }
                    if (businessFlow.P_Business_flow_planEndTime == null)
                    {
                        businessFlowListHtml += "<td></td>";
                    }
                    else
                    {
                        businessFlowListHtml += "<td>" + businessFlow.P_Business_flow_planEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "</td>";
                    }
                    if (Context.UIContext.Current.IsPreSetManager)
                    {//如果为系统内置管理员，则不受到任何权限限制
                        isAllowOpenCustomerForm = "1";
                    }
                    //任务表单
                    businessFlowListHtml += "<td><a title=\"查看表单\" id=\"Td_" + businessFlow.P_Business_flow_code + "\" onmouseout=\"omout_Tj2()\" onclick=\"omover_Tj2('Td_" + businessFlow.P_Business_flow_code + "', 'tjjyDetails','/flowmanager/businessflow/BusinesFlowFormList?businessFlowCode=" + businessFlow.P_Business_flow_code + "')\"  >查看表单</a></td>";
                    if (fkType == Convert.ToInt32(FlowTypeEnum.案件))
                    {
                        businessFlowListHtml += "<td>" + businessFlow.P_Business_flow_fixPrice + "</td>";
                    }
                    businessFlowListHtml += "<td>" + businessFlow.P_Business_state_name + "</td>";
                    if (fkType == Convert.ToInt32(FlowTypeEnum.商机) || fkType == Convert.ToInt32(FlowTypeEnum.客户))
                    {
                        businessFlowListHtml += "<td>" + businessFlow.P_Business_flow_applicationStatusName + "</td>";
                    }
                    businessFlowListHtml += "<td class=\"operate\">";
                    if (fkType == Convert.ToInt32(FlowTypeEnum.商机))
                    {
                        businessFlowListHtml += "" + this.GetChanceBusinessFlowOperateBtnHtmls(fkType, new Guid(pkCode), businessFlow.P_Business_flow_code.Value,
                           businessFlow.P_Business_flow_applicationStatus == null ? 0 : businessFlow.P_Business_flow_applicationStatus.Value, businessFlow.P_Business_state.Value);
                    }
                    else if (fkType == Convert.ToInt32(FlowTypeEnum.客户))
                    {
                        businessFlowListHtml += "" + this.GetCustomerBusinessFlowOperateBtnHtmls(fkType, new Guid(pkCode), businessFlow.P_Business_flow_code.Value,
                           businessFlow.P_Business_flow_applicationStatus == null ? 0 : businessFlow.P_Business_flow_applicationStatus.Value, businessFlow.P_Business_state.Value);
                    }

                    businessFlowListHtml += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.openOwnDefineForm('" + businessFlow.P_Business_flow_code + "','" + pkCode + "','" + fkType + "','" + isAllowOpenCustomerForm + "','" + ExistsIsHasOpenFormsPower(businessFlow.P_Business_flow_code.Value, fkType) + "','" + IsNullBusinessFlowForm(businessFlow.P_Business_flow_code.Value) + "')\">打开</a>";
                    businessFlowListHtml += "</td>";
                    businessFlowListHtml += "</tr>";

                    SetRecursionList(businessFlow.P_Business_flow_code.Value, ref businessFlowListHtml, businessFlowList, businessFlowSequence.ToString(), pkCode, fkType);

                    businessFlowSequence++;
                }
            }

            ViewBag.BusinessFlowListHtml = preListHtml + businessFlowListHtml + backListHtml;
        }

        /// <summary>
        /// 验证是否有负责需操作的表单
        /// </summary>
        /// <param name="businessFlow"></param>
        /// <param name="isResponsibleImg"></param>
        /// <returns></returns>
        private string CheckResponsible(Guid P_Business_flow_code, string isResponsibleImg)
        {
            //找到此流程下面所有表单
            List<CommonService.Model.FlowManager.P_Business_flow_form> BusinessFlowForms = _businessFlowFormWCF.GetBusinessFlowFormsWithFormType(P_Business_flow_code);
            #region  判断是否提示
            foreach (var item in BusinessFlowForms)
            {
                //第一种，必须显示提示的是（当前有表单被驳回，并且自己是表单的负责人
                if (item.P_Business_flow_form_status == Convert.ToInt32(FormStatusEnum.未通过) && item.ResponsiblePersonGuids.ToLower().Contains(UIContext.Current.UserCode.Value.ToString().ToLower()))
                {
                    isResponsibleImg = "<img src='/Theme/images/d02.png' width='20' height='20' />";
                }
                //第二种必须提示的是（当前需要填写数据，必须自己是表单负责人）。
                if (item.P_Business_flow_form_status == Convert.ToInt32(FormStatusEnum.未提交) && item.ResponsiblePersonGuids.ToLower().Contains(UIContext.Current.UserCode.Value.ToString().ToLower()))
                {
                    isResponsibleImg = "<img src='/Theme/images/d02.png' width='20' height='20' />";
                }
                //第三种必须提示的是(该审批该表单的人，该表单必须是已提交状态）
                if (item.P_Business_flow_form_status == Convert.ToInt32(FormStatusEnum.已提交))
                {
                    //再判断该表单是否是当前用户审核（根据审核表）
                    if (IsHasCheckFormPower(P_Business_flow_code))
                    {
                        isResponsibleImg = "<img src='/Theme/images/d02.png' width='20' height='20' />";
                    }

                    //var checkList = _formCheckWCF.GetFirstTimeFormCheckRecord(item.P_Business_flow_form_code.Value);
                    //if (checkList != null && checkList.Count > 0)
                    //{
                    //    var lastcheckmodel = checkList.OrderByDescending(p => p.F_FormCheck_id).FirstOrDefault();
                    //    if (lastcheckmodel != null && lastcheckmodel.F_FormCheck_checkPerson != null && lastcheckmodel.F_FormCheck_checkPerson.Value.ToString().ToLower().Contains(UIContext.Current.UserCode.Value.ToString().ToLower()))
                    //    {
                    //        isResponsibleImg = "<img src='/Theme/images/d02.png' width='20' height='20' />";
                    //    }

                    //}

                }

            }
            #endregion
            return isResponsibleImg;
        }

        /// <summary>
        /// 根据阶段(流程)Guid，获取当前阶段(流程)是否为"大结案"或"退案"阶段(流程)标识(如果是这两种情况，则标识用图标显示)
        /// </summary>
        /// <param name="flowCode">阶段(流程)Guid</param>
        /// <returns></returns>
        private string GetEndCaseIdentityByFlow(Guid flowCode)
        {
            string endCaseIdentity = string.Empty;
            CommonService.Model.FlowManager.P_Flow flow = _flowWCF.GetModel(flowCode);
            if (flow != null)
            {
                if (flow.P_Flow_IsCrossForm)
                {
                    endCaseIdentity = "<img src='/Theme/images/d02.png' width='20' height='20' />";
                }
            }

            return endCaseIdentity;
        }

        /// <summary>
        /// 检查当前用户是否有"审核表单"的权限
        /// </summary>
        /// <param name="businessFlowCode"></param>
        /// <returns></returns>
        private bool IsHasCheckFormPower(Guid businessFlowCode)
        {
            /**
             * author:hety 
             * date:2015-06-18
             * description:
             * (1)、只要当前登录用户在当前业务流程关联的表单中审核进度中(对应F_FormCheck表)，并且审核状态为"未审核"的话，就有"审核"的权限
             * (2)、内置系统管理员用户为万能用户，不受任何权限限制
             **/
            bool isHasCheckForm = false;

            if (Context.UIContext.Current.IsPreSetManager)
            {
                isHasCheckForm = true;
            }
            else
            {
                List<CommonService.Model.Customer.V_User> V_User = _vUserWCF.GetCheckOwnFormUsers(businessFlowCode);
                var powerUserList = from allList in V_User
                                    where allList.UserCode == Context.UIContext.Current.UserCode
                                    select allList;
                if (powerUserList.Count() != 0)
                {
                    isHasCheckForm = true;//代表"允许当前登录用户审核"
                }
            }

            return isHasCheckForm;
        }
        /// <summary>
        /// 递归加载所有业务流程列表
        /// </summary>
        /// <param name="parentCode">上级流程Code</param>
        /// <param name="businessFlowListHtml">业务流程 List Html</param>
        /// <param name="businessFlowList">业务流程集合</param>
        /// <param name="parentBusinFlowSequences">递归传输累加上级流程序号字符串</param>
        private void SetRecursionList2(Guid parentCode, ref string businessFlowListHtml, List<CommonService.Model.FlowManager.P_Business_flow> businessFlowList, string parentBusinFlowSequences, string pkCode, int fkType)
        {
            string trClass = "";
            int businessFlowSequence = 1;
            string isAllowOpenCustomerForm = "1";//是否允许打开业务流程关联自定义表单(该业务流程必须处于“正在进行”或者“已结束”的才有可以打开的机会，因为最终还有人员权限的限制)
            string thisBusinFlowSequences = parentBusinFlowSequences;
            var lowbusinessFlowList = from allList in businessFlowList
                                      where allList.P_Flow_parent == parentCode
                                      orderby allList.P_Business_order ascending
                                      select allList;

            foreach (CommonService.Model.FlowManager.P_Business_flow businessFlow in lowbusinessFlowList)
            {
                ///是否有自己需要负责的流程
                string isResponsibleImg = "";
                isAllowOpenCustomerForm = "1";
                if (businessFlow.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.未开始))
                {
                    trClass = "grey";
                    isAllowOpenCustomerForm = "0";
                }
                else if (businessFlow.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.正在进行))
                {
                    trClass = "yellow";
                    isResponsibleImg = CheckResponsible(businessFlow.P_Business_flow_code.Value, isResponsibleImg);
                }
                else if (businessFlow.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.已结束))
                {
                    trClass = "blue";
                }
                parentBusinFlowSequences = thisBusinFlowSequences + "." + businessFlowSequence;//序号处理
                businessFlowListHtml += "<tr class=\"" + trClass + "\" target=\"sid_Iterm\" rel=\"" + businessFlow.P_Business_flow_code + "\">";
                businessFlowListHtml += "<td>" + thisBusinFlowSequences + "." + businessFlowSequence + "</td>";
                businessFlowListHtml += "<td>" + businessFlow.P_Business_flow_name + "</td>";

                if (Context.UIContext.Current.IsPreSetManager)
                {//如果为系统内置管理员，则不受到任何权限限制
                    isAllowOpenCustomerForm = "1";
                }
                businessFlowListHtml += "<td>" + businessFlow.P_Business_state_name + "</td>";
                businessFlowListHtml += "</tr>";
                SetRecursionList2(businessFlow.P_Business_flow_code.Value, ref businessFlowListHtml, businessFlowList, parentBusinFlowSequences, pkCode, fkType);
                businessFlowSequence++;
            }
        }

        /// <summary>
        /// 递归加载所有业务流程列表
        /// </summary>
        /// <param name="parentCode">上级流程Code</param>
        /// <param name="businessFlowListHtml">业务流程 List Html</param>
        /// <param name="businessFlowList">业务流程集合</param>
        /// <param name="parentBusinFlowSequences">递归传输累加上级流程序号字符串</param>
        private void SetRecursionList(Guid parentCode, ref string businessFlowListHtml, List<CommonService.Model.FlowManager.P_Business_flow> businessFlowList, string parentBusinFlowSequences, string pkCode, int fkType)
        {
            string trClass = "";
            int businessFlowSequence = 1;
            string isAllowOpenCustomerForm = "1";//是否允许打开业务流程关联自定义表单(该业务流程必须处于“正在进行”或者“已结束”的才有可以打开的机会，因为最终还有人员权限的限制)
            string thisBusinFlowSequences = parentBusinFlowSequences;
            var lowbusinessFlowList = from allList in businessFlowList
                                      where allList.P_Flow_parent == parentCode
                                      orderby allList.P_Business_order ascending
                                      select allList;

            foreach (CommonService.Model.FlowManager.P_Business_flow businessFlow in lowbusinessFlowList)
            {
                ///是否有自己需要负责的流程
                string isResponsibleImg = "";
                isAllowOpenCustomerForm = "1";
                if (businessFlow.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.未开始))
                {
                    trClass = "grey";
                    isAllowOpenCustomerForm = "0";
                }
                else if (businessFlow.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.正在进行))
                {
                    trClass = "yellow";
                    isResponsibleImg = CheckResponsible(businessFlow.P_Business_flow_code.Value, isResponsibleImg);
                }
                else if (businessFlow.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.已结束))
                {
                    trClass = "blue";
                }
                if (string.IsNullOrEmpty(isResponsibleImg))
                {
                    isResponsibleImg = this.GetEndCaseIdentityByFlow(businessFlow.P_Flow_code.Value);
                }
                parentBusinFlowSequences = thisBusinFlowSequences + "." + businessFlowSequence;//序号处理
                businessFlowListHtml += "<tr class=\"" + trClass + "\" target=\"sid_Iterm\" rel=\"" + businessFlow.P_Business_flow_code + "\" ondblclick=\"parent.openOwnDefineForm('" + businessFlow.P_Business_flow_code + "','" + pkCode + "','" + fkType + "','" + isAllowOpenCustomerForm + "','" + ExistsIsHasOpenFormsPower(businessFlow.P_Business_flow_code.Value, fkType) + "','" + IsNullBusinessFlowForm(businessFlow.P_Business_flow_code.Value) + "')\">";
                businessFlowListHtml += "<td>" + isResponsibleImg + "</td>";
                businessFlowListHtml += "<td>" + thisBusinFlowSequences + "." + businessFlowSequence + "</td>";
                businessFlowListHtml += "<td>" + businessFlow.P_Business_flow_name + "</td>";
                businessFlowListHtml += "<td>" + businessFlow.P_Flow_name + "</td>";
                if (businessFlow.P_Business_flow_planStartTime == null)
                {
                    businessFlowListHtml += "<td></td>";
                }
                else
                {
                    businessFlowListHtml += "<td>" + businessFlow.P_Business_flow_planStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "</td>";
                }
                if (businessFlow.P_Business_flow_planEndTime == null)
                {
                    businessFlowListHtml += "<td></td>";
                }
                else
                {
                    businessFlowListHtml += "<td>" + businessFlow.P_Business_flow_planEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "</td>";
                }
                if (Context.UIContext.Current.IsPreSetManager)
                {//如果为系统内置管理员，则不受到任何权限限制
                    isAllowOpenCustomerForm = "1";
                }
                //任务表单
                businessFlowListHtml += "<td><a title=\"查看表单\" id=\"Td_" + businessFlow.P_Business_flow_code + "\" onmouseout=\"omout_Tj2()\" onmouseover=\"omover_Tj2('Td_" + businessFlow.P_Business_flow_code + "', 'tjjyDetails','/flowmanager/businessflow/BusinesFlowFormList?businessFlowCode=" + businessFlow.P_Business_flow_code + "')\"  >查看表单</a></td>";
                if (fkType == Convert.ToInt32(FlowTypeEnum.案件))
                {
                    businessFlowListHtml += "<td>" + businessFlow.P_Business_flow_fixPrice + "</td>";
                }
                businessFlowListHtml += "<td>" + businessFlow.P_Business_state_name + "</td>";
                if (fkType == Convert.ToInt32(FlowTypeEnum.商机) || fkType == Convert.ToInt32(FlowTypeEnum.客户))
                {
                    businessFlowListHtml += "<td>" + businessFlow.P_Business_flow_applicationStatusName + "</td>";
                }
                businessFlowListHtml += "<td class=\"operate\">";
                if (fkType == Convert.ToInt32(FlowTypeEnum.商机))
                {
                    businessFlowListHtml += "" + this.GetChanceBusinessFlowOperateBtnHtmls(fkType, new Guid(pkCode), businessFlow.P_Business_flow_code.Value,
                       businessFlow.P_Business_flow_applicationStatus == null ? 0 : businessFlow.P_Business_flow_applicationStatus.Value, businessFlow.P_Business_state.Value);
                }
                else if (fkType == Convert.ToInt32(FlowTypeEnum.客户))
                {
                    businessFlowListHtml += "" + this.GetCustomerBusinessFlowOperateBtnHtmls(fkType, new Guid(pkCode), businessFlow.P_Business_flow_code.Value,
                       businessFlow.P_Business_flow_applicationStatus == null ? 0 : businessFlow.P_Business_flow_applicationStatus.Value, businessFlow.P_Business_state.Value);
                }
                if (businessFlow.P_Business_flow_applicationStatus != Convert.ToInt32(BusinessFlowApplicationStatueType.配置未通过))
                {
                    businessFlowListHtml += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.openOwnDefineForm('" + businessFlow.P_Business_flow_code + "','" + pkCode + "','" + fkType + "','" + isAllowOpenCustomerForm + "','" + ExistsIsHasOpenFormsPower(businessFlow.P_Business_flow_code.Value, fkType) + "','" + IsNullBusinessFlowForm(businessFlow.P_Business_flow_code.Value) + "')\">打开</a>";
                }
                businessFlowListHtml += "</td>";
                businessFlowListHtml += "</tr>";
                SetRecursionList(businessFlow.P_Business_flow_code.Value, ref businessFlowListHtml, businessFlowList, parentBusinFlowSequences, pkCode, fkType);
                businessFlowSequence++;
            }
        }

        /// <summary>
        /// 获取业务流程操作按钮htmls串(目前此逻辑，只针对商机)
        /// </summary>
        /// <param name="fkType">业务流程(案件或者商机)</param>
        /// <param name="pkCode">案件Guid或者商机Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessFlowApplyState">业务流程申请状态</param>
        /// <param name="carryingState">业务流程进行状态</param>
        /// <returns></returns>
        private string GetChanceBusinessFlowOperateBtnHtmls(int fkType, Guid pkCode, Guid businessFlowCode, int businessFlowApplyState, int carryingState)
        {
            string businessFlowOperateBtnHtmls = String.Empty;

            CommonService.Model.FlowManager.P_Business_flow businessFlow = _bussinessFlowWCF.Get(businessFlowCode);//业务流程数据模型
            CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(pkCode);//商机数据模型

            /**
             * author:hety
             * date:2015-10-23
             * description:
             * (1)、若业务流程申请状态为"申请配置"，则业务流程负责人可看到“修改”、“删除”的按钮，如果当前登录用户为"内置系统管理员"，则始终显示这两个按钮.除此之外，数据权限为 13 的用户，同样有这两个按钮权限
             * (2)、若业务流程申请状态为"申请配置"，则商机负责人(内置系统管理员例外)可以看到“同意”、“不同意”按钮
             * (3)、商机下的所有业务流程中，同时只允许一个业务流程的申请状态为"已提交"；如果商机下的所有业务流程中没有申请状态为"已提交"的，
             *      那么流程负责人(内置系统管理员例外)，可以在业务流程申请状态为“配置通过”，并且业务流程进行状态为“未开始”的数据后方看到“申请开启”按钮
             * (4)、若业务流程申请状态为"已提交"，则商机负责人(内置系统管理员例外)可以看到“开启”、“驳回申请”按钮
             ***/

            #region 处理业务(1)
            bool isBusinessPerson = false;//当前登录用户是否为业务此业务流程负责人
            if (UIContext.Current.IsPreSetManager)
            {
                businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.modyBusinessFlow('" + businessFlowCode + "','" + pkCode + "','edit','2')\">修改</a>";
                businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.deleteBusinessFlow('" + businessFlowCode + "')\">删除</a>";
            }
            else
            {
                if (businessFlowApplyState == Convert.ToInt32(BusinessFlowApplicationStatueType.申请配置))
                {
                    if (businessFlow != null)
                    {
                        if (businessFlow.P_Business_person != null)
                        {
                            if (businessFlow.P_Business_person == UIContext.Current.UserCode)
                            {//当前登录用户，为此业务流程负责人
                                isBusinessPerson = true;
                                businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.modyBusinessFlow('" + businessFlowCode + "','" + pkCode + "','edit','2')\">修改</a>";
                                businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.deleteBusinessFlow('" + businessFlowCode + "')\">删除</a>";
                            }
                        }
                    }

                    #region 如果当前登录用户不为此业务的负责人，则检查当前登录用户的数据权限是否为 13
                    if (!isBusinessPerson)
                    {
                        List<CommonService.Model.SysManager.C_Role_Role_Power> roleRolePowers = _roleRolePowerWCF.GetRolePowersByOrgPostUserCode(Context.UIContext.Current.OrgCode.Value,Context.UIContext.Current.UserCode.Value,Context.UIContext.Current.PostCode.Value);
                        if (roleRolePowers.Where(p => p.C_Role_Power_id == 13).Count() != 0)
                        {
                            businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.modyBusinessFlow('" + businessFlowCode + "','" + pkCode + "','edit','2')\">修改</a>";
                            businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.deleteBusinessFlow('" + businessFlowCode + "')\">删除</a>";
                        }
                    }
                    #endregion
                }
            }
            #endregion

            #region 处理业务(2)
            if (businessFlowApplyState == Convert.ToInt32(BusinessFlowApplicationStatueType.申请配置))
            {
                if (UIContext.Current.IsPreSetManager)
                {
                    businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.agreeBusinessFlow('" + fkType + "','" + pkCode + "','" + businessFlowCode + "')\">同意</a>";
                    businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.unAgreeBusinessFlow('" + fkType + "','" + pkCode + "','" + businessFlowCode + "')\">不同意</a>";
                }
                else
                {
                    if (businessChance != null)
                    {
                        if (businessChance.B_BusinessChance_person != null)
                        {
                            if (businessChance.B_BusinessChance_person == UIContext.Current.UserCode)
                            {//当前登录用户，为此商机负责人
                                businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.agreeBusinessFlow('" + fkType + "','" + pkCode + "','" + businessFlowCode + "')\">同意</a>";
                                businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.unAgreeBusinessFlow('" + fkType + "','" + pkCode + "','" + businessFlowCode + "')\">不同意</a>";
                            }
                        }
                    }
                }
            }
            #endregion

            #region 处理业务(3)
            List<CommonService.Model.FlowManager.P_Business_flow> allBusinessFlows = _bussinessFlowWCF.GetPureListByFkCode(pkCode);
            int businessFlowHaveSubmitedCount = allBusinessFlows.Where(p => p.P_Business_flow_applicationStatus == Convert.ToInt32(BusinessFlowApplicationStatueType.已提交)
                && p.P_Business_state == Convert.ToInt32(BusinessFlowStatus.未开始)).Count();//已提交业务流程数量
            if (businessFlowHaveSubmitedCount == 0)
            {
                if (businessFlowApplyState == Convert.ToInt32(BusinessFlowApplicationStatueType.配置通过) && carryingState == Convert.ToInt32(BusinessFlowStatus.未开始))
                {
                    if (UIContext.Current.IsPreSetManager)
                    {
                        businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.applyOpenBusinessFlow('" + fkType + "','" + pkCode + "','" + businessFlowCode + "')\">申请开启</a>";
                    }
                    else
                    {
                        if (businessFlow != null)
                        {
                            if (businessFlow.P_Business_person != null)
                            {
                                if (businessFlow.P_Business_person == UIContext.Current.UserCode)
                                {//当前登录用户，为此业务流程负责人
                                    businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.applyOpenBusinessFlow('" + fkType + "','" + pkCode + "','" + businessFlowCode + "')\">申请开启</a>";
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            #region 处理业务(4)
            if (businessFlowApplyState == Convert.ToInt32(BusinessFlowApplicationStatueType.已提交) && carryingState == Convert.ToInt32(BusinessFlowStatus.未开始))
            {
                if (UIContext.Current.IsPreSetManager)
                {
                    businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.startAppliedBusinessFlow('" + fkType + "','" + pkCode + "','" + businessFlowCode + "')\">开启</a>";
                    businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.rejectAppliedBusinessFlow('" + fkType + "','" + pkCode + "','" + businessFlowCode + "')\">驳回申请</a>";
                }
                else
                {
                    if (businessChance != null)
                    {
                        if (businessChance.B_BusinessChance_person != null)
                        {
                            if (businessChance.B_BusinessChance_person == UIContext.Current.UserCode)
                            {//当前登录用户，为此商机负责人
                                businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.startAppliedBusinessFlow('" + fkType + "','" + pkCode + "','" + businessFlowCode + "')\">开启</a>";
                                businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.rejectAppliedBusinessFlow('" + fkType + "','" + pkCode + "','" + businessFlowCode + "')\">驳回申请</a>";
                            }
                        }
                    }
                }
            }
            #endregion

            return businessFlowOperateBtnHtmls;
        }

        /// <summary>
        /// 获取业务流程操作按钮htmls串(目前此逻辑，只针对客户)
        /// </summary>
        /// <param name="fkType">业务流程(案件或者商机或者客户)</param>
        /// <param name="pkCode">案件Guid或者商机Guid或者客户Guid</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="businessFlowApplyState">业务流程申请状态</param>
        /// <param name="carryingState">业务流程进行状态</param>
        /// <returns></returns>
        private string GetCustomerBusinessFlowOperateBtnHtmls(int fkType, Guid pkCode, Guid businessFlowCode, int businessFlowApplyState, int carryingState)
        {
            string businessFlowOperateBtnHtmls = String.Empty;

            CommonService.Model.FlowManager.P_Business_flow businessFlow = _bussinessFlowWCF.Get(businessFlowCode);//业务流程数据模型
            CommonService.Model.C_Customer customer = _customerWCF.Get(pkCode);//客户数据模型

            /**
             * author:hety
             * date:2015-11-25
             * description:
             * (1)、若业务流程申请状态为"申请配置"，则业务流程负责人可看到“修改”、“删除”的按钮，如果当前登录用户为"内置系统管理员"，则始终显示这两个按钮.除此之外，数据权限为 13 的用户，同样有这两个按钮权限
             * (2)、若业务流程申请状态为"申请配置"，则客户负责人(内置系统管理员例外)可以看到“同意”、“不同意”按钮
             * (3)、客户下的所有业务流程中，同时只允许一个业务流程的申请状态为"已提交"；如果客户下的所有业务流程中没有申请状态为"已提交"的，
             *      那么流程负责人(内置系统管理员例外)，可以在业务流程申请状态为“配置通过”，并且业务流程进行状态为“未开始”的数据后方看到“申请开启”按钮
             * (4)、若业务流程申请状态为"已提交"，则客户负责人(内置系统管理员例外)可以看到“开启”、“驳回申请”按钮
             ***/

            #region 处理业务(1)
            bool isBusinessPerson = false;//当前登录用户是否为业务此业务流程负责人
            if (UIContext.Current.IsPreSetManager)
            {
                businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.modyBusinessFlow('" + businessFlowCode + "','" + pkCode + "','edit','3')\">修改</a>";
                businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.deleteBusinessFlow('" + businessFlowCode + "')\">删除</a>";
            }
            else
            {
                if (businessFlowApplyState == Convert.ToInt32(BusinessFlowApplicationStatueType.申请配置))
                {
                    if (businessFlow != null)
                    {
                        if (businessFlow.P_Business_person != null)
                        {
                            if (businessFlow.P_Business_person == UIContext.Current.UserCode)
                            {//当前登录用户，为此业务流程负责人
                                isBusinessPerson = true;
                                businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.modyBusinessFlow('" + businessFlowCode + "','" + pkCode + "','edit','3')\">修改</a>";
                                businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.deleteBusinessFlow('" + businessFlowCode + "')\">删除</a>";
                            }
                        }
                    }

                    #region 如果当前登录用户不为此业务的负责人，则检查当前登录用户的数据权限是否为 13
                    if (!isBusinessPerson)
                    {
                        List<CommonService.Model.SysManager.C_Role_Role_Power> roleRolePowers = _roleRolePowerWCF.GetRolePowersByOrgPostUserCode(Context.UIContext.Current.OrgCode.Value, Context.UIContext.Current.UserCode.Value, Context.UIContext.Current.PostCode.Value);
                        if (roleRolePowers.Where(p => p.C_Role_Power_id == 13).Count() != 0)
                        {
                            businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.modyBusinessFlow('" + businessFlowCode + "','" + pkCode + "','edit','3')\">修改</a>";
                            businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.deleteBusinessFlow('" + businessFlowCode + "')\">删除</a>";
                        }
                    }
                    #endregion
                }
            }
            #endregion

            #region 处理业务(2)
            if (businessFlowApplyState == Convert.ToInt32(BusinessFlowApplicationStatueType.申请配置))
            {
                if (UIContext.Current.IsPreSetManager)
                {
                    businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.agreeBusinessFlow('" + fkType + "','" + pkCode + "','" + businessFlowCode + "')\">同意</a>";
                    businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.unAgreeBusinessFlow('" + fkType + "','" + pkCode + "','" + businessFlowCode + "')\">不同意</a>";
                }
                else
                {
                    if (customer != null)
                    {
                        if (customer.C_Customer_responsiblePerson != null)
                        {
                            if (customer.C_Customer_responsiblePerson == UIContext.Current.UserCode)
                            {//当前登录用户，为此客户负责人
                                businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.agreeBusinessFlow('" + fkType + "','" + pkCode + "','" + businessFlowCode + "')\">同意</a>";
                                businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.unAgreeBusinessFlow('" + fkType + "','" + pkCode + "','" + businessFlowCode + "')\">不同意</a>";
                            }
                        }
                    }
                }
            }
            #endregion

            #region 处理业务(3)   暂且关闭申请开启操作
            //List<CommonService.Model.FlowManager.P_Business_flow> allBusinessFlows = _bussinessFlowWCF.GetPureListByFkCode(pkCode);
            //int businessFlowHaveSubmitedCount = allBusinessFlows.Where(p => p.P_Business_flow_applicationStatus == Convert.ToInt32(BusinessFlowApplicationStatueType.已提交)
            //    && p.P_Business_state == Convert.ToInt32(BusinessFlowStatus.未开始)).Count();//已提交业务流程数量
            //if (businessFlowHaveSubmitedCount == 0)
            //{
            //    if (businessFlowApplyState == Convert.ToInt32(BusinessFlowApplicationStatueType.配置通过) && carryingState == Convert.ToInt32(BusinessFlowStatus.未开始))
            //    {
            //        if (UIContext.Current.IsPreSetManager)
            //        {
            //            businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.applyOpenBusinessFlow('" + fkType + "','" + pkCode + "','" + businessFlowCode + "')\">申请开启</a>";
            //        }
            //        else
            //        {
            //            if (businessFlow != null)
            //            {
            //                if (businessFlow.P_Business_person != null)
            //                {
            //                    if (businessFlow.P_Business_person == UIContext.Current.UserCode)
            //                    {//当前登录用户，为此业务流程负责人
            //                        businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.applyOpenBusinessFlow('" + fkType + "','" + pkCode + "','" + businessFlowCode + "')\">申请开启</a>";
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion

            #region 处理业务(4)   暂且关闭申请开启操作
            //if (businessFlowApplyState == Convert.ToInt32(BusinessFlowApplicationStatueType.已提交) && carryingState == Convert.ToInt32(BusinessFlowStatus.未开始))
            //{
            //    if (UIContext.Current.IsPreSetManager)
            //    {
            //        businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.startAppliedBusinessFlow('" + fkType + "','" + pkCode + "','" + businessFlowCode + "')\">开启</a>";
            //        businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.rejectAppliedBusinessFlow('" + fkType + "','" + pkCode + "','" + businessFlowCode + "')\">驳回申请</a>";
            //    }
            //    else
            //    {
            //        if (customer != null)
            //        {
            //            if (customer.C_Customer_responsiblePerson != null)
            //            {
            //                if (customer.C_Customer_responsiblePerson == UIContext.Current.UserCode)
            //                {//当前登录用户，为此商机负责人
            //                    businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.startAppliedBusinessFlow('" + fkType + "','" + pkCode + "','" + businessFlowCode + "')\">开启</a>";
            //                    businessFlowOperateBtnHtmls += "<a class=\"tablelink\" href=\"javascript:void(0)\" onclick=\"parent.rejectAppliedBusinessFlow('" + fkType + "','" + pkCode + "','" + businessFlowCode + "')\">驳回申请</a>";
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion

            return businessFlowOperateBtnHtmls;
        }


        /// <summary>
        /// 检查当前用户是否有打开表单的权限
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        private string ExistsIsHasOpenFormsPower(Guid businessFlowCode, int fkType)
        {
            string exist = "0";//代表"不允许当前登录用户打开"
            if (Context.UIContext.Current.IsPreSetManager)
            {//如果为系统内置管理员，则不受到任何权限限制
                exist = "1";
            }
            else
            {
                //List<CommonService.Model.Customer.V_User> V_User = new List<CommonService.Model.Customer.V_User>();
                //if(fkType==Convert.ToInt32(FlowTypeEnum.案件))
                //{
                //    V_User = _vUserWCF.GetOpenOwnFormUsers(businessFlowCode, 1);
                //}else if(fkType==Convert.ToInt32(FlowTypeEnum.商机))
                //{
                //    V_User = _vUserWCF.GetOpenOwnFormUsers(businessFlowCode, 2);
                //}
                //var powerUserList = from allList in V_User
                //                    where allList.UserCode == Context.UIContext.Current.UserCode
                //                    select allList;
                //if (powerUserList.Count() != 0)
                //{
                //    exist = "1";//代表"允许当前登录用户打开"
                //}
                exist = "1";//代表"允许当前登录用户打开"
            }
            return exist;
        }

        private string IsNullBusinessFlowForm(Guid businessFlowCode)
        {
            string exist = "0";
            List<CommonService.Model.FlowManager.P_Business_flow_form> businessFlowForms = _businessFlowFormWCF.GetBusinessFlowForms(businessFlowCode);
            if (businessFlowForms.Count != 0)
            {
                exist = "1";
            }
            return exist;
        }

        /// <summary>
        /// 根据关联外键Guid和根级业务流程，获取关联所有业务流程信息(多选)
        /// </summary>
        /// <param name="pkCode">关联外键Guid</param>
        private void SetMulityBusiFlowByPKCodeAndRootBusiFlow(string pkCode, string businessFlowCode, string fkType)
        {
            List<CommonService.Model.FlowManager.P_Business_flow> businessFlows = _bussinessFlowWCF.GetListByFkCode(new Guid(pkCode));
            SetMulityTopListBusinessFlow(businessFlows, businessFlowCode, pkCode, fkType);
        }

        /// <summary>
        /// 装载顶级业务流程列表(多选)
        /// </summary>
        /// <param name="businessFlowList">业务流程集合</param>
        private void SetMulityTopListBusinessFlow(List<CommonService.Model.FlowManager.P_Business_flow> businessFlowList, string businessFlowCode, string pkCode, string fkType)
        {
            string businessFlowListHtml = "";
            string preListHtml = "";//前缀
            string backListHtml = "";//后缀
            int businessFlowSequence = 1;//业务流程序号
            string trClass = "";
            string checkboxDisable = "disabled=disabled";

            if (!String.IsNullOrEmpty(businessFlowCode))
            {//从当前根级业务流程起
                var topBusinessFlowList = from allList in businessFlowList
                                          where allList.P_Business_flow_code == new Guid(businessFlowCode)
                                          select allList;
                if (topBusinessFlowList.Count() != 0)
                {
                    if (topBusinessFlowList.FirstOrDefault().P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.未开始))
                    {
                        trClass = "grey";
                        checkboxDisable = "";
                    }
                    else if (topBusinessFlowList.FirstOrDefault().P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.正在进行))
                    {
                        trClass = "yellow";
                    }
                    else if (topBusinessFlowList.FirstOrDefault().P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.已结束))
                    {
                        trClass = "blue";
                    }
                    businessFlowListHtml += "<tr class=\"" + trClass + "\" target=\"sid_Iterm\" rel=\"" + topBusinessFlowList.FirstOrDefault().P_Business_flow_code + "\">";
                    if (Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件))
                    {
                        businessFlowListHtml += "<td><input operate=\"operate\" " + checkboxDisable + " type=\"checkbox\" value=\"\"></td>";
                    }
                    businessFlowListHtml += "<td>" + businessFlowSequence + "</td>";
                    businessFlowListHtml += "<td>" + topBusinessFlowList.FirstOrDefault().P_Business_flow_name + "</td>";
                    businessFlowListHtml += "<td>" + topBusinessFlowList.FirstOrDefault().P_Flow_name + "</td>";
                    businessFlowListHtml += "<td>" + topBusinessFlowList.FirstOrDefault().P_Business_state_name + "</td>";
                    businessFlowListHtml += "</tr>";

                    SetMulityRecursionList(topBusinessFlowList.FirstOrDefault().P_Business_flow_code.Value, ref businessFlowListHtml, businessFlowList, businessFlowSequence.ToString(), pkCode, fkType);
                }
            }
            else
            {//所有关联业务流程
                var topBusinessFlowList = from allList in businessFlowList
                                          where allList.P_Business_flow_level == 1
                                          orderby allList.P_Business_order ascending
                                          select allList;
                foreach (CommonService.Model.FlowManager.P_Business_flow businessFlow in topBusinessFlowList)
                {
                    if (businessFlow.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.未开始))
                    {
                        trClass = "grey";
                        checkboxDisable = "";
                    }
                    else if (businessFlow.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.正在进行))
                    {
                        trClass = "yellow";
                    }
                    else if (businessFlow.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.已结束))
                    {
                        trClass = "blue";
                    }
                    businessFlowListHtml += "<tr class=\"" + trClass + "\" target=\"sid_Iterm\" rel=\"" + businessFlow.P_Business_flow_code + "\">";
                    if (Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件))
                    {
                        businessFlowListHtml += "<td><input operate=\"operate\" " + checkboxDisable + " type=\"checkbox\" value=\"\"></td>";
                    }
                    businessFlowListHtml += "<td>" + businessFlowSequence + "</td>";
                    businessFlowListHtml += "<td>" + businessFlow.P_Business_flow_name + "</td>";
                    businessFlowListHtml += "<td>" + businessFlow.P_Flow_name + "</td>";
                    businessFlowListHtml += "<td>" + businessFlow.P_Business_state_name + "</td>";
                    businessFlowListHtml += "</tr>";

                    SetMulityRecursionList(businessFlow.P_Business_flow_code.Value, ref businessFlowListHtml, businessFlowList, businessFlowSequence.ToString(), pkCode, fkType);

                    businessFlowSequence++;
                }
            }

            ViewBag.MulityBusinessFlowListHtml = preListHtml + businessFlowListHtml + backListHtml;
        }


        /// <summary>
        /// 递归加载所有业务流程列表(多选)
        /// </summary>
        /// <param name="parentCode">上级流程Code</param>
        /// <param name="businessFlowListHtml">业务流程 List Html</param>
        /// <param name="businessFlowList">业务流程集合</param>
        /// <param name="parentBusinFlowSequences">递归传输累加上级流程序号字符串</param>
        private void SetMulityRecursionList(Guid parentCode, ref string businessFlowListHtml, List<CommonService.Model.FlowManager.P_Business_flow> businessFlowList, string parentBusinFlowSequences, string pkCode, string fkType)
        {
            string trClass = "";
            string checkboxDisable = "disabled=disabled";
            int businessFlowSequence = 1;
            string thisBusinFlowSequences = parentBusinFlowSequences;
            var lowbusinessFlowList = from allList in businessFlowList
                                      where allList.P_Flow_parent == parentCode
                                      orderby allList.P_Business_order ascending
                                      select allList;

            foreach (CommonService.Model.FlowManager.P_Business_flow businessFlow in lowbusinessFlowList)
            {
                if (businessFlow.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.未开始))
                {
                    trClass = "grey";
                    checkboxDisable = "";
                }
                else if (businessFlow.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.正在进行))
                {
                    trClass = "yellow";
                }
                else if (businessFlow.P_Business_state.Value == Convert.ToInt32(BusinessFlowStatus.已结束))
                {
                    trClass = "blue";
                }
                parentBusinFlowSequences = thisBusinFlowSequences + "." + businessFlowSequence;//序号处理
                businessFlowListHtml += "<tr class=\"" + trClass + "\" target=\"sid_Iterm\" rel=\"" + businessFlow.P_Business_flow_code + "\">";
                if (Convert.ToInt32(fkType) == Convert.ToInt32(FlowTypeEnum.案件))
                {
                    businessFlowListHtml += "<td><input id=\"allChecked\" operate=\"operate\" " + checkboxDisable + " type=\"checkbox\" value=\"\"></td>";
                }
                businessFlowListHtml += "<td>" + thisBusinFlowSequences + "." + businessFlowSequence + "</td>";
                businessFlowListHtml += "<td>" + businessFlow.P_Business_flow_name + "</td>";
                businessFlowListHtml += "<td>" + businessFlow.P_Flow_name + "</td>";
                businessFlowListHtml += "<td>" + businessFlow.P_Business_state_name + "</td>";
                businessFlowListHtml += "</tr>";
                SetMulityRecursionList(businessFlow.P_Business_flow_code.Value, ref businessFlowListHtml, businessFlowList, parentBusinFlowSequences, pkCode, fkType);
                businessFlowSequence++;
            }
        }




        #endregion

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="form"></param>
        /// <param name="businessFlow"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.FlowManager.P_Business_flow businessFlow)
        {
            //流程负责人
            if (!String.IsNullOrEmpty(form["mainLawyerlookup.Code"].Trim()))
            {
                businessFlow.P_Business_person = new Guid(form["mainLawyerlookup.Code"].Trim());
            }
            //服务方法调用
            int businessFlowId = 0;
            string flowTypeName = String.Empty;
            int type = Convert.ToInt32(form["type"]);
            if (type == 1)
                flowTypeName = "案件";
            else if (type == 2)
                flowTypeName = "商机";
            else if (type == 3)
                flowTypeName = "客户";

            #region
            bool flag = true;
            int flowType = 0;//流程类型
            DateTime planStartTime = DateTime.Now;
            DateTime planEndTime = DateTime.Now;
            if (type == 1)
            {
                CommonService.Model.CaseManager.B_Case casemodel = _caseWCF.GetModel(new Guid(businessFlow.P_Fk_code.ToString()));
                planStartTime = Convert.ToDateTime(casemodel.B_Case_planStartTime);
                planEndTime = Convert.ToDateTime(casemodel.B_Case_planEndTime);
                flowType = Convert.ToInt32(FlowTypeEnum.案件);
            }
            else if (type == 2)
            {
                CommonService.Model.BusinessChanceManager.B_BusinessChance businessChance = _businessChanceWCF.GetModel(new Guid(businessFlow.P_Fk_code.ToString()));
                planStartTime = Convert.ToDateTime(businessChance.B_BusinessChance_planStartTime);
                planEndTime = Convert.ToDateTime(businessChance.B_BusinessChance_planEndTime);
                flowType = Convert.ToInt32(FlowTypeEnum.商机);
            }
            else if (type == 3)
            {
                CommonService.Model.C_Customer customer = _customerWCF.Get(new Guid(businessFlow.P_Fk_code.ToString()));
                planStartTime = Convert.ToDateTime(customer.C_Customer_planStartTime);
                planEndTime = Convert.ToDateTime(customer.C_Customer_planEndTime);
                flowType = Convert.ToInt32(FlowTypeEnum.客户);
            }
            #endregion

            if (DateTime.Compare(businessFlow.P_Business_flow_planStartTime.Value, businessFlow.P_Business_flow_planEndTime.Value) < 0)
            {
                if (businessFlow.P_Business_flow_id > 0)
                {//修改
                    #region 修改
                    if (!string.IsNullOrEmpty(businessFlow.P_Business_flow_planStartTime.ToString()))
                    {
                        if (DateTime.Compare(Convert.ToDateTime(businessFlow.P_Business_flow_planStartTime), planStartTime) < 0 || DateTime.Compare(Convert.ToDateTime(businessFlow.P_Business_flow_planStartTime), planEndTime) > 0)
                        {
                            flag = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(businessFlow.P_Business_flow_planEndTime.ToString()))
                    {
                        if (DateTime.Compare(Convert.ToDateTime(businessFlow.P_Business_flow_planEndTime), planEndTime) > 0 || DateTime.Compare(Convert.ToDateTime(businessFlow.P_Business_flow_planEndTime), planStartTime) < 0)
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        bool isUpdateSuccess = _bussinessFlowWCF.Update(businessFlow, type);
                        if (isUpdateSuccess)
                        {
                            businessFlowId = businessFlow.P_Business_flow_id;
                        }
                    }
                    else
                    {
                        return Json(TipHelper.JsonData("时间超出" + flowTypeName + "计划开始和结束时间！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                    }
                    #endregion
                }
                else
                {//添加
                    #region 添加
                    if (!string.IsNullOrEmpty(businessFlow.P_Business_flow_planStartTime.ToString()))
                    {
                        if (DateTime.Compare(Convert.ToDateTime(businessFlow.P_Business_flow_planStartTime), planStartTime) < 0 || DateTime.Compare(Convert.ToDateTime(businessFlow.P_Business_flow_planStartTime), planEndTime) > 0)
                        {
                            flag = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(businessFlow.P_Business_flow_planEndTime.ToString()))
                    {
                        if (DateTime.Compare(Convert.ToDateTime(businessFlow.P_Business_flow_planEndTime), planEndTime) > 0 || DateTime.Compare(Convert.ToDateTime(businessFlow.P_Business_flow_planEndTime), planStartTime) < 0)
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        bool isSuccess = _bussinessFlowWCF.ExistsByFkCodeAndFlowCode(businessFlow.P_Fk_code.Value, businessFlow.P_Flow_code.Value,type);
                        if (isSuccess)
                        {
                            return Json(TipHelper.JsonData("已存在该业务流程！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                        }
                        else
                        {
                            businessFlow.P_Business_createTime = DateTime.Now;
                            businessFlowId = _bussinessFlowWCF.Add(businessFlow, flowType);
                        }
                    }
                    else
                    {
                        return Json(TipHelper.JsonData("时间超出" + flowTypeName + "计划开始和结束时间！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                    }
                    #endregion
                }

                if (businessFlowId > 0)
                {
                    #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                    string formOperateType = form["formOperateType"].ToString().ToLower();
                    if (formOperateType == "onlysave")
                    {
                        return Json(TipHelper.JsonData("保存流程信息成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshGrandpa));//仅仅保存
                    }
                    else if (formOperateType == "saveandnewnext")
                    {
                        return Json(TipHelper.JsonData("保存流程信息成功", "/flowmanager/businessflow/create?businessFlowCode=" + businessFlow.P_Flow_parent + "&fkCode=" + businessFlow.P_Fk_code + "&type=" + type, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));//保存并且新增下一个
                    }
                    else
                    {
                        return Json(TipHelper.JsonData("保存流程信息成功", ""));//默认仅仅保存
                    }
                    #endregion
                }
                else
                {
                    //保存失败固定写法
                    return Json(TipHelper.JsonData("保存流程信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
            }
            else
            {
                return Json(TipHelper.JsonData("计划开始时间不能大于计划结束时间，<br>并且不能超出" + flowTypeName + "的计划开始和结束的<br>时间范围！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 向前移动业务流程Action
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="fkCode">业务外键Guid(比如案件Guid，商机Guid)</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MoveForward(string businessFlowCode, string fkCode)
        {
            bool isSuccess = _bussinessFlowWCF.MoveForward(new Guid(fkCode), new Guid(businessFlowCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("上移业务流程成功！", "", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("上移业务流程失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 向后移动业务流程Action
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="fkCode">业务外键Guid(比如案件Guid，商机Guid)</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MoveBackward(string businessFlowCode, string fkCode)
        {
            bool isSuccess = _bussinessFlowWCF.MoveBackward(new Guid(fkCode), new Guid(businessFlowCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("下移业务流程成功！", "", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("下移业务流程失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string businessFlowCode)
        {
            bool isSuccess = _bussinessFlowWCF.Delete(new Guid(businessFlowCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除业务流程成功！", "", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除业务流程失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 同意业务流程申请配置
        /// </summary>
        /// <param name="fkType">流程类型(案件或者商机)</param>
        /// <param name="fkCode">业务Guid(案件Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AgreeBusinessFlow(string fkType, string fkCode, string businessFlowCode)
        {
            bool isSuccess = _bussinessFlowWCF.AgreeBusinessFlow(Convert.ToInt32(fkType), new Guid(fkCode), new Guid(businessFlowCode), UIContext.Current.UserCode.Value);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("同意此申请配置成功！", "", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("同意此申请配置失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 拒绝业务流程申请配置
        /// </summary>
        /// <param name="fkType">流程类型(案件或者商机)</param>
        /// <param name="fkCode">业务Guid(案件Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UnAgreeBusinessFlow(string fkType, string fkCode, string businessFlowCode)
        {
            bool isSuccess = _bussinessFlowWCF.UnAgreeBusinessFlow(Convert.ToInt32(fkType), new Guid(fkCode), new Guid(businessFlowCode), UIContext.Current.UserCode.Value);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("拒绝此申请配置成功！", "", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("拒绝此申请配置失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 申请开启业务流程
        /// </summary>
        /// <param name="fkType">流程类型(案件或者商机)</param>
        /// <param name="fkCode">业务Guid(案件Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult applyOpenBusinessFlow(string fkType, string fkCode, string businessFlowCode)
        {
            bool isSuccess = _bussinessFlowWCF.ApplyOpenBusinessFlow(Convert.ToInt32(fkType), new Guid(fkCode), new Guid(businessFlowCode), UIContext.Current.UserCode.Value);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("申请开启业务流程成功！", "", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("申请开启业务流程失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 开启业务流程
        /// </summary>
        /// <param name="fkType">流程类型(案件或者商机)</param>
        /// <param name="fkCode">业务Guid(案件Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult startAppliedBusinessFlow(string fkType, string fkCode, string businessFlowCode)
        {
            bool isSuccess = _bussinessFlowWCF.StartAppliedBusinessFlow(Convert.ToInt32(fkType), new Guid(fkCode), new Guid(businessFlowCode), UIContext.Current.UserCode.Value);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("开启此业务流程成功！", "", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("开启此业务流程失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 驳回已申请开启的业务流程
        /// </summary>
        /// <param name="fkType">流程类型(案件或者商机)</param>
        /// <param name="fkCode">业务Guid(案件Guid或者商机Guid)</param>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult rejectAppliedBusinessFlow(string fkType, string fkCode, string businessFlowCode)
        {
            bool isSuccess = _bussinessFlowWCF.RejectAppliedBusinessFlow(Convert.ToInt32(fkType), new Guid(fkCode), new Guid(businessFlowCode), UIContext.Current.UserCode.Value);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("驳回此业务流程申请成功！", "", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("驳回此业务流程申请失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

    }
}