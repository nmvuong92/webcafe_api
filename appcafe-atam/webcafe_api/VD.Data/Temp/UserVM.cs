using System.ComponentModel.DataAnnotations;

namespace VD.Data.Temp
{
    public class UserVM
    {
        public int ID { get; set; }
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Display(Name = "Điện thoại")]
        public string DienThoai { get; set; }
    }
}
