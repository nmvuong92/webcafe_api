using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.User
{
    public class pLoginVM
    {
        [Required(ErrorMessage = "Hãy nhập {0}")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Hãy nhập {0}")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}