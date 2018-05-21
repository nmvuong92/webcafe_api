using System.ComponentModel.DataAnnotations;

namespace VD.Data.Temp
{
    public class TemplateVM
    {
        [Display(Name = "Email robot gửi")]
        public string sysEmailGui { get; set; }
        [Display(Name = "Mật khẩu")]
        public string sysEmaillGuiMatKhau { get; set; }

        [Display(Name = "Mẫu phản hồi")]
        public string sysTemplatePhanHoi { get; set; }

        [Display(Name = "Gửi email phản hồi tự động?")]
        public bool sysIsSendEmailPhanHoi { get; set; }
        [Display(Name = "Tiêu đề phản hồi")]
        public string sysTemplateTieuDePhanHoi { get; set; }
    }
}
