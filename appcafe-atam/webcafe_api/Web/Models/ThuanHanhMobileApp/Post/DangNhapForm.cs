using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.ThuanHanhMobileApp.Post
{
    public class DangNhapForm
    {
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Hãy nhập {0}")]
        public string CMND { get; set; }


        [Required(ErrorMessage = "Hãy nhập {0}")]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }
    }
}