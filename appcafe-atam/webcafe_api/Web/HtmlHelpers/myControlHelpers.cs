
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.HtmlHelpers
{
    public static class myControlHelpers
    {
        
            public static MvcHtmlString myUploadImg(this HtmlHelper htmlHelper, string name)
            {
                String rs = "";

                return MvcHtmlString.Create(rs);
            }
       
    }
}