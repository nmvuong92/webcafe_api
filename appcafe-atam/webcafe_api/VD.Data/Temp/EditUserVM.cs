using System;
using System.ComponentModel.DataAnnotations;

namespace VD.Data.Temp
{
   public class EditUserVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Hãy nhập {0}")]
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }
    

        [Required(ErrorMessage = "Hãy nhập {0}")]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }


        [DataType(DataType.EmailAddress, ErrorMessage = "Email không đúng")]
        [EmailAddress]
        [Required(ErrorMessage = "Hãy nhập {0}")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
  
        public Nullable<System.DateTime> NgayDK { get; set; }
    
    }
}
