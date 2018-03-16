using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.KMS.Controllers
{
    public class ArticleController : BaseController
    {
        private readonly ICommonService.KMS.IK_Resources _resourcesWCF;
        private readonly ICommonService.KMS.IK_Keyword _keywordWCF;
        private readonly ICommonService.KMS.IK_Keyword_Resources _keyword_ResourcesWCF;
        private readonly ICommonService.KMS.IK_Knowledge _knowledgeWCF;
        private readonly ICommonService.KMS.IK_Knowledge_Resources knowledge_ResourcesWCF;
        private readonly ICommonService.KMS.IK_Resources_Cover _resources_CoverWCF;

        //
        // GET: /KMS/Article/
        public ArticleController()
        {
            #region 服务初始化
            _resourcesWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Resources>("K_ResourcesWCF");
            _keywordWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Keyword>("K_KeywordWCF");
            _keyword_ResourcesWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Keyword_Resources>("K_Keyword_ResourcesWCF");
            _knowledgeWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Knowledge>("K_KnowledgeWCF");
            knowledge_ResourcesWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Knowledge_Resources>("K_Knowledge_ResourcesWCF");
            _resources_CoverWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Resources_Cover>("K_Resources_CoverWCF");
            #endregion

        }
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public ActionResult Create(string resourceesCode, int? type, string reflash)
        {
            CommonService.Model.KMS.K_Resources model = new CommonService.Model.KMS.K_Resources();
            if (resourceesCode != "" && resourceesCode != null)
            {
                model = _resourcesWCF.GetModel(new Guid(resourceesCode));
            }
            else
            {
                model.K_Resources_code = Guid.NewGuid();
                model.K_Resources_type = Convert.ToInt32(ResourcesTypeEnum.文章);
                model.K_Resources_creator = Context.UIContext.Current.RootUserCode;
                model.K_Resources_isDelete = false;
                model.K_Resources_state = Convert.ToInt32(ResourcesStateEnum.未审核);
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
            ViewBag.KnowlwedgeList = knowledgeList;

            List<CommonService.Model.KMS.K_Resources_Cover> listCover = _resources_CoverWCF.GetStartList();
            ViewBag.listCover = listCover;

            ViewBag.type = type;
            ViewBag.reflash = reflash;

            return View(model);
        }
        /// <summary>
        /// 修改文章
        /// </summary>
        /// <param name="resourcesCode">文章Guid</param>
        /// <returns></returns>
        public ActionResult Edit(string resourcesCode,string reflash)
        {
            if (string.IsNullOrEmpty(resourcesCode))
            {

            }

            List<CommonService.Model.KMS.K_Knowledge> knowledgeList = _knowledgeWCF.GetAllList();
            ViewBag.KnowlwedgeList = knowledgeList;
            List<CommonService.Model.KMS.K_Resources_Cover> listCover = _resources_CoverWCF.GetStartList();
            ViewBag.listCover = listCover;
            ViewBag.reflash = reflash;

            CommonService.Model.KMS.K_Resources model = _resourcesWCF.GetModel(new Guid(resourcesCode));
            return View("Create", model);
        }
        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection form, CommonService.Model.KMS.K_Resources article)
        {
            #region

            #region 关键字处理
            if (article.K_Resources_id > 0)
            {
                //删除原关键字与资源的关连
                _keyword_ResourcesWCF.DeleteByResourcesCode(article.K_Resources_code.Value);
            }
            if (article.K_Resources_Keyword != null && article.K_Resources_Keyword.Trim() != "")
            {
                string[] Keywords = article.K_Resources_Keyword.Split(',', '，');
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
                        keywordResourcesModel.K_Resources_code = article.K_Resources_code.Value;
                    }
                    else
                    {
                        keywordResourcesModel.K_Keyword_code = new Guid(keyWordCode);
                        keywordResourcesModel.K_Resources_code = article.K_Resources_code.Value;
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
                if (article.K_Resources_id > 0)
                {
                    //knowledge_ResourcesWCF.DeleteByFkCode(article.K_Resources_code.Value);//删除之前的所属分类数据

                    //修改所属分类
                    CommonService.Model.KMS.K_Knowledge_Resources knowledge = knowledge_ResourcesWCF.GetModelByFkCode(article.K_Resources_code.Value);
                    knowledge.P_FK_code = article.K_Resources_code.Value;
                    knowledge.K_Knowledge_code = new Guid(Knowledge);
                    knowledge_ResourcesWCF.Update(knowledge);
                }
                else
                {
                    CommonService.Model.KMS.K_Knowledge_Resources knowledgeResourcesModel = new CommonService.Model.KMS.K_Knowledge_Resources();
                    knowledgeResourcesModel.K_Knowledge_Resources_code = Guid.NewGuid();
                    knowledgeResourcesModel.K_Knowledge_Resources_type = 1;
                    knowledgeResourcesModel.P_FK_code = article.K_Resources_code.Value;
                    knowledgeResourcesModel.K_Knowledge_code = new Guid(Knowledge);
                    knowledgeResourcesModel.K_Knowledge_Resources_creator = Context.UIContext.Current.RootUserCode;
                    knowledgeResourcesModel.K_Knowledge_Resources_createTime = DateTime.Now;
                    knowledgeResourcesModel.K_Knowledge_Resources_isDelete = false;

                    knowledge_ResourcesWCF.Add(knowledgeResourcesModel);
                }
            }
            #endregion

            #region 文章封面图片
            string imageName = "";
            string imageDirectory = "img";//封面图片存放位置
            try
            {
                if (Request.Files.Count != 0)
                {
                    HttpFileCollectionBase imgfiles = Request.Files;
                    HttpPostedFileBase httpPostFileImage = imgfiles["ArticleCoverImage"];
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
                        article.K_Resources_coverImage = "\\" + imageDirectory + "\\" + imgfileName;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            #endregion

            #endregion
            int articleId = 0;
            if (article.K_Resources_id > 0)
            {//修改
                //获取原数据
                CommonService.Model.KMS.K_Resources oldarticle = _resourcesWCF.GetModel(article.K_Resources_code.Value);
                //如果封面图片为空，则保存原来的封面图
                if (article.K_Resources_coverImage == null || article.K_Resources_coverImage == "")
                    article.K_Resources_coverImage = oldarticle.K_Resources_coverImage;
                bool isUpdateSuccess = _resourcesWCF.Update(article);
                if (isUpdateSuccess)
                {
                    articleId = article.K_Resources_id;
                }
            }
            else
            {//添加
                article.K_Resources_createTime = DateTime.Now;
                article.K_Resources_Permissions = false;
                articleId = _resourcesWCF.Add(article);
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
            if (articleId > 0)
                return Json(TipHelper.JsonData("提交文章信息成功，等待管理员审核！", url, IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageGoAnotherPage));
            else
                return Json(TipHelper.JsonData("提交文章信息失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
        }
        public ActionResult Select(string code)
        {
            return View();
        }
    }
}