using System.Web.Mvc;

namespace Portal.Areas.TypicalCase
{
    public class TypicalCaseAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TypicalCase";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TypicalCase_default",
                "TypicalCase/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}