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
    /// 自由流程表单审核Control
    /// </summary>
    public class FreeFormAuditController : BaseController
    {
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.OA.IO_Form _oFormWCF;
        private readonly ICommonService.OA.IO_Form_AuditFlow _oformAuditFlowWCF;
        private readonly ICommonService.OA.IO_Form_AuditPerson _oformAuditPersonWCF;
        private readonly ICommonService.IC_Messages _messageWCF;
        //
        // GET: /OA/FreeFormAudit/
        public FreeFormAuditController()
        {
            #region 服务初始化
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _oFormWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Form>("oFormWCF");
            _oformAuditFlowWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Form_AuditFlow>("oForm_AuditFlowWCF");
            _oformAuditPersonWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Form_AuditPerson>("oForm_AuditPersonWCF");
            _messageWCF = ServiceProxyFactory.Create<ICommonService.IC_Messages>("MessagesWCF");
            #endregion
        }
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建提交表单审核Action
        /// </summary>
        /// <param name="oFormCode">表单Guid</param>
        /// <returns></returns>
        public ActionResult CreateSubmit(string oFormCode)
        {
            CommonService.Model.OA.O_Form model = new CommonService.Model.OA.O_Form();
            model.O_Form_code = new Guid(oFormCode);
            InitializationPageParameter();
            return View("CreateSubmitView", model);
        }

        /// <summary>
        /// 自由流程表单审核布局Action
        /// </summary>
        /// <param name="oFormCode">协同办公表单Guid</param>
        /// <returns></returns>
        public PartialViewResult FreeFlowAudit(string oFormCode)
        {
            CommonService.Model.OA.O_Form oForm = _oFormWCF.Get(new Guid(oFormCode));
            ViewBag.O_Form_applyPerson_name = oForm.O_Form_applyPerson_name;
            List<CommonService.Model.OA.O_Form_AuditFlow> FAlists = _oformAuditFlowWCF.GetListByFormCode(new Guid(oFormCode));//表单审批流程和审核人数据集合
            ViewBag.FAlists = FAlists;
            ViewBag.LoginUser = Context.UIContext.Current.UserCode;//当前登录人
            return PartialView("FreeFlowAuditPartial");
        }
        /// <summary>
        /// 创建下一流程
        /// </summary>
        /// <param name="audit_Code">审批流程guid</param>
        /// <returns></returns>
        public ActionResult FreeNextFlow(string audit_Code)
        {
            CommonService.Model.OA.O_Form_AuditFlow FAmodel = _oformAuditFlowWCF.Get(new Guid(audit_Code));//得到此流程实体
            InitializationPageParameter();
            return View(FAmodel);
        }
        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //人员列表
            List<CommonService.Model.SysManager.C_Userinfo> userLists = _userinfoWCF.GetUsersByOrgAndPost(null, null, string.Empty);
            string userHtml = "";
            foreach (var user in userLists)
            {
                userHtml += "<option value=" + user.C_Userinfo_code + ">" + user.C_Userinfo_Organization_name + "=>" + user.C_Userinfo_name + "</option>";
            }
            ViewBag.userhtml = userHtml;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.OA.O_Form model)
        {
            bool flag = true;
            //审核人
            string user = form["hd_receivers"];
            Guid O_Form_AuditFlow_code = Guid.NewGuid();
            CommonService.Model.OA.O_Form formModel = _oFormWCF.Get(new Guid(model.O_Form_code.ToString()));
            formModel.O_Form_applyPerson = Context.UIContext.Current.UserCode;
            formModel.O_Form_applyTime = DateTime.Now;
            formModel.O_Form_applyStatus = Convert.ToInt32(FormApplyTypeEnum.已提交);
            if (!_oFormWCF.Update(formModel))
                flag = false;
            int maxOrdr = _oformAuditFlowWCF.GetMaxOrderModel(new Guid(model.O_Form_code.ToString()));
            CommonService.Model.OA.O_Form_AuditFlow FAmodel = new CommonService.Model.OA.O_Form_AuditFlow();
            FAmodel.O_Form_AuditFlow_code = O_Form_AuditFlow_code;
            FAmodel.O_Form_AuditFlow_o_form = new Guid(model.O_Form_code.ToString());
            if (maxOrdr == 1)
            {
                FAmodel.O_Form_AuditFlow_flowSet_order = 1;
            }
            else
            {
                FAmodel.O_Form_AuditFlow_flowSet_order = maxOrdr + 1;
            }
            FAmodel.O_Form_AuditFlow_flowSet_auditType = Convert.ToInt32(AuditTypeEnum.并且);
            FAmodel.O_Form_AuditFlow_auditStatus = Convert.ToInt32(FormAuditTypeEnum.未开始);
            FAmodel.O_Form_AuditFlow_isDelete = false;
            FAmodel.O_Form_AuditFlow_creator = Context.UIContext.Current.UserCode;
            FAmodel.O_Form_AuditFlow_createTime = DateTime.Now;
            if (!(_oformAuditFlowWCF.Add(FAmodel) > 0))
                flag = false;
            CommonService.Model.OA.O_Form_AuditPerson FAPmodel = new CommonService.Model.OA.O_Form_AuditPerson();
            FAPmodel.O_Form_AuditPerson_code = Guid.NewGuid();
            FAPmodel.O_Form_AuditPerson_auditPerson = new Guid(user);
            FAPmodel.O_Form_AuditPerson_status = Convert.ToInt32(FormApprovalTypeEnum.未审核);
            FAPmodel.O_Form_AuditPerson_formAuditFlow = O_Form_AuditFlow_code;
            FAPmodel.O_Form_AuditPerson_isDelete = false;
            FAPmodel.O_Form_AuditPerson_creator = Context.UIContext.Current.UserCode;
            FAPmodel.O_Form_AuditPerson_createTime = DateTime.Now;
            if (!(_oformAuditPersonWCF.Add(FAPmodel) > 0))
                flag = false;
            if (flag)
            {
                #region   表单提交成功后  给审核人推送消息
                //先向消息表中添加消息
                CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.OA表单消息);
                msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.OA表单提交);
                msgModel.C_Messages_link = FAPmodel.O_Form_AuditPerson_formAuditFlow;
                msgModel.C_Messages_createTime = DateTime.Now;
                msgModel.C_Messages_person = FAPmodel.O_Form_AuditPerson_auditPerson;
                msgModel.C_Messages_isRead = 0;
                msgModel.C_Messages_isValidate = 1;
                _messageWCF.Add(msgModel);
                //添加消息后  发送给审核人信息
                CommonService.Model.OA.O_Form_AuditFlow FAFModel = _oformAuditFlowWCF.GetModelByAuditFlowcode(new Guid(FAPmodel.O_Form_AuditPerson_formAuditFlow.ToString()), 1);//表单未审核审批流程信息
                var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                var touser = ChatHub.userlist.FirstOrDefault(x => x.userCode == user);//查询审核人是否在线
                if (touser != null)
                {
                    JsonHelper jh = new JsonHelper();
                    context.Clients.Client(touser.ConnectionId).sendFormSubMsg(jh.EntityToJson(FAFModel));//接收消息人的数据集合
                }

                #endregion
                return Json(TipHelper.JsonData("提交表单信息成功！", "ajaxify_trigger|baseLargeModal|/oa/form/layoutroottabs?oFormCode=" + model.O_Form_code.Value.ToString(), IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshThisPage));
            }
            else
            {
                return Json(TipHelper.JsonData("提交表单信息失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// 保存下一流程
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveNextFlow(FormCollection form, CommonService.Model.OA.O_Form_AuditFlow model)
        {
            #region   修改完善的流程信息
            bool flag = true;
            model.O_Form_AuditFlow_auditStatus = Convert.ToInt32(FormAuditTypeEnum.已通过);
            model.O_Form_AuditFlow_auditTime = DateTime.Now;
            if (!_oformAuditFlowWCF.Update(model))
                flag = false;
            CommonService.Model.OA.O_Form_AuditPerson FAoldModel = _oformAuditPersonWCF.GetModelByFlowCode(new Guid(model.O_Form_AuditFlow_code.ToString()));
            FAoldModel.O_Form_AuditPerson_content = model.O_Form_AuditPerson_content;
            FAoldModel.O_Form_AuditPerson_auditTime = DateTime.Now;
            FAoldModel.O_Form_AuditPerson_status = Convert.ToInt32(FormApprovalTypeEnum.已通过);
            if (!_oformAuditPersonWCF.Update(FAoldModel))
                flag = false;
            #endregion
            #region  添加流程信息

            //审核人
            string user = form["hd_receivers"];
            Guid O_Form_AuditFlow_code = Guid.NewGuid();
            //CommonService.Model.OA.O_Form formModel = _oFormWCF.Get(new Guid(model.O_Form_AuditFlow_o_form.ToString()));
            //formModel.O_Form_applyPerson = Context.UIContext.Current.UserCode;
            //formModel.O_Form_applyTime = DateTime.Now;
            //formModel.O_Form_applyStatus = Convert.ToInt32(FormApplyTypeEnum.已提交);
            //if (!_oFormWCF.Update(formModel))
            //    flag = false;
            int maxOrdr = _oformAuditFlowWCF.GetMaxOrderModel(new Guid(model.O_Form_AuditFlow_o_form.ToString()));
            CommonService.Model.OA.O_Form_AuditFlow FAmodel = new CommonService.Model.OA.O_Form_AuditFlow();
            FAmodel.O_Form_AuditFlow_code = O_Form_AuditFlow_code;
            FAmodel.O_Form_AuditFlow_o_form = new Guid(model.O_Form_AuditFlow_o_form.ToString());
            FAmodel.O_Form_AuditFlow_flowSet_order = model.O_Form_AuditFlow_flowSet_order + 1;
            FAmodel.O_Form_AuditFlow_flowSet_auditType = Convert.ToInt32(AuditTypeEnum.并且);
            FAmodel.O_Form_AuditFlow_auditStatus = Convert.ToInt32(FormAuditTypeEnum.未开始);
            FAmodel.O_Form_AuditFlow_isDelete = false;
            FAmodel.O_Form_AuditFlow_creator = Context.UIContext.Current.UserCode;
            FAmodel.O_Form_AuditFlow_createTime = DateTime.Now;
            if (!(_oformAuditFlowWCF.Add(FAmodel) > 0))
                flag = false;
            CommonService.Model.OA.O_Form_AuditPerson FAPmodel = new CommonService.Model.OA.O_Form_AuditPerson();
            FAPmodel.O_Form_AuditPerson_code = Guid.NewGuid();
            FAPmodel.O_Form_AuditPerson_auditPerson = new Guid(user);
            FAPmodel.O_Form_AuditPerson_status = Convert.ToInt32(FormApprovalTypeEnum.未审核);
            FAPmodel.O_Form_AuditPerson_formAuditFlow = O_Form_AuditFlow_code;
            FAPmodel.O_Form_AuditPerson_isDelete = false;
            FAPmodel.O_Form_AuditPerson_creator = Context.UIContext.Current.UserCode;
            FAPmodel.O_Form_AuditPerson_createTime = DateTime.Now;
            if (!(_oformAuditPersonWCF.Add(FAPmodel) > 0))
                flag = false;
            if (flag)
            {
                #region   表单提交成功后  给下一级审核人推送消息
                //先向消息表中添加消息
                CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.OA表单消息);
                msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.OA表单提交);
                msgModel.C_Messages_link = FAPmodel.O_Form_AuditPerson_formAuditFlow;
                msgModel.C_Messages_createTime = DateTime.Now;
                msgModel.C_Messages_person = FAPmodel.O_Form_AuditPerson_auditPerson;
                msgModel.C_Messages_isRead = 0;
                msgModel.C_Messages_isValidate = 1;
                _messageWCF.Add(msgModel);
                //添加消息后  发送给审核人信息
                CommonService.Model.OA.O_Form_AuditFlow FAFModel = _oformAuditFlowWCF.GetModelByAuditFlowcode(new Guid(FAPmodel.O_Form_AuditPerson_formAuditFlow.ToString()), 1);//表单未审核审批流程信息
                var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                var touser = ChatHub.userlist.FirstOrDefault(x => x.userCode == user);//查询审核人是否在线
                if (touser != null)
                {
                    JsonHelper jh = new JsonHelper();
                    context.Clients.Client(touser.ConnectionId).sendFormSubMsg(jh.EntityToJson(FAFModel));//接收消息人的数据集合
                }

                #endregion
                return Json(TipHelper.JsonData("开启下一流程成功！", "ajaxify_trigger|baseLargeModal|/oa/form/layoutroottabs?oFormCode=" + model.O_Form_AuditFlow_o_form.Value.ToString(), IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshThisPage));
            }
            else
            {
                return Json(TipHelper.JsonData("开启下一流程失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }

            #endregion
        }
        /// <summary>
        /// 结束流程
        /// </summary>
        /// <param name="flowCode"></param>
        /// <returns></returns>
        public ActionResult EndFlow(string audit_Code, int type)
        {
            CommonService.Model.OA.O_Form_AuditFlow FAmodel = _oformAuditFlowWCF.Get(new Guid(audit_Code));//得到此流程实体  
            if (type == 1)
            {
                FAmodel.O_Form_Type = 1;
            }
            else
            {
                FAmodel.O_Form_Type = 2;
            }
            return View(FAmodel);
        }
        /// <summary>
        /// 结束表单和流程
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveEndFlow(FormCollection form, CommonService.Model.OA.O_Form_AuditFlow model)
        {
            #region   修改完善的流程信息
            bool flag = true;
            if (model.O_Form_Type == 1)//通过
            {
                //修改流程为通过
                model.O_Form_AuditFlow_auditStatus = Convert.ToInt32(FormAuditTypeEnum.已通过);
                model.O_Form_AuditFlow_auditTime = DateTime.Now;
                if (!_oformAuditFlowWCF.Update(model))
                    flag = false;
                //修改流程审核人为通过
                CommonService.Model.OA.O_Form_AuditPerson FAoldModel = _oformAuditPersonWCF.GetModelByFlowCode(new Guid(model.O_Form_AuditFlow_code.ToString()));
                FAoldModel.O_Form_AuditPerson_content = model.O_Form_AuditPerson_content;
                FAoldModel.O_Form_AuditPerson_auditTime = DateTime.Now;
                FAoldModel.O_Form_AuditPerson_status = Convert.ToInt32(FormApprovalTypeEnum.已通过);
                if (!_oformAuditPersonWCF.Update(FAoldModel))
                    flag = false;
                //修改表单为通过
                CommonService.Model.OA.O_Form Fmodel = _oFormWCF.Get(new Guid(model.O_Form_AuditFlow_o_form.ToString()));
                Fmodel.O_Form_applyStatus = Convert.ToInt32(FormApplyTypeEnum.已通过);
                if (!_oFormWCF.Update(Fmodel))
                    flag = false;
            }
            else//驳回
            {
                //修改流程为未通过
                model.O_Form_AuditFlow_auditStatus = Convert.ToInt32(FormAuditTypeEnum.未通过);
                model.O_Form_AuditFlow_auditTime = DateTime.Now;
                if (!_oformAuditFlowWCF.Update(model))
                    flag = false;
                //修改流程审核人为已驳回
                CommonService.Model.OA.O_Form_AuditPerson FAoldModel = _oformAuditPersonWCF.GetModelByFlowCode(new Guid(model.O_Form_AuditFlow_code.ToString()));
                FAoldModel.O_Form_AuditPerson_content = model.O_Form_AuditPerson_content;
                FAoldModel.O_Form_AuditPerson_auditTime = DateTime.Now;
                FAoldModel.O_Form_AuditPerson_status = Convert.ToInt32(FormApprovalTypeEnum.已驳回);
                if (!_oformAuditPersonWCF.Update(FAoldModel))
                    flag = false;
                //修改表单为未通过
                CommonService.Model.OA.O_Form Fmodel = _oFormWCF.Get(new Guid(model.O_Form_AuditFlow_o_form.ToString()));
                Fmodel.O_Form_applyStatus = Convert.ToInt32(FormApplyTypeEnum.未通过);
                if (!_oFormWCF.Update(Fmodel))
                    flag = false;
            }

            if (flag)
            {
                #region   审核完给申请人发送消息
                //先向消息表中添加消息
                CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.OA表单消息);
                msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.OA表单提交);
                msgModel.C_Messages_link = model.O_Form_AuditFlow_code;
                msgModel.C_Messages_createTime = DateTime.Now;
                msgModel.C_Messages_person = model.O_Form_applyPerson;
                msgModel.C_Messages_isRead = 0;
                msgModel.C_Messages_isValidate = 1;
                _messageWCF.Add(msgModel);
                //添加消息后  发送给审核人信息
                CommonService.Model.OA.O_Form_AuditFlow FAFModel = _oformAuditFlowWCF.GetModelByAuditFlowcode(new Guid(model.O_Form_AuditFlow_code.ToString()), 2);//表单已审批流程信息


                var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                var touser = ChatHub.userlist.FirstOrDefault(x => x.userCode == FAFModel.O_Form_applyPerson.ToString());//查询申请人是否在线
                if (touser != null)
                {
                    JsonHelper jh = new JsonHelper();
                    context.Clients.Client(touser.ConnectionId).sendFormSubMsg(jh.EntityToJson(FAFModel));//接收消息人的数据集合
                }

                #endregion
                return Json(TipHelper.JsonData("审核成功！", "ajaxify_trigger|/oa/form/layoutroottabs?oFormCode=" + model.O_Form_AuditFlow_o_form.Value.ToString(), IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageGoAnotherPage));
            }
            else
            {
                return Json(TipHelper.JsonData("审核失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            #endregion

        }
    }
}