using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using Ninject.Web.WebApi;
using OfficeOpenXml.FormulaParsing.Excel.Functions;
using VD.Data;
using VD.Data.Entity.MF;
using VD.Lib.DTO;
using Web.Areas.Admin.ViewModels;
using Web.Controllers;
using Web.Security;

namespace Web.Areas.Admin.Controllers
{
    [myAuth(Roles = "1,2")]
    public class ThucDonController : BaseController
    {
        vuong_cms_context __db = new vuong_cms_context();
        // GET: Admin/ThucDon
        public ActionResult Index()
        {
            return View();
        }

        //lấy ds thực đơn
        
        public JsonResult ajax_get_thucdon(int quan_id)
        {
            var __auth = MySsAuthUsers.GetAuth();
            List<ThucDonVM> vm = new List<ThucDonVM>();
            var rs = __db.ThucDon.Where(w => w.Quan.UserId == __auth.ID && w.QuanId == quan_id).Select(s => new ThucDonVM()
            {
                Id = s.Id,
                TenThucDon = s.TenThucDon,
                Icon = s.Icon,
                QuanId = s.QuanId,
            });
            return Json(rs,JsonRequestBehavior.AllowGet);
        }

        //lấy quán
        public JsonResult ajax_get_quan()
        {
            var __auth = MySsAuthUsers.GetAuth();
            var rs = __db.Quan.Where(w => w.UserId == __auth.ID).ToList().Select(s=>new Quan
            {
                TenQuan = s.TenQuan,
                Id = s.Id,
                ImageThumbnail = s.ImageThumbnail,
            }).ToList();
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        //tạo thực đơn

        [HttpPost]
        public JsonResult ajax_create_thuc_don(ThucDonVM thucdon)
        {
            rs r;
            try
            {
                ThucDon td = new ThucDon();
                td.TenThucDon = thucdon.TenThucDon;
                td.QuanId = thucdon.QuanId;
                td.Icon = thucdon.Icon;
                __db.ThucDon.Add(td);
                __db.SaveChanges();
                thucdon.Id = td.Id;
                r = rs.T("Ok", thucdon);
            }
            catch (Exception ex)
            {
                r = rs.F("Lỗi: " + ex.Message);
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }

        //lấy ds thực đơn chi tiết của thực đơn
        public JsonResult ajax_get_thucdonct(int ThucDonId)
        {
          
            var rs = __db.ThucDonCT.Where(w => w.ThucDonId == ThucDonId).Select(s => new ThucDonCTVM()
            {
                TenSanPham = s.Product.ProductName,
                HinhAnh = s.Product.ThumbnailImage,
                SanPhamId = s.ProductId,
                ThucDonId=s.ThucDonId,
                Id=s.Id,
                Gia=s.Product.Price,
            });
            return Json(rs, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ajax_get_dssp(int QuanId)
        {
            var __auth = MySsAuthUsers.GetAuth();
            var rs = __db.Product.Where(w => w.ProductCat.Quan.UserId==__auth.ID).ToList().Select(s => new Product()
            {
                Id = s.Id,
                ProductName = s.ProductName,
                ThumbnailImage = s.ThumbnailImage,
                Price = s.Price,
            });
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ajax_pick_sanpham_vao_thucdon(int ProductId, int ThucDonId)
        {
            rs r;
            try
            {
                if (__db.ThucDonCT.Any(a => a.ThucDonId == ThucDonId && a.ProductId == ProductId))
                {
                    throw new Exception("Sản phẩm đã tồn tại trong thực đơn");
                }
                ThucDonCT ct = new ThucDonCT();
                ct.ThucDonId = ThucDonId;
                ct.ProductId = ProductId;
                __db.ThucDonCT.Add(ct);
                __db.SaveChanges();

                var s = __db.ThucDonCT.Include(i=>i.Product).FirstOrDefault(f=>f.Id==ct.Id);
                var v = new ThucDonCTVM()
                {
                    TenSanPham = s.Product.ProductName,
                    HinhAnh = s.Product.ThumbnailImage,
                    SanPhamId = s.ProductId,
                    ThucDonId = s.ThucDonId,
                    Id=s.Id,
                };
                r = rs.T("Ok", v);
            }
            catch (Exception ex)
            {
                r = rs.F("Lỗi: " + ex.Message);
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult ajax_remove_sp(int ThucDonCTId)
        {
            rs r;
            try
            {
                var entity = __db.ThucDonCT.Find(ThucDonCTId);
                __db.ThucDonCT.Remove(entity);
                __db.SaveChanges();
                r = rs.T("Ok");
            }
            catch (Exception ex)
            {
                r = rs.F("Lỗi: " + ex.Message);
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult ajax_remove_thucdon(int id)
        {
            rs r;
            try
            {
                var entity = __db.ThucDon.Find(id);
                __db.ThucDon.Remove(entity);
                __db.SaveChanges();
                r = rs.T("Ok");
            }
            catch (Exception ex)
            {
                r = rs.F("Lỗi: " + ex.Message);
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }
          [HttpPost]
        public JsonResult ajax_sua_thucdon(ThucDonVM data)
        {
            rs r;
            try
            {
                var entity = __db.ThucDon.Find(data.Id);
                entity.TenThucDon = data.TenThucDon;
                entity.Icon = data.Icon;
                __db.SaveChanges();
                r = rs.T("Ok");
            }
            catch (Exception ex)
            {
                r = rs.F("Lỗi: " + ex.Message);
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }
        

    }
}