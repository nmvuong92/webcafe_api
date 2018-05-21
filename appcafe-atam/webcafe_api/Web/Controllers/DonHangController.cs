using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using System.Web.Util;
using VD.Data;
using VD.Data.Entity.MF;
using VD.Data.IRepository;
using VD.Lib;
using VD.Lib.DTO;
using Web.ViewModels;

namespace Web.Controllers
{
    public class DonHangController : BaseController
    {
        private IContactRepository _contactRepo;

        public DonHangController(IContactRepository _contactRepo)
        {
            this._contactRepo = _contactRepo;
        }
        // GET: DatHang

        public ActionResult TestUrl()
        {
            return Content(myUrl.ResolveServerUrl("/abc.jpg", false));
        }
        public ActionResult Index(string back_url="")
        {
            ViewBag.back_url = back_url;
            ThanhToanVM vm = new ThanhToanVM();
            using (var __db = new vuong_cms_context())
            {
        

                 //user
                var uuu = MySsAuthUsers.GetAuth();


                if (uuu != null)
                {
                    var user = __db.Users.Find(uuu.ID);
                    vm.DiaChiGiaohang = user.Address;
                }
            }

            return View(vm);
        }

        [HttpGet]
        public JsonResult LayGioHang()
        {
            var model = GioHang.Lay();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DatHang(int MaSanPham, int SoLuong,string back_url="")
        {
            return RedirectToAction("Index",new{back_url});
        }

        [HttpGet]
        public JsonResult LayGiaShip(int district_id)
        {
            int gia_ship =0;
            using (var __db = new vuong_cms_context())
            {
                gia_ship = __db.District.Find(district_id).GiaShip;
            }
            return Json(gia_ship, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Index(ThanhToanVM model)
        {
            var giohang = GioHang.Lay();
            if (!giohang.CTGioHangs.Any())
            {
                ModelState.AddModelError(string.Empty, "Giỏ hàng rỗng");
            }
            var uuu = MySsAuthUsers.GetAuth();
            if (uuu == null)
            {
                ModelState.AddModelError(string.Empty, "Vui lòng đăng nhập");
            }
            bool status = false;
            using (var __db = new vuong_cms_context())
            {
                if (ModelState.IsValid)
                {

                    using (var tx = __db.Database.BeginTransaction())
                    {
                        try
                        {
                           
                            //donhang
                            DonHang donhang = new DonHang();
                            donhang.TongTienHang = giohang.TongTienHang;
                            donhang.TrangThaiGiaoHangId = 1;
                            donhang.TrangThaiThanhToanId = 1;

                            //ctdh
                            donhang.CTDonHangs = new Collection<CTDonHang>();
                            foreach (var gio in giohang.CTGioHangs)
                            {
                                donhang.CTDonHangs.Add(new CTDonHang()
                                {
                                    SanPhamId = gio.SanPhamId,
                                    SoLuong = gio.SoLuong,
                                    ThanhTien = gio.ThanhTien,
                                    DonGia = gio.DonGia,
                                });
                            }
                            //user
                           
                            if (uuu != null)
                            {
                                donhang.UserId = uuu.ID;
                            }
                            
                            __db.DonHangs.Add(donhang);
                            __db.SaveChanges();


                            
                            //com
                            tx.Commit();
                            
                            

                        }
                        catch (Exception ex)
                        {
                            tx.Rollback();
                        }

                    }
                }
            }
            return View(model);
        }
      
        public static Random rd;
        [HttpPost]
        public ActionResult ThemSanPham(ThemSanPhamGioHangVM vm)
        {
            rd = new Random();

            try
            {
                vuong_cms_context __db = new vuong_cms_context();
                var sanpham = __db.Product.Find(vm.SanPhamId);

                CTGioHang ct = new CTGioHang();
                ct.SanPhamId = vm.SanPhamId;
                ct.TenSanPham = sanpham.ProductName;
                ct.HinhAnh = sanpham.ThumbnailImage;
                ct.SoLuong = vm.SoLuong;
                ct.Link = Url.Action("Detail", "SanPham", new { id = sanpham.Id, seo_title = sanpham.ProductName.URLFriendly() });
                GioHang.ThemSanPham(ct);

            }
            catch (Exception ex)
            {
                return Content("Lỗi: " + ex.Message);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult Xoa(int id)
        {
            rs r;
            try
            {

                GioHang.XoaSP(id);
                r = rs.T("Ok");
            }
            catch (Exception ex)
            {
                r = rs.F(ex.Message);
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }
        [HttpPost]
        public JsonResult CapNhatSoLuong(int id, int sl)
        {
            rs r;
            try
            {

                GioHang.CapNhatSL(id, sl);
                r = rs.T("Ok");
            }
            catch (Exception ex)
            {
                r = rs.F(ex.Message);
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }

        [HttpGet]
        public JsonResult ddlDistrict(int province_id)
        {
            vuong_cms_context __db = new vuong_cms_context();
            var obj = __db.District.Where(w => w.ProvinceId == province_id).Select(s => new
            {
                s.ProvinceId,
                s.Id,
                s.Name
            });
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ddlWard(int district_id)
        {
            vuong_cms_context __db = new vuong_cms_context();
            var obj = __db.Ward.Where(w => w.DistrictID == district_id).Select(s => new
            {
                s.DistrictID,
                s.Id,
                s.Name
            });
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}