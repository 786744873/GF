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
    /// 角色-角色权限关联控制器
    /// </summary>
    public class Role_Role_PowerController : BaseController
    {
        private readonly ICommonService.SysManager.IC_Role_Role_Power _roleRolePowerWCF;

        public Role_Role_PowerController()
        {
            #region 服务初始化         
            _roleRolePowerWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Role_Role_Power>("Role_Role_PowerWCF");
            #endregion
        }

        //
        // GET: /SysManager/Role_Role_Power/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 角色关联角色权限列表Action
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        public ActionResult RoleRelationRolePowerList(int roleId)
        {
            List<CommonService.Model.SysManager.C_Role_Role_Power> roleRolePowers = _roleRolePowerWCF.GetRolePowersByRoleId(roleId);
            return View(roleRolePowers);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <param name="rolePowerId">角色权限Id</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(int roleId,int rolePowerId)
        {
            CommonService.Model.SysManager.C_Role_Role_Power role_RolePower = new CommonService.Model.SysManager.C_Role_Role_Power();
            role_RolePower.C_Roles_id = roleId;
            role_RolePower.C_Role_Power_id = rolePowerId;

            bool isExists = _roleRolePowerWCF.Exists(roleId, rolePowerId);
            if (isExists)
            {
                return Json(TipHelper.JsonData("不可以重复设置权限！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
            int role_Role_Power_id = _roleRolePowerWCF.Add(role_RolePower);
            if (role_Role_Power_id >0)
            {//成功           
                return Json(TipHelper.JsonData("增加权限成功！", "iframe_role_rolePower", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("增加权限失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="roleRolePowerId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int roleRolePowerId)
        {
            bool isSuccess = _roleRolePowerWCF.Delete(roleRolePowerId);
            if (isSuccess)
            {//成功           
                return Json(TipHelper.JsonData("删除权限成功！", "iframe_role_rolePower", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.RefreshIframeChildren));
            }
            else
            {//失败
                return Json(TipHelper.JsonData("删除权限失败！", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
	}
}