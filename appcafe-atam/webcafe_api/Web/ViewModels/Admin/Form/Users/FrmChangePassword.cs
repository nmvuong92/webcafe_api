using System.ComponentModel.DataAnnotations;
namespace Web.ViewModels.Admin.Form.Users
{
    public class FrmChangePassword
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Tài khoản")]
        public string TenDangNhap { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Mật khẩu hiện tại")]
        public string MatKhauCu { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Mật khẩu mới")]
        public string MatKhauMoi { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Nhập lại mật khẩu mới")]
        [Compare("MatKhauMoi", ErrorMessage = "Mật khẩu mơi và mật khẩu xác nhận không khớp")]
        public string ReMatKhauMoi { get; set; }
    }
}
