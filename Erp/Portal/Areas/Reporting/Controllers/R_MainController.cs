using Context;
using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.Reporting.Controllers
{
    public class R_MainController : BaseController
    {
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;
        //
        // GET: /Reporting/R_Main/

        public R_MainController()
        {
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Main()
        {
            DataSet ds = _caseWCF.GetReportByYear();

            string result = "[";
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                if(item["月份"]==DBNull.Value||item["月份"]==null)
                {
                    continue;
                }

                result += "{";
                result += "\"date\":" + "" + item["月份"].ToString()+ ",";
                result += "\"distance\":"+item["数量"]+",";
                result += "\"townSize\":10,";
                result += "\"移交标的\":" + (item["移交标的"] == DBNull.Value ? "0" + "," : item["移交标的"] + ",");
                result += "\"预期收益\":" + (item["预期收益"] == DBNull.Value ? "0" : item["预期收益"] + "");
                result += "},";
            }
            if (result.Length > 1)
            {
                result = result.Substring(0, result.Length - 1);
            }
            result += "]";

            ViewBag.Result = result;
            return View();
        }
    }
}