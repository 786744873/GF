using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.KMS.Controllers
{
    public class StudyController : BaseController
    {
        private readonly ICommonService.KMS.IK_study _studyWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.SysManager.IC_Roles _rolesWCF;
        private readonly ICommonService.KMS.IK_Resources _resourcesWCF;
        private readonly ICommonService.KMS.IK_Problem _problemWCF;
        private readonly ICommonService.KMS.IK_Knowledge _knowledgeWCF;
        private readonly ICommonService.KMS.IK_Comments _commentsWCF;
        private readonly ICommonService.KMS.IK_Resources_Browse _resourcesBrowseWCF;
        //
        // GET: /KMS/Problem/
        public StudyController()
        {
            #region 服务初始化
            _studyWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_study>("K_studyWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _rolesWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Roles>("RolesWCF");
            _resourcesWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Resources>("K_ResourcesWCF");
            _problemWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Problem>("K_ProblemWCF");
            _knowledgeWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Knowledge>("K_KnowledgeWCF");
            _commentsWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Comments>("K_CommentsWCF");
            _resourcesBrowseWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Resources_Browse>("K_Resources_BrowseWCF");
            #endregion
        }


        #region 个人中心主页

        /// <summary>
        /// 个人中心
        /// </summary>
        /// <returns></returns>
        public ActionResult DefaultLayout()
        {
            //取用户角色
            //int roleId = 0;
            //if (!Context.UIContext.Current.IsPreSetManager)
            //{
            //    int.Parse(Context.UIContext.Current.RoleId.ToString());
            //}
            //CommonService.Model.SysManager.C_Roles role = _rolesWCF.GetModel(roleId);
            //if (role != null)
            //{
            //    ViewBag.roleName = role.C_Roles_name;
            //}
            //else
            //{
            //    ViewBag.roleName = string.Empty;
            //}

            //问题
            CommonService.Model.KMS.K_Problem problem = new CommonService.Model.KMS.K_Problem();
            problem.K_Problem_creator = Context.UIContext.Current.RootUserCode;
            problem.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.已解决);
            int SettledNumber = _problemWCF.GetRecordCount(problem);//已解决问题
            ViewBag.SettledNumber = SettledNumber;
            problem.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.未解决);
            int UnresolvedNumber = _problemWCF.GetRecordCount(problem);//未解决问题
            ViewBag.UnresolvedNumber = UnresolvedNumber;
            problem.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.已回答);
            int AnswerNumber = _problemWCF.GetRecordCount(problem);//已回答问题
            ViewBag.AnswerNumber = AnswerNumber;
            return View();
        }

        #endregion

        #region 个人中心

        public ActionResult PersonalCenter()
        {
            //我的文档/视频
            CommonService.Model.KMS.K_Resources resource = new CommonService.Model.KMS.K_Resources();
            int DocumentNumber = 0;
            int VideoQuantity = 0;
            int ArticleQuantity = 0;
            int ImgNumber = 0;
            //在个人中心，不论谁，都只能看到自己的
            //if (!Context.UIContext.Current.IsPreSetManager)
            //{
            resource.K_Resources_creator = Context.UIContext.Current.RootUserCode;
            DocumentNumber = _resourcesWCF.MyDocumentAndVideoListCount(resource, 1);
            VideoQuantity = _resourcesWCF.MyDocumentAndVideoListCount(resource, 2);
            ArticleQuantity = _resourcesWCF.MyDocumentAndVideoListCount(resource, 3);
            ImgNumber = _resourcesWCF.MyDocumentAndVideoListCount(resource, 4);
            //}
            //else
            //{
            //    DocumentNumber = _resourcesWCF.MyDocumentAndVideoListCount(resource, 1);
            //    VideoQuantity = _resourcesWCF.MyDocumentAndVideoListCount(resource, 2);
            //    ArticleQuantity = _resourcesWCF.MyDocumentAndVideoListCount(resource, 3);
            //    ImgNumber = _resourcesWCF.MyDocumentAndVideoListCount(resource, 4);
            //}
            ViewBag.DocumentNumber = DocumentNumber;//文档
            ViewBag.VideoQuantity = VideoQuantity;//视频
            ViewBag.ArticleQuantity = ArticleQuantity;//文章
            ViewBag.ImgNumber = ImgNumber;//图片
            
            CommonService.Model.KMS.K_Comments comments = new CommonService.Model.KMS.K_Comments();
            //我的问答
            comments.K_Comments_creator = Context.UIContext.Current.RootUserCode;
            comments.K_Comments_type = 876;
            int myAnswerNum = _commentsWCF.GetRecordCount(comments);
            ViewBag.myAnswerNum = myAnswerNum;
            //我的评论
            comments.K_Comments_type = 875;
            int myCommentNum = _commentsWCF.GetRecordCount(comments);
            ViewBag.myCommentNum = myCommentNum;

            //最近收藏
            List<CommonService.Model.KMS.K_study> studyList = new List<CommonService.Model.KMS.K_study>();
            studyList = _studyWCF.GetListByCreatorTime(Context.UIContext.Current.RootUserCode.Value, 8);
            ViewBag.studyList = studyList;
            //最近上传
            List<CommonService.Model.KMS.K_Resources> resourcesList = new List<CommonService.Model.KMS.K_Resources>();
            string userCode = Context.UIContext.Current.RootUserCode.ToString();
            resourcesList = _resourcesWCF.GetListByRecentUpload(new Guid(userCode), 4);
            ViewBag.resourcesList = resourcesList;
            //最近浏览
            List<CommonService.Model.KMS.K_Resources_Browse> browseList = new List<CommonService.Model.KMS.K_Resources_Browse>();
            browseList = _resourcesBrowseWCF.GetListByCreatorTime(Context.UIContext.Current.RootUserCode.Value, 3);
            ViewBag.browseList = browseList;
            return View();
        }

        #endregion

        #region 我的评论/我的回答

        /// <summary>
        /// 我的评论
        /// </summary>
        /// <returns></returns>
        public ActionResult MyComments(string type)
        {
            InitializationPageParameter();
            if (type == null || type == "")
                type = "875";

            ViewBag.tabType = type;

            return View();
        }
        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult AjaxMyCommentslist(jQueryDataTableParamModel param)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.KMS.K_Comments Conditon = new CommonService.Model.KMS.K_Comments();
            Conditon.K_Comments_creator = Context.UIContext.Current.RootUserCode;

            string CommentType = Request.Params.Get("CommentType");
            if (CommentType != null && CommentType != "")
            {
                Conditon.K_Comments_type = Convert.ToInt32(CommentType);
            }

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_title");
                if (title != null && title != "")
                {
                    Conditon.K_Comments_content = title;
                }

                #endregion
            }

            #endregion

            #region 分页数据处理

            //总记录数
            this.TotalRecordCount = _commentsWCF.GetRecordCount(Conditon);
            //数据信息
            List<CommonService.Model.KMS.K_Comments> comments = null; //_commentsWCF.GetResourcesCommentListByPage(Conditon,"", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            if (CommentType == "875")//获取资源评论
            {
                comments = _commentsWCF.GetResourcesCommentListByPage(Conditon,
                "", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            }
            if (CommentType == "876")//获取问吧回答
            {
                comments = _commentsWCF.GetProblemCommentListByPage(Conditon,
                    "", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            }
            //转化数据格式
            var result = from c in comments
                         select new[] { 
                 c.K_Comments_code.ToString(),
                 c.K_Resources_type.ToString(),
                 c.K_Resources_url,
                 c.P_FK_code.ToString(),
                 c.K_Comments_type.ToString(),
                 c.K_Comments_parentName,
                 c.K_Comments_typeName, 
                 c.C_Userinfo_name,
                 c.K_Comments_content,
                 c.K_Comments_createTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                 c.K_Comments_score.ToString(),
                 c.K_Comments_helpfulCount==false ? "否" : "是"
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

        #endregion

        #region 我的收藏

        /// <summary>
        /// 我的收藏
        /// </summary>
        /// <returns></returns>
        public ActionResult MyCollection()
        {
            InitializationPageParameter();

            return View();
        }
        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult AjaxMyCollectionlist(jQueryDataTableParamModel param)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.KMS.K_study Conditon = new CommonService.Model.KMS.K_study();
            Conditon.K_study_creator = Context.UIContext.Current.RootUserCode;

            //收藏资源类型
            string collectionResourcesType = Request.Params.Get("collectionResourcesType");
            if (collectionResourcesType != null && collectionResourcesType != "")
            {
                Conditon.K_Resources_type = Convert.ToInt32(collectionResourcesType);
            }

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_title");
                if (title != null && title != "")
                {
                    Conditon.K_Resources_name = title;
                }

                #endregion
            }

            #endregion

            #region 分页数据处理

            //总记录数
            this.TotalRecordCount = _studyWCF.GetRecordCount(Conditon);
            //数据信息
            List<CommonService.Model.KMS.K_study> redources = _studyWCF.GetListByPage(Conditon,
                "", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            //转化数据格式
            var result = from c in redources
                         select new[] { 
                 c.K_Resources_code.ToString(),
                 c.K_Resources_type.ToString(),
                 c.K_Resources_url,
                 c.K_study_code.ToString(),
                 c.K_Resources_name,
                 c.K_study_createTime.ToString()

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
        /// <param name="studyCode"></param>
        /// <returns></returns>
        public ActionResult Delete(string studyCode)
        {
            bool isSuccess = _studyWCF.Delete(new Guid(studyCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除信息成功！", "/kms/study/MyCollection", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        #endregion

        #region 我的分享

        /// <summary>
        /// 我的分享
        /// </summary>
        /// <returns></returns>
        public ActionResult MyDocument(string type)
        {
            InitializationPageParameter();
            ViewBag.DocType = type;

            return View();
        }
        /// <summary>
        /// Ajax获取我的分享列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult AjaxMyDocumentlist(jQueryDataTableParamModel param)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.KMS.K_Resources Conditon = new CommonService.Model.KMS.K_Resources();
            Conditon.K_Resources_creator = Context.UIContext.Current.RootUserCode;

            //资源状态查询
            string state = Request.Params.Get("documentResourcesState");
            if (state != null && state != "")
            {
                Conditon.K_Resources_state = Convert.ToInt32(state);
            }

            //资源类型查询
            string type = Request.Params.Get("documentResourcesType");
            if (type != null && type != "")
            {
                Conditon.K_Resources_type = Convert.ToInt32(type);
            }

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_title");
                if (title != null && title != "")
                {
                    Conditon.K_Resources_name = title;
                }

                #endregion
            }

            #endregion

            #region 分页数据处理

            //总记录数
            this.TotalRecordCount = _resourcesWCF.GetRecordCount(Conditon);
            //数据信息
            List<CommonService.Model.KMS.K_Resources> redources = _resourcesWCF.GetListByPage(Conditon, "", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);//数据信息

            //转化数据格式
            var result = from c in redources
                         select new[] { 
                 c.K_Resources_code.ToString(),
                 c.K_Resources_type.ToString(),
                 c.K_Resources_url,
                 c.K_Resources_name, 
                 c.K_Resources_typeName.ToString(),
                 c.K_Resources_stateName,
                 c.K_Resources_Situation
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

        #endregion

        #region 我的问题

        /// <summary>
        /// 我的问题
        /// </summary>
        /// <returns></returns>
        public ActionResult MyProblem(string type)
        {
            InitializationPageParameter();

            if (type == null)
                type = "1";

            ViewBag.tabType = type;

            return View();
        }

        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxMyPromblemList(jQueryDataTableParamModel param)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.KMS.K_Problem Conditon = new CommonService.Model.KMS.K_Problem();

            if (!Context.UIContext.Current.IsPreSetManager)
            {
                Conditon.K_Problem_creator = Context.UIContext.Current.RootUserCode;
            }

            #region 查询项处理

            string tabType = Request.Params.Get("tabType");
            if (tabType == "1")
            {
                Conditon.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.已解决);
            }
            if (tabType == "2")
            {
                Conditon.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.未解决);
            }

            #endregion

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
                 c.K_Problem_creatorName,
                 c.K_Problem_createTime.Value.ToString("yyyy/MM/dd"),
                 c.K_Problem_AnswerCount.ToString()
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

        #endregion

        #region 我的浏览历史

        /// <summary>
        /// 浏览历史
        /// </summary>
        /// <returns></returns>
        public ActionResult MyBrowse()
        {
            InitializationPageParameter();

            return View();
        }
        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxMyBrowselist(jQueryDataTableParamModel param)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.KMS.K_Resources_Browse Conditon = new CommonService.Model.KMS.K_Resources_Browse();
            Conditon.Userinfo_code = Context.UIContext.Current.RootUserCode.Value;

            //浏览资源类型
            string browseResourcesType = Request.Params.Get("browseResourcesType");
            if (browseResourcesType != null && browseResourcesType != "")
            {
                Conditon.K_Resources_type = Convert.ToInt32(browseResourcesType);
            }

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_title");
                if (title != null && title != "")
                {
                    Conditon.K_Resources_name = title;
                }

                #endregion
            }

            #endregion

            #region 分页数据处理

            //总记录数
            this.TotalRecordCount = _resourcesBrowseWCF.GetRecordCount(Conditon);
            //数据信息
            List<CommonService.Model.KMS.K_Resources_Browse> redources = _resourcesBrowseWCF.GetListByPage(Conditon,
                "", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            //转化数据格式
            var result = from c in redources
                         select new[] { 
                 c.K_Resources_code.ToString(),
                 c.K_Resources_Browse_id.ToString(),
                 c.K_Resources_type.ToString(),
                 c.K_Resources_url,
                 c.K_Resources_name,
                 c.K_Resources_typeName,
                 c.K_Resources_KnowledgeName,
                 c.K_Resources_Browse_createTime.ToString()

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
        /// 删除浏览记录
        /// </summary>
        /// <param name="browserid"></param>
        /// <returns></returns>
        public ActionResult DeleteBrowse(int browserid)
        {
            bool isSuccess = _resourcesBrowseWCF.Delete(browserid);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除信息成功！", "/kms/study/MyBrowse", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        #endregion

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //资源状态参数集合
            List<CommonService.Model.C_Parameters> ResourcesState = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(ResourcesEnum.资源状态));
            ViewBag.ResourcesState = ResourcesState;
            List<CommonService.Model.C_Parameters> ResourcesType = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(ResourcesEnum.资源类型));
            ViewBag.ResourcesType = ResourcesType;
            //资源状态参数集合
            List<CommonService.Model.C_Parameters> CommentsType = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CommentsEunm.评论类型));
            ViewBag.CommentsType = CommentsType;

            //问题
            CommonService.Model.KMS.K_Problem problem = new CommonService.Model.KMS.K_Problem();
            problem.K_Problem_creator = Context.UIContext.Current.RootUserCode;
            problem.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.已解决);
            int SettledNumber = _problemWCF.GetRecordCount(problem);//已解决问题
            ViewBag.SettledNumber = SettledNumber;
            problem.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.未解决);
            int UnresolvedNumber = _problemWCF.GetRecordCount(problem);//未解决问题
            ViewBag.UnresolvedNumber = UnresolvedNumber;
            problem.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.已回答);
            int AnswerNumber = _problemWCF.GetRecordCount(problem);//已回答问题
            ViewBag.AnswerNumber = AnswerNumber;
        }
    }
}