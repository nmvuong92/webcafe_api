using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VD.Data;
using VD.Lib.DTO;
using Web.Controllers;
using Web.Security;

namespace Web.Areas.Admin.Controllers
{
    [myAuth(Roles = "1")]
    public class PhiVanChuyenController : BaseController
    {
        vuong_cms_context __db = new vuong_cms_context();
        // GET: Admin/PhiVanChuyen
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult updateGiaShipTinhThanh(int Id, int GiaShip)
        {
            rs r;
            try
            {
                var up = __db.Province.Find(Id);
                up.GiaShip = GiaShip;
                __db.Database.ExecuteSqlCommand("UPDATE District SET GiaShip=" + GiaShip + " WHERE ProvinceId="+Id);
                __db.SaveChanges();
                r = rs.T("Ok");
            }
            catch (Exception ex)
            {
                r = rs.F(ex.Message);
            }
            return Json(r, JsonRequestBehavior.DenyGet);

        }
        [HttpPost]
        public JsonResult updateGiaShipQuanHuyen(int Id, int GiaShip)
        {
            rs r;
            try
            {
                var up = __db.District.Find(Id);
                up.GiaShip = GiaShip;
                r = rs.T("Ok");
                __db.SaveChanges();
            }
            catch (Exception ex)
            {
                r = rs.F(ex.Message);
            }
            return Json(r, JsonRequestBehavior.DenyGet);

        }
        [HttpGet]
        public JsonResult loadTinhThanh()
        {
            var lst = __db.Province.Select(s => new
            {
                s.Name,
                s.Id,
                s.GiaShip
            });
            return Json(lst,JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult loadQuanHuyen(int tinh_id)
        {
            var lst = __db.District.Where(w => w.ProvinceId == tinh_id).Select(s => new
            {
                s.Name,
                s.Id,
                s.GiaShip
            });
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult loadPhuongXa(int quan_huyen_id)
        {
            var lst = __db.Ward.Where(w => w.DistrictID == quan_huyen_id).Select(s => new
            {
                s.Name,
                s.Id
            });
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
    }
}