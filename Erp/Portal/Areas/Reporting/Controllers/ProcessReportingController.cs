using CommonService.Common;
using Maticsoft.Common;
using Portal.Controllers;
using Portal.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.Reporting.Controllers
{
    public class ProcessReportingController : BaseController
    {
        private readonly ICommonService.Reporting.IProcessReporting _processReportingWCF;
        private readonly ICommonService.IC_Region _regionWCF;
        private readonly ICommonService.IC_SearchConditionRecord _searchConditionRecordWCF;
        private readonly ICommonService.IC_Parameters _parameterWCF;

        public ProcessReportingController()
        {
            _processReportingWCF = ServiceProxyFactory.Create<ICommonService.Reporting.IProcessReporting>("ProcessReportingWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
            _searchConditionRecordWCF = ServiceProxyFactory.Create<ICommonService.IC_SearchConditionRecord>("SearchConditionRecordWCF");
            _parameterWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
        }
        //
        // GET: /Reporting/ProcessReporting/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Reporting/B_Case/
        public ActionResult List(int? type)
        {
            var areaList = _regionWCF.GetAllList(); //区域
            ViewBag.AreaList = areaList;
            ViewBag.type = type;
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
            //表单查询模型
            CommonService.Model.Reporting.ProcessReporting oFormConditon = new CommonService.Model.Reporting.ProcessReporting();

            Guid groupCode = Guid.NewGuid();
            List<CommonService.Model.C_SearchConditionRecord> searchConditionRecords = new List<CommonService.Model.C_SearchConditionRecord>();
            int type = Convert.ToInt32(Request.Params.Get("type"));
            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string area = Request.Params.Get("i_area");//区域
                if (area != null && area != "-1")
                {
                    oFormConditon.Query_area = area;
                    CommonService.Model.C_SearchConditionRecord SearchConditionRecord = addSearchConditionRecord(groupCode, "地区", area);
                    searchConditionRecords.Add(SearchConditionRecord);
                }
                string dept = Request.Params.Get("s_dept");//部门
                if (dept != null && dept != "")
                {
                    if (type == 3)
                    {
                        oFormConditon.Query_department = dept;
                        CommonService.Model.C_SearchConditionRecord SearchConditionRecord = addSearchConditionRecord(groupCode, "营销部门", dept);
                        searchConditionRecords.Add(SearchConditionRecord);
                    }
                    else
                    {
                        oFormConditon.Query_organ = dept;
                        CommonService.Model.C_SearchConditionRecord SearchConditionRecord = addSearchConditionRecord(groupCode, "部门", dept);
                        searchConditionRecords.Add(SearchConditionRecord);
                    }
                }
                string Sponsorlawyer = Request.Params.Get("s_Sponsorlawyer");//主办律师
                if (Sponsorlawyer != null && Sponsorlawyer != "")
                {
                    oFormConditon.Query_laywer = Sponsorlawyer;
                    CommonService.Model.C_SearchConditionRecord SearchConditionRecord = addSearchConditionRecord(groupCode, "主办律师", Sponsorlawyer);
                    searchConditionRecords.Add(SearchConditionRecord);
                }
                string number = Request.Params.Get("s_number");//案件编码
                if (number != null && number != "")
                {
                    oFormConditon.Query_caseNum = number;
                    CommonService.Model.C_SearchConditionRecord SearchConditionRecord = addSearchConditionRecord(groupCode, "案件编码", number);
                    searchConditionRecords.Add(SearchConditionRecord);
                }
                string priject = Request.Params.Get("s_project");//工程名称
                if (priject != null && priject != "")
                {
                    oFormConditon.Query_project = priject;
                    CommonService.Model.C_SearchConditionRecord SearchConditionRecord = addSearchConditionRecord(groupCode, "工程名称", priject);
                    searchConditionRecords.Add(SearchConditionRecord);
                }
                string count = Request.Params.Get("s_court");//管辖法院
                if (count != null && count != "")
                {
                    oFormConditon.Query_court = count;
                    CommonService.Model.C_SearchConditionRecord SearchConditionRecord = addSearchConditionRecord(groupCode, "管辖法院", count);
                    searchConditionRecords.Add(SearchConditionRecord);
                }
                string client = Request.Params.Get("s_client");//委托人
                if (client != null && client != "")
                {
                    oFormConditon.Query_deleger = client;
                    CommonService.Model.C_SearchConditionRecord SearchConditionRecord = addSearchConditionRecord(groupCode, "委托人", client);
                    searchConditionRecords.Add(SearchConditionRecord);
                }
                string party = Request.Params.Get("s_otherParty");//对方当事人
                if (party != null && party != "")
                {
                    oFormConditon.Query_party = party;
                    CommonService.Model.C_SearchConditionRecord SearchConditionRecord = addSearchConditionRecord(groupCode, "对方当事人", party);
                    searchConditionRecords.Add(SearchConditionRecord);
                }
                string subject = Request.Params.Get("s_otherParty1");//移交标的
                if (subject != null && subject != "")
                {
                    oFormConditon.Query_subject = subject;
                    CommonService.Model.C_SearchConditionRecord SearchConditionRecord = addSearchConditionRecord(groupCode, "移交标的", subject);
                    searchConditionRecords.Add(SearchConditionRecord);
                }
                string subjectZ = Request.Params.Get("s_otherParty2");//移交标的至
                if (subjectZ != null && subjectZ != "")
                {
                    oFormConditon.Query_subjectZ = subjectZ;
                    CommonService.Model.C_SearchConditionRecord SearchConditionRecord = addSearchConditionRecord(groupCode, "移交标的至", subjectZ);
                    searchConditionRecords.Add(SearchConditionRecord);
                }
                string income = Request.Params.Get("s_expectedRevenue1");//预期收入
                if (income != null && income != "")
                {
                    oFormConditon.Query_income = income;
                    CommonService.Model.C_SearchConditionRecord SearchConditionRecord = addSearchConditionRecord(groupCode, "预期收入", income);
                    searchConditionRecords.Add(SearchConditionRecord);
                }
                string incomeZ = Request.Params.Get("s_expectedRevenue2");//预期收入至
                if (incomeZ != null && incomeZ != "")
                {
                    oFormConditon.Query_incomeZ = incomeZ;
                    CommonService.Model.C_SearchConditionRecord SearchConditionRecord = addSearchConditionRecord(groupCode, "预期收入至", incomeZ);
                    searchConditionRecords.Add(SearchConditionRecord);
                }
                string closedDate = Request.Params.Get("i_studyTime1");//收案时间
                if (closedDate != null && closedDate != "")
                {
                    oFormConditon.Query_closedDate = closedDate;
                    CommonService.Model.C_SearchConditionRecord SearchConditionRecord = addSearchConditionRecord(groupCode, "收案时间", closedDate);
                    searchConditionRecords.Add(SearchConditionRecord);
                }
                string closedDateZ = Request.Params.Get("i_studyTime2");//收案时间至
                if (closedDateZ != null && closedDateZ != "")
                {
                    oFormConditon.Query_closedDateZ = closedDateZ;
                    CommonService.Model.C_SearchConditionRecord SearchConditionRecord = addSearchConditionRecord(groupCode, "收案时间至", closedDateZ);
                    searchConditionRecords.Add(SearchConditionRecord);
                }
                string customDate = Request.Params.Get("i_customTime1");//自定义时间
                if (customDate != null && customDate != "")
                {
                    oFormConditon.Query_customDate = customDate;
                    CommonService.Model.C_SearchConditionRecord SearchConditionRecord = addSearchConditionRecord(groupCode, "自定义时间", customDate);
                    searchConditionRecords.Add(SearchConditionRecord);
                }
                string customDateZ = Request.Params.Get("i_customTime2");//自定义时间至
                if (customDateZ != null && customDateZ != "")
                {
                    oFormConditon.Query_customDateZ = customDateZ;
                    CommonService.Model.C_SearchConditionRecord SearchConditionRecord = addSearchConditionRecord(groupCode, "自定义时间至", customDateZ);
                    searchConditionRecords.Add(SearchConditionRecord);
                }

                if (searchConditionRecords.Count() > 0)
                {
                    _searchConditionRecordWCF.OperateList(searchConditionRecords);
                }
                #endregion
            }

            #endregion

            #region 数据列表
            //数据总数
            this.TotalRecordCount = _processReportingWCF.GetProcessReportingCount(oFormConditon, param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength, type);
            //数据列表
            List<CommonService.Model.Reporting.ProcessReporting> listsLoan = _processReportingWCF.GetProcessReporting(oFormConditon, param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength, type);

            string opreation = "";//操作
            string groupCodeStr = Guid.Empty.ToString();
            if (searchConditionRecords.Count() > 0)
            {
                groupCodeStr = groupCode.ToString();
            }
            //转化数据格式

            IEnumerable<string[]> result;
            if (type == 1)
            {
                result = from c in listsLoan
                         select new[] { 
                             type.ToString(),
                             groupCodeStr,
                             c.Query_area,
                             c.Query_entry,
                             c.平均延期时长,
                             c.实际预期收益,
                             c.延期预期收益,
                             c.实际移交标的,
                             c.延期移交标的,
                             c.平均超期时长,
                             c.超期预期收益,
                             c.超期移交标的,
                             c.区域,
                             c.监控项,
                             c.应完成数,
                             c.实际完成数,
                             c.完成率,
                             c.超期数,
                             c.超期率,
                             c.延期数,
                             c.延期率,
                             opreation
                };
            }
            else if (type == 2)
            {
                result = from c in listsLoan
                         select new[] { 
                             type.ToString(),
                             groupCodeStr,
                             c.Query_area,
                             c.Query_laywerCode,
                             c.Query_entry,
                             c.平均延期时长,
                             c.实际预期收益,
                             c.延期预期收益,
                             c.实际移交标的,
                             c.延期移交标的,
                             c.平均超期时长,
                             c.超期预期收益,
                             c.超期移交标的,
                             c.区域,
                             c.律师,
                             c.监控项,
                             c.应完成数,
                             c.实际完成数,
                             c.完成率,
                             c.超期数,
                             c.超期率,
                             c.延期数,
                             c.延期率,
                             opreation
                };
            }
            else
            {
                result = from c in listsLoan
                         select new[] { 
                             type.ToString(),
                             groupCodeStr,
                             c.Query_area,
                             c.Query_department,
                             c.Query_entry,
                             c.平均延期时长,
                             c.实际预期收益,
                             c.延期预期收益,
                             c.实际移交标的,
                             c.延期移交标的,
                             c.平均超期时长,
                             c.超期预期收益,
                             c.超期移交标的,
                             c.区域,
                             c.营销部门,
                             c.监控项,
                             c.应完成数,
                             c.实际完成数,
                             c.完成率,
                             c.超期数,
                             c.超期率,
                             c.延期数,
                             c.延期率,
                             opreation
                };
            }

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
        /// 添加查询条件记录
        /// </summary>
        /// <param name="groupCode"></param>
        /// <param name="C_SearchConditionRecord_key"></param>
        /// <param name="C_SearchConditionRecord_value"></param>
        /// <returns></returns>
        private CommonService.Model.C_SearchConditionRecord addSearchConditionRecord(Guid groupCode, string C_SearchConditionRecord_key, string C_SearchConditionRecord_value)
        {
            CommonService.Model.C_SearchConditionRecord searchConditionRecord = new CommonService.Model.C_SearchConditionRecord();
            searchConditionRecord.C_SearchConditionRecord_belonging = Convert.ToInt32(SearchConditionRecordBelongingEnum.进程管理统计报表);
            searchConditionRecord.C_SearchConditionRecord_group = groupCode;
            searchConditionRecord.C_SearchConditionRecord_key = C_SearchConditionRecord_key;
            searchConditionRecord.C_SearchConditionRecord_value = C_SearchConditionRecord_value;

            return searchConditionRecord;
        }

        /// <summary>
        /// 详细列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ProcessReportingDetails(string ProcessReportingStr)
        {
            ViewBag.ProcessReportingStr = ProcessReportingStr;
            return View();
        }

        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param">Jquery DataTables 插件参数</param>
        /// <returns></returns>
        public ActionResult AjaxDetailsList(jQueryDataTableParamModel param)
        {
            #region 查询拼接条件设置,查询条件根据实际业务进行相应更改)
            //表单查询模型
            CommonService.Model.Reporting.ProcessReporting oFormConditon = new CommonService.Model.Reporting.ProcessReporting();

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            string processReportingStr = Request.Params.Get("ProcessReportingStr");
            processReportingStr = processReportingStr.Substring(0, processReportingStr.Length - 1);
            string[] processReportingArray = processReportingStr.Split(',');

            List<CommonService.Model.C_SearchConditionRecord> searchConditionRecordList = new List<CommonService.Model.C_SearchConditionRecord>();
            if (processReportingArray[1] != Guid.Empty.ToString())
            {
                searchConditionRecordList = _searchConditionRecordWCF.GetListByGroup(new Guid(processReportingArray[1]));
            }
            foreach (CommonService.Model.C_SearchConditionRecord C_SearchConditionRecord in searchConditionRecordList)
            {
                switch (C_SearchConditionRecord.C_SearchConditionRecord_key)
                {
                    case "地区": oFormConditon.Query_area = C_SearchConditionRecord.C_SearchConditionRecord_value; break;
                    case "部门": oFormConditon.Query_organ = C_SearchConditionRecord.C_SearchConditionRecord_value; break;
                    case "主办律师": oFormConditon.Query_laywer = C_SearchConditionRecord.C_SearchConditionRecord_value; break;
                    case "案件编码": oFormConditon.Query_caseNum = C_SearchConditionRecord.C_SearchConditionRecord_value; break;
                    case "工程名称": oFormConditon.Query_project = C_SearchConditionRecord.C_SearchConditionRecord_value; break;
                    case "管辖法院": oFormConditon.Query_court = C_SearchConditionRecord.C_SearchConditionRecord_value; break;
                    case "委托人": oFormConditon.Query_deleger = C_SearchConditionRecord.C_SearchConditionRecord_value; break;
                    case "对方当事人": oFormConditon.Query_party = C_SearchConditionRecord.C_SearchConditionRecord_value; break;
                    case "移交标的": oFormConditon.Query_subject = C_SearchConditionRecord.C_SearchConditionRecord_value; break;
                    case "移交标的至": oFormConditon.Query_subjectZ = C_SearchConditionRecord.C_SearchConditionRecord_value; break;
                    case "预期收入": oFormConditon.Query_income = C_SearchConditionRecord.C_SearchConditionRecord_value; break;
                    case "预期收入至": oFormConditon.Query_incomeZ = C_SearchConditionRecord.C_SearchConditionRecord_value; break;
                    case "收案时间": oFormConditon.Query_closedDate = C_SearchConditionRecord.C_SearchConditionRecord_value; break;
                    case "收案时间至": oFormConditon.Query_closedDateZ = C_SearchConditionRecord.C_SearchConditionRecord_value; break;
                    case "自定义时间": oFormConditon.Query_customDate = C_SearchConditionRecord.C_SearchConditionRecord_value; break;
                    case "自定义时间至": oFormConditon.Query_customDateZ = C_SearchConditionRecord.C_SearchConditionRecord_value; break;
                    case "营销部门": oFormConditon.Query_department = C_SearchConditionRecord.C_SearchConditionRecord_value; break;
                }
            }
            if (processReportingArray[2] != "")
            {//区域Guid
                oFormConditon.Query_area = processReportingArray[2];
            }
            if (processReportingArray[0] == "2")
            {//以律师统计
                if (processReportingArray[3] != "")
                {//律师Guid
                    oFormConditon.Query_laywerCode = processReportingArray[3];
                }
                if (processReportingArray[4] != "")
                {//监控项Guid
                    oFormConditon.Query_entry = processReportingArray[4];
                }
            }
            else if (processReportingArray[0] == "3")
            {
                if (processReportingArray[3] != "")
                {//部门Guid
                    oFormConditon.Query_department = processReportingArray[3];
                }
                if (processReportingArray[4] != "")
                {//监控项Guid
                    oFormConditon.Query_entry = processReportingArray[4];
                }
            }
            else
            {
                if (processReportingArray[3] != "")
                {//监控项Guid
                    oFormConditon.Query_entry = processReportingArray[3];
                }
            }

            #endregion

            #region 数据列表
            //数据总数
            this.TotalRecordCount = _processReportingWCF.GetProcessDetailsCount(oFormConditon, param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            //数据列表
            List<CommonService.Model.MonitorManager.M_Entry_Statistics> listsLoan = _processReportingWCF.GetProcessDetails(oFormConditon, param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);
            //案件类型参数集合
            List<CommonService.Model.C_Parameters> Case_type = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(CaseEnum.案件类型));
            //预警类型参数集合
            List<CommonService.Model.C_Parameters> warningType = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(EntrylEnum.预警类型));
            //办案状态参数集合
            List<CommonService.Model.C_Parameters> handlingState = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(EntrylEnum.监控状态));
            //预警情况参数集合
            List<CommonService.Model.C_Parameters> warningSituation = _parameterWCF.GetChildrenByParentId(Convert.ToInt32(EntrylEnum.预警情况));
            //转化数据格式
            var result = from c in listsLoan
                         select new[] { 
                             c.M_Case_name,
                             c.M_Case_type!=null ? Case_type.Where(b => b.C_Parameters_id == c.M_Case_type).FirstOrDefault().C_Parameters_name : "",
                             c.M_Entry_name,
                             c.M_Entry_Duration.ToString(),
                             c.M_Entry_Statistics_changeDuration.ToString(),
                             c.M_Entry_Statistics_entrySTime!=null ? c.M_Entry_Statistics_entrySTime.Value.ToString("yyyy-MM-dd") : "",
                             c.M_Entry_Statistics_entryETime!=null ? c.M_Entry_Statistics_entryETime.Value.ToString("yyyy-MM-dd") : "",
                             c.M_Entry_Statistics_HandlingState!=null ? handlingState.Where(d=>d.C_Parameters_id==c.M_Entry_Statistics_HandlingState).FirstOrDefault().C_Parameters_name : "",
                             c.M_Entry_Statistics_Management.ToString(),
                             c.M_Entry_Statistics_warningSituation!=null ? warningSituation.Where(d=>d.C_Parameters_id==c.M_Entry_Statistics_warningSituation).FirstOrDefault().C_Parameters_name : "",
                             c.M_Entry_warningType!=null ? warningType.Where(a=>a.C_Parameters_id==c.M_Entry_warningType).FirstOrDefault().C_Parameters_name : "",
                             c.M_Entry_warningDuration.ToString(),
                             c.M_Case_number
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
            //表单查询模型
            CommonService.Model.Reporting.ProcessReporting oFormConditon = new CommonService.Model.Reporting.ProcessReporting();

            int type = Convert.ToInt32(Request.Params.Get("type"));
            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string area = Request.Params.Get("i_area");//区域
                if (area != null && area != "-1")
                {
                    oFormConditon.Query_area = area;
                }
                string dept = Request.Params.Get("s_dept");//部门
                if (dept != null && dept != "")
                {
                    if (type == 3)
                    {
                        oFormConditon.Query_department = dept;
                    }
                    else
                    {
                        oFormConditon.Query_organ = dept; 
                    }
                   
                }
                string Sponsorlawyer = Request.Params.Get("s_Sponsorlawyer");//主办律师
                if (Sponsorlawyer != null && Sponsorlawyer != "")
                {
                    oFormConditon.Query_laywer = Sponsorlawyer;
                }
                string number = Request.Params.Get("s_number");//案件编码
                if (number != null && number != "")
                {
                    oFormConditon.Query_caseNum = number;
                }
                string priject = Request.Params.Get("s_project");//工程名称
                if (priject != null && priject != "")
                {
                    oFormConditon.Query_project = priject;
                }
                string count = Request.Params.Get("s_court");//管辖法院
                if (count != null && count != "")
                {
                    oFormConditon.Query_court = count;
                }
                string client = Request.Params.Get("s_client");//委托人
                if (client != null && client != "")
                {
                    oFormConditon.Query_deleger = client;
                }
                string party = Request.Params.Get("s_otherParty");//对方当事人
                if (party != null && party != "")
                {
                    oFormConditon.Query_party = party;
                }
                string subject = Request.Params.Get("s_otherParty1");//移交标的
                if (subject != null && subject != "")
                {
                    oFormConditon.Query_subject = subject;
                }
                string subjectZ = Request.Params.Get("s_otherParty2");//移交标的至
                if (subjectZ != null && subjectZ != "")
                {
                    oFormConditon.Query_subjectZ = subjectZ;
                }
                string income = Request.Params.Get("s_expectedRevenue1");//预期收入
                if (income != null && income != "")
                {
                    oFormConditon.Query_income = income;
                }
                string incomeZ = Request.Params.Get("s_expectedRevenue2");//预期收入至
                if (incomeZ != null && incomeZ != "")
                {
                    oFormConditon.Query_incomeZ = incomeZ;
                }
                string closedDate = Request.Params.Get("i_studyTime1");//收案时间
                if (closedDate != null && closedDate != "")
                {
                    oFormConditon.Query_closedDate = closedDate;
                }
                string closedDateZ = Request.Params.Get("i_studyTime2");//收案时间至
                if (closedDateZ != null && closedDateZ != "")
                {
                    oFormConditon.Query_closedDateZ = closedDateZ;
                }
                string customDate = Request.Params.Get("i_customTime1");//自定义时间
                if (customDate != null && customDate != "")
                {
                    oFormConditon.Query_customDate = customDate;
                }
                string customDateZ = Request.Params.Get("i_customTime2");//自定义时间至
                if (customDateZ != null && customDateZ != "")
                {
                    oFormConditon.Query_customDateZ = customDateZ;
                }
                #endregion
            }

            #endregion

            //数据列表
            List<CommonService.Model.Reporting.ProcessReporting> listsLoan = _processReportingWCF.GetProcessReporting(oFormConditon, 1, 1000000, type);

            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            //貌似这里可以设置各种样式字体颜色背景等，但是不是很方便，这里就不设置了

            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("区域");
            if (type == 2)
            {
                row1.CreateCell(1).SetCellValue("主办律师");
            }
            if (type == 3)
            {
                row1.CreateCell(1).SetCellValue("营销部门");
            }
            row1.CreateCell(type == 1 ? 1 : 2).SetCellValue("监控项");
            row1.CreateCell(type == 1 ? 2 : 3).SetCellValue("应完成数");
            row1.CreateCell(type == 1 ? 3 : 4).SetCellValue("实际完成数");
            row1.CreateCell(type == 1 ? 4 : 5).SetCellValue("完成率");
            row1.CreateCell(type == 1 ? 5 : 6).SetCellValue("超期数");
            row1.CreateCell(type == 1 ? 6 : 7).SetCellValue("超期率");
            row1.CreateCell(type == 1 ? 7 : 8).SetCellValue("延期数");
            row1.CreateCell(type == 1 ? 8 : 9).SetCellValue("延期率");

            //....N行

            //将数据逐步写入sheet1各个行
            for (int i = 0; i < listsLoan.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);

                rowtemp.CreateCell(0).SetCellValue(listsLoan[i].区域);
                if (type == 2)
                {
                    rowtemp.CreateCell(1).SetCellValue(listsLoan[i].律师);
                }
                if (type == 3)
                {
                    rowtemp.CreateCell(1).SetCellValue(listsLoan[i].营销部门);
                }
                rowtemp.CreateCell(type == 1 ? 1 : 2).SetCellValue(listsLoan[i].监控项);
                rowtemp.CreateCell(type == 1 ? 2 : 3).SetCellValue(listsLoan[i].应完成数);
                rowtemp.CreateCell(type == 1 ? 3 : 4).SetCellValue(listsLoan[i].实际完成数);
                rowtemp.CreateCell(type == 1 ? 4 : 5).SetCellValue(listsLoan[i].完成率);
                rowtemp.CreateCell(type == 1 ? 5 : 6).SetCellValue(listsLoan[i].超期数);
                rowtemp.CreateCell(type == 1 ? 6 : 7).SetCellValue(listsLoan[i].超期率);
                rowtemp.CreateCell(type == 1 ? 7 : 8).SetCellValue(listsLoan[i].延期数);
                rowtemp.CreateCell(type == 1 ? 8 : 9).SetCellValue(listsLoan[i].延期率);
                //....N行
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            DateTime dt = DateTime.Now;
            string dateTime = dt.ToString("yyMMddHHmmssfff");
            string fileName = "进程监控报表" + dateTime + ".xls";
            return File(ms, "application/vnd.ms-excel", fileName);
        }
        #endregion
    }
}