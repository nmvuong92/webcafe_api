using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.ThuanHanhMobileApp.Post
{
    public class GopYDonHangForm
    {
        [Display(Name = "Mã đơn hàng")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public int DonHangID { get; set; }


        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [MaxLength(500,ErrorMessage = "Nội dung quá dài, tối đa 500 ký tự")]
        public string NoiDung { get; set; }
    }
}