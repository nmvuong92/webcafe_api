
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VD.Data.Entity.MF
{
    public class DonHang : BaseEntity
    {
        public DonHang()
        {
            this.DeviceType = 1;//web : 2//mobile
        }

        [Required]
        [Display(Name = "Tổng tiền hàng")]
        public decimal TongTienHang { get; set; }


        [Display(Name = "Ghi chú đơn hàng")]
        public string GhiChuDonHang { get; set; }


        //bàn nào?
        /*[Display(Name = "Bàn")]
        public int? BanId { get; set; }
        [ForeignKey("BanId")]
        public virtual Ban Ban { get; set; }*/
         [Display(Name = "Bàn số")]
        public int? Ban { get; set; }

        //trạng thái giao hàng
        [Display(Name = "Giao hàng")]
        public int TrangThaiGiaoHangId { get; set; }
        [ForeignKey("TrangThaiGiaoHangId")]
        public virtual TrangThaiGiaoHang TrangThaiGiaoHang { get; set; }


        //trạng thái thanh toán
        [Display(Name = "Thanh toán")]
        public int TrangThaiThanhToanId { get; set; }

        [ForeignKey("TrangThaiThanhToanId")]
        public virtual TrangThaiThanhToan TrangThaiThanhToan { get; set; }

        //user nào tạo?
        [Display(Name = "Người tạo")]
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        //quán nào
        [Display(Name = "Quán")]
        public int QuanId { get; set; }
        [ForeignKey("QuanId")]
        public virtual Quan Quan { get; set; }


        //user nào tạo?
        [Display(Name = "Chủ sở hữu")]
        public int BaseUserId { get; set; }
        [ForeignKey("BaseUserId")]
        public virtual User BaseUser { get; set; }

        public int DeviceType { get; set; }
        //mobile devices
        public string ModelNumber { get; set; } //if mobile
        public string UniqueID { get; set; } //if mobile

        //số lần tính tiền
        public int SoLanGoiTinhTien { get; set; }
        public DateTime? LanCuoiGoiTinhTien { get; set; }

        //hình thức mua hàng
        public int HinhThucMuaHangId { get; set; }
        [ForeignKey("HinhThucMuaHangId")]

        public virtual HinhThucMuaHang HinhThucMuaHang { get; set; }

        //> đối với hình thức 3
        public string DiaChiGiaoHang { get; set; }
        public string SDT { get; set; }
        //:end

        [Display(Name = "Yêu cầu khác")]
        public string YeuCauKhac { get; set; }


        [Display(Name = "Tiền khách đưa")]
        public int TienKhachDua { get; set; }

        [NotMapped]
        [Display(Name = "Tiền thối lại")]
        public int TienThuaThoiLai
        {
            get { return this.TienKhachDua - (int)this.TongTienHang; }
        }

        //chi tiết đơn hàng
        public virtual ICollection<CTDonHang> CTDonHangs { get; set; }
       //góp ý
        public virtual ICollection<GopY> GopYs { get; set; } 
    }
}
