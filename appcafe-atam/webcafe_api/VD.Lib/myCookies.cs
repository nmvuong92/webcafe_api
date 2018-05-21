
using System;
using System.Web;
using VD.Lib.DTO;
using VD.Lib.Encode;

namespace VD.Lib
{

    /// <summary>
    /// Xử lý Cookies
    /// </summary>
    public class myCookies
    {
        public static SimpleAES aes = new SimpleAES();

        /// <summary>
        /// Gán giá trị cookies
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">giá trị</param>
        /// <param name="dateExp">thời gian sống</param>
        public static void Set(string key, string value, DateTime dateExp)
        {
            try
            {
                HttpCookie cookies = new HttpCookie(key);
                cookies.Value = value;
                cookies.Expires = dateExp;
                HttpContext.Current.Response.Cookies.Add(cookies);
            }
            catch
            {
                throw;
            }
        }

      
        public static void SetAESEncryptToString(string key, string value, DateTime dateExp)
        {
            try
            {
                HttpCookie cookies = new HttpCookie(key);
                cookies.Value = aes.EncryptToString(value);
                cookies.Expires = dateExp;
                HttpContext.Current.Response.Cookies.Add(cookies);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Lấy giá trị cookies
        /// </summary>
        /// <param name="key">key</param>
        /// <returns></returns>
        public static string Get(string key)
        {
            try
            {
                return HttpContext.Current.Request.Cookies[key].Value;
            }
            catch
            {
                return string.Empty;
            }
        }
        public static int? GetInt(string key)
        {
            try
            {
                return int.Parse(HttpContext.Current.Request.Cookies[key].Value);
            }
            catch
            {
                return null;
            }
        }
        public static string GetLang()
        {
            try
            {
                var lang =  HttpContext.Current.Request.Cookies[SysConsts.COOKIE_CURRENT_LANG_CUL].Value;
                if (lang != "vi-VN" && lang != "en-US")
                {
                    lang = "vi-VN"; //en
                }
                myCookies.Set(SysConsts.COOKIE_CURRENT_LANG_CUL, lang, DateTime.Now.AddYears(1));
                return lang;
            }
            catch
            {
                return string.Empty;
            }
        }
        public static int GetLangKey()
        {
            string culture = GetLang();
            int __langid;
            switch (culture)
            {
                case "vi-VN":
                    __langid = 2;
                    break;
                default:
                    __langid = 1; //en-us
                    break;
            }
            return __langid;
        }
        public static string SetLang(string _culture)
        {
            try
            {
              
                if (_culture != "vi-VN" && _culture != "en-US")
                {
                    _culture = "vi-VN";
                }
                myCookies.Set(SysConsts.COOKIE_CURRENT_LANG_CUL, _culture, DateTime.Now.AddYears(1));
                return _culture;
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string GetAESDecryptString(string key)
        {
            try
            {
                return aes.DecryptString(HttpContext.Current.Request.Cookies[key].Value);
            }
            catch
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// Xóa cookies
        /// </summary>
        /// <param name="key">key</param>
        public static void Clear(string key, DateTime set_expires)
        {
            try
            {
                HttpCookie cookies = new HttpCookie(key);
                cookies.Value = null;
                cookies.Expires = set_expires;
                HttpContext.Current.Response.Cookies.Add(cookies);
            }
            catch
            {
                throw;
            }
        }

        public static void Clear(string key)
        {
            try
            {
                HttpCookie cookies = new HttpCookie(key);
                cookies.Value = null;
                cookies.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookies);
            }
            catch
            {
                throw;
            }
        }
        public static string GetCurrentCulture()
        {
            return myCookies.Get(SysConsts.COOKIE_CURRENT_LANG_CUL);
        }
        public static void setDefaultLang(string value)
        {
            myCookies.Set(SysConsts.COOKIE_DEFAULT_LANG, value, DateTime.Now.AddMonths(1));
        }
        public static string getDefaultLang()
        {
            return myCookies.Get(SysConsts.COOKIE_DEFAULT_LANG);
        }
        public static bool isVN()
        {
            return myCookies.Get(SysConsts.COOKIE_CURRENT_LANG_CUL) == SysConsts.CUL_LANG_VI_VN;
        }
        public static bool isCN()
        {
            return myCookies.Get(SysConsts.COOKIE_CURRENT_LANG_CUL) == SysConsts.CUL_LANG_ZH_CN;
        }
        public static bool isUS()
        {
            return myCookies.Get(SysConsts.COOKIE_CURRENT_LANG_CUL) == SysConsts.CUL_LANG_EN_US;
        }

        public static void clear_all_cookies_domain()
        {
            string[] myCookies = HttpContext.Current.Response.Cookies.AllKeys;
            foreach (string cookie in myCookies)
            {
                HttpContext.Current.Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
        }
    }
}
