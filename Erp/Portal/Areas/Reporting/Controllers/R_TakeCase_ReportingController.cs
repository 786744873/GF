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
    public class R_TakeCase_ReportingController : BaseController
    {


        private readonly ICommonService.Reporting.IR_TakeCase_Reporting _reporting_CaseWCF;
        // GET: /Reporting/R_TakeCase_Reporting/
        public R_TakeCase_ReportingController()
        {
            _reporting_CaseWCF = ServiceProxyFactory.Create<ICommonService.Reporting.IR_TakeCase_Reporting>("R_TakeCase_ReportingWCF");
        }
        public ActionResult List()
        {

            var list = _reporting_CaseWCF.GetModelList("");

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
            CommonService.Model.Reporting.R_TakeCase_Reporting oFormConditon = new CommonService.Model.Reporting.R_TakeCase_Reporting();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_number");
                if (title != null && title != "")
                {
                    oFormConditon.B_TakeCase_Reporting_caseNumber = title;

                }
                #endregion
            }

            #endregion




            this.TotalRecordCount = _reporting_CaseWCF.GetListCount("");



            List<CommonService.Model.Reporting.R_TakeCase_Reporting> listsLoan = _reporting_CaseWCF.GetListByPage("", " ID asc ", param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);

            //转化数据格式
            var result = from c in listsLoan
                         select new[] { 
                              c.R_TakeCase_Reporting_year,
                               c.R_TakeCase_Reporting_month,
                                c.R_TakeCase_Reporting_area,
                                c.R_TakeCase_Reporting_dept,
                                c.R_TakeCase_Reporting_minister,
                                c.B_TakeCase_Reporting_consultant,
                                c.B_TakeCase_Reporting_customer,
                                c.B_TakeCase_Reporting_newOrOld,
                                c.B_TakeCase_Reporting_level,
                                c.B_TakeCase_Reporting_loyalty,
                                c.B_TakeCase_Reporting_sect,
                             c.B_TakeCase_Reporting_caseNumber,
                             c.B_TakeCase_Reporting_relCustomer,
                             c.B_TakeCase_Reporting_rival,
                                c.B_TakeCase_Reporting_project,
                                c.B_TakeCase_Reporting_plate,
                                 c.B_TakeCase_Reporting_property,
                                  c.B_TakeCase_Reporting_transferTarget,
                                   c.B_TakeCase_Reporting_expectedReturn,
                             c.B_TakeCase_Reporting_court,                   
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

            int i = _reporting_CaseWCF.Statistics();
            if (i > 0)
            {
                return "成功";
            }
            else
            {
                return ("失败");
            }
        }
        #region 数据导出功能
        public FileResult Export()
        {
            #region 查询拼接条件设置,查询条件根据实际业务进行相应更改)
            //s_number
            //表单查询模型
            CommonService.Model.Reporting.R_TakeCase_Reporting oFormConditon = new CommonService.Model.Reporting.R_TakeCase_Reporting();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string title = Request.Params.Get("s_number");
                if (title != null && title != "")
                {
                    oFormConditon.B_TakeCase_Reporting_caseNumber = title;

                }
                #endregion
            }

            #endregion




            this.TotalRecordCount = _reporting_CaseWCF.GetListCount("");



            List<CommonService.Model.Reporting.R_TakeCase_Reporting> listsLoan = _reporting_CaseWCF.GetListByPage("", " ID asc ", 1, 1000000);



            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            //貌似这里可以设置各种样式字体颜色背景等，但是不是很方便，这里就不设置了

            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("接案年份");
            row1.CreateCell(1).SetCellValue("接案月份");
            row1.CreateCell(2).SetCellValue("地区");
            row1.CreateCell(3).SetCellValue("部门");
            row1.CreateCell(4).SetCellValue("部长/组长");
            row1.CreateCell(5).SetCellValue("专业顾问");
            row1.CreateCell(6).SetCellValue("客户名称");
            row1.CreateCell(7).SetCellValue("新老客户");
            row1.CreateCell(8).SetCellValue("客户级别");
            row1.CreateCell(9).SetCellValue("客户忠诚度");
            row1.CreateCell(10).SetCellValue("客户流派");
            row1.CreateCell(11).SetCellValue("案号");
            row1.CreateCell(12).SetCellValue("案件委托人（原告）");
            row1.CreateCell(13).SetCellValue("对手（被告）");
            row1.CreateCell(14).SetCellValue("项目");
            row1.CreateCell(15).SetCellValue("板块");
            row1.CreateCell(16).SetCellValue("性质");
            row1.CreateCell(17).SetCellValue("移交标的");
            row1.CreateCell(18).SetCellValue("预期收益");
            row1.CreateCell(19).SetCellValue("管辖法院");
            

            //....N行


            //将数据逐步写入sheet1各个行
            for (int i = 0; i < listsLoan.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);

                rowtemp.CreateCell(0).SetCellValue(listsLoan[i].R_TakeCase_Reporting_year);
                rowtemp.CreateCell(1).SetCellValue(listsLoan[i].R_TakeCase_Reporting_month);
                rowtemp.CreateCell(2).SetCellValue(listsLoan[i].R_TakeCase_Reporting_area);
                rowtemp.CreateCell(3).SetCellValue(listsLoan[i].R_TakeCase_Reporting_dept);
                rowtemp.CreateCell(4).SetCellValue(listsLoan[i].R_TakeCase_Reporting_minister);
                rowtemp.CreateCell(5).SetCellValue(listsLoan[i].B_TakeCase_Reporting_consultant);
                rowtemp.CreateCell(6).SetCellValue(listsLoan[i].B_TakeCase_Reporting_customer);
                rowtemp.CreateCell(7).SetCellValue(listsLoan[i].B_TakeCase_Reporting_newOrOld);
                rowtemp.CreateCell(8).SetCellValue(listsLoan[i].B_TakeCase_Reporting_level);
                rowtemp.CreateCell(9).SetCellValue(listsLoan[i].B_TakeCase_Reporting_loyalty);
                rowtemp.CreateCell(10).SetCellValue(listsLoan[i].B_TakeCase_Reporting_sect);
                rowtemp.CreateCell(11).SetCellValue(listsLoan[i].B_TakeCase_Reporting_caseNumber);
                rowtemp.CreateCell(12).SetCellValue(listsLoan[i].B_TakeCase_Reporting_relCustomer);
              
                rowtemp.CreateCell(13).SetCellValue(listsLoan[i].B_TakeCase_Reporting_rival);
                rowtemp.CreateCell(14).SetCellValue(listsLoan[i].B_TakeCase_Reporting_project);
                rowtemp.CreateCell(15).SetCellValue(listsLoan[i].B_TakeCase_Reporting_plate);
                rowtemp.CreateCell(16).SetCellValue(listsLoan[i].B_TakeCase_Reporting_property);

                rowtemp.CreateCell(17).SetCellValue(listsLoan[i].B_TakeCase_Reporting_transferTarget);
                rowtemp.CreateCell(18).SetCellValue(listsLoan[i].B_TakeCase_Reporting_expectedReturn);
                rowtemp.CreateCell(19).SetCellValue(listsLoan[i].B_TakeCase_Reporting_court);




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