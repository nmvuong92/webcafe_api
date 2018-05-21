using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;
using System;

using System.Linq;
using System.Net;
using System.Transactions;
using System.Web.Mvc;
using Ninject;
using VD.Data;
using VD.Data.Entity.MF;
using VD.Data.IRepository;
using VD.Data.Paging;


using VD.Lib.DTO;
using VD.Lib.Encode;

using Web.Controllers;
using Web.Security;
using Web.ViewModels.Admin.Form.Users;

using VD.Data.Entity;
namespace Web.Areas.Admin.Controllers
{
    [myAuth(Roles = "1,2")]
    public class NhanVienController : BaseController
    {
        private IRoleRepository _roleServ;
        private IPermissionRepository _permisionServ;
        private IUserRepository _userServ;
        vuong_cms_context __db = new vuong_cms_context();
        public NhanVienController(
            IRoleRepository _roleServ,
            IPermissionRepository _quyenServ,
            IUserRepository _userServ)
        {
            this._roleServ = _roleServ;
            this._permisionServ = _quyenServ;
            this._userServ = _userServ;

        }

        public ActionResult Index()
        {
            ViewBag.lstRole = _roleServ.GetList(w=>w.Id==3).ToList();
           
            ViewBag.ddlStatus = __db.UserStatus.Select(s => new SelectListItem()
            {
                Text=s.Name,
                Value = s.Id.ToString()
            });
            User vm = new User();
            return View(vm);
        }

        [HttpPost]
        public PartialViewResult ajax_paging(User_filter paging)
        {
            var __auth = MySsAuthUsers.GetAuth();
            PG<User> vmpg;
            vmpg = _userServ.GetQueryPaging(paging, w=>w.OwnerId ==__auth.ID);
            return PartialView(vmpg);
        }


        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            var __auth = MySsAuthUsers.GetAuth();
            ViewBag.ddlRole = _roleServ.GetList(w => w.Id == 3).ToList().Select(s => new SelectListItem()
            {
                Text = s.Name,
                Value = s.Id.ToString()
            });
            ViewBag.dsQuyen = _permisionServ.GetList().ToList();
            var model = new FrmCreateUserVM();
            model.ddlGioiTinh = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Nam",Value = "Nam"},
                new SelectListItem(){Text = "Nữ",Value = "Nữ"}
            };

            model.DanhSachQuan = __db.Quan.Where(w => w.UserId == __auth.ID);
            model.DanhSachQuanChon = __db.UserQuan.Where(w => w.UserID == __auth.ID).Select(s=>s.QuanID).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(FrmCreateUserVM model)
        {
            var __auth = MySsAuthUsers.GetAuth();
            rs r;
            if (_userServ.Count(s => s.Username == model.Username) == 0)
            {
                try
                {
                    SimpleAES __aes = new SimpleAES();
                    User entity = new User();
                    //pass encode
                    entity.Username = model.Username;
                    entity.Password = __aes.EncryptToString(model.Password);
                    entity.RoleId = model.RoleId;
                    entity.UserStatusId = 1;
                    entity.Address = model.Address;
                    entity.Phone = model.Phone;
                    entity.GioiTinh = model.GioiTinh;
                    entity.Fullname = model.Username;
                    entity.OwnerId = __auth.ID;
                    entity.Image = model.Image;

                    entity.UserQuans = new Collection<UserQuan>();
                    //danh sach nhan vien quan ly
                    foreach (var item in model.QuanIntIDs)
                    {
                        entity.UserQuans.Add(new UserQuan()
                        {
                            QuanID = item,
                            UserID = entity.Id
                        });
                    }
                    __db.Users.Add(entity);
                    __db.SaveChanges();
                    r = rs.T("Okay");
                }
                catch (Exception ex)
                {
                    r = rs.F("Lỗi: " + ex.Message);
                }
            }
            else
            {
                r = rs.F("Lỗi:tên đăng nhập đã tồn tại vui lòng chọn tên khác");

            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            var __auth = MySsAuthUsers.GetAuth();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userServ.GetEntry(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.ddlRole = _roleServ.GetList(w => w.Id == 3).ToList().Select(s => new SelectListItem()
            {
                Text = s.Name,
                Value = s.Id.ToString()
            });
            ViewBag.dsQuyen = _permisionServ.GetList().ToList();
            SimpleAES aes = new SimpleAES();
            user.Password = aes.DecryptString(user.Password);

            FrmCreateUserVM model = Mapper.Map<User, FrmCreateUserVM>(user);
            model.ddlGioiTinh = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Nam",Value = "Nam"},
                new SelectListItem(){Text = "Nữ",Value = "Nữ"}
            };
            model.DanhSachQuan = __db.Quan.Where(w => w.UserId == __auth.ID);
            model.DanhSachQuanChon = user.UserQuans.Select(s => s.QuanID).ToList();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public JsonResult Edit(FrmCreateUserVM model)
        {
            rs r;
            using (var trans = new TransactionScope())
            {
                try
                {
                    SimpleAES __aes = new SimpleAES();
                    var entity = _userServ.SingleOrDefault(s => s.Id == model.ID);
                    entity.RoleId = model.RoleId;
                    entity.Password = __aes.EncryptToString(model.Password);
                    entity.Phone = model.Phone;
                    entity.Fullname = model.Fullname;
                    entity.GioiTinh = model.GioiTinh;
                    entity.Email = model.Email;
                    entity.Address = model.Address;
                    entity.Image = model.Image;
                    entity.UserQuans.Clear();

                    //danh sach nhan vien quan ly
                    entity.UserQuans = new List<UserQuan>();
                    if (model.QuanIds != null)
                    {
                        foreach (var item in model.QuanIntIDs)
                        {
                            entity.UserQuans.Add(new UserQuan()
                            {
                                QuanID = item,
                                UserID = entity.Id
                            });
                        }
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

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var __auth = MySsAuthUsers.GetAuth();
            rs r;
            try
            {
                User user = _userServ.GetEntry(id);
                if (user.Username.ToLower() == "admin" || user.Id==__auth.ID)
                {
                    r = rs.F("Không thể xóa admin/owner");
                }
                else
                {
                    _userServ.Delete(user);
                    _userServ.Save();
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
            var __auth = MySsAuthUsers.GetAuth();
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
                            var en = _userServ.SingleOrDefault(s => s.Id == idmess);
                            if (en.Username.ToLower() == "admin" || en.Id == __auth.ID)
                            {

                            }
                            else
                            {
                                _userServ.Delete(en);
                                _userServ.Save();
                            }
                           
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

        internal static int[] SplitString(string original)
        {
            if (String.IsNullOrEmpty(original))
            {
                return new int[0];
            }

            //cái: piece
            var split = from piece in original.Split(',')
                        let trimmed = piece.Trim()
                        where !String.IsNullOrEmpty(trimmed)
                        select int.Parse(trimmed);
            return split.ToArray();
        }

        internal static bool IsInRole(string[] chils_roles, string[] parent_roles)
        {
            return chils_roles.Count(parent_roles.Contains) == chils_roles.Length;
        }
    }
}
