using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.IndividuationForm.Controllers
{
    /// <summary>
    /// 附件表单(个性化)
    /// </summary>
    public class AttachmentFormController : BaseController
    {
        //
        // GET: /IndividuationForm/AttachmentForm/
        public override ActionResult Index()
        {
            return View();
        }
	}
}