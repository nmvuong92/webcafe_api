using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VD.Data;
using VD.Data.Entity.MF;
using VD.Data.IRepository;
using VD.Data.Paging;
using VD.Lib.DTO;
using Web.Areas.Admin.ViewModels.MF;
using Web.Controllers;
using Web.Security;

namespace Web.Areas.Admin.Controllers
{
    [myAuth(Roles = "1,2")]
    public class ProductCatController :BaseController
    {
        private IProductCatRepository _productCatRepo;
    
        vuong_cms_context __db = new vuong_cms_context();

        public ProductCatController(IProductCatRepository _productCatRepo)
        {
            this._productCatRepo = _productCatRepo;
        }
        // GET: Admin/ProductCat
        public ActionResult Index()
        {
            ProductCat vm = new ProductCat();
            return View(vm);
        }

        [HttpPost]
        public PartialViewResult ajax_paging(smartpaging paging)
        {
            var __auth = MySsAuthUsers.GetAuth();
            PG<ProductCat> vmpg;
            if (__auth.Username == "admin")
            {
                vmpg = _productCatRepo.GetQueryPaging(paging);
            }
            else
            {
                vmpg = _productCatRepo.GetQueryPaging(paging, w => w.Quan.UserId == __auth.OwnerId);
            }
         
            return PartialView(vmpg);
        }

     
        public PartialViewResult ddlParent(string name, string SelectedValue = "-1", string Default = "-Chọn danh mục-")
        {
            var qqq = __db.ProductCat.AsQueryable();
            ViewBag.Name = name;
            ViewBag.SelectedValue = SelectedValue;
            ViewBag.Default = Default;
            return PartialView(qqq);
        }

       

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var __auth = MySsAuthUsers.GetAuth();
            var entity = __db.ProductCat.Find(id);
            ProductCatCRUD vm = new ProductCatCRUD();
            vm.Id = entity.Id;
            vm.Name = entity.Name;
            //vm.ParentId = entity.ParentId;
            vm.Description = entity.Description;
            vm.ImageThumbnail = entity.ImageThumbnail;
            vm.QuanId = entity.QuanId;
            vm.ddlQuan = __db.Quan.Where(w => w.UserId == __auth.ID).ToList().Select(s => new SelectListItem()
            {
                Text = "[" + s.MaQuan + "] " + s.TenQuan,
                Value = s.Id.ToString()
            });
            return View(vm);
        }

        [HttpPost]
        public JsonResult EditProccess(ProductCatCRUD model)
        {
            rs r;
            try
            {
                var entity = __db.ProductCat.Find(model.Id);
                entity.Name = model.Name;
                //entity.ParentId = (model.ParentId==-1)?null:model.ParentId;
                entity.Description = model.Description;
                entity.QuanId = model.QuanId;

                if (string.IsNullOrWhiteSpace(model.ImageThumbnail))
                {
                    entity.ImageThumbnail = "/Content/images/sample/menu1.png";
                }
                else
                {
                    entity.ImageThumbnail = model.ImageThumbnail;
                }
                __db.SaveChanges();
                r = rs.T("Ok");
            }
            catch (Exception ex)
            {
                r = rs.F(ex.Message);
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var __auth = MySsAuthUsers.GetAuth();
            ProductCatCRUD vm = new ProductCatCRUD();
            vm.ddlQuan = __db.Quan.Where(w => w.UserId == __auth.ID).ToList().Select(s => new SelectListItem()
            {
                Text = "[" + s.MaQuan + "] " + s.TenQuan,
                Value = s.Id.ToString()
            });
            //vm.ParentId = -1;
            return View(vm);
        }

        [HttpPost]
        public JsonResult CreateProccess(ProductCatCRUD model)
        {
            rs r;
            try
            {
                var entity = new ProductCat();
                entity.Name = model.Name;
             
                //entity.ParentId = (model.ParentId == -1) ? null : model.ParentId;
                entity.Description = model.Description;
               
                entity.QuanId = model.QuanId;
                if (string.IsNullOrWhiteSpace(model.ImageThumbnail))
                {
                    entity.ImageThumbnail = "/Content/images/sample/menu1.png";
                }
                else
                {
                    entity.ImageThumbnail = model.ImageThumbnail;
                }
                __db.ProductCat.Add(entity);
                __db.SaveChanges();
                r = rs.T("Ok");
            }
            catch (Exception ex)
            {
                r = rs.F(ex.Message);
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }

        public JsonResult Delete(int id)
        {
            rs r;
            try
            {
                var entity = __db.ProductCat.Find(id);
                __db.ProductCat.Remove(entity);
                __db.SaveChanges();
                r = rs.T("Ok");
            }
            catch (Exception ex)
            {
                r = rs.F(ex.Message);
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }
    }
}