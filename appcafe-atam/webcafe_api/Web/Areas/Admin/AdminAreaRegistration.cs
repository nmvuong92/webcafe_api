using System.Threading;
using System.Web.Mvc;

namespace Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            var default_lang = Thread.CurrentThread.CurrentCulture.Name;

            //context.MapRoute(
            //    "Admin_default1",
            //    "Admin/{lang}/{controller}/{action}/{id}",
            //    new { lang = default_lang, action = "Index", controller = "Home", id = UrlParameter.Optional },
            //    new[] { "VD.WEB.Areas.Admin.Controllers" }
            //);
            context.MapRoute(
                "Admin_default",
                "vdadmin/{controller}/{action}/{id}",
                new { action = "Index", controller = "Home", id = UrlParameter.Optional },
                new[] { "Web.Areas.Admin.Controllers" }
            );
        }
    }
}