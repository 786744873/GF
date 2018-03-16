using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.SysManager.Controllers
{
    /// <summary>
    /// 角色--区域中间表控制器
    /// </summary>
    public class Userinfo_areaController : BaseController
    {
         private readonly ICommonService.SysManager.IC_Userinfo_area _userinfo_areaWCF;
         private readonly ICommonService.IC_Region _regionWCF;
         public Userinfo_areaController()
        {
            #region 服务初始化            
            _userinfo_areaWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Userinfo_area>("Userinfo_areaWCF");
            _regionWCF = ServiceProxyFactory.Create<ICommonService.IC_Region>("RegionWCF");
            #endregion
        }
        //
        // GET: /SysManager/Userinfo_area/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="form">查询条件表单</param>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult List(FormCollection form, string userCode, int? page = 1)
        {
            #region 查询模型条件设置,查询条件都根据实际业务进行相应更改)

            CommonService.Model.C_Region rrConditon = new CommonService.Model.C_Region();
            string[] userCodes = userCode.Split(',');
            ViewBag.rrConditon = userCodes[2];

            #endregion

            //List<CommonService.Model.C_Region> regionList = _regionWCF.GetAllList();

            return View();
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string userCode, string regionCode)
        {
            bool isSuccess = _userinfo_areaWCF.Delete(new Guid(userCode), new Guid(regionCode));
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除关联区域信息成功！", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshThisPage));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除关联区域信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
	}
}