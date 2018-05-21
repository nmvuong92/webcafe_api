using System.ComponentModel.DataAnnotations;
using Web.ViewModels.Form;

namespace Web.Areas.Admin.ViewModels.MF
{
    public class ArticleCRUD : BaseInput
    {
        [Required]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Tiêu đề SEO")]
        public string SEOTitle { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Mô tả ngắn")]
        public string Description { get; set; }
        [Display(Name = "Ảnh")]
        public string ImageThumbnail { get; set; }
        [Display(Name = "Danh mục")]
        public int CategoryId { get; set; }

        [Display(Name = "Biểu tượng font-awesome")]
        public string FontAwesomeIcon { get; set; }
    }
}