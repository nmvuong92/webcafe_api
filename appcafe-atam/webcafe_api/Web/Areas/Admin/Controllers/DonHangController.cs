using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Transactions;
using System.Web.Management;
using System.Web.Mvc;
using VD.Data;
using VD.Data.Entity.MF;
using VD.Data.IRepository;
using VD.Data.Paging;
using VD.Lib;
using VD.Lib.DTO;
using Web.Areas.Admin.ViewModels;
using Web.Controllers;
using Web.Security;
using WebGrease;

namespace Web.Areas.Admin.Controllers
{
    [myAuth]
    public class DonHangController : BaseController
    {
        private IDonHangRepository _DonHangServ;
        vuong_cms_context __db = new vuong_cms_context();
        private IImgTmpRepository _imgTmpServ;
        public DonHangController(IDonHangRepository _DonHangServ, IImgTmpRepository _imgTmpServ)
        {
            this._DonHangServ = _DonHangServ;
            this._imgTmpServ = _imgTmpServ;
        }
        public ActionResult Index()
        {
            var __auth = MySsAuthUsers.GetAuth();
            IEnumerable<SelectListItem> ddlQuan = new List<SelectListItem>();
            var user = __db.Users.Find(__auth.ID);
            if (__auth.RoleId == 1)
            {
                ddlQuan = __db.Quan.Select(s => new SelectListItem()
                {
                    Text = s.TenQuan,
                    Value = s.Id.ToString(),
                    Selected = s.Id == user.QuanDefaultId
                });

            }
            else if (__auth.IsOwner)
            {
                ddlQuan = __db.Quan.Where(w => w.UserId == __auth.ID).Select(s => new SelectListItem()
                {
                    Text = s.TenQuan,
                    Value = s.Id.ToString(),
                    Selected = s.Id == user.QuanDefaultId
                });
            }
            else
            {
                ddlQuan =
                    __db.UserQuan.Where(w => w.UserID == __auth.ID).Select(s => s.Quan).Select(s => new SelectListItem()
                    {
                        Text = s.TenQuan,
                        Value = s.Id.ToString(),
                        Selected = s.Id == user.QuanDefaultId
                    });

            }
            var vm = new DonHang();
            ViewBag.ddlQuan = ddlQuan;
            ViewBag.QuanDefaultId = user.QuanDefaultId;
            ViewBag.BaseUserId = __auth.ID;
            ViewBag.__auth = __auth;
            return View(vm);
        }

        [HttpPost]
        public PartialViewResult ajax_paging(donhang_sp paging)
        {
            var __auth = MySsAuthUsers.GetAuth();

            PG<DonHang> vmpg;
            if (__auth.RoleId == 1)
            {
                vmpg = _DonHangServ.GetQueryPaging(paging);
            }
            else
            {
                vmpg = _DonHangServ.GetQueryPaging(paging, w => w.BaseUserId == __auth.OwnerId);
            }
            ViewBag.ddlTrangThaiGiaoHang = __db.TrangThaiGiaoHang.Select(s => new SelectListItem()
            {
                Text = s.Ten,
                Value = s.Id.ToString()
            });
            ViewBag.ddlTrangThaiThanhToan = __db.TrangThaiThanhToan.Select(s => new SelectListItem()
            {
                Text = s.Ten,
                Value = s.Id.ToString()
            });
            return PartialView(vmpg);
        }

