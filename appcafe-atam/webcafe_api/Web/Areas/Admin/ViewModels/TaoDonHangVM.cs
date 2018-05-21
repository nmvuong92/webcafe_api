using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.Admin.ViewModels
{
    public class TaoDonHangVM
    {
        public int DonHangId { get; set; }
        public List<GioHangVM> GioHang { get; set; }
        public int Ban { get; set; }
        public string GhiChu { get; set; }
        public int QuanId { get; set; }

        public int HinhThucMuaHangId { get; set; }
        public int TrangThaiGiaoHangId { get; set; }
        public int TrangThaiThanhToanId { get; set; }

        public string SDT { get; set; }
        public string YeuCauKhac { get; set; }
        public string DiaChiGiaoHang { get; set; }
    }

    public class GioHangVM
    {
        public int ProductId { get; set; }
        public int Price { get; set; }
        public int SoLuong { get; set; }
        public int ThucDonId { get; set; }

        public int ThanhTien
        {
            get { return this.Price*this.SoLuong; }
        }
    }
}