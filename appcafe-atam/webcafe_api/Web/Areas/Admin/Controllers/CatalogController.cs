using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using VD.Data;
using VD.Data.Entity;
using VD.Data.Entity.MF;
using VD.Data.IRepository;
using VD.Data.Repository;
using VD.Lib;
using VD.Lib.DTO;
using Web.Areas.Admin.ViewModels;
using Web.Controllers;
using Web.Security;

namespace Web.Areas.Admin.Controllers
{
     [myAuth(Roles = "1")]
    public class CatalogController : BaseController
    {
        vuong_cms_context __db = new vuong_cms_context();
   

   
        public ActionResult Index(int page=1)
        {
            var list = __db.Catalog.ToList();

            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            Catalog model = new Catalog();
            model.HinhAnh = "nonononononono";
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Catalog model, HttpPostedFileBase file)
        {
            rs r;
            if (ModelState.IsValid)
            {
                try
                {
                    if (file.ContentLength > 0)
                    {
                        string _FileName = myNumbers.LayMaNgauNhien10ChuSo() + Path.GetFileName(file.FileName);
                        string _xpath = "/user-uploads/catalog/" + _FileName;
                        string _path = Path.Combine(Server.MapPath("~/user-uploads/catalog"), _FileName);
                        file.SaveAs(_path);
                        model.HinhAnh = _xpath;
                    }
                    else
                    {
                        model.HinhAnh = "";
                    }
                    
                    __db.Catalog.Add(model);
                    __db.SaveChanges();
                 
                    r = rs.T("Success!");
                }
                catch (Exception ex)
                {
                    r = rs.F(ex.Message);
                }
                TempData["message"] = r.m;
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = __db.Catalog.Find(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Catalog model, HttpPostedFileBase file)
        {
            rs r;
            if (ModelState.IsValid)
            {
                try
                {
                    var up = __db.Catalog.Find(model.Id);
                    up.Title = model.Title;
                    up.ThuTu = model.ThuTu;
                    up.Url = model.Url;
                    up.Target = model.Target;
                    up.CssClassDiv = model.CssClassDiv;
                    up.CssClass = model.CssClass;
                    if (file!=null&&file.ContentLength > 0)
                    {
                        string _FileName = myNumbers.LayMaNgauNhien10ChuSo() + Path.GetFileName(file.FileName);
                        string _xpath = "/user-uploads/catalog/" + _FileName;
                        string _path = Path.Combine(Server.MapPath("~/user-uploads/catalog"), _FileName);
                        file.SaveAs(_path);
                        up.HinhAnh = _xpath;
                    }
                    __db.SaveChanges();
                    r = rs.T("Success!");
                }
                catch (Exception ex)
                {
                    r = rs.F(ex.Message);
                }
                TempData["message"] = r.m;
                return RedirectToAction("Index");
            }
            return View(model);
        }
        // GET: Admin/TVAnh/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            rs r;
            try
            {
                var model = __db.Catalog.Find(id);
                __db.Catalog.Remove(model);
                __db.SaveChanges();
                r = rs.T("Ok");
            }
            catch (Exception ex)
            {
                r = rs.F("Lỗi: " + ex.Message);

            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }

    }
}