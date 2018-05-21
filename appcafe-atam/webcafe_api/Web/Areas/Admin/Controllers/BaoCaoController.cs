using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Transactions;
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

namespace Web.Areas.Admin.Controllers
{
    [myAuth]
    public class BaoCaoController : BaseController
    {
        private IDonHangRepository _DonHangServ;
        vuong_cms_context __db = new vuong_cms_context();
        private IImgTmpRepository _imgTmpServ;
        public BaoCaoController(IDonHangRepository _DonHangServ, IImgTmpRepository _imgTmpServ)
        {
            this._DonHangServ = _DonHangServ;
            this._imgTmpServ = _imgTmpServ;
        }


        public ActionResult Index()
        {
            var __auth = MySsAuthUsers.GetAuth();
            IEnumerable<SelectListItem> ddlQuan = new List<SelectListItem>();
            var user = __db.Users.Find(__auth.ID);
            if (__auth.IsOwner)
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
            return View(vm);
        }

        [HttpPost]
        public PartialViewResult ajax_paging(donhang_sp paging)
        {
            var __auth = MySsAuthUsers.GetAuth();
            paging.trangthaigiaohangid = -1;
            paging.trangthaithanhtoanid = 2;
            PG<DonHang> vmpg;
            vmpg = _DonHangServ.GetQueryPaging(paging,w=>w.BaseUserId==__auth.OwnerId);
            return PartialView(vmpg);
        }

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
            var thucdon = __db.ThucDon.Where(w => w.QuanId == quanid).ToList().Select(s => new ThucDon()
            {
                Id = s.Id,
                TenThucDon = s.TenThucDon,
                Icon = s.Icon,
            }).ToList();
            return Json(thucdon, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ajax_get_thucdonct(int thucdonid)
        {
            var thucdon = __db.ThucDonCT.Where(w => w.ThucDonId == thucdonid).ToList().Select(s => new ThucDonCT()
            {
                Id = s.Id,
                ThucDonId = s.ThucDonId,
                Product = new Product()
                {
                   Id=s.Product.Id,
                   ProductName = s.Product.ProductName,
                   Price = s.Product.Price,
                   ThumbnailImage = s.Product.ThumbnailImage,
                }
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
                var __user=__db.Users.Find(__auth.ID);
                DonHang dh = new DonHang();
                dh.GhiChuDonHang = model.GhiChu;
                //dh.BanId = model.BanId != -1 ? model.BanId : null;
                dh.QuanId = model.QuanId;
                dh.TrangThaiGiaoHangId = model.TrangThaiGiaoHangId;
                dh.TrangThaiThanhToanId = model.TrangThaiThanhToanId;
                dh.UserId = __auth.ID;
                dh.BaseUserId = __user.OwnerId!=null?__user.OwnerId.Value:__auth.ID;
                dh.CTDonHangs = new Collection<CTDonHang>();
                dh.TongTienHang = model.GioHang.Sum(s => s.Price*s.SoLuong);

                dh.Ban = model.Ban;

                foreach (var item in model.GioHang)
                {
                    dh.CTDonHangs.Add(new CTDonHang()
                    {
                        SanPhamId = item.ProductId,
                        DonGia = item.Price,
                        ThanhTien = item.ThanhTien,
                        SoLuong = item.SoLuong,
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
            return Json(new
            {
                TrangThaiGiaoHang,
                TrangThaiThanhToan
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


        [HttpPost]
        public JsonResult xoachon(int[] arr)
        {
            rs r;
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
