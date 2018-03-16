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
    public class R_ImplementationCase_ReportingController : BaseController
    {
        private readonly ICommonService.Reporting.IR_ImplementationCase_Reporting _reporting_CaseWCF;
        // GET: /Reporting/R_ImplementationCase_Reporting/
       public R_ImplementationCase_ReportingController()
        {
            _reporting_CaseWCF = ServiceProxyFactory.Create<ICommonService.Reporting.IR_ImplementationCase_Reporting>("R_ImplementationCase_ReportingWCF");
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
            CommonService.Model.Reporting.R_ImplementationCase_Reporting oFormConditon = new CommonService.Model.Reporting.R_ImplementationCase_Reporting();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_number");
                if (title != null && title != "")
                {
                    oFormConditon.Case_Number = title;

                }
                #endregion
            }

            #endregion




            this.TotalRecordCount = _reporting_CaseWCF.GetRecordCount("");



            List<CommonService.Model.Reporting.R_ImplementationCase_Reporting> listsLoan = _reporting_CaseWCF.GetListByPage("", " ID asc ", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);

            //转化数据格式
            var result = from c in listsLoan
                         select new[] { 
                              c.Year,
                               c.Month,
                                c.AreaName,
                              
                                c.HostName,
                                  c.CoName,
                                c.Case_Number,
                                c.B_Plaintiff_Name,
                                c.B_Defendant_Name,
                                c.B_Project_Name,
                                c.AcceptanceTime,
                                c.B_TransferPrice,
                                 c.JurisdictionCourt,
                                 c.DocumentIncome,
                             c.OverdueIncome,
                            c.DateExecution,
                            c.ProgressCaseMonth,
                            c.ProgressCompletionTime,
                            c.Implementation,
                            c.ExecutionPlan,
                            c.SalesReturn,
                             
                               
                                  
                                                  
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
            CommonService.Model.Reporting.R_ImplementationCase_Reporting oFormConditon = new CommonService.Model.Reporting.R_ImplementationCase_Reporting();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_number");
                if (title != null && title != "")
                {
                    oFormConditon.Case_Number = title;

                }
                #endregion
            }

            #endregion




            this.TotalRecordCount = _reporting_CaseWCF.GetRecordCount("");



            List<CommonService.Model.Reporting.R_ImplementationCase_Reporting> listsLoan = _reporting_CaseWCF.GetListByPage("", " ID asc ", 1, 1000000);



            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            //貌似这里可以设置各种样式字体颜色背景等，但是不是很方便，这里就不设置了

            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);

            row1.CreateCell(0).SetCellValue("年份");
            row1.CreateCell(1).SetCellValue("月份");
            row1.CreateCell(2).SetCellValue("地区");
            row1.CreateCell(3).SetCellValue("主办/独立律师");
            row1.CreateCell(4).SetCellValue("协办/助理律师");
            row1.CreateCell(5).SetCellValue("案号");
            row1.CreateCell(6).SetCellValue("原告");
            row1.CreateCell(7).SetCellValue("被告");
            row1.CreateCell(8).SetCellValue("项目");
            row1.CreateCell(9).SetCellValue("收案时间");
            row1.CreateCell(10).SetCellValue("移交标的");
            row1.CreateCell(11).SetCellValue("管辖法院");
            row1.CreateCell(12).SetCellValue("文书收入");
            row1.CreateCell(13).SetCellValue("逾期收入");
            row1.CreateCell(14).SetCellValue("执行条件成就日期");
            row1.CreateCell(15).SetCellValue("本月案件进展");
            row1.CreateCell(16).SetCellValue("进展完成日期");
            row1.CreateCell(17).SetCellValue("执行措施种类");
            row1.CreateCell(18).SetCellValue("执行划款");
            row1.CreateCell(19).SetCellValue("可销售回款额");
            //....N行

            //将数据逐步写入sheet1各个行
            for (int i = 0; i < listsLoan.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);

                rowtemp.CreateCell(0).SetCellValue(listsLoan[i].Year);
                rowtemp.CreateCell(1).SetCellValue(listsLoan[i].Month);
                rowtemp.CreateCell(2).SetCellValue(listsLoan[i].AreaName);
                rowtemp.CreateCell(3).SetCellValue(listsLoan[i].HostName);
                rowtemp.CreateCell(4).SetCellValue(listsLoan[i].CoName);
                rowtemp.CreateCell(5).SetCellValue(listsLoan[i].Case_Number);
                rowtemp.CreateCell(6).SetCellValue(listsLoan[i].B_Plaintiff_Name);
                rowtemp.CreateCell(7).SetCellValue(listsLoan[i].B_Defendant_Name);
                rowtemp.CreateCell(8).SetCellValue(listsLoan[i].B_Project_Name);
                rowtemp.CreateCell(9).SetCellValue(listsLoan[i].AcceptanceTime);
                rowtemp.CreateCell(10).SetCellValue(listsLoan[i].B_TransferPrice);
             
                rowtemp.CreateCell(11).SetCellValue(listsLoan[i].JurisdictionCourt);

                rowtemp.CreateCell(12).SetCellValue(listsLoan[i].DocumentIncome);
                rowtemp.CreateCell(13).SetCellValue(listsLoan[i].OverdueIncome);


                rowtemp.CreateCell(14).SetCellValue(listsLoan[i].DateExecution);
                rowtemp.CreateCell(15).SetCellValue(listsLoan[i].ProgressCaseMonth);
                rowtemp.CreateCell(16).SetCellValue(listsLoan[i].ProgressCompletionTime);
                rowtemp.CreateCell(17).SetCellValue(listsLoan[i].Implementation);
                rowtemp.CreateCell(18).SetCellValue(listsLoan[i].ExecutionPlan);
                rowtemp.CreateCell(19).SetCellValue(listsLoan[i].SalesReturn);
               

                
                          


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