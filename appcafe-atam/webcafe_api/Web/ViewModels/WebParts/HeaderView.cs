using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VD.Data.Entity;
using VD.Data.Entity.MF;

namespace Web.ViewModels.WebParts
{
    public class HeaderView
    {
        public int _current_culture { get; set; }
        public IEnumerable<Lang> Langs { get; set; }
        public IEnumerable<ProductCat> ProductCats { get; set; }
        public int SLSPGioHang { get; set; }
      
    }
}