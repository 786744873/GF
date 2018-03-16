using CommonService.Common;
using Maticsoft.Common;
using Microsoft.AspNet.SignalR;
using Portal.Controllers;
using Portal.Hubs;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.KMS.Controllers
{
    public class ProblemController : BaseController
    {
        private readonly ICommonService.KMS.IK_Knowledge _knowledgeWCF;
        private readonly ICommonService.KMS.IK_Problem _problemWCF;
        private readonly ICommonService.KMS.IK_Comments _commentsWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.KMS.IK_Knowledge_Resources knowledge_ResourcesWCF;
        private readonly ICommonService.IC_Messages _messageWCF;
        private readonly ICommonService.KMS.IK_Browse_Log _browserLogWCF;
        private readonly ICommonService.IC_Court _courtWCF;
        private readonly ICommonService.FlowManager.IP_Flow _flowWCF;
        private readonly ICommonService.FlowManager.IP_Flow_form _flowformWCF;
        private readonly ICommonService.KMS.IK_PorblemAndResources_LinkCase _porblemAndResources_LinkCaseWCF;
        private readonly ICommonService.IC_Region _regionWCF;
        //
        // GET: /KMS/Problem/
        public ProblemController()
        {
            #region 服务初始化
            _knowledgeWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Knowledge>("K_KnowledgeWCF");
            _problemWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Problem>("K_ProblemWCF");
            _commentsWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Comments>("K_CommentsWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            knowledge_ResourcesWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Knowledge_Resources>("K_Knowledge_ResourcesWCF");
            _messageWCF = ServiceProxyFactory.Create<ICommonService.IC_Messages>("MessagesWCF");
            _browserLogWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Browse_Log>("K_Browse_LogWCF");
            _courtWCF = ServiceProxyFactory.Create<ICommonService.IC_Court>("CourtWCF");
            _flowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow>("FlowWCF");
            _flowformWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow_form>("Flow_formWCF");
            _porblemAndResources_LinkCaseWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_PorblemAndResources_LinkCase>("K_PorblemAndResources_LinkCaseWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
            #endregion
        }
        public ActionResult Index()
        {
            List<CommonService.Model.KMS.K_Knowledge> listK = _knowledgeWCF.GetAllList();
            ViewBag.listK = listK;
            return View();
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public ActionResult List(string problemContent, string knowledgeCode)
        {
            //string pathStr = Request.Url.PathAndQuery.ToLower();
            CommonService.Model.KMS.K_Problem problem = new CommonService.Model.KMS.K_Problem();
            CommonService.Model.KMS.K_Problem problemNo = new CommonService.Model.KMS.K_Problem();
            problem.K_Problem_auditStatue = Convert.ToInt32(ProblemAuditStateEnum.审核通过);
            if (knowledgeCode != null)
            {
                problem.K_Problem_Knowledge_code = new Guid(knowledgeCode);
            }
            ViewBag.knowledgeCode = knowledgeCode;
            if (!String.IsNullOrEmpty(problemContent))
            {
                problem.K_Problem_content = problemContent;
                ViewBag.problemContent = problem.K_Problem_content;
                Random rd = new Random();
                string index = rd.Next().ToString();
                //索引服务器附件存放全目录
                string indexPath = Server.MapPath("../../") + "indextemp" + "\\" + index;
                if (!Directory.Exists(indexPath))
                {
                    Directory.CreateDirectory(indexPath);
                }
                //List<CommonService.Model.KMS.K_Problem> problemList = _problemWCF.SearchResources(indexPath, problemContent, 5, "", "K_Problem_createTime desc");
                //ViewBag.problemList = problemList;
                //待解决问题
                List<CommonService.Model.KMS.K_Problem> problemListNo = _problemWCF.SearchResources(indexPath, problemContent, 6, "K_Problem_statue=838 and K_Problem_auditStatue=883", "K_Problem_createTime desc");//审核通过并且待解决的问题
                ViewBag.problemListNo = problemListNo;
                //已解决问题
                List<CommonService.Model.KMS.K_Problem> problemListYes = _problemWCF.SearchResources(indexPath, problemContent, 6, "K_Problem_statue=839 and K_Problem_auditStatue=883", "K_Problem_createTime desc");//审核通过并且已解决的问题
                ViewBag.problemListYes = problemListYes;
            }
            else
            {
                ViewBag.problemContent = problem.K_Problem_content;
                //已解决的问题
                problem.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.已解决);
                List<CommonService.Model.KMS.K_Problem> problemList = _problemWCF.GetListByPage(problem, "K_Problem_createTime desc", 0, 6);
                ViewBag.problemListYes = problemList;

                //未解决的问题
                problemNo = problem;
                problemNo.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.未解决);
                List<CommonService.Model.KMS.K_Problem> problemListNo = _problemWCF.GetListByPage(problem, "K_Problem_createTime desc", 0, 6);
                ViewBag.problemListNo = problemListNo;
            }

            List<CommonService.Model.KMS.K_Knowledge> listK = _knowledgeWCF.GetAllList();
            ViewBag.listK = listK;
            //当前用户问题总数
            CommonService.Model.KMS.K_Problem problem1 = new CommonService.Model.KMS.K_Problem();
            if (!Context.UIContext.Current.IsPreSetManager)
            {
                problem1.K_Problem_creator = Context.UIContext.Current.RootUserCode;
            }
            int problemTotal = _problemWCF.GetRecordCount(problem1);
            ViewBag.problemTotal = problemTotal;
            //已解决问题
            problem1.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.已解决);
            int problemSettled = _problemWCF.GetRecordCount(problem1);
            ViewBag.problemSettled = problemSettled;
            //待解决问题
            problem1.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.未解决);
            int problemNoSettled = _problemWCF.GetRecordCount(problem1);
            ViewBag.problemNoSettled = problemNoSettled;
            //热门问题
            List<CommonService.Model.KMS.K_Problem> HotProblem = _problemWCF.GetListByBrowseCount();
            ViewBag.HotProblem = HotProblem;
            //风云榜
            int commentType = Convert.ToInt32(CommentsTypeEunm.问吧回答);
            List<CommonService.Model.KMS.K_Comments> commentCreator = _commentsWCF.GetListByHelpfulCount(commentType);
            ViewBag.commentCreator = commentCreator;
            return View();
        }
        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult Ajaxlist(jQueryDataTableParamModel param)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.KMS.K_Problem Conditon = new CommonService.Model.KMS.K_Problem();
            Conditon.K_Problem_auditStatue = Convert.ToInt32(ProblemAuditStateEnum.审核通过);
            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_title");
                if (title != null && title != "")
                {
                    Conditon.K_Problem_content = title;
                }
                string state = Request.Params.Get("i_state");
                if (state != null && state != "-1")
                {
                    //Conditon.K_Resources_state = Convert.ToInt32(state);
                }

                #endregion
            }

            #endregion

            #region 分页数据处理

            //总记录数
            this.TotalRecordCount = _problemWCF.GetRecordCount(Conditon);
            //数据信息
            List<CommonService.Model.KMS.K_Problem> redources = _problemWCF.GetListByPage(Conditon,
                "", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            //转化数据格式
            var result = from c in redources
                         select new[] { 
                 c.K_Problem_code.ToString(),
                 c.K_Problem_content, 
                 c.K_Problem_statueName
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
        /// 提问题
        /// </summary>
        /// <returns></returns>
        public ActionResult AddProblem(string problemContent, string court, string flow, string form)
        {
            CommonService.Model.KMS.K_PorblemAndResources_LinkCase linkModel = new CommonService.Model.KMS.K_PorblemAndResources_LinkCase();
            if (!string.IsNullOrEmpty(flow))
                linkModel.K_ProblemAndResources_LinkCase_BusinessFlowcode = new Guid(flow);
            if (!string.IsNullOrEmpty(form))
                linkModel.K_ProblemAndResources_LinkCase_Formcode = new Guid(form);
            ViewBag.linkModel = linkModel;
            InitializationPageParameter();
            if (problemContent == "undefined")
            {
                problemContent = "";
            }
            CommonService.Model.KMS.K_Problem problem = new CommonService.Model.KMS.K_Problem();
            problem.K_Problem_code = Guid.NewGuid();
            problem.K_Problem_content = problemContent;
            problem.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.未解决);
            problem.K_Problem_auditStatue = Convert.ToInt32(ProblemAuditStateEnum.审核通过);//因不需审核，默认审核通过
            problem.K_Problem_creator = Context.UIContext.Current.RootUserCode;
            problem.K_Problem_createTime = DateTime.Now;
            problem.K_Problem_isDelete = false;

            List<CommonService.Model.KMS.K_Knowledge> knowledgeList = _knowledgeWCF.GetAllList();
            ViewBag.knowledgeList = knowledgeList;
            return View(problem);
        }
        /// <summary>
        /// 提交问题
        /// </summary>
        /// <param name="form"></param>
        /// <param name="problem"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.KMS.K_Problem problem)
        {
            #region 所属知识分类
            CommonService.Model.KMS.K_Knowledge_Resources knowledgeProblem = new CommonService.Model.KMS.K_Knowledge_Resources();
            knowledgeProblem.K_Knowledge_Resources_code = Guid.NewGuid();
            knowledgeProblem.K_Knowledge_code = new Guid(form["K_Problem_Knowledge_code"]);
            knowledgeProblem.P_FK_code = problem.K_Problem_code;
            knowledgeProblem.K_Knowledge_Resources_type = 2;
            knowledgeProblem.K_Knowledge_Resources_creator = Context.UIContext.Current.RootUserCode;
            knowledgeProblem.K_Knowledge_Resources_createTime = problem.K_Problem_createTime;
            knowledgeProblem.K_Knowledge_Resources_isDelete = false;
            knowledge_ResourcesWCF.Add(knowledgeProblem);
            #endregion

            int flag = _problemWCF.Add(problem);
            if (flag > 0)
            {//成功
                #region 问题/文档/视频 关联业务流程表单表
                string type = form["problemType"];
                if (type == "1")
                {
                    CommonService.Model.KMS.K_PorblemAndResources_LinkCase linkModel = new CommonService.Model.KMS.K_PorblemAndResources_LinkCase();
                    linkModel.K_ProblemAndResources_LinkCase_code = Guid.NewGuid();
                    linkModel.C_FK_code = problem.K_Problem_code.Value;
                    linkModel.K_ProblemAndResources_LinkCase_CourtListcode =form["K_ProblemAndResources_LinkCase_Courtcode"];
                    linkModel.K_ProblemAndResources_LinkCase_BusinessFlowcode = new Guid(form["K_ProblemAndResources_LinkCase_BusinessFlowcode"]);
                    linkModel.K_ProblemAndResources_LinkCase_Formcode = new Guid(form["K_ProblemAndResources_LinkCase_Formcode"]);
                    linkModel.K_ProblemAndResources_LinkCase_type = 2;
                    if (form["caseArea"] != "全部")
                    {
                        linkModel.K_ProblemAndResources_LinkCase_region = new Guid(form["caseArea"]);
                    }

                    _porblemAndResources_LinkCaseWCF.MutilyAdd(linkModel);
                }
                #endregion
                return Json(TipHelper.JsonData("你的问题提交成功！", "/kms/Problem/list", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageGoAnotherPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("操作失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// 回答问题
        /// </summary>
        /// <param name="problemCode">问题Guid</param>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult AnswerProblem(string problemCode, string msgID)
        {
            CommonService.Model.KMS.K_Problem problem = _problemWCF.GetModel(new Guid(problemCode));

            //回答问题
            List<CommonService.Model.KMS.K_Comments> comments = _commentsWCF.GetCommentsListByCode(new Guid(problemCode));
            ViewBag.listCom = comments;
            //增加浏览次数
            AddBrowseCount(problemCode);
            //获取浏览量
            int browseCount = _browserLogWCF.GetBrowseCount(new Guid(problemCode), "K_Browse_Log_usercode");
            ViewBag.browseCount = browseCount;

            if (!string.IsNullOrEmpty(msgID))
            {
                CommonService.Model.C_Messages msgModel = _messageWCF.GetModel(Convert.ToInt32(msgID));//得到此条日程的提醒消息实体
                if (msgModel != null)
                { //存在此条日程的消息提醒
                    if (msgModel.C_Messages_isRead == 0)
                    {
                        msgModel.C_Messages_isRead = 1;
                        _messageWCF.Update(msgModel);
                    }
                }
                var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                var touser = ChatHub.userlist.FirstOrDefault(x => x.userCode == msgModel.C_Messages_person.ToString());//查询消息人信息
                context.Clients.Client(touser.ConnectionId).removeProblemCommentMsg(msgID);//接收消息人的数据集合
            }
            CommonService.Model.KMS.K_PorblemAndResources_LinkCase condtion = new CommonService.Model.KMS.K_PorblemAndResources_LinkCase();
            condtion.C_FK_code = problem.K_Problem_code.Value;
            CommonService.Model.KMS.K_PorblemAndResources_LinkCase linkModel = _porblemAndResources_LinkCaseWCF.GetModelByModel(condtion);
            ViewBag.linkModel = linkModel;
            return View(problem);
        }
        #region 增加资源浏览记录---陈盼盼

        /// <summary>
        /// 增加资源浏览记录
        /// </summary>
        /// <param name="resources"></param>
        public void AddBrowseCount(string resourceCode)
        {
            CommonService.Model.KMS.K_Browse_Log browseLog = new CommonService.Model.KMS.K_Browse_Log();

            browseLog.K_Browse_Log_usercode = Context.UIContext.Current.RootUserCode;//当前登录主用户
            browseLog.P_FK_code = new Guid(resourceCode);//资源code
            browseLog.K_Browse_Log_ip = Request.UserHostAddress;  //取得本机IP

            //判断当前用户是否已浏览过此文档，如果已浏览，则不增加浏览量
            bool isHave = _browserLogWCF.IsExists(browseLog);

            if (!isHave)//如果不存在则新增
            {
                browseLog.K_Browse_Log_datetime = DateTime.Now;//记录生成时间
                _browserLogWCF.Add(browseLog);
            }
        }

        #endregion
        /// <summary>
        /// 提交评论
        /// </summary>
        /// <param name="form"></param>
        /// <param name="resources"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveComment(FormCollection form)
        {
            string resourcesCode = form["problemCode"];
            string commentContent = form["K_Comments_content"];
            string commentContent2 = form["code"];//回复评论的父级guid
            string content = form["" + commentContent2 + ""];//回复内容
            CommonService.Model.KMS.K_Problem problem = _problemWCF.GetModel(new Guid(resourcesCode));
            CommonService.Model.KMS.K_Comments comments = new CommonService.Model.KMS.K_Comments();
            comments.K_Comments_code = Guid.NewGuid();
            comments.P_FK_code = new Guid(resourcesCode);
            comments.K_Comments_type = Convert.ToInt32(CommentsTypeEunm.问吧回答);
            if (!string.IsNullOrEmpty(commentContent2))//子集评论
            {
                comments.K_Comments_parent = new Guid(commentContent2);
                comments.K_Comments_content = content;
            }
            else
            {
                comments.K_Comments_content = commentContent;
            }
            comments.K_Comments_isDelete = false;
            comments.K_Comments_creator = Context.UIContext.Current.RootUserCode;
            comments.K_Comments_createTime = DateTime.Now;
            comments.K_Comments_helpfulCount = false;
            //当前楼层
            int bigNum = _commentsWCF.GetFloors(new Guid(resourcesCode));//获取该资源下最大楼层数
            if (bigNum == 0)
            {
                comments.K_Comments_floors = 1;
            }
            else
            {
                comments.K_Comments_floors = bigNum + 1;
            }
            int isSuccess = _commentsWCF.Add(comments);
            if (!string.IsNullOrEmpty(commentContent2))
            {
                #region 问题回复
                CommonService.Model.KMS.K_Comments comment = _commentsWCF.GetModel(new Guid(commentContent2));
                //先向消息表中添加消息
                CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.KMS问吧回答消息);
                msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.问题回复);
                msgModel.C_Messages_link = comments.K_Comments_code;
                msgModel.C_Messages_createTime = DateTime.Now;
                msgModel.C_Messages_person = comment.K_Comments_creator;
                msgModel.C_Messages_isRead = 0;
                msgModel.C_Messages_isValidate = 1;
                _messageWCF.Add(msgModel);
                //添加消息后  发送给审核人信息
                var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                var touser = ChatHub.userlist.FirstOrDefault(x => x.userCode == comment.K_Comments_creator.ToString());//查询资源创建人是否在线
                if (touser != null)
                {
                    comments.K_Comments_content = comments.K_Comments_content.Length > 10 ? comments.K_Comments_content.Substring(0, 10) + "..." : comments.K_Comments_content;
                    JsonHelper jh = new JsonHelper();
                    context.Clients.Client(touser.ConnectionId).sendProblemCommentMsg(jh.EntityToJson(comments));//接收消息人的数据集合
                }
                #endregion
            }
            else
            {
                #region 给提问人发送消息
                //先向消息表中添加消息
                CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.KMS问吧回答消息);
                msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.问题回答);
                msgModel.C_Messages_link = comments.K_Comments_code;
                msgModel.C_Messages_createTime = DateTime.Now;
                msgModel.C_Messages_person = problem.K_Problem_creator;
                msgModel.C_Messages_isRead = 0;
                msgModel.C_Messages_isValidate = 1;
                _messageWCF.Add(msgModel);
                //添加消息后  发送给审核人信息
                var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                var touser = ChatHub.userlist.FirstOrDefault(x => x.userCode == problem.K_Problem_creator.ToString());//查询提问人是否在线
                if (touser != null)
                {
                    comments.K_Comments_content = comments.K_Comments_content.Length > 10 ? comments.K_Comments_content.Substring(0, 10) + "..." : comments.K_Comments_content;
                    JsonHelper jh = new JsonHelper();
                    context.Clients.Client(touser.ConnectionId).sendProblemCommentMsg(jh.EntityToJson(comments));//接收消息人的数据集合
                }
                #endregion
            }
            if (isSuccess > 0)
            {//成功
                return Json(TipHelper.JsonData("回复成功！", "kms/problem/AnswerProblem?problemCode=" + problem.K_Problem_code + "", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("回复失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// 意见采纳
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CommentAdopt(string commentCode)
        {
            CommonService.Model.KMS.K_Comments comment = _commentsWCF.GetModel(new Guid(commentCode));
            //有用次数+1
            //if(comment.K_Comments_helpfulCount==null)
            //{
            //    comment.K_Comments_helpfulCount = 0;
            //}
            comment.K_Comments_helpfulCount = true;
            _commentsWCF.Update(comment);

            CommonService.Model.KMS.K_Problem problem = _problemWCF.GetModel(comment.P_FK_code.Value);
            problem.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.已解决);
            bool isSuccess = _problemWCF.Update(problem);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("意见已采纳！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("意见采纳失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// 问吧列表
        /// </summary>
        /// <returns></returns>
        public ActionResult problemList()
        {
            InitializationPageParameter();
            return View();
        }
        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult ajaxproblemlist(jQueryDataTableParamModel param)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.KMS.K_Problem Conditon = new CommonService.Model.KMS.K_Problem();

            if (!Context.UIContext.Current.IsPreSetManager)
            {//所属知识分类负责人（虚拟字段）
                Conditon.K_Problem_Knowledge_person = Context.UIContext.Current.RootUserCode.Value;
            }
            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_title");
                if (title != null && title != "")
                {
                    Conditon.K_Problem_content = title;
                }
                //string state = Request.Params.Get("i_state");
                //if (state != null && state != "-1")
                //{
                //    Conditon.K_Problem_auditStatue = Convert.ToInt32(state);
                //}
                string type = Request.Params.Get("i_type");
                if (type != null && type != "-1")
                {
                    Conditon.K_Problem_Knowledge_code = new Guid(type);
                }

                #endregion
            }

            #endregion

            #region 分页数据处理

            //总记录数
            this.TotalRecordCount = _problemWCF.GetRecordCount(Conditon);
            //数据信息
            List<CommonService.Model.KMS.K_Problem> redources = _problemWCF.GetListByPage(Conditon,
                "", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            //转化数据格式
            var result = from c in redources
                         select new[] { 
                 c.K_Problem_code.ToString(),
                 c.K_Problem_content, 
                 c.K_Problem_Knowledge_name,
                 c.K_Problem_auditStatueName,
                 c.K_Problem_creatorName,
                 c.K_Problem_createTime.Value.ToString("yyyy-MM-dd HH:mm:ss")
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
        /// 删除
        /// </summary>
        /// <param name="problemCode">问题Guid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string problemCode, string reflash)
        {
            bool isSuccess = _problemWCF.DeleteList(problemCode);

            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除问题成功！", reflash, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除问题失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// 问题审核
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ProblemAudit(string problemCode, int state)
        {
            bool isSuccess = _problemWCF.ProblemAudit(new Guid(problemCode), state);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("操作成功！", "problemCommentList", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("操作失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 问题搜索
        /// </summary>
        /// <returns></returns>
        public ActionResult Search(string keyWord, string knowledge, string type)
        {
            if (type == null)
                type = "0";

            if (!string.IsNullOrEmpty(keyWord))
                ViewBag.keyword = keyWord;
            if (!string.IsNullOrEmpty(knowledge))
                ViewBag.knowledge = knowledge;
            if (!string.IsNullOrEmpty(type))
                ViewBag.tabType = type;

            List<CommonService.Model.KMS.K_Knowledge> listK = _knowledgeWCF.GetAllList();
            ViewBag.listK = listK;

            return View();
        }

        /// <summary>
        /// 问题搜索ajax/更多问题ajax
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxPromblemSearchlist(jQueryDataTableParamModel param)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.KMS.K_Problem Conditon = new CommonService.Model.KMS.K_Problem();
            //查询非自己的问题时，只能看到审核通过的
            Conditon.K_Problem_auditStatue = Convert.ToInt32(ProblemAuditStateEnum.审核通过);//审核通过的数据

            #region 查询项处理
            bool flag = true;//判断是否需要执行详细信息查询
            //关键字查询   
            string keyWord = Request.Params.Get("s_title");
            //string title = Request.Params.Get("");
            if (keyWord != null && keyWord != "")
            {
                Random rd = new Random();
                string index = rd.Next().ToString();
                //索引服务器附件存放全目录
                string indexPath = Server.MapPath("../../") + "indextemp" + "\\" + index;
                if (!Directory.Exists(indexPath))
                {
                    Directory.CreateDirectory(indexPath);
                }
                string codeitem = _problemWCF.GetProblemCodeItems(indexPath, keyWord);
                if (codeitem == "")
                {
                    flag = false;
                }
                else
                {
                    Conditon.K_Problem_codeItems = codeitem;
                }
            }

            //string tabType = Request.Params.Get("tabType");
            string tabType = Request.Params.Get("shareproblemtype");
            if (tabType == "1")
            {
                Conditon.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.已解决);
            }
            if (tabType == "2")
            {
                Conditon.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.未解决);
            }
            else
            { tabType = "0"; }
            ViewBag.tabType = tabType;
            //资源所属知识类型查询条件
            string knowledge = Request.Params.Get("KnowledgeType");
            if (!string.IsNullOrEmpty(knowledge))
            {
                Conditon.K_Problem_Knowledge_code = new Guid(knowledge);
            }
            string myProblem = Request.Params.Get("myProblem");

            #endregion

            #endregion

            #region 分页数据处理
            List<CommonService.Model.KMS.K_Problem> redources = new List<CommonService.Model.KMS.K_Problem>();
            if (flag)
            {//执行查询详细信息
                //总记录数
                this.TotalRecordCount = _problemWCF.GetRecordCount(Conditon);
                //数据信息
                redources = _problemWCF.GetListByPage(Conditon,
                    "K_Problem_createTime desc ", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            }
            else
            {
                this.TotalRecordCount = 0;
            }
            //转化数据格式
            var result = from c in redources
                         select new[] { 
                 c.K_Problem_code.ToString(),
                 c.K_Problem_content, 
                 c.K_Problem_Knowledge_name,
                 c.K_Problem_creatorName,
                 c.K_Problem_createTime.Value.ToString("yyyy/MM/dd"),
                 c.K_Problem_AnswerCount.ToString(),
                 TotalRecordCount.ToString(),
                 keyWord
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
        /// 根据流程得到表单数据列表
        /// </summary>
        /// <param name="businessFlow"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetFormList(string businessFlow)
        {
            List<CommonService.Model.FlowManager.P_Flow_form> formItems = _flowformWCF.GetListByFlowCode(new Guid(businessFlow));
            return Json(formItems);
        }
        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //资源状态参数集合
            List<CommonService.Model.C_Parameters> ProblemState = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(ProblemEnum.问题审核状态));
            List<CommonService.Model.KMS.K_Knowledge> ProblemType = _knowledgeWCF.GetAllList();

            ViewBag.ProblemState = ProblemState;
            ViewBag.ProblemType = ProblemType;
            //法院集合
            List<CommonService.Model.C_Court> CourtItems = _courtWCF.GetAllList();
            string userHtml = "";
            userHtml += "<option value='all'>全部</option>";
            foreach (var court in CourtItems)
            {
                userHtml += "<option value=" + court.C_Court_code + ">" + court.C_Court_name + "</option>";
            }
            ViewBag.userhtml = userHtml;
            ViewBag.courtItems = CourtItems;
            //业务流程集合
            List<CommonService.Model.FlowManager.P_Flow> FlowItems = _flowWCF.GetListByFlowType(Convert.ToInt32(FlowTypeEnum.案件));
            ViewBag.flowItems = FlowItems;
            //表单集合（默认获取第一个流程的表单）
            List<CommonService.Model.FlowManager.P_Flow_form> formItems = _flowformWCF.GetListByFlowCode(FlowItems[0].P_Flow_code.Value);
            ViewBag.formItem = formItems;
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.regionList = regionList;
        }
    }
}