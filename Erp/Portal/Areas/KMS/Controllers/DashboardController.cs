using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.KMS.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /KMS/Dashboard/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DefaultLayout()
        {
            return View();
        }
	}
}