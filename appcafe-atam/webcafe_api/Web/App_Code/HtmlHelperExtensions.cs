using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.WebPages;
using System.Linq;


public static class HtmlHelperExtensions
{
    public static MvcHtmlString myBreadCrumbs(this HtmlHelper htmlHelper,
        List<MvcHtmlString> lstUrl,
        string currentText="",
        string currentText2="")
    {
        var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);


        string _html = "<ol class='breadcrumb'>";
            _html += "<li><a href='"+urlHelper.Action("Index","Home")+"'>Home</a></li>";
        if (lstUrl != null &&lstUrl.Any())
        {
            foreach (var lia in lstUrl)
            {
                _html += "<li>" + lia.ToHtmlString() + "</li>";
            }
        }
       
        if (!string.IsNullOrWhiteSpace(currentText))
        {
            _html += "<li>" + currentText + "</li>";
        }

        if (!string.IsNullOrWhiteSpace(currentText2))
        {
            _html += "<li>" + currentText2 + "</li>";
        }
        _html += "</ol>";
        return MvcHtmlString.Create(_html);
    }
  
    public static string IsSelected(this HtmlHelper html, string controllers = "", string actions = "", string cssClass = "selected")
    {
        ViewContext viewContext = html.ViewContext;
        bool isChildAction = viewContext.Controller.ControllerContext.IsChildAction;

        if (isChildAction)
            viewContext = html.ViewContext.ParentActionViewContext;

        RouteValueDictionary routeValues = viewContext.RouteData.Values;
        string currentAction = routeValues["action"].ToString();
        string currentController = routeValues["controller"].ToString();

        if (String.IsNullOrEmpty(actions))
            actions = currentAction;

        if (String.IsNullOrEmpty(controllers))
            controllers = currentController;

        string[] acceptedActions = actions.Trim().Split(',').Distinct().ToArray();
        string[] acceptedControllers = controllers.Trim().Split(',').Distinct().ToArray();

        return acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController) ?
            cssClass : String.Empty;
    }

    public static MvcHtmlString Script(this HtmlHelper htmlHelper, Func<object, HelperResult> template)
    {
        htmlHelper.ViewContext.HttpContext.Items["_script_" + Guid.NewGuid()] = template;
        return MvcHtmlString.Empty;
    }

    public static IHtmlString RenderScripts(this HtmlHelper htmlHelper)
    {
        foreach (object key in htmlHelper.ViewContext.HttpContext.Items.Keys)
        {
            if (key.ToString().StartsWith("_script_"))
            {
                var template = htmlHelper.ViewContext.HttpContext.Items[key] as Func<object, HelperResult>;
                if (template != null)
                {
                    htmlHelper.ViewContext.Writer.Write(template(null));
                }
            }
        }
        return MvcHtmlString.Empty;
    }
    public static HtmlString RenderImg(this HtmlHelper helper, string url)
    {

        string rs = "<p style='line-height: 68px;'>Not found</p>";
        if (!String.IsNullOrEmpty(url))
        {
            rs = "<img src='" + url + "' style='width:100px;' />";
        }

        return MvcHtmlString.Create(rs);

    }
    public static string AbsoluteAction(this UrlHelper url, string action, string controller, string _area = "")
    {
        Uri requestUrl = url.RequestContext.HttpContext.Request.Url;

        string absoluteAction = string.Format("{0}://{1}{2}",
                                              requestUrl.Scheme,
                                              requestUrl.Authority,
                                              url.Action(action, controller, new { area = _area }));

        return absoluteAction;
    }

    public static MvcHtmlString MyTextBoxFor<TModel, TProperty>(
    this HtmlHelper<TModel> helper,
    Expression<Func<TModel, TProperty>> expression)
    {
        string rs = "<div class='img-ck'>";

        rs += "</div>";
        return helper.TextBoxFor(expression, new { @class = "txt" });
    }


}

/*
 @Html.Script(
    @<script src="@Url.Content("~/Scripts/jquery-1.4.4.min.js")" type="text/javascript"></script>
)
 
 */


