using System.Web.Mvc;

namespace Portal.Areas.Feedback
{
    public class FeedbackAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Feedback";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Feedback_default",
                "Feedback/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}