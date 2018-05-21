
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.BQC
{
    public class CapNhatUserVM
    {

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string Fullname { get; set; }


        [Display(Name = "Email đăng nhập")]
        public string Username { get; set; }
        

        [Display(Name = "Số điện thoại liên hệ")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string Phone { get; set; }


        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string Address { get; set; }
    }
}