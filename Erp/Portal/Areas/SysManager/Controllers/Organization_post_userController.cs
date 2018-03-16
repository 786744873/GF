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
    /// 组织机构—岗位—人员关系控制器
    /// </summary>
    public class Organization_post_userController : BaseController
    {
        private readonly ICommonService.SysManager.IC_Organization_post_user  _orgUserPostWCF;

        public Organization_post_userController()
        {
           //服务初始化
            _orgUserPostWCF = ServiceProxyFactory.Create<ICommonService.SysManager.IC_Organization_post_user>("OrgPostUserWCF");
        }

        //
        // GET: /SysManager/Organization_post_user/
        public override ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取用户已分配岗位Action
        /// </summary>
        /// <param name="orgCode">组织机构Guid</param>
        /// <param name="userCode">用户Guid</param>
        /// <returns></returns>
        public ActionResult GetHasDisputedPosts(string orgCode, string userCode)
        {
            Guid? _orginzationCode=null;
            Guid? _userCode=null;
            if (!orgCode.Equals("{orgCode}"))
            {
                _orginzationCode = new Guid(orgCode);
            }
            _userCode = new Guid(userCode);
            List<CommonService.Model.SysManager.C_Organization_post_user> orgUserPosts = _orgUserPostWCF.GetHasDisbutedPosts(_orginzationCode, _userCode);
            return View(orgUserPosts);
        }

	}
}