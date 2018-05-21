using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VD.Data.Entity.nongsan;

namespace Web.ViewModels.NongSan
{
    public class ProductSectionHomepageLV
    {
        public IQueryable<Product> NEW { get; set; }
        public IQueryable<Product> SPECIAL { get; set; }
        public IQueryable<Product> SEASONAL { get; set; }
    }
}