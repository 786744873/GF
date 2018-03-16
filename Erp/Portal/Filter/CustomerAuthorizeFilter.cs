using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace Portal.Filter
{
    /// <summary>
    /// author:hety
    /// date:2015-06-16
    /// description:自定义授权信息
    /// </summary>
    public class CustomerAuthorizeFilter : AuthorizeAttribute
    {
        /// <summary>
        /// 授权中心
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {            
                return false;
            }
            return true;
        }

        /// <summary>
        /// 尚未授权，跳转到指定页面(含framset或iframe框架的跳转)(这种情况代表执行相应Action之前)
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                
                filterContext.Result = new EmptyResult();//必须返回一个空结果；否则还会执行对应的Action
                string url = "/Account/SignIn"; //跳转到登录页面
                string requestUrl = filterContext.RequestContext.HttpContext.Request.RawUrl.ToLower();
                if (requestUrl.Contains("kms"))
                {
                    url = "/Account/kmsSignIn"; //跳转到知识库登录页面
                }
                filterContext.HttpContext.Response.Write("<script type=\"text/javascript\" language=\"javascript\">top.location.href='" + url + "';</script>");
            }
        }

        /// <summary>
        /// 尚未授权，跳转到指定页面(含framset或iframe框架的跳转)(这种情况代表执行相应Action之后)，目前被废弃
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
           
        }
    }
}