using System.Web.Mvc;
using VD.Lib.DTO;
namespace Web.Controllers{
    public class ErrorController : BaseController
    {
        public JsonResult AccessDenied()
        {
            return Json(rs.F("Bạn không có quyền thực hiện chức năng này"),JsonRequestBehavior.AllowGet);
        }

        public ActionResult Page404()
        {
            return View();
        }
        public ContentResult Page400()
        {
            return Content("400 BAD request");
        }
        public ActionResult Page401(bool isAjax)
        {
            if (isAjax)
            {
                return Json(rs.F("401 status"), JsonRequestBehavior.AllowGet);
            }
            MesDto vm = new MesDto();
            vm.Code = 401;
            vm.Message = "401 Unauthorized Explained";
            vm.Message2 = "Chưa được cấp quyền cho chức năng này, vui lòng đăng nhập!";
            return View("Error", vm);
            
        }
        public ActionResult Custom()
        {
            return View();
        }
        public ContentResult Page403()
        {
            return Content("403 Forbidden Explained ");
        }
        public ContentResult Page500()
        {
            return Content("500 Internal server error Explained");
        }
        public ContentResult Page503()
        {
            return Content("503 Service unavailable Explained");
        }
    }
}