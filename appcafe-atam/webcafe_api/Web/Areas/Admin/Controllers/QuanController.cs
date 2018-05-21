using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using AutoMapper;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using VD.Data;
using VD.Data.Entity;
using VD.Data.Entity.MF;
using VD.Data.IRepository;
using VD.Data.Paging;
using VD.Data.Temp;
using VD.Lib.DTO;
using VD.Lib.Encode;
using Web.Areas.Admin.ViewModels.MF;
using Web.Controllers;
using Web.Security;
using Web.ViewModels.Admin.Form.Users;

namespace Web.Areas.Admin.Controllers
{
    [myAuth(Roles = "1,2")]
    public class QuanController : BaseController
    {
        private IRoleRepository _roleServ;
        private IQuanRepository _QuanServ;
        private IUserRepository _userServ;
        private IPermissionRepository _permisionServ;
        vuong_cms_context __db = new vuong_cms_context();
        private IImgTmpRepository _imgTmpServ;
        public QuanController(
            IQuanRepository _QuanServ,
            IImgTmpRepository _imgTmpServ,
            IUserRepository _userServ,
            IPermissionRepository _quyenServ,
            IRoleRepository _roleServ)
        {
            this._QuanServ = _QuanServ;
            this._imgTmpServ = _imgTmpServ;
            this._userServ = _userServ;
            this._permisionServ = _quyenServ;
            this._roleServ = _roleServ;
        }

        [HttpPost]
        public JsonResult AjaxDatQuanChinh(int quanid)
        {
            rs r;
            try
            {
                var __auth = MySsAuthUsers.GetAuth();
                var user = __db.Users.Find(__auth.ID);

                user.QuanDefaultId = quanid;
                __db.SaveChanges();

                r = rs.T("Ok");
            }
            catch (Exception ex)
            {
                r = rs.F(ex.Message);
            }

            return Json(r, JsonRequestBehavior.DenyGet);
        }
        public ActionResult ChonQuanMacDinh(int? id)
        {
            var __auth = MySsAuthUsers.GetAuth();
            var user = __db.Users.Find(__auth.ID);
            if (id.HasValue)
            {
                try
                {
                    user.QuanDefaultId = id;
                    __db.SaveChanges();
                }
                catch (Exception ex)
                {

                }
            }
            var dsQuanSoHuu = new List<Quan>();
            if (user.OwnerId != null)
            {
                dsQuanSoHuu = __db.UserQuan.Where(w => w.UserID == __auth.ID).Select(s => s.Quan).ToList();
            }
            else
            {
                dsQuanSoHuu = __db.Quan.Where(w => w.UserId == __auth.ID).ToList();
            }
            ViewBag.id = user.QuanDefaultId;
            return View(dsQuanSoHuu);
        }

        public ActionResult Index()
        {
            ViewBag.__auth = MySsAuthUsers.GetAuth();
            Quan vm = new Quan();
            return View(vm);
        }

        [HttpPost]
        public PartialViewResult ajax_paging(smartpaging paging)
        {
            var __auth = MySsAuthUsers.GetAuth();
            PG<Quan> vmpg;
            if (__auth.RoleId == 1 && __auth.Username == "admin")
            {
                vmpg = _QuanServ.GetQueryPaging(paging);
            }
            else
            {
                vmpg = _QuanServ.GetQueryPaging(paging, w => w.UserId == __auth.ID);
            }
            var user = __db.Users.Find(__auth.ID);
            ViewBag.QuanDefaultId = user.QuanDefaultId ?? -1;
            return PartialView(vmpg);
        }

