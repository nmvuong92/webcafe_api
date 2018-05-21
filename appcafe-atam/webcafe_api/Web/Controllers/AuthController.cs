using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using JWT;
using VD.Data;
using VD.Data.Entity;
using VD.Data.IRepository;
using VD.Data.Temp;
using VD.Lib;
using VD.Lib.DTO;
using Web.Security;
using Web.ViewModels.Admin.Form.Users;


namespace Web.Controllers
{

    [myAuth]

    public class AuthController : Controller
    {
        //DI
        private IUserRepository _userServ;
        private IConfigRepository __confServ;
        vuong_cms_context __db = new vuong_cms_context();
        public AuthController(IUserRepository _userServ, IConfigRepository __confServ)
        {
            this._userServ = _userServ;
            this.__confServ = __confServ;
        }

        public ActionResult UserLoggedInfo()
        {
            return PartialView();
        }

        #region[login]
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string ReturnUrl = "", string role = "")
        {

            var vm = new loginVM();
            vm.ReturnUrl = ReturnUrl;
            vm.role = role;
            ViewBag.ip = Request.UserHostAddress;
            ViewBag.__config = __confServ.GetConfigCache();
            return View(vm);
        }


        [HttpPost]
        [AllowAnonymous]
        public JsonResult LoginProccess(loginVM vm)
        {
            rs logr = _userServ.Login(vm.Username, vm.Password, true);
            if (logr.r)
            {
                loginVM user = (loginVM)logr.v;
                DateTime exp = DateTime.UtcNow.AddYears(1);
                var token = EncodeDecodeJWT.Encode(new Dictionary<string, object>
                        {
                            {"uid",user.ID},
                            {"exp",exp.toJWTString()}
                        });
                HttpCookie authCookie = new HttpCookie("auth");
                authCookie.Value = token;
                authCookie.Expires = DateTime.Now.AddMonths(1);
                Response.Cookies.Add(authCookie);
                //myCookies.Set("auth", token, exp);
            }

            string re;
            if (vm.role == "homepage")
            {
                re = Url.Action("Index", "Home", new { area = "" });
            }
            else
            {
                re = Url.Action("Index", "Home", new { area = "Admin" });
            }
            if (string.IsNullOrEmpty(vm.ReturnUrl) == false)
            {
                re = myBase64EncodeDecode.DecodeBase64(vm.ReturnUrl);
            }

            logr.v = re;
            return Json(logr, JsonRequestBehavior.DenyGet);
        }
        #endregion

        #region[logout]
        [HttpGet]
        public ActionResult Logout(string role = "")
        {
            if (_userServ.SSisLogin())
            {
                _userServ.SSLogOut();
            }
            if (role == "homepage")
            {
                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
        #endregion

        #region[thay đổi mật khẩu]

        [HttpGet]
        public ActionResult ChangePassword()
        {
            var vm = new FrmChangePassword();
            var user = _userServ.SSgetUserLoged();
            vm.TenDangNhap = user.Username;
            vm.ID = user.ID;
            return View(vm);
        }

        [HttpPost]
        public ActionResult ChangePassword(FrmChangePassword vm)
        {
            rs r = _userServ.ChangePassword(vm.ID, vm.MatKhauCu, vm.MatKhauMoi);
            TempData["message"] = r.m;
            return View(vm);
        }
        #endregion


        #region[profile]
        [myAuth]
        public ActionResult Profile()
        {
            var u = _userServ.GetEntry(_userServ.SSgetUserLoged().ID);
            return View(u);
        }

        [HttpGet]
        [myAuth]
        public ActionResult EditProfile()
        {
            var vm_id = _userServ.SSgetUserLoged().ID;
            var en = _userServ.GetEntry(vm_id);

            var vm = new EditUserVM();
            vm.HoTen = en.Fullname;
            vm.DienThoai = en.Phone;
            vm.ID = en.Id;
            vm.Email = en.Email;
            vm.DiaChi = en.Address;
            vm.Username = en.Username;
            return View(vm);
        }

        [HttpPost]
        [myAuth]
        public ActionResult EditProfile(EditUserVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user=__db.Users.Find(vm.ID);
                    user.Email = vm.Email;
                    user.Phone = vm.DienThoai;
                    user.Fullname = vm.HoTen;
                    user.Address = vm.DiaChi;
                    __db.SaveChanges();
                  
                    TempData["message"] = "Cập nhật thành công";
                    return RedirectToAction("Profile");
                }
                catch (Exception ex)
                {
                    TempData["message"] = "Error: " + ex.Message;
                }
            }
            return View(vm);
        }
        #endregion




    }
}