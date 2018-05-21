using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VD.Data;

namespace Web.Controllers
{
    public class ProductCatController : Controller
    {
        vuong_cms_context __db = new vuong_cms_context();
        // GET: ProductCat
        public ActionResult PMenuDeQuy()
        {
            var parent = __db.ProductCat.OrderBy(q=>q.Order).ToList();
            return PartialView(parent);
        }

      


    }
}