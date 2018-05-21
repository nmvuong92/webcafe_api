
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Web.ViewModels.Form
{
    public class demoVM
    {
        [Required(ErrorMessage = "input {0}")]
        public string name { get; set; }
        [Required(ErrorMessage = "input {0}")]
        public string gender { get; set; }

        public HttpPostedFileBase UploadedFile { get; set; }
    }
}