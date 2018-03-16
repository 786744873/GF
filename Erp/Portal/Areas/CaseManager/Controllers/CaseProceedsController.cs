using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.CaseManager.Controllers
{
    /// <summary>
    /// 案件收益核算信息控制器
    /// </summary>
    public class CaseProceedsController : BaseController
    {
        //
        // GET: /CaseManager/CaseProceeds/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// tab 页签
        /// </summary>
        /// <returns></returns>
        public ActionResult TabDetails(string fkCode)
        {
            ViewBag.fkCode = fkCode;
            return View();
        }
	}
}