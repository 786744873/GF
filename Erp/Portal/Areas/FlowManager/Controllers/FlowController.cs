using CommonService.Common;
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
    ///流程控制器
    /// </summary>
    public class FlowController : BaseController
    {
        private readonly ICommonService.IC_Parameters _parametersWCF;
        private readonly ICommonService.FlowManager.IP_Flow _flowWCF;
        private readonly ICommonService.SysManager.IC_Post _postWCF;
        private readonly ICommonService.FlowManager.IP_Flow_post _flow_postWCF;
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;
        public FlowController()
        {
            #region 服务初始化
            _parametersWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _flowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow>("FlowWCF");
            _postWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Post>("PostWCF");
            _flow_postWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow_post>("Flow_postWCF");
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            #endregion
        }
        //
        // GET: /FlowManager/Flow/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string flowCode, int? flowType)
        {
            InitializationPageParameter();
            //创建初始化参数实体
            CommonService.Model.FlowManager.P_Flow flow = new CommonService.Model.FlowManager.P_Flow();
            List<CommonService.Model.SysManager.C_Post> posts = _postWCF.GetList();
            flow.P_Flow_code = Guid.NewGuid();
            flow.P_Flow_level = 0;
            if (!String.IsNullOrEmpty(flowCode))
            {
                flow.P_Flow_parent = new Guid(flowCode);
            }
            if (flowType != null)
            {
                flow.P_Flow_type = flowType;
            }
            flow.P_Flow_creator = Context.UIContext.Current.UserCode;
            flow.P_Flow_createTime = DateTime.Now;
            flow.P_Flow_isDelete = 0;
            flow.P_Flow_order = 0;
            flow.C_Posts = posts;
            if (flow.P_Flow_parent == null)
            {
                ViewBag.SelectedFlowCode = "";
            }
            else
            {
                ViewBag.SelectedFlowCode = flowCode;
            }
            if (flow.P_Flow_type == null)
            {
                ViewBag.flowType = "";
            }
            else
            {
                ViewBag.flowType = flowType;
            }

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(flow);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string flowCode, int? flowType)
        {
            if (String.IsNullOrEmpty(flowCode) || flowCode == "{flowCode}")
            {
                return RedirectToAction("Create", new { flowType = flowType });
            }
            InitializationPageParameter();
            CommonService.Model.FlowManager.P_Flow flow = _flowWCF.GetModel(new Guid(flowCode));
            ViewBag.SelectedFlowCode = flowCode;
            ViewBag.flowType = flowType;

            List<CommonService.Model.SysManager.C_Post> posts = _postWCF.GetList();
            List<CommonService.Model.FlowManager.P_Flow_post> flow_posts = _flow_postWCF.GetListByFlowcode(new Guid(flowCode));
            foreach (var post in posts)
            {
                foreach (var flow_post in flow_posts)
                {
                    if (post.C_Post_code == flow_post.F_Post_code)
                    {
                        post.C_Post_ischeckted = true;
                    }
                }
            }
            flow.C_Posts = posts;

            #region 权限
            this.InitializationButtonsPower();
            #endregion


            return View("Create", flow);
        }

        /// <summary>
        /// 布局TreeList
        /// </summary>
        /// <returns></returns>
        public ActionResult LayoutTreeList()
        {
            return View();
        }

        /// <summary>
        /// 普通树结构Action
        /// </summary>
        /// <param name="sourceType">调用此Action，的来源，根据此来源，处理点击树节点后的目标导航链接：1代表流程基础页面调用；2代表业务流程页面调用</param>
        /// <param name="businessFlowCode">业务流程Code</param>
        /// <param name="fkCode">关联Guid比如案件、商机Guid等</param>
        /// <param name="operatetype">操作类型：add代表增加；edit代表修改</param>
        /// <returns></returns>
        public ActionResult Tree(int sourceType, string businessFlowCode, string fkCode, string operatetype, int type)
        {
            SetSingleFlow(sourceType, businessFlowCode, fkCode, operatetype, type);
            ViewBag.sourceType = sourceType;
            return View();
        }

        /// <summary>
        /// 普通树结构Action
        /// </summary>
        /// <param name="sourceType">调用此Action，的来源，根据此来源，处理点击树节点后的目标导航链接：1代表流程基础页面调用；2代表业务流程页面调用</param>
        /// <param name="businessFlowCode">业务流程Code</param>
        /// <param name="fkCode">关联Guid比如案件、商机Guid等</param>
        /// <param name="operatetype">操作类型：add代表增加；edit代表修改</param>
        /// <returns></returns>
        public ActionResult Validate_Tree(int sourceType, string businessFlowCode, string fkCode, string operatetype, int type)
        {
            Validate_SetSingleFlow(sourceType, businessFlowCode, fkCode, operatetype, type);
            ViewBag.sourceType = sourceType;
            return View("Tree");
        }

        public ActionResult List(FormCollection form, int? page = 1)
        {
            InitializationPageParameter();
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //参数查询模型
            CommonService.Model.FlowManager.P_Flow flowConditon = new CommonService.Model.FlowManager.P_Flow();

            if (!String.IsNullOrEmpty(form["P_Flow_name"]))
            {//参数名称查询条件
                flowConditon.P_Flow_name = form["P_Flow_name"].Trim(); ;
            }

            //参数查询模型传递到前端视图中
            ViewBag.FlowConditon = flowConditon;

            #endregion

            //获取参数总记录数
            this.TotalRecordCount = _flowWCF.GetRecordCount(flowConditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            List<CommonService.Model.FlowManager.P_Flow> flow = _flowWCF.GetListByPage(flowConditon,
                "P_Flow_level Asc,T.P_Flow_order Asc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);
            return View(flow);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(CommonService.Model.FlowManager.P_Flow flow)
        {
            //服务方法调用
            int flowId = 0;

            if (flow.P_Flow_id > 0)
            {//修改
                bool isUpdateSuccess = _flowWCF.Update(flow);
                if (isUpdateSuccess)
                {
                    flowId = flow.P_Flow_id;
                }
            }
            else
            {//添加
                flow.P_Flow_createTime = DateTime.Now;
                flowId = _flowWCF.Add(flow);
            }

            if (flowId >= 0)
            {
                //保存成功提示固定写法
                return Json(TipHelper.JsonData("保存流程信息成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshParent));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存流程信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string flowCode)
        {
            bool isSuccess = _flowWCF.Delete(new Guid(flowCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除流程信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshParent));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除流程信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        #region 不含checkbox的流程递归

        /// <summary>
        ///  装载全部流程信息
        /// </summary>
        private void SetSingleFlow(int sourceType, string businessFlowCode, string fkCode, string operatetype, int type)
        {
            List<CommonService.Model.FlowManager.P_Flow> flows = _flowWCF.GetAllList();
            SetSingleTopFlow(flows, sourceType, businessFlowCode, fkCode, operatetype, type);
        }
        /// <summary>
        ///  装载全部流程信息
        /// </summary>
        private void Validate_SetSingleFlow(int sourceType, string businessFlowCode, string fkCode, string operatetype, int type)
        {
            List<CommonService.Model.FlowManager.P_Flow> flows = _flowWCF.GetAllList();

            var businessList = _bussinessFlowWCF.GetListByFkCode(Guid.Parse(fkCode));
            foreach (var item in businessList)
            {
                if (type == 2 && item.P_Business_flow_applicationStatus == Convert.ToInt32(BusinessFlowApplicationStatueType.配置未通过))
                {
                    continue; 
                }
                else
                {
                    var mf = flows.Where(p => p.P_Flow_code == item.P_Flow_code).FirstOrDefault();
                    flows.Remove(mf);
                }
               
            }

            SetSingleTopFlow(flows, sourceType, businessFlowCode, fkCode, operatetype, type);
        }

        /// <summary>
        /// 装载顶级流程
        /// </summary>
        /// <param name="flowList">流程集合</param>
        private void SetSingleTopFlow(List<CommonService.Model.FlowManager.P_Flow> flowList, int sourceType, string businessFlowCode, string fkCode, string operatetype, int type)
        {
            string flowTreeHtml = "";
            string preTreeHtml = "<ul>";//树前缀
            string backTreeHtml = "</ul>";//树后缀
            var topFlowCaseList = from allList in flowList
                                  where allList.P_Flow_level == 1 && allList.P_Flow_type == Convert.ToInt32(FlowTypeEnum.案件)
                                  orderby allList.P_Flow_order ascending
                                  select allList;
            var topFlowOpportunitiesList = from allList in flowList
                                           where allList.P_Flow_level == 1 && allList.P_Flow_type == Convert.ToInt32(FlowTypeEnum.商机)
                                           orderby allList.P_Flow_order ascending
                                           select allList;
            var topFlowCustomerList = from allList in flowList
                                      where allList.P_Flow_level == 1 && allList.P_Flow_type == Convert.ToInt32(FlowTypeEnum.客户)
                                      orderby allList.P_Flow_order ascending
                                      select allList;
            string href = "";

            if (sourceType == 2)
            {
                #region 业务流程调用
                if (type == 1)
                {//案件
                    foreach (CommonService.Model.FlowManager.P_Flow flow in topFlowCaseList)
                    {
                        href = "";
                        if (operatetype == "add")
                        {
                            href = "/flowmanager/businessflow/create?businessFlowCode=" + businessFlowCode + "&fkCode=" + fkCode + "&flowCode=" + flow.P_Flow_code + "&type=" + type;
                        }
                        else if (operatetype == "edit")
                        {
                            href = "/flowmanager/businessflow/edit?businessFlowCode=" + businessFlowCode + "&flowCode=" + flow.P_Flow_code + "&type=" + type;
                        }
                        string uniqueId = flow.P_Flow_code.Value.ToString();

                        flowTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + flow.P_Flow_name + "</a>";
                        SetSignleRecursionTree(flow.P_Flow_code.Value, ref flowTreeHtml, flowList, sourceType, businessFlowCode, fkCode, operatetype);
                        flowTreeHtml += "</li>";
                    }
                }
                else if (type == 2)
                {//商机
                    foreach (CommonService.Model.FlowManager.P_Flow flow in topFlowOpportunitiesList)
                    {
                        href = "";
                        if (operatetype == "add")
                        {
                            href = "/flowmanager/businessflow/create?businessFlowCode=" + businessFlowCode + "&fkCode=" + fkCode + "&flowCode=" + flow.P_Flow_code + "&type=" + type;
                        }
                        else if (operatetype == "edit")
                        {
                            href = "/flowmanager/businessflow/edit?businessFlowCode=" + businessFlowCode + "&flowCode=" + flow.P_Flow_code + "&type=" + type;
                        }
                        string uniqueId = flow.P_Flow_code.Value.ToString();

                        flowTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + flow.P_Flow_name + "</a>";
                        SetSignleRecursionTree(flow.P_Flow_code.Value, ref flowTreeHtml, flowList, sourceType, businessFlowCode, fkCode, operatetype);
                        flowTreeHtml += "</li>";
                    }
                }
                else if (type == 3)
                {//客户
                    foreach (CommonService.Model.FlowManager.P_Flow flow in topFlowCustomerList)
                    {
                        href = "";
                        if (operatetype == "add")
                        {
                            href = "/flowmanager/businessflow/create?businessFlowCode=" + businessFlowCode + "&fkCode=" + fkCode + "&flowCode=" + flow.P_Flow_code + "&type=" + type;
                        }
                        else if (operatetype == "edit")
                        {
                            href = "/flowmanager/businessflow/edit?businessFlowCode=" + businessFlowCode + "&flowCode=" + flow.P_Flow_code + "&type=" + type;
                        }
                        string uniqueId = flow.P_Flow_code.Value.ToString();

                        flowTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + flow.P_Flow_name + "</a>";
                        SetSignleRecursionTree(flow.P_Flow_code.Value, ref flowTreeHtml, flowList, sourceType, businessFlowCode, fkCode, operatetype);
                        flowTreeHtml += "</li>";
                    }
                }
                #endregion
            }
            else if (sourceType == 3)
            {
                #region 进程管理页面调用
                foreach (CommonService.Model.FlowManager.P_Flow flow in topFlowCaseList)
                {
                    href = "?{flowCode}=" + flow.P_Flow_code;
                    string uniqueId = flow.P_Flow_code.Value.ToString();

                    flowTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + flow.P_Flow_name + "</a>";
                    SetSignleRecursionTree(flow.P_Flow_code.Value, ref flowTreeHtml, flowList, sourceType, businessFlowCode, fkCode, operatetype);
                    flowTreeHtml += "</li>";
                }
                #endregion
            }
            else
            {//流程基础页面调用
                #region  案件
                href = "?{flowType}=" + Convert.ToInt32(FlowTypeEnum.案件);
                flowTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"\" href=\"" + href + "\">案件</a>";
                flowTreeHtml += "<ul>";
                /*
               *
               *说明：只要在<li>标签上加上 class=jstree-open, 默认就会打开树,hety,2015-05-19
               */
                foreach (CommonService.Model.FlowManager.P_Flow flow in topFlowCaseList)
                {
                    href = "";
                    href = "?{flowCode}=" + flow.P_Flow_code + "&{flowType}=" + flow.P_Flow_type;
                    string uniqueId = flow.P_Flow_code.Value.ToString();

                    flowTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + flow.P_Flow_name + "</a>";
                    SetSignleRecursionTree(flow.P_Flow_code.Value, ref flowTreeHtml, flowList, sourceType, businessFlowCode, fkCode, operatetype);
                    flowTreeHtml += "</li>";
                }
                flowTreeHtml += "</ul>";
                flowTreeHtml += "</li>";

                #endregion

                #region  商机
                href = "?{flowType}=" + Convert.ToInt32(FlowTypeEnum.商机);
                flowTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"\" href=\"" + href + "\">商机</a>";
                flowTreeHtml += "<ul>";
                /*
                 *
                 *说明：只要在<li>标签上加上 class=jstree-open, 默认就会打开树,hety,2015-05-19
                 */
                foreach (CommonService.Model.FlowManager.P_Flow flow in topFlowOpportunitiesList)
                {
                    href = "";
                    href = "?{flowCode}=" + flow.P_Flow_code + "&{flowType}=" + flow.P_Flow_type;
                    string uniqueId = flow.P_Flow_code.Value.ToString();

                    flowTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + flow.P_Flow_name + "</a>";
                    SetSignleRecursionTree(flow.P_Flow_code.Value, ref flowTreeHtml, flowList, sourceType, businessFlowCode, fkCode, operatetype);
                    flowTreeHtml += "</li>";
                }
                flowTreeHtml += "</ul>";
                flowTreeHtml += "</li>";

                #endregion

                #region  客户
                href = "?{flowType}=" + Convert.ToInt32(FlowTypeEnum.客户);
                flowTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"\" href=\"" + href + "\">客户</a>";
                flowTreeHtml += "<ul>";
                /*
                 *
                 *说明：只要在<li>标签上加上 class=jstree-open, 默认就会打开树,hety,2015-11-24
                 */
                foreach (CommonService.Model.FlowManager.P_Flow flow in topFlowCustomerList)
                {
                    href = "";
                    href = "?{flowCode}=" + flow.P_Flow_code + "&{flowType}=" + flow.P_Flow_type;
                    string uniqueId = flow.P_Flow_code.Value.ToString();

                    flowTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + flow.P_Flow_name + "</a>";
                    SetSignleRecursionTree(flow.P_Flow_code.Value, ref flowTreeHtml, flowList, sourceType, businessFlowCode, fkCode, operatetype);
                    flowTreeHtml += "</li>";
                }
                flowTreeHtml += "</ul>";
                flowTreeHtml += "</li>";

                #endregion
            }

            ViewBag.SingleFlowTreeHtml = preTreeHtml + flowTreeHtml + backTreeHtml;
        }

        /// <summary>
        /// 递归加载所有流程
        /// </summary>
        /// <param name="parentCode">上级流程Code</param>
        /// <param name="organizationTreeHtml">流程Tree Html</param>
        /// <param name="categoryList">分类集合</param>
        private void SetSignleRecursionTree(Guid parentCode, ref string flowTreeHtml, List<CommonService.Model.FlowManager.P_Flow> flowList, int sourceType, string businessFlowCode, string fkCode, string operatetype)
        {
            var lowflowList = from allList in flowList
                              where allList.P_Flow_parent == parentCode
                              orderby allList.P_Flow_order ascending
                              select allList;
            if (lowflowList.Count() != 0)
            {
                flowTreeHtml += "<ul>";
            }
            /*
             *
             *说明：只要在<li>标签上加上 class=jstree-open, 默认就会打开树,hety,2015-05-19
             */
            foreach (CommonService.Model.FlowManager.P_Flow flow in lowflowList)
            {
                string href = "";
                switch (sourceType)
                {
                    case 1://代表流程基础页面调用
                        //href = "/flowmanager/flow/edit?flowCode=" + flow.P_Flow_code;
                        href = "?{flowCode}=" + flow.P_Flow_code + "&{flowType}=" + flow.P_Flow_type;
                        break;
                    case 2://代表业务流程页面调用
                        if (operatetype == "add")
                        {
                            href = "/flowmanager/businessflow/create?businessFlowCode=" + businessFlowCode + "&fkCode=" + fkCode + "&flowCode=" + flow.P_Flow_code;
                        }
                        else if (operatetype == "edit")
                        {
                            href = "/flowmanager/businessflow/edit?businessFlowCode=" + businessFlowCode + "&flowCode=" + flow.P_Flow_code;
                        }
                        break;
                    default:
                        break;
                }
                string uniqueId = flow.P_Flow_code.Value.ToString();
                flowTreeHtml += "<li class=\"jstree-open\"><a uniqueid=\"" + uniqueId + "\" href=\"" + href + "\">" + flow.P_Flow_name + "</a>";
                SetSignleRecursionTree(flow.P_Flow_code.Value, ref flowTreeHtml, flowList, sourceType, businessFlowCode, fkCode, operatetype);
                flowTreeHtml += "</li>";
            }
            if (lowflowList.Count() != 0)
            {
                flowTreeHtml += "</ul>";
            }
        }

        #endregion

        public ActionResult Test()
        {
            return View();
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //流程类型参数集合
            List<CommonService.Model.C_Parameters> Flow_type = _parametersWCF.GetChildrenByParentId(Convert.ToInt32(FlowEnum.流程类型));
            ViewBag.Flow_type = Flow_type;

            List<CommonService.Model.C_Parameters> FlowManagerType = _parametersWCF.GetChildrenByParentId(Convert.ToInt32(FlowEnum.流程所属类型));
            ViewBag.FlowManagerType = FlowManagerType;
        }
    }
}