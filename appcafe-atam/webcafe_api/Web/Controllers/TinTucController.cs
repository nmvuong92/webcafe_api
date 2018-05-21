using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using VD.Data;
using Web.ViewModels.MF;

namespace Web.Controllers
{

    public class TinTucController : BaseController
    {
        vuong_cms_context __db = new vuong_cms_context();
        // GET: TinTu
        [Route("news.html")]
        public ActionResult Index(int page = 1)
        {
            TinTucView model = new TinTucView();
            model.List =
                __db.Article.Where(w => w.CategoryId == 2)
                    .OrderByDescending(d => d.CreatedDate)
                    .ToPagedList(page, __setting.row_per_page);
            model.XemNhieu = __db.Article.Where(w => w.CategoryId == 2).OrderByDescending(o => o.LuotXem).Take(5).ToList();
            return View(model);
        }

        [Route("news/read/{seo_title}/{id}.html")]
        public ActionResult Detail(int id, string seo_title = "")
        {
            var baiviet = __db.Article.Find(id);
            baiviet.LuotXem += 1;
            __db.SaveChanges();
            
            TinTucChiTietView model = new TinTucChiTietView();
            model.BaiViet = baiviet;
            model.LienQuan = __db.Article.Where(w => w.CategoryId == model.BaiViet.CategoryId).OrderByDescending(q=>q.CreatedDate).Take(8).ToList();
            return View(model);
        }

        public ActionResult HuongDanMuaHang()
        {
            var sss = __db.Article.FirstOrDefault(w => w.CategoryId == 3);
            if (sss != null)
            {
                return RedirectToAction("Detail", new {seo_title = sss.SEOTitle, sss.Id});
            }
            return Content("Bài viết không tồn tại!");
        }

        public ActionResult PartialHuongDanMuaHang()
        {
            var sss = __db.Article.FirstOrDefault(w => w.CategoryId == 3);
            if (sss != null)
            {
                return PartialView(sss);
            }
            return Content("Bài viết không tồn tại!");
        }
    }
}