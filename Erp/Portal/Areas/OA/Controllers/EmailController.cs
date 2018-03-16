using CommonService.Common;
using Maticsoft.Common;
using Microsoft.AspNet.SignalR;
using Portal.Controllers;
using Portal.Hubs;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.OA.Controllers
{
    public class EmailController : BaseController
    {
        private readonly ICommonService.OA.IO_Email _emailWCF;
        private readonly ICommonService.OA.IO_Email_user _emailUserWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.IC_Messages _messageWCF;
        public EmailController()
        {
            #region 服务初始化
            _emailWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Email>("emailWCF");
            _emailUserWCF = ServiceProxyFactory.Create<ICommonService.OA.IO_Email_user>("email_userWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _messageWCF = ServiceProxyFactory.Create<ICommonService.IC_Messages>("MessagesWCF");
            #endregion
        }
        public static List<CommonService.Model.SysManager.C_Userinfo> ConnectedUsers = new List<CommonService.Model.SysManager.C_Userinfo>();
        //
        // GET: /OA/Email/
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 创建邮件和修改邮件
        /// </summary>
        /// <returns></returns>
        public ActionResult Create(string userCode,string skipType)
        {
            if (!string.IsNullOrEmpty(userCode))
            {
                ViewBag.sendCode = userCode;
            }
            else
            {
                ViewBag.sendCode = "";
            }
            CommonService.Model.OA.O_Email email = new CommonService.Model.OA.O_Email();
            email.O_Email_code = Guid.NewGuid();
            email.O_Email_creator = Context.UIContext.Current.RootUserCode;
            email.O_Email_isDelete = false;
            email.O_Email_sender = Context.UIContext.Current.RootUserCode;
            List<CommonService.Model.SysManager.C_Userinfo> userLists = _userinfoWCF.GetParentList();
            string userHtml = "";
            userHtml += "<option value=-1>全部</option>";
            foreach (var user in userLists)
            {
                userHtml += "<option value=" + user.C_Userinfo_code + ">" + user.C_Userinfo_name + "</option>";
            }
            ViewBag.userhtml = userHtml;
            ViewBag.skipType = skipType;
            return View(email);
        }
        /// <summary>
        /// 打开菜单按钮的链接默认收件箱
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ActionResult List(string emailCode, string msgID, string Mlist, int? type = 1)
        {
            ViewBag.Mlist = Mlist;
            ViewBag.EmailCode = emailCode;
            ViewBag.MsgID = msgID;
            ViewBag.type = type;
            //if (!string.IsNullOrEmpty(Mlist))
            //{ //从消息跳转过来，跳到指定的邮件详细
            //    return RedirectToAction("Details","Email", new { emailCode = emailCode, msgID = msgID, type = type });
            //}

            string Title = "";
            if (type == 1)
            {
                Title = "收件箱";
            }
            else if (type == 2)
            {
                Title = "发件箱";
            }
            else
            {
                Title = "草稿箱";
            }
            ViewBag.title = Title;
            return View();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="emailCode"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public ActionResult Edit(string emailCode, int type)
        {
            CommonService.Model.OA.O_Email model = _emailWCF.GetModelByCode(new Guid(emailCode));
            List<CommonService.Model.OA.O_Email_user> list = _emailUserWCF.GetListByEmailCode(new Guid(emailCode));
            string user_list = "";
            foreach (var item in list)
            {
                user_list = user_list + item.C_Userinfo_code.ToString() + ",";
            }
            model.O_Email_userList = user_list == "" ? "" : user_list.Substring(0, user_list.Length - 1);

            string userHtml = "";
            userHtml += "<option value=-1>全部</option>";
            List<CommonService.Model.SysManager.C_Userinfo> userLists = _userinfoWCF.GetParentList();
            foreach (var user in userLists)
            {
                userHtml += "<option value=" + user.C_Userinfo_code + ">" + user.C_Userinfo_name + "</option>";
            }
            ViewBag.userhtml = userHtml;
            ViewBag.Etype = type;
            return View("Create", model);
        }
        /// <summary>
        /// 根据type类型的不同过去收件箱，发件箱，草稿箱的数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AjaxList(jQueryDataTableParamModel param)
        {
            // type   判断是1.收件箱 还是2.已发送   还是3.草稿箱
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)
            //邮箱查询模型
            CommonService.Model.OA.O_Email_user emailUserConditon = new CommonService.Model.OA.O_Email_user();
            CommonService.Model.OA.O_Email emailConditon = new CommonService.Model.OA.O_Email();
            int type = Convert.ToInt32(Request.Params.Get("istype"));
            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch != "0")
            {
                //代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_title");
                if (title != null && title != "")
                {
                    emailConditon.O_Email_title = title;
                    emailUserConditon.O_Email_title = title;
                }
                #endregion
            }

            if (!string.IsNullOrEmpty(type.ToString()))
            {
                if (type == 1)//收件箱
                {
                    // 获取收件箱数据
                    emailUserConditon.O_Email_state = Convert.ToInt32(EmailStateEnum.已发送);
                    emailUserConditon.O_Email_user_type = Convert.ToInt32(EmailSendTypeEnum.收件人);
                    emailUserConditon.C_Userinfo_code = Context.UIContext.Current.RootUserCode;
                }
                else if (type == 2)//已发送
                {
                    emailConditon.O_Email_state = Convert.ToInt32(EmailStateEnum.已发送);
                    emailConditon.O_Email_sender = Context.UIContext.Current.RootUserCode;
                }
                else//草稿箱
                {
                    emailConditon.O_Email_state = Convert.ToInt32(EmailStateEnum.草稿);
                    emailConditon.O_Email_sender = Context.UIContext.Current.RootUserCode;
                }
            }
            #endregion

            #region 分页数据处理


            //转化数据格式
            if (type == 1)
            {//收件箱
                //总记录数
                this.TotalRecordCount = _emailUserWCF.GetRecordCount(emailUserConditon);
                //数据信息
                List<CommonService.Model.OA.O_Email_user> emails = _emailUserWCF.GetListByPage(emailUserConditon,
                    "O_Email_createTime Desc", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
                var result = from c in emails
                             select new[] { 
                 c.O_Email_code.Value.ToString(), 
                 //"<input type='checkbox' class='checkboxes' value="+c.O_Email_code.Value.ToString()+"/>",
                 c.O_Email_title,
                 c.C_Userinfo_name,
                 c.O_Email_user_isRead?"是":"否",
                 c.O_Email_createTime==null?"":c.O_Email_createTime.Value.ToString("yyyy-MM-dd HH:mm:ss") 
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
            }
            else
            {//草稿箱和发送箱
                //总记录数
                this.TotalRecordCount = _emailWCF.GetRecordCount(emailConditon);
                List<CommonService.Model.OA.O_Email> emails = _emailWCF.GetListByPage(emailConditon,
                    "O_Email_createTime Desc", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
                var result = from c in emails
                             select new[] { 
                 c.O_Email_code.Value.ToString(), 
                 //"<input type='checkbox' class='checkboxes' value="+c.O_Email_code.Value.ToString()+"/>",
                 c.O_Email_title,
                 c.O_Email_userListname==""?"":c.O_Email_userListname.Substring(0,c.O_Email_userListname.Length-1),
                 c.O_Email_createTime.Value.ToString("yyyy-MM-dd HH:mm:ss") 
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
            }

            #endregion
        }
        /// <summary>
        /// 邮件发送
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection form, CommonService.Model.OA.O_Email email)
        {
            //收件人list
            string userLists = form["hd_receivers"];
            int type = Convert.ToInt32(form["type"]);//获取邮件的操作类型   存草稿  /    发送
            string Result = "";
            if (type == 490)//存草稿
            {
                email.O_Email_state = 490;
                Result = "保存";
            }
            else//发送
            {
                email.O_Email_state = 489;
                Result = "发送";
            }
            if (_emailWCF.MutilyAddEmail(email, userLists))
            {
                if (email.O_Email_state == 489)
                {
                    #region   邮件发送成功  推送消息
                    var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                    if (userLists.Contains("-1"))
                    {//全部人员
                        List<CommonService.Model.SysManager.C_Userinfo> userListList = _userinfoWCF.GetParentList();
                        foreach (var item in userListList)
                        { //消息表中添加消息
                            CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                            msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.OA邮箱消息);
                            msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.收件箱消息);
                            msgModel.C_Messages_link = email.O_Email_code;
                            msgModel.C_Messages_createTime = DateTime.Now;
                            msgModel.C_Messages_person = item.C_Userinfo_code.Value;
                            msgModel.C_Messages_isRead = 0;
                            msgModel.C_Messages_isValidate = 1;
                            _messageWCF.Add(msgModel);
                        }
                        foreach (var item in userListList)
                        {
                            var touser = ChatHub.userlist.FirstOrDefault(x => x.userCode == item.ToString());//查询收件人是否在线
                            if (touser != null)
                            {
                                CommonService.Model.OA.O_Email_user emailUser = _emailUserWCF.GetModelByEcodeAndUcode(new Guid(email.O_Email_code.ToString()), item.C_Userinfo_code.Value);
                                context.Clients.Client(touser.ConnectionId).sendEmailMsg(EntityToJson(emailUser));//接收消息人的数据集合
                            }
                        }
                    }
                    else
                    {
                        string[] userItem = userLists.Split(',');
                        foreach (var item in userItem)
                        { //消息表中添加消息
                            CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                            msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.OA邮箱消息);
                            msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.收件箱消息);
                            msgModel.C_Messages_link = email.O_Email_code;
                            msgModel.C_Messages_createTime = DateTime.Now;
                            msgModel.C_Messages_person = new Guid(item);
                            msgModel.C_Messages_isRead = 0;
                            msgModel.C_Messages_isValidate = 1;
                            _messageWCF.Add(msgModel);
                        }
                        foreach (var item in userItem)
                        {
                            var touser = ChatHub.userlist.FirstOrDefault(x => x.userCode == item.ToString());//查询收件人是否在线
                            if (touser != null)
                            {
                                CommonService.Model.OA.O_Email_user emailUser = _emailUserWCF.GetModelByEcodeAndUcode(new Guid(email.O_Email_code.ToString()), new Guid(item));
                                context.Clients.Client(touser.ConnectionId).sendEmailMsg(EntityToJson(emailUser));//接收消息人的数据集合
                            }
                        }
                    }
                    #endregion
                }
                return Json(TipHelper.JsonData("邮件" + Result + "成功！", "ajaxify_trigger|/oa/email/List", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageGoAnotherPage));
            }
            else
                return Json(TipHelper.JsonData("邮件" + Result + "失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
        }
        /// <summary>
        /// 查看邮件详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Details(string emailCode, string msgID, string type)
        {
            Guid emailGuid = new Guid(emailCode);
            int flag = 0;
            CommonService.Model.OA.O_Email email = _emailWCF.GetModelByCode(new Guid(emailCode));
            //修改此email为已读
            if (email.O_Email_state == Convert.ToInt32(EmailStateEnum.已发送))
            {
                CommonService.Model.OA.O_Email_user emailuser = _emailUserWCF.GetModelByEcodeAndUcode(emailGuid, new Guid(Context.UIContext.Current.RootUserCode.ToString()));
                if (emailuser != null && emailuser.O_Email_user_isRead == false)
                {
                    emailuser.O_Email_user_isRead = true;
                    _emailUserWCF.Update(emailuser);
                }
                CommonService.Model.C_Messages model = _messageWCF.GetModelByLinkCodeUserCodeModel(new Guid(emailCode), new Guid(Context.UIContext.Current.RootUserCode.ToString()));
                if (model != null)
                {
                    Readmsg(model.C_Messages_id.ToString());
                    flag++;
                }
            }
            //修改消息为已读
            if (!string.IsNullOrEmpty(msgID))
            {
                if (flag == 0)
                    Readmsg(msgID);
            }
            ViewBag.type = type;
            ViewBag.sendCode = email.O_Email_creator.ToString();
            ViewBag.emailCode = emailCode;
            return View(email);
        }
        /// <summary>
        /// 消息加载局部视图
        /// </summary>
        /// <param name="emailCode"></param>
        /// <param name="msgID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public PartialViewResult PartDetails(string emailCode, string msgID, string type,string skipType)
        {
            Guid emailGuid = new Guid(emailCode);
            int flag = 0;
            CommonService.Model.OA.O_Email email = _emailWCF.GetModelByCode(new Guid(emailCode));
            //修改此email为已读
            if (email.O_Email_state == Convert.ToInt32(EmailStateEnum.已发送))
            {
                CommonService.Model.OA.O_Email_user emailuser = _emailUserWCF.GetModelByEcodeAndUcode(emailGuid, new Guid(Context.UIContext.Current.RootUserCode.ToString()));
                if (emailuser != null && emailuser.O_Email_user_isRead == false)
                {
                    emailuser.O_Email_user_isRead = true;
                    _emailUserWCF.Update(emailuser);
                }
                CommonService.Model.C_Messages model = _messageWCF.GetModelByLinkCodeUserCodeModel(new Guid(emailCode), new Guid(Context.UIContext.Current.RootUserCode.ToString()));
                if (model != null)
                {
                    Readmsg(model.C_Messages_id.ToString());
                    flag++;
                }
            }
            //修改消息为已读
            if (!string.IsNullOrEmpty(msgID))
            {
                if (flag == 0)
                    Readmsg(msgID);
            }
            ViewBag.type = type;
            ViewBag.sendCode = email.O_Email_creator.ToString();
            ViewBag.skipType = skipType;
            return PartialView("Details", email);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="articleCode">邮件Guid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string emailCode, string type)
        {
            bool flag = true;
            Guid emaiGuid = new Guid(emailCode);
            if (Convert.ToInt32(type) == 1)//收件箱可以删除
            {
                if (!_emailUserWCF.DeleteByCode(emaiGuid, new Guid(Context.UIContext.Current.RootUserCode.ToString())))
                {
                    flag = false;
                }
            }
            else if (Convert.ToInt32(type) == 2)//已发送
            {
                flag = false;
            }
            else//草稿箱
            {
                if (!_emailWCF.MutilyDelete(emaiGuid))
                    flag = false;
            }
            if (flag)
            {//成功
                return Json(TipHelper.JsonData("删除邮件信息成功！", "ajaxify_trigger|/oa/email/List", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndThisPageGoAnotherPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除邮件信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj">要转换的实体对象</param>
        /// <returns></returns>
        public string EntityToJson(object obj)
        {
            StringBuilder jsonStr = new StringBuilder();
            PropertyInfo[] pInfos = obj.GetType().GetProperties();
            string pValue = string.Empty;
            jsonStr.Append("{");
            foreach (PropertyInfo p in pInfos)
            {
                if (!(p.GetValue(obj, null) == null))
                {
                    //转义掉Json格式特殊字符 ‘\’,‘"’
                    pValue = p.GetValue(obj, null).ToString().Replace("\\", "\\\\").Replace("\"", "\\\"");
                }
                else
                {
                    pValue = string.Empty;
                }
                jsonStr.Append(string.Format("\"{0}\":\"{1}\",", p.Name, pValue));

            }
            jsonStr.Remove(jsonStr.Length - 1, 1);
            jsonStr.Append("}");
            return jsonStr.ToString();
        }
        /// <summary>
        /// 读取消息
        /// </summary>
        /// <param name="msgID"></param>
        private void Readmsg(string msgID)
        {
            CommonService.Model.C_Messages model = _messageWCF.GetModel(Convert.ToInt32(msgID));
            if (model.C_Messages_isRead == 0)
            {
                model.C_Messages_isRead = 1;
                _messageWCF.ReadMessage(Convert.ToInt32(msgID));
                var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                var touser = ChatHub.userlist.FirstOrDefault(x => x.userCode == model.C_Messages_person.ToString());//查询消息人信息
                if (touser != null)
                    context.Clients.Client(touser.ConnectionId).removeEmailSubMsg(msgID);//接收消息人的数据集合
            }
        }
    }
}