using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace VD.Lib
{
    public static class ExtensionMethods
    {
        public static bool HasFile(this HttpPostedFileBase file)
        {
            return file != null && file.ContentLength > 0;
        }
    }
}
