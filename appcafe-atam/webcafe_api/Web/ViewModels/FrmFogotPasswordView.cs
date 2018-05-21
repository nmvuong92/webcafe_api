
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class FrmFogotPasswordView
    {
        [Display(Name = "Email address")]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]

        public string Email { get; set; }
        [Required]
        [Display(Name = "Captcha code")]
        public string Captcha { get; set; }
        public string ButtonSubmitText { get; set; }
    }
}