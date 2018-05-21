
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VD.Data.Entity.MF
{
    public class CTDonHang:BaseEntity
    {
        public int SanPhamId { get; set; }

        public int ThucDonId { get; set; }

        [ForeignKey("SanPhamId")]
        public virtual Product SanPham { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public int GiaId { get; set; }
        public string TenGia { get; set; }
        //donhang
        public int DonHangID { get; set; }
        [ForeignKey("DonHangID")]
        public virtual DonHang DonHang { get; set; }
    }
}
