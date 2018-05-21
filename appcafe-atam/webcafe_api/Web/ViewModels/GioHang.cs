using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VD.Lib;

namespace Web.ViewModels
{
    public class GioHang
    {
        public GioHang()
        {
            this.CTGioHangs= new List<CTGioHang>();
        }
        
        public int SoLuongSanPham
        {
            get { return this.CTGioHangs.Count; }
        }

        public decimal TongTienHang
        {
            get { return this.CTGioHangs.Sum(s => s.SoLuong*s.DonGia); }
        }

        public int GiaShip { get; set; }
        public int PTVat
        {
            get { return 0; }
        }
        public decimal TienVat
        {
            get { return this.TongTienHang * this.PTVat / 100; }
        }

        public decimal ThanhTien
        {
            get { return this.TongTienHang + this.TienVat; }
        }

        public List<CTGioHang> CTGioHangs { get; set; }

        public static GioHang Lay()
        {
            var ss_gio_hang = mySessions.Get("gio_hang");
            GioHang gio_hang;
            if (ss_gio_hang == null)
            {
                gio_hang = new GioHang();
                mySessions.Set("gio_hang", gio_hang);
            }
            else
            {
                gio_hang = (GioHang)ss_gio_hang;
            }
            gio_hang.GiaShip = 0;
            return gio_hang;
        }
        public  static void ThemSanPham(CTGioHang ct)
        {
            var ss_gio_hang = mySessions.Get("gio_hang");
            GioHang gio_hang;
            if (ss_gio_hang == null)
            {
                gio_hang = new GioHang();
            }
            else
            {
                gio_hang = (GioHang)ss_gio_hang;
            }
            var exists = gio_hang.CTGioHangs.FirstOrDefault(w => w.SanPhamId == ct.SanPhamId);
            if (exists != null)
            {
                exists.SoLuong += ct.SoLuong;
            }
            else
            {
                gio_hang.CTGioHangs.Add(ct);
            }
            mySessions.Set("gio_hang", gio_hang);
        }
        public static void XoaSP(int idsp)
        {
            var ss_gio_hang = mySessions.Get("gio_hang");
            if (ss_gio_hang != null)
            {
                var gio_hang = (GioHang)ss_gio_hang;
                gio_hang.CTGioHangs.Remove(gio_hang.CTGioHangs.FirstOrDefault(w => w.SanPhamId == idsp));
            }
        }

        public static void CapNhatSL(int idsp, int sl)
        {
            var ss_gio_hang = mySessions.Get("gio_hang");
            if (ss_gio_hang != null)
            {
                var gio_hang = (GioHang)ss_gio_hang;
                var up = (gio_hang.CTGioHangs.FirstOrDefault(w => w.SanPhamId == idsp));
                up.SoLuong = sl;
            }
        }
        
    }

    public class CTGioHang
    {
        public int SanPhamId { get; set; }
        public string TenSanPham { get; set; }
        public string HinhAnh { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public string Link { get; set; }

        public decimal ThanhTien
        {
            get { return this.SoLuong*this.DonGia; }
        }
    }
}