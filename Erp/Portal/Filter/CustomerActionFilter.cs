using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Filter
{
    /// <summary>
    /// 自定义Action基类
    /// </summary>
    public class CustomerActionFilter : FilterAttribute, IActionFilter
    {
        /// <summary>
        /// action执行以后调用此方法
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string requestUrl = filterContext.RequestContext.HttpContext.Request.RawUrl.ToLower();

            if (!(requestUrl.Contains("/home/") || requestUrl.Contains("/account/") || requestUrl.Contains("/kms/") || requestUrl.Contains("/oa/") || requestUrl.Contains("/feedback/") || requestUrl == "/" || requestUrl == "" || requestUrl.Contains("/weixinapi/")
                || requestUrl.Contains("/formpropertyvalue/") || requestUrl.Contains("/export") || requestUrl.Contains("/individuationform") || requestUrl.Contains("/downpic")))//去掉导出的action
            {//action之前以后，关闭"加载中"UI控件
                if (!filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.Write("<script type=\"text/javascript\" language=\"javascript\">if (window.parent != window) {top.hideBasicLoading();}</script>");
                }                
            }
 
            if (requestUrl.Contains("/home/main"))
            {//主控制台页面 增加 "关闭进度条提示"操作
                filterContext.HttpContext.Response.Write("<script type=\"text/javascript\" language=\"javascript\">top.hideBasicLoading();</script>");
            }
        }

        /// <summary>
        /// action执行之前调用此方法
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string a = "";
        }
    }
}