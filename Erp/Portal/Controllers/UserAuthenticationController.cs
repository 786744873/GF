using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Portal.Controllers
{
    /// <summary>
    /// 用户认证
    /// </summary>
    public class UserAuthenticationController : Controller
    {
        /// <summary>
        /// 当前请求认证对象
        /// </summary>
        public IAuthenticationManager Authentication
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        //
        // GET: /UserAuthentication/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 设置用户认证
        /// </summary>
        /// <param name="userCode">子用用户Guid</param>
        /// <param name="rootUserCode">根用用户Guid</param>
        /// <param name="userName">用户名</param>
        protected void SetUserAuthentication(Guid userCode, Guid? rootUserCode, string userName, string loginName, Guid? orgCode, Guid? postCode, int? roleId, bool isPreSetManager, bool isRemember, string userArea, string userOrgPosts, string userRoles)
        {
            var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Sid, userCode.ToString()),//登录用户Guid
                            new Claim(ClaimTypes.Name, userName),//登录用户名称   
                            new Claim(ClaimTypes.GivenName,loginName),//登录名称
                            new Claim("userArea",userArea==null ? "" :userArea),//登录用户地区
                            new Claim("rootUserCode",rootUserCode==null ? "" : rootUserCode.ToString()),//登录主用户Guid
                            new Claim("orgCode",orgCode==null ? "" : orgCode.ToString()),//登录部门Guid
                            new Claim("postCode",postCode==null ? "" : postCode.ToString()),//登录岗位Guid
                            new Claim("roleId",roleId==null ? "" : roleId.ToString()),//登录角色Id
                            new Claim("isPreSetManager",isPreSetManager ? "1" : "0"),//是否为系统预置管理员用户
                            new Claim("userOrgPosts",userOrgPosts==null ? "" : userOrgPosts.ToString()),//用户所属部门、岗位集合(字符串集合)
                            new Claim("userRoles",userRoles==null ? "" : userRoles.ToString())//用户角色集合
                         };
            var identity = new ClaimsIdentity(
                claims,
                DefaultAuthenticationTypes.ApplicationCookie,
                ClaimTypes.Name,
                ClaimTypes.Role);

            // if you want roles, just add as many as you want here (for loop maybe?)
            //identity.AddClaim(new Claim(ClaimTypes.Role, "guest"));
            /*
             * author:hety 
             * date:2015-06-16
             * description:这种认证机制，默认如果Action有用户操作的话，会自动刷新加密Cookie的有效时间
             **/
            Authentication.SignIn(new AuthenticationProperties { IsPersistent = isRemember }, identity);
        }

        /// <summary>
        /// 刷新在线Owin认证(特指刷新组织机构、岗位)
        /// </summary>
        /// <param name="orgCode">当前用户组织机构Guid</param>
        /// <param name="postCode">当前用户岗位Guid</param>
        /// <param name="postGroupCode">当前用户岗位组Guid</param>
        public void RefreshOnlineOwinAuth(Guid? orgCode, Guid? postCode, Guid? postGroupCode)
        {
            IOwinContext ctx = HttpContext.Request.GetOwinContext();
            ClaimsPrincipal user = ctx.Authentication.User;
            var claims = user.Claims.ToList();

            claims.Remove(this.GetClaim(claims, "orgCode"));
            claims.Remove(this.GetClaim(claims, "postCode"));
            claims.Remove(this.GetClaim(claims, "postGroupCode"));

            claims.Add(new Claim("orgCode",orgCode==null ? "" : orgCode.ToString()));
            claims.Add(new Claim("postCode", postCode == null ? "" : postCode.ToString()));
            claims.Add(new Claim("postGroupCode", postCode == null ? "" : postCode.ToString()));

            var identity = new ClaimsIdentity(
             claims,
            DefaultAuthenticationTypes.ApplicationCookie,
            ClaimTypes.Name,
            ClaimTypes.Role);

            Authentication.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);
        }

        /// <summary>
        /// 获取claims中存储的Claim
        /// </summary>
        /// <param name="claims">Claim集合</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public Claim GetClaim(List<Claim> claims, string key)
        {
            var claim = claims.FirstOrDefault(c => c.Type == key);
            if (claim == null)
                return null;

            return claim;
        }

	}
}