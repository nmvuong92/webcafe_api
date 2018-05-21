using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using VD.Lib;


namespace Web.Fitters
{
    public class LocalizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
            /*if (!filterContext.IsChildAction)
            {
                string culture = "vi-VN";//; myCookies.GetLang();
                //filterContext.RouteData.Values["lang"] = culture;
                if (culture!=string.Empty)
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
                }
            }
            base.OnActionExecuting(filterContext);*/
        }
    }
}