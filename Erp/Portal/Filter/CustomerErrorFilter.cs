using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Filter
{
    /// <summary>
    /// 陈永俊
    /// 2015年11月11日11
    /// 异常处理
    /// </summary>
    public class CustomerErrorFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            // 添加记录日志代码
            string errrrMessage = filterContext.Exception.ToString();
        }

    }
}