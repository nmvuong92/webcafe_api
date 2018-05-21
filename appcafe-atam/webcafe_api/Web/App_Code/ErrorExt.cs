

using System.Collections.Generic;
using System.Web.Mvc;


namespace Web
{
    public static class ErrorExt
    {
        public static string ToErrorListStr(this ModelStateDictionary value)
        {
            string err = "<ul>";
            foreach (ModelState modelState in value.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    err += "<li>" + error.ErrorMessage+ "</li>";
                }
            }
            err += "</ul>";
            return err;
        }
    }
}