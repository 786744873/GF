using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.CaseManager.Controllers
{
    /// <summary>
    /// 案件--客户约定控制器
    /// 作者:崔慧栋
    /// 日期:2015/06/04
    /// </summary>
    public class ClientAgreementController : BaseController
    {
        //
        // GET: /CaseManager/ClientAgreement/
        public ActionResult Index()
        {
            return View();
        }

       /// <summary>
        /// tab 页签
       /// </summary>
       /// <param name="caseCode">关联Guid</param>
       /// <param name="type">1、案件  2、商机</param>
       /// <returns></returns>
        public ActionResult TabDetails(string caseCode,int type)
        {
            ViewBag.caseCode = caseCode;
            ViewBag.type = type;
            return View();
        }

        /// <summary>
        /// tab 页签
        /// </summary>
        /// <param name="caseCode">关联Guid</param>
        /// <param name="type">1、案件  2、商机</param>
        /// <returns></returns>
        public ActionResult TabDetailed(string caseCode,int type)
        {
            ViewBag.caseCode = caseCode;
            ViewBag.type = type;
            return View();
        }
	}
}