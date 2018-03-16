
using CommonService.Common;
using CommonService.Model.CaseManager;
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
    /// 案件维护控制器
    /// </summary>
    public class CaseMaintainController : BaseController
    {

        private readonly ICommonService.CaseManager.IB_CaseMaintain _bussinessCaseMaintainWCF;
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow_form _businessFlowFormWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;
        private readonly ICommonService.FlowManager.IP_Flow _flowWCF;
        private readonly ICommonService.SysManager.IC_Role_Role_Power _roleRolePowerWCF;
        public CaseMaintainController()
        {
            _bussinessCaseMaintainWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_CaseMaintain>("CaseMaintainWCF");
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _flowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow>("FlowWCF");
            _roleRolePowerWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Role_Role_Power>("Role_Role_PowerWCF");
            _businessFlowFormWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow_form>("Business_flow_formWCF");
        }
        //
        // GET: /CaseManager/CaseMaintain/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 案件维护tab
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
            List<CommonService.Model.FlowManager.P_Flow> casestage = _flowWCF.GetAllList();

            #region  业务查询条件
            if (!String.IsNullOrEmpty(form["B_Case_name"]))
            {//案件名称查询条件
                caseConditon.B_Case_name = form["B_Case_name"].Trim();
            }
            if (!String.IsNullOrEmpty(form["B_Case_number"]))
            {//案件编码查询条件
                caseConditon.B_Case_number = form["B_Case_number"].Trim();
            }
            if ((!String.IsNullOrEmpty(form["B_Case_state"])) && (form["B_Case_state"].ToString()) != "全部")
            {//案件状态查询条件
                caseConditon.B_Case_state = Convert.ToInt32(form["B_Case_state"]);
            }
            if ((!String.IsNullOrEmpty(form["B_Case_type"])) && (form["B_Case_type"].ToString()) != "全部")
            {//案件类型查询条件
                caseConditon.B_Case_type = Convert.ToInt32(form["B_Case_type"]);
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

            ViewBag.casestage = casestage;
            ViewBag.CaseConditon = caseConditon;
            #endregion

            //获取案件总记录数
            this.TotalRecordCount = _caseWCF.GetPowerRecordCaseMainCount(caseConditon, UIContext.Current.IsPreSetManager, UIContext.Current.UserCode,
                postCode, orgCode, "(select count(*) from B_CaseMaintain where T.B_Case_code=B_CaseMaintain.B_Case_code)>0");

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取案件数据信息
            List<CommonService.Model.CaseManager.B_Case> caseMaintains = _caseWCF.GetPowerListB_caseMainByPage(caseConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, postCode, orgCode, "(select count(*) from B_CaseMaintain where T.B_Case_code=B_CaseMaintain.B_Case_code)>0");

            #region 分布式权限以及初始化用户登录信息
            this.DistributedInitButtonsPower(orgCode, postCode);
            this.DistributedInitLogin(orgCode, postCode, postGroupCode);
            #endregion

            return View(caseMaintains);
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        public ActionResult Create(FormCollection form, int? page = 1)
        {
            InitializationPageParameter();

            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //案件查询模型
            CommonService.Model.CaseManager.B_Case caseConditon = new CommonService.Model.CaseManager.B_Case();

            //案件查询模型传递到前端视图中
            caseConditon.B_Case_oprationtype = 1;
            List<CommonService.Model.C_Parameters> casesta = _parameterWCF.GetChildrenByParentId(198);
            ViewBag.casesta = casesta;
            List<CommonService.Model.FlowManager.P_Flow> casestage = _flowWCF.GetAllList();
            #region  业务查询条件
            if (!String.IsNullOrEmpty(form["B_Case_name"]))
            {//案件名称查询条件
                caseConditon.B_Case_name = form["B_Case_name"].Trim();
            }

            if (!String.IsNullOrEmpty(form["B_Case_number"]))
            {//案件编码查询条件
                caseConditon.B_Case_number = form["B_Case_number"].Trim();
            }

            if ((!String.IsNullOrEmpty(form["B_Case_state"])) && (form["B_Case_state"].ToString()) != "全部")
            {//案件状态查询条件
                caseConditon.B_Case_state = Convert.ToInt32(form["B_Case_state"]);
            }

            if ((!String.IsNullOrEmpty(form["B_Case_type"])) && (form["B_Case_type"].ToString()) != "全部")
            {//案件类型查询条件
                caseConditon.B_Case_type = Convert.ToInt32(form["B_Case_type"]);
            }
            #endregion
            ViewBag.casestage = casestage;
            ViewBag.CaseConditon = caseConditon;
            #endregion
            //获取案件总记录数
            this.TotalRecordCount = _caseWCF.GetPowerRecordCount(null,caseConditon, UIContext.Current.IsPreSetManager, UIContext.Current.UserCode,
                UIContext.Current.PostCode, UIContext.Current.OrgCode);
            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            //获取案件数据信息
            this.PageSize = 10;
            List<CommonService.Model.CaseManager.B_Case> banks = _caseWCF.GetPowerListByPage(null,caseConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, UIContext.Current.IsPreSetManager, 
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);
            #region 权限
            this.InitializationButtonsPower();
            #endregion
            CommonService.Model.CaseManager.B_CaseMaintain B_CaseMainModel = new CommonService.Model.CaseManager.B_CaseMaintain();
            ViewBag.B_CaseMain = B_CaseMainModel;

            return View(banks);
        }




             /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        public ActionResult Create_New(string fcasecode,string flowcode,string Form_formCode)
        {
            CommonService.Model.CaseManager.B_CaseMaintain B_CaseMainModel = new CommonService.Model.CaseManager.B_CaseMaintain();
            ViewBag.B_CaseMain = B_CaseMainModel;
            ViewData["addressUrlParameters"] = "";

            ViewBag.flowcode = flowcode;
            ViewBag.fcasecode =fcasecode;
            ViewBag.fccfcode =Form_formCode;
            return View();
        }
        /// <summary>
        /// 提交表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save_New(FormCollection form, CommonService.Model.CaseManager.B_CaseMaintain b_CaseMaintain)
        {
            //服务方法调用
            int userId = 0;
            if (!String.IsNullOrEmpty(form["B_Flow_code"]))
            {
                b_CaseMaintain.B_Flow_code = new Guid(form["B_Flow_code"]);
            }
            else
            {
                return Json(TipHelper.JsonData("请选择任务阶段！", "/CaseManager/CaseMaintain/Create_New", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            if (!String.IsNullOrEmpty(form["B_Case_code"]))
            {
                b_CaseMaintain.B_Case_code = new Guid(form["B_Case_code"]);
            }
            if (!String.IsNullOrEmpty(form["F_Form_code"]))
            {
                b_CaseMaintain.F_Form_code = new Guid(form["F_Form_code"]);
            }
            else
            {
                return Json(TipHelper.JsonData("请选择任务表单！", "/CaseManager/CaseMaintain/Create_New", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }

            b_CaseMaintain.B_CaseCost_creator = Guid.Parse(Context.UIContext.Current.UserCode.ToString());
            if (!String.IsNullOrEmpty(form["B_CaseCost_isDelete"]))
            {
                b_CaseMaintain.B_CaseCost_isDelete = Convert.ToInt32(form["B_CaseCost_isDelete"]);
            }
            if (!String.IsNullOrEmpty(form["B_CaseMaintain_code"]))
            {
                b_CaseMaintain.B_CaseMaintain_code = new Guid(form["B_CaseMaintain_code"]);
            }

            if (!String.IsNullOrEmpty(form["B_CaseMaintain_Date"]))
            {
                b_CaseMaintain.B_CaseMaintain_Date = Convert.ToDateTime(form["B_CaseMaintain_Date"]);
            }
            if (!String.IsNullOrEmpty(form["B_CaseMaintain_id"]))
            {
                b_CaseMaintain.B_CaseMaintain_id = Convert.ToInt32(form["B_CaseMaintain_id"]);
            }


            if (b_CaseMaintain.B_CaseMaintain_id > 0)
            {//修改

                b_CaseMaintain.B_CaseMaintain_Date = b_CaseMaintain.B_CaseCost_createTime;
                bool isUpdateSuccess = _bussinessCaseMaintainWCF.Update(b_CaseMaintain);
                if (isUpdateSuccess)
                {
                    userId = b_CaseMaintain.B_CaseMaintain_id;
                }
            }
            else
            {//添加 
                b_CaseMaintain.B_CaseCost_createTime = DateTime.Now;
                b_CaseMaintain.B_CaseMaintain_code = Guid.NewGuid();
                b_CaseMaintain.B_CaseCost_isDelete = 0;
                b_CaseMaintain.B_CaseMaintain_Date = b_CaseMaintain.B_CaseCost_createTime;
                b_CaseMaintain.B_CaseCost_creator = Guid.Parse(Context.UIContext.Current.UserCode.ToString());
                userId = _bussinessCaseMaintainWCF.Add(b_CaseMaintain);
            }

            if (userId > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存成功", "/CaseManager/CaseMaintain/Create_New", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存成功", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }


        /// <summary>
        /// 案件列表
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult ListCase(FormCollection form, int? page = 1)
        {
            InitializationPageParameter();

            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //案件查询模型
            CommonService.Model.CaseManager.B_Case caseConditon = new CommonService.Model.CaseManager.B_Case();
         
            //案件查询模型传递到前端视图中
            caseConditon.B_Case_oprationtype = 1;
            List<CommonService.Model.C_Parameters> casesta = _parameterWCF.GetChildrenByParentId(198);
            ViewBag.casesta = casesta;
            List<CommonService.Model.FlowManager.P_Flow> casestage = _flowWCF.GetAllList();
            #region  业务查询条件
            if (!String.IsNullOrEmpty(form["B_Case_name"]))
            {//案件名称查询条件
                caseConditon.B_Case_name = form["B_Case_name"].Trim();
            }

            if (!String.IsNullOrEmpty(form["B_Case_number"]))
            {//案件编码查询条件
                caseConditon.B_Case_number = form["B_Case_number"].Trim();
            }

            if ((!String.IsNullOrEmpty(form["B_Case_state"])) && (form["B_Case_state"].ToString()) != "全部")
            {//案件状态查询条件
                caseConditon.B_Case_state = Convert.ToInt32(form["B_Case_state"]);
            }

            if ((!String.IsNullOrEmpty(form["B_Case_type"])) && (form["B_Case_type"].ToString()) != "全部")
            {//案件类型查询条件
                caseConditon.B_Case_type = Convert.ToInt32(form["B_Case_type"]);
            }


            #endregion
            ViewBag.casestage = casestage;
            ViewBag.CaseConditon = caseConditon;
            #endregion

            //获取案件总记录数
            this.TotalRecordCount = _caseWCF.GetPowerRecordCount(null,caseConditon, UIContext.Current.IsPreSetManager, UIContext.Current.UserCode,
                UIContext.Current.PostCode, UIContext.Current.OrgCode);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取案件数据信息
            List<CommonService.Model.CaseManager.B_Case> banks = _caseWCF.GetPowerListByPage(null,caseConditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, UIContext.Current.PostCode, UIContext.Current.OrgCode);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View("/Areas/CaseManager/Views/CaseMaintain/ListCase.cshtml", banks);

        }
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
        }



        public ActionResult MaintainLayout(string fkCode)
        {
            ViewBag.FkCode = fkCode;
 
            return View();

        }
        /// <summary>
        /// 业务流程树Action
        /// </summary>
        /// <param name="pkCode">案件Guid或商机Guid</param>
        /// <returns></returns>
        public ActionResult Tree(string pkCode)
        {
            SetSingleBusinessFlow(new Guid(pkCode));
            return View();
        }

        #region 不含checkbox的业务流程递归

        /// <summary>
        /// 根据关联外键Guid，获取关联所有业务流程信息
        /// </summary>
        /// <param name="pkCode">关联外键Guid</param>
        private void SetSingleBusinessFlow(Guid pkCode)
        {
            List<CommonService.Model.FlowManager.P_Business_flow> businessFlows = _bussinessFlowWCF.GetListByFkCode(pkCode);
            SetSingleTopBusinessFlow(businessFlows, pkCode);
        }

        /// <summary>
        /// 装载顶级业务流程
        /// </summary>
        /// <param name="businessFlowList">业务流程集合</param>
        private void SetSingleTopBusinessFlow(List<CommonService.Model.FlowManager.P_Business_flow> businessFlowList, Guid pkCode)
        {
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
            CommonService.Model.CaseManager.B_Case bcase = _caseWCF.GetModel(pkCode);
            string caseName = bcase.B_Case_name;
            if (!String.IsNullOrEmpty(caseName) && caseName.Length > 10)
            {
                caseName = caseName.Substring(0, 10) + "......";
            }
            businessFlowTreeHtml += "<li class=\"jstree-open\" ><a class=\"jstree-anchor jstree-clicked\" uniqueid=\"\" href=\"\">" + caseName + "</a>";
            businessFlowTreeHtml += "<ul>";

            foreach (CommonService.Model.FlowManager.P_Business_flow businessFlow in topBusinessFlowList)
            {
                string href = "?{flowCode}=" + businessFlow.P_Flow_code.Value.ToString();
                string uniqueId = businessFlow.P_Business_flow_code.Value.ToString();
                nodeName = businessFlow.P_Business_flow_name;

                if (UIContext.Current.IsPreSetManager)
                {
                    businessFlowTreeHtml += "<li class=\"jstree-open\"  ><a " + " uniqueid=\"" + uniqueId + "\" href=\"" + href + "\" level=\"" + businessFlow.P_Business_flow_level + "\">" + nodeName + "</a>";
                }
                else if (businessFlow.P_Business_person == Context.UIContext.Current.UserCode)
                {
                    businessFlowTreeHtml += "<li class=\"jstree-open\"  ><a " + " uniqueid=\"" + uniqueId + "\" href=\"" + href + "\" level=\"" + businessFlow.P_Business_flow_level + "\">" + nodeName + "</a>";
                }
                else
                {
                    businessFlowTreeHtml += "<li class=\"jstree-open\"  ><a class=\"jstree-disabled\" uniqueid=\"" + uniqueId + "\" href=\"" + href + "\" level=\"" + businessFlow.P_Business_flow_level + "\">" + nodeName + "</a>";
                }
                SetSignleRecursionTree(businessFlow.P_Business_flow_code.Value, ref businessFlowTreeHtml, businessFlowList);
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
        private void SetSignleRecursionTree(Guid parentCode, ref string businessFlowTreeHtml, List<CommonService.Model.FlowManager.P_Business_flow> businessFlowList)
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
            foreach (CommonService.Model.FlowManager.P_Business_flow businessFlow in lowbusinessFlowList)
            {
                string href = "?{flowCode}=" + businessFlow.P_Flow_code.Value.ToString();
                string uniqueId = businessFlow.P_Business_flow_code.Value.ToString();
                nodeName = businessFlow.P_Business_flow_name;


                if (UIContext.Current.IsPreSetManager)
                {
                    businessFlowTreeHtml += "<li class=\"jstree-open\"  ><a " + " uniqueid=\"" + uniqueId + "\" href=\"" + href + "\" level=\"" + businessFlow.P_Business_flow_level + "\">" + nodeName + "</a>";
                }
                else if (parentBusinessCode.P_Business_person == Context.UIContext.Current.UserCode)
                {
                    businessFlowTreeHtml += "<li class=\"jstree-open\"  ><a " + " uniqueid=\"" + uniqueId + "\" href=\"" + href + "\" level=\"" + businessFlow.P_Business_flow_level + "\">" + nodeName + "</a>";
                }
                else
                {
                    businessFlowTreeHtml += "<li class=\"jstree-open\"  ><a class=\"jstree-disabled\" uniqueid=\"" + uniqueId + "\" href=\"" + href + "\" level=\"" + businessFlow.P_Business_flow_level + "\">" + nodeName + "</a>";
                }
                //businessFlowTreeHtml += "<li class=\"jstree-open\"><a " + disabled + " uniqueid=\"" + uniqueId + "\" href=\"" + href + "\" level=\"" + businessFlow.P_Business_flow_level + "\">" + nodeName + "</a>";
                SetSignleRecursionTree(businessFlow.P_Business_flow_code.Value, ref businessFlowTreeHtml, businessFlowList);
                businessFlowTreeHtml += "</li>";
            }
            if (lowbusinessFlowList.Count() != 0)
            {
                businessFlowTreeHtml += "</ul>";
            }
        }

        #endregion

        /// <summary>
        /// 业务流程关联所有表单Action
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public ActionResult BusinessFlowRelationFormList(string businessFlowCode)
        {
            List<CommonService.Model.FlowManager.P_Business_flow_form> businessFlowForms;
            if (businessFlowCode == "{sid_Iterm}" || businessFlowCode == "")
            {
                businessFlowForms = new List<CommonService.Model.FlowManager.P_Business_flow_form>();
            }
            else
            {
                businessFlowForms = _businessFlowFormWCF.GetBusinessFlowForms(new Guid(businessFlowCode));
            }
            return View(businessFlowForms);
        }
        /// <summary>
        /// 提交表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.CaseManager.B_CaseMaintain b_CaseMaintain)
        {
            //服务方法调用
            int userId = 0;
            if (!String.IsNullOrEmpty(form["B_Flow_code"]))
            {
                b_CaseMaintain.B_Flow_code = new Guid(form["B_Flow_code"]);
            }
            else {
                return Json(TipHelper.JsonData("请选择任务阶段！", "/CaseManager/CaseMaintain/create", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            if (!String.IsNullOrEmpty(form["B_Case_code"]))
            {
                b_CaseMaintain.B_Case_code = new Guid(form["B_Case_code"]);  
            }
            if (!String.IsNullOrEmpty(form["F_Form_code"]))
            {
                b_CaseMaintain.F_Form_code = new Guid(form["F_Form_code"]);
            }
            else {
                return Json(TipHelper.JsonData("请选择任务表单！", "/CaseManager/CaseMaintain/create", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }

            b_CaseMaintain.B_CaseCost_creator = Guid.Parse(Context.UIContext.Current.UserCode.ToString());
            if (!String.IsNullOrEmpty(form["B_CaseCost_isDelete"]))
            {
                b_CaseMaintain.B_CaseCost_isDelete = Convert.ToInt32(form["B_CaseCost_isDelete"]);
            }
            if (!String.IsNullOrEmpty(form["B_CaseMaintain_code"]))
            {
                b_CaseMaintain.B_CaseMaintain_code = new Guid(form["B_CaseMaintain_code"]);
            }

            if (!String.IsNullOrEmpty(form["B_CaseMaintain_Date"]))
            {
                b_CaseMaintain.B_CaseMaintain_Date = Convert.ToDateTime(form["B_CaseMaintain_Date"]);
            }
            if (!String.IsNullOrEmpty(form["B_CaseMaintain_id"]))
            {
                b_CaseMaintain.B_CaseMaintain_id = Convert.ToInt32(form["B_CaseMaintain_id"]);
            }


            if (b_CaseMaintain.B_CaseMaintain_id > 0)
            {//修改

                b_CaseMaintain.B_CaseMaintain_Date = b_CaseMaintain.B_CaseCost_createTime;
                bool isUpdateSuccess = _bussinessCaseMaintainWCF.Update(b_CaseMaintain);
                if (isUpdateSuccess)
                {
                    userId = b_CaseMaintain.B_CaseMaintain_id;
                }
            }
            else
            {//添加 
                b_CaseMaintain.B_CaseCost_createTime = DateTime.Now;
                b_CaseMaintain.B_CaseMaintain_code = Guid.NewGuid();
                b_CaseMaintain.B_CaseCost_isDelete = 0;
                b_CaseMaintain.B_CaseMaintain_Date = b_CaseMaintain.B_CaseCost_createTime;
                b_CaseMaintain.B_CaseCost_creator = Guid.Parse(Context.UIContext.Current.UserCode.ToString());
                userId = _bussinessCaseMaintainWCF.Add(b_CaseMaintain);
            }

            if (userId > 0)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存用户信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存用户信息成功", "/CaseManager/CaseMaintain/create", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存用户信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存用户信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// 案件信息
        /// </summary>
        /// <param name="caseCode">案件Code</param>
        /// <param name="type">1、修改按钮</param>
        /// <returns></returns>
        public ActionResult CaseTabDetails(FormCollection form, string caseCode, int? page = 1)
        {           
            B_Case model = _caseWCF.GetModel(Guid.Parse(caseCode));
            ViewBag.casename = model.B_Case_name;
            B_CaseMaintain model2 = new B_CaseMaintain();
            model2.B_Case_code = Guid.Parse(caseCode);
            //获取案件总记录数
            this.PageSize = 10;
            this.TotalRecordCount = _bussinessCaseMaintainWCF.GetRecordCount(model2);
            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            ViewData["addressUrlParameters"] = "?caseCode=" + caseCode;
            List<CommonService.Model.CaseManager.B_CaseMaintain> bank = _bussinessCaseMaintainWCF.GetListByPage(model2, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(bank);
        }
        /// <summary>
        /// 案件信息
        /// </summary>
        /// <param name="caseCode">案件Code</param>
        /// <param name="type">1、修改按钮</param>
        /// <returns></returns>
        public ActionResult CaseTabDetailss(FormCollection form, string caseCode, int? page = 1)
        {
            
            B_Case model = _caseWCF.GetModel(Guid.Parse(caseCode));
            ViewBag.casename = model.B_Case_name;
            B_CaseMaintain model2 = new B_CaseMaintain();
            model2.B_Case_code = Guid.Parse(caseCode);
            //获取案件总记录数
            this.PageSize = 10;
            this.TotalRecordCount = _bussinessCaseMaintainWCF.GetRecordCount(model2);
            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);
            ViewData["addressUrlParameters"] = "?caseCode=" + caseCode;
          
            List<CommonService.Model.CaseManager.B_CaseMaintain> bank = _bussinessCaseMaintainWCF.GetListByPage(model2, "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(bank);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int caseCode)
        {
            InitializationPageParameter();
            ViewData["addressUrlParameters"] = "";
            B_CaseMaintain model = new B_CaseMaintain();
            model = _bussinessCaseMaintainWCF.GetModel(caseCode);
            //服务方法调用
            return View(model);
        }
        /// <summary>
        /// 删除维护数据一条
        /// </summary>
        /// <param name="bankCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int B_CaseMaintain_id)
        {
            bool isSuccess = _bussinessCaseMaintainWCF.Delete(B_CaseMaintain_id);

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
        /// 删除维护中心界面的案件
        /// </summary>
        /// <param name="caseCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Deletecase(string caseCode)
        {
            bool isSuccess = _bussinessCaseMaintainWCF.DeleteCase(caseCode);

            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除案件信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除案件信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            return null;
        }

    }
}