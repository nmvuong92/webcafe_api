using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Web.ViewModels.MF
{
    public class FrmLienHeView : BaseConfigVM
    {
        [Display(Name = "Họ và tên")]
        [Required]
        public string HoTen { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email address isvalid!")]
        [Required]
        public string Email { get; set; }


        [StringLength(500, ErrorMessage = "Topic 10-500 characters", MinimumLength = 10)]
        [Display(Name = "Tiêu đề")]
        [Required]
        public string TieuDe { get; set; }



        [Display(Name = "Nội dung")]
        [AllowHtml]
        [StringLength(3000, ErrorMessage = "Nội dung 10-3000 characters", MinimumLength = 10)]
        [Required]
        public string NoiDung { get; set; }

        [Display(Name = "Mã captcha")]
        [Required]
        public string Captcha { get; set; }


        [Display(Name = "Số điện thoại")]
        [StringLength(15, ErrorMessage = "Phone number isvalid", MinimumLength = 9)]
        [Required]
        public string SDT { get; set; }
   
    }
}