using Maticsoft.Common;
using Portal.Controllers;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.OA.Controllers
{
    public class FlowController : BaseController
    {
        private readonly ICommonService.OA.IO_Flow _flowWCF;
        private readonly ICommonService.OA.IO_FlowSet _flowsetWCF;
        //
        // GET: /OA/Flow/
        public FlowController()
        {
            #region 服务初始化
            _flowWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Flow>("oFlowWCF");
            _flowsetWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_FlowSet>("oFlowSetWCF");
            #endregion
        }
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            CommonService.Model.OA.O_Flow model = new CommonService.Model.OA.O_Flow();
            model.O_Flow_code = Guid.NewGuid();
            model.O_Flow_creator = Context.UIContext.Current.UserCode;
            model.O_Flow_isDelete =false;
            return View(model);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string flowCode)
        {
            CommonService.Model.OA.O_Flow flow = _flowWCF.GetModel(new Guid(flowCode));
            return View("Create",flow);
        }
        /// <summary>
        /// 流程列表
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            return View();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="flowCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string flowCode)
        {
            bool isSuccess = _flowWCF.Delete(new Guid(flowCode));
            if (isSuccess)
            {//成功(这里可以给一个table的id，目的是操作table后，刷新table)
                return Json(TipHelper.JsonData("删除流程信息成功！", "flowList", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除流程信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult AjaxList(jQueryDataTableParamModel param)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //流程查询模型
            CommonService.Model.OA.O_Flow flowConditon = new CommonService.Model.OA.O_Flow();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_title");
                if (title != null && title != "")
                {
                    flowConditon.O_Flow_name = title;
                }
                #endregion
            }

            #endregion

            #region 分页数据处理

            //总记录数
            this.TotalRecordCount = _flowWCF.GetRecordCount(flowConditon);
            //数据信息
            List<CommonService.Model.OA.O_Flow> flows = _flowWCF.GetListByPage(flowConditon,
                "O_Flow_createTime Desc", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            //转化数据格式
            var result = from c in flows
                         select new[] { 
                 c.O_Flow_code.Value.ToString(), 
                 c.O_Flow_name, 
                 c.O_Flow_isFree?"是":"否",
                 c.O_Flow_createTime.Value.ToString("yyyy-MM-dd HH:mm:ss")
            };
            //返回json数据
            return Json(
                new
                {
                    sEcho = param.sEcho,
                    iTotalRecords = this.TotalRecordCount,
                    iTotalDisplayRecords = this.TotalRecordCount,
                    aaData = result
                }
            );

            #endregion
        }
        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection form, CommonService.Model.OA.O_Flow flow)
        {
            //服务方法调用
            int flowId = 0;
            if (flow.O_Flow_id > 0)
            {//修改
                bool isUpdateSuccess = _flowWCF.Update(flow);
                if (isUpdateSuccess)
                {
                    flowId = flow.O_Flow_id;
                }
            }
            else
            {//添加
                DateTime now = DateTime.Now;
                flow.O_Flow_createTime = DateTime.Now;
                flowId = _flowWCF.Add(flow);
            }
            if (flowId>0)
            {
                return Json(TipHelper.JsonData("保存流程信息成功！", "ajaxify_trigger|/oa/flow/List", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageGoAnotherPage));
            }
            else
            {
                //表单提交失败固定写法
                return Json(TipHelper.JsonData("保存流程信息失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// 流程预设
        /// </summary>
        /// <param name="flowCode"></param>
        /// <returns></returns>
        public ActionResult FlowSet(string flowCode)
        {
            ViewBag.flowCode = flowCode;
            return View();
        }
        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult FlowSetAjaxList(jQueryDataTableParamModel param, string flowCode)
        {
            CommonService.Model.OA.O_FlowSet flowSetConditon = new CommonService.Model.OA.O_FlowSet();
            flowSetConditon.O_FlowSet_flow = new Guid(flowCode);
            #region 分页数据处理

            //总记录数
            this.TotalRecordCount = _flowsetWCF.GetRecordCount(flowSetConditon);
            //数据信息
            List<CommonService.Model.OA.O_FlowSet> flowsets = _flowsetWCF.GetListByPage(flowSetConditon,
                "O_FlowSet_createTime Desc", 1, 100);
            //转化数据格式
            var result = from c in flowsets
                         select new[] { 
                 c.O_FlowSet_code.Value.ToString(), 
                 c.O_FlowSet_flow.Value.ToString(),
                 c.O_FlowSet_flow.Value.ToString(),
                 c.O_FlowSet_order.ToString(),
                 c.O_FlowSet_auditType.ToString(),
                 c.O_FlowSet_auditType.ToString(),
                 c.O_FlowSet_rule,
                 "编辑",
                 "删除"
            };
            //返回json数据
            return Json(
                new
                {
                    sEcho = param.sEcho,
                    iTotalRecords = this.TotalRecordCount,
                    iTotalDisplayRecords = this.TotalRecordCount,
                    aaData = result
                }
            );

            #endregion
        }
        public ActionResult FlowSetSave(string flowsetcode, string O_FlowSet_order, string O_FlowSet_auditType, string O_FlowSet_rule)
        {

            return View();
        }
	}
}