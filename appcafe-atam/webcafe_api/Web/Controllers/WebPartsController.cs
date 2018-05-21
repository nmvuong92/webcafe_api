using System.Collections.Generic;
using System.Web.Mvc;
using VD.Data;
using VD.Data.Entity;
using VD.Data.Entity.MF;
using VD.Data.IRepository;
using VD.Lib;
using Web.ViewModels;
using Web.ViewModels.WebParts;
using System.Linq;
namespace Web.Controllers
{

    public class WebPartsController : BaseController
    {
        private ICounterRepository _counterRepo;
        private ILangRepository _langRepo;
        private IConfigRepository _confServ;
        private vuong_cms_context __db = new vuong_cms_context();
        public WebPartsController(
            ICounterRepository _counterRepo,
            ILangRepository _langRepo,
            IConfigRepository _confRepo
            )
        {
            this._counterRepo = _counterRepo;
            this._langRepo = _langRepo;
            this._confServ = _confRepo;
        }

        public PartialViewResult SelectLanguage()
        {
            ViewBag.__langid = __langid;
            IEnumerable<Lang> viewmodel = _langRepo.GetList(orderBy: q => q.OrderBy(o => o.Order));
            return PartialView(viewmodel);
        }
        [ChildActionOnly]
        public PartialViewResult Footer()
        {
            vuong_cms_context __db = new vuong_cms_context();
            FooterView model = new FooterView()
            {
                Statistic = this._counterRepo.GetCounter(),
                DanhMucSanPhamChinh =  new List<ProductCat>(),
                DsBaiVietFooter = __db.Article.Where(w=>w.CategoryId==3).OrderByDescending(q=>q.ModifiedDate).ToList()
            };
            
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Meta()
        {
            return PartialView();
        }
         

        [ChildActionOnly]
        public PartialViewResult Header()
        {
            vuong_cms_context __db = new vuong_cms_context();

            HeaderView model = new HeaderView();
            model._current_culture = base.__langid;
            model.ProductCats = __db.ProductCat.ToList();
            model.Langs = _langRepo.GetList(orderBy: q => q.OrderBy(o => o.Order));

            if (mySessions.Get("gio_hang") == null)
            {
                model.SLSPGioHang = 0;
            }
            else
            {
                model.SLSPGioHang = ((GioHang)mySessions.Get("gio_hang")).CTGioHangs.Count;
            }
         
            return PartialView(model);
        }
     
        [ChildActionOnly]
        public PartialViewResult JobMenu()
        {
            return PartialView();
        }

        [OutputCache(Duration = 3600)]
        public PartialViewResult Favicon()
        {
            return PartialView();
        }


       
        public PartialViewResult AppMenu()
        {
            return PartialView();
        }

        public PartialViewResult PSlider()
        {
            var model = __db.Slider.OrderBy(q => q.Order).ToList();
            return PartialView(model);
        }
    }
}