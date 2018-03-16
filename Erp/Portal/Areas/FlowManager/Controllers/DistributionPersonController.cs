using Maticsoft.Common;
using Portal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Areas.FlowManager.Controllers
{
    /// <summary>
    /// 分配负责人控制器
    /// </summary>
    public class DistributionPersonController : BaseController
    {
        private readonly ICommonService.FlowManager.IP_Business_flow _bussinessFlowWCF;
        public DistributionPersonController()
        {
            #region 服务初始化
            _bussinessFlowWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Business_flow>("Business_flowWCF");
            #endregion
        }

        //
        // GET: /FlowManager/DistributionPerson/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 业务流程分配负责人Action
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <returns></returns>
        public ActionResult BusinessFlow_DefaultLayout(FormCollection form, string FlowCode, string fkCode, string type, string postcode)
        {

            //CommonService.Model.FlowManager.P_Business_flow businessFlow = _bussinessFlowWCF.Get(new Guid(businessFlowCode));
            //关联流程Guid
            CommonService.Model.SysManager.C_Userinfo userinfo = new CommonService.Model.SysManager.C_Userinfo();
            if (!String.IsNullOrEmpty(form["C_Userinfo_name"]))
            {
                userinfo.C_Userinfo_name = form["C_Userinfo_name"];
            }
            if (!String.IsNullOrEmpty(form["fkCode"]))
            {
                ViewBag.fkCode = form["fkCode"];
            }
            else
            {
                ViewBag.fkCode = fkCode;
            }
            if (!String.IsNullOrEmpty(form["type"]))
            {
                ViewBag.type = form["type"];
            }
            else
            {
                ViewBag.type = type;
            }
            if (!String.IsNullOrEmpty(form["postcode"]))
            {
                ViewBag.postcode = form["postcode"];
            }
            else
            {
                ViewBag.postcode = postcode;
            }


            ViewBag.FlowCode = FlowCode;
            ViewBag.PrConditon = userinfo;
            return View();
        }

        /// <summary>
        /// 确认分配业务流程负责人
        /// </summary>
        /// <param name="businessFlowCode">业务流程Guid</param>
        /// <param name="userCode">负责人Guid</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ConfirmBusinessFlowPerson(string businessFlowCode, string userCode)
        {
            bool isSuccess = _bussinessFlowWCF.UpdatePerson(new Guid(businessFlowCode), new Guid(userCode));
            if (isSuccess)
            {
                //保存成功提示固定写法
                return Json(TipHelper.JsonData("分配业务流程负责人成功", "", IsAlertTip.Yes, TipType.Success, AlertTipPageType.ThisPage, OperateTypeAfterTip.CloseDialogAndRefreshParent));
            }
            else
            {
                //保存失败固定写法
                return Json(TipHelper.JsonData("分配业务流程负责人失败", "", IsAlertTip.Yes, TipType.Error, AlertTipPageType.ThisPage, OperateTypeAfterTip.NoAction));
            }
        }
    }
}