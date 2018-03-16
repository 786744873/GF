using Maticsoft.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.KMS.Controllers
{
    public class PaperManagementController : BaseController
    {
        private readonly ICommonService.KMS.IK_Knowledge _knowledgeWCF;
        private readonly ICommonService.KMS.IK_Exam _examWCF;
        //
        // GET: /KMS/PaperManagement/
        public PaperManagementController()
        {
            #region 服务初始化
            _knowledgeWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Knowledge>("K_KnowledgeWCF");
            _examWCF = ServiceProxyFactory.Create<ICommonService.KMS.IK_Exam>("K_ExamWCF");
            #endregion

        }

        #region 考试增删改查

        /// <summary>
        /// 考试列表页
        /// </summary>
        /// <returns></returns>
        public ActionResult PaperList(string knowledgeCode)
        {
            List<CommonService.Model.KMS.K_Exam> examList = new List<CommonService.Model.KMS.K_Exam>();

            #region 查询条件

            CommonService.Model.KMS.K_Exam model = new CommonService.Model.KMS.K_Exam();

            model.K_Exam_name = "";

            #endregion

            #region 获取所有知识分类
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
            #endregion

            if (!String.IsNullOrEmpty(knowledgeCode))
            {
                string knowledge = "'" + knowledgeCode + "'";
                examList = _examWCF.GetListByCategory(knowledge, model);
                ViewBag.knowledgeCode = knowledgeCode;
            }
            else
            {
                //根据分类权限查询所有考试
                string knowledgeList = "";
                foreach (var knowledge in listK)
                {
                    knowledgeList += "'" + knowledge.K_Knowledge_code + "',";
                }
                knowledgeList = knowledgeList.Substring(0, knowledgeList.Length - 1);
                examList = _examWCF.GetListByCategory(knowledgeList, model);
                ViewBag.knowledgeCode = "";
            }
            ViewBag.examList = examList;

            return View();
        }

        /// <summary>
        /// 添加考试页
        /// </summary>
        /// <returns></returns>
        public ActionResult Create(string examcode)
        {
            CommonService.Model.KMS.K_Exam model = new CommonService.Model.KMS.K_Exam();
            if (examcode != null && examcode != "")
            {
                Guid code = new Guid(examcode);
                model = _examWCF.GetModel(code);
            }

            List<CommonService.Model.KMS.K_Knowledge> knowledgeList = new List<CommonService.Model.KMS.K_Knowledge>();
            if (!Context.UIContext.Current.IsPreSetManager)
            {
                knowledgeList = _knowledgeWCF.GetAllListByPerson(Context.UIContext.Current.RootUserCode.Value);
            }
            else
            {
                knowledgeList = _knowledgeWCF.GetAllList();
            }
            ViewBag.KnowlwedgeList = knowledgeList;
            return View(model);
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection form, CommonService.Model.KMS.K_Exam exam)
        {
            #region 二维码
            string imageName = "";
            string imageDirectory = "img";//二维码图片存放位置
            try
            {
                if (Request.Files.Count != 0)
                {
                    HttpFileCollectionBase imgfiles = Request.Files;
                    HttpPostedFileBase httpPostFileImage = imgfiles["paperImage"];
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
                        exam.K_Exam_img = "\\" + imageDirectory + "\\" + imgfileName;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            #endregion

            string Knowledge = form["K_Exam_category"].ToString();
            exam.K_Exam_category = new Guid(Knowledge);
            bool isSuccess = false;
            if (exam.K_Exam_id > 0)
            {//修改
                isSuccess = _examWCF.Update(exam);
            }
            else
            {//添加
                exam.K_Exam_createtime = DateTime.Now;
                exam.K_Exam_isDelete = false;
                isSuccess = _examWCF.Add(exam);
            }
            if (isSuccess)
                return Json(TipHelper.JsonData("提交考试信息成功！", "/kms/papermanagement/paperlist", IsAlertTip.No, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.ThisPageGoAnotherPage));
            else
                return Json(TipHelper.JsonData("提交考试信息失败！", "", IsAlertTip.No, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
        }

        /// <summary>
        /// 删除考试
        /// </summary>
        /// <param name="examcode"></param>
        /// <returns></returns>
        public ActionResult Delete(string examcode)
        {
            bool isSuccess = _examWCF.Delete(new Guid(examcode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除考试成功！", "/kms/papermanagement/paperlist", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseTipAndRefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除考试失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        #endregion

        #region 考试报表

        public ActionResult ExamReport()
        {
            string url = "http://www.101test.com/client/open/getToken";//http post 接口
            //{"username":"1058516205@qq.com","password":"123456","encrypted":false} 
            string postData = "{\"username\":\"1058516205@qq.com\",\"password\":\"123456\",\"encrypted\":false}";//参数
            string getToken = PostWebRequest(url, postData);
            ViewBag.strValue = getToken;
            JObject jo = (JObject)JsonConvert.DeserializeObject(getToken);
            string Data = jo["data"].ToString();//返回的token：21495:ZqfbtZfW68BKyKBaLo4-4a3rAUsliiYlynTjV1lOI0hBpvZUCKEJq7f-BvRf3GsOHi5zWgnmb3_REWVQOuv0fw
            ViewBag.Data = Data;


            //测试  获取报告
            string reportUrl = "http://www.101test.com/client/open/getReport";//http post 接口
            string reportData = "{\"token\":\"21495:ZqfbtZfW68BKyKBaLo4-4a3rAUsliiYlynTjV1lOI0hBpvZUCKEJq7f-BvRf3GsOHi5zWgnmb3_REWVQOuv0fw\",\"testId\":84211}";//参数
            string getReport = PostWebRequest(reportUrl, reportData);
            ViewBag.getReport = getReport;

            return View();
        }

        /// <summary>
        /// http post 接口请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// 作者：陈盼盼
        /// 日期2016-3-8
        /// <returns></returns>
        private string PostWebRequest(string url, string paraUrlCoded)
        {
            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);//转化
            request.ContentLength = payload.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(payload, 0, payload.Length);//写入参数
            writer.Close();
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s = response.GetResponseStream();
            string StrDate = "";
            string strValue = "";
            StreamReader Reader = new StreamReader(s, Encoding.UTF8);
            //strValue = Reader.ReadToEnd();//获取json返回值
            while ((StrDate = Reader.ReadLine()) != null)
            {
                strValue += StrDate + "\r\n";
            }
            return strValue;
        }

        #endregion
    }
}