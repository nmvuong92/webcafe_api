
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OfficeOpenXml.FormulaParsing.Utilities;

namespace Web.Models.ThuanHanhMobileApp.Post
{
    public class DatHangForm : AuthToken
    {
        [Display(Name = "Họ tên (*)")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string HoTen { get; set; }

        [Display(Name = "Địa chỉ (*)")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string DiaChiNhanHang { get; set; }


        [Display(Name = "Điện thoại (*)")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string DienThoai { get; set; }

        [Display(Name = "Ghi chú")]
        [StringLength(200, ErrorMessage = "Ghi chú không vượt quá 200 ký tự")]
        public string GhiChu { get; set; }

        public List<CTDonHangForm> ChiTietDonHang { get; set; }

    }
    public class DatHangQRForm
    {
        [Display(Name = "Bàn")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public int Ban { get; set; } //0: neu hình thức là 2,3

        /// <summary>
        /// hình thức mua hàng
        /// 1: tại quán
        /// 2: mang đi
        /// 3: giao hàng
        /// </summary>
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Hình thức mua hàng")]
        public int HinhThucMuaHangId { get; set; }


        //> đối với hình thức 3
        public string DiaChiGiaoHang { get; set; }
        public string SDT { get; set; }
        //:end

        [Display(Name = "Yêu cầu khác")]
        public string YeuCauKhac { get; set; }

        [Display(Name = "Shop")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public int QuanId { get; set; }

        //mobile devices
        public string ModelNumber { get; set; } //if mobile
        public string UniqueID { get; set; } //if mobile

        public List<CTDonHangForm> ChiTietDonHang { get; set; }

    }
}