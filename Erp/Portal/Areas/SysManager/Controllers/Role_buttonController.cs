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
    /// 角色--按钮中间表控制器
    /// 作者：崔慧栋
    /// 日期：2015/06/02
    /// </summary>
    public class Role_buttonController : BaseController
    {
        private readonly ICommonService.SysManager.IC_Role_button _role_buttonWCF;

         public Role_buttonController()
        {
            #region 服务初始化
            _role_buttonWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Role_button>("Role_buttonWCF");
            #endregion
        }
        //
        // GET: /SysManager/Role_button/
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
        public ActionResult List(int roleId,int? menuId)
        {
            int menu_id = 0;
            if(menuId!=null)
            {
                menu_id = int.Parse(menuId.ToString());
            }
            List<CommonService.Model.SysManager.C_Role_button> role_buttons = _role_buttonWCF.GetListByMenuId(roleId, menu_id);
            return View(role_buttons);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int roleId, int menu_buttonsId)
        {
            bool isSuccess = _role_buttonWCF.Delete(roleId,menu_buttonsId);
            if (isSuccess)
            {//成功
                return Json(TipHelper.JsonData("删除关联按钮信息成功！", "iframe_allocatedBtnList", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除关联按钮信息失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
	}
}