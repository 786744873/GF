using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.Feedback.Controllers
{
    /// <summary>
    /// 意见反馈Control
    /// </summary>
    public class FeedbackController : BaseController
    {
        private readonly ICommonService.Feedback.IC_Feedback _feedbackWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        private readonly ICommonService.SysManager.IC_Userinfo _userinfoWCF;
        private readonly ICommonService.IC_Files _fileWCF;
        public FeedbackController()
        {
            #region 服务初始化
            _feedbackWCF = ServiceProxyFactory.Create<ICommonService.Feedback.IC_Feedback>("FeedbackWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            _userinfoWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo>("UserinfoWCF");
            _fileWCF = ServiceProxyFactory.Create<ICommonService.IC_Files>("FilesWCF");
            #endregion
        }
        //
        // GET: /Feedback/Feedback/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 附件存放主目录
        /// </summary>
        string attachmentMainPath = ConfigurationManager.AppSettings["AttachmentStoreMainPath"];
        /// <summary>
        /// 附件显示主目录
        /// </summary>
        string attachmentShowMainPath = ConfigurationManager.AppSettings["AttachmentShowMainPath"];

        /// <summary>
        /// 创建Action
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(string leftmenuname)
        {
            InitializationPageParameter();
            //创建初始化业务流程实体
            CommonService.Model.Feedback.C_Feedback feedback = new CommonService.Model.Feedback.C_Feedback();
            feedback.C_Feedback_code = Guid.NewGuid();
            feedback.C_Feedback_thePage = leftmenuname;
            feedback.C_Feedback_state = Convert.ToInt32(FeedbackStateEnum.未操作);
            feedback.C_Feedback_applicant = Context.UIContext.Current.RootUserCode;
            List<CommonService.Model.Feedback.C_Feedback> feedbackList = _feedbackWCF.GetListByApplicant(Context.UIContext.Current.RootUserCode.Value);
            ViewBag.feedbackList = feedbackList;
            int AdoptCount = 0;
            int Integral = 0;
            foreach (CommonService.Model.Feedback.C_Feedback feedbackItem in feedbackList)
            {
                if (feedbackItem.C_Feedback_state == Convert.ToInt32(FeedbackStateEnum.已采纳))
                {
                    AdoptCount++;
                }
                Integral = Integral + Convert.ToInt32(feedbackItem.C_Feedback_Integral);
            }
            ViewBag.AdoptCount = AdoptCount;//被采纳数
            ViewBag.Integral = Integral;//积分
            ViewBag.feedbackCount = feedbackList.Count();//问题总数

            #region 处理附件
            List<CommonService.Model.C_Files> Files = new List<CommonService.Model.C_Files>();
            ViewBag.Files = Files;
            ViewBag.AttachmentShowMainPath = attachmentShowMainPath;

            #endregion

            return View(feedback);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            InitializationPageParameter();
            return View();
        }
        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult AjaxList(jQueryDataTableParamModel param)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            //查询模型
            CommonService.Model.Feedback.C_Feedback feedbackConditon = new CommonService.Model.Feedback.C_Feedback();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string thePage = Request.Params.Get("s_thePage");
                if (thePage != null && thePage != "")
                {
                    feedbackConditon.C_Feedback_thePage = thePage;
                }
                string applicant = Request.Params.Get("s_applicant");
                if (applicant != null && applicant != "")
                {
                    feedbackConditon.C_Feedback_applicantName = applicant;
                }
                string state = Request.Params.Get("i_state_type");
                if (state != null && state != "-1")
                {
                    feedbackConditon.C_Feedback_state = Convert.ToInt32(state);
                }

                #endregion
            }
            CommonService.Model.SysManager.C_Userinfo userinfo=_userinfoWCF.GetModelByUserCode(Context.UIContext.Current.UserCode.Value);
            if (!Context.UIContext.Current.IsPreSetManager)
            {
                feedbackConditon.C_Feedback_applicant = userinfo.C_Userinfo_code.Value;
            }

            #endregion

            #region 分页数据处理

            //总记录数
            this.TotalRecordCount = _feedbackWCF.GetRecordCount(feedbackConditon);
            //数据信息
            List<CommonService.Model.Feedback.C_Feedback> feedbacks = _feedbackWCF.GetListByPage(feedbackConditon,
                "", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            //转化数据格式
            var result = from c in feedbacks
                         select new[] { 
                             c.C_Feedback_code.ToString(),
                             c.C_Feedback_code.ToString(),
                             c.C_Feedback_thePage,
                             c.C_Feedback_wantfunctionName,
                             c.C_Feedback_Description.Length > 15 ? c.C_Feedback_Description.Substring(0,15)+"..." : c.C_Feedback_Description,//
                             c.C_Feedback_stateName,
                             c.C_Feedback_applicantName,
                             c.C_Feedback_dateTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                             c.C_Feedback_replyContent==null ? "" : c.C_Feedback_replyContent.Length > 15 ? c.C_Feedback_replyContent.Substring(0,15)+"..." : c.C_Feedback_replyContent,//
                             c.C_Feedback_audipersonName=c.C_Feedback_audipersonName==null ? "" : c.C_Feedback_audipersonName,
                             c.C_Feedback_audiTime==null ? c.C_Feedback_audiTime.ToString() : c.C_Feedback_audiTime.Value.ToString("yyyy-MM-dd HH:mm:ss")
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
        /// 意见处理
        /// </summary>
        /// <param name="feedbackCodes">意见反馈GUID</param>
        /// <param name="type">状态</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult HandleAction(string feedbackCodes,int type)
        {
            bool isSuccess = false;
            string[] feedbackCodeStr = feedbackCodes.Split(',');
            List<CommonService.Model.Feedback.C_Feedback> feedbackList = new List<CommonService.Model.Feedback.C_Feedback>();
            foreach (var feedbackCode in feedbackCodeStr)
            {
                CommonService.Model.Feedback.C_Feedback feedback = _feedbackWCF.GetModel(new Guid(feedbackCode));
                feedback.C_Feedback_state = type;

                feedbackList.Add(feedback);
            }

            isSuccess = _feedbackWCF.OperateList(feedbackList);

            if (isSuccess)
            {//成功(这里可以给一个table的id，目的是操作table后，刷新table)
                return Json(TipHelper.JsonData("操作成功！", "feedbackList", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("操作失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }

        }

        /// <summary>
        /// 详细页面
        /// </summary>
        /// <param name="feedbackCode"></param>
        /// <returns></returns>
        public ActionResult Detial(string feedbackCode)
        {
            InitializationPageParameter();
            CommonService.Model.Feedback.C_Feedback feedback = new CommonService.Model.Feedback.C_Feedback();
            if(feedbackCode!=null)
            {
                feedback = _feedbackWCF.GetModel(new Guid(feedbackCode));
                feedback.C_Feedback_audiPerson = Context.UIContext.Current.UserCode;
                feedback.C_Feedback_audiTime = DateTime.Now;
            }

            #region 处理附件
            List<CommonService.Model.C_Files> Files = _fileWCF.GetFilesByBelongTypeAndRelationCode(Convert.ToInt32(FileBelongTypeEnum.意见反馈), new Guid(feedbackCode));
            ViewBag.Files = Files;
            ViewBag.AttachmentShowMainPath = attachmentShowMainPath;

            #endregion

            return View("create",feedback);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="form"></param>
        /// <param name="businessFlow"></param>
        /// <returns></returns>
        [HttpPost] 
        public ActionResult Save(FormCollection form, CommonService.Model.Feedback.C_Feedback feedBack)
        {
            string relationCode = feedBack.C_Feedback_code.ToString();//关联反馈Guid
            string targetDirectory="feedback";//附件存放文件夹
            string fileBelongType = Convert.ToInt32(FileBelongTypeEnum.意见反馈).ToString();//文件归属类型(意见反馈)

            string originalFileName = "";
            try
            {
                if (Request.Files.Count != 0)
                {
                    #region 上传文件
                    HttpPostedFileBase httpPostFile = Request.Files[0];
                    originalFileName = System.IO.Path.GetFileName(httpPostFile.FileName.ToString()); //得到原文件名              
                    // 初始化byte长度.

                    byte[] file = new Byte[httpPostFile.ContentLength];
                    // 把附件写入byte中
                    System.IO.Stream stream = httpPostFile.InputStream;
                    stream.Read(file, 0, httpPostFile.ContentLength);
                    stream.Flush();
                    stream.Close();

                    //服务器附件根目录
                    string mainPhyPath = attachmentMainPath;
                    //服务器附件存放全目录
                    string attachPhyPath = mainPhyPath + "" + targetDirectory + "\\";
                    if (!Directory.Exists(attachPhyPath))
                    {
                        Directory.CreateDirectory(attachPhyPath);
                    }
                    //附件扩展名称
                    string extensionName = System.IO.Path.GetExtension(originalFileName).ToLower();
                    //附件名称
                    string fileName = Guid.NewGuid() + extensionName;
                    string attachmentFullPathName = attachPhyPath + fileName;
                    int fileLength = file.Length;

                    System.IO.FileStream fs = new System.IO.FileStream(attachmentFullPathName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                    fs.Write(file, 0, fileLength);
                    fs.Flush();
                    fs.Close();
                    #endregion

                    #region 保存上传文件信息到数据库
                    CommonService.Model.C_Files cFile = new CommonService.Model.C_Files();
                    cFile.C_Files_code = Guid.NewGuid();
                    cFile.C_Files_viewName = originalFileName;
                    cFile.C_Files_name = "/" + targetDirectory + "/" + fileName;
                    cFile.C_Files_size = fileLength / 1024;
                    cFile.C_Files_creator = Context.UIContext.Current.UserCode;
                    cFile.C_Files_createDate = DateTime.Now;
                    cFile.C_Files_type = extensionName;
                    cFile.C_Files_isDelete = 0;
                    cFile.C_Files_cate = Convert.ToInt32(fileBelongType);
                    cFile.C_Files_link = new Guid(relationCode);

                    _fileWCF.Add(cFile);

                    #endregion
                }
            }
            catch (Exception ex)
            {

            }

            if (Request.Files.Count == 0)
            {
                #region 只执行数据库的保存
                int feedBackId = 0;
                if (feedBack.C_Feedback_id > 0)
                {//修改               
                    bool isUpdateSuccess = _feedbackWCF.Update(feedBack);
                    if (isUpdateSuccess)
                    {
                        feedBackId = feedBack.C_Feedback_id;
                    }
                }
                else
                {//添加
                    DateTime now = DateTime.Now;
                    feedBack.C_Feedback_dateTime = now;
                    feedBackId = _feedbackWCF.Add(feedBack);
                }
                if (feedBackId > 0)
                {
                    return Json(TipHelper.JsonData("意见提交成功！", "/feedback/feedback/List", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageGoAnotherPage));
                }
                else
                {
                    //表单提交失败固定写法
                    return Json(TipHelper.JsonData("意见提交失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
                }
                #endregion
            }

            return Json("");
        }

        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="fileCode">附件Guid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string fileCode)
        {
            bool isSuccess = _fileWCF.Delete(new Guid(fileCode));
            if (isSuccess)
            {
                //保存成功提示固定写法
                return Json(TipHelper.JsonData("删除附件成功！", "iframe_attachment", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("删除附件失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 初始化页面参数
        /// </summary>
        private void InitializationPageParameter()
        {
            //功能类型参数集合
            List<CommonService.Model.C_Parameters> wantfunction = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(FeedbackEnum.功能类型));
            ViewBag.Wantfunction = wantfunction;
            //状态类型参数集合
            List<CommonService.Model.C_Parameters> feedbackState = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(FeedbackEnum.意见反馈状态));
            ViewBag.FeedbackState = feedbackState;
        }
	}
}