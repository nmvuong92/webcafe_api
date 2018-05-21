using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VD.Data.Entity.MF;

namespace Web.Areas.Admin.ViewModels
{
    public class ThucDonSelectVM:ThucDon
    {
        public List<ThucDonCTSelectVM> ThucDonCTSelectVM { get; set; }
    }

    public class ThucDonCTSelectVM : ThucDonCT
    {
        public int SoLuong { get; set; }
    }

    public class ProductThucDonVM : Product
    {
        public int GiaId { get; set; }
        public int Price { get; set; }
    }
}