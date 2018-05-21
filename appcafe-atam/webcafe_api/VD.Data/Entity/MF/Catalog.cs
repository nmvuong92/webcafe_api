using System.ComponentModel.DataAnnotations;

namespace VD.Data.Entity.MF
{
    public class Catalog:BaseEntity
    {
        [Display(Name="Tiêu đề")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string Title { get; set; }

        [Display(Name = "Liên kết")]
        public string Url { get; set; }

        [Display(Name = "Loại kiên kết")]
        public string Target { get; set; }

        [Display(Name = "Thứ tự")]
        public string ThuTu { get; set; }

        [Display(Name = "Hình ảnh")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string HinhAnh { get; set; }


        [Display(Name = "Css class cột")]
        public string CssClassDiv { get; set; }


        [Display(Name = "Css class ảnh")]
        public string CssClass { get; set; }

    }
}
