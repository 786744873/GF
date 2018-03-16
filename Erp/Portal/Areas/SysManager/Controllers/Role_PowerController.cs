using CommonService.Common;
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
    /// 角色权限控制器
    /// </summary>
    public class Role_PowerController : BaseController
    {
        private readonly ICommonService.SysManager.IC_Role_Power _rolePowerWCF;
        private readonly ICommonService.IC_Parameters _ParametersWCF;


        public Role_PowerController()
        {
            #region 服务初始化
            _rolePowerWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Role_Power>("Role_PowerWCF");
            _ParametersWCF = ServiceProxyFactory.Create<ICommonService.IC_Parameters>("parametersWCF");
            #endregion
        }

        //
        // GET: /SysManager/Role_Power/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 分配角色权限布局页
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <returns></returns>
        public ActionResult DefaultLayout(int roleId)
        {
            List<CommonService.Model.C_Parameters> listP = _ParametersWCF.GetChildrenByParentId(Convert.ToInt32(PowerTypeEnum.权限类型));
            ViewBag.listP = listP;
            ViewBag.RoleId = roleId;
            return View();
        }

        /// <summary>
        /// 全部权限Action
        /// </summary>     
        /// <returns></returns>
        public ActionResult AllList(int? type)
        {
            if (type == 0)
            {
                type = null;
            }
            List<CommonService.Model.SysManager.C_Role_Power> rolePowers = _rolePowerWCF.GetListByType(type);
            return View(rolePowers);
        }

    }
}