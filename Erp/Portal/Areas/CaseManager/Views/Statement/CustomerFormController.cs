using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.CaseManager.Views.Statement
{
    public class CustomerFormController : BaseController
    {
        //
        // GET: /CaseManager/CustomerForm/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(FormCollection form, int? page = 1)
        {


     

          

            return View();
        }
	}
}