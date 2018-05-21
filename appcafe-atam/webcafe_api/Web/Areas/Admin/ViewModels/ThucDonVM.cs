using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.Admin.ViewModels
{
    public class ThucDonVM
    {
        public int Id { get; set; }
        public string TenThucDon { get; set; }
        public string Icon { get; set; }
        public int QuanId { get; set; }
        public List<ThucDonCTVM> ThucDonCT { get; set; } 
    }

    public class ThucDonCTVM
    {
        public int Id { get; set; }
        public int SanPhamId { get; set; }
        public string TenSanPham { get; set; }
        public string HinhAnh { get; set; }
        public int ThucDonId { get; set; }
        public int Gia { get; set; }
    }
}