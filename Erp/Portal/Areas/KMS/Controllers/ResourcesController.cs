using CommonService.Common;
using Maticsoft.Common;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Portal.Controllers;
using Portal.Hubs;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.KMS.Controllers
{
    public class ResourcesController : BaseController
    {
        private readonly ICommonService.KMS.IK_Resources _resourcesWCF;
        private readonly ICommonService.KMS.IK_Knowledge _knowledgeWCF;
        private readonly ICommonService.KMS.IK_Keyword _keywordWCF;
        private readonly ICommonService.KMS.IK_Keyword_Resources _keyword_ResourcesWCF;
        private readonly ICommonService.KMS.IK_Knowledge_Resources knowledge_ResourcesWCF;
        private readonly ICommonService.KMS.IK_Problem _problemWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.KMS.IK_Comments _commentsWCF;
        private readonly ICommonService.KMS.IK_Resources_zambia _resources_zambiaWCF;
        private readonly ICommonService.KMS.IK_study _studyWCF;
        private readonly ICommonService.IC_Messages _messageWCF;
        private readonly ICommonService.KMS.IK_Resources_Cover _resources_CoverWCF;
        private readonly ICommonService.KMS.IK_Resources_Browse _resourcesBrowseWCF;
        private readonly ICommonService.KMS.IK_Browse_Log _browserLogWCF;
        private readonly ICommonService.IC_Court _courtWCF;
        private readonly ICommonService.FlowManager.IP_Flow _flowWCF;
        private readonly ICommonService.FlowManager.IP_Flow_form _flowformWCF;
        private readonly ICommonService.KMS.IK_PorblemAndResources_LinkCase _porblemAndResources_LinkCaseWCF;
        private readonly ICommonService.IC_Region _regionWCF;

        CommonService.Common.Office2PDFHelper OfficePDF = new CommonService.Common.Office2PDFHelper();
        public ResourcesController()
        {
            #region 服务初始化
            _resourcesWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Resources>("K_ResourcesWCF");
            _knowledgeWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Knowledge>("K_KnowledgeWCF");
            _keywordWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Keyword>("K_KeywordWCF");
            _keyword_ResourcesWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Keyword_Resources>("K_Keyword_ResourcesWCF");
            knowledge_ResourcesWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Knowledge_Resources>("K_Knowledge_ResourcesWCF");
            _problemWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Problem>("K_ProblemWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _commentsWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Comments>("K_CommentsWCF");
            _resources_zambiaWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Resources_zambia>("K_Resources_zambiaWCF");
            _studyWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_study>("K_studyWCF");
            _messageWCF = ServiceProxyFactory.Create<ICommonService.IC_Messages>("MessagesWCF");
            _resources_CoverWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Resources_Cover>("K_Resources_CoverWCF");
            _resourcesBrowseWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Resources_Browse>("K_Resources_BrowseWCF");
            _browserLogWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Browse_Log>("K_Browse_LogWCF");
            _courtWCF = ServiceProxyFactory.Create<ICommonService.IC_Court>("CourtWCF");
            _flowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow>("FlowWCF");
            _flowformWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow_form>("Flow_formWCF");
            _porblemAndResources_LinkCaseWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_PorblemAndResources_LinkCase>("K_PorblemAndResources_LinkCaseWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
            #endregion
        }

        /// <summary>
        /// 附件存放主目录
        /// </summary>
        string attachmentMainPath = ConfigurationManager.AppSettings["AttachmentStoreMainPath"];
        /// <summary>
        /// 附件显示主目录
        /// </summary>
        string attachmentShowMainPath = ConfigurationManager.AppSettings["AttachmentShowMainPath"];
        //
        // GET: /KMS/Resources/
        /// <summary>
        /// 资源管理首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DefaultLayout()
        {
            #region 获取资源对应数量
            CommonService.Model.KMS.K_Resources model = new CommonService.Model.KMS.K_Resources();
            int allRCount = _resourcesWCF.GetRecordCount(model);
            model.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.视频);
            int aviCount = _resourcesWCF.GetRecordCount(model);
            model.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.word);
            int wordCount = _resourcesWCF.GetRecordCount(model);
            model.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.pdf);
            int pdfCount = _resourcesWCF.GetRecordCount(model);
            model.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.excel);
            int excelCount = _resourcesWCF.GetRecordCount(model);
            model.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.ppt);
            int pptCount = _resourcesWCF.GetRecordCount(model);
            model.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.图片);
            int jpgCount = _resourcesWCF.GetRecordCount(model);
            model.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.文章);
            int articleCount = _resourcesWCF.GetRecordCount(model);
            ViewBag.allRCount = allRCount;
            ViewBag.aviCount = aviCount;//视频
            ViewBag.jpgCount = jpgCount;//图片
            ViewBag.wordCount = wordCount + pdfCount + excelCount + pptCount;//文档
            ViewBag.articleCount = articleCount;//文章
            #endregion

            #region  获取当月上传资源对应数量
            model.K_Resources_type = null;
            int allRCountM = _resourcesWCF.GetRecordCount(model);
            model.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.视频);
            int aviCountM = _resourcesWCF.GetRecordCountByMonth(model);
            model.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.word);
            int wordCountM = _resourcesWCF.GetRecordCountByMonth(model);
            model.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.pdf);
            int pdfCountM = _resourcesWCF.GetRecordCountByMonth(model);
            model.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.excel);
            int excelCountM = _resourcesWCF.GetRecordCountByMonth(model);
            model.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.ppt);
            int pptCountM = _resourcesWCF.GetRecordCountByMonth(model);
            model.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.图片);
            int jpgCountM = _resourcesWCF.GetRecordCountByMonth(model);
            model.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.文章);
            int articleCountM = _resourcesWCF.GetRecordCountByMonth(model);
            ViewBag.allRCountM = allRCountM;
            ViewBag.aviCountM = aviCountM;//视频
            ViewBag.jpgCountM = jpgCountM;//图片
            ViewBag.wordCountM = wordCountM + pdfCountM + excelCountM + pptCountM;//文档
            ViewBag.articleCountM = articleCountM;//文章

            #endregion

            #region 获取问题对应数量
            CommonService.Model.KMS.K_Problem modelP = new CommonService.Model.KMS.K_Problem();
            int allCount = _problemWCF.GetRecordCount(modelP);
            modelP.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.未解决);
            int wjCount = _problemWCF.GetRecordCount(modelP);
            modelP.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.已解决);
            int yjCount = _problemWCF.GetRecordCount(modelP);
            modelP.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.已回答);
            int yhCount = _problemWCF.GetRecordCount(modelP);
            modelP.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.未回答);
            int whCount = _problemWCF.GetRecordCount(modelP);
            ViewBag.allCount = allCount;
            ViewBag.wjCount = wjCount;
            ViewBag.yjCount = yjCount;
            ViewBag.yhCount = yhCount;
            ViewBag.whCount = whCount;
            #endregion

            #region 获取当月问题对应数量
            CommonService.Model.KMS.K_Problem modelM = new CommonService.Model.KMS.K_Problem();
            int allCountM = _problemWCF.GetRecordCountByMonth(modelM);
            modelM.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.未解决);
            int wjCountM = _problemWCF.GetRecordCountByMonth(modelM);
            modelM.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.已解决);
            int yjCountM = _problemWCF.GetRecordCountByMonth(modelM);
            modelM.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.已回答);
            int yhCountM = _problemWCF.GetRecordCountByMonth(modelM);
            modelM.K_Problem_statue = Convert.ToInt32(ProblemStateEnum.未回答);
            int whCountM = _problemWCF.GetRecordCountByMonth(modelM);
            ViewBag.allCountM = allCountM;
            ViewBag.wjCountM = wjCountM;
            ViewBag.yjCountM = yjCountM;
            ViewBag.yhCountM = yhCountM;
            ViewBag.whCountM = whCountM;
            #endregion

            #region 获得评论数量
            CommonService.Model.KMS.K_Comments modelC = new CommonService.Model.KMS.K_Comments();
            int allComCount = _commentsWCF.GetRecordCount(modelC);
            ViewBag.allComCount = allComCount;
            #endregion

            return View();
        }
        /// <summary>
        /// 资源上传
        /// </summary>
        /// <param name="resourceesCode">资源Guid</param>
        /// <param name="type">1、知识库维护页面 2、我的分享页面</param>
        /// <returns></returns>
        public ActionResult Upload(string resourceesCode, int? type, string reflash, string court, string flow, string form, string caseArea)
        {
            ViewBag.caseArea = caseArea;
            CommonService.Model.KMS.K_Resources resources = new CommonService.Model.KMS.K_Resources();
            CommonService.Model.KMS.K_PorblemAndResources_LinkCase linkModel = new CommonService.Model.KMS.K_PorblemAndResources_LinkCase();
            if (!string.IsNullOrEmpty(flow))
                linkModel.K_ProblemAndResources_LinkCase_BusinessFlowcode = new Guid(flow);
            if (!string.IsNullOrEmpty(form))
                linkModel.K_ProblemAndResources_LinkCase_Formcode = new Guid(form);
            if (resourceesCode != "")
            {
                resources = _resourcesWCF.GetModel(new Guid(resourceesCode));
                CommonService.Model.KMS.K_PorblemAndResources_LinkCase condTion = new CommonService.Model.KMS.K_PorblemAndResources_LinkCase();
                condTion.C_FK_code = resources.K_Resources_code.Value;
                linkModel = _porblemAndResources_LinkCaseWCF.GetModelByModel(condTion);
                InitializationPageParameter(linkModel);
            }
            else
            {
                resources.K_Resources_code = Guid.NewGuid();
                resources.K_Resources_state = Convert.ToInt32(ResourcesStateEnum.未审核);
                resources.K_Resources_creator = Context.UIContext.Current.RootUserCode;
                resources.K_Resources_isDelete = false;
                InitializationPageParameter(linkModel);
            }
            //reflash=myshare3 则为知识维护修改，知识类型只能看到权限下的
            List<CommonService.Model.KMS.K_Knowledge> knowledgeList = new List<CommonService.Model.KMS.K_Knowledge>();
            if (reflash == "myshare3")
            {
                if (!Context.UIContext.Current.IsPreSetManager)
                {
                    knowledgeList = _knowledgeWCF.GetAllListByPerson(Context.UIContext.Current.RootUserCode.Value);
                }
                else
                {
                    knowledgeList = _knowledgeWCF.GetAllList();
                }
            }
            else
            {
                knowledgeList = _knowledgeWCF.GetAllList();
            }
            ViewBag.linkModel = linkModel;
            ViewBag.KnowlwedgeList = knowledgeList;
            List<CommonService.Model.KMS.K_Resources_Cover> listCover = _resources_CoverWCF.GetStartList();
            ViewBag.listCover = listCover;
            ViewBag.type = type;
            ViewBag.reflash = reflash;//刷新页面
            InitializationPageParameter();
            return View(resources);
        }
        /// <summary>
        /// 资源维护
        /// </summary>
        /// <returns></returns>
        public ActionResult List(string knowledgeCode)
        {
            InitializationPageParameter();
            //获取所有知识分类
            List<CommonService.Model.KMS.K_Knowledge> listK = new List<CommonService.Model.KMS.K_Knowledge>();
            if (Context.UIContext.Current.IsPreSetManager)
            {
                listK = _knowledgeWCF.GetAllList();
                ViewBag.listK = listK;
            }
            else
            {
                listK = _knowledgeWCF.GetAllListByPerson(Context.UIContext.Current.RootUserCode.Value);
                ViewBag.listK = listK;
            }
            if (!String.IsNullOrEmpty(knowledgeCode))
            {
                ViewBag.knowledgeCode = knowledgeCode;
            }
            else
            {
                ViewBag.knowledgeCode = "";
            }
            return View();
        }
        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult Ajaxlist(jQueryDataTableParamModel param, string knowledgeCode)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.KMS.K_Resources Conditon = new CommonService.Model.KMS.K_Resources();
            if (!String.IsNullOrEmpty(knowledgeCode))
            {
                Conditon.K_Resources_Knowledge_code = knowledgeCode;
            }
            if (!Context.UIContext.Current.IsPreSetManager)
            {//资源所属知识分类负责人
                Conditon.K_Resources_Knowledge_person = Context.UIContext.Current.RootUserCode.Value;
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
                string state = Request.Params.Get("i_state");
                if (state != null && state != "-1")
                {
                    Conditon.K_Resources_state = Convert.ToInt32(state);
                }
                string type = Request.Params.Get("i_type");
                if (type != null && type != "-1")
                {
                    Conditon.K_Resources_type = Convert.ToInt32(type);
                }

                #endregion
            }

            #endregion

            #region 分页数据处理

            //总记录数
            this.TotalRecordCount = _resourcesWCF.GetRecordCount(Conditon);
            //数据信息
            List<CommonService.Model.KMS.K_Resources> redources = _resourcesWCF.GetListByPage(Conditon,
                "", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            //转化数据格式
            var result = from c in redources
                         select new[] { 
                 c.K_Resources_code.ToString(),
                 c.K_Resources_type.ToString(),
                 c.K_Resources_name, 
                 c.K_Resources_url,
                 c.K_Resources_creatorName.ToString(),
                 c.K_Resources_createTime.ToString(),
                 c.K_Resources_Knowledge_name,
                 c.K_Resources_typeName,
                 c.K_Resources_stateName,
                 c.K_Resources_Permissions.ToString()
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

        public ActionResult Search()
        {

            InitializationPageParameter();

            CommonService.Model.KMS.K_Resources model = new CommonService.Model.KMS.K_Resources();
            //model.K_Resources_state = Convert.ToInt32(ResourcesStateEnum.已发布);
            model.K_Resources_creator = Context.UIContext.Current.RootUserCode;
            model.K_Resources_type = 827;
            int aviCount = _resourcesWCF.GetRecordCount(model);
            model.K_Resources_type = 1;
            int wordCount = _resourcesWCF.GetRecordCount(model);

            ViewBag.aviCounts = aviCount;
            ViewBag.wordCounts = wordCount;

            ViewBag.type = 1;

            return View();
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="form"></param>
        /// <param name="resources"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(FormCollection form, CommonService.Model.KMS.K_Resources resources)
        {
            #region 关键字处理
            if (resources.K_Resources_id > 0)
            {
                //删除原关键字与资源的关连
                _keyword_ResourcesWCF.DeleteByResourcesCode(resources.K_Resources_code.Value);
            }
            if (resources.K_Resources_Keyword != null && resources.K_Resources_Keyword.Trim() != "")
            {
                string[] Keywords = resources.K_Resources_Keyword.Split(',', '，');
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
                        keywordResourcesModel.K_Resources_code = resources.K_Resources_code.Value;
                    }
                    else
                    {
                        keywordResourcesModel.K_Keyword_code = new Guid(keyWordCode);
                        keywordResourcesModel.K_Resources_code = resources.K_Resources_code.Value;
                    }

                    keyword_ResourcesList.Add(keywordResourcesModel);
                }
                _keywordWCF.OperateList(keywordList);
                _keyword_ResourcesWCF.OperateList(keyword_ResourcesList);
            }
            #endregion

            #region 所属分类处理
            string Knowledge = form["K_Resources_Knowledge"];
            if (Knowledge != "")
            {
                if (resources.K_Resources_id > 0)
                {
                    //knowledge_ResourcesWCF.DeleteByFkCode(resources.K_Resources_code.Value);//删除之前的所属分类数据

                    //修改所属分类
                    CommonService.Model.KMS.K_Knowledge_Resources knowledge = knowledge_ResourcesWCF.GetModelByFkCode(resources.K_Resources_code.Value);
                    knowledge.P_FK_code = resources.K_Resources_code.Value;
                    knowledge.K_Knowledge_code = new Guid(Knowledge);

                    knowledge_ResourcesWCF.Update(knowledge);
                }
                else
                {
                    CommonService.Model.KMS.K_Knowledge_Resources knowledgeResourcesModel = new CommonService.Model.KMS.K_Knowledge_Resources();
                    knowledgeResourcesModel.K_Knowledge_Resources_code = Guid.NewGuid();
                    knowledgeResourcesModel.K_Knowledge_Resources_type = 1;
                    knowledgeResourcesModel.P_FK_code = resources.K_Resources_code.Value;
                    knowledgeResourcesModel.K_Knowledge_code = new Guid(Knowledge);
                    knowledgeResourcesModel.K_Knowledge_Resources_creator = Context.UIContext.Current.RootUserCode;
                    knowledgeResourcesModel.K_Knowledge_Resources_createTime = DateTime.Now;
                    knowledgeResourcesModel.K_Knowledge_Resources_isDelete = false;

                    knowledge_ResourcesWCF.Add(knowledgeResourcesModel);
                }
            }
            #endregion

            #region 文件上传处理
            string originalFileName = "";
            string imageName = "";
            string targetDirectory = "KmsResources";//附件存放文件夹
            string imageDirectory = "img";//封面图片存放位置
            try
            {
                if (Request.Files.Count != 0)
                {
                    #region 上传文件
                    if (resources.K_Resources_id == 0)
                    {
                        HttpFileCollectionBase files = Request.Files;
                        HttpPostedFileBase httpPostFile = files["resourcesFile"];
                        originalFileName = System.IO.Path.GetFileName(httpPostFile.FileName.ToString()); //得到原文件名         
                        if (originalFileName != "")
                        {
                            // 初始化byte长度.
                            byte[] file = new Byte[httpPostFile.ContentLength];
                            // 把附件写入byte中
                            System.IO.Stream stream = httpPostFile.InputStream;
                            stream.Read(file, 0, httpPostFile.ContentLength);
                            stream.Flush();
                            stream.Close();

                            //服务器附件根目录
                            //string mainPhyPath = attachmentMainPath;
                            string mainPhyPath = Server.MapPath("../../");
                            //服务器附件存放全目录
                            string attachPhyPath = mainPhyPath + "" + targetDirectory + "\\";
                            if (!Directory.Exists(attachPhyPath))
                            {
                                Directory.CreateDirectory(attachPhyPath);
                            }
                            //附件扩展名称
                            string extensionName = System.IO.Path.GetExtension(originalFileName).ToLower();
                            //附件名称
                            string fileCode = Guid.NewGuid().ToString().Replace('-', '_');
                            string fileName = fileCode + extensionName;
                            string attachmentFullPathName = attachPhyPath + fileName;
                            int fileLength = file.Length;

                            System.IO.FileStream fs = new System.IO.FileStream(attachmentFullPathName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                            fs.Write(file, 0, fileLength);
                            fs.Flush();
                            fs.Close();

                            #region 保存上传文件信息到数据库
                            resources.K_Resources_name = originalFileName;
                            resources.K_Resources_url = attachmentFullPathName;
                            resources.K_Resources_Extension = extensionName;
                            switch (extensionName)
                            {
                                case ".doc":
                                    resources.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.word);
                                    break;
                                case ".docx":
                                    resources.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.word);
                                    break;
                                case ".ppt":
                                    resources.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.ppt);
                                    break;
                                case ".pptx":
                                    resources.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.ppt);
                                    break;
                                case ".pps":
                                    resources.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.ppt);
                                    break;
                                case ".ppsx":
                                    resources.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.ppt);
                                    break;
                                case ".pdf":
                                    resources.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.pdf);
                                    break;
                                case ".xlsx":
                                    resources.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.excel);
                                    break;
                                case ".xls":
                                    resources.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.excel);
                                    break;
                                case ".jpg":
                                    resources.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.图片);
                                    break;
                                case ".png":
                                    resources.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.图片);
                                    break;
                                case ".gif":
                                    resources.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.图片);
                                    break;
                            }
                            #endregion

                            //文件格式转换
                            string fileType = extensionName.Substring(1, extensionName.Length - 1);//文件格式
                            string targetFolder = "KmsResourcesSWF";
                            string filePdfName = fileCode + ".pdf";
                            string targetPath = mainPhyPath + "" + targetFolder + "\\" + filePdfName;//目标文件路径
                            OfficePDF.FileFormatConversion(fileType, attachmentFullPathName, targetPath);
                        }
                    }
                    #endregion

                    #region 资源封面图片
                    HttpFileCollectionBase imgfiles = Request.Files;
                    HttpPostedFileBase httpPostFileImage = imgfiles["resourcesCoverImage"];
                    if (httpPostFileImage != null)
                    {
                        imageName = System.IO.Path.GetFileName(httpPostFileImage.FileName.ToString()); //得到图片原文件名   
                        if (imageName != "")
                        {
                            string imgextensionName = System.IO.Path.GetExtension(imageName).ToLower();
                            string imgfileCode = Guid.NewGuid().ToString().Replace('-', '_');
                            string imgfileName = imgfileCode + imgextensionName;
                            string mainPhyPath = Server.MapPath("../../");
                            // 初始化byte长度.
                            byte[] imagefile = new Byte[httpPostFileImage.ContentLength];
                            // 把附件写入byte中
                            System.IO.Stream imagestream = httpPostFileImage.InputStream;
                            imagestream.Read(imagefile, 0, httpPostFileImage.ContentLength);
                            imagestream.Flush();
                            imagestream.Close();
                            //服务器附件存放全目录
                            string imgattachPhyPath = mainPhyPath + "" + imageDirectory + "\\";
                            if (!Directory.Exists(imgattachPhyPath))
                            {
                                Directory.CreateDirectory(imgattachPhyPath);
                            }
                            string imgattachmentFullPathName = imgattachPhyPath + imgfileName;
                            int imgfileLength = imagefile.Length;

                            System.IO.FileStream imgfs = new System.IO.FileStream(imgattachmentFullPathName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                            imgfs.Write(imagefile, 0, imgfileLength);
                            imgfs.Flush();
                            imgfs.Close();
                            resources.K_Resources_coverImage = "\\" + imageDirectory + "\\" + imgfileName;
                        }
                    }
                    #region    二进制保存封面图片
                    //System.IO.Stream fsImage = httpPostFileImage.InputStream;
                    //Byte[] btye2 = new byte[fsImage.Length];
                    //fsImage.Read(btye2, 0, Convert.ToInt32(fsImage.Length));
                    //fsImage.Close();

                    ////资源封面图片赋值
                    //resources.K_Resources_coverImage = btye2;
                    #endregion

                    #endregion

                }
            }
            catch (Exception ex)
            {

            }
            #endregion

            //服务方法调用
            int resourcesId = 0;

            if (resources.K_Resources_id > 0)
            {//修改
                //获取原数据
                CommonService.Model.KMS.K_Resources oldresources = _resourcesWCF.GetModel(resources.K_Resources_code.Value);
                //如果封面图片为空，则保存原来的封面图
                if (resources.K_Resources_coverImage == null || resources.K_Resources_coverImage == "")
                    resources.K_Resources_coverImage = oldresources.K_Resources_coverImage;
                bool isUpdateSuccess = _resourcesWCF.Update(resources);
                if (isUpdateSuccess)
                {
                    #region 问题/文档/视频 关联业务流程表单表
                    string type = form["problemType"];
                    CommonService.Model.KMS.K_PorblemAndResources_LinkCase conModel = new CommonService.Model.KMS.K_PorblemAndResources_LinkCase();
                    conModel.C_FK_code = resources.K_Resources_code.Value;
                    CommonService.Model.KMS.K_PorblemAndResources_LinkCase linkModel = _porblemAndResources_LinkCaseWCF.GetModelByModel(conModel);
                    if (type == "1")
                    {
                        if (linkModel == null)
                        {
                            linkModel = new CommonService.Model.KMS.K_PorblemAndResources_LinkCase();
                            linkModel.K_ProblemAndResources_LinkCase_code = Guid.NewGuid();
                            linkModel.C_FK_code = resources.K_Resources_code.Value;
                            linkModel.K_ProblemAndResources_LinkCase_CourtListcode = form["K_ProblemAndResources_LinkCase_Courtcode"];
                            if (form["caseArea"] != "全部")
                            {
                                linkModel.K_ProblemAndResources_LinkCase_region = new Guid(form["caseArea"]);
                            }
                            linkModel.K_ProblemAndResources_LinkCase_BusinessFlowcode = new Guid(form["K_ProblemAndResources_LinkCase_BusinessFlowcode"]);
                            linkModel.K_ProblemAndResources_LinkCase_Formcode = new Guid(form["K_ProblemAndResources_LinkCase_Formcode"]);
                            linkModel.K_ProblemAndResources_LinkCase_type = 1;
                            _porblemAndResources_LinkCaseWCF.MutilyAdd(linkModel);
                        }
                        else
                        {
                            linkModel.K_ProblemAndResources_LinkCase_CourtListcode = form["K_ProblemAndResources_LinkCase_Courtcode"];
                            linkModel.K_ProblemAndResources_LinkCase_BusinessFlowcode = new Guid(form["K_ProblemAndResources_LinkCase_BusinessFlowcode"]);
                            linkModel.K_ProblemAndResources_LinkCase_Formcode = new Guid(form["K_ProblemAndResources_LinkCase_Formcode"]);
                            if (form["caseArea"] != "全部")
                            {
                                linkModel.K_ProblemAndResources_LinkCase_region = new Guid(form["caseArea"]);
                            }

                            _porblemAndResources_LinkCaseWCF.MutilyUpdate(linkModel);
                        }

                    }
                    else
                    {
                        if (linkModel != null)
                        {
                            _porblemAndResources_LinkCaseWCF.MutilyDelete(linkModel);
                        }
                    }
                    #endregion

                    resourcesId = resources.K_Resources_id;
                }
            }
            else
            {//增加

                DateTime now = DateTime.Now;
                resources.K_Resources_createTime = now;
                resources.K_Resources_Permissions = false;
                resourcesId = _resourcesWCF.Add(resources);
                if (resourcesId > 0)
                {
                    #region 问题/文档/视频 关联业务流程表单表
                    string type = form["problemType"];
                    if (type == "1")
                    {
                        CommonService.Model.KMS.K_PorblemAndResources_LinkCase linkModel = new CommonService.Model.KMS.K_PorblemAndResources_LinkCase();
                        linkModel.K_ProblemAndResources_LinkCase_code = Guid.NewGuid();
                        linkModel.C_FK_code = resources.K_Resources_code.Value;
                        linkModel.K_ProblemAndResources_LinkCase_CourtListcode = form["K_ProblemAndResources_LinkCase_Courtcode"];
                        linkModel.K_ProblemAndResources_LinkCase_BusinessFlowcode = new Guid(form["K_ProblemAndResources_LinkCase_BusinessFlowcode"]);
                        linkModel.K_ProblemAndResources_LinkCase_Formcode = new Guid(form["K_ProblemAndResources_LinkCase_Formcode"]);
                        linkModel.K_ProblemAndResources_LinkCase_type = 1;
                        if (form["caseArea"] != "全部")
                        {
                            linkModel.K_ProblemAndResources_LinkCase_region = new Guid(form["caseArea"]);
                        }

                        _porblemAndResources_LinkCaseWCF.MutilyAdd(linkModel);
                    }
                    #endregion
                }
            }
            //获取刷新页id
            string reflash = form["reflash"];
            string url = "/kms/resources/MyShare";
            if (reflash == "resourceslist")
            {
                url = "/kms/Resources/list";
            }
            else if (reflash == "myshare1")
            {
                url = "/kms/resources/MyShare?type=1";
            }
            else if (reflash == "myshare3")
            {
                url = "/kms/resources/MyShare?type=3";
            }
            if (resourcesId > 0)
            {
                return Json(TipHelper.JsonData("保存资源信息成功！", url, IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageGoAnotherPage));
            }
            else
            {
                //表单提交失败固定写法
                return Json(TipHelper.JsonData("保存资源信息失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// 查看资源
        /// </summary>
        /// <param name="resourceCode"></param>
        /// <returns></returns>
        public ActionResult SelectResources(string resourceCode, string msgID, int? type)
        {
            CommonService.Model.KMS.K_Resources resources = _resourcesWCF.GetModel(new Guid(resourceCode));

            if (resources == null)
            {
                return View();
            }
            #region  加载文档
            if (type == Convert.ToInt32(ResourcesTypeEnum.excel) || type == Convert.ToInt32(ResourcesTypeEnum.pdf) || type == Convert.ToInt32(ResourcesTypeEnum.ppt) || type == Convert.ToInt32(ResourcesTypeEnum.word) || type == Convert.ToInt32(ResourcesTypeEnum.图片))
            {
                string fileName = "";
                string filePath = "";
                if (resources != null)
                {
                    int index = resources.K_Resources_url.LastIndexOf("\\");
                    fileName = resources.K_Resources_url.Substring(index + 1, 36);
                    filePath = resources.K_Resources_url.Substring(index + 1, resources.K_Resources_url.Length - index - 1);
                }
                string cmdStr = fileName + ".swf";
                ViewBag.fileStr = cmdStr;
                ViewBag.filePath = filePath;
                ViewBag.type = 1;
            }
            else if (type == Convert.ToInt32(ResourcesTypeEnum.文章))
            {
                ViewBag.type = 2;
            }
            else
            {
                ViewBag.type = 3;
            }
            #endregion
            List<CommonService.Model.KMS.K_Comments> listCom = _commentsWCF.GetCommentsListByCode(new Guid(resources.K_Resources_code.ToString()));
            ViewBag.listCom = listCom;
            if (!string.IsNullOrEmpty(msgID))
            {
                CommonService.Model.C_Messages msgModel = _messageWCF.GetModel(Convert.ToInt32(msgID));//得到此条日程的提醒消息实体
                if (msgModel != null)
                { //存在此条消息提醒
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
            bool exists = _studyWCF.ExistsStudy(Context.UIContext.Current.RootUserCode.Value, new Guid(resourceCode));
            int flag = 0;
            if (exists)
                flag = 1;
            ViewBag.flag = flag;

            //判断是否点过赞或无用
            int zam = 0;
            CommonService.Model.KMS.K_Resources_zambia selectModel = new CommonService.Model.KMS.K_Resources_zambia();
            selectModel.K_Resources_code = new Guid(resourceCode);
            selectModel.C_Userinfo_code = Context.UIContext.Current.RootUserCode;
            CommonService.Model.KMS.K_Resources_zambia zamModel = _resources_zambiaWCF.GetModelByModel(selectModel);
            if (zamModel != null)
            {
                ViewBag.IsZam = zamModel.K_Resources_zambia_type;
            }
            else
            {
                ViewBag.IsZam = zam;
            }

            //添加用户浏览记录
            AddBrowse(Context.UIContext.Current.RootUserCode.Value, new Guid(resourceCode));

            //增加浏览量
            AddBrowseCount(resourceCode);
            //获取资源浏览量
            int browseCount = _browserLogWCF.GetBrowseCount(new Guid(resourceCode), "K_Browse_Log_usercode");
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
        /// 资源下载
        /// </summary>
        /// <param name="filePath">资源路劲</param>
        /// <param name="fileName">资源名称</param>
        /// <returns></returns>
        public FileStreamResult DownResources(string filePath, string resourcesCode)
        {
            CommonService.Model.KMS.K_Resources resources = _resourcesWCF.GetModel(new Guid(resourcesCode));
            if (resources.K_Resources_downloadCount == null)
                resources.K_Resources_downloadCount = 0;
            //下载次数+1
            resources.K_Resources_downloadCount = resources.K_Resources_downloadCount + 1;
            _resourcesWCF.Update(resources);

            string fileName = resources.K_Resources_name;
            string absoluFilePath = Server.MapPath("../../" + filePath);
            return File(new FileStream(absoluFilePath, FileMode.Open), "application/octet-stream", Server.UrlEncode(fileName));
        }
        /// <summary>
        /// 删除资源(多条删除)
        /// </summary>
        /// <param name="redourcesCode">资源Guid</param>
        /// <param name="type">1为多条删除</param>
        /// <param name="reflash">刷新页面</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string redourcesCode, string reflash)
        {
            bool isSuccess = _resourcesWCF.DeleteList(redourcesCode);

            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除资源信息成功！", reflash, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除资源信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// 资源审核
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ResourcesAudit(string resourcesCode, int state, string reflash)
        {
            bool isSuccess = _resourcesWCF.ResourcesAudit(resourcesCode, state);
            if (isSuccess)
            {//成功
                List<CommonService.Model.KMS.K_Resources> resourcesList = _resourcesWCF.GetListByCode(resourcesCode);
                foreach (var model in resourcesList)
                {
                    //处理视频审核时封面图片，如果视频没有封面图片，怎从优酷总获取视频封面地址
                    if (model.K_Resources_type == Convert.ToInt32(ResourcesTypeEnum.视频) && model.K_Resources_coverImage == null)
                    {
                        string url = @"https://openapi.youku.com/v2/videos/show_basic.json?client_id=46d33f35eb3b5080&video_id=" + model.K_Resources_url + "";
                        string strJson = new System.Net.WebClient().DownloadString(url);
                        if (!String.IsNullOrEmpty(strJson))
                        {
                            JObject jo = (JObject)JsonConvert.DeserializeObject(strJson);
                            model.K_Resources_coverImage = jo["thumbnail"].ToString();
                            _resourcesWCF.Update(model);
                        }
                    }
                }
                return Json(TipHelper.JsonData("操作成功！", reflash, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("操作失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 资源是否允许下载
        /// </summary>
        /// <param name="resourcesCode"></param>
        /// <param name="permissions"></param>
        /// <returns></returns>
        public ActionResult ResourcesPermissions(string resourcesCode, int permissions, string reflash)
        {
            bool isSuccess = _resourcesWCF.ResourcesPermissions(resourcesCode, permissions);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("操作成功！", reflash, IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("操作失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 装载父级知识分类
        /// </summary>
        private void SetSingleTopKnowledge(List<CommonService.Model.KMS.K_Knowledge> knowledgeList)
        {
            string knowledgeTreeHtml = "";
            string preTreeHtml = "<ul>";//树前缀
            string backTreeHtml = "</ul>";//树后缀
            var topOrganizationList = from allList in knowledgeList
                                      where allList.K_Knowledge_parent == null
                                      orderby allList.K_Knowledge_id ascending
                                      select allList;

            foreach (CommonService.Model.KMS.K_Knowledge knowledge in topOrganizationList)
            {
                string href = "";

                string uniqueId = knowledge.K_Knowledge_code.Value.ToString();

                knowledgeTreeHtml += "<li><a data-toggle=\"tab\" uniqueid=\"" + uniqueId + "\" href=\"" + href + "\"><i class=\"fa fa-briefcase\"></i>" + knowledge.K_Knowledge_name + "</a><span class=\"after\"></span>";

                SetSignleRecursionTree(knowledge.K_Knowledge_code.Value, ref knowledgeTreeHtml, knowledgeList);
                knowledgeTreeHtml += "</li>";
            }
            knowledgeTreeHtml += "</ul>";
            knowledgeTreeHtml += "</li>";
            ViewBag.SingleKnowledgeTreeHtml = preTreeHtml + knowledgeTreeHtml + backTreeHtml;
        }

        /// <summary>
        /// 递归加载所有组织机构(递归加载知识分类，默认指打开三级，其余的默认不打开)
        /// </summary>
        private void SetSignleRecursionTree(Guid parentCode, ref string knowledgeTreeHtml, List<CommonService.Model.KMS.K_Knowledge> knowledgeList)
        {
            var lowknowledgeList = from allList in knowledgeList
                                   where allList.K_Knowledge_parent == parentCode
                                   orderby allList.K_Knowledge_id ascending
                                   select allList;
            if (lowknowledgeList.Count() != 0)
            {
                knowledgeTreeHtml += "<ul>";
            }

            foreach (CommonService.Model.KMS.K_Knowledge knowledge in lowknowledgeList)
            {
                string href = "";

                string uniqueId = knowledge.K_Knowledge_code.Value.ToString();
                string jsTreeOpenClass = string.Empty;//不打开这些子组织机,如果要打开，则用：jsTreeOpenClass = "class=jstree-open"

                knowledgeTreeHtml += "<li " + jsTreeOpenClass + "><a data-toggle=\"tab\" uniqueid=\"" + uniqueId + "\" href=\"" + href + "\"><i class=\"fa fa-briefcase\"></i>" + knowledge.K_Knowledge_name + "</a>";

                SetSignleRecursionTree(knowledge.K_Knowledge_code.Value, ref knowledgeTreeHtml, knowledgeList);
                knowledgeTreeHtml += "</li>";
            }
            if (lowknowledgeList.Count() != 0)
            {
                knowledgeTreeHtml += "</ul>";
            }
        }
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
            CommonService.Model.KMS.K_Resources resource = _resourcesWCF.GetModel(new Guid(resourcesCode));
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
                    comments.K_Comments_content = comments.K_Comments_content.Length > 10 ? comments.K_Comments_content.Substring(0, 10) + "..." : comments.K_Comments_content;
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
                msgModel.C_Messages_person = resource.K_Resources_creator;
                msgModel.C_Messages_isRead = 0;
                msgModel.C_Messages_isValidate = 1;
                _messageWCF.Add(msgModel);
                //添加消息后  发送给审核人信息
                var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                var touser = ChatHub.userlist.FirstOrDefault(x => x.userCode == resource.K_Resources_creator.ToString());//查询资源创建人是否在线
                if (touser != null)
                {
                    comments.K_Comments_content = comments.K_Comments_content.Length > 10 ? comments.K_Comments_content.Substring(0, 10) + "..." : comments.K_Comments_content;
                    JsonHelper jh = new JsonHelper();
                    context.Clients.Client(touser.ConnectionId).sendFormSubMsg(jh.EntityToJson(comments));//接收消息人的数据集合
                }
                #endregion
            }
            if (isSuccess > 0)
            {//成功
                return Json(TipHelper.JsonData("回复成功！", "/kms/Resources/SelectResources?resourceCode=" + resourcesCode + "&type=" + resource.K_Resources_type + "", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshPartial));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("回复失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public ActionResult SearchResult(string keyWord, string knowledgeCode)
        {
            if (!String.IsNullOrEmpty(keyWord))
            {
                Random rd = new Random();
                string index = rd.Next().ToString();
                //索引服务器附件存放全目录
                string indexPath = Server.MapPath("../../") + "\\" + "indextemp" + "\\" + index;
                if (!Directory.Exists(indexPath))
                {
                    Directory.CreateDirectory(indexPath);
                }
                List<CommonService.Model.KMS.K_Resources> list = _resourcesWCF.SearchResources(indexPath, keyWord);
                ViewBag.listSearch = list;
                if (list.Count > 0)
                {
                    ViewBag.type = 2;
                }
                else
                {
                    ViewBag.type = 0;
                }
                InitializationPageParameter();
            }
            else if (!String.IsNullOrEmpty(knowledgeCode))
            {
                CommonService.Model.KMS.K_Resources resources = new CommonService.Model.KMS.K_Resources();
                resources.K_Resources_Knowledge_code = knowledgeCode;
                resources.K_Resources_state = 834;
                List<CommonService.Model.KMS.K_Resources> resourcesList = _resourcesWCF.GetListByPage(resources, "", 0, 1000);
                ViewBag.listSearch = resourcesList;
                if (resourcesList.Count > 0)
                {
                    ViewBag.type = 2;
                }
                else
                {
                    ViewBag.type = 0;
                }
                InitializationPageParameter();
            }
            else
                ViewBag.type = 1;
            ViewBag.keyword = keyWord;
            ViewBag.knowledgeCode = knowledgeCode;
            return View("Search");
        }
        /// <summary>
        /// 资源点赞
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ResourcesPraise(string ResourcesCode, int type)
        {
            int flag = 0;
            CommonService.Model.KMS.K_Resources_zambia selectModel = new CommonService.Model.KMS.K_Resources_zambia();
            selectModel.K_Resources_code = new Guid(ResourcesCode);
            selectModel.C_Userinfo_code = Context.UIContext.Current.RootUserCode;
            CommonService.Model.KMS.K_Resources_zambia zamModel = _resources_zambiaWCF.GetModelByModel(selectModel);
            if (zamModel == null)
            {
                CommonService.Model.KMS.K_Resources resources = _resourcesWCF.GetModel(new Guid(ResourcesCode));
                if (type == 1)
                {
                    //被赞次数+1
                    if (resources.K_Resources_zambiaCount == null)
                    {
                        resources.K_Resources_zambiaCount = 0;
                        resources.K_Resources_zambiaCount = resources.K_Resources_zambiaCount + 1;
                    }
                    else
                    {
                        resources.K_Resources_zambiaCount = resources.K_Resources_zambiaCount + 1;
                    }
                }
                else
                {
                    //没用次数+1
                    if (resources.K_Resources_nouserCount == null)
                    {
                        resources.K_Resources_nouserCount = 0;
                        resources.K_Resources_nouserCount = resources.K_Resources_nouserCount + 1;
                    }
                    else
                    {
                        resources.K_Resources_nouserCount = resources.K_Resources_nouserCount + 1;
                    }
                }
                if (_resourcesWCF.Update(resources))
                {
                    if (type == 1)
                        flag = 1;
                    else
                        flag = 2;
                    CommonService.Model.KMS.K_Resources_zambia model = new CommonService.Model.KMS.K_Resources_zambia();
                    model.K_Resources_code = resources.K_Resources_code;
                    model.C_Userinfo_code = Context.UIContext.Current.RootUserCode;
                    model.K_Resources_zambia_type = type;
                    model.K_Resources_zambia_createTime = DateTime.Now;
                    model.K_Resources_zambia_isDelete = false;
                    _resources_zambiaWCF.Add(model);
                }
            }
            return Json(flag);
        }

        /// <summary>
        /// 收藏资源
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ResourcesCollection(string ResourcesCode)
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
        /// 获取资源类型Type
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetType(string code)
        {
            CommonService.Model.KMS.K_Resources model = _resourcesWCF.GetModel(new Guid(code));
            int type = 1;
            if (model != null)
                type = Convert.ToInt32(model.K_Resources_type);
            return Json(type);
        }
        /// <summary>
        /// 我要分享
        /// </summary>
        /// <returns></returns>
        public ActionResult MyShare(int? type = 1)
        {
            InitializationPageParameter();
            List<CommonService.Model.KMS.K_Knowledge> knowledgeList = _knowledgeWCF.GetAllListByPerson(Context.UIContext.Current.RootUserCode.Value);
            ViewBag.knowledgesCount = knowledgeList.Count();
            if (Context.UIContext.Current.IsPreSetManager)
            {
                ViewBag.IsPreSetManager = "1";//当前是所属知识分类负责人
            }
            else
            {
                ViewBag.IsPreSetManager = "0";
            }
            ViewBag.type = type;
            return View();
        }
        /// <summary>
        /// 我的分享
        /// </summary>
        /// <returns></returns>
        public ActionResult MyShareDocuments()
        {
            InitializationPageParameter();
            return View();
        }
        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult AjaxMyShareDocumentslist(jQueryDataTableParamModel param)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.KMS.K_Resources Conditon = new CommonService.Model.KMS.K_Resources();
            Conditon.K_Resources_creator = Context.UIContext.Current.RootUserCode;

            string shareResourcesState = Request.Params.Get("shareResourcesState");
            string shareResourcesType = Request.Params.Get("shareResourcesType");
            if (shareResourcesState != null && shareResourcesState != "")
            {
                Conditon.K_Resources_state = Convert.ToInt32(shareResourcesState);
            }
            if (shareResourcesType != null && shareResourcesType != "")
            {
                Conditon.K_Resources_type = Convert.ToInt32(shareResourcesType);
            }
            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_title");
                if (title != null && title != "")
                {
                    Conditon.K_Resources_name = title.Trim();
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
                 c.K_Resources_typeName,
                 c.K_Resources_Knowledge_name,
                 c.K_Resources_stateName,
                 c.K_Resources_Situation,
                 c.K_Resources_state.ToString()
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
        /// 知识审核
        /// </summary>
        /// <returns></returns>
        public ActionResult KnowledgeAudit()
        {
            InitializationPageParameter();
            return View();
        }
        /// <summary>
        /// Ajax获取列表Json
        /// </summary>, string knowledgeCode
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult AjaxKnowledgeAuditlist(jQueryDataTableParamModel param)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.KMS.K_Resources Conditon = new CommonService.Model.KMS.K_Resources();

            string auditResourcesType = Request.Params.Get("auditResourcesTypeId");
            if (auditResourcesType != null && auditResourcesType != "")
            {
                Conditon.K_Resources_type = Convert.ToInt32(auditResourcesType);
            }
            if (!Context.UIContext.Current.IsPreSetManager)
            {
                Conditon.K_Resources_Knowledge_person = Context.UIContext.Current.RootUserCode.Value;
            }
            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_title");
                if (title != null && title != "")
                {
                    Conditon.K_Resources_name = title.Trim();
                }

                #endregion
            }

            #endregion

            #region 分页数据处理

            //总记录数
            this.TotalRecordCount = _resourcesWCF.GetRecordCount(Conditon);
            //数据信息
            List<CommonService.Model.KMS.K_Resources> redources = _resourcesWCF.GetListByPage(Conditon,
                "", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            //转化数据格式
            var result = from c in redources
                         select new[] { 
                 c.K_Resources_code.ToString(),
                 c.K_Resources_type.ToString(),
                 c.K_Resources_url,
                 c.K_Resources_name, 
                 c.K_Resources_typeName,
                 c.K_Resources_Knowledge_name,
                 c.K_Resources_stateName,
                 c.K_Resources_Permissions.ToString(),
                 c.K_Resources_creatorName.ToString(),
                 c.K_Resources_createTime.ToString(),
                 c.K_Resources_state.ToString()
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
        /// 知识维护
        /// </summary>
        /// <returns></returns>
        public ActionResult KnowledgeMaintenance()
        {
            InitializationPageParameter();
            return View();
        }
        /// <summary>
        /// 评论列表页
        /// </summary>
        /// <param name="resourcesCode"></param>
        /// <returns></returns>
        public PartialViewResult PartCommentList(string resourcesCode)
        {
            CommonService.Model.KMS.K_Resources resources = _resourcesWCF.GetModel(new Guid(resourcesCode));
            List<CommonService.Model.KMS.K_Comments> listCom = _commentsWCF.GetCommentsListByCode(new Guid(resourcesCode));
            ViewBag.listCom = listCom;
            ViewBag.SourceType = 1;
            return PartialView(resources);
        }
        public ActionResult CommentList(string resourcesCode)
        {
            ViewBag.SourceType = 2;
            CommonService.Model.KMS.K_Resources resources = _resourcesWCF.GetModel(new Guid(resourcesCode));
            List<CommonService.Model.KMS.K_Comments> listCom = _commentsWCF.GetCommentsListByCode(new Guid(resourcesCode));
            ViewBag.listCom = listCom;
            return View("PartCommentList", resources);
        }
        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult AjaxKnowledgeMaintenancelist(jQueryDataTableParamModel param)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.KMS.K_Resources Conditon = new CommonService.Model.KMS.K_Resources();
            //Conditon.K_Resources_creator = Context.UIContext.Current.RootUserCode;
            if (!Context.UIContext.Current.IsPreSetManager)//负责人
            {
                Conditon.K_Resources_Knowledge_person = Context.UIContext.Current.RootUserCode.Value;
            }

            string maintenanceResourcesState = Request.Params.Get("maintenanceResourcesStateId");
            string maintenanceResourcesType = Request.Params.Get("maintenanceResourcesTypeId");
            if (maintenanceResourcesState != null && maintenanceResourcesState != "")
            {
                Conditon.K_Resources_state = Convert.ToInt32(maintenanceResourcesState);
            }
            if (maintenanceResourcesType != null && maintenanceResourcesType != "")
            {
                Conditon.K_Resources_type = Convert.ToInt32(maintenanceResourcesType);
            }
            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_title");
                if (title != null && title != "")
                {
                    Conditon.K_Resources_name = title.Trim();
                }
                //string state = Request.Params.Get("i_state");
                //if (state != null && state != "-1")
                //{
                //    Conditon.K_Resources_state = Convert.ToInt32(state);
                //}

                #endregion
            }

            #endregion

            #region 分页数据处理

            //总记录数
            this.TotalRecordCount = _resourcesWCF.GetRecordCount(Conditon);
            //数据信息
            List<CommonService.Model.KMS.K_Resources> redources = _resourcesWCF.GetListByPage(Conditon, "", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);//数据信息

            string knowledgeStr = "";
            List<CommonService.Model.KMS.K_Knowledge> knowledges = new List<CommonService.Model.KMS.K_Knowledge>();
            if (!Context.UIContext.Current.IsPreSetManager)
            {
                knowledges = _knowledgeWCF.GetAllListByPerson(Context.UIContext.Current.RootUserCode.Value);
            }
            else
            {
                knowledges = _knowledgeWCF.GetAllList();
            }
            if (knowledges.Count() > 0)
            {
                foreach (CommonService.Model.KMS.K_Knowledge knowledge in knowledges)
                {
                    knowledgeStr += knowledge.K_Knowledge_code + "_" + knowledge.K_Knowledge_name + ",";
                }
            }
            knowledgeStr = knowledgeStr == "" ? knowledgeStr : knowledgeStr.Substring(0, knowledgeStr.Length - 1);

            //转化数据格式
            var result = from c in redources
                         select new[] { 
                 c.K_Resources_code.ToString(),
                 c.K_Resources_type.ToString(),
                 c.K_Resources_url,
                 c.K_Resources_name, 
                 c.K_Resources_typeName,
                 c.K_Resources_Knowledge_name,
                 c.K_Resources_stateName,
                 c.K_Resources_Situation,
                 c.K_Resources_creatorName,
                 c.K_Resources_createTime.ToString(),
                 c.K_Resources_state.ToString(),
                 knowledgeStr
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

        #region 系统封面资源管理

        /// <summary>
        /// 系统封面设置
        /// </summary>
        /// <returns></returns>
        public ActionResult Cover()
        {
            //InitializationPageParameter();
            CommonService.Model.KMS.K_Resources_Cover cover = new CommonService.Model.KMS.K_Resources_Cover();
            cover.K_Resources_cover_code = Guid.NewGuid();
            cover.K_Resources_cover_state = false;
            cover.K_Resources_cover_creater = (Guid)Context.UIContext.Current.RootUserCode;
            cover.K_Resources_cover_isDelete = false;

            List<CommonService.Model.KMS.K_Resources_Cover> listCover = _resources_CoverWCF.GetAllList();
            ViewBag.listCover = listCover;
            return View(cover);
        }

        /// <summary>
        /// 资源封面图片上传
        /// </summary>
        /// <param name="form"></param>
        /// <param name="cover"></param>
        /// <returns></returns>
        public ActionResult SaveCover(FormCollection form, CommonService.Model.KMS.K_Resources_Cover cover)
        {
            #region 文件上传处理
            string originalFileName = "";
            string imageDirectory = "img";//封面图片存放位置
            try
            {
                if (Request.Files.Count != 0)
                {
                    #region 上传文件
                    HttpFileCollectionBase files = Request.Files;
                    HttpPostedFileBase httpPostFile = files["resourcesCoverImage"];
                    originalFileName = System.IO.Path.GetFileName(httpPostFile.FileName.ToString()); //得到原文件名         
                    if (originalFileName != "")
                    {
                        // 初始化byte长度.
                        byte[] file = new Byte[httpPostFile.ContentLength];
                        // 把附件写入byte中
                        System.IO.Stream stream = httpPostFile.InputStream;
                        stream.Read(file, 0, httpPostFile.ContentLength);
                        stream.Flush();
                        stream.Close();

                        //服务器附件根目录
                        //string mainPhyPath = attachmentMainPath;
                        string mainPhyPath = Server.MapPath("../../");
                        //服务器附件存放全目录
                        string attachPhyPath = mainPhyPath + "" + imageDirectory + "\\";
                        if (!Directory.Exists(attachPhyPath))
                        {
                            Directory.CreateDirectory(attachPhyPath);
                        }
                        //附件扩展名称
                        string extensionName = System.IO.Path.GetExtension(originalFileName).ToLower();
                        //附件名称
                        string fileCode = Guid.NewGuid().ToString().Replace('-', '_');
                        string fileName = fileCode + extensionName;
                        string attachmentFullPathName = attachPhyPath + fileName;
                        int fileLength = file.Length;

                        System.IO.FileStream fs = new System.IO.FileStream(attachmentFullPathName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                        fs.Write(file, 0, fileLength);
                        fs.Flush();
                        fs.Close();


                        #region 保存上传文件信息到数据库
                        cover.K_Resources_cover_url = "\\" + imageDirectory + "\\" + fileName;
                        #endregion
                    }
                    #endregion

                }
            }
            catch (Exception ex)
            {

            }
            #endregion

            //服务方法调用
            int coverId = 0;

            if (cover.K_Resources_cover_url == null)//图片路径不能为空
            {
                //表单提交失败固定写法
                return Json(TipHelper.JsonData("网络错误，请重新上传！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            else
            {
                if (cover.K_Resources_cover_id > 0)
                {//修改
                    bool isUpdateSuccess = _resources_CoverWCF.Update(cover);
                    if (isUpdateSuccess)
                    {
                        coverId = cover.K_Resources_cover_id;
                    }
                }
                else
                {//增加
                    DateTime now = DateTime.Now;
                    cover.K_Resources_cover_createTime = now;
                    coverId = _resources_CoverWCF.Add(cover);
                }
                if (coverId > 0)
                {
                    return Json(TipHelper.JsonData("上传资源封面图片成功！", "/kms/Resources/Cover", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageGoAnotherPage));
                }
                else
                {
                    //表单提交失败固定写法
                    return Json(TipHelper.JsonData("上传资源封面图片失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
            }
        }

        /// <summary>
        /// 删除封面图片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteCover(int coverId)
        {
            bool isSuccess = _resources_CoverWCF.Delete(coverId);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除资源封面图片成功！", "/kms/Resources/Cover", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除资源封面图片失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 修改封面图片状态
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateCover(int coverId)
        {
            CommonService.Model.KMS.K_Resources_Cover cover = _resources_CoverWCF.GetModel(coverId);
            cover.K_Resources_cover_state = !cover.K_Resources_cover_state;
            bool isSuccess = _resources_CoverWCF.Update(cover);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("修改资源封面图片成功！", "/kms/Resources/Cover", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("修改资源封面图片失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        #endregion

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
            CommonService.Model.KMS.K_Resources model = new CommonService.Model.KMS.K_Resources();
            model.K_Resources_state = Convert.ToInt32(ResourcesStateEnum.已发布);
            model.K_Resources_type = 827;
            int aviCount = _resourcesWCF.GetRecordCount(model);
            model.K_Resources_type = 1;
            int wordCount = _resourcesWCF.GetRecordCount(model);
            //int allCount = _resourcesWCF.GetRecordCount(model);
            //model.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.视频);
            //int aviCount = _resourcesWCF.GetRecordCount(model);
            //int wordCount = allCount - aviCount;
            ViewBag.aviCount = aviCount;
            ViewBag.wordCount = wordCount;
            List<CommonService.Model.KMS.K_Knowledge> listK = _knowledgeWCF.GetAllList();
            ViewBag.listK = listK;
            List<CommonService.Model.KMS.K_Resources> listR = _resourcesWCF.GetListByBrowseCount(3, null, null);
            ViewBag.listR = listR;
            List<CommonService.Model.KMS.K_Resources> listAVI = _resourcesWCF.GetListByBrowseCount(3, null, Convert.ToInt32(ResourcesTypeEnum.视频));
            ViewBag.listAVI = listAVI;
            List<CommonService.Model.KMS.K_Resources> listArticle = _resourcesWCF.GetListByBrowseCount(5, null, Convert.ToInt32(ResourcesTypeEnum.文章));
            ViewBag.listArticle = listArticle;
            List<CommonService.Model.KMS.K_Keyword> listKey = _keywordWCF.GetTagList();
            ViewBag.listKey = listKey;

        }
        public void InitializationPageParameter(CommonService.Model.KMS.K_PorblemAndResources_LinkCase model)
        {
            //法院集合
            List<CommonService.Model.C_Court> CourtItems = _courtWCF.GetAllList();
            string userHtml = "";
            userHtml += "<option value='all'>全部</option>";
            foreach (var court in CourtItems)
            {
                if (model != null && court.C_Court_code == model.K_ProblemAndResources_LinkCase_Courtcode)
                {
                    userHtml += "<option value=" + court.C_Court_code + ">" + court.C_Court_name + "</option>";
                }
                else
                {
                    userHtml += "<option value=" + court.C_Court_code + ">" + court.C_Court_name + "</option>";
                }

            }
            ViewBag.userhtml = userHtml;
            ViewBag.courtItems = CourtItems;
            //业务流程集合
            List<CommonService.Model.FlowManager.P_Flow> FlowItems = _flowWCF.GetListByFlowType(Convert.ToInt32(FlowTypeEnum.案件));
            ViewBag.flowItems = FlowItems;
            //表单集合
            if (model != null && model.K_ProblemAndResources_LinkCase_BusinessFlowcode!=null)
            {
                List<CommonService.Model.FlowManager.P_Flow_form> formItems = _flowformWCF.GetListByFlowCode(model.K_ProblemAndResources_LinkCase_BusinessFlowcode.Value);
                ViewBag.formItem = formItems;
            }
            else
            {
                string flowCode = FlowItems[0].P_Flow_code.ToString();
                if (model.K_ProblemAndResources_LinkCase_BusinessFlowcode!=null&&!string.IsNullOrEmpty(model.K_ProblemAndResources_LinkCase_BusinessFlowcode.Value.ToString()))
                { 
                    flowCode = model.K_ProblemAndResources_LinkCase_BusinessFlowcode.ToString();
                }
                List < CommonService.Model.FlowManager.P_Flow_form> formItems = _flowformWCF.GetListByFlowCode(new Guid(flowCode));
                ViewBag.formItem = formItems;
            }
            List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllSpecialList();
            ViewBag.regionList = regionList;

        }
    }
}