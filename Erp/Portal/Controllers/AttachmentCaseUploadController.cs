using CommonService.Common;
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
    public class AttachmentCaseUploadController : BaseController
    {
         private readonly ICommonService.IC_Files _fileWCF;
         private readonly ICommonService.IC_Parameters _parameterWCF;
         public AttachmentCaseUploadController()
        {
            #region 服务初始化
            _fileWCF = ServiceProxyFactory.Create<ICommonService.IC_Files>("FilesWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            #endregion
        }
                /// <summary>
        /// 初始化页面参数
        /// </summary>
         private void InitializationPageParameter()
         {
             //客户类型参数集合
             List<CommonService.Model.C_Parameters> CaseTypes = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(FileBelongTypeEnum.案件));
             ViewBag.CaseTypes = CaseTypes;
         }
        //
        // GET: /AttachmentCaseUpload/
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
        /// 附件布局Action(案件)
        /// </summary>
        /// <param name="relationCode">关联业务Guid</param>
        /// <param name="targetDirectory">目标附件存放目录</param>
        /// <param name="fileBelongType">文件所属类型</param>
        /// <returns></returns>
        public ActionResult Attachment_Caselayout(string relationCode, string targetDirectory, string fileBelongType)
        {
            InitializationPageParameter();
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
        public ActionResult AttachmentCaseList(string relationCode, string targetDirectory, string fileBelongType)
        {
            ViewBag.AttachmentShowMainPath = attachmentShowMainPath;

            List<CommonService.Model.C_Files> Files = _fileWCF.GetChildenFilesByBelongTypeAndRelationCode(Convert.ToInt32(fileBelongType), new Guid(relationCode));
            return View(Files);
        }

        /// <summary>
        /// 上传附件
        /// </summary>
        /// <param name="relationCode"></param>
        /// <param name="targetDirectory"></param>
        /// <param name="fileBelongType"></param>
        [HttpPost]
        public void UploadAttachment(string relationCode, string targetDirectory, string fileBelongType,string caseChildren)
        {
            string originalFileName = "";
            try
            {
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

                #region 保存信息到数据库
                CommonService.Model.C_Files cFile = new CommonService.Model.C_Files();
                cFile.C_Files_code = Guid.NewGuid();
                cFile.C_Files_viewName = originalFileName;
                cFile.C_Files_name = "/" + targetDirectory + "/" + fileName;
                cFile.C_Files_size = fileLength/1024;
                cFile.C_Files_creator = Context.UIContext.Current.UserCode;
                cFile.C_Files_createDate = DateTime.Now;
                cFile.C_Files_type = extensionName;
                cFile.C_Files_isDelete = 0;
                cFile.C_Files_cate = Convert.ToInt32(caseChildren);
                cFile.C_Files_link = new Guid(relationCode);
                _fileWCF.Add(cFile);

                #endregion
            }
            catch (Exception ex)
            {

            }
        }

	}
}