using CommonService.Common;
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
    ///条目表控制器
    ///作者：崔慧栋
    ///日期：2015/06/09
    /// </summary>
    public class EntryController : BaseController
    {
        private readonly ICommonService.MonitorManager.IM_Entry _entryWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        public EntryController()
        {
            #region 服务初始化
            _entryWCF = ServiceProxyFactory.Create<ICommonService.MonitorManager.IM_Entry>("EntryWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            #endregion
        }
        //
        // GET: /MonitorManager/Entry/
        public override ActionResult Index()
        {
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
            //创建初始化条目实体
            CommonService.Model.MonitorManager.M_Entry entry = new CommonService.Model.MonitorManager.M_Entry();
            entry.M_Entry_code = Guid.NewGuid();
            entry.M_Entry_isDelete = 0;
            entry.M_Entry_creator = Context.UIContext.Current.UserCode;
            entry.M_Entry_createTime = DateTime.Now;
            
            return View(entry);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int entryId)
        {
            InitializationPageParameter();
            CommonService.Model.MonitorManager.M_Entry entry = _entryWCF.GetModel(entryId);
            entry.M_Entry_scodes = entry.M_Entry_sFlow + "," + entry.M_Entry_sForm + "," + entry.M_Entry_sTime;
            entry.M_Entry_ecodes = entry.M_Entry_eFlow + "," + entry.M_Entry_eForm + "," + entry.M_Entry_eTime;
            return View("Create", entry);
        }

        /// <summary>
        /// 流程布局结构Action
        /// </summary>
        /// <param name="fkCode"></param>
        /// <returns></returns>
        public ActionResult DefaultLayout(string type)
        {
            ViewBag.type = type;
            return View();
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //条目查询模型
            CommonService.Model.MonitorManager.M_Entry Conditon = new CommonService.Model.MonitorManager.M_Entry();

            if (!String.IsNullOrEmpty(form["M_Entry_name"]))
            {//条目名称查询条件
                Conditon.M_Entry_name = form["M_Entry_name"].Trim();
            }
            //条目查询模型传递到前端视图中
            ViewBag.Conditon = Conditon;

            #endregion

            //获取条目总记录数
            this.TotalRecordCount = _entryWCF.GetRecordCount(Conditon);

            //初始化页面信息(固定写法)
            this.InitializationPageInfo(form, page.Value);

            //获取条目数据信息
            List<CommonService.Model.MonitorManager.M_Entry> entrys = _entryWCF.GetListByPage(Conditon,
                "", (this.ThisPageIndex - 1) * this.PageSize + 1, this.ThisPageIndex * this.PageSize);

            #region 权限
            this.InitializationButtonsPower();
            #endregion

            return View(entrys);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form,CommonService.Model.MonitorManager.M_Entry entry)
        {
            if (entry.M_Entry_Duration == null)
            {
                entry.M_Entry_Duration = 0;
            }
            if (entry.M_Entry_warningDuration == null)
            {
                entry.M_Entry_warningDuration = 0;
            }

            #region 字段赋值
            entry.M_Entry_sname = form["sTimelookup.Name"];
            entry.M_Entry_ename = form["eTimelookup.Name"];
            if (String.IsNullOrEmpty(form["courtlookup.Code"]))
            {
                entry.M_Entry_court = null;
            }
            else
            {
                entry.M_Entry_court = form["courtlookup.Code"];
            }            
            string[] scodes = form["sTimelookup.Code"].Split(',');
            string[] ecodes = form["eTimelookup.Code"].Split(',');
            entry.M_Entry_sFlow = new Guid(scodes[0]);
            if (scodes [1]!= "")
            {
                entry.M_Entry_sForm=new Guid(scodes[1]);
            }
            entry.M_Entry_sTime = new Guid(scodes[2]);
            entry.M_Entry_eFlow = new Guid(ecodes[0]);
            if (ecodes [1]!= "")
            {
                entry.M_Entry_eForm =new Guid( ecodes[1]);
            }
            entry.M_Entry_eTime = new Guid(ecodes[2]);
            #endregion

            //服务方法调用
            bool isUpdateSuccess = false;

            if (entry.M_Entry_id > 0)
            {//修改
                isUpdateSuccess = _entryWCF.Update(entry);
            }
            else
            {//添加
                entry.M_Entry_createTime = DateTime.Now;
                isUpdateSuccess = _entryWCF.Add(entry);
            }

            if (isUpdateSuccess)
            {
                #region 保存成功后，根据表单操作类型执行不同的业务逻辑
                string formOperateType = form["formOperateType"].ToString().ToLower();
                if (formOperateType == "onlysave")
                {
                    return Json(TipHelper.JsonData("保存条目信息成功", ""));//仅仅保存
                }
                else if (formOperateType == "saveandnewnext")
                {
                    return Json(TipHelper.JsonData("保存条目信息成功", "/MonitorManager/Entry/create", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ParentPage, OperateTypeAfterTip.ThisPageGoAnotherPage));//保存并且新增下一个
                }
                else
                {
                    return Json(TipHelper.JsonData("保存条目信息成功", ""));//默认仅仅保存
                }
                #endregion
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("保存条目信息失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int entryId)
        {
            bool isSuccess = _entryWCF.Delete(entryId);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除条目信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除条目信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 条目详细
        /// </summary>
        /// <param name="M_Entry_Statistics_code"></param>
        /// <returns></returns>
        public ActionResult PKentryDetails(string M_Entry_code)
        {
            CommonService.Model.MonitorManager.M_Entry entry = _entryWCF.GetModelByCode(new Guid(M_Entry_code));

            return View(entry);
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //预警类型参数集合
            List<CommonService.Model.C_Parameters> warningType = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(EntrylEnum.预警类型));
            ViewBag.warningType = warningType;
            //进程类型参数集合
            List<CommonService.Model.C_Parameters> processType = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(EntrylEnum.进程类型));
            ViewBag.processType = processType;
        }
	}
}