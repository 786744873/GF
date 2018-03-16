using CommonService.Common;
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
    public class MarketingCenterController : BaseController
    {
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;
        private readonly ICommonService.IC_Region _regionWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;
        public MarketingCenterController()
        {
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
        }
        //
        // GET: /Reporting/MarketingCenter/
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 收案类型统计
        /// </summary>
        /// <returns></returns>
        public ActionResult CustomerTeamList()
        {
            var areaList = _regionWCF.GetAllList(); //区域
            ViewBag.AreaList = areaList;
            //案件类型参数集合
            List<CommonService.Model.C_Parameters> Case_type = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.案件类型));
            ViewBag.Case_type = Case_type;
            //案件性质参数集合
            List<CommonService.Model.C_Parameters> Case_nature = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.案件性质));
            ViewBag.Case_nature = Case_nature;
            return View();
        }
        public ActionResult AjaxCustomerTeamList(jQueryDataTableParamModel param)
        {
            #region 查询拼接条件设置,查询条件根据实际业务进行相应更改)
            //s_number
            //表单查询模型
            CommonService.Model.Reporting.R_CaseType_Reporting oFormConditon = new CommonService.Model.Reporting.R_CaseType_Reporting();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                //区域
                string area = Request.Params.Get("i_area");
                if (area != null && area != "" && area != "-1")
                {
                    oFormConditon.QueryArea = new Guid(area);
                } 
                //案件类型
                string caseType = Request.Params.Get("i_caseType");
                if (caseType != null && caseType != "" && caseType != "-1")
                {
                    oFormConditon.QueryCaseType = Convert.ToInt32(caseType);
                }
                //案件性质
                string caseNature = Request.Params.Get("i_caseNature");
                if (caseNature != null && caseNature != "" && caseNature != "-1")
                {
                    oFormConditon.QueryNature = Convert.ToInt32(caseNature);
                }
                //开始收案时间
                string startTime = Request.Params.Get("i_startTime");
                if (startTime != null && startTime != "")
                {
                    oFormConditon.QueryStartTime = Convert.ToDateTime(startTime);
                }
                //结束收案时间
                string endTime = Request.Params.Get("i_endTime");
                if (endTime != null && endTime != "")
                {
                    oFormConditon.QueryEndTime = Convert.ToDateTime(endTime);
                }
                //开始移交标的
                string StartTransferTargetMoney = Request.Params.Get("s_StartTransferTargetMoney");
                if (StartTransferTargetMoney != null && StartTransferTargetMoney != "")
                {
                    oFormConditon.QueryStartTransferTargetMoney = Convert.ToDecimal(StartTransferTargetMoney);
                }
                //结束移交标的
                string EndTransferTargetMoney = Request.Params.Get("s_EndTransferTargetMoney");
                if (EndTransferTargetMoney != null && EndTransferTargetMoney != "")
                {
                    oFormConditon.QueryEndTransferTargetMoney = Convert.ToDecimal(EndTransferTargetMoney);
                }
                //开始预期收益的
                string StartExpectedGrant = Request.Params.Get("s_StartExpectedGrant");
                if (StartExpectedGrant != null && StartExpectedGrant != "")
                {
                    oFormConditon.QueryStartExpectedGrant = Convert.ToDecimal(StartExpectedGrant);
                }
                //结束预期收益的
                string EndExpectedGrant = Request.Params.Get("s_EndExpectedGrant");
                if (EndExpectedGrant != null && EndExpectedGrant != "")
                {
                    oFormConditon.QueryEndExpectedGrant = Convert.ToDecimal(EndExpectedGrant);
                }
                #endregion
            }

            #endregion

            #region 数据列表
            this.TotalRecordCount = _caseWCF.GetReportByCaseTypeCount(oFormConditon);

            List<CommonService.Model.Reporting.R_CaseType_Reporting> listsLoan = _caseWCF.GetReportByCaseType(oFormConditon, param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);

            //转化数据格式
            var result = from c in listsLoan
                         select new[] {
                            c.年份,
                            c.月份,
                            c.地区,
                            c.案件类型,
                            c.收案总数,
                            c.类型收案数,
                            c.非类型收案数,
                            c.移交总标的,
                            c.类型移交标的,
                            c.非类型移交标的,
                            c.预期总收益,
                            c.类型预期收益,
                            c.非类型预期收益
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
        /// 区域收案统计
        /// </summary>
        /// <returns></returns>
        public ActionResult CustomerTeamAreaList()
        {
            var areaList = _regionWCF.GetAllList(); //区域
            ViewBag.AreaList = areaList;
            //案件类型参数集合
            List<CommonService.Model.C_Parameters> Case_type = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.案件类型));
            ViewBag.Case_type = Case_type;
            //案件性质参数集合
            List<CommonService.Model.C_Parameters> Case_nature = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.案件性质));
            ViewBag.Case_nature = Case_nature;
            return View();
        }
        public ActionResult AjaxCustomerTeamAreaList(jQueryDataTableParamModel param)
        {
            #region 查询拼接条件设置,查询条件根据实际业务进行相应更改)
            //s_number
            //表单查询模型
            CommonService.Model.Reporting.R_CaseArea_Reporting oFormConditon = new CommonService.Model.Reporting.R_CaseArea_Reporting();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                //区域
                string area = Request.Params.Get("i_area");
                if (area != null && area != "" && area != "-1")
                {
                    oFormConditon.QueryArea = new Guid(area);
                }
                //案件类型
                string caseType = Request.Params.Get("i_caseType");
                if (caseType != null && caseType != "" && caseType != "-1")
                {
                    oFormConditon.QueryCaseType = Convert.ToInt32(caseType);
                }
                //案件性质
                string caseNature = Request.Params.Get("i_caseNature");
                if (caseNature != null && caseNature != "" && caseNature != "-1")
                {
                    oFormConditon.QueryNature = Convert.ToInt32(caseNature);
                }
                //开始收案时间
                string startTime = Request.Params.Get("i_startTime");
                if (startTime != null && startTime != "")
                {
                    oFormConditon.QueryStartTime = Convert.ToDateTime(startTime);
                }
                //结束收案时间
                string endTime = Request.Params.Get("i_endTime");
                if (endTime != null && endTime != "")
                {
                    oFormConditon.QueryEndTime = Convert.ToDateTime(endTime);
                }
                //开始移交标的
                string StartTransferTargetMoney = Request.Params.Get("s_StartTransferTargetMoney");
                if (StartTransferTargetMoney != null && StartTransferTargetMoney != "")
                {
                    oFormConditon.QueryStartTransferTargetMoney = Convert.ToDecimal(StartTransferTargetMoney);
                }
                //结束移交标的
                string EndTransferTargetMoney = Request.Params.Get("s_EndTransferTargetMoney");
                if (EndTransferTargetMoney != null && EndTransferTargetMoney != "")
                {
                    oFormConditon.QueryEndTransferTargetMoney = Convert.ToDecimal(EndTransferTargetMoney);
                }
                //开始预期收益的
                string StartExpectedGrant = Request.Params.Get("s_StartExpectedGrant");
                if (StartExpectedGrant != null && StartExpectedGrant != "")
                {
                    oFormConditon.QueryStartExpectedGrant = Convert.ToDecimal(StartExpectedGrant);
                }
                //结束预期收益的
                string EndExpectedGrant = Request.Params.Get("s_EndExpectedGrant");
                if (EndExpectedGrant != null && EndExpectedGrant != "")
                {
                    oFormConditon.QueryEndExpectedGrant = Convert.ToDecimal(EndExpectedGrant);
                }
                #endregion
            }

            #endregion

            #region 数据列表
            this.TotalRecordCount = _caseWCF.GetReportByAreaCount(oFormConditon);

            List<CommonService.Model.Reporting.R_CaseArea_Reporting> listsLoan = _caseWCF.GetReportByArea(oFormConditon, param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);

            //转化数据格式
            var result = from c in listsLoan
                         select new[] {
                            c.收案年份,
                            c.收案月份,
                            c.地区,
                            c.收案总数,
                            c.类型收案数,
                            c.非类型收案数,
                            c.客户总数,
                            c.新客户,
                            c.老客户,
                            c.移交总标的,
                            c.类型移交标的,
                            c.非类型移交标的,
                            c.预期总收益,
                            c.类型预期收益,
                            c.非类型预期收益,
                            c.本月计划收案数,
                            c.计划收案完成率,
                            c.下月计划收案数,
                            c.本月计划预期收益,
                            c.计划收益完成率,
                            c.下月计划预期收益
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
        /// 部门收案统计
        /// </summary>
        /// <returns></returns>
        public ActionResult CustomerTeamOrganList()
        {
            var areaList = _regionWCF.GetAllList(); //区域
            ViewBag.AreaList = areaList;
            //案件类型参数集合
            List<CommonService.Model.C_Parameters> Case_type = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.案件类型));
            ViewBag.Case_type = Case_type;
            //案件性质参数集合
            List<CommonService.Model.C_Parameters> Case_nature = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.案件性质));
            ViewBag.Case_nature = Case_nature;
            return View();
        }
        public ActionResult AjaxCustomerTeamOrganList(jQueryDataTableParamModel param)
        {
            #region 查询拼接条件设置,查询条件根据实际业务进行相应更改)
            //s_number
            //表单查询模型
            CommonService.Model.Reporting.R_CaseOrgan_Reporting oFormConditon = new CommonService.Model.Reporting.R_CaseOrgan_Reporting();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                //区域
                string area = Request.Params.Get("i_area");
                if (area != null && area != "" && area != "-1")
                {
                    oFormConditon.QueryArea = new Guid(area);
                }
                //案件类型
                string caseType = Request.Params.Get("i_caseType");
                if (caseType != null && caseType != "" && caseType != "-1")
                {
                    oFormConditon.QueryCaseType = Convert.ToInt32(caseType);
                }
                //案件性质
                string caseNature = Request.Params.Get("i_caseNature");
                if (caseNature != null && caseNature != "" && caseNature != "-1")
                {
                    oFormConditon.QueryNature = Convert.ToInt32(caseNature);
                }
                //开始收案时间
                string startTime = Request.Params.Get("i_startTime");
                if (startTime != null && startTime != "")
                {
                    oFormConditon.QueryStartTime = Convert.ToDateTime(startTime);
                }
                //结束收案时间
                string endTime = Request.Params.Get("i_endTime");
                if (endTime != null && endTime != "")
                {
                    oFormConditon.QueryEndTime = Convert.ToDateTime(endTime);
                }
                //开始移交标的
                string StartTransferTargetMoney = Request.Params.Get("s_StartTransferTargetMoney");
                if (StartTransferTargetMoney != null && StartTransferTargetMoney != "")
                {
                    oFormConditon.QueryStartTransferTargetMoney = Convert.ToDecimal(StartTransferTargetMoney);
                }
                //结束移交标的
                string EndTransferTargetMoney = Request.Params.Get("s_EndTransferTargetMoney");
                if (EndTransferTargetMoney != null && EndTransferTargetMoney != "")
                {
                    oFormConditon.QueryEndTransferTargetMoney = Convert.ToDecimal(EndTransferTargetMoney);
                }
                //开始预期收益的
                string StartExpectedGrant = Request.Params.Get("s_StartExpectedGrant");
                if (StartExpectedGrant != null && StartExpectedGrant != "")
                {
                    oFormConditon.QueryStartExpectedGrant = Convert.ToDecimal(StartExpectedGrant);
                }
                //结束预期收益的
                string EndExpectedGrant = Request.Params.Get("s_EndExpectedGrant");
                if (EndExpectedGrant != null && EndExpectedGrant != "")
                {
                    oFormConditon.QueryEndExpectedGrant = Convert.ToDecimal(EndExpectedGrant);
                }
                #endregion
            }

            #endregion

            #region 数据列表
            this.TotalRecordCount = _caseWCF.GetReportByOrganCount(oFormConditon);

            List<CommonService.Model.Reporting.R_CaseOrgan_Reporting> listsLoan = _caseWCF.GetReportByOrgan(oFormConditon, param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);

            //转化数据格式
            var result = from c in listsLoan
                         select new[] {
                            c.收案年份,
                            c.收案月份,
                            c.地区,
                            c.收案总数,
                            c.类型收案数,
                            c.非类型收案数,
                            c.客户总数,
                            c.新客户,
                            c.老客户,
                            c.移交总标的,
                            c.类型移交标的,
                            c.非类型移交标的,
                            c.预期总收益,
                            c.类型预期收益,
                            c.非类型预期收益,
                            c.本月计划收案数,
                            c.计划收案完成率,
                            c.下月计划收案数,
                            c.本月计划预期收益,
                            c.计划收益完成率,
                            c.下月计划预期收益
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
            CommonService.Model.Reporting.R_CaseType_Reporting oFormConditon = new CommonService.Model.Reporting.R_CaseType_Reporting();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                //区域
                string area = Request.Params.Get("i_area");
                if (area != null && area != "" && area != "-1")
                {
                    oFormConditon.QueryArea = new Guid(area);
                }
                //案件类型
                string caseType = Request.Params.Get("i_caseType");
                if (caseType != null && caseType != "" && caseType != "-1")
                {
                    oFormConditon.QueryCaseType = Convert.ToInt32(caseType);
                }
                //案件性质
                string caseNature = Request.Params.Get("i_caseNature");
                if (caseNature != null && caseNature != "" && caseNature != "-1")
                {
                    oFormConditon.QueryNature = Convert.ToInt32(caseNature);
                }
                //开始收案时间
                string startTime = Request.Params.Get("i_startTime");
                if (startTime != null && startTime != "")
                {
                    oFormConditon.QueryStartTime = Convert.ToDateTime(startTime);
                }
                //结束收案时间
                string endTime = Request.Params.Get("i_endTime");
                if (endTime != null && endTime != "")
                {
                    oFormConditon.QueryEndTime = Convert.ToDateTime(endTime);
                }
                //开始移交标的
                string StartTransferTargetMoney = Request.Params.Get("s_StartTransferTargetMoney");
                if (StartTransferTargetMoney != null && StartTransferTargetMoney != "")
                {
                    oFormConditon.QueryStartTransferTargetMoney = Convert.ToDecimal(StartTransferTargetMoney);
                }
                //结束移交标的
                string EndTransferTargetMoney = Request.Params.Get("s_EndTransferTargetMoney");
                if (EndTransferTargetMoney != null && EndTransferTargetMoney != "")
                {
                    oFormConditon.QueryEndTransferTargetMoney = Convert.ToDecimal(EndTransferTargetMoney);
                }
                //开始预期收益的
                string StartExpectedGrant = Request.Params.Get("s_StartExpectedGrant");
                if (StartExpectedGrant != null && StartExpectedGrant != "")
                {
                    oFormConditon.QueryStartExpectedGrant = Convert.ToDecimal(StartExpectedGrant);
                }
                //结束预期收益的
                string EndExpectedGrant = Request.Params.Get("s_EndExpectedGrant");
                if (EndExpectedGrant != null && EndExpectedGrant != "")
                {
                    oFormConditon.QueryEndExpectedGrant = Convert.ToDecimal(EndExpectedGrant);
                }
                #endregion
            }

            #endregion

            //数据列表
            List<CommonService.Model.Reporting.R_CaseType_Reporting> listsLoan = _caseWCF.GetReportByCaseType(oFormConditon, 1, 1000000);

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
            row1.CreateCell(3).SetCellValue("案件类型");
            row1.CreateCell(4).SetCellValue("收案总数");
            row1.CreateCell(5).SetCellValue("类型收案数");
            row1.CreateCell(6).SetCellValue("非类型收案数");
            row1.CreateCell(7).SetCellValue("移交总标的");
            row1.CreateCell(8).SetCellValue("类型移交标的");
            row1.CreateCell(9).SetCellValue("非类型移交标的");
            row1.CreateCell(10).SetCellValue("预期总收益");
            row1.CreateCell(11).SetCellValue("类型预期收益");
            row1.CreateCell(12).SetCellValue("非类型预期收益");

            //....N行

            //将数据逐步写入sheet1各个行
            for (int i = 0; i < listsLoan.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);

                rowtemp.CreateCell(0).SetCellValue(listsLoan[i].年份);
                rowtemp.CreateCell(1).SetCellValue(listsLoan[i].月份);
                rowtemp.CreateCell(2).SetCellValue(listsLoan[i].地区);
                rowtemp.CreateCell(3).SetCellValue(listsLoan[i].案件类型);
                rowtemp.CreateCell(4).SetCellValue(listsLoan[i].收案总数);
                rowtemp.CreateCell(5).SetCellValue(listsLoan[i].类型收案数);
                rowtemp.CreateCell(6).SetCellValue(listsLoan[i].非类型收案数);
                rowtemp.CreateCell(7).SetCellValue(listsLoan[i].移交总标的);
                rowtemp.CreateCell(8).SetCellValue(listsLoan[i].类型移交标的);
                rowtemp.CreateCell(9).SetCellValue(listsLoan[i].非类型移交标的);
                rowtemp.CreateCell(10).SetCellValue(listsLoan[i].预期总收益);
                rowtemp.CreateCell(11).SetCellValue(listsLoan[i].类型预期收益);
                rowtemp.CreateCell(12).SetCellValue(listsLoan[i].非类型预期收益);
                //....N行
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "收案类型统计报表" + dateTime + ".xls";
            return File(ms, "application/vnd.ms-excel", fileName);
        }
        /// <summary>
        /// 区域收案统计导出报表
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public FileResult ExportAreaList(FormCollection form)
        {
            #region 查询拼接条件设置,查询条件根据实际业务进行相应更改)
            //s_number
            //表单查询模型
            CommonService.Model.Reporting.R_CaseArea_Reporting oFormConditon = new CommonService.Model.Reporting.R_CaseArea_Reporting();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                //区域
                string area = Request.Params.Get("i_area");
                if (area != null && area != "" && area != "-1")
                {
                    oFormConditon.QueryArea = new Guid(area);
                }
                //案件类型
                string caseType = Request.Params.Get("i_caseType");
                if (caseType != null && caseType != "" && caseType != "-1")
                {
                    oFormConditon.QueryCaseType = Convert.ToInt32(caseType);
                }
                //案件性质
                string caseNature = Request.Params.Get("i_caseNature");
                if (caseNature != null && caseNature != "" && caseNature != "-1")
                {
                    oFormConditon.QueryNature = Convert.ToInt32(caseNature);
                }
                //开始收案时间
                string startTime = Request.Params.Get("i_startTime");
                if (startTime != null && startTime != "")
                {
                    oFormConditon.QueryStartTime = Convert.ToDateTime(startTime);
                }
                //结束收案时间
                string endTime = Request.Params.Get("i_endTime");
                if (endTime != null && endTime != "")
                {
                    oFormConditon.QueryEndTime = Convert.ToDateTime(endTime);
                }
                //开始移交标的
                string StartTransferTargetMoney = Request.Params.Get("s_StartTransferTargetMoney");
                if (StartTransferTargetMoney != null && StartTransferTargetMoney != "")
                {
                    oFormConditon.QueryStartTransferTargetMoney = Convert.ToDecimal(StartTransferTargetMoney);
                }
                //结束移交标的
                string EndTransferTargetMoney = Request.Params.Get("s_EndTransferTargetMoney");
                if (EndTransferTargetMoney != null && EndTransferTargetMoney != "")
                {
                    oFormConditon.QueryEndTransferTargetMoney = Convert.ToDecimal(EndTransferTargetMoney);
                }
                //开始预期收益的
                string StartExpectedGrant = Request.Params.Get("s_StartExpectedGrant");
                if (StartExpectedGrant != null && StartExpectedGrant != "")
                {
                    oFormConditon.QueryStartExpectedGrant = Convert.ToDecimal(StartExpectedGrant);
                }
                //结束预期收益的
                string EndExpectedGrant = Request.Params.Get("s_EndExpectedGrant");
                if (EndExpectedGrant != null && EndExpectedGrant != "")
                {
                    oFormConditon.QueryEndExpectedGrant = Convert.ToDecimal(EndExpectedGrant);
                }
                #endregion
            }

            #endregion

            //数据列表
            List<CommonService.Model.Reporting.R_CaseArea_Reporting> listsLoan = _caseWCF.GetReportByArea(oFormConditon, 1, 1000000);

            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            //貌似这里可以设置各种样式字体颜色背景等，但是不是很方便，这里就不设置了

            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("收案年份");
            row1.CreateCell(1).SetCellValue("收案月份");
            row1.CreateCell(2).SetCellValue("地区");
            row1.CreateCell(3).SetCellValue("收案总数");
            row1.CreateCell(4).SetCellValue("类型收案数");
            row1.CreateCell(5).SetCellValue("非类型收案数");
            row1.CreateCell(6).SetCellValue("客户总数");
            row1.CreateCell(7).SetCellValue("新客户");
            row1.CreateCell(8).SetCellValue("老客户");
            row1.CreateCell(9).SetCellValue("移交总标的");
            row1.CreateCell(10).SetCellValue("类型移交标的");
            row1.CreateCell(11).SetCellValue("非类型移交标的");
            row1.CreateCell(12).SetCellValue("预期总收益");
            row1.CreateCell(13).SetCellValue("类型预期收益");
            row1.CreateCell(14).SetCellValue("非类型预期收益");
            row1.CreateCell(15).SetCellValue("本月计划收案数");
            row1.CreateCell(16).SetCellValue("计划收案完成率");
            row1.CreateCell(17).SetCellValue("下月计划收案数");
            row1.CreateCell(18).SetCellValue("本月计划预期收益");
            row1.CreateCell(19).SetCellValue("计划收益完成率");
            row1.CreateCell(20).SetCellValue("下月计划预期收益");
            //....N行

            //将数据逐步写入sheet1各个行
            for (int i = 0; i < listsLoan.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);

                rowtemp.CreateCell(0).SetCellValue(listsLoan[i].收案年份);
                rowtemp.CreateCell(1).SetCellValue(listsLoan[i].收案月份);
                rowtemp.CreateCell(2).SetCellValue(listsLoan[i].地区);
                rowtemp.CreateCell(3).SetCellValue(listsLoan[i].收案总数);
                rowtemp.CreateCell(4).SetCellValue(listsLoan[i].类型收案数);
                rowtemp.CreateCell(5).SetCellValue(listsLoan[i].非类型收案数);
                rowtemp.CreateCell(6).SetCellValue(listsLoan[i].客户总数);
                rowtemp.CreateCell(7).SetCellValue(listsLoan[i].新客户);
                rowtemp.CreateCell(8).SetCellValue(listsLoan[i].老客户);
                rowtemp.CreateCell(9).SetCellValue(listsLoan[i].移交总标的);
                rowtemp.CreateCell(10).SetCellValue(listsLoan[i].类型移交标的);
                rowtemp.CreateCell(11).SetCellValue(listsLoan[i].非类型移交标的);
                rowtemp.CreateCell(12).SetCellValue(listsLoan[i].预期总收益);
                rowtemp.CreateCell(13).SetCellValue(listsLoan[i].类型预期收益);
                rowtemp.CreateCell(14).SetCellValue(listsLoan[i].非类型预期收益);
                rowtemp.CreateCell(15).SetCellValue(listsLoan[i].本月计划收案数);
                rowtemp.CreateCell(16).SetCellValue(listsLoan[i].计划收案完成率);
                rowtemp.CreateCell(17).SetCellValue(listsLoan[i].下月计划收案数);
                rowtemp.CreateCell(18).SetCellValue(listsLoan[i].本月计划预期收益);
                rowtemp.CreateCell(19).SetCellValue(listsLoan[i].计划收益完成率);
                rowtemp.CreateCell(20).SetCellValue(listsLoan[i].下月计划预期收益);
                //....N行
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "区域收案统计报表" + dateTime + ".xls";
            return File(ms, "application/vnd.ms-excel", fileName);
        }
        /// <summary>
        /// 部门收案统计导出报表
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public FileResult ExportOrganList(FormCollection form)
        {
            #region 查询拼接条件设置,查询条件根据实际业务进行相应更改)
            //s_number
            //表单查询模型
            CommonService.Model.Reporting.R_CaseOrgan_Reporting oFormConditon = new CommonService.Model.Reporting.R_CaseOrgan_Reporting();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                //区域
                string area = Request.Params.Get("i_area");
                if (area != null && area != "" && area != "-1")
                {
                    oFormConditon.QueryArea = new Guid(area);
                }
                //案件类型
                string caseType = Request.Params.Get("i_caseType");
                if (caseType != null && caseType != "" && caseType != "-1")
                {
                    oFormConditon.QueryCaseType = Convert.ToInt32(caseType);
                }
                //案件性质
                string caseNature = Request.Params.Get("i_caseNature");
                if (caseNature != null && caseNature != "" && caseNature != "-1")
                {
                    oFormConditon.QueryNature = Convert.ToInt32(caseNature);
                }
                //开始收案时间
                string startTime = Request.Params.Get("i_startTime");
                if (startTime != null && startTime != "")
                {
                    oFormConditon.QueryStartTime = Convert.ToDateTime(startTime);
                }
                //结束收案时间
                string endTime = Request.Params.Get("i_endTime");
                if (endTime != null && endTime != "")
                {
                    oFormConditon.QueryEndTime = Convert.ToDateTime(endTime);
                }
                //开始移交标的
                string StartTransferTargetMoney = Request.Params.Get("s_StartTransferTargetMoney");
                if (StartTransferTargetMoney != null && StartTransferTargetMoney != "")
                {
                    oFormConditon.QueryStartTransferTargetMoney = Convert.ToDecimal(StartTransferTargetMoney);
                }
                //结束移交标的
                string EndTransferTargetMoney = Request.Params.Get("s_EndTransferTargetMoney");
                if (EndTransferTargetMoney != null && EndTransferTargetMoney != "")
                {
                    oFormConditon.QueryEndTransferTargetMoney = Convert.ToDecimal(EndTransferTargetMoney);
                }
                //开始预期收益的
                string StartExpectedGrant = Request.Params.Get("s_StartExpectedGrant");
                if (StartExpectedGrant != null && StartExpectedGrant != "")
                {
                    oFormConditon.QueryStartExpectedGrant = Convert.ToDecimal(StartExpectedGrant);
                }
                //结束预期收益的
                string EndExpectedGrant = Request.Params.Get("s_EndExpectedGrant");
                if (EndExpectedGrant != null && EndExpectedGrant != "")
                {
                    oFormConditon.QueryEndExpectedGrant = Convert.ToDecimal(EndExpectedGrant);
                }
                #endregion
            }

            #endregion

            //数据列表
            List<CommonService.Model.Reporting.R_CaseOrgan_Reporting> listsLoan = _caseWCF.GetReportByOrgan(oFormConditon, 1, 1000000);

            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            //貌似这里可以设置各种样式字体颜色背景等，但是不是很方便，这里就不设置了

            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("收案年份");
            row1.CreateCell(1).SetCellValue("收案月份");
            row1.CreateCell(2).SetCellValue("地区");
            row1.CreateCell(3).SetCellValue("收案总数");
            row1.CreateCell(4).SetCellValue("类型收案数");
            row1.CreateCell(5).SetCellValue("非类型收案数");
            row1.CreateCell(6).SetCellValue("客户总数");
            row1.CreateCell(7).SetCellValue("新客户");
            row1.CreateCell(8).SetCellValue("老客户");
            row1.CreateCell(9).SetCellValue("移交总标的");
            row1.CreateCell(10).SetCellValue("类型移交标的");
            row1.CreateCell(11).SetCellValue("非类型移交标的");
            row1.CreateCell(12).SetCellValue("预期总收益");
            row1.CreateCell(13).SetCellValue("类型预期收益");
            row1.CreateCell(14).SetCellValue("非类型预期收益");
            row1.CreateCell(15).SetCellValue("本月计划收案数");
            row1.CreateCell(16).SetCellValue("计划收案完成率");
            row1.CreateCell(17).SetCellValue("下月计划收案数");
            row1.CreateCell(18).SetCellValue("本月计划预期收益");
            row1.CreateCell(19).SetCellValue("计划收益完成率");
            row1.CreateCell(20).SetCellValue("下月计划预期收益");
            //....N行

            //将数据逐步写入sheet1各个行
            for (int i = 0; i < listsLoan.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);

                rowtemp.CreateCell(0).SetCellValue(listsLoan[i].收案年份);
                rowtemp.CreateCell(1).SetCellValue(listsLoan[i].收案月份);
                rowtemp.CreateCell(2).SetCellValue(listsLoan[i].地区);
                rowtemp.CreateCell(3).SetCellValue(listsLoan[i].收案总数);
                rowtemp.CreateCell(4).SetCellValue(listsLoan[i].类型收案数);
                rowtemp.CreateCell(5).SetCellValue(listsLoan[i].非类型收案数);
                rowtemp.CreateCell(6).SetCellValue(listsLoan[i].客户总数);
                rowtemp.CreateCell(7).SetCellValue(listsLoan[i].新客户);
                rowtemp.CreateCell(8).SetCellValue(listsLoan[i].老客户);
                rowtemp.CreateCell(9).SetCellValue(listsLoan[i].移交总标的);
                rowtemp.CreateCell(10).SetCellValue(listsLoan[i].类型移交标的);
                rowtemp.CreateCell(11).SetCellValue(listsLoan[i].非类型移交标的);
                rowtemp.CreateCell(12).SetCellValue(listsLoan[i].预期总收益);
                rowtemp.CreateCell(13).SetCellValue(listsLoan[i].类型预期收益);
                rowtemp.CreateCell(14).SetCellValue(listsLoan[i].非类型预期收益);
                rowtemp.CreateCell(15).SetCellValue(listsLoan[i].本月计划收案数);
                rowtemp.CreateCell(16).SetCellValue(listsLoan[i].计划收案完成率);
                rowtemp.CreateCell(17).SetCellValue(listsLoan[i].下月计划收案数);
                rowtemp.CreateCell(18).SetCellValue(listsLoan[i].本月计划预期收益);
                rowtemp.CreateCell(19).SetCellValue(listsLoan[i].计划收益完成率);
                rowtemp.CreateCell(20).SetCellValue(listsLoan[i].下月计划预期收益);
                //....N行
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "部门收案统计报表" + dateTime + ".xls";
            return File(ms, "application/vnd.ms-excel", fileName);
        }
        #endregion
	}
}