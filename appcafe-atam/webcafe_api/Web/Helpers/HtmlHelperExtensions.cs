using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Web.Helpers
{
    public static class HtmlHelperExtensions
    {
        #region[url]
        /// <summary>
        /// create absolute action
        /// </summary>
        /// <param name="url"></param>
        /// <param name="action"></param>
        /// <param name="controller"></param>
        /// <param name="routeValues"></param>
        /// <returns></returns>
        public static string AbsoluteAction(this UrlHelper url, string action, string controller, object routeValues)
        {
            Uri requestUrl = url.RequestContext.HttpContext.Request.Url;



            string absoluteAction = string.Format("{0}{1}",

                                                 requestUrl.GetLeftPart(UriPartial.Authority),

                                               url.Action(action, controller, routeValues));

            return absoluteAction;

        }
        /// <summary>
        /// Generates a fully qualified URL to an action method by using
        /// the specified action name, controller name and route values.
        /// </summary>
        /// <param name="url">The URL helper.</param>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns>The absolute URL.</returns>
        public static string AbsoluteAction2(this UrlHelper url,
            string actionName, string controllerName, object routeValues = null)
        {
            string scheme = url.RequestContext.HttpContext.Request.Url.Scheme;

            return url.Action(actionName, controllerName, routeValues, scheme);
        }
        public static string ActionEnscriptId(this UrlHelper url, string action, string controller, object routeValues)
        {
            Uri requestUrl = url.RequestContext.HttpContext.Request.Url;

            

            string absoluteAction = string.Format("{0}{1}",

                                                 requestUrl.GetLeftPart(UriPartial.Authority),

                                               url.Action(action, controller, routeValues));

            return absoluteAction;

        }
        #endregion

        public static MvcHtmlString layAnhMacDinh(this HtmlHelper html, string anh = "", string default_img = "", bool isthumbs = false)
        {

            if (string.IsNullOrEmpty(anh))
            {
                if (default_img != "")
                {
                    return new MvcHtmlString(default_img);
                }
                return new MvcHtmlString("https://kairaweb.com/wp-content/plugins/ajax-search-pro/img/default.jpg");
            }
            else
            {
                return new MvcHtmlString(anh); ;
            }

        }
    }
}