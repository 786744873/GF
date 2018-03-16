using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.BaseData.Controllers
{
    /// <summary>
    /// 财产线索控制器
    /// </summary>
    public class Property_trailController : BaseController
    {
        //
        // GET: /BaseData/Property_trail/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// tab 页签
        /// </summary>
        /// <returns></returns>
        public ActionResult TabDetails(string crival_code, int? property_trail_type)
        {
            ViewBag.CRival_code = crival_code;
            ViewBag.Property_trail_type = property_trail_type;
            return View();
        }

        /// <summary>
        /// 财产详细
        /// </summary>
        /// <returns></returns>
        public ActionResult PropertyTabDetails(string crival_code, int? property_trail_type)
        {
            ViewBag.CRival_code = crival_code;
            ViewBag.Property_trail_type = property_trail_type;
            return View();
        }
	}
}