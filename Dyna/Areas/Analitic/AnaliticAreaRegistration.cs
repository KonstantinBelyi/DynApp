using System.Web.Mvc;

namespace Dyna.Areas.Analitic
{
    public class AnaliticAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Analitic";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Analitic_default",
                "Analitic/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}