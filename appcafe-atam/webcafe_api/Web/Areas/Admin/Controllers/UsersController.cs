using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;
using System;

using System.Linq;
using System.Net;
using System.Transactions;
using System.Web.Mvc;
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
    [myAuth(Roles = "1")]
    public class UsersController : BaseController
    {
        private IRoleRepository _roleServ;
        private IPermissionRepository _permisionServ;
        private IUserRepository _userServ;
        vuong_cms_context __db = new vuong_cms_context();
        public UsersController(
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
            ViewBag.lstRole = _roleServ.GetList(w => w.Id == 2).ToList();

            ViewBag.ddlStatus = __db.UserStatus.Select(s => new SelectListItem()
            {
                Text = s.Name,
                Value = s.Id.ToString(),
            });
            User vm = new User();
            return View(vm);
        }

        [HttpPost]
        public PartialViewResult ajax_paging(User_filter paging)
        {
            PG<User> vmpg;
            vmpg = _userServ.GetQueryPaging(paging, w => w.RoleId == 2);
            return PartialView(vmpg);
        }


        // GET: Admin/Users/Create
        public ActionResult Create()
        {

            ViewBag.ddlRole = _roleServ.GetList(w => w.Id == 2).ToList().Select(s => new SelectListItem()
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
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(FrmCreateUserVM model)
        {
            rs r;
            if (_userServ.Count(s => s.Username == model.Username) == 0)
            {
                    using (TransactionScope tx = new TransactionScope())
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
                            entity.GioiTinh = model.GioiTinh;
                            entity.Phone = model.Phone;
                            entity.Email = model.Email;
                            entity.Fullname = model.Username;
                            entity.Image = model.Image;
                            __db.Users.Add(entity);
                            __db.SaveChanges();

                            //quan

                            /*Quan quan = new Quan()
                            {
                                UserId = entity.Id,
                                TenQuan = "Quán mẫu",
                                MaQuan = "QUAN_MAU",
                                DiaChi = "Tp. HCM",
                                DienThoai = "0123456789",
                                BanArr = "1,2,3,4,5,6,7,8,9,10",
                                ImageThumbnail =  Utils.RandomAnhSample("/Content/images/sample/shop",1,2,".png")
                            };
                            __db.Quan.Add(quan);
                            __db.SaveChanges();

                            //product cat & product
                            List<ProductCat> product_cat = new List<ProductCat>();
                            for(var i=0;i<2;i++)
                            {
                                var pc = new ProductCat()
                                {
                                    QuanId = quan.Id,
                                    Name = "Danh mục mẫu" + (i + 1),
                                    Products = new Collection<Product>(),
                                    ImageThumbnail =  Utils.RandomAnhSample("/Content/images/sample/cat",1,2,".png")
                                };
                                for (var j = 0; j < 2; j++)
                                {
                                     pc.Products.Add(new Product(){
                                         ProductName = "Sản phẩm "+(j+1),
                                         MaSo = "MSP-"+j+1,
                                         Price = Utils.RandomGia(),
                                         ThumbnailImage = Utils.RandomAnhSample("/Content/images/sample/p",1,5,".png"),
                                    });
                                }
                                product_cat.Add(pc);
                            }
                            __db.ProductCat.AddRange(product_cat);
                            __db.SaveChanges();

                            //thuc don
                            var dssp = __db.Product.Where(w => w.ProductCat.QuanId == quan.Id).Select(s=>s.Id).ToList();
                            List<ThucDon> tds = new List<ThucDon>();
                            for (var i = 0; i < 2; i++)
                            {
                                ThucDon td = new ThucDon();
                                td.QuanId = quan.Id;
                                td.Icon = Utils.RandomAnhSample("/Content/images/sample/menu", 1, 3, ".png");
                                td.TenThucDon = "Thực đơn mẫu" + (i + 1);
                                td.ThucDonCTs = new Collection<ThucDonCT>();
                              
                                td.ThucDonCTs.Add(new ThucDonCT()
                                {
                                    ProductId = dssp[i],
                                });
                               
                                tds.Add(td);
                            }
                            __db.ThucDon.AddRange(tds);
                            __db.SaveChanges();
                            */

                            r = rs.T("Okay");
                            tx.Complete();
                        }
                        catch (Exception ex)
                        {
                            r = rs.F("Lỗi: " + ex.Message);
                        }
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

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userServ.GetEntry(id.Value);
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
                    entity.GioiTinh = model.GioiTinh;
                    entity.Address = model.Address;
                    entity.Phone = model.Phone;
                    entity.Email = model.Email;
                    entity.Fullname = model.Fullname;
                    entity.Image = model.Image;
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
                if (user.Username.ToLower() == "admin" || user.Id == __auth.ID)
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
                            var en = __db.Users.Find(idmess);
                            if (en.Username.ToLower() == "admin" || en.Id == __auth.ID)
                            {
                                throw new Exception("Không thể xóa admin và tài khoản đang đăng nhập!");
                            }
                            else
                            {
                                foreach (var child in en.Members.ToList())
                                {
                                    
                                }
                                __db.SaveChanges();

                                __db.Users.Remove(en);
                                __db.SaveChanges();
                              
                            }
                        }
                        r = rs.T("Xóa thành công");
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