        #region [edit]
        [HttpGet]
        public JsonResult ajax_get_edit(int id, int quanid)
        {
            var en = __db.DonHangs.Find(id);
            DonHangVM dh = new DonHangVM();
            dh.TrangThaiGiaoHangId = en.TrangThaiGiaoHangId;
            dh.TrangThaiThanhToanId = en.TrangThaiThanhToanId;
            dh.GhiChuDonHang = en.GhiChuDonHang;
            dh.Ban = en.Ban;
            dh.DiaChiGiaoHang = en.DiaChiGiaoHang;
            dh.SDT = en.SDT;
            dh.YeuCauKhac = en.YeuCauKhac;

            List<ThucDonCTSLVM> lst = new List<ThucDonCTSLVM>();

            foreach (var item in en.CTDonHangs)
            {
                ThucDonCTSLVM ct = new ThucDonCTSLVM();
                ct.Id = item.ThucDonId;
                ct.GiaId = item.GiaId;
                ct.TenGia = item.TenGia;
                ct.ProductId = item.SanPhamId;
                ct.ThucDon = null;
                ct.ThucDonId = item.ThucDonId;
                ct.SoLuong = item.SoLuong;
                ct.ProductId = item.SanPhamId;
                ct.Product = new Product();
                ct.Product.Id = item.SanPhamId;
                ct.Product.Price = (int)item.DonGia;
                ct.Product.MaSo = item.SanPham.MaSo;
                ct.Product.ProductName = item.SanPham.ProductName+"<code>"+item.TenGia+"</code>";
                ct.Product.ProductCatId = item.SanPham.ProductCatId;
                ct.Product.ThumbnailImage = item.SanPham.ThumbnailImage;
                lst.Add(ct);
            }
            dh.ThucDonVMs = lst;
            dh.DSGopYJson = en.GopYs.OrderByDescending(o=>o.Id).ToList().Select(s => new GopYJson()
            {
                Id=s.Id,
                NoiDungGopY=s.NoiDungGopY,
                ThoiGian= s.CreatedDate.XuatDateTime(),
            }).ToList();
            return Json(dh, JsonRequestBehavior.AllowGet);
        }
        #endregion

