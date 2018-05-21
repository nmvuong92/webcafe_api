using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Web.App_Code
{
    public static class vHelper
    {
        public static string LabelRequired(string target, string text)
        {
            return String.Format("<label for='{0}'>{1}</label>", target, text);
        }
        public static MvcHtmlString RequiredLabelFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes, bool isrequired = false, string first_html = "")
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metaData.DisplayName ?? metaData.PropertyName ?? htmlFieldName.Split('.').Last();

            if (metaData.IsRequired || isrequired)
                labelText += "<span class=\"required\">*</span>";

            if (String.IsNullOrEmpty(labelText))
                return MvcHtmlString.Empty;

            var label = new TagBuilder("label");
            label.Attributes.Add("for", helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));

            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(htmlAttributes))
            {
                label.MergeAttribute(prop.Name.Replace('_', '-'), prop.GetValue(htmlAttributes).ToString(), true);
            }

            label.InnerHtml = first_html + labelText;
            return MvcHtmlString.Create(label.ToString());
        }
    }
}