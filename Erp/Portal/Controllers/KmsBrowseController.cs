using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Controllers
{
    public class KmsBrowseController : Controller
    {
        //
        // GET: /KmsBrowse/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult KmsSelectResource()
        {
            return View();
        }
	}
}