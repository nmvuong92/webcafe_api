using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.ViewModels.MF
{
    public class ProductCatCRUD
    {
        public int Id { get; set; }
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }
        [Display(Name = "Mô tả danh mục")]
        public string Description { get; set; }

        //[Display(Name = "Danh mục cha")]
        //public int? ParentId { get; set; }

        [Display(Name = "Ảnh")]
        public string ImageThumbnail { get; set; }



        //cat của quán nào?
        [Display(Name = "Quán")]
        [Required(ErrorMessage = "Hãy chọn {0}")]
        public int QuanId { get; set; }


        //
        public IEnumerable<SelectListItem> ddlQuan { get; set; } 
    }
}