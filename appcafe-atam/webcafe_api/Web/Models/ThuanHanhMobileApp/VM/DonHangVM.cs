using System.Collections.Generic;
using VD.Data.Entity.MF;
using VD.Lib;
using Web.Models.BQC;

namespace Web.Models.ThuanHanhMobileApp.VM
{
  
    public class DonHangVM
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string DiaChiNhanHang { get; set; }
        public string SDT { get; set; }
        public decimal TongTienHang { get; set; }
        public string GhiChuDonHang { get; set; }
        public HTTTVM HTTT { get; set; }
        public string NgayDatHang { get; set; }
        public int SoLanGoiTinhTien { get; set; }
        public int Ban { get; set; }
        public string MaDonHang
        {
            get { return "TH"+this.Id; }
        }

        public int DiemTichLuy
        {
            get
            {
                if (this.TrangThaiThanhToan.Id == 2)
                {
                    return (int)this.TongTienHang;
                }
                else
                {
                    return 0;
                }
            }
        }

        public TrangThaiGiaoHangVM TrangThaiGiaoHang { get; set; }
        public int HinhThucMuaHangId { get; set; }
        public HinhThucMuaHang HinhThucMuaHang { get; set; }
        public TrangThaiThanhToan TrangThaiThanhToan { get; set; }
        public int UserId { get; set; }
        public virtual List<CTDonHangVM> CTDonHangs { get; set; }


        public UserClient User { get; set; }
        public static DonHangVM map(DonHang item)
        {
            DonHangVM donhangClient = new DonHangVM
            {
                Id = item.Id,
                GhiChuDonHang = item.GhiChuDonHang,
                TongTienHang = item.TongTienHang,
                NgayDatHang = item.CreatedDate.XuatDate(),
                SoLanGoiTinhTien = item.SoLanGoiTinhTien, 
                Ban=item.Ban??0,
                TrangThaiGiaoHang = new TrangThaiGiaoHangVM()
                {
                    Id = item.TrangThaiGiaoHangId,
                    Ten = item.TrangThaiGiaoHang.Ten,
                },
                TrangThaiThanhToan = new TrangThaiThanhToan()
                {
                    Id = item.TrangThaiThanhToanId,
                    Ten = item.TrangThaiThanhToan.Ten
                },
                HinhThucMuaHang = new HinhThucMuaHang()
                {
                    Id = item.HinhThucMuaHangId,
                    Ten = item.HinhThucMuaHang.Ten,
                },
                HinhThucMuaHangId = item.HinhThucMuaHangId
            };
            donhangClient.CTDonHangs = new List<CTDonHangVM>();
            foreach (var ctDonHang in item.CTDonHangs){
                donhangClient.CTDonHangs.Add(new CTDonHangVM()
                {
                    DonGia = ctDonHang.DonGia,
                    SoLuong = ctDonHang.SoLuong,
                    ThanhTien = ctDonHang.ThanhTien,
                    SanPham = SanPham.map(ctDonHang.SanPham,ctDonHang.Id)
                });
            }
            return donhangClient;
        }
        public static List<DonHangVM> map(IEnumerable<DonHang> data)
        {
            List<DonHangVM> lst = new List<DonHangVM>();
            foreach (var item in data)
            {
                lst.Add(map(item));
            }
            return lst;
        }
    }
}