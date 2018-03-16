using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.Milepost.Controllers
{
    /// <summary>
    /// 稽查控制器
    /// </summary>
    public class CheckAuthorityController : BaseController
    {
        /// <summary>
        /// 虚拟稽查WCF服务
        /// </summary>
        private readonly ICommonService.Customer.IV_CheckAuthority checkAuthorityWCF;
        public CheckAuthorityController()
        {
            checkAuthorityWCF = ServiceProxyFactory.Create<ICommonService.Customer.IV_CheckAuthority>("VCheckAuthorityWCF");
        }
        //
        // GET: /Milepost/CheckAuthority/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 稽查简要统计Action
        /// </summary>
        /// <param name="pkCode">业务Guid(比如案件Guid)</param>
        /// <returns></returns>
        public ActionResult CheckAuthorityStatistics(string pkCode)
        {
            ViewBag.PkCode = pkCode;
            List<CommonService.Model.Customer.V_CheckAuthority> VCheckAuthoritys = checkAuthorityWCF.GetBriefCheckAuthorityByPkCode(new Guid(pkCode));
            return View(VCheckAuthoritys);
        }

	}
}