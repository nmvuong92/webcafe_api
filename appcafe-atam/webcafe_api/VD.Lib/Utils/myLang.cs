using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;


namespace VD.Lib.Utils
{
    public static class L
    {
        public static string ls(this Dictionary<string,string> lstLang,string key)
        {
            string value = "";
            if (lstLang.TryGetValue(key, out value))
            {
               
            }
            else
            {
                value = "-";

            }
            return value;
        }
        public static string lsi(this Dictionary<string, string> lstLang, string key)
        {
            string value = "";
            if (lstLang.TryGetValue(key, out value))
            {

            }
            else
            {
                value = "-";

            }
            return HttpUtility.HtmlDecode(value);
        }
    }
    public class myLang
    {
        public static T CL<T>(T en, T vi, T cn, T jp)
        {
            string culname = CultureInfo.CurrentCulture.Name;
            if (culname == "vi-VN")
            {
                return vi;
            }
            if (culname == "zh-CN")
            {
                return cn;
            }
            if (culname == "ja-JP")
            {
                return jp;
            }
            var defaultlang = myCookies.getDefaultLang();
            if (defaultlang == "vi-VN")
            {
                return vi;
            }
            if (defaultlang == "zh-CN")
            {
                return cn;
            }
            if (defaultlang == "ja-JP")
            {
                return jp;
            }
            return en;
        }

        public static string activeClass(string curculture, string targetequals)
        {
            if (curculture == targetequals)
            {
                return "active";
            }
            return "";
        }

        public static elang getCurLang(string culname)
        {
            elang el;
            switch(culname)
            {
                case "vi-VN":
                    el = elang.vi;
                    break;
                case "zh-CN":
                    el = elang.cn;
                    break;
                case "ja-JP":
                    el = elang.jp;
                    break;
                default:
                    el = elang.en;
                    break;
            }
            return el;
        }
    }

    
    public enum elang
    {
        en,
        vi,
        cn,
        jp
    }
}
