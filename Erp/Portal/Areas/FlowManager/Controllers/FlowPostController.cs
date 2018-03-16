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
    /// 流程关联岗位控制器
    /// </summary>
    public class FlowPostController : BaseController
    {
        private readonly ICommonService.FlowManager.IP_Flow_post _flowPostWCF;
        public FlowPostController()
        {
            //WCF服务初始化
            _flowPostWCF = ServiceProxyFactory.Create<ICommonService.FlowManager.IP_Flow_post>("Flow_postWCF");
        }

        //
        // GET: /FlowManager/FlowPost/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 流程关联岗位Action
        /// </summary>
        /// <param name="flowCode">流程Guid</param>
        /// <returns></returns>
        public ActionResult FlowRelationPostList(string flowCode, string type, string PCd2)
        {
            if (String.IsNullOrEmpty(flowCode))
            {
                flowCode = Guid.Empty.ToString();
            }
            if (!String.IsNullOrEmpty(PCd2))
            {
                ViewBag.PostCode = PCd2;
            }
            else
            {
                ViewBag.PostCode = "";
            }
 
            List<CommonService.Model.FlowManager.P_Flow_post> FlowPosts = _flowPostWCF.GetListByFlowcode(new Guid(flowCode));
            ViewBag.type = type;
            return View(FlowPosts);
        }
    }
}