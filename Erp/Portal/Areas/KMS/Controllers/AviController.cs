using CommonService.Common;
using Maticsoft.Common;
using Maticsoft.DBUtility;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Security.Twitter.Messages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Portal.Controllers;
using Portal.Hubs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.KMS.Controllers
{
    public class AviController : BaseController
    {
        private readonly ICommonService.KMS.IK_Resources _resourcesWCF;
        private readonly ICommonService.KMS.IK_Knowledge _knowledgeWCF;
        private readonly ICommonService.KMS.IK_Keyword _keywordWCF;
        private readonly ICommonService.KMS.IK_Keyword_Resources _keyword_ResourcesWCF;
        private readonly ICommonService.KMS.IK_Knowledge_Resources knowledge_ResourcesWCF;
        private readonly ICommonService.KMS.IK_Comments _commentsWCF;
        private readonly ICommonService.KMS.IK_study _studyWCF;
        private readonly ICommonService.KMS.IK_Token _tokenWCF;
        private readonly ICommonService.IC_Messages _messageWCF;
        private readonly ICommonService.KMS.IK_Resources_Browse _resourcesBrowseWCF;
        private readonly ICommonService.KMS.IK_Browse_Log _browserLogWCF;
        private readonly ICommonService.IC_Court _courtWCF;
        private readonly ICommonService.FlowManager.IP_Flow _flowWCF;
        private readonly ICommonService.FlowManager.IP_Flow_form _flowformWCF;
        private readonly ICommonService.KMS.IK_PorblemAndResources_LinkCase _porblemAndResources_LinkCaseWCF;
        private readonly ICommonService.IC_Region _regionWCF;

        private string ClidentID = "46d33f35eb3b5080";
        private string ClientSecret = "684644f4a4703482f9a2a9854713b16a";
        private string url = "https://openapi.youku.com/v2/oauth2/authorize?client_id=46d33f35eb3b5080&response_type=code&redirect_uri=http://www.baidu.com";
        private string AccessTokenUrl = "https://openapi.youku.com/v2/oauth2/token";
        private string Code = "80223b6d83b54daacb5c496d1d5dcb4c";

        public AviController()
        {
            #region 服务初始化
            _resourcesWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Resources>("K_ResourcesWCF");
            _knowledgeWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Knowledge>("K_KnowledgeWCF");
            _keywordWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Keyword>("K_KeywordWCF");
            _keyword_ResourcesWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Keyword_Resources>("K_Keyword_ResourcesWCF");
            knowledge_ResourcesWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Knowledge_Resources>("K_Knowledge_ResourcesWCF");
            _commentsWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Comments>("K_CommentsWCF");
            _studyWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_study>("K_studyWCF");
            _tokenWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Token>("K_TokenWCF");
            _messageWCF = ServiceProxyFactory.Create<ICommonService.IC_Messages>("MessagesWCF");
            _resourcesBrowseWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Resources_Browse>("K_Resources_BrowseWCF");
            _browserLogWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Browse_Log>("K_Browse_LogWCF");
            _courtWCF = ServiceProxyFactory.Create<ICommonService.IC_Court>("CourtWCF");
            _flowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow>("FlowWCF");
            _flowformWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow_form>("Flow_formWCF");
            _porblemAndResources_LinkCaseWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_PorblemAndResources_LinkCase>("K_PorblemAndResources_LinkCaseWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
            #endregion
        }
        //
        // GET: /KMS/Avi/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(string court, string flow, string form)
        {
            //string getTokenparmar = "client_id=46d33f35eb3b5080&client_secret=684644f4a4703482f9a2a9854713b16a&grant_type=authorization_code&code=" + Code + "&redirect_uri=http://www.baidu.com";
            CommonService.Model.KMS.K_PorblemAndResources_LinkCase linkModel = new CommonService.Model.KMS.K_PorblemAndResources_LinkCase();
            if (!string.IsNullOrEmpty(flow))
                linkModel.K_ProblemAndResources_LinkCase_BusinessFlowcode = new Guid(flow);
            if (!string.IsNullOrEmpty(form))
                linkModel.K_ProblemAndResources_LinkCase_Formcode = new Guid(form);
            ViewBag.linkModel = linkModel;
            //获取最新Token
            CommonService.Model.KMS.K_Token upToDateToken = _tokenWCF.GetDateModel("K_Token_zambia_createTime desc");
            //创建时间与当前时间相比是否超过token中的有效时间（K_Token_expires_in）
            DateTime dtNow = DateTime.Now;//当前时间
            DateTime dtOld = Convert.ToDateTime(upToDateToken.K_Token_zambia_createTime);//创建时间
            int seconds = Convert.ToInt32((dtNow - dtOld).TotalSeconds);//间隔秒
            string refreshToken = "client_id=46d33f35eb3b5080&client_secret=684644f4a4703482f9a2a9854713b16a&grant_type=refresh_token&refresh_token=" + upToDateToken.K_Token_refresh_token;
            string token = PostWebRequest(AccessTokenUrl, refreshToken, Encoding.UTF8);
            if (seconds > upToDateToken.K_Token_expires_in)
            {              
                //{"access_token": "a4481cad3b9e2d3c5aa386228e558767","expires_in": "2592000","refresh_token": "b5c07f7231fdc5e255ade69178154fd2","token_type": "bearer"}
                JObject jo = (JObject)JsonConvert.DeserializeObject(token);
                CommonService.Model.KMS.K_Token model = new CommonService.Model.KMS.K_Token();
                model.K_Token_Access_Token = jo["access_token"].ToString();
                model.K_Token_expires_in = Convert.ToInt32(jo["expires_in"].ToString());
                model.K_Token_refresh_token = jo["refresh_token"].ToString();
                model.K_Token_zambia_createTime = DateTime.Now;
                model.K_Token_zambia_isDelete = false;
                _tokenWCF.Add(model);//数据库中添加新的token值
                ViewBag.token = jo["access_token"].ToString();
            }
            else
            {
                ViewBag.token = upToDateToken.K_Token_Access_Token.ToString();
            }
            CommonService.Model.KMS.K_Resources resources = new CommonService.Model.KMS.K_Resources();
            resources.K_Resources_code = Guid.NewGuid();
            resources.K_Resources_state = Convert.ToInt32(ResourcesStateEnum.未审核);
            resources.K_Resources_creator = Context.UIContext.Current.RootUserCode;
            resources.K_Resources_isDelete = false;
            InitializationPageParameter();
            return View(resources);
        }
        /// <summary>
        /// 视频上传
        /// </summary>
        /// <param name="form"></param>
        /// <param name="resources"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(string auther, string tags, string title, string description, string id, string baseimg, string K_Resources_Knowledge, string court, string flow, string form, string caseArea)
        {
            CommonService.Model.KMS.K_Resources model = new CommonService.Model.KMS.K_Resources();
            model.K_Resources_code = Guid.NewGuid();
            model.K_Resources_isDelete = false;
            model.K_Resources_state = Convert.ToInt32(ResourcesStateEnum.未审核);
            model.K_Resources_creator = Context.UIContext.Current.RootUserCode;
            if (!String.IsNullOrEmpty(auther))
            {
                model.K_Resources_author = auther;
            }
            if (!String.IsNullOrEmpty(title))
            {
                model.K_Resources_name = title;
            }
            if (!String.IsNullOrEmpty(description))
            {
                model.K_Resources_description = description;
            }
            model.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.视频);
            model.K_Resources_createTime = DateTime.Now;
            model.K_Resources_url = id;
            if (!String.IsNullOrEmpty(baseimg) && baseimg != "undefined")
            {
                #region  封面处理
                string base64 = baseimg.Split(',')[1];//base64值
                byte[] imgfile = Convert.FromBase64String(base64);
                MemoryStream memStream = new MemoryStream(imgfile);
                Bitmap bmp = new Bitmap(memStream);
                //服务器附件存放全目录
                string filename = Guid.NewGuid().ToString();
                bmp.Save(Server.MapPath("../../") + "img\\" + "" + filename + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);   //保存为.jpg格式
                memStream.Close();
                model.K_Resources_coverImage = @"\img\" + "" + filename + ".jpg";
                #endregion
            }
            int isSuccess = _resourcesWCF.Add(model);
            if (K_Resources_Knowledge != "")
            {
                CommonService.Model.KMS.K_Knowledge_Resources knowledgeResourcesModel = new CommonService.Model.KMS.K_Knowledge_Resources();
                knowledgeResourcesModel.K_Knowledge_Resources_code = Guid.NewGuid();
                knowledgeResourcesModel.K_Knowledge_Resources_type = 1;
                knowledgeResourcesModel.P_FK_code = model.K_Resources_code;
                knowledgeResourcesModel.K_Knowledge_code = new Guid(K_Resources_Knowledge);
                knowledgeResourcesModel.K_Knowledge_Resources_creator = Context.UIContext.Current.RootUserCode;
                knowledgeResourcesModel.K_Knowledge_Resources_createTime = DateTime.Now;
                knowledgeResourcesModel.K_Knowledge_Resources_isDelete = false;

                knowledge_ResourcesWCF.Add(knowledgeResourcesModel);
            }
            #region 关键字处理
            if (!String.IsNullOrEmpty(tags))
            {
                string[] Keywords = tags.Split(',', '，');
                List<CommonService.Model.KMS.K_Keyword> keywordList = new List<CommonService.Model.KMS.K_Keyword>();
                List<CommonService.Model.KMS.K_Keyword_Resources> keyword_ResourcesList = new List<CommonService.Model.KMS.K_Keyword_Resources>();
                foreach (string keyword in Keywords)
                {
                    CommonService.Model.KMS.K_Keyword_Resources keywordResourcesModel = new CommonService.Model.KMS.K_Keyword_Resources();//关键字与资源关连表
                    CommonService.Model.KMS.K_Keyword keywordModel = new CommonService.Model.KMS.K_Keyword();//过滤名称相同的关键字
                    string keyWordCode = _keywordWCF.GetModelByKey(keyword);
                    if (keyWordCode == "")
                    {
                        keywordModel = new CommonService.Model.KMS.K_Keyword();
                        keywordModel.K_Keyword_code = Guid.NewGuid();
                        keywordModel.K_Keyword_name = keyword;
                        keywordModel.K_Keyword_creator = Context.UIContext.Current.RootUserCode;
                        keywordModel.K_Keyword_createTime = DateTime.Now;
                        keywordModel.K_Keyword_isDelete = false;

                        keywordList.Add(keywordModel);
                        keywordResourcesModel.K_Keyword_code = keywordModel.K_Keyword_code.Value;
                        keywordResourcesModel.K_Resources_code = model.K_Resources_code.Value;
                    }
                    else
                    {
                        keywordResourcesModel.K_Keyword_code = new Guid(keyWordCode);
                        keywordResourcesModel.K_Resources_code = model.K_Resources_code.Value;
                    }

                    keyword_ResourcesList.Add(keywordResourcesModel);
                }
                _keywordWCF.OperateList(keywordList);
                _keyword_ResourcesWCF.OperateList(keyword_ResourcesList);
            }
            #endregion
            if (isSuccess > 0)
            {//成功
                #region 问题/文档/视频 关联业务流程表单表
                if (!string.IsNullOrEmpty(court))
                {
                    CommonService.Model.KMS.K_PorblemAndResources_LinkCase linkModel = new CommonService.Model.KMS.K_PorblemAndResources_LinkCase();
                    linkModel.K_ProblemAndResources_LinkCase_code = Guid.NewGuid();
                    linkModel.C_FK_code = model.K_Resources_code.Value;
                    linkModel.K_ProblemAndResources_LinkCase_CourtListcode = court;
                    linkModel.K_ProblemAndResources_LinkCase_BusinessFlowcode = new Guid(flow);
                    linkModel.K_ProblemAndResources_LinkCase_Formcode = new Guid(form);
                    linkModel.K_ProblemAndResources_LinkCase_type = 3;
                    if (caseArea != "全部")
                    {
                        linkModel.K_ProblemAndResources_LinkCase_region = new Guid(caseArea);
                    }

                    _porblemAndResources_LinkCaseWCF.MutilyAdd(linkModel);
                }
                #endregion

                return Json(1);
            }
            else
            {//失败
                return Json(0);
            }
        }
        /// <summary>
        /// 查看视频
        /// </summary>
        /// <returns></returns>
        public ActionResult Details(string id, string msgID)
        {
            CommonService.Model.KMS.K_Resources resources = _resourcesWCF.GetModelByUrl(id);

            ViewBag.id = id;

            List<CommonService.Model.KMS.K_Comments> comments = _commentsWCF.GetCommentsListByCode(resources.K_Resources_code.Value);
            ViewBag.listCom = comments;
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
                context.Clients.Client(touser.ConnectionId).removeFormSubMsg(msgID);//接收消息人的数据集合
            }

            //判断是否收藏过此资源
            bool exists = _studyWCF.ExistsStudy(Context.UIContext.Current.RootUserCode.Value, new Guid(resources.K_Resources_code.ToString()));
            int flag = 0;
            if (exists)
                flag = 1;
            ViewBag.flag = flag;

            //添加用户浏览记录
            AddBrowse(Context.UIContext.Current.RootUserCode.Value, new Guid(resources.K_Resources_code.ToString()));

            //增加资源浏览量
            AddBrowseCount(resources.K_Resources_code.ToString());
            //获取资源浏览量
            int browseCount = _browserLogWCF.GetBrowseCount(resources.K_Resources_code.Value, "K_Browse_Log_usercode");
            ViewBag.browseCount = browseCount;

            return View(resources);
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
            string resourcesCode = form["resourcesCode"];
            string commentContent = form["K_Comments_content"];
            string commentContent2 = form["code"];//回复评论的父级guid
            string content = form["" + commentContent2 + ""];//回复内容
            CommonService.Model.KMS.K_Resources resources = _resourcesWCF.GetModel(new Guid(resourcesCode));
            CommonService.Model.KMS.K_Comments comments = new CommonService.Model.KMS.K_Comments();
            comments.K_Comments_code = Guid.NewGuid();
            comments.P_FK_code = new Guid(resourcesCode);
            comments.K_Comments_type = Convert.ToInt32(CommentsTypeEunm.资源评论);
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
                #region 评论回复
                CommonService.Model.KMS.K_Comments comment = _commentsWCF.GetModel(new Guid(commentContent2));
                //先向消息表中添加消息
                CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.KMS资源评论消息);
                msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.评论回复);
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
                    JsonHelper jh = new JsonHelper();
                    context.Clients.Client(touser.ConnectionId).sendFormSubMsg(jh.EntityToJson(comments));//接收消息人的数据集合
                }
                #endregion
            }
            else
            {
                #region 给资源提交人发送消息
                //先向消息表中添加消息
                CommonService.Model.C_Messages msgModel = new CommonService.Model.C_Messages();
                msgModel.C_Messages_fType = Convert.ToInt32(MessageBigTypeEnum.KMS资源评论消息);
                msgModel.C_Messages_type = Convert.ToInt32(MessageTinyTypeEnum.资源评论);
                msgModel.C_Messages_link = comments.K_Comments_code;
                msgModel.C_Messages_createTime = DateTime.Now;
                msgModel.C_Messages_person = resources.K_Resources_creator;
                msgModel.C_Messages_isRead = 0;
                msgModel.C_Messages_isValidate = 1;
                _messageWCF.Add(msgModel);
                //添加消息后  发送给审核人信息
                var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                var touser = ChatHub.userlist.FirstOrDefault(x => x.userCode == resources.K_Resources_creator.ToString());//查询资源创建人是否在线
                if (touser != null)
                {
                    JsonHelper jh = new JsonHelper();
                    context.Clients.Client(touser.ConnectionId).sendFormSubMsg(jh.EntityToJson(comments));//接收消息人的数据集合
                }
                #endregion
            }
            if (isSuccess > 0)
            {//成功
                return Json(TipHelper.JsonData("回复成功！", "commentsList", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("回复失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 收藏视频
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AviCollection(string ResourcesCode)
        {
            int flag = 0;
            bool exists = _studyWCF.ExistsStudy(Context.UIContext.Current.RootUserCode.Value, new Guid(ResourcesCode));
            if (!exists)
            {
                CommonService.Model.KMS.K_Resources resources = _resourcesWCF.GetModel(new Guid(ResourcesCode));
                //资源收藏次数+1
                if (resources.K_Resources_collectionCount == null)
                {
                    resources.K_Resources_collectionCount = 0;
                }
                resources.K_Resources_collectionCount = resources.K_Resources_collectionCount + 1;
                bool isCollectionResources = _resourcesWCF.Update(resources);

                CommonService.Model.KMS.K_study study = new CommonService.Model.KMS.K_study();
                study.K_study_code = Guid.NewGuid();
                study.K_Resources_code = new Guid(ResourcesCode);
                study.K_study_isDelete = false;
                study.K_study_creator = Context.UIContext.Current.RootUserCode;
                study.K_study_createTime = DateTime.Now;

                int isStudy = _studyWCF.Add(study);

                if (isCollectionResources && isStudy > 0)
                {
                    flag = 1;
                }
            }

            return Json(flag);
        }
        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            List<CommonService.Model.KMS.K_Knowledge> knowledgeList = _knowledgeWCF.GetAllList();
            ViewBag.KnowlwedgeList = knowledgeList;
            //法院集合
            List<CommonService.Model.C_Court> CourtItems = _courtWCF.GetAllList();
            string userHtml = "";
            userHtml += "<option value='all'>全部</option>";
            foreach (var court in CourtItems)
            {
                    userHtml += "<option value=" + court.C_Court_code + ">" + court.C_Court_name + "</option>";
            }
            ViewBag.userhtml = userHtml;
            //业务流程集合
            List<CommonService.Model.FlowManager.P_Flow> FlowItems = _flowWCF.GetListByFlowType(Convert.ToInt32(FlowTypeEnum.案件));
            ViewBag.flowItems = FlowItems;
            List<CommonService.Model.FlowManager.P_Flow_form> formItems = _flowformWCF.GetListByFlowCode(FlowItems[0].P_Flow_code.Value);
            ViewBag.formItem = formItems;
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.regionList = regionList;
        }

        #region 为当前登录人添加浏览记录

        /// <summary>
        /// 为当前登录人添加浏览记录
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="resourcesCode"></param>
        private void AddBrowse(Guid userCode, Guid resourcesCode)
        {
            //查询当前登录人是否有此资源浏览记录，如果有更新浏览时间
            CommonService.Model.KMS.K_Resources_Browse browse = _resourcesBrowseWCF.ExistsBrowse(userCode, resourcesCode);
            if (browse != null)
            {
                browse.K_Resources_Browse_createTime = DateTime.Now;
                _resourcesBrowseWCF.Update(browse);
            }
            else
            {
                CommonService.Model.KMS.K_Resources_Browse browseModel = new CommonService.Model.KMS.K_Resources_Browse();
                browseModel.Userinfo_code = userCode;
                browseModel.K_Resources_code = resourcesCode;
                browseModel.K_Resources_Browse_createTime = DateTime.Now;
                browseModel.K_Resources_Browse_isDelete = false;
                int count = _resourcesBrowseWCF.Add(browseModel);
            }
        }

        #endregion

        private string PostWebRequest(string postUrl, string paramData, Encoding dataEncode)
        {
            string ret = string.Empty;
            byte[] byteArray = dataEncode.GetBytes(paramData); //转化
            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
            webReq.Method = "POST";
            webReq.ContentType = "application/x-www-form-urlencoded";

            webReq.ContentLength = byteArray.Length;
            Stream newStream = webReq.GetRequestStream();
            newStream.Write(byteArray, 0, byteArray.Length);//写入参数
            newStream.Close();
            HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
            ret = sr.ReadToEnd();
            sr.Close();
            response.Close();
            newStream.Close();
            return ret;
        }

    }
}