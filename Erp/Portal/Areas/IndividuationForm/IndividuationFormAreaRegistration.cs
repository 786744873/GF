using System.Web.Mvc;

namespace Portal.Areas.IndividuationForm
{
    public class IndividuationFormAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "IndividuationForm";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "IndividuationForm_default",
                "IndividuationForm/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}