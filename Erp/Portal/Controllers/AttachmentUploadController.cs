using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Controllers
{
    /// <summary>
    /// 附件上传控制器
    /// </summary>
    public class AttachmentUploadController : BaseController
    {
        private readonly ICommonService.IC_Files _fileWCF;
        private readonly ICommonService.IC_DownloadRecord _downloadRecordWCF;
        public AttachmentUploadController()
        {
            #region 服务初始化
            _fileWCF = ServiceProxyFactory.Create<ICommonService.IC_Files>("FilesWCF");
            _downloadRecordWCF = ServiceProxyFactory.Create<ICommonService.IC_DownloadRecord>("C_DownloadRecordWCF");
            #endregion
        }

        //
        // GET: /AttachmentUpload/
        public override ActionResult Index()
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
        /// 附件布局Action
        /// </summary>
        /// <param name="relationCode">关联业务Guid</param>
        /// <param name="targetDirectory">目标附件存放目录</param>
        /// <param name="fileBelongType">文件所属类型</param>
        /// <returns></returns>
        public ActionResult Attachment_Defaultlayout(string relationCode, string targetDirectory, string fileBelongType)
        {
            ViewBag.RelationCode = relationCode;
            ViewBag.TargetDirectory = targetDirectory;
            ViewBag.FileBelongType = fileBelongType;

            return View();
        }
        /// <summary>
        /// 附件上传Action
        /// </summary>
        /// <param name="relationCode">关联业务Guid</param>
        /// <param name="targetDirectory">目标附件存放目录</param>
        /// <param name="fileBelongType">文件所属类型</param>
        /// <returns></returns>
        public ActionResult AttachmentList(string relationCode, string targetDirectory, string fileBelongType)
        {
            ViewBag.AttachmentShowMainPath = attachmentShowMainPath;
            List<CommonService.Model.C_Files> Files = _fileWCF.GetFilesByBelongTypeAndRelationCode(Convert.ToInt32(fileBelongType), new Guid(relationCode));
            return View(Files);
        }

        public ActionResult DownPic(string fileGuid, string url)
        {
            //增加下载记录（非管理员）
            if (!Context.UIContext.Current.IsPreSetManager)
            {
                CommonService.Model.C_DownloadRecord model = new CommonService.Model.C_DownloadRecord();
                model.C_DownloadRecord_code = Guid.NewGuid();
                model.C_DownloadRecord_createTime = DateTime.Now;
                model.C_DownloadRecord_creator = Context.UIContext.Current.UserCode;
                model.C_DownloadRecord_isDelete = false;
                model.C_DownloadRecord_attachmentCode = new Guid(fileGuid);
                _downloadRecordWCF.Add(model);
            }
            //下载文件
            CommonService.Model.C_Files fModel = _fileWCF.GetModelByCode(new Guid(fileGuid));
            return File(new FileStream(Server.MapPath(url), FileMode.Open), "application/octet-stream", fModel.C_Files_viewName);
        }
        [HttpPost]
        /// <summary>
        /// 获得文件的下载记录
        /// </summary>
        /// <param name="fileCode"></param>
        /// <returns></returns>
        public JsonResult GetdownList(string fileCode)
        {
            List<CommonService.Model.C_DownloadRecord> list = new List<CommonService.Model.C_DownloadRecord>();
            list = _downloadRecordWCF.GetListByfileCode(new Guid(fileCode));
            var result = from c in list
                         select new[]{
                         c.C_Userinfo_name,
                         c.C_DownloadRecord_createTime==null?"":c.C_DownloadRecord_createTime.Value.ToString("yyyy-MM-dd HH:mm:ss") 
                       };
            return Json(result);
        }
        /// <summary>
        /// 上传附件
        /// </summary>
        /// <param name="relationCode"></param>
        /// <param name="targetDirectory"></param>
        /// <param name="fileBelongType"></param>
        [HttpPost]
        public void UploadAttachment(string relationCode, string targetDirectory, string fileBelongType)
        {
            string originalFileName = "";
            try
            {
                HttpPostedFileBase httpPostFile = Request.Files[0];
                originalFileName = System.IO.Path.GetFileName(httpPostFile.FileName.ToString()); //得到原文件名              
                // 初始化byte长度.

                byte[] file = new Byte[httpPostFile.ContentLength];

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

                #region 保存信息到数据库
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
            catch (Exception ex)
            {

            }

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
        /// 附件布局Action(只读附件)
        /// </summary>
        /// <param name="relationCode">关联业务Guid</param>
        /// <param name="targetDirectory">目标附件存放目录</param>
        /// <param name="fileBelongType">文件所属类型</param>
        /// <returns></returns>
        public ActionResult Attachment_Defaultlayout_View(string relationCode, string targetDirectory, string fileBelongType)
        {
            ViewBag.RelationCode = relationCode;
            ViewBag.TargetDirectory = targetDirectory;
            ViewBag.FileBelongType = fileBelongType;

            return View();
        }

        /// <summary>
        /// 附件列表Action(只读附件)
        /// </summary>
        /// <param name="relationCode">关联业务Guid</param>
        /// <param name="targetDirectory">目标附件存放目录</param>
        /// <param name="fileBelongType">文件所属类型</param>
        /// <returns></returns>
        public ActionResult AttachmentViewList(string relationCode, string targetDirectory, string fileBelongType)
        {
            ViewBag.AttachmentShowMainPath = attachmentShowMainPath;

            List<CommonService.Model.C_Files> Files = _fileWCF.GetFilesByBelongTypeAndRelationCode(Convert.ToInt32(fileBelongType), new Guid(relationCode));
            return View(Files);
        }

        public ActionResult BrowseFile()
        {
            string a = "";
            return View();
        }

        public ActionResult UploadFile()
        {
             

            string a = "";
            return View();
        }

    }
}