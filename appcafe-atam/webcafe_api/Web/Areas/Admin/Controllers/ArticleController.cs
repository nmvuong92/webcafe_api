using System.Collections.Generic;
using AutoMapper;
using System;

using System.Linq;
using System.Net;
using System.Transactions;
using System.Web.Mvc;
using Ninject;
using VD.Data;
using VD.Data.Base;
using VD.Data.Entity.MF;
using VD.Data.IRepository;
using VD.Data.Paging;


using VD.Lib.DTO;
using VD.Lib.Encode;
using Web.Areas.Admin.ViewModels.MF;
using Web.Controllers;
using Web.Security;

namespace Web.Areas.Admin.Controllers
{
       [myAuth(Roles = "1")]
    public class ArticleController : BaseController
    {
        private IArticleRepository _ArticleServ;
        vuong_cms_context __db = new vuong_cms_context();
        public ArticleController(
            IArticleRepository _ArticleServ)
        {
            this._ArticleServ = _ArticleServ;

        }

        [NonAction]
        public IEnumerable<SelectListItem> getddlCategory()
        {
            return __db.Category.Select(s => new SelectListItem()
            {
                Text = s.Name,
                Value = s.Id.ToString()
            }).ToList();
        } 

        public ActionResult Index()
        {
          
            Article vm = new Article();
            ViewBag.ddlCategory = getddlCategory();
            return View(vm);
        }

        [HttpPost]
        public PartialViewResult ajax_paging(article_sp paging)
        {
            PG<Article> vmpg;
            vmpg = _ArticleServ.GetQueryPaging(paging);
            var tim = __db.Settings.Find(1);

            ViewBag.AboutUsMainId = tim.AboutUsMainId;
            return PartialView(vmpg);
        }

        public ActionResult Create()
        {
            ViewBag.ddlCategory = getddlCategory();
            ArticleCRUD model = new ArticleCRUD();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public JsonResult Create(ArticleCRUD model)
        {
            rs r;
            try
            {
                Article entity = new Article();
                entity.CategoryId = model.CategoryId;
                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ImageThumbnail = model.ImageThumbnail;
                entity.SEOTitle = model.SEOTitle;
                entity.Description = model.Description;
                entity.FontAwesomeIcon = model.FontAwesomeIcon;
                __db.Article.Add(entity);
                __db.SaveChanges();
                r = rs.T("Okay");
            }
            catch (Exception ex)
            {
                r = rs.F("Lỗi: " + ex.Message);
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }

        public ActionResult Edit(int id)
        {
            Article entity = _ArticleServ.GetEntry(id);
            
            ArticleCRUD vm = new ArticleCRUD();
            vm.Id = entity.Id;
            ViewBag.ddlCategory = getddlCategory();

            vm.CategoryId = entity.CategoryId;
            vm.Title = entity.Title;
            vm.Content = entity.Content;
            vm.ImageThumbnail = entity.ImageThumbnail;
            vm.SEOTitle = entity.SEOTitle;
            vm.Description = entity.Description;
            vm.FontAwesomeIcon = entity.FontAwesomeIcon;
       
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public JsonResult Edit(ArticleCRUD model)
        {
            rs r;
            using (var trans = new TransactionScope())
            {
                try
                {
                    var entity = _ArticleServ.SingleOrDefault(s => s.Id == model.Id);
                    entity.CategoryId = model.CategoryId;
                    entity.Title = model.Title;
                    entity.Content = model.Content;
                    entity.ImageThumbnail = model.ImageThumbnail;
                    entity.SEOTitle = model.SEOTitle;
                    entity.Description = model.Description;
                    entity.FontAwesomeIcon = model.FontAwesomeIcon;
                    _ArticleServ.Save();
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
                Article Article = _ArticleServ.GetEntry(id);

                _ArticleServ.Delete(Article);
                _ArticleServ.Save();


                r = rs.T("Ok");
            }
            catch (Exception ex)
            {
                r = rs.F("Lỗi: " + ex.Message);

            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }
          [HttpPost]
        public ActionResult SetMainAboutUs(int id)
        {
            rs r;
            try
            {

                var tim = __db.Settings.Find(1);
                tim.AboutUsMainId = id;
                __db.SaveChanges();
                CacheServ.ClearAll();

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
                            __db.Database.ExecuteSqlCommand("DELETE FROM Articles WHERE Id=" + idmess);
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
    }
}
