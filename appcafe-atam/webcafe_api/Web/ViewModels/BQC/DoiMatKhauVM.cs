using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.ViewModels.BQC
{
    public class DoiMatKhauVM
    {
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Mật khẩu hiện tại")]
        public string MatKhauHienTai { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Mật khẩu mới")]
        public string MatKhauMoi { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("MatKhauMoi", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string XacNhanMatKhauMoi { get; set; }
    }
}