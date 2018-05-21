using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Form
{
    public class FrmResetPwView
    {
        public string key { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "password must be between 5 and 30 characters", MinimumLength = 5)]
        [Display(Name = "New password")]
        public string Password { get; set; }

        
        [System.Web.Mvc.Compare("Password", ErrorMessage = "Confirm password not match!")]
        [Required]
        [Display(Name = "Confirm new password")]
        public string ne_Repassword { get; set; }

        public string Email { get; set; }

    }
}