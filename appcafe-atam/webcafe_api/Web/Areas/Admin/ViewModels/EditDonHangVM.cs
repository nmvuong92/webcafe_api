using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VD.Data.Entity.MF;

namespace Web.Areas.Admin.ViewModels
{
    public class DonHangVM : DonHang
    {
        public List<ThucDonCTSLVM> ThucDonVMs { get; set; }

        public List<GopYJson> DSGopYJson { get; set; } 
    }

    public class GopYJson
    {
        public int Id { get; set; }
        public string NoiDungGopY { get; set; }
        public string ThoiGian { get; set; }
    }
    public class ThucDonCTSLVM : ThucDonCT
    {
        public int GiaId { get; set; }
        public string TenGia { get; set; }
        public int SoLuong { get; set; }
    }
}