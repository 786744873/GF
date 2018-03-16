using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.CaseManager.Controllers
{
    public class CasePlanController : BaseController
    {
        private readonly ICommonService.CaseManager.IB_Case _caseWCF;
        private readonly ICommonService.CaseManager.IB_Case_plan _casespanWCF;
        private readonly ICommonService.SysManager.IC_Role_Role_Power _roleRolePowerWCF;

        public CasePlanController()
        {
            #region 服务初始化
            _caseWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case>("CaseWCF");
            _casespanWCF = ServiceProxyFactory.Create<ICommonService.CaseManager.IB_Case_plan>("Case_PlanWCF");
            _roleRolePowerWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Role_Role_Power>("Role_Role_PowerWCF");
            #endregion
        }
        //
        // GET: /CaseManager/CasePlan/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// tab 页签
        /// </summary>
        /// <returns></returns>
        public ActionResult TabDetails(string fkCode, string businessFlowCode)
        {

            ViewBag.businessFlowCode = businessFlowCode;
            if (!string.IsNullOrEmpty(fkCode))
            {
                string[] a = fkCode.Split(',');
                if (a.Length == 2)
                {
                    fkCode = a[0];
                }
            }
            ViewBag.fkCode = fkCode;

            #region 权限
            Guid? orgCode=null;//当前用户所属部门Guid
            Guid? postCode=null;//当前用户所属岗位Guid
            List<CommonService.Model.SysManager.C_Role_Role_Power> roleRolePowers;
            if (Context.UIContext.Current.IsPreSetManager)
            {
                roleRolePowers = new List<CommonService.Model.SysManager.C_Role_Role_Power>();
            }
            else
            {
                if (Request.QueryString["orgCode"] != null)
                    orgCode = new Guid(Request.QueryString["orgCode"]);
                if (Request.QueryString["postCode"] != null)
                    postCode = new Guid(Request.QueryString["postCode"]);
                roleRolePowers = _roleRolePowerWCF.GetRolePowersByOrgPostUserCode(orgCode, Context.UIContext.Current.UserCode, postCode);
            }
            ViewBag.RoleRolePowers = roleRolePowers;
            #endregion

            return View();
        }

    }
}