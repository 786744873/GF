using System.Web.Mvc;

namespace Portal.Areas.BusinessChanceManager
{
    public class BusinessChanceManagerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BusinessChanceManager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BusinessChanceManager_default",
                "BusinessChanceManager/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}