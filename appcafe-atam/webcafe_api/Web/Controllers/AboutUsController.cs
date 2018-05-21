using System.Linq;
using System.Web.Mvc;
using PagedList;
using VD.Data;
using VD.Data.Entity.MF;
using Web.ViewModels.MF;

namespace Web.Controllers
{
   
    public class AboutUsController : BaseController
    {
        vuong_cms_context __db = new vuong_cms_context();
        // GET: AboutUs
        [Route("about-us.html")]
        public ActionResult Index(int? id, int? page, string seo_title = "main")
        {
            
            if (!page.HasValue)
            {
                page = 1;
            }
            AboutUsIndexView model = new AboutUsIndexView();
            model.Id = id;
            if (id.HasValue)
            {
                model.Chinh = __db.Article.Find(id.Value);

            }
            else
            {
                var aboutusid = __setting.AboutUsMainId;
                if (aboutusid != null)
                {
                    model.Chinh = __db.Article.FirstOrDefault(f => f.CategoryId == 1 && f.Id == aboutusid);
                    if (model.Chinh == null)
                    {
                        model.Chinh = __db.Article.FirstOrDefault(f => f.CategoryId == 1);
                    }
                }
                else
                {
                    model.Chinh = __db.Article.FirstOrDefault(f => f.CategoryId == 1);
                }

            }

            if (id.HasValue)
            {
                model.LienQuan =
                    __db.Article.Where(w => w.CategoryId == 1 && w.Id != model.Chinh.Id)
                        .OrderByDescending(q => q.Id)
                        .ToPagedList(page.Value, __setting.row_per_page);
            }
            else
            {
                model.LienQuan =
                       __db.Article.Where(w => w.CategoryId == 1 &&w.Id!=model.Chinh.Id)
                           .OrderByDescending(q => q.Id)
                           .ToPagedList(page.Value, __setting.row_per_page);
            }

            return View(model);
        }

        public ActionResult PAboutUs()
        {
            var aboutusmaiid = __setting.AboutUsMainId;
            Article model;
            if (aboutusmaiid != null)
            {
                model = __db.Article.FirstOrDefault(f => f.CategoryId == 1 && f.Id==aboutusmaiid.Value);
                if (model == null)
                {
                    model = __db.Article.FirstOrDefault(f => f.CategoryId == 1);
                }
            }
            else
            {
                 model = __db.Article.FirstOrDefault(f => f.CategoryId == 1);
            }
           
            return PartialView(model);
        }
    }
}