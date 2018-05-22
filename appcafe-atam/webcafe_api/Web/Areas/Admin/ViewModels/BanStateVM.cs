using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.Admin.ViewModels
{
    public class BanStateVM
    {
        public int Ban { get; set; }
        public int SoLuongBanChuaThanhToan { get; set; }
        public int SoLuongBanChuaGiaoHang { get; set; }

        public bool Alert
        {
            get { return this.SoLuongBanChuaGiaoHang > 0 || this.SoLuongBanChuaThanhToan > 0; }
        }
    }
}