        [myAuth(Roles = "1", Users = "admin")]
        // GET: Admin/Quans/Create
        public ActionResult Create(int catid = -1)
        {
            var auth = MySsAuthUsers.GetAuth();
            QuanCRUD vm = new QuanCRUD();
            vm.DanhSachNhanVien = __db.Users.Where(w => w.OwnerId == auth.ID);
            vm.ChuQuan = new FrmCreateUserVM();
            vm.ChuQuan.ddlGioiTinh = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Nam",Value = "Nam"},
                new SelectListItem(){Text = "Nữ",Value = "Nữ"}
            };
            ViewBag.__auth = auth;
            return View(vm);
        }
        [myAuth(Roles = "1", Users = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public JsonResult Create(QuanCRUD model)
        {
            var __auth = MySsAuthUsers.GetAuth();
            rs r;
            using (TransactionScope tx = new TransactionScope())
            {
                try
                {


                    //chủ quán
                    SimpleAES __aes = new SimpleAES();
                    User chuquan = new User();
                    //pass encode
                    chuquan.Username = model.ChuQuan.Username;
                    chuquan.Password = __aes.EncryptToString(model.ChuQuan.Password);
                    chuquan.RoleId = 2;//chu quan
                    chuquan.UserStatusId = 1;
                    chuquan.Address = model.ChuQuan.Address;
                    chuquan.GioiTinh = model.ChuQuan.GioiTinh;
                    chuquan.Phone = model.ChuQuan.Phone;
                    chuquan.Email = model.ChuQuan.Email;
                    chuquan.Fullname = model.ChuQuan.Username;
                    if (string.IsNullOrWhiteSpace(model.ImageThumbnail))
                    {
                        chuquan.Image = "/Content/images/sample/shop2.png"; //model.Image;
                    }
                    else
                    {
                        chuquan.Image = model.ImageThumbnail;
                    }
                    __db.Users.Add(chuquan);
                    __db.SaveChanges();


                    Quan quan = new Quan();
                    quan.MaQuan = model.MaQuan;
                    quan.TenQuan = model.TenQuan;

                    quan.UserQuans = new List<UserQuan>();
                    quan.UserId = chuquan.Id; //chuquan
                    quan.DiaChi = model.DiaChi;
                    quan.DienThoai = model.DienThoai;
                    quan.BanArr = "1,2,3,4,5,6,7,8,9,10";
                    if (string.IsNullOrWhiteSpace(model.ImageThumbnail))
                    {
                        quan.ImageThumbnail = "/Content/images/sample/account.png";
                    }
                    else
                    {
                        quan.ImageThumbnail = model.ImageThumbnail;
                    }
                    //danh sach nhan vien quan ly
                    foreach (var item in model.NhanVienIntIDs)
                    {
                        quan.UserQuans.Add(new UserQuan()
                        {
                            QuanID = quan.Id,
                            UserID = item
                        });
                    }
                    __db.Quan.Add(quan);
                    __db.SaveChanges();
                    chuquan.QuanDefaultId = quan.Id;
                    __db.SaveChanges();
                    //product cat & product
                    List<ProductCat> product_cat = new List<ProductCat>();
                    for (var i = 0; i < 2; i++)
                    {
                        var pc = new ProductCat()
                        {
                            QuanId = quan.Id,
                            Name = "Danh mục mẫu" + (i + 1),
                            Products = new Collection<Product>(),
                            ImageThumbnail = Utils.RandomAnhSample("/Content/images/sample/cat", 1, 2, ".png")
                        };
                        for (var j = 0; j < 2; j++)
                        {
                            pc.Products.Add(new Product()
                            {
                                ProductName = "Sản phẩm " + (j + 1),
                                MaSo = "MSP-" + j + 1,
                                Price = Utils.RandomGia(),
                                ThumbnailImage = Utils.RandomAnhSample("/Content/images/sample/p", 1, 5, ".png"),
                            });
                        }
                        product_cat.Add(pc);
                    }
                    __db.ProductCat.AddRange(product_cat);
                    __db.SaveChanges();


                    r = rs.T("Okay");
                    tx.Complete();
                }
                catch (Exception ex)
                {
                    r = rs.F("Lỗi: " + ex.Message);
                }
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }

        // GET: Admin/Quans/Edit/5
        public ActionResult Edit(int id)
        {
            var auth = MySsAuthUsers.GetAuth();
            Quan entity = _QuanServ.GetEntry(id);

            QuanCRUD vm = new QuanCRUD();
            vm.Id = entity.Id;
            vm.MaQuan = entity.MaQuan;
            vm.TenQuan = entity.TenQuan;

            if (string.IsNullOrWhiteSpace(vm.ImageThumbnail))
            {
                vm.ImageThumbnail = "/Content/images/sample/shop2.png"; //model.Image;
            }
            else
            {
                vm.ImageThumbnail = entity.ImageThumbnail;
            }
            vm.DiaChi = entity.DiaChi;
            vm.DienThoai = entity.DienThoai;
            if (auth.RoleId == 1)
            {
                vm.DanhSachNhanVien = new List<User>();
            }
            else
            {
                vm.DanhSachNhanVien = __db.Users.Where(w => w.OwnerId == auth.ID);
            }
            ViewBag.__auth = auth;
            vm.DanhSachNhanVienChon = entity.UserQuans.Select(s => s.UserID).ToList();
            vm.BanArr = entity.BanArr;
            vm.ChuQuan = new FrmCreateUserVM();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]


        public JsonResult Edit(QuanCRUD model)
        {

            rs r;
            using (var trans = new TransactionScope())
            {
                try
                {
                    var entity = _QuanServ.SingleOrDefault(s => s.Id == model.Id);
                    entity.MaQuan = model.MaQuan;
                    entity.TenQuan = model.TenQuan;
                    if (string.IsNullOrWhiteSpace(model.ImageThumbnail))
                    {
                        entity.ImageThumbnail = "/Content/images/sample/shop2.png"; //model.Image;
                    }
                    else
                    {
                        entity.ImageThumbnail = model.ImageThumbnail;
                    }
                   
                    entity.DiaChi = model.DiaChi;
                    entity.DienThoai = model.DienThoai;

                    //ban

                    List<int> arr;
                    if (!string.IsNullOrWhiteSpace(model.BanArr))
                    {
                        try
                        {
                            arr = model.BanArr.Split(',').Select(Int32.Parse).Distinct().ToList();
                            entity.BanArr = string.Join(",", arr.Select(x => x.ToString()).ToArray());
                        }
                        catch
                        {
                            throw new Exception("Lỗi, vui lòng kiểm tra giá trị nhập tất cả số bàn ngăn cách nhau bằng dấu phẩy!!!");
                        }
                    }
                    else
                    {
                        throw new Exception("Vui lòng nhập ít nhất 1 bàn!!!");
                    }
                    //
                    entity.UserQuans.Clear();
                    _QuanServ.Save();
                    //danh sach nhan vien quan ly
                    entity.UserQuans = new List<UserQuan>();
                    if (model.NhanVienIntIDs != null)
                    {
                        foreach (var item in model.NhanVienIntIDs)
                        {
                            entity.UserQuans.Add(new UserQuan()
                            {
                                QuanID = entity.Id,
                                UserID = item
                            });
                        }
                    }

                    _QuanServ.Save();
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
                Quan Quan = _QuanServ.GetEntry(id);

                _QuanServ.Delete(Quan);
                _QuanServ.Save();

                r = rs.T("Ok");
            }
            catch (Exception ex)
            {
                r = rs.F("Lỗi: " + ex.Message);

            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public ActionResult SetBanChayQuan(int id)
        {
            rs r;
            try
            {

                Quan search = _QuanServ.GetEntry(id);
                //search.IsBanChay = !search.IsBanChay;
                _QuanServ.Save();
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
                            __db.Database.ExecuteSqlCommand("DELETE FROM Quans WHERE Id=" + idmess);
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

        #region EDIT USER

        // GET: Admin/Users/Edit/5
        public ActionResult EditUser(int id)
        {
            var __auth = MySsAuthUsers.GetAuth();
            ViewBag.__auth = __auth;
            User user = _userServ.GetEntry(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.ddlRole = _roleServ.GetList(w => w.Id == 2).ToList().Select(s => new SelectListItem()
            {
                Text = s.Name,
                Value = s.Id.ToString()
            });
            ViewBag.dsQuyen = _permisionServ.GetList().ToList();
            SimpleAES aes = new SimpleAES();
            user.Password = aes.DecryptString(user.Password);
            FrmCreateUserVM model = Mapper.Map<User, FrmCreateUserVM>(user);
            model.ddlGioiTinh = new List<SelectListItem>(){
                new SelectListItem(){Text = "Nam",Value = "Nam"},
                new SelectListItem(){Text = "Nữ",Value = "Nữ"}
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public JsonResult EditUser(FrmCreateUserVM model)
        {
            var __auth = MySsAuthUsers.GetAuth();
            bool isadmin = __auth.RoleId == 1 && __auth.Username == "admin";
            rs r;
            using (var trans = new TransactionScope())
            {
                try
                {
                    SimpleAES __aes = new SimpleAES();
                    var entity = _userServ.SingleOrDefault(s => s.Id == model.ID);
                    entity.RoleId = model.RoleId;
                    entity.Password = __aes.EncryptToString(model.Password);
                    entity.GioiTinh = model.GioiTinh;
                    entity.Address = model.Address;
                    entity.Phone = model.Phone;
                    entity.Email = model.Email;
                    entity.Fullname = model.Fullname;
                    entity.Image = model.Image;
                    if (isadmin && entity.Username != model.Username)
                    {
                        if (__db.Users.Any(a => a.Username == model.Username && a.Id != model.ID))
                        {
                            throw new Exception("Tên đăng nhập này đã tồn tại");
                        }
                        entity.Username = model.Username;
                    }
                    _userServ.Save();
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
        #endregion
        #region IMAGES

        #endregion
    }
}
