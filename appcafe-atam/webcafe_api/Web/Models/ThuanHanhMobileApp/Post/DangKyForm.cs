using System.ComponentModel.DataAnnotations;

namespace Web.Models.ThuanHanhMobileApp.Post
{
    public class DangKyForm
    {
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Hãy nhập {0}")]
        public string HoTen { get; set; }

        [Display(Name = "Số điện thoại (Phone number)")]
        [Required(ErrorMessage = "Hãy nhập {0}")]
        public string CMND { get; set; }

        [Display(Name = "Địa chỉ email")]
        
        public string Email { get; set; }

        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }


        [Display(Name = "Số điện thoại")]
        public string DienThoai { get; set; }


        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }

        [Display(Name = "xác nhận mật khẩu")]
        [Compare("MatKhau", ErrorMessage = "Xác nhận mật khẩu không đúng!")]
        public string XacNhanMatKhau { get; set; }


    }
}