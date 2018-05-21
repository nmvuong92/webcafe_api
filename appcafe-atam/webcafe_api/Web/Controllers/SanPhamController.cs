using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.Mvc;
using PagedList;
using VD.Data;
using VD.Data.Entity.MF;
using Web.ViewModels.MF;
using Product = VD.Data.Entity.MF.Product;

namespace Web.Controllers
{
    [RoutePrefix("products")]
    public class SanPhamController : BaseController
    {
        vuong_cms_context __db = new vuong_cms_context();
        public PartialViewResult PSanPhamChinh()
        {
            IEnumerable<Product> main =
                __db.Product.OrderByDescending(q => q.Id).Take(20);
            return PartialView(main);
        }
        [Route("index/{catid?}")]
        public ActionResult Index(int? catid, int page = 1)
        {
            if (!catid.HasValue)
            {
                return RedirectToAction("AllProduct");
            }

            ProductIndexByCatView view = new ProductIndexByCatView();
            view.ProductCat = __db.ProductCat.Find(catid);
            view.ProductCatRelated = new List<ProductCat>();

            view.Products =
                __db.Product.Where(w => w.ProductCatId == catid.Value).OrderBy(o => o.Id).ToPagedList(page, __setting.row_per_page);
            return View(view);
        }
        [Route("all-product.html")]
        public ActionResult AllProduct()
        {
            return View();
        }
        [Route("detail/{seo_title}/{id}.html")]
        public ActionResult Detail(int id)
        {
            var model = __db.Product.FirstOrDefault(w => w.Id == id);
            var vm = new ChiTietSanPhamView();
            vm.Id = id;
            vm.SanPham = model;
            vm.DanhMucLienQuan = new List<ProductCat>();
            vm.SanPhamLienQuan =
                __db.Product.Where(w => w.ProductCatId == model.ProductCatId)
                    .OrderBy(o => o.Id)
                    .Take(8).ToList();
            return View(vm);
        }

        public PartialViewResult SanPhamBanChay()
        {
            IEnumerable<Product> model =
                __db.Product.OrderByDescending(o => o.CreatedDate).Take(8).ToList();

            return PartialView(model);
        }
        [HttpGet]
        public JsonResult AjaxGetCatShow()
        {
          
            using (var _mycontext = new vuong_cms_context())
            {
                _mycontext.Configuration.LazyLoadingEnabled = false;
                _mycontext.Configuration.ProxyCreationEnabled = false;

                var rs = _mycontext.ProductCat.Select(s=>new {
                    s.Id,
                    s.Name
                }).ToList();
                return Json(rs, JsonRequestBehavior.AllowGet);
            }
        }
        public PartialViewResult AjaxPartialProductByCat(int catid)
        {
            var view = new AjaxPartialProductByCatView();
            var cats = __db.ProductCat.Find(catid);
            view.ProductCat = cats;
            view.ProductCatRelated =new List<ProductCat>();
            view.Product8 =
                __db.Product.Where(w => w.ProductCatId == catid).OrderByDescending(q => q.Id).Take(8).ToList();
            return PartialView(view);
        }
    }
}