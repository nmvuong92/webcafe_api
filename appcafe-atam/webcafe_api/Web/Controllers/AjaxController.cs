
using System;
using System.Web.Mvc;
using VD.Data;
using VD.Lib;
using VD.Lib.DTO;

namespace Web.Controllers
{
    public class AjaxController : BaseController
    {
        public AjaxController()
        {
            
        }
        public JsonResult Config()
        {

            return Json(__config, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckUserLogin()
        {
            var au = MySsAuthUsers.GetAuth();
            rs r;
            if (au != null && au.RoleId == 2)
            {
                r = rs.T("Ok");
            }
            else
            {
                r = rs.F("Vui lòng đăng nhập tài khoản người dùng!");
            }
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult toggleAppMenu()
        {
            var cur = myCookies.Get("app-menu");
            if (cur == string.Empty)
            {
                cur = "show";
            }
            else
            {
                if(cur== "show")
                {
                    cur = "hide";
                }
                else
                {
                    cur = "show";
                }
            }
            myCookies.Set("app-menu", cur, DateTime.Now.AddYears(1));

            return Json(cur, JsonRequestBehavior.AllowGet);
        }
    }
}