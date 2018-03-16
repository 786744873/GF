using CommonService.Common;
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
    /// <summary>
    /// 流程预设控制器
    /// </summary>
    public class FlowSetController : BaseController
    {
        private readonly ICommonService.OA.IO_FlowSet _flowsetWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.OA.IO_FlowSet_AuditPerson _oFlowSet_AuditPersonWCF;
        public FlowSetController()
        {
            #region 服务初始化
            _flowsetWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_FlowSet>("oFlowSetWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _oFlowSet_AuditPersonWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_FlowSet_AuditPerson>("oFlowSet_AuditPersonWCF");
            #endregion
        }

        //
        // GET: /OA/FlowSet/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 默认列表Action(菜单超链接打开)
        /// </summary>
        /// <returns></returns>
        public ActionResult List(string flowCode)
        {
            ViewBag.flowCode = flowCode;
            return View();
        }

        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult AjaxList(jQueryDataTableParamModel param, string flowCode)
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
                 c.O_FlowSet_order.ToString(),
                 c.O_FlowSet_auditTypename,
                 c.O_Flowset_personNames_Lists,
                 c.O_FlowSet_rule,
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
        /// 添加流程预设
        /// </summary>
        /// <returns></returns>
        public ActionResult Create(string O_FlowSet_flow)
        {
            ViewBag.flowCode = O_FlowSet_flow;
            Guid flowsetcode = new Guid(O_FlowSet_flow);//所属流程Guid,
            CommonService.Model.OA.O_FlowSet model = new CommonService.Model.OA.O_FlowSet();
            model.O_FlowSet_flow = flowsetcode;
            model.O_FlowSet_isDelete = false;
            model.O_FlowSet_creator = Context.UIContext.Current.UserCode;
            model.O_FlowSet_code = Guid.NewGuid();
            InitializationPageParameter();
            return View(model);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="flowSetCode"></param>
        /// <returns></returns>
        public ActionResult Edit(string flowSetCode)
        {
            CommonService.Model.OA.O_FlowSet model = _flowsetWCF.Get(new Guid(flowSetCode));
            List<CommonService.Model.OA.O_FlowSet_AuditPerson> userlist = _oFlowSet_AuditPersonWCF.GetListByflowSetCode(new Guid(flowSetCode));
            ViewBag.flowCode = model.O_FlowSet_flow;
            string user_list = "";
            foreach (var item in userlist)
            {
                user_list = user_list + item.O_FlowSet_auditPerson_auditPerson + ",";
            }
            model.O_Flowset_personNames_Lists = user_list;
            InitializationPageParameter();
            return View("Create", model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="flowSetCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string flowSetCode)
        {
            CommonService.Model.OA.O_FlowSet model = _flowsetWCF.Get(new Guid(flowSetCode));

            if (_flowsetWCF.UpdateFlowSetAndAuditPerson(model, "", 3))
            {
                return Json(TipHelper.JsonData("删除预设信息成功！", "flowSetList", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
            }
            else
            {
                return Json(TipHelper.JsonData("删除预设信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //审核类型参数集合
            List<CommonService.Model.C_Parameters> lists = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(FlowSetAuditTypeEnum.多人审核类型));
            ViewBag.lists = lists;
            //人员
            List<CommonService.Model.SysManager.C_Userinfo> userLists = _userinfoWCF.GetUsersByOrgAndPost(null, null, string.Empty);
            string userHtml = "";
            foreach (var user in userLists)
            {
                userHtml += "<option value=" + user.C_Userinfo_code + ">" + user.C_Userinfo_Organization_name + ">" + user.C_Userinfo_post_name + ">" + user.C_Userinfo_name + "</option>";
            }
            ViewBag.userhtml = userHtml;
        }
        /// <summary>
        /// 新增预设
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.OA.O_FlowSet model)
        {
            bool flag = true;
            //审核人list
            string userLists = form["hd_receivers"];
            model.O_FlowSet_createTime = DateTime.Now;
            //增加或者修改流程预设
            if (model.O_FlowSet_id > 0)
            {//修改
                if (!_flowsetWCF.UpdateFlowSetAndAuditPerson(model, userLists, 2))
                    flag = false;
            }
            else
            { //新增
                if (!_flowsetWCF.UpdateFlowSetAndAuditPerson(model, userLists, 1))
                    flag = false;
            }
            if (flag)
            {
                return Json(TipHelper.JsonData("保存预设信息成功！", "ajaxify_trigger|/oa/flowset/List?flowCode="+model.O_FlowSet_flow+"", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageGoAnotherPage));
            }
            else
            {
                //表单提交失败固定写法
                return Json(TipHelper.JsonData("保存预设信息失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }

        }
    }
}