using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VD.Data;
using Web.ViewModels.MF;

namespace Web.Controllers
{
    public class CatalogController : BaseController
    {
        vuong_cms_context __db = new vuong_cms_context();
        // GET: Catalog
        [Route("catalog.html")]
        public ActionResult Index(int? id)
        {
            CatalogView vm = new CatalogView();
            if (id.HasValue)
            {
                vm.main = __db.Catalog.FirstOrDefault(f => f.Id == id);
            }
            else
            {
                vm.main = __db.Catalog.FirstOrDefault();
            }
            vm.List = __db.Catalog.ToList();

            return View(vm);
        }

        public PartialViewResult SectionHomepage()
        {
            var model = __db.Catalog.OrderBy(o=>o.ThuTu).AsQueryable();
            return PartialView(model);
        }
    }
}