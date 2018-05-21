using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Web.ViewModels.User
{
    public class RegisterVM
    {
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Email")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [Display(Name = "Nhập lại mật khẩu")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string CfPassword { get; set; }

        [Display(Name = "Điện thoại (*)")]
        public string Phone { get; set; }
        [Display(Name = "Địa chỉ (*)")]
        public string Address { get; set; }

        [Display(Name = "Tỉnh thành")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public int ProvinceId { get; set; }


        [Display(Name = "Phường xã")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public int WardId { get; set; }


        [Display(Name = "Quận huyện")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public int DistrictId { get; set; }

        [Display(Name = "Danh xưng")]
        public string XungDanh { get; set; }


        [Display(Name = "Họ (*)")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string Ho { get; set; }


        [Display(Name = "Tên (*)")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string Ten { get; set; }


        //
        public IEnumerable<SelectListItem> ddlProvince { get; set; }
        public IEnumerable<SelectListItem> ddlDistrict { get; set; }
        public IEnumerable<SelectListItem> ddlWard { get; set; }
        public IEnumerable<SelectListItem> ddlHttt { get; set; }
        public IEnumerable<SelectListItem> ddlXungDanh { get; set; }
    }
}