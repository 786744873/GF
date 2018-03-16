using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.BaseData.Controllers
{
    /// <summary>
    /// 法院所属区域控制器（）
    /// 作者：陈永俊
    /// 时间：2015年6月18日
    /// </summary>
    public class Region_CourtController : BaseController
    {
        private readonly ICommonService.IC_Region _regionWCF;
        private readonly ICommonService.SysManager.IC_Userinfo_area _userinfo_areaWCF;
        //
        // GET: /BaseData/Region_Court/
        public ActionResult Index()
        {
            return View();
        }
        public Region_CourtController()
        {
            #region 服务初始化
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
            _userinfo_areaWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo_area>("Userinfo_areaWCF");
            #endregion
        }
        /// <summary>
        /// 布局TreeList
        /// </summary>
        /// <returns></returns>
        public ActionResult LayoutTreeList()
        {
            return View();
        }

	}
}