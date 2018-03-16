using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Context
{
    /// <summary>
    /// 登录上下文信息
    /// </summary>
    public class UIContext
    {
        private static UIContext current;
        /// <summary>
        /// 当前登录用户实例
        /// </summary>
        public static UIContext Current
        {
            get
            {
                if (current == null)
                {
                    current = new UIContext();
                }
                return current;
            }
        }

        /// <summary>
        /// 登录主用户Guid(Code)
        /// </summary>
        public Guid? UserCode
        {
            //get
            //{
            //    IOwinContext ctx = HttpContext.Current.Request.GetOwinContext();
            //    ClaimsPrincipal user = ctx.Authentication.User;
            //    var claims = user.Claims.ToList();

            //    string sId = GetClaim(claims, ClaimTypes.Sid);
            //    if (string.IsNullOrEmpty(sId))
            //    {
            //        return null;
            //    }
            //    return new Guid(sId);
            //}
            get
            {
                IOwinContext ctx = HttpContext.Current.Request.GetOwinContext();
                ClaimsPrincipal user = ctx.Authentication.User;
                var claims = user.Claims.ToList();

                string rootUserCode = GetClaim(claims, "rootUserCode");
                if (string.IsNullOrEmpty(rootUserCode))
                {
                    return null;
                }
                return new Guid(rootUserCode);
            }
        }

        /// <summary>
        /// 登录主用户Guid(Code)
        /// </summary>
        public Guid? RootUserCode
        {
            get
            {
                IOwinContext ctx = HttpContext.Current.Request.GetOwinContext();
                ClaimsPrincipal user = ctx.Authentication.User;
                var claims = user.Claims.ToList();

                string rootUserCode = GetClaim(claims, "rootUserCode");
                if (string.IsNullOrEmpty(rootUserCode))
                {
                    return null;
                }
                return new Guid(rootUserCode);
            }
        }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName
        {
            get
            {
                IOwinContext ctx = HttpContext.Current.Request.GetOwinContext();
                ClaimsPrincipal user = ctx.Authentication.User;
                var claims = user.Claims.ToList();

                string name = GetClaim(claims, ClaimTypes.Name);
                if (string.IsNullOrEmpty(name))
                {
                    return "";
                }
                return name;
            }
        }

        /// <summary>
        /// 登录名称
        /// </summary>
        public string LoginName
        {
            get
            {
                IOwinContext ctx = HttpContext.Current.Request.GetOwinContext();
                ClaimsPrincipal user = ctx.Authentication.User;
                var claims = user.Claims.ToList();

                string name = GetClaim(claims, ClaimTypes.GivenName);
                if (string.IsNullOrEmpty(name))
                {
                    return "";
                }
                return name;
            }
        }
        /// <summary>
        /// 用户地区名称
        /// </summary>
        //public string LoginArea
        //{
        //    get
        //    {
        //        IOwinContext ctx = HttpContext.Current.Request.GetOwinContext();
        //        ClaimsPrincipal user = ctx.Authentication.User;
        //        var claims = user.Claims.ToList();

        //        string name = GetClaim(claims, "userArea");
        //        if (string.IsNullOrEmpty(name))
        //        {
        //            return "";
        //        }
        //        return name;
        //    }
        //}

        /// <summary>
        /// 用户所属部门岗位集合
        /// </summary>
        public List<V_User_Org_Post> UserOrgPosts
        {
            get
            {
                IOwinContext ctx = HttpContext.Current.Request.GetOwinContext();
                ClaimsPrincipal user = ctx.Authentication.User;
                var claims = user.Claims.ToList();

                string userOrgPosts = GetClaim(claims, "userOrgPosts");
                if (string.IsNullOrEmpty(userOrgPosts))
                {
                    return new List<V_User_Org_Post>();
                }

                //转换字符串拼接，为集合
                string[] orgPosts = userOrgPosts.Split('|');
                List<V_User_Org_Post> userOrgPostArray = new List<V_User_Org_Post>();
                for (int i = 0; i < orgPosts.Length; i++)
                {
                    string[] dutys = orgPosts[i].Split(',');
                    if (dutys.Length >= 8)
                    {
                        V_User_Org_Post userOrgPost = new V_User_Org_Post();
                        userOrgPost.PostCode = new Guid(dutys[0]);
                        userOrgPost.PostName = dutys[1];
                        userOrgPost.OrgCode = new Guid(dutys[2]);
                        userOrgPost.OrgName = dutys[3];
                        if (!String.IsNullOrEmpty(dutys[4]))
                        {
                            userOrgPost.OrgRegionCode = new Guid(dutys[4]);
                        }
                        userOrgPost.OrgRegionName = dutys[5];
                        userOrgPost.PostGroupCode = new Guid(dutys[6]);
                        userOrgPost.PostGroupName = dutys[7];

                        userOrgPostArray.Add(userOrgPost);
                    }
                }

                return userOrgPostArray;
            }
        }

        /// <summary>
        /// 用户角色集合
        /// </summary>
        public string UserRoles
        {
            get
            {
                IOwinContext ctx = HttpContext.Current.Request.GetOwinContext();
                ClaimsPrincipal user = ctx.Authentication.User;
                var claims = user.Claims.ToList();

                string userRoles = GetClaim(claims, "userRoles");
                if (string.IsNullOrEmpty(userRoles))
                {
                    return "";
                }
                return userRoles;
            }
        }
        /// <summary>
        /// 登录部门Guid(Code)(一定要慎重运用此会话，只有父页面为"按部门、岗位、人员权限动态加载的tab页签列表的情况，才可以使用")
        /// </summary>
        public Guid? OrgCode     
        {
            get
            {
                IOwinContext ctx = HttpContext.Current.Request.GetOwinContext();
                ClaimsPrincipal user = ctx.Authentication.User;
                var claims = user.Claims.ToList();

                string orgCode = GetClaim(claims, "orgCode");
                if (string.IsNullOrEmpty(orgCode))
                {
                    return null;
                }
                return new Guid(orgCode);
            }
        }

        /// <summary>
        /// 登录岗位Guid(Code)(一定要慎重运用此会话，只有父页面为"按部门、岗位、人员权限动态加载的tab页签列表的情况，才可以使用")
        /// </summary>
        public Guid? PostCode
        {
            get
            {
                IOwinContext ctx = HttpContext.Current.Request.GetOwinContext();
                ClaimsPrincipal user = ctx.Authentication.User;
                var claims = user.Claims.ToList();

                string postCode = GetClaim(claims, "postCode");
                if (string.IsNullOrEmpty(postCode))
                {
                    return null;
                }
                return new Guid(postCode);
            }
        }

        /// <summary>
        /// 登录岗位所属岗位组Guid(Code)(一定要慎重运用此会话，只有父页面为"按部门、岗位、人员权限动态加载的tab页签列表的情况，才可以使用")
        /// </summary>
        public Guid? PostGroupCode
        {
            get
            {
                IOwinContext ctx = HttpContext.Current.Request.GetOwinContext();
                ClaimsPrincipal user = ctx.Authentication.User;
                var claims = user.Claims.ToList();

                string postGroupCode = GetClaim(claims, "postGroupCode");
                if (string.IsNullOrEmpty(postGroupCode))
                {
                    return null;
                }
                return new Guid(postGroupCode);
            }
        }

        /// <summary>
        /// 登录角色Id(已废弃)
        /// </summary>
        //public int? RoleId
        //{
        //    get
        //    {
        //        IOwinContext ctx = HttpContext.Current.Request.GetOwinContext();
        //        ClaimsPrincipal user = ctx.Authentication.User;
        //        var claims = user.Claims.ToList();

        //        string roleId = GetClaim(claims, "roleId");
        //        if (string.IsNullOrEmpty(roleId))
        //        {
        //            return null;
        //        }
        //        return Convert.ToInt32(roleId);
        //    }
        //}

        /// <summary>
        /// 是否为预置系统管理员用户,true为是,false为不是
        /// </summary>
        public bool IsPreSetManager
        {
            get
            {
                IOwinContext ctx = HttpContext.Current.Request.GetOwinContext();
                ClaimsPrincipal user = ctx.Authentication.User;
                var claims = user.Claims.ToList();

                string isPreSetManager = GetClaim(claims, "isPreSetManager");
                if (string.IsNullOrEmpty(isPreSetManager))
                {
                    return false;
                }
                return isPreSetManager == "1" ? true : false;
            }
        }

        /// <summary>
        /// 获取claims中存储的信息
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string GetClaim(List<Claim> claims, string key)
        {
            var claim = claims.FirstOrDefault(c => c.Type == key);
            if (claim == null)
                return null;

            return claim.Value;
        }
    }
}
