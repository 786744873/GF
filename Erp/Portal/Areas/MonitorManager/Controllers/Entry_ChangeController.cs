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
    ///条目变更表控制器
    ///作者：崔慧栋
    ///日期：2015/06/12
    /// </summary>
    public class Entry_ChangeController : BaseController
    {
        private readonly ICommonService.MonitorManager.IM_Entry_Change _entry_ChangeWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.MonitorManager.IM_Entry_Statistics _entry_StatisticsWCF;
        public Entry_ChangeController()
        {
            #region 服务初始化
            _entry_ChangeWCF = ServiceProxyFactory.Create<ICommonService.MonitorManager.IM_Entry_Change>("Entry_ChangeWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _entry_StatisticsWCF = ServiceProxyFactory.Create<ICommonService.MonitorManager.IM_Entry_Statistics>("Entry_StatisticsWCF");
            #endregion
        }
        //
        // GET: /MonitorManager/Entry_Change/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string Entry_Statistics_code)
        {
            InitializationPageParameter();
            string[] codeStr = Entry_Statistics_code.Split(',');
            //创建初始化实体
            CommonService.Model.MonitorManager.M_Entry_Change entry_change = new CommonService.Model.MonitorManager.M_Entry_Change();
            CommonService.Model.MonitorManager.M_Entry_Change entry_change1 = _entry_ChangeWCF.GetModel(new Guid(codeStr[0]));

            CommonService.Model.MonitorManager.M_Entry_Statistics mntryStatistics = _entry_StatisticsWCF.GetModel(new Guid(codeStr[1]));
            ViewBag.mntryStatistics = mntryStatistics;

            int? Duration = 0;
            List<CommonService.Model.MonitorManager.M_Entry_Change> entry_changeList = _entry_ChangeWCF.GetModelList("M_Entry_Statistics_code=" + "'" + codeStr[1] + "'");
            foreach (CommonService.Model.MonitorManager.M_Entry_Change entryChange in entry_changeList)
            {
                if (entryChange.M_Entry_Change_IsThrough == 327)
                {//审核通过
                    Duration += entryChange.M_Entry_Change_approvalDuration;
                }
            }
            ViewBag.Duration = Duration;

            if (entry_change1 == null)
            {
                entry_change.M_Entry_Change_code = Guid.NewGuid();
                if (!String.IsNullOrEmpty(codeStr[1]))
                {
                    entry_change.M_Entry_Statistics_code = new Guid(codeStr[1]);
                }
                entry_change.M_Entry_Change_proposer = Context.UIContext.Current.UserName;
                entry_change.M_Entry_Change_Applicant = Context.UIContext.Current.UserCode;
                entry_change.M_Entry_Change_applicationTime = DateTime.Now;
                entry_change.M_Entry_Change_IsThrough = Convert.ToInt32(EntryChangeIsThroughlEnum.未审批);
                entry_change.M_Entry_Change_isDelete = 0;
                entry_change.M_Entry_Change_creator = Context.UIContext.Current.UserCode;
                entry_change.M_Entry_Change_createTime = DateTime.Now;

                return View(entry_change);
            }else
            {
                return View(entry_change1);
            }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string entryChange_code)
        {
            InitializationPageParameter();
            string[] codeStr = entryChange_code.Split(',');
            CommonService.Model.MonitorManager.M_Entry_Change entry_change = _entry_ChangeWCF.GetModel(new Guid(codeStr[0]));
            entry_change.M_Entry_Change_approvalPerson = UIContext.Current.UserName;
            entry_change.M_Entry_Change_Approval = UIContext.Current.UserCode;
            entry_change.M_Entry_Change_approvalTime = DateTime.Now;

            CommonService.Model.MonitorManager.M_Entry_Statistics mntryStatistics = _entry_StatisticsWCF.GetModel(new Guid(codeStr[1]));
            ViewBag.mntryStatistics = mntryStatistics;

            int? Duration = 0;
            List<CommonService.Model.MonitorManager.M_Entry_Change> entry_changeList = _entry_ChangeWCF.GetModelList("M_Entry_Statistics_code=" + "'" + codeStr[1] + "'");
            foreach (CommonService.Model.MonitorManager.M_Entry_Change entryChange in entry_changeList)
            {
                if (entryChange.M_Entry_Change_IsThrough == 327)
                {//审核通过
                    Duration += entryChange.M_Entry_Change_approvalDuration;
                }
            }
            ViewBag.Duration = Duration;

            return View(entry_change);
        }

        ///详细变更列表
        public ActionResult PKRelationBusinessFlowList2(string M_Entry_Statistics_code)
        {
            InitializationPageParameter();
           
            List<CommonService.Model.MonitorManager.M_Entry_Change> entry_changeList =_entry_ChangeWCF.GetModelList("M_Entry_Statistics_code="+"'"+M_Entry_Statistics_code+"'");
            
            return View(entry_changeList);
        }

        /// <summary>
        /// 条目变更记录
        /// </summary>
        /// <param name="pkCode">案件Guid</param>
        /// <returns></returns>
        public ActionResult EntryChangeRecord(string pkCode)
        {
            InitializationPageParameter();
            List<CommonService.Model.MonitorManager.M_Entry_Change> entry_changeList = _entry_ChangeWCF.GetEntryChangeRecordByPkCode(new Guid(pkCode));

            if (entry_changeList.Count() == 0)
            {
                return RedirectToAction("EmptyEntryChangeRecord");
            }

            return View(entry_changeList);
        }
        /// <summary>
        /// 空的 条目变更记录
        /// </summary>
        /// <returns></returns>
        public ActionResult EmptyEntryChangeRecord()
        {
            return View();
        }

        /// <summary>
        /// 条目变更tab
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
            CommonService.Model.MonitorManager.M_Entry_Change Conditon = new CommonService.Model.MonitorManager.M_Entry_Change();
            #region  业务查询条件
            if (!String.IsNullOrEmpty(form["M_Case_name"]))
            {//案件名称查询条件
                Conditon.M_Case_name = form["M_Case_name"].Trim();
            }
            if (!String.IsNullOrEmpty(form["M_Case_number"]))
            {//案件编码查询条件
                Conditon.M_Case_number = form["M_Case_number"].Trim();
            }
            if (!String.IsNullOrEmpty(form["M_Entry_Change_proposer"]))
            {//变更申请人
                Conditon.M_Entry_Change_proposer = form["M_Entry_Change_proposer"].Trim();
            }
            if ((!string.IsNullOrEmpty(form["M_Entry_Change_approvalDuration"])) && (!string.IsNullOrEmpty(form["M_Entry_Change_approvalDuration2"])))
            {//变更申请时长

                int a = 0;
                if ((!int.TryParse(form["M_Entry_Change_approvalDuration"].ToString().Trim(), out a)) || (!int.TryParse(form["M_Entry_Change_approvalDuration2"].ToString().Trim(), out a)))
                {
                    Conditon.M_Entry_Change_approvalDuration = null;
                    Conditon.M_Entry_Change_approvalDuration2 = null;
                }
                else
                {
                    Conditon.M_Entry_Change_approvalDuration = int.Parse(form["M_Entry_Change_approvalDuration"]);
                    Conditon.M_Entry_Change_approvalDuration2 = int.Parse(form["M_Entry_Change_approvalDuration2"]);
                }
              
            }
            if (!String.IsNullOrEmpty(form["M_Entry_Change_approvalPerson"]))
            {//变更审批人
                Conditon.M_Entry_Change_approvalPerson = form["M_Entry_Change_approvalPerson"].Trim();
            }
            if (!String.IsNullOrEmpty(form["M_Entry_Change_IsThrough"]) && form["M_Entry_Change_IsThrough"]!="请选择")
            {//变更情况
                Conditon.M_Entry_Change_IsThrough = Convert.ToInt32(form["M_Entry_Change_IsThrough"].Trim());
            }
            #endregion
           
            //查询模型传递到前端视图中
            ViewBag.Conditon = Conditon;

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
            this.TotalRecordCount = _entry_ChangeWCF.GetRecordCount(Conditon, "M_Entry_Change_IsThrough Asc,M_Entry_Change_id desc", UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, postCode, orgCode);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取数据信息
            List<CommonService.Model.MonitorManager.M_Entry_Change> entry_changes = _entry_ChangeWCF.GetListByPage(Conditon,
                "M_Entry_Change_IsThrough Asc,M_Entry_Change_id desc", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize, UIContext.Current.IsPreSetManager,
                UIContext.Current.UserCode, postCode, orgCode, "(select count(*) from B_CaseMaintain where T.B_Case_code=B_CaseMaintain.B_Case_code)>0");

            #region 权限
            this.DistributedInitButtonsPower(orgCode, postCode);
            this.DistributedInitLogin(orgCode, postCode, postGroupCode);
            #endregion

            return View(entry_changes);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.MonitorManager.M_Entry_Change entryChange)
        {
            string btn = form["CheckType"];
            //服务方法调用
            int entryChangeId = 0;

            if (btn!=null)
            {//修改
                if(btn=="1")
                {
                    entryChange.M_Entry_Change_IsThrough = Convert.ToInt32(EntryChangeIsThroughlEnum.通过);
                    bool isUpdateSuccess = _entry_ChangeWCF.Update(entryChange);
                    if (isUpdateSuccess)
                    {
                        entryChangeId = entryChange.M_Entry_Change_id;
                    }
                }else
                {
                    entryChange.M_Entry_Change_IsThrough = Convert.ToInt32(EntryChangeIsThroughlEnum.未通过);
                    bool isUpdateSuccess = _entry_ChangeWCF.Update(entryChange);
                    if (isUpdateSuccess)
                    {
                        entryChangeId = entryChange.M_Entry_Change_id;
                    }
                }
            }
            else
            {//添加
                entryChangeId = _entry_ChangeWCF.Add(entryChange);
            }

            if (entryChangeId > 0)
            {
                //保存成功提示固定写法
                return Json(TipHelper.JsonData("保存条目变更信息成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存条目变更信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //案件类型参数集合
            List<CommonService.Model.C_Parameters> Case_type = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.案件类型));
            ViewBag.Case_type = Case_type;
            //变更情况参数集合
            List<CommonService.Model.C_Parameters> Change_isThrough = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(EntryChangelEnum.变更情况));
            ViewBag.Change_isThrough = Change_isThrough;
            //办案状态参数集合
            List<CommonService.Model.C_Parameters> handlingState = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(EntrylEnum.监控状态));
            ViewBag.handlingState = handlingState;
            //预警情况参数集合
            List<CommonService.Model.C_Parameters> warningSituation = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(EntrylEnum.预警情况));
            ViewBag.warningSituation = warningSituation;
        }
	}
}