using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VD.Data.Entity.nongsan;

namespace Web.ViewModels.NongSan
{
    public class ProductLV
    {
        public string searchk { get; set; }
        public int cat { get; set; }
        public int sort { get; set; }
        public ProductCat ProductCat { get; set; }
        public IEnumerable<SelectListItem> ddlSort { get; set; }
        public IPagedList<Product> pList { get; set; }
    }
    public class ProductDetailVM
    {
        public Product Product { get; set; }
        public IQueryable<Product> pOrthers { get; set; }
    }
}