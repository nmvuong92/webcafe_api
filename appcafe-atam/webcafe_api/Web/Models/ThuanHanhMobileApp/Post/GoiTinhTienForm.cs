using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.ThuanHanhMobileApp.Post
{
    public class GoiTinhTienForm
    {
        [Display(Name = "Mã đơn hàng")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public int DonHangID { get; set; }

        [Display(Name = "Tiền khách đưa")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public int TienKhachDua { get; set; }

    }
}