        /*
      
        [HttpGet]
        public JsonResult ajax_get_ban(int quanid)
        {
            var thucdon = __db.Ban.Where(w => w.QuanId == quanid).ToList().Select(s => new Ban()
            {
                Id = s.Id,
                TenBan = s.TenBan,
                MaBan = s.MaBan
            }).ToList();
            return Json(thucdon, JsonRequestBehavior.AllowGet);
        }*/
        [HttpGet]
        public JsonResult ajax_get_thucdon(int quanid)
        {

            var thucdon = __db.ProductCat.Where(w => w.QuanId == quanid).Select(s => new ThucDonSelectVM()
            {
                Id = s.Id,
                TenThucDon = s.Name,
                Icon = s.ImageThumbnail,
            }).ToList();
            foreach (var td in thucdon)
            {
                td.ThucDonCTSelectVM = __db.Product.Where(w => w.ProductCatId == td.Id).ToList().Select(s => new ThucDonCTSelectVM()
                {
                    Id = s.Id,
                    ThucDonId = s.Id,
                    GiaId = 0,//mac dinh la 0 => chế ra danh sách giá dựa vào bảng giá lúc đó append vào danh sách giá sẽ khác 0 (Id giá)
                    
                    Product = new Product()
                    {
                        Id = s.Id,
                        ProductName = s.ProductName,
                        SoLuongGia = s.SoLuongGia,
                        Price = s.Price,
                        ThumbnailImage = s.ThumbnailImage,
                    },
                    BangGia = s.BangGiaCT.ToList().Select(bg=>new BangGiaThucDonVM()
                    {
                        Id = bg.Id,
                        Ten = bg.Ten,
                        Price = bg.Price,
                        ProductId = bg.ProductId,
                        SoLuong = 0,
                    }).ToList()
                }).ToList();
            }
            return Json(thucdon, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ajax_edit_thucdon(int quanid)
        {
            var thucdon = __db.ThucDon.Where(w => w.QuanId == quanid).ToList().Select(s => new ThucDon()
            {
                Id = s.Id,
                TenThucDon = s.TenThucDon,
                Icon = s.Icon,
            }).ToList();
            return Json(thucdon, JsonRequestBehavior.AllowGet);
        }
       

        [HttpPost]
        public JsonResult ajax_dathang(TaoDonHangVM model)
        {
            var __auth = MySsAuthUsers.GetAuth();
            rs r = rs.T("Ok");
            try
            {
                var BanArr = new List<int>();
                var quan = __db.Quan.FirstOrDefault(f => f.Id == model.QuanId);
                if (!string.IsNullOrWhiteSpace(quan.BanArr))
                {
                    try
                    {
                        BanArr = quan.BanArr.Split(',').Select(Int32.Parse).Distinct().ToList();
                    }
                    catch
                    {

                    }
                }
                /*if (!BanArr.Contains(model.Ban))
                {
                    throw new Exception("Số Bàn nhập không tồn tại trong quán " + quan.TenQuan + ", vui lòng thử lại!");
                }*/


                var __user = __db.Users.Find(__auth.ID);
                DonHang dh = new DonHang();
                dh.GhiChuDonHang = model.GhiChu;
                //dh.BanId = model.BanId != -1 ? model.BanId : null;
                dh.QuanId = model.QuanId;
                dh.TrangThaiGiaoHangId = model.TrangThaiGiaoHangId;
                dh.TrangThaiThanhToanId = model.TrangThaiThanhToanId;
                dh.HinhThucMuaHangId = model.HinhThucMuaHangId;
                dh.UserId = __auth.ID;
                dh.BaseUserId = __user.OwnerId != null ? __user.OwnerId.Value : __auth.ID;
                dh.CTDonHangs = new Collection<CTDonHang>();
                dh.TongTienHang = model.GioHang.Sum(s => s.Price * s.SoLuong);
                dh.Ban = model.Ban;


                
               
                dh.SDT = model.SDT;
                dh.YeuCauKhac = model.YeuCauKhac;
                dh.DiaChiGiaoHang = model.DiaChiGiaoHang;

                foreach (var item in model.GioHang)
                {
                    dh.CTDonHangs.Add(new CTDonHang()
                    {
                        SanPhamId = item.ProductId,
                        DonGia = item.Price,
                        ThanhTien = item.ThanhTien,
                        SoLuong = item.SoLuong,
                        ThucDonId = item.ThucDonId,
                        GiaId = item.GiaId,
                        TenGia = item.TenGia,
                    });
                }

                //save
                __db.DonHangs.Add(dh);
                __db.SaveChanges();
            }
            catch (Exception ex)
            {
                r = rs.F(ex.Message);
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }
        [HttpPost]
        public JsonResult ajax_edit_dathang(TaoDonHangVM model)
        {
        
            rs r = rs.T("Ok");
            
            using (var tx = new TransactionScope())
            {
                try
                {
                    var donhang =  __db.DonHangs.Find(model.DonHangId);
                    donhang.Ban = model.Ban;
                    donhang.GhiChuDonHang = model.GhiChu;
                    donhang.TrangThaiGiaoHangId = model.TrangThaiGiaoHangId;
                    donhang.TrangThaiThanhToanId = model.TrangThaiThanhToanId;
                    donhang.HinhThucMuaHangId = model.HinhThucMuaHangId;
                    donhang.ModifiedDate = DateTime.Now;
                    donhang.TongTienHang = model.GioHang.Sum(s => (int?)(s.Price * s.SoLuong)) ?? 0;

                    donhang.SDT = model.SDT;
                    donhang.YeuCauKhac = model.YeuCauKhac;
                    donhang.DiaChiGiaoHang = model.DiaChiGiaoHang;

                    __db.SaveChanges();
                    // Delete children
                    var itemsToDelete = __db.CTDonHangs.Where(x => x.DonHangID==model.DonHangId);
                    __db.CTDonHangs.RemoveRange(itemsToDelete);
                    __db.SaveChanges();

                    List<CTDonHang> lst = new List<CTDonHang>();
                    foreach (var item in model.GioHang)
                    {
                        lst.Add(new CTDonHang()
                        {
                            DonGia = item.Price,
                            SoLuong = item.SoLuong,
                            ThucDonId = item.ThucDonId,
                            SanPhamId=item.ProductId,
                            ThanhTien = item.ThanhTien,
                            DonHangID = model.DonHangId,
                            GiaId = item.GiaId,
                            TenGia = item.TenGia,
                        });
                    }
                    __db.CTDonHangs.AddRange(lst);
                    __db.SaveChanges();
                    r = rs.T("Cập nhật đơn hàng thành công!");
                    tx.Complete();
                }
                catch (Exception ex)
                {
                    r = rs.F("Lỗi: " + ex.Message);
                }
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }
        [HttpGet]
        public JsonResult ajax_ddl()
        {
            var TrangThaiGiaoHang = __db.TrangThaiGiaoHang.ToList().Select(s => new TrangThaiGiaoHang()
            {
                Ten = s.Ten,
                Id = s.Id,
            });
            var TrangThaiThanhToan = __db.TrangThaiThanhToan.ToList().Select(s => new TrangThaiThanhToan()
            {
                Ten = s.Ten,
                Id = s.Id,
            });
            var ddlHinhThucMuaHang = __db.HinhThucMuaHang.ToList().Select(s => new SelectListItem()
            {
                Value = s.Id.ToString(),
                Text = s.Ten,
            }).ToList();
            return Json(new
            {
                TrangThaiGiaoHang,
                TrangThaiThanhToan,
                ddlHinhThucMuaHang
            }, JsonRequestBehavior.AllowGet);
        }





        // GET: Admin/DonHangs/Edit/5
        public ActionResult Edit(int id)
        {
            DonHang entity = _DonHangServ.GetEntry(id);

            DonHangCRUD vm = new DonHangCRUD();
            vm.entity = entity;
            vm.Id = entity.Id;
            vm.TrangThaiGiaoHangId = entity.TrangThaiGiaoHangId;
            vm.TrangThaiThanhToanId = entity.TrangThaiThanhToanId;

            vm.GhiChuDonHang = entity.GhiChuDonHang;
            vm.ddlTrangThaiGiaoHang = __db.TrangThaiGiaoHang.Select(s => new SelectListItem()
            {
                Text = s.Ten,
                Value = s.Id.ToString(),
            }).ToList();

            vm.ddlTrangThaiThanhToan = __db.TrangThaiThanhToan.Select(s => new SelectListItem()
            {
                Text = s.Ten,
                Value = s.Id.ToString(),
            }).ToList();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public JsonResult Edit(DonHangCRUD model)
        {
            rs r;
            using (var trans = new TransactionScope())
            {
                try
                {
                    var entity = _DonHangServ.SingleOrDefault(s => s.Id == model.Id);
                    entity.TrangThaiGiaoHangId = model.TrangThaiGiaoHangId;
                    entity.TrangThaiThanhToanId = model.TrangThaiThanhToanId;
                    entity.ModifiedDate = DateTime.Now;
                    entity.GhiChuDonHang = model.GhiChuDonHang;
                    _DonHangServ.Save();

                    int diemtichluy = __db.DonHangs.Where(w => w.UserId == entity.UserId && w.TrangThaiThanhToanId == 2).Sum(s => (int?)s.TongTienHang) ?? 0;
                    var user = __db.Users.Find(entity.UserId);
                    __db.SaveChanges();

                    trans.Complete();
                    r = rs.T("Okay");
                }
                catch (Exception ex)
                {
                    r = rs.F("Lỗi: " + ex.Message);
                }
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            rs r;
            try
            {
                DonHang DonHang = _DonHangServ.GetEntry(id);

                _DonHangServ.Delete(DonHang);
                _DonHangServ.Save();

                r = rs.T("Ok");
            }
            catch (Exception ex)
            {
                r = rs.F("Lỗi: " + ex.Message);

            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }
        /*[HttpPost]
        public ActionResult DanhDauXemGopY(int id)
        {
            rs r;
            try
            {
                DonHang DonHang = __db.DonHangs.Find(id);
                DonHang.DaXemGopY = true;
                DonHang.ThoiGianXemGopY = DateTime.Now;
                __db.SaveChanges();
                r = rs.T("Ok");
            }
            catch (Exception ex)
            {
                r = rs.F("Lỗi: " + ex.Message);

            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }*/

        [HttpPost]
        public ActionResult ThayDoiTrangThaiThanhToan(int id, int idtrangthai)
        {
            rs r;
            try
            {
                DonHang DonHang = __db.DonHangs.Find(id);
                DonHang.TrangThaiThanhToanId = idtrangthai;
                DonHang.ModifiedDate = DateTime.Now;
                __db.SaveChanges();
                if (idtrangthai == 2)
                {
                    OneSignalAPI.SendMsgToUser("Đơn hàng: TH" + DonHang.Id, "Tính tiền thành công!", DonHang.UniqueID);
                }
                else if (idtrangthai == 3)
                {
                    OneSignalAPI.SendMsgToUser("Đơn hàng: TH" + DonHang.Id, "Đã hủy!", DonHang.UniqueID);
                }
               
                r = rs.T("Ok");
            }
            catch (Exception ex)
            {
                r = rs.F("Lỗi: " + ex.Message);

            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }
        [HttpPost]
        public ActionResult ThayDoiTrangThaiGiaoHang(int id, int idtrangthai)
        {
            rs r;
            try
            {
                DonHang DonHang = __db.DonHangs.Find(id);
                DonHang.TrangThaiGiaoHangId = idtrangthai;
                DonHang.ModifiedDate = DateTime.Now;
                __db.SaveChanges();
                if (idtrangthai == 2)
                {
                    OneSignalAPI.SendMsgToUser("Đơn hàng: TH" + DonHang.Id, "Đã giao!", DonHang.UniqueID);
                }
                r = rs.T("Ok");
            }
            catch (Exception ex)
            {
                r = rs.F("Lỗi: " + ex.Message);

            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }
        [HttpPost]
        public JsonResult xoachon(int[] arr)
        {
            rs r;
            var __auth = MySsAuthUsers.GetAuth();
            if (!__auth.IsOwner)
            {
                r = rs.F("Bạn không có quyền xóa, liên hệ chủ quán!");
            }
            else
            {
                if (arr.Length == 0)
                {
                    r = rs.F("Không có mục nào chọn");
                }
                else
                {
                    using (var trans = new TransactionScope())
                    {
                        try
                        {
                            foreach (int idmess in arr)
                            {
                                __db.Database.ExecuteSqlCommand("DELETE FROM DonHangs WHERE Id=" + idmess);
                            }
                            r = rs.T("OK");
                            trans.Complete();
                        }
                        catch (Exception ex)
                        {
                            r = rs.F(ex.Message);
                        }
                    }

                }
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }

        public ActionResult Print(int id)
        {
            var dh = __db.DonHangs.Find(id);
            return View(dh);
        }


        [HttpPost]
        public JsonResult toggleHetHang(int id)
        {
            rs r;
            try
            {
                using (var __db = new vuong_cms_context())
                {
                    var en = __db.CTDonHangs.Find(id);
                    __db.SaveChanges();
                    r = rs.T("Cập nhật thành công!");
                }
            }
            catch (Exception ex)
            {
                r = rs.F(ex.Message);
                throw;
            }
            return Json(r, JsonRequestBehavior.DenyGet);

        }


        [HttpPost]
        public JsonResult editSLSP(int ctid, int sl)
        {
            rs r;

            using (var __db = new vuong_cms_context())
            {
                using (var tx = new TransactionScope())
                {
                    try
                    {
                        var en = __db.CTDonHangs.Find(ctid);
                        en.SoLuong = sl;
                        en.ThanhTien = en.DonGia * en.SoLuong;
                        __db.SaveChanges();

                        var parent = __db.DonHangs.Find(en.DonHangID);
                        parent.TongTienHang = parent.CTDonHangs.Sum(s => s.DonGia * s.SoLuong);
                        __db.SaveChanges();
                        tx.Complete();

                        r = rs.T("Cập nhật thành công!", new
                        {
                            TongTien = parent.TongTienHang.ToMoneyStr(),
                            ThanhTien = en.ThanhTien.ToMoneyStr(),
                        });
                    }
                    catch (Exception ex)
                    {
                        r = rs.F(ex.Message);
                    }
                }
            }

            return Json(r, JsonRequestBehavior.DenyGet);

        }
    }

}
