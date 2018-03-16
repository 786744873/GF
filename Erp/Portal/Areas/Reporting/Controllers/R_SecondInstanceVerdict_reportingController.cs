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
    public class R_SecondInstanceVerdict_reportingController : BaseController
    {

        private readonly ICommonService.Reporting.IR_SecondInstanceVerdict_reporting _reporting_CaseWCF;
        private readonly ICommonService.IC_Region _regionWCF;
        // GET: /Reporting/R_SecondInstanceVerdict_reporting/
        public R_SecondInstanceVerdict_reportingController()
        {
            _reporting_CaseWCF = ServiceProxyFactory.Create<ICommonService.Reporting.IR_SecondInstanceVerdict_reporting>("R_SecondInstanceVerdict_reportingWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
        }
        //
        // GET: /Reporting/R_SecondInstanceVerdict_reporting/
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult List()
        {
            var areaList = _regionWCF.GetAllList(); //区域
            ViewBag.AreaList = areaList;

            return View();
        }

        public ActionResult Reporting()
        {
            var areaList = _regionWCF.GetAllList(); //区域
            ViewBag.AreaList = areaList;

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
            CommonService.Model.Reporting.R_SecondInstanceVerdict_reporting oFormConditon = new CommonService.Model.Reporting.R_SecondInstanceVerdict_reporting();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            int type = Convert.ToInt32(Request.Params.Get("i_statistics"));
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                if (!string.IsNullOrEmpty(Request.Params.Get("i_area")) && Request.Params.Get("i_area") != "-1") //区域
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_area = Request.Params.Get("i_area");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_organ"))) //部门
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_organ = Request.Params.Get("i_organ");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_layyer"))) //主办
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_host = Request.Params.Get("i_layyer");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_number"))) //案件编码
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_caseNumber = Request.Params.Get("i_number");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_project"))) //工程
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_project = Request.Params.Get("i_project");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_court"))) //法院
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_firstCourt = Request.Params.Get("i_court");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_deleg"))) //委托人
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_plaintiff = Request.Params.Get("i_deleg");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_rival"))) //对方当事人
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_otherParty = Request.Params.Get("i_rival");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yjbd"))) //移交标的
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_transferTarget = Request.Params.Get("i_yjbd");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yjbdz"))) //移交标的至
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_transferTargetz = Request.Params.Get("i_yjbdz");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yqsr"))) //预期收益
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_expectedReturn = Request.Params.Get("i_yqsr");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yqsrz"))) //预期收入至
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_expectedReturnz = Request.Params.Get("i_yqsrz");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_time"))) //收案时间
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_closedDate = Request.Params.Get("i_time");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_timez"))) //收案时间至
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_closedDatez = Request.Params.Get("i_timez");
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



            List<CommonService.Model.Reporting.V_SecondInstanceVerdict_reporting> listsLoan = _reporting_CaseWCF.GetDataList(oFormConditon, type, "", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);

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
                              c.判决数,
                              c.判决率,
                              c.调解数,
                              c.调解率,
                              c.维持原判数,
                              c.维持原判率,
                              c.结案数,
                              c.结案率,
                              c.文书收入,
                                     
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
            CommonService.Model.Reporting.R_SecondInstanceVerdict_reporting oFormConditon = new CommonService.Model.Reporting.R_SecondInstanceVerdict_reporting();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                if (!string.IsNullOrEmpty(Request.Params.Get("i_area")) && Request.Params.Get("i_area") != "-1") //区域
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_area = Request.Params.Get("i_area");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_organ"))) //部门
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_organ = Request.Params.Get("i_organ");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_layyer"))) //主办
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_host = Request.Params.Get("i_layyer");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_number"))) //案件编码
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_caseNumber = Request.Params.Get("i_number");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_project"))) //工程
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_project = Request.Params.Get("i_project");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_court"))) //法院
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_firstCourt = Request.Params.Get("i_court");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_deleg"))) //委托人
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_plaintiff = Request.Params.Get("i_deleg");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_rival"))) //对方当事人
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_otherParty = Request.Params.Get("i_rival");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yjbd"))) //移交标的
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_transferTarget = Request.Params.Get("i_yjbd");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yjbdz"))) //移交标的至
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_transferTargetz = Request.Params.Get("i_yjbdz");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yqsr"))) //预期收益
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_expectedReturn = Request.Params.Get("i_yqsr");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yqsrz"))) //预期收入至
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_expectedReturnz = Request.Params.Get("i_yqsrz");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_time"))) //收案时间
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_closedDate = Request.Params.Get("i_time");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_timez"))) //收案时间至
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_closedDatez = Request.Params.Get("i_timez");
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



            List<CommonService.Model.Reporting.R_SecondInstanceVerdict_reporting> listsLoan = _reporting_CaseWCF.GetListByPage(oFormConditon, " ID asc ", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);

            //转化数据格式
            var result = from c in listsLoan
                         select new[] { 
                              c.R_SecondInstanceVerdict_reporting_area,
                              c.R_SecondInstanceVerdict_reporting_organName,   
                              c.R_SecondInstanceVerdict_reporting_host,
                              c.R_SecondInstanceVerdict_reporting_co,
                              c.R_SecondInstanceVerdict_reporting_firstCourt,
                              c.R_SecondInstanceVerdict_reporting_caseNumber,
                              c.R_SecondInstanceVerdict_reporting_plaintiff,
                              c.R_SecondInstanceVerdict_reporting_otherParty,
                              c.R_SecondInstanceVerdict_reporting_project,
                              c.R_SecondInstanceVerdict_reporting_closedDate,
                              c.R_SecondInstanceVerdict_reporting_transferTarget,
                              c.R_SecondInstanceVerdict_reporting_expectedReturn,
                              c.R_SecondInstanceVerdict_reporting_fitingTime,
                              c.R_SecondInstanceVerdict_reporting_startDate,
                              c.R_SecondInstanceVerdict_reporting_isExtension,
                              c.R_SecondInstanceVerdict_reporting_extensionTime,
                              c.R_SecondInstanceVerdict_reporting_finishedTime,
                              c.R_SecondInstanceVerdict_reporting_InstrumentsType,
                              c.R_SecondInstanceVerdict_reporting_isValidate,
                              c.R_SecondInstanceVerdict_reporting_InstrumentsMoney,
                              c.R_SecondInstanceVerdict_reporting_iswei,
                                     
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
            CommonService.Model.Reporting.R_SecondInstanceVerdict_reporting oFormConditon = new CommonService.Model.Reporting.R_SecondInstanceVerdict_reporting();
            int type = Convert.ToInt32(form["i_statistics"]);
            string isExecutedSearch = form["isExecutedSearch"];
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                if (!string.IsNullOrEmpty(form["i_area"]) && form["i_area"] != "-1") //区域
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_area = form["i_area"];
                }

                if (!string.IsNullOrEmpty(form["i_organ"])) //部门
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_organ = form["i_organ"];
                }

                if (!string.IsNullOrEmpty(form["i_layyer"])) //主办
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_host = form["i_layyer"];
                }

                if (!string.IsNullOrEmpty(form["i_number"])) //案件编码
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_caseNumber = form["i_number"];
                }

                if (!string.IsNullOrEmpty(form["i_project"])) //工程
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_project = form["i_project"];
                }

                if (!string.IsNullOrEmpty(form["i_court"])) //法院
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_firstCourt = form["i_court"];
                }

                if (!string.IsNullOrEmpty(form["i_deleg"])) //委托人
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_plaintiff = form["i_deleg"];
                }

                if (!string.IsNullOrEmpty(form["i_rival"])) //对方当事人
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_otherParty = form["i_rival"];
                }

                if (!string.IsNullOrEmpty(form["i_yjbd"])) //移交标的
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_transferTarget = form["i_yjbd"];
                }

                if (!string.IsNullOrEmpty(form["i_yjbdz"])) //移交标的至
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_transferTargetz = form["i_yjbdz"];
                }

                if (!string.IsNullOrEmpty(form["i_yqsr"])) //预期收益
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_expectedReturn = form["i_yqsr"];
                }

                if (!string.IsNullOrEmpty(form["i_yqsrz"])) //预期收入至
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_expectedReturnz = form["i_yqsrz"];
                }

                if (!string.IsNullOrEmpty(form["i_time"])) //收案时间
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_closedDate = form["i_time"];
                }

                if (!string.IsNullOrEmpty(form["i_timez"])) //收案时间至
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_closedDatez = form["i_timez"];
                }
                //string title = Request.Params.Get("s_number");
                //if (title != null && title != "")
                //{
                //    oFormConditon.B_TakeCase_Reporting_caseNumber = title;

                //}
                #endregion
            }

            #endregion

            List<CommonService.Model.Reporting.R_SecondInstanceVerdict_reporting> listsLoan = _reporting_CaseWCF.GetListByPage(oFormConditon, " ID asc ", 1, 1000000);



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
            row1.CreateCell(4).SetCellValue("二审管辖法院");
            row1.CreateCell(5).SetCellValue("案号");
            row1.CreateCell(6).SetCellValue("原告");
            row1.CreateCell(7).SetCellValue("被告");
            row1.CreateCell(8).SetCellValue("项目");
            row1.CreateCell(9).SetCellValue("收案时间");
            row1.CreateCell(10).SetCellValue("移交标的");
            row1.CreateCell(11).SetCellValue("预期收入");
            row1.CreateCell(12).SetCellValue("立案时间");
            row1.CreateCell(13).SetCellValue("二审开始时间");
            row1.CreateCell(14).SetCellValue("是否申请延期");
            row1.CreateCell(15).SetCellValue("申请延期时长");
            row1.CreateCell(16).SetCellValue("实际完成时间");
            row1.CreateCell(17).SetCellValue("文书类型");
            row1.CreateCell(18).SetCellValue("文书是否生效");
            row1.CreateCell(19).SetCellValue("文书收入");
            row1.CreateCell(20).SetCellValue("是否维持原判");



            //....N行


            //将数据逐步写入sheet1各个行
            for (int i = 0; i < listsLoan.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);

                rowtemp.CreateCell(0).SetCellValue(listsLoan[i].R_SecondInstanceVerdict_reporting_area);
                rowtemp.CreateCell(1).SetCellValue(listsLoan[i].R_SecondInstanceVerdict_reporting_organName);
                rowtemp.CreateCell(2).SetCellValue(listsLoan[i].R_SecondInstanceVerdict_reporting_host);
                rowtemp.CreateCell(3).SetCellValue(listsLoan[i].R_SecondInstanceVerdict_reporting_co);
                rowtemp.CreateCell(4).SetCellValue(listsLoan[i].R_SecondInstanceVerdict_reporting_firstCourt);
                rowtemp.CreateCell(5).SetCellValue(listsLoan[i].R_SecondInstanceVerdict_reporting_caseNumber);
                rowtemp.CreateCell(6).SetCellValue(listsLoan[i].R_SecondInstanceVerdict_reporting_plaintiff);
                rowtemp.CreateCell(7).SetCellValue(listsLoan[i].R_SecondInstanceVerdict_reporting_otherParty);
                rowtemp.CreateCell(8).SetCellValue(listsLoan[i].R_SecondInstanceVerdict_reporting_project);
                rowtemp.CreateCell(9).SetCellValue(listsLoan[i].R_SecondInstanceVerdict_reporting_closedDate);
                rowtemp.CreateCell(10).SetCellValue(listsLoan[i].R_SecondInstanceVerdict_reporting_transferTarget);
                rowtemp.CreateCell(11).SetCellValue(listsLoan[i].R_SecondInstanceVerdict_reporting_expectedReturn);
                rowtemp.CreateCell(12).SetCellValue(listsLoan[i].R_SecondInstanceVerdict_reporting_fitingTime);
                rowtemp.CreateCell(13).SetCellValue(listsLoan[i].R_SecondInstanceVerdict_reporting_startDate);
                rowtemp.CreateCell(14).SetCellValue(listsLoan[i].R_SecondInstanceVerdict_reporting_isExtension);
                rowtemp.CreateCell(15).SetCellValue(listsLoan[i].R_SecondInstanceVerdict_reporting_extensionTime);
                rowtemp.CreateCell(16).SetCellValue(listsLoan[i].R_SecondInstanceVerdict_reporting_finishedTime);
                rowtemp.CreateCell(17).SetCellValue(listsLoan[i].R_SecondInstanceVerdict_reporting_InstrumentsType);
                rowtemp.CreateCell(18).SetCellValue(listsLoan[i].R_SecondInstanceVerdict_reporting_isValidate);
                rowtemp.CreateCell(19).SetCellValue(listsLoan[i].R_SecondInstanceVerdict_reporting_InstrumentsMoney);
                rowtemp.CreateCell(20).SetCellValue(listsLoan[i].R_SecondInstanceVerdict_reporting_iswei);



                //....N行
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "二审判决报表" + dateTime + ".xls";
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
            CommonService.Model.Reporting.R_SecondInstanceVerdict_reporting oFormConditon = new CommonService.Model.Reporting.R_SecondInstanceVerdict_reporting();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            int type = Convert.ToInt32(Request.Params.Get("i_statistics"));
            string typeN = type == 1 ? "区域" : type == 2 ? "部门" : type == 3 ? "主办律师" : type == 4 ? "二审管辖法院" : "";
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                if (!string.IsNullOrEmpty(Request.Params.Get("i_area")) && Request.Params.Get("i_area") != "-1") //区域
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_area = Request.Params.Get("i_area");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_organ"))) //部门
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_organ = Request.Params.Get("i_organ");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_layyer"))) //主办
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_host = Request.Params.Get("i_layyer");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_number"))) //案件编码
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_caseNumber = Request.Params.Get("i_number");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_project"))) //工程
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_project = Request.Params.Get("i_project");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_court"))) //法院
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_firstCourt = Request.Params.Get("i_court");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_deleg"))) //委托人
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_plaintiff = Request.Params.Get("i_deleg");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_rival"))) //对方当事人
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_otherParty = Request.Params.Get("i_rival");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yjbd"))) //移交标的
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_transferTarget = Request.Params.Get("i_yjbd");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yjbdz"))) //移交标的至
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_transferTargetz = Request.Params.Get("i_yjbdz");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yqsr"))) //预期收益
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_expectedReturn = Request.Params.Get("i_yqsr");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_yqsrz"))) //预期收入至
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_expectedReturnz = Request.Params.Get("i_yqsrz");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_time"))) //收案时间
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_closedDate = Request.Params.Get("i_time");
                }

                if (!string.IsNullOrEmpty(Request.Params.Get("i_timez"))) //收案时间至
                {
                    oFormConditon.R_SecondInstanceVerdict_reporting_closedDatez = Request.Params.Get("i_timez");
                }
                //string title = Request.Params.Get("s_number");
                //if (title != null && title != "")
                //{
                //    oFormConditon.B_TakeCase_Reporting_caseNumber = title;

                //}
                #endregion
            }

            #endregion

            List<CommonService.Model.Reporting.V_SecondInstanceVerdict_reporting> listsLoan = _reporting_CaseWCF.GetDataList(oFormConditon, type, "", 1, 1000000);



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
            row1.CreateCell(24).SetCellValue("判决数");
            row1.CreateCell(25).SetCellValue("判决率");
            row1.CreateCell(26).SetCellValue("调解数");
            row1.CreateCell(27).SetCellValue("调解率");
            row1.CreateCell(28).SetCellValue("原判维持数");
            row1.CreateCell(29).SetCellValue("原判维持率");
            row1.CreateCell(30).SetCellValue("结案数");
            row1.CreateCell(31).SetCellValue("结案率");
            row1.CreateCell(32).SetCellValue("文书收入");

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
                rowtemp.CreateCell(24).SetCellValue(listsLoan[i].判决数);
                rowtemp.CreateCell(25).SetCellValue(listsLoan[i].判决率);
                rowtemp.CreateCell(26).SetCellValue(listsLoan[i].调解数);
                rowtemp.CreateCell(27).SetCellValue(listsLoan[i].调解率);
                rowtemp.CreateCell(28).SetCellValue(listsLoan[i].维持原判数);
                rowtemp.CreateCell(29).SetCellValue(listsLoan[i].维持原判率);
                rowtemp.CreateCell(30).SetCellValue(listsLoan[i].结案数);
                rowtemp.CreateCell(31).SetCellValue(listsLoan[i].结案率);
                rowtemp.CreateCell(32).SetCellValue(listsLoan[i].文书收入);


                //....N行
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "二审判决统计" + dateTime + ".xls";
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