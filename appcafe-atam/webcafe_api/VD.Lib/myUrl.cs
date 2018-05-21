using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace VD.Lib
{
    public static class myUrl
    {
        public static string GenerateSlug(this string phrase)
        {
            string str = phrase.RemoveAccent().ToLower();

            str = Regex.Replace(str, @"[^a-z0-9\s-]", ""); // invalid chars          
            str = Regex.Replace(str, @"\s+", " ").Trim(); // convert multiple spaces into one space  
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim(); // cut and trim it  
            str = Regex.Replace(str, @"\s", "-"); // hyphens  

            return str;
        }

        public static string ResolveServerUrl(string serverUrl, bool forceHttps)
        {
            if (serverUrl.IndexOf("://") > -1)
                return serverUrl;

            string newUrl = serverUrl;
            Uri originalUri = HttpContext.Current.Request.Url;
            newUrl = (forceHttps ? "https" : originalUri.Scheme) +
                     "://" + originalUri.Authority + newUrl;
            return newUrl;
        }

        public static string RemoveAccent(this string txt)
        {
            byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return Encoding.ASCII.GetString(bytes);
        }
        public static string BaseUrl()
        {
            var request = HttpContext.Current.Request;
            var address = String.Format("{0}://{1}/", request.Url.Scheme, request.Url.Authority);
            return address;
        }
        public static string BaseUrl2()
        {
            var request = HttpContext.Current.Request;
            var address = String.Format("{0}://{1}", request.Url.Scheme, request.Url.Authority);
            return address;
        }
        /// <summary>
        /// Get URL HTTP/HTTPS
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetSiteUrl(string value = "")
        {
            string Port = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
            if (Port == null || Port == "80" || Port == "443")
                Port = "";
            else
                Port = ":" + Port;

            string Protocol = HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
            if (Protocol == null || Protocol == "0")
                Protocol = "http://";
            else
                Protocol = "https://";

            string sOut = Protocol + HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + Port;
            return String.Format("{0}{1}", sOut, value);
        }
    }
}
