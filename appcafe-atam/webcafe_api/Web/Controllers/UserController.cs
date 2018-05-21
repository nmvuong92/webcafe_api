using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using JWT;
using VD.Data;
using VD.Data.Entity;
using VD.Data.Entity.BQC;
using VD.Data.IRepository;
using VD.Data.Temp;
using VD.Lib;
using VD.Lib.DTO;
using VD.Lib.Encode;
using Web.Security;
using Web.ViewModels.BQC;
using Web.ViewModels.User;

namespace Web.Controllers
{
    public class UserController : BaseController
    {
        public IUserRepository _userRepo;
        public UserController(IUserRepository _userRepo)
        {
            this._userRepo = _userRepo;
        }
        vuong_cms_context __db = new vuong_cms_context();
        public ActionResult PRegister()
        {
            RegisterVM vm = new RegisterVM();
            vm.ddlProvince = __db.Province.Select(s => new SelectListItem()
            {
                Value = s.Id.ToString(),
                Text = s.Name
            }).ToList();
            vm.ddlHttt = __db.HTTTs.Select(s => new SelectListItem()
            {
                Value = s.Id.ToString(),
                Text = s.Ten
            }).ToList();
            vm.ddlXungDanh = new List<SelectListItem>(){
                    new SelectListItem(){Text="Anh",Value="Anh"},
                    new SelectListItem(){Text= "Chị",Value="Chị"}
                }.ToList();
            return View(vm);
        }

        [HttpPost]
        public ActionResult PRegister(RegisterVM model)
        {

            rs r;
            SimpleAES __aes = new SimpleAES();
            if (ModelState.IsValid)
            {
                if (__db.Users.Any(a => a.Username == model.Username))
                {
                    r = rs.F("Tên đăng nhập không hợp lệ hoặc đã tồn tại!");
                }
                else
                {
                    try
                    {
                        User entity = new User();
                        entity.Address = model.Address;
                        entity.Phone = model.Phone;
                       
                        entity.Username = model.Username;
                        entity.Password = __aes.EncryptToString(model.Password);

                        entity.UserStatusId = 1; //kích hoat
                        entity.RoleId = 2; //cus

                        __db.Users.Add(entity);
                        __db.SaveChanges();

                        DateTime exp = DateTime.UtcNow.AddYears(1);
                        var token = EncodeDecodeJWT.Encode(new Dictionary<string, object>
                        {
                            {"uid",entity.Id},
                            {"exp",exp.toJWTString()}
                        });
                        myCookies.Set("auth", token, exp);
                        r = rs.T("Ok!");
                    }
                    catch (Exception exx)
                    {
                        r = rs.F(exx.Message);
                    }
                }

            }
            else
            {
                r = rs.F("Lỗi nhập liệu");
            }
            if (r.r)
            {
                return RedirectToAction("Profile", "User");
            }
            model.ddlProvince = __db.Province.Select(s => new SelectListItem()
            {
                Value = s.Id.ToString(),
                Text = s.Name
            }).ToList();
            model.ddlHttt = __db.HTTTs.Select(s => new SelectListItem()
            {
                Value = s.Id.ToString(),
                Text = s.Ten
            }).ToList();
            model.ddlXungDanh = new List<SelectListItem>(){
                    new SelectListItem(){Text="Anh",Value="Anh"},
                    new SelectListItem(){Text= "Chị",Value="Chị"}
                }.ToList();
            return View(model);
        }
        public ActionResult PLogin(string ReturnUrl = "")
        {
            Web.ViewModels.User.pLoginVM model = new Web.ViewModels.User.pLoginVM();
            model.ReturnUrl = ReturnUrl;
            return View(model);
        }
        public ActionResult mLogin()
        {
            Web.ViewModels.User.pLoginVM model = new Web.ViewModels.User.pLoginVM();
            model.ReturnUrl = string.Empty;
            return View(model);
        }
        [HttpPost]
        public JsonResult mLoginProcess(Web.ViewModels.User.pLoginVM model)
        {
            rs r;
            if (ModelState.IsValid)
            {
                try
                {
                    SimpleAES __aes = new SimpleAES();
                    string __pw_aes = __aes.EncryptToString(model.Password);
                    var _login = __db.Users.FirstOrDefault(f => f.Username == model.Username && f.Password == __pw_aes);


                    if (_login != null)
                    {
                        DateTime exp = DateTime.UtcNow.AddYears(1);
                        var token = EncodeDecodeJWT.Encode(new Dictionary<string, object>
                        {
                            {"uid",_login.Id},
                            {"exp",exp.toJWTString()}
                        });
                        myCookies.Set("auth", token, exp);
                        loginVM log = new loginVM(_login);
                        MySsAuthUsers.setLogin(log);
                        r = rs.T("Ok!");
                    }
                    else
                    {
                        r = rs.F("Ok!");
                    }
                }
                catch (Exception ex)
                {
                    r = rs.F(ex.Message);
                }
            }
            else
            {
                r = rs.F("Lỗi nhập liệu!");
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }
        [HttpPost]
        public ActionResult PLogin(Web.ViewModels.User.pLoginVM model)
        {
            rs r;
            if (ModelState.IsValid)
            {
                try
                {
                    SimpleAES __aes = new SimpleAES();
                    string __pw_aes = __aes.EncryptToString(model.Password);
                    var _login = __db.Users.FirstOrDefault(f => f.Username == model.Username && f.Password == __pw_aes);


                    if (_login != null)
                    {
                        DateTime exp = DateTime.UtcNow.AddYears(1);
                        var token = EncodeDecodeJWT.Encode(new Dictionary<string, object>
                        {
                            {"uid",_login.Id},
                            {"exp",exp.toJWTString()}
                        });
                        myCookies.Set("auth", token, exp);
                        loginVM log = new loginVM(_login);
                        MySsAuthUsers.setLogin(log);
                        r = rs.T("Ok!");
                    }
                    else
                    {
                        r = rs.F("Ok!");
                    }
                }
                catch (Exception ex)
                {
                    r = rs.F(ex.Message);
                }
            }
            else
            {
                r = rs.F("Lỗi nhập liệu!");
            }
            if (!r.r)
            {
                ModelState.AddModelError(string.Empty, r.m);
            }
            else
            {

                if (string.IsNullOrEmpty(model.ReturnUrl) == false)
                {
                    return Redirect(myBase64EncodeDecode.DecodeBase64(model.ReturnUrl));
                }
                else
                {
                    return RedirectToAction("Profile", "User");
                }

            }
            return View(model);
        }

        public ActionResult Logout()
        {
            this._userRepo.SSLogOut();
            return RedirectToAction("Index", "Home");

        }

        [myAuth]
        public ActionResult Profile()
        {
            var au = MySsAuthUsers.GetAuth();
            vuong_cms_context __db = new vuong_cms_context();
            var model = __db.Users.Find(au.ID);
            return View(model);
        }

        /*

        [myAuth]
        [HttpPost]
        public ActionResult NangCapVip()
        {
            var au = MySsAuthUsers.GetAuth();
            using (var __db = new vuong_cms_context())
            {

                var giavip1 = __setting.menh_gia_the_cao_mua_thanh_vien_vip1;
                var user = __db.Users.Find(au.ID);
                if (user.ViTien >= giavip1)
                {
                    using (var tx = new TransactionScope())
                    {
                        user.ViTien -= giavip1;
                        user.IsVip1 = true;
                        __db.SaveChanges();

                        LichSuGiaoDich ls = new LichSuGiaoDich();
                        ls.UserId = au.ID;
                        ls.menhgia = giavip1;
                        ls.ngaygiaodich = DateTime.Now;
                        ls.tengiaodich = "Nâng cấp thành viên VIP";
                        __db.LichSuGiaoDich.Add(ls);
                        __db.SaveChanges();

                        //refresh
                        _userRepo.RefreshLogin();
                        tx.Complete();
                        TempData["message"] = "Nâng cấp thành công";
                    }

                }
                else
                {
                    TempData["message"] = "Bạn không đủ tiền, vui lòng nạp thẻ";
                    return RedirectToAction("NapThe", "BaoKim");
                }
            }
            return RedirectToAction("Profile");
        }*/
        [myAuth]
        public ActionResult LichSuGiaoDich()
        {
            int _id = MySsAuthUsers.GetAuth().ID;

            vuong_cms_context __db = new vuong_cms_context();
            var model = __db.LichSuGiaoDich.Where(w => w.UserId == _id).OrderByDescending(o => o.ngaygiaodich);
            return View(model);
        }
        [myAuth]
        public ActionResult LichSuNapThe()
        {
            int _id = MySsAuthUsers.GetAuth().ID;
            vuong_cms_context __db = new vuong_cms_context();
            var model = __db.LichSuNapThe.Where(w => w.UserId == _id).OrderByDescending(o => o.ngay);
            return View(model);
        }

        [myAuth]
        public ActionResult DonHang()
        {
            int _id = MySsAuthUsers.GetAuth().ID;
            vuong_cms_context __db = new vuong_cms_context();
            var model = __db.DonHangs.Where(w => w.UserId == _id).OrderByDescending(o => o.CreatedDate);
            return View(model);
        }
        
        [myAuth]
        public ActionResult CTDonHang(int Id)
        {
            int _id = MySsAuthUsers.GetAuth().ID;
            vuong_cms_context __db = new vuong_cms_context();
            var model = __db.DonHangs.FirstOrDefault(w => w.Id == Id);
            return View(model);
        }
        [myAuth]
        public ActionResult DoiMatKhau()
        {

            DoiMatKhauVM model = new DoiMatKhauVM();
            return View(model);
        }

        [HttpPost]
        [myAuth]
        public JsonResult DoiMatKhauProccess(DoiMatKhauVM model)
        {
            rs r;
            SimpleAES __aes = new SimpleAES();
            if (ModelState.IsValid)
            {
                var __oldpw = __aes.EncryptToString(model.MatKhauHienTai);
                var __newpw = __aes.EncryptToString(model.MatKhauMoi);
                var __id = MySsAuthUsers.GetAuth().ID;
                using (var __db = new vuong_cms_context())
                {
                    var user = __db.Users.Find(__id);
                    if (user.Password == __oldpw)
                    {
                        user.Password = __newpw;
                        __db.SaveChanges();
                        r = rs.T("Ok");
                    }
                    else
                    {
                        r = rs.F("Mật khẩu hiện tại không chính xác!");
                    }
                }
            }
            else
            {

                r = rs.F("Vui lòng điền đầy đủ thông tin!");
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }


        [myAuth]
        public ActionResult CapNhat()
        {
            var __id = MySsAuthUsers.GetAuth().ID;
            CapNhatUserVM model = new CapNhatUserVM();
            using (var __db = new vuong_cms_context())
            {
                var user = __db.Users.Find(__id);
                model.Username = user.Username;
                model.Phone = user.Phone;
                model.Address = user.Address;
                model.Fullname = user.Fullname;
            }
            return View(model);
        }

        [HttpPost]
        [myAuth]
        public JsonResult CapNhatProccess(CapNhatUserVM model)
        {
            rs r;
            SimpleAES __aes = new SimpleAES();
            if (ModelState.IsValid)
            {

                var __id = MySsAuthUsers.GetAuth().ID;
                using (var __db = new vuong_cms_context())
                {
                    var user = __db.Users.Find(__id);

                    user.Phone = model.Phone;
                    user.Address = model.Address;
                    user.Fullname = model.Fullname;
                    __db.SaveChanges();
                    r = rs.T("Ok");
                }
            }
            else
            {
                r = rs.F("Vui lòng điền đầy đủ thông tin!");
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }
    }
}