using Portal.Filter;
using System.Web;
using System.Web.Mvc;

namespace Portal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomerActionFilter());//自定义Action过滤器
            filters.Add(new CustomerErrorFilter());
        }
    }
}
