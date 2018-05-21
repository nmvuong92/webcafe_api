using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Web;

namespace Web
{
    public class MuiSysAttribute : DisplayNameAttribute
    {
        public MuiSysAttribute(string resourceId)
            : base(GetMessageFromResource(resourceId))
        { }

        private static string GetMessageFromResource(string resourceId)
        {
            // TODO: Return the string from the resource file
            return mui_sys.mui_sys.ResourceManager.GetString(resourceId);
        }
    }
}