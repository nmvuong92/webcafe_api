using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class ThanhToanVM
    {
        [Display(Name = "Họ Tên(*)")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string HoTen { get; set; }


        [Display(Name = "Địa chỉ giao hàng (*)")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string DiaChiGiaohang { get; set; }
     

        [Display(Name = "Điện thoại (*)")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string DienThoai { get; set; }
    }

}