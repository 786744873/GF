using System.Web.Mvc;

namespace Portal.Areas.IndividuationCallBack
{
    public class IndividuationCallBackAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "IndividuationCallBack";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "IndividuationCallBack_default",
                "IndividuationCallBack/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}