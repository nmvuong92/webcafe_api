using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using VD.Data;
using VD.Data.Entity.MF;
using VD.Lib.DTO;
using Web.Models.ThuanHanhMobileApp;
using Web.Models.ThuanHanhMobileApp.Post;
using Web.Models.ThuanHanhMobileApp.VM;

namespace Web.Apis
{
    public class DonHangController : ApiController
    {
        [HttpGet]
        [AcceptVerbs("OPTIONS")]
        public string test()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<UsersOnLine>();
            context.Clients.All.notify_new_donhang(-1, "HELLLO");
            return "ya";
        }
        [HttpGet]
        [AcceptVerbs("OPTIONS")]
        public ListPagingJson<DonHangVM> layds(int userid, string token, int page, int pageSize)
        {
            vuong_cms_context __db = new vuong_cms_context();
            //initial
            var paging = new ListPagingJson<DonHangVM>();
            paging.Paging.RecordsPerPage = pageSize;
            paging.Paging.CurrentPage = page;
            //calculator
            var query = __db.DonHangs.Where(w => w.UserId == userid);
            paging.Number1 = query.Count(c => c.TrangThaiThanhToanId == 1);
            paging.Paging.TotalRecords = query.Count();
            paging.List = DonHangVM.map(query.OrderByDescending(o => o.Id).Skip((page - 1) * pageSize).Take(pageSize));
            return paging;
        }
        [HttpGet]
        [AcceptVerbs("OPTIONS")]
        public ListPagingJson<DonHangVM> laydsdevice(string uniqueID, int trangthaithanhtoanid,int page, int pageSize)
        {
            //initial
            var paging = new ListPagingJson<DonHangVM>();
            paging.Paging.RecordsPerPage = pageSize;
            paging.Paging.CurrentPage = page;

            vuong_cms_context __db = new vuong_cms_context();

            //calculator
            var query = __db.DonHangs.Where(w => w.UniqueID == uniqueID);
            paging.Number1 = query.Count(c => c.TrangThaiThanhToanId == 1);
            if (trangthaithanhtoanid != -1)
            {
                query = query.Where(w => w.TrangThaiThanhToanId == trangthaithanhtoanid);
            }
            paging.Paging.TotalRecords = query.Count();
            paging.List = DonHangVM.map(query.OrderByDescending(o => o.Id).Skip((page - 1) * pageSize).Take(pageSize));
            //so don hang chua thanh toan
            return paging;
        }

        [HttpGet]
        [AcceptVerbs("OPTIONS")]
        public ListPagingJson<DonHangVM> layds_tichdiem(int userid, string token, int page, int pageSize)
        {
            //initial
            var paging = new ListPagingJson<DonHangVM>();
            paging.Paging.RecordsPerPage = pageSize;
            paging.Paging.CurrentPage = page;

            vuong_cms_context __db = new vuong_cms_context();

            //calculator
            var query = __db.DonHangs.Where(w => w.UserId == userid && w.TrangThaiThanhToanId == 2);
            paging.Paging.TotalRecords = query.Count();
            paging.List = DonHangVM.map(query.OrderByDescending(o => o.Id).Skip((page - 1) * pageSize).Take(pageSize));
            return paging;
        }

        [HttpPost]
        [AcceptVerbs("OPTIONS")]
        public rs dat_hang_qr(DatHangQRForm model)
        {
            rs r;
            using (var __db = new vuong_cms_context())
            {
                if (ModelState.IsValid)
                {

                    using (var tx = __db.Database.BeginTransaction())
                    {
                        try
                        {
                            var quan = __db.Quan.FirstOrDefault(f => f.Id == model.QuanId);

                            //var ban = __db.Ban.First(f => f.Id == model.BanId && f.QuanId == model.QuanId);
                            if (quan == null)
                            {
                                throw new Exception("Bàn và quán không hợp lệ, vui lòng thử lại!");
                            }

                            var BanArr = new List<int>();
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
                            if (model.HinhThucMuaHangId==1&&!BanArr.Contains(model.Ban))
                            {
                                throw new Exception("Số Bàn nhập không tồn tại trong quán "+quan.TenQuan+", vui lòng thử lại!");
                            }
                            //donhang
                            DonHang donhang = new DonHang();
                            //donhang.BanId = model.BanId;
                            donhang.Ban = model.Ban;
                            donhang.QuanId = model.QuanId;
                            donhang.GhiChuDonHang = "";
                            donhang.TrangThaiGiaoHangId = 1;
                            donhang.TrangThaiThanhToanId = 1;
                            donhang.UserId = null;
                            donhang.BaseUserId = quan.UserId;
                            donhang.DeviceType = 2;//mobile
                            donhang.UniqueID = model.UniqueID;
                            donhang.ModelNumber = model.ModelNumber;
                            donhang.HinhThucMuaHangId = model.HinhThucMuaHangId;
                            donhang.SDT = model.SDT;
                            donhang.YeuCauKhac = model.YeuCauKhac;
                            donhang.DiaChiGiaoHang = model.DiaChiGiaoHang;
                            donhang.TienKhachDua = 0;
                            //ctdh
                            donhang.CTDonHangs = new Collection<CTDonHang>();
                            foreach (var gio in model.ChiTietDonHang)
                            {
                                Product sp =__db.Product.FirstOrDefault(f => f.Id == gio.SanPhamId && f.ProductCat.QuanId == model.QuanId);
                                
                                if (sp == null)
                                {
                                    throw new Exception("Sản phẩm không tồn tại, vui lòng xóa tất cả sản phẩm giỏ hàng và chọn lại!");
                                }
                                var price = sp.Price;
                                string tengia = "";
                                if (gio.GiaId != 0)
                                {
                                    var check_gia=__db.BangGiaCT.FirstOrDefault(f => f.Id == gio.GiaId);
                                    if (check_gia == null)
                                    {
                                        throw new Exception("Bảng giá sản phẩm đã cũ, vui lòng tạo lại đơn hàng!");
                                    }
                                    else
                                    {
                                        price = check_gia.Price;
                                        tengia = check_gia.Ten;
                                    }
                                }
                                CTDonHang newct = new CTDonHang()
                                {
                                    SanPhamId = gio.SanPhamId,
                                    SoLuong = gio.SoLuong,
                                    DonGia = price,
                                    ThucDonId = gio.ThucDonId,
                                    TenGia = tengia,
                                    GiaId = gio.GiaId,
                                };
                                newct.ThanhTien = newct.DonGia * newct.SoLuong;
                                donhang.CTDonHangs.Add(newct);
                            }
                            var __tongtiendonhang = donhang.CTDonHangs.Sum(s => (int?)s.DonGia * s.SoLuong) ?? 0;
                            donhang.TongTienHang = __tongtiendonhang;
                           
                            //user
                            __db.DonHangs.Add(donhang);
                            __db.SaveChanges();

                            //com
                            tx.Commit();
                            r = rs.T("Đặt hàng thành công");
                            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<UsersOnLine>();
                            context.Clients.All.notify_new_donhang(donhang.BaseUserId, "Đơn hàng mới tại bàn: "+donhang.Ban );
                        }
                        catch (Exception ex)
                        {
                            r = rs.F(ex.Message);
                            tx.Rollback();
                        }

                    }
                }
                else
                {
                    //all error
                    r = rs.F("Lỗi, vui lòng thử lại. " + string.Join(";", ModelState.Values
                                             .SelectMany(x => x.Errors)
                                             .Select(x => x.ErrorMessage).Distinct()));
                }
            }
            return r;
        }
        [HttpPost]
        [AcceptVerbs("OPTIONS")]
        public rs goitinhtien(GoiTinhTienForm model)
        {
            rs r;
            using (var __db = new vuong_cms_context())
            {
                if (ModelState.IsValid)
                {
                   
                    var entity=__db.DonHangs.Find(model.DonHangID);
                    if (model.TienKhachDua < entity.TongTienHang)
                    {
                        throw new Exception("Tiền khách đưa không đủ!");
                    }
                    entity.SoLanGoiTinhTien++;
                    entity.TienKhachDua = model.TienKhachDua;
                    entity.LanCuoiGoiTinhTien = DateTime.Now;
                    __db.SaveChanges();
                    r = rs.T("Quán đã nhận được yêu cầu gọi tính tiền!", DonHangVM.map(entity));
                    IHubContext context = GlobalHost.ConnectionManager.GetHubContext<UsersOnLine>();
                    context.Clients.All.notify_goitinhtien(entity.BaseUserId,"Yêu cầu tính tiền bàn: "+entity.Ban);

                }
                else
                {
                    //all error
                    r = rs.F("Lỗi, vui lòng thử lại. " + string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).Distinct()));
                }
            }
            return r;
        }

        [HttpPost]
        [AcceptVerbs("OPTIONS")]
        public rs gopy(GopYDonHangForm model)
        {
            rs r;
            using (var __db = new vuong_cms_context())
            {
                if (ModelState.IsValid)
                {
                    var entity = __db.DonHangs.Find(model.DonHangID);
                    GopY gop = new GopY();
                    gop.DonHangId = model.DonHangID;
                    gop.NoiDungGopY = model.NoiDung;
                    gop.CreatedDate = DateTime.Now;
                    __db.GopY.Add(gop);
                    __db.SaveChanges();
                    r = rs.T("Chúng tôi đã ghi nhận góp ý của bạn, xin cám ơn!", DonHangVM.map(entity));

                    IHubContext context = GlobalHost.ConnectionManager.GetHubContext<UsersOnLine>();
                    if (entity.HinhThucMuaHangId == 1)
                    {
                        context.Clients.All.notify_gopy(entity.BaseUserId, "Nhận được góp ý tại bàn: " + entity.Ban);
                    }
                    else
                    {
                        context.Clients.All.notify_gopy(entity.BaseUserId, "Nhận được góp ý *"+entity.HinhThucMuaHang.Ten+"*");
                    }
                }
                else
                {
                    //all error
                    r = rs.F("Lỗi, vui lòng thử lại. " + string.Join(";", ModelState.Values
                                             .SelectMany(x => x.Errors)
                                             .Select(x => x.ErrorMessage).Distinct()));
                }
            }
            return r;
        }

        [HttpPost]
        [AcceptVerbs("OPTIONS")]
        public rs dat_hang(DatHangForm model)
        {
            rs r;
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
                            donhang.UserId = model.UserId;
                            donhang.GhiChuDonHang = model.GhiChu;
                            donhang.TrangThaiGiaoHangId = 1;
                            donhang.TrangThaiThanhToanId = 1;
                            //ctdh
                            donhang.CTDonHangs = new Collection<CTDonHang>();
                            foreach (var gio in model.ChiTietDonHang)
                            {
                                var sanphamdb = __db.Product.Find(gio.SanPhamId);
                                CTDonHang newct = new CTDonHang()
                                {
                                    SanPhamId = gio.SanPhamId,
                                    SoLuong = gio.SoLuong,
                                };
                                newct.ThanhTien = newct.DonGia * newct.SoLuong;
                                donhang.CTDonHangs.Add(newct);
                            }
                            var __tongtiendonhang = donhang.CTDonHangs.Sum(s => s.DonGia * s.SoLuong);
                            donhang.TongTienHang = __tongtiendonhang;

                            //user
                            __db.DonHangs.Add(donhang);
                            __db.SaveChanges();

                            //com
                            tx.Commit();
                            r = rs.T("Đặt hàng thành công");
                        }
                        catch (Exception ex)
                        {
                            r = rs.F("Lỗi máy chủ " + ex.Message);
                            tx.Rollback();
                        }

                    }
                }
                else
                {
                    //all error
                    r = rs.F(string.Join(";", ModelState.Values
                                             .SelectMany(x => x.Errors)
                                             .Select(x => x.ErrorMessage).Distinct()));
                }
            }
            return r;
        }
    }
}
