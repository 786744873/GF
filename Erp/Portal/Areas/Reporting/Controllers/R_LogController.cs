using Maticsoft.Common;
using Portal.Controllers;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.Reporting.Controllers
{
    public class R_LogController : BaseController
    {
        private readonly ICommonService.SysManager.IC_Log _logWCF;
        private readonly ICommonService.Reporting.IR_SystemLog_Reporting _SystemLog_ReportingWCF;
        private readonly ICommonService.IC_Region _regionWCF;

        //
        // GET: /Reporting/R_Log/
        public R_LogController()
        {
            _logWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Log>("LogWCF");
            _SystemLog_ReportingWCF = ServiceProxyFactory.Create<ICommonService.Reporting.IR_SystemLog_Reporting>("R_SystemLog_ReportingWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
        }

        public ActionResult Index()
        {
            return View();
        }

        #region 根据区域统计系统访问量

        /// <summary>
        /// 根据区域统计日志
        /// </summary>
        /// <returns></returns>
        public ActionResult LogReport()
        {
            DateTime dateto = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            DateTime datefrom = Convert.ToDateTime(DateTime.Now.AddMonths(-1).ToShortDateString());
            string organization = "";
            DataSet ds = _logWCF.GetReportByArea(datefrom, dateto, organization);

            string result = "[";
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                if (item["区域"] == DBNull.Value || item["区域"] == null)
                {
                    continue;
                }

                result += "{";
                result += "\"area\":" + "\"" + item["区域"].ToString() + "\",";
                result += "\"distance\":" + item["登陆人数"] + ",";
                result += "\"townSize\":10,";
                result += "\"APP人数\":" + (item["APP人数"] == DBNull.Value ? "0" + "," : item["APP人数"] + ",");
                result += "\"云学堂人数\":" + (item["云学堂人数"] == DBNull.Value ? "0" + "," : item["云学堂人数"] + ",");
                result += "\"PC人数\":" + (item["PC人数"] == DBNull.Value ? "0" : item["PC人数"] + "");
                result += "},";
            }
            if (result.Length > 1)
            {
                result = result.Substring(0, result.Length - 1);
            }
            result += "]";

            ViewBag.Result = result;
            ViewBag.dateto = dateto.ToShortDateString();
            ViewBag.datefrom = datefrom.ToShortDateString();
            return View();
        }

        /// <summary>
        /// 根据区域统计日志
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="organization"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult LogReport2(FormCollection collection, string dateFrom, string dateTo, string organization, string type)
        {
            DateTime dateto;
            DateTime datefrom;
            string result = "";
            if (string.IsNullOrEmpty(dateTo))
            {
                dateto = DateTime.Now.AddDays(1);
            }
            else
            {
                dateto = Convert.ToDateTime(dateTo).AddDays(1);//如：1月2号到5号的实际为1月2号凌晨到6号的凌晨
            }
            if (string.IsNullOrEmpty(dateFrom))
            {
                datefrom = Convert.ToDateTime("1900-01-01");
            }
            else
            {
                datefrom = Convert.ToDateTime(dateFrom);
            }
            if (type == "1")
            {
                DataSet ds = _logWCF.GetReportByArea(datefrom, dateto, organization);
                result = "[";
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    if (item["区域"] == DBNull.Value || item["区域"] == null)
                    {
                        continue;
                    }

                    result += "{";
                    result += "\"area\":" + "\"" + item["区域"].ToString() + "\",";
                    result += "\"distance\":" + item["登陆人数"] + ",";
                    result += "\"townSize\":10,";
                    result += "\"APP人数\":" + (item["APP人数"] == DBNull.Value ? "0" + "," : item["APP人数"] + ",");
                    result += "\"云学堂人数\":" + (item["云学堂人数"] == DBNull.Value ? "0" + "," : item["云学堂人数"] + ",");
                    result += "\"PC人数\":" + (item["PC人数"] == DBNull.Value ? "0" : item["PC人数"] + "");
                    result += "},";
                }
                if (result.Length > 1)
                {
                    result = result.Substring(0, result.Length - 1);
                }
                result += "]";
            }
            else
            {
                DataSet ds = _logWCF.GetReportByAreaCount(datefrom, dateto, organization);
                result = "[";
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    if (item["区域"] == DBNull.Value || item["区域"] == null)
                    {
                        continue;
                    }

                    result += "{";
                    result += "\"area\":" + "\"" + item["区域"].ToString() + "\",";
                    result += "\"distance\":" + item["登陆次数"] + ",";
                    result += "\"townSize\":10,";
                    result += "\"APP次数\":" + (item["APP次数"] == DBNull.Value ? "0" + "," : item["APP次数"] + ",");
                    result += "\"云学堂次数\":" + (item["云学堂次数"] == DBNull.Value ? "0" + "," : item["云学堂次数"] + ",");
                    result += "\"PC次数\":" + (item["PC次数"] == DBNull.Value ? "0" : item["PC次数"] + "");
                    result += "},";
                }
                if (result.Length > 1)
                {
                    result = result.Substring(0, result.Length - 1);
                }
                result += "]";
            }
            return Json(result);
        }

        #endregion

        #region 根据人员统计系统访问量

        /// <summary>
        /// 系统访问量统计
        /// </summary>
        /// <returns></returns>
        public ActionResult LogReportByUser()
        {
            var areaList = _regionWCF.GetAllList(); //区域
            ViewBag.AreaList = areaList;
            DateTime dateto = DateTime.Now;
            DateTime datefrom = Convert.ToDateTime(DateTime.Now.AddMonths(-1));
            ViewBag.dateTo = dateto.ToShortDateString();
            ViewBag.dateFrom = datefrom.ToShortDateString();
            return View();
        }

        /// <summary>
        /// Ajax获取列表Json
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxLogReportList(jQueryDataTableParamModel param)
        {
            #region 查询拼接条件设置,查询条件根据实际业务进行相应更改)

            string isExecutedSearch = Request.Params.Get("isExecutedSearch");
            //查询条件
            string quyu = "";
            string bumen = "";
            string renyuan = "";
            DateTime dateto = Convert.ToDateTime(DateTime.Now.ToShortDateString());//默认检索开始时间
            DateTime datefrom = Convert.ToDateTime(DateTime.Now.AddMonths(-1).ToShortDateString());//默认检索结束时间
            if (isExecutedSearch != null && isExecutedSearch == "1")
            {//代表已执行查询
                #region 查询项处理
                string area = Request.Params.Get("i_area");//区域
                if (area != null && area != "-1")
                {
                    quyu = area;
                }
                string dept = Request.Params.Get("s_dept");//部门
                if (dept != null && dept != "")
                {
                    bumen = dept;
                }
                string user = Request.Params.Get("s_user");//人员
                if (user != null && user != "")
                {
                    renyuan = user;
                }
                string from = Request.Params.Get("i_dateTimeFrom");//自定义时间
                if (from != null && from != "")
                {
                    datefrom = Convert.ToDateTime(from);
                }
                else
                {
                    datefrom = Convert.ToDateTime("1900-01-01");
                }
                string to = Request.Params.Get("i_dateTimeTo");//自定义时间至
                if (to != null && to != "")
                {
                    dateto = Convert.ToDateTime(to).AddDays(1);//如：1月2号到5号的实际为1月2号凌晨到6号的凌晨
                }
                else
                {
                    dateto = DateTime.Now.AddDays(1);
                }
                #endregion
            }

            #endregion

            #region 数据列表
            //数据总数
            this.TotalRecordCount = _SystemLog_ReportingWCF.GetReportByUserCount(datefrom, dateto, bumen, renyuan, quyu);
            //数据列表
            List<CommonService.Model.Reporting.R_SystemLog_Reporting> listsLoan = _SystemLog_ReportingWCF.GetReportByUser(datefrom, dateto, bumen, renyuan, quyu, param.iDisplayStart + 1, param.iDisplayStart + param.iDisplayLength);

            //转化数据格式

            IEnumerable<string[]> result = from c in listsLoan
                                           select new[] { 
                            c.Area,
                            c.Organization,
                            c.Userinfo,
                            c.TotalTimes.ToString(),
                            c.TotalDays.ToString(),
                            c.AppTotalTimes.ToString(),
                            c.AppTotalDays.ToString(),
                            c.PCTotalTimes.ToString(),
                            c.PCTotalDays.ToString(),
                            c.KmsTotalTimes.ToString(),
                            c.KmsTotalDays.ToString()
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

        #endregion
    }
}