
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;
using VD.Lib;
using Web.App_Start;
using Web.Helpers;


namespace Web
{
    public class RouteConfig
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapHubs();
            
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.IgnoreRoute("Content/{*pathInfo}");
            //routes.IgnoreRoute("uploads/{*pathInfo}");
            //routes.IgnoreRoute("imagecache/{*pathInfo}");

            //routes.RouteExistingFiles = true;
            routes.LowercaseUrls = true;
            routes.MapMvcAttributeRoutes();
            // Call to register your localized and default attribute routes

         
            //routes.MapRoute(
            //        name: "DefaultCulture",
            //        url: "{lang}/{controller}/{action}/{id}",
            //        constraints: new { lang = @"(\w{2})|(\w{2}-\w{2})" },
            //        defaults: new { lang = "en-US", controller = "Home", action = "index", id = UrlParameter.Optional },
            //        namespaces: new[] { "Web.Controllers" }
            //    );


            routes.MapRoute(

              name: "Default",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "index", id = UrlParameter.Optional },
              namespaces: new[] { "Web.Controllers" }

          );
        }
    }
}
