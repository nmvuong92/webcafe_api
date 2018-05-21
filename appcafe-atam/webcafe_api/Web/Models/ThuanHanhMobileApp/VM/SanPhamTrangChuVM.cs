using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.ThuanHanhMobileApp.VM
{
    public class SanPhamTrangChuVM
    {
        public IEnumerable<SanPham> HOT { get; set; }
        public IEnumerable<SanPham> NEW { get; set; }
    }
}