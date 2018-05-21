using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VD.Data;
using VD.Data.Entity.MF;
using VD.Lib.DTO;
using Web.Controllers;
using Web.Security;

namespace Web.Areas.Admin.Controllers
{
    [myAuth(Roles = "1,2")]
    public class BanNewController : BaseController
    {
        vuong_cms_context __db = new vuong_cms_context();
        // GET: Admin/BanNew
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult dsban(int quanid)
        {
            var quan = __db.Quan.Find(quanid);
            var arr = new List<int>();
            if (!string.IsNullOrWhiteSpace(quan.BanArr))
            {
                try
                {
                    arr = quan.BanArr.Split(',').Select(Int32.Parse).Distinct().ToList();
                }
                catch
                {
                   
                }
            }
            return Json(arr, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult save(int quanid, string value)
        {
            rs r;
            try
            {
                List<int> arr;
                if (!string.IsNullOrWhiteSpace(value))
                {
                    try
                    {
                        arr = value.Split(',').Select(Int32.Parse).Distinct().ToList();
                        var quan = __db.Quan.Find(quanid);
                        quan.BanArr = string.Join(",", arr.Select(x => x.ToString()).ToArray());
                        __db.SaveChanges();
                        r = rs.T("Lưu thành công!");
                    }
                    catch
                    {
                        r = rs.F("Lỗi, vui lòng kiểm tra giá trị nhập tất cả số bàn ngăn cách nhau bằng dấu phẩy!!!");
                    }
                }
                else
                {
                    r = rs.F("Vui lòng nhập ít nhất 1 bàn!!!");
                }
            }
            catch (Exception ex)
            {
                r = rs.F(ex.Message);
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }
        
    }
}