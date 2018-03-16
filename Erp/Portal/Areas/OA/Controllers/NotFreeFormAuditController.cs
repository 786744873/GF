using CommonService.Common;
using Maticsoft.Common;
using Microsoft.AspNet.SignalR;
using Portal.Controllers;
using Portal.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.OA.Controllers
{
    /// <summary>
    /// 非自由流程表单审核Control
    /// </summary>
    public class NotFreeFormAuditController : BaseController
    {
        private readonly ICommonService.OA.IO_Form _oFormWCF;
        private readonly ICommonService.OA.IO_Form_AuditFlow _oformAuditFlowWCF;
        private readonly ICommonService.OA.IO_Form_AuditPerson _oformAuditPersonWCF;
        private readonly ICommonService.IC_Messages _messageWCF;

        public NotFreeFormAuditController()
        {
            //服务初始化
            _oFormWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Form>("oFormWCF");
            _oformAuditFlowWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Form_AuditFlow>("oForm_AuditFlowWCF");
            _oformAuditPersonWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Form_AuditPerson>("oForm_AuditPersonWCF");
            _messageWCF = ServiceProxyFactory.Create<ICommonService.IC_Messages>("MessagesWCF");
        }

        //
        // GET: /OA/NotFreeFormAudit/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 非自由流程表单审核布局Action
        /// </summary>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <returns></returns>
        public PartialViewResult NotFreeFlowAudit(string oFormCode)
        {
            ViewBag.OFormCode = oFormCode;
            CommonService.Model.OA.O_Form oForm = _oFormWCF.Get(new Guid(oFormCode));
            ViewBag.O_Form_applyPerson_name = oForm.O_Form_applyPerson_name;
            ViewBag.ApplyStatus = oForm.O_Form_applyStatus.Value;
            //表单审批流程集合
            List<CommonService.Model.OA.O_Form_AuditFlow> FormAuditFlows = _oformAuditFlowWCF.GetFormAuditFlowsByFormCode(new Guid(oFormCode));
            //表单审批人集合
            List<CommonService.Model.OA.O_Form_AuditPerson> FormAuditPersons = _oformAuditPersonWCF.GetFormAuditPersonsByFormCode(new Guid(oFormCode));

            #region 整合表单审批流程和审批人
            foreach (CommonService.Model.OA.O_Form_AuditFlow formAuditFlow in FormAuditFlows)
            {
                formAuditFlow.O_Form_AuditFlow_AuditPersons = FormAuditPersons.FindAll(p => p.O_Form_AuditPerson_formAuditFlow == formAuditFlow.O_Form_AuditFlow_code);
            }
            #endregion

            return PartialView("NotFreeFlowAuditPartial", FormAuditFlows);
        }

        /// <summary>
        /// 通过审核
        /// </summary>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <param name="formAuditFlowCode">表单审批流程Guid</param>
        /// <param name="notShowFormAuditFlowCodes">不满足规则的表单审批流程Guid串</param>
        /// <returns></returns>
        public ActionResult PassCheck(string oFormCode, string formAuditFlowCode, string notShowFormAuditFlowCodes)
        {
            ViewBag.OFormCode = oFormCode;
            ViewBag.FormAuditFlowCode = formAuditFlowCode;
            ViewBag.NotShowFormAuditFlowCodes = notShowFormAuditFlowCodes;
            return View();
        }

        /// <summary>
        /// 提交通过
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SubmitPassCheck(FormCollection form)
        {
            string oFormCode = form["oFormCode"];
            string formAuditFlowCode = form["formAuditFlowCode"];
            string auditContent = form["auditContent"];
            string notShowFormAuditFlowCodes = form["notShowFormAuditFlowCodes"];
            int isSuccess = _oformAuditFlowWCF.NotFreeFlowPassCheck(new Guid(oFormCode), new Guid(formAuditFlowCode), Context.UIContext.Current.UserCode.Value, auditContent, notShowFormAuditFlowCodes);

            if (isSuccess > 0)
            {
                //根据isSuccess的值判断审核通过的情况（当前流程通过，还是表单通过，或者只是自己的审核通过），推送给不同人的消息
                CommonService.Model.OA.O_Form_AuditFlow FAmodel = _oformAuditFlowWCF.Get(new Guid(formAuditFlowCode));//得到此流程实体  
                if (isSuccess == 1)
                { 
                    #region   发送消息给表单申请人，表单通过了
                    //先向消息表中添加消息
                    CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                    msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.OA表单消息);
                    msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.OA表单提交);
                    msgModel.C_Messages_link = new Guid(formAuditFlowCode);
                    msgModel.C_Messages_createTime = DateTime.Now;
                    msgModel.C_Messages_person = FAmodel.O_Form_applyPerson;
                    msgModel.C_Messages_isRead = 0;
                    msgModel.C_Messages_isValidate = 1;
                    _messageWCF.Add(msgModel);
                    //添加消息后  发送给审核人信息
                    CommonService.Model.OA.O_Form_AuditFlow FAFModel = _oformAuditFlowWCF.GetModelByAuditFlowcode(new Guid(formAuditFlowCode), 2);//表单已审批流程信息

                    var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                    var touser = ChatHub.userlist.FirstOrDefault(x => x.userCode == FAFModel.O_Form_applyPerson.ToString());//查询申请人是否在线
                    if (touser != null)
                    {
                        JsonHelper jh = new JsonHelper();
                        context.Clients.Client(touser.ConnectionId).sendFormSubMsg(jh.EntityToJson(FAFModel));//接收消息人的数据集合
                    }

                    #endregion
                }
                else if (isSuccess == 2)
                { //发送消息给下一流程的审核人,需要审核
                    #region  当前流程审核通过  给下一级流程审核人发送消息
                    int orde = Convert.ToInt32(FAmodel.O_Form_AuditFlow_flowSet_order) + 1;
                    List<CommonService.Model.OA.O_Form_AuditFlow> FAFModelList = _oformAuditFlowWCF.GetModelByAuditFlowcodeAndformCodeAndOrder( 1, new Guid(oFormCode), orde);
                    foreach (var item in FAFModelList)
                    {
                        //先向消息表中添加消息
                        CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                        msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.OA表单消息);
                        msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.OA表单提交);
                        msgModel.C_Messages_link = item.O_Form_AuditFlow_code;
                        msgModel.C_Messages_createTime = DateTime.Now;
                        msgModel.C_Messages_person = item.O_Form_AuditPerson_auditPerson;
                        msgModel.C_Messages_isRead = 0;
                        msgModel.C_Messages_isValidate = 1;
                        _messageWCF.Add(msgModel);
                        //添加消息后  发送给审核人信息
                        CommonService.Model.OA.O_Form_AuditFlow FAFModel = _oformAuditFlowWCF.GetModelByAuditFlowcode(new Guid(item.O_Form_AuditFlow_code.ToString()), 1);//表单未审核审批流程信息
                        var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                        var touser = ChatHub.userlist.FirstOrDefault(x => x.userCode == item.O_Form_AuditPerson_auditPerson.ToString());//查询审核人是否在线
                        if (touser != null)
                        {
                            JsonHelper jh = new JsonHelper();
                            context.Clients.Client(touser.ConnectionId).sendFormSubMsg(jh.EntityToJson(FAFModel));//接收消息人的数据集合
                        }
                    }
                    #endregion
                }
                return Json(TipHelper.JsonData("通过成功！", "ajaxify_trigger|baseLargeModal|/oa/form/layoutroottabs?oFormCode=" + oFormCode, IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshThisPage));
            }
            else
            {
                return Json(TipHelper.JsonData("通过失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 驳回审核
        /// </summary>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <param name="formAuditFlowCode">表单审批流程Guid</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult RejectCheck(string oFormCode, string formAuditFlowCode)
        {
            ViewBag.OFormCode = oFormCode;
            ViewBag.FormAuditFlowCode = formAuditFlowCode;
            return View();
        }

        /// <summary>
        /// 提交驳回
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SubmitRejectCheck(FormCollection form)
        {
            string oFormCode = form["oFormCode"];
            string formAuditFlowCode = form["formAuditFlowCode"];
            string auditContent = form["auditContent"];
            bool isSuccess = _oformAuditFlowWCF.NotFreeFlowRejectCheck(new Guid(oFormCode), new Guid(formAuditFlowCode), Context.UIContext.Current.UserCode.Value, auditContent);

            if (isSuccess)
            {
                #region   驳回后给申请人发送消息
                CommonService.Model.OA.O_Form_AuditFlow FAmodel = _oformAuditFlowWCF.Get(new Guid(formAuditFlowCode));//得到此流程实体  
                //先向消息表中添加消息
                CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.OA表单消息);
                msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.OA表单提交);
                msgModel.C_Messages_link = new Guid(formAuditFlowCode);
                msgModel.C_Messages_createTime = DateTime.Now;
                msgModel.C_Messages_person = FAmodel.O_Form_applyPerson;
                msgModel.C_Messages_isRead = 0;
                msgModel.C_Messages_isValidate = 1;
                _messageWCF.Add(msgModel);
                //添加消息后  发送给审核人信息
                CommonService.Model.OA.O_Form_AuditFlow FAFModel = _oformAuditFlowWCF.GetModelByAuditFlowcode(new Guid(formAuditFlowCode), 2);//表单已审批流程信息

                var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                var touser = ChatHub.userlist.FirstOrDefault(x => x.userCode == FAFModel.O_Form_applyPerson.ToString());//查询申请人是否在线
                if (touser != null)
                {
                    JsonHelper jh = new JsonHelper();
                    context.Clients.Client(touser.ConnectionId).sendFormSubMsg(jh.EntityToJson(FAFModel));//接收消息人的数据集合
                }
                #endregion
                return Json(TipHelper.JsonData("驳回成功！", "ajaxify_trigger|baseLargeModal|/oa/form/layoutroottabs?oFormCode=" + oFormCode, IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshThisPage));
            }
            else
            {
                return Json(TipHelper.JsonData("驳回失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

    }
}