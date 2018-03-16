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
    public class R_ConsultantCase_ReportingController : BaseController
    {
        private readonly ICommonService.Reporting.IR_ConsultantCase_Reporting _reporting_CaseWCF;
        // GET: /Reporting/R_ConsultantCase_Reporting/
       public R_ConsultantCase_ReportingController()
        {
            _reporting_CaseWCF = ServiceProxyFactory.Create<ICommonService.Reporting.IR_ConsultantCase_Reporting>("R_ConsultantCase_ReportingWCF");
        }
        public ActionResult List()
        {

            var list = _reporting_CaseWCF.GetModelList(" ");

            return View();
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
            CommonService.Model.Reporting.R_ConsultantCase_Reporting oFormConditon = new CommonService.Model.Reporting.R_ConsultantCase_Reporting();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_number");
                if (title != null && title != "")
                {
                    oFormConditon.R_ConsultantCase_Reporting_typeCount = title;

                }
                #endregion
            }

            #endregion




            this.TotalRecordCount = _reporting_CaseWCF.GetRecordCount("");



            List<CommonService.Model.Reporting.R_ConsultantCase_Reporting> listsLoan = _reporting_CaseWCF.GetListByPage("", " ID asc ", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);

            //转化数据格式
            var result = from c in listsLoan
                         select new[] { 
                              c.R_ConsultantCase_Reporting_year,
                               c.R_ConsultantCase_Reporting_month,
                               c.R_ConsultantCase_Reporting_area,
                               c.R_ConsultantCase_Reporting_allCount,
                               c.R_ConsultantCase_Reporting_typeCount,
                               c.R_ConsultantCase_Reporting_unTypeCount,
                               c.R_ConsultantCase_Reporting_customerCount,
                               c.R_ConsultantCase_Reporting_newCustomer,
                               c.R_ConsultantCase_Reporting_oldCustomer,
                               c.R_ConsultantCase_Reporting_transferTarget,
                              c.R_ConsultantCase_Reporting_typeTransferTarget,
                              c.R_ConsultantCase_Reporting_unTypeTransferTarget,
                                c.R_ConsultantCase_Reporting_expectedReturn,
                                c.R_ConsultantCase_Reporting_typeExpectedReturn,
                               c.R_ConsultantCase_Reporting_unTypeExpectedReturn,
                                  c.R_ConsultantCase_Reporting_monthCount,
                                  c.R_ConsultantCase_Reporting_cCompletion,
                                  c.R_ConsultantCase_Reporting_nextMonthCount,
                                  c.R_ConsultantCase_Reporting_monthExpected,
                                  c.R_ConsultantCase_Reporting_eCompletion,
                                  c.R_ConsultantCase_Reporting_nextMonthExpected,


            

                                                  
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


        [HttpPost]
        public string TbService()
        {

            _reporting_CaseWCF.Statistics();

            return "成功";


        }
        #region 数据导出功能
        public FileResult Export()
        {
            #region 查询拼接条件设置,查询条件根据实际业务进行相应更改)
            //s_number
            //表单查询模型
            CommonService.Model.Reporting.R_ConsultantCase_Reporting oFormConditon = new CommonService.Model.Reporting.R_ConsultantCase_Reporting();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_number");
                if (title != null && title != "")
                {
                    oFormConditon.R_ConsultantCase_Reporting_area = title;

                }
                #endregion
            }

            #endregion




            this.TotalRecordCount = _reporting_CaseWCF.GetRecordCount("");



            List<CommonService.Model.Reporting.R_ConsultantCase_Reporting> listsLoan = _reporting_CaseWCF.GetListByPage("", " ID asc ", 1, 1000000);



            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            //貌似这里可以设置各种样式字体颜色背景等，但是不是很方便，这里就不设置了

            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);

            row1.CreateCell(0).SetCellValue("接案年份");
            row1.CreateCell(1).SetCellValue("接案月份");
            row1.CreateCell(2).SetCellValue("顾问");
            row1.CreateCell(3).SetCellValue("接案总数");
            row1.CreateCell(4).SetCellValue("类型案件数量");
            row1.CreateCell(5).SetCellValue("非类型案件数量");
            row1.CreateCell(6).SetCellValue("客户总数");
            row1.CreateCell(7).SetCellValue("新客户数量");
            row1.CreateCell(8).SetCellValue("老客户数量");
            row1.CreateCell(9).SetCellValue("移交总标的");
            row1.CreateCell(10).SetCellValue("类型移交标的");
            row1.CreateCell(11).SetCellValue("非类型移交标的");
            row1.CreateCell(12).SetCellValue("预期总收益");
            row1.CreateCell(13).SetCellValue("类型预期收益");
            row1.CreateCell(14).SetCellValue("非类型预期收益");
            row1.CreateCell(15).SetCellValue("本月计划接案数");
            row1.CreateCell(16).SetCellValue("完成率");
            row1.CreateCell(17).SetCellValue("下月计划接案数");
            row1.CreateCell(18).SetCellValue("本月计划预期收益");
            row1.CreateCell(19).SetCellValue("完成率");
            row1.CreateCell(20).SetCellValue("下月计划预期收益");
            //....N行
         
            //将数据逐步写入sheet1各个行
            for (int i = 0; i < listsLoan.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);

                rowtemp.CreateCell(0).SetCellValue(listsLoan[i].R_ConsultantCase_Reporting_year);
                rowtemp.CreateCell(1).SetCellValue(listsLoan[i].R_ConsultantCase_Reporting_month);
                rowtemp.CreateCell(2).SetCellValue(listsLoan[i].R_ConsultantCase_Reporting_area);
                rowtemp.CreateCell(3).SetCellValue(listsLoan[i].R_ConsultantCase_Reporting_allCount);
                rowtemp.CreateCell(4).SetCellValue(listsLoan[i].R_ConsultantCase_Reporting_typeCount);
                rowtemp.CreateCell(5).SetCellValue(listsLoan[i].R_ConsultantCase_Reporting_unTypeCount);
                rowtemp.CreateCell(6).SetCellValue(listsLoan[i].R_ConsultantCase_Reporting_customerCount);
                rowtemp.CreateCell(7).SetCellValue(listsLoan[i].R_ConsultantCase_Reporting_newCustomer);
                rowtemp.CreateCell(8).SetCellValue(listsLoan[i].R_ConsultantCase_Reporting_oldCustomer);
                rowtemp.CreateCell(9).SetCellValue(listsLoan[i].R_ConsultantCase_Reporting_transferTarget);
                rowtemp.CreateCell(10).SetCellValue(listsLoan[i].R_ConsultantCase_Reporting_typeTransferTarget);
             
                rowtemp.CreateCell(11).SetCellValue(listsLoan[i].R_ConsultantCase_Reporting_unTypeTransferTarget);

                rowtemp.CreateCell(12).SetCellValue(listsLoan[i].R_ConsultantCase_Reporting_expectedReturn);
                rowtemp.CreateCell(13).SetCellValue(listsLoan[i].R_ConsultantCase_Reporting_typeExpectedReturn);


                rowtemp.CreateCell(14).SetCellValue(listsLoan[i].R_ConsultantCase_Reporting_unTypeExpectedReturn);
                rowtemp.CreateCell(15).SetCellValue(listsLoan[i].R_ConsultantCase_Reporting_monthCount);
                rowtemp.CreateCell(16).SetCellValue(listsLoan[i].R_ConsultantCase_Reporting_cCompletion);
                rowtemp.CreateCell(17).SetCellValue(listsLoan[i].R_ConsultantCase_Reporting_nextMonthCount);
                rowtemp.CreateCell(18).SetCellValue(listsLoan[i].R_ConsultantCase_Reporting_monthExpected);
                rowtemp.CreateCell(19).SetCellValue(listsLoan[i].R_ConsultantCase_Reporting_eCompletion);
               rowtemp.CreateCell(20).SetCellValue(listsLoan[i].R_ConsultantCase_Reporting_nextMonthExpected);

                
                          


                //....N行
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "案件报表" + dateTime + ".xls";
            return File(ms, "application/vnd.ms-excel", fileName);
        }
        #endregion
	}
}