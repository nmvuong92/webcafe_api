using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Web.Http;
using System.Web.Mvc;
using JWT;
using VD.Data;
using VD.Data.Entity;
using VD.Data.IRepository;
using VD.Data.Temp;
using VD.Lib;
using VD.Lib.DTO;
using VD.Lib.Encode;
using Web.Models.BQC;
using Web.Models.ThuanHanhMobileApp;
using Web.Models.ThuanHanhMobileApp.Post;
using Web.Security;

namespace Web.Apis
{

    public class AuthController : ApiController
    {
        private IUserRepository _userServ;
        private IConfigRepository __confServ;

        public AuthController(IUserRepository _userServ)
        {
            this._userServ = _userServ;
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.AcceptVerbs("OPTIONS")]
        public rs layds()
        {
            //lay danh muc cap 1

            return rs.T("Ok");
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.AcceptVerbs("OPTIONS")]
 
        public rs dang_nhap(DangNhapForm vm)
        {
            //var jwt = this.Request.Headers.GetValues("jwt").FirstOrDefault();


            rs r;
        
            rs logr = _userServ.Login(vm.CMND, vm.MatKhau, true,true);
            if (logr.r)
            {
                loginVM user = (loginVM) logr.v;
                DateTime exp = DateTime.UtcNow.AddMonths(1);
                var token = EncodeDecodeJWT.Encode(new Dictionary<string, object>
                {
                    {"uid", user.ID},
                    {"exp", exp.toJWTString()}
                });
                //đăng nhập thành công trả về token
                r = rs.T(logr.m, UserClient.map(user,token));
            }
            else
            {
                //tài khoản mật khẩu không chính xác
                r = rs.F(logr.m);
            }
            return r;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.AcceptVerbs("OPTIONS")]
        public rs dang_ky(DangKyForm model)
        {
            rs r;
            
            //lay danh muc cap 1
            if (ModelState.IsValid)
            {
              
               
                SimpleAES __aes = new SimpleAES();
              
                    vuong_cms_context __db = new vuong_cms_context();
                    if (__db.Users.Any(a => a.Username == model.CMND))
                    {
                        r = rs.F("Tên đăng nhập không hợp lệ hoặc đã tồn tại!");
                    }
                    else
                    {
                        try
                        {
                           
                            User entity = new User();
                            entity.Address = model.DiaChi;
                            entity.Phone = model.CMND;

                            entity.Username = model.CMND;
                            entity.Fullname = model.HoTen;
                            entity.Email = model.Email;
                           
                      
                            entity.Password = __aes.EncryptToString(model.MatKhau);

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
                            var getuser = __db.Users.Find(entity.Id);
                            loginVM getuservm = new loginVM(getuser);
                            var userClient = UserClient.map(getuservm, token);
                            r = rs.T("Ok!", userClient);
                        }
                        catch (Exception exx)
                        {

                            r = rs.F("Lỗi máy chủ: " + exx.Message);
                        }
                    }
            }
            else
            {
                //all error
                string messages = string.Join("; ", ModelState.Values
                                         .SelectMany(x => x.Errors)
                                         .Select(x => x.ErrorMessage).Distinct());
                r = rs.F(messages);
            }
            return r;
        }
    }
}
