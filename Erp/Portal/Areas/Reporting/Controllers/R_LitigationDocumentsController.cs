using Maticsoft.Common;
using Portal.Controllers;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.Reporting.Controllers
{
    public class R_LitigationDocumentsController : BaseController
    {

        private readonly ICommonService.Reporting.IR_LitigationDocuments _reporting_CaseWCF;
        private readonly ICommonService.IC_Region _regionWCF;
        // GET: /Reporting/R_LitigationDocuments/
        public R_LitigationDocumentsController()
        {
            _reporting_CaseWCF = ServiceProxyFactory.Create<ICommonService.Reporting.IR_LitigationDocuments>("R_LitigationDocumentsWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
        }
        //
        // GET: /Reporting/R_LitigationDocuments/
        public ActionResult Index()
        {
            

            return View();
        }

        public ActionResult List()
        {
            var areaList = _regionWCF.GetAllList(); //区域
            ViewBag.AreaList = areaList;
            //var list = _reporting_CaseWCF.GetModelList("");
            return View();
        }

        public ActionResult Reporting()
        {
            var areaList = _regionWCF.GetAllList(); //区域
            ViewBag.AreaList = areaList;
            //var list = _reporting_CaseWCF.GetModelList("");
            return View();
        }

        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult AjaxStatistics(jQueryDataTableParamModel param)
        {
            #region 查询拼接条件设置,查询条件根据实际业务进行相应更改)
            //s_number
            //表单查询模型
            CommonService.Model.Reporting.R_LitigationDocuments oFormConditon = new CommonService.Model.Reporting.R_LitigationDocuments();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            int type = Convert.ToInt32(Request.Params.Get("i_statistics"));
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                if (!string.IsNullOrEmpty(Request.Params.Get("i_area")) && Request.Params.Get("i_area") != "-1") //区域
                {
                    oFormConditon.R_LitigationDocuments_area = Request.Params.Get("i_area");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_organ"))) //部门
                {
                    oFormConditon.R_LitigationDocuments_organ = Request.Params.Get("i_organ");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_layyer"))) //主办
                {
                    oFormConditon.R_LitigationDocuments_host = Request.Params.Get("i_layyer");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_number"))) //案件编码
                {
                    oFormConditon.R_LitigationDocuments_caseNumber = Request.Params.Get("i_number");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_project"))) //工程
                {
                    oFormConditon.R_LitigationDocuments_project = Request.Params.Get("i_project");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_court"))) //法院
                {
                    oFormConditon.R_LitigationDocuments_firstCourt = Request.Params.Get("i_court");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_deleg"))) //委托人
                {
                    oFormConditon.R_LitigationDocuments_plaintiff = Request.Params.Get("i_deleg");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_rival"))) //对方当事人
                {
                    oFormConditon.R_LitigationDocuments_otherParty = Request.Params.Get("i_rival");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yjbd"))) //移交标的
                {
                    oFormConditon.R_LitigationDocuments_transferTarget = Request.Params.Get("i_yjbd");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yjbdz"))) //移交标的至
                {
                    oFormConditon.R_LitigationDocuments_transferTargetz = Request.Params.Get("i_yjbdz");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yqsr"))) //预期收益
                {
                    oFormConditon.R_LitigationDocuments_expectedReturn = Request.Params.Get("i_yqsr");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yqsrz"))) //预期收入至
                {
                    oFormConditon.R_LitigationDocuments_expectedReturnz = Request.Params.Get("i_yqsrz");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_time"))) //收案时间
                {
                    oFormConditon.R_LitigationDocuments_closedDate = Request.Params.Get("i_time");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_timez"))) //收案时间至
                {
                    oFormConditon.R_LitigationDocuments_closedDatez = Request.Params.Get("i_timez");
                }
                //string title = Request.Params.Get("s_number");
                //if (title != null && title != "")
                //{
                //    oFormConditon.B_TakeCase_Reporting_caseNumber = title;

                //}
                #endregion
            }

            #endregion




            this.TotalRecordCount = _reporting_CaseWCF.GetDataListCount(oFormConditon, type);



            List<CommonService.Model.Reporting.V_LitigationDocuments> listsLoan = _reporting_CaseWCF.GetDataList(oFormConditon, type, "", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);

            //转化数据格式
            var result = from c in listsLoan
                         select new[] { 
                              c.地区,
                              c.统计项,
                              c.应完成数,   
                              c.移交标的,
                              c.预期收入,
                              c.实际完成数,
                              c.实际移交标的,
                              c.实际预期收入,
                              c.实际完成率,
                              c.超期数,
                              c.超期移交标的,
                              c.超期预期收入,
                              c.超期率,
                              c.超期总时长,
                              c.平均超期时长,
                              c.最长超期时长,
                              c.最短超期时长,
                              c.延期数,
                              c.延期移交标的,
                              c.延期预期收入,
                              c.延期率,
                              c.延期总时长,
                              c.平均延期时长,
                              c.最长延期时长,
                              c.最短延期时长,
                                     
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

        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult AjaxList(jQueryDataTableParamModel param)
        {
            #region 查询拼接条件设置,查询条件根据实际业务进行相应更改)
            //s_number
            //表单查询模型
            CommonService.Model.Reporting.R_LitigationDocuments oFormConditon = new CommonService.Model.Reporting.R_LitigationDocuments();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                if (!string.IsNullOrEmpty(Request.Params.Get("i_area")) && Request.Params.Get("i_area") != "-1") //区域
                {
                    oFormConditon.R_LitigationDocuments_area = Request.Params.Get("i_area");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_organ"))) //部门
                {
                    oFormConditon.R_LitigationDocuments_organ = Request.Params.Get("i_organ");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_layyer"))) //主办
                {
                    oFormConditon.R_LitigationDocuments_host = Request.Params.Get("i_layyer");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_number"))) //案件编码
                {
                    oFormConditon.R_LitigationDocuments_caseNumber = Request.Params.Get("i_number");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_project"))) //工程
                {
                    oFormConditon.R_LitigationDocuments_project = Request.Params.Get("i_project");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_court"))) //法院
                {
                    oFormConditon.R_LitigationDocuments_firstCourt = Request.Params.Get("i_court");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_deleg"))) //委托人
                {
                    oFormConditon.R_LitigationDocuments_plaintiff = Request.Params.Get("i_deleg");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_rival"))) //对方当事人
                {
                    oFormConditon.R_LitigationDocuments_otherParty = Request.Params.Get("i_rival");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yjbd"))) //移交标的
                {
                    oFormConditon.R_LitigationDocuments_transferTarget = Request.Params.Get("i_yjbd");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yjbdz"))) //移交标的至
                {
                    oFormConditon.R_LitigationDocuments_transferTargetz = Request.Params.Get("i_yjbdz");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yqsr"))) //预期收益
                {
                    oFormConditon.R_LitigationDocuments_expectedReturn = Request.Params.Get("i_yqsr");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yqsrz"))) //预期收入至
                {
                    oFormConditon.R_LitigationDocuments_expectedReturnz = Request.Params.Get("i_yqsrz");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_time"))) //收案时间
                {
                    oFormConditon.R_LitigationDocuments_closedDate = Request.Params.Get("i_time");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_timez"))) //收案时间至
                {
                    oFormConditon.R_LitigationDocuments_closedDatez = Request.Params.Get("i_timez");
                }
                //string title = Request.Params.Get("s_number");
                //if (title != null && title != "")
                //{
                //    oFormConditon.B_TakeCase_Reporting_caseNumber = title;

                //}
                #endregion
            }

            #endregion




            this.TotalRecordCount = _reporting_CaseWCF.GetRecordCount(oFormConditon);



            List<CommonService.Model.Reporting.R_LitigationDocuments> listsLoan = _reporting_CaseWCF.GetListByPage(oFormConditon, " ID asc ", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);

            //转化数据格式
            var result = from c in listsLoan
                         select new[] { 
                              c.R_LitigationDocuments_area,
                              c.R_LitigationDocuments_organName,   
                              c.R_LitigationDocuments_host,
                              c.R_LitigationDocuments_co,
                              c.R_LitigationDocuments_firstCourt,
                              c.R_LitigationDocuments_caseNumber,
                              c.R_LitigationDocuments_plaintiff,
                              c.R_LitigationDocuments_otherParty,
                              c.R_LitigationDocuments_project,
                              c.R_LitigationDocuments_closedDate,
                              c.R_LitigationDocuments_transferTarget,
                              c.R_LitigationDocuments_expectedReturn,
                              c.R_LitigationDocuments_isExtension,
                              c.R_LitigationDocuments_extensionTime,
                              c.R_LitigationDocuments_finishedTime,
                                     
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

        #region 数据导出功能
        /// <summary>
        /// 导出报表
        /// </summary>
        /// <returns></returns>
        public FileResult ExportList(FormCollection form)
        {
            #region 查询拼接条件设置,查询条件根据实际业务进行相应更改)
            //s_number
            //表单查询模型
            CommonService.Model.Reporting.R_LitigationDocuments oFormConditon = new CommonService.Model.Reporting.R_LitigationDocuments();
            int type = Convert.ToInt32(form["i_statistics"]);
            string isExecutedSearch = form["isExecutedSearch"];
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                if (!string.IsNullOrEmpty(form["i_area"]) && form["i_area"] != "-1") //区域
                {
                    oFormConditon.R_LitigationDocuments_area = form["i_area"];
                }

                if (!string.IsNullOrEmpty(form["i_organ"])) //部门
                {
                    oFormConditon.R_LitigationDocuments_organ = form["i_organ"];
                }

                if (!string.IsNullOrEmpty(form["i_layyer"])) //主办
                {
                    oFormConditon.R_LitigationDocuments_host = form["i_layyer"];
                }

                if (!string.IsNullOrEmpty(form["i_number"])) //案件编码
                {
                    oFormConditon.R_LitigationDocuments_caseNumber = form["i_number"];
                }

                if (!string.IsNullOrEmpty(form["i_project"])) //工程
                {
                    oFormConditon.R_LitigationDocuments_project = form["i_project"];
                }

                if (!string.IsNullOrEmpty(form["i_court"])) //法院
                {
                    oFormConditon.R_LitigationDocuments_firstCourt = form["i_court"];
                }

                if (!string.IsNullOrEmpty(form["i_deleg"])) //委托人
                {
                    oFormConditon.R_LitigationDocuments_plaintiff = form["i_deleg"];
                }

                if (!string.IsNullOrEmpty(form["i_rival"])) //对方当事人
                {
                    oFormConditon.R_LitigationDocuments_otherParty = form["i_rival"];
                }

                if (!string.IsNullOrEmpty(form["i_yjbd"])) //移交标的
                {
                    oFormConditon.R_LitigationDocuments_transferTarget = form["i_yjbd"];
                }

                if (!string.IsNullOrEmpty(form["i_yjbdz"])) //移交标的至
                {
                    oFormConditon.R_LitigationDocuments_transferTargetz = form["i_yjbdz"];
                }

                if (!string.IsNullOrEmpty(form["i_yqsr"])) //预期收益
                {
                    oFormConditon.R_LitigationDocuments_expectedReturn = form["i_yqsr"];
                }

                if (!string.IsNullOrEmpty(form["i_yqsrz"])) //预期收入至
                {
                    oFormConditon.R_LitigationDocuments_expectedReturnz = form["i_yqsrz"];
                }

                if (!string.IsNullOrEmpty(form["i_time"])) //收案时间
                {
                    oFormConditon.R_LitigationDocuments_closedDate = form["i_time"];
                }

                if (!string.IsNullOrEmpty(form["i_timez"])) //收案时间至
                {
                    oFormConditon.R_LitigationDocuments_closedDatez = form["i_timez"];
                }
                //string title = Request.Params.Get("s_number");
                //if (title != null && title != "")
                //{
                //    oFormConditon.B_TakeCase_Reporting_caseNumber = title;

                //}
                #endregion
            }

            #endregion

            List<CommonService.Model.Reporting.R_LitigationDocuments> listsLoan = _reporting_CaseWCF.GetListByPage(oFormConditon, " ID asc ", 1, 1000000);



            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            //貌似这里可以设置各种样式字体颜色背景等，但是不是很方便，这里就不设置了

            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("区域");
            row1.CreateCell(1).SetCellValue("部门");
            row1.CreateCell(2).SetCellValue("主办/独立律师");
            row1.CreateCell(3).SetCellValue("协办/助理律师");
            row1.CreateCell(4).SetCellValue("一审管辖法院");
            row1.CreateCell(5).SetCellValue("案号");
            row1.CreateCell(6).SetCellValue("原告");
            row1.CreateCell(7).SetCellValue("被告");
            row1.CreateCell(8).SetCellValue("项目");
            row1.CreateCell(9).SetCellValue("收案时间");
            row1.CreateCell(10).SetCellValue("移交标的");
            row1.CreateCell(11).SetCellValue("预期收入");
            row1.CreateCell(12).SetCellValue("是否申请延期");
            row1.CreateCell(13).SetCellValue("申请延期时长");
            row1.CreateCell(14).SetCellValue("实际完成时间");



            //....N行


            //将数据逐步写入sheet1各个行
            for (int i = 0; i < listsLoan.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);

                rowtemp.CreateCell(0).SetCellValue(listsLoan[i].R_LitigationDocuments_area);
                rowtemp.CreateCell(1).SetCellValue(listsLoan[i].R_LitigationDocuments_organName);
                rowtemp.CreateCell(2).SetCellValue(listsLoan[i].R_LitigationDocuments_host);
                rowtemp.CreateCell(3).SetCellValue(listsLoan[i].R_LitigationDocuments_co);
                rowtemp.CreateCell(4).SetCellValue(listsLoan[i].R_LitigationDocuments_firstCourt);
                rowtemp.CreateCell(5).SetCellValue(listsLoan[i].R_LitigationDocuments_caseNumber);
                rowtemp.CreateCell(6).SetCellValue(listsLoan[i].R_LitigationDocuments_plaintiff);
                rowtemp.CreateCell(7).SetCellValue(listsLoan[i].R_LitigationDocuments_otherParty);
                rowtemp.CreateCell(8).SetCellValue(listsLoan[i].R_LitigationDocuments_project);
                rowtemp.CreateCell(9).SetCellValue(listsLoan[i].R_LitigationDocuments_closedDate);
                rowtemp.CreateCell(10).SetCellValue(listsLoan[i].R_LitigationDocuments_transferTarget);
                rowtemp.CreateCell(11).SetCellValue(listsLoan[i].R_LitigationDocuments_expectedReturn);
                rowtemp.CreateCell(12).SetCellValue(listsLoan[i].R_LitigationDocuments_isExtension);

                rowtemp.CreateCell(13).SetCellValue(listsLoan[i].R_LitigationDocuments_isExtension);
                rowtemp.CreateCell(14).SetCellValue(listsLoan[i].R_LitigationDocuments_finishedTime);




                //....N行
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "诉讼文书制作报表" + dateTime + ".xls";
            return File(ms, "application/vnd.ms-excel", fileName);
        }

        /// <summary>
        /// 导出报表
        /// </summary>
        /// <returns></returns>
        public FileResult ExportReporting(FormCollection form)
        {
            #region 查询拼接条件设置,查询条件根据实际业务进行相应更改)
            //s_number
            //表单查询模型
            CommonService.Model.Reporting.R_LitigationDocuments oFormConditon = new CommonService.Model.Reporting.R_LitigationDocuments();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            int type = Convert.ToInt32(Request.Params.Get("i_statistics"));
            string typeN = type == 1 ? "区域" : type == 2 ? "部门" : type == 3 ? "主办律师" : type == 4 ? "一审管辖法院" : "";
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                if (!string.IsNullOrEmpty(Request.Params.Get("i_area")) && Request.Params.Get("i_area") != "-1") //区域
                {
                    oFormConditon.R_LitigationDocuments_area = Request.Params.Get("i_area");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_organ"))) //部门
                {
                    oFormConditon.R_LitigationDocuments_organ = Request.Params.Get("i_organ");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_layyer"))) //主办
                {
                    oFormConditon.R_LitigationDocuments_host = Request.Params.Get("i_layyer");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_number"))) //案件编码
                {
                    oFormConditon.R_LitigationDocuments_caseNumber = Request.Params.Get("i_number");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_project"))) //工程
                {
                    oFormConditon.R_LitigationDocuments_project = Request.Params.Get("i_project");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_court"))) //法院
                {
                    oFormConditon.R_LitigationDocuments_firstCourt = Request.Params.Get("i_court");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_deleg"))) //委托人
                {
                    oFormConditon.R_LitigationDocuments_plaintiff = Request.Params.Get("i_deleg");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_rival"))) //对方当事人
                {
                    oFormConditon.R_LitigationDocuments_otherParty = Request.Params.Get("i_rival");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yjbd"))) //移交标的
                {
                    oFormConditon.R_LitigationDocuments_transferTarget = Request.Params.Get("i_yjbd");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yjbdz"))) //移交标的至
                {
                    oFormConditon.R_LitigationDocuments_transferTargetz = Request.Params.Get("i_yjbdz");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yqsr"))) //预期收益
                {
                    oFormConditon.R_LitigationDocuments_expectedReturn = Request.Params.Get("i_yqsr");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yqsrz"))) //预期收入至
                {
                    oFormConditon.R_LitigationDocuments_expectedReturnz = Request.Params.Get("i_yqsrz");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_time"))) //收案时间
                {
                    oFormConditon.R_LitigationDocuments_closedDate = Request.Params.Get("i_time");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_timez"))) //收案时间至
                {
                    oFormConditon.R_LitigationDocuments_closedDatez = Request.Params.Get("i_timez");
                }
                //string title = Request.Params.Get("s_number");
                //if (title != null && title != "")
                //{
                //    oFormConditon.B_TakeCase_Reporting_caseNumber = title;

                //}
                #endregion
            }

            #endregion

            List<CommonService.Model.Reporting.V_LitigationDocuments> listsLoan = _reporting_CaseWCF.GetDataList(oFormConditon, type, "", 1, 1000000);



            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            //貌似这里可以设置各种样式字体颜色背景等，但是不是很方便，这里就不设置了

            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue(typeN);
            row1.CreateCell(1).SetCellValue("应完成数");
            row1.CreateCell(2).SetCellValue("移交标的");
            row1.CreateCell(3).SetCellValue("预期收入");
            row1.CreateCell(4).SetCellValue("实际完成数");
            row1.CreateCell(5).SetCellValue("移交标的");
            row1.CreateCell(6).SetCellValue("预期收入");
            row1.CreateCell(7).SetCellValue("完成率");
            row1.CreateCell(8).SetCellValue("超期数");
            row1.CreateCell(9).SetCellValue("移交标的");
            row1.CreateCell(10).SetCellValue("预期收入");
            row1.CreateCell(11).SetCellValue("超期率");
            row1.CreateCell(12).SetCellValue("超期总时长");
            row1.CreateCell(13).SetCellValue("平均超期时长");
            row1.CreateCell(14).SetCellValue("最长超期时长");
            row1.CreateCell(15).SetCellValue("最短超期时长");
            row1.CreateCell(16).SetCellValue("延期数");
            row1.CreateCell(17).SetCellValue("移交标的");
            row1.CreateCell(18).SetCellValue("预期收入");
            row1.CreateCell(19).SetCellValue("延期率");
            row1.CreateCell(20).SetCellValue("延期总时长");
            row1.CreateCell(21).SetCellValue("平均延期时长");
            row1.CreateCell(22).SetCellValue("最长延期时长");
            row1.CreateCell(23).SetCellValue("最短延期时长");



            //....N行


            //将数据逐步写入sheet1各个行
            for (int i = 0; i < listsLoan.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);

                rowtemp.CreateCell(0).SetCellValue(listsLoan[i].统计项);
                rowtemp.CreateCell(1).SetCellValue(listsLoan[i].应完成数);
                rowtemp.CreateCell(2).SetCellValue(listsLoan[i].移交标的);
                rowtemp.CreateCell(3).SetCellValue(listsLoan[i].预期收入);
                rowtemp.CreateCell(4).SetCellValue(listsLoan[i].实际完成数);
                rowtemp.CreateCell(5).SetCellValue(listsLoan[i].实际移交标的);
                rowtemp.CreateCell(6).SetCellValue(listsLoan[i].实际预期收入);
                rowtemp.CreateCell(7).SetCellValue(listsLoan[i].实际完成率);
                rowtemp.CreateCell(8).SetCellValue(listsLoan[i].超期数);
                rowtemp.CreateCell(9).SetCellValue(listsLoan[i].超期移交标的);
                rowtemp.CreateCell(10).SetCellValue(listsLoan[i].超期预期收入);
                rowtemp.CreateCell(11).SetCellValue(listsLoan[i].超期率);
                rowtemp.CreateCell(12).SetCellValue(listsLoan[i].超期总时长);
                rowtemp.CreateCell(13).SetCellValue(listsLoan[i].平均超期时长);
                rowtemp.CreateCell(14).SetCellValue(listsLoan[i].最长超期时长);
                rowtemp.CreateCell(15).SetCellValue(listsLoan[i].最短超期时长);
                rowtemp.CreateCell(16).SetCellValue(listsLoan[i].延期数);
                rowtemp.CreateCell(17).SetCellValue(listsLoan[i].延期移交标的);
                rowtemp.CreateCell(18).SetCellValue(listsLoan[i].延期预期收入);
                rowtemp.CreateCell(19).SetCellValue(listsLoan[i].延期率);
                rowtemp.CreateCell(20).SetCellValue(listsLoan[i].延期总时长);
                rowtemp.CreateCell(21).SetCellValue(listsLoan[i].平均延期时长);
                rowtemp.CreateCell(22).SetCellValue(listsLoan[i].最长延期时长);
                rowtemp.CreateCell(23).SetCellValue(listsLoan[i].最短延期时长);


                //....N行
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "诉讼文书制作统计" + dateTime + ".xls";
            return File(ms, "application/vnd.ms-excel", fileName);
        }
        #endregion

        /// <summary>
        /// 统计
        /// </summary>
        [HttpPost]
        public void TbService()
        {
            _reporting_CaseWCF.Statistics();
        }
	}
}