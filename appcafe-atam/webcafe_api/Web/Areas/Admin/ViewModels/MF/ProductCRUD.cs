using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VD.Data.Entity.MF;
using Web.ViewModels.Form;

namespace Web.Areas.Admin.ViewModels.MF
{
    public class ProductCRUD : BaseInput
    {
        [Required]
        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; }
        [Display(Name = "Thông tin chi tiết")]
        [AllowHtml]
        public string Infomation { get; set; }
        [Display(Name = "Ảnh hiển thị")]
        public string ThumbnailImage { get; set; }
        [Display(Name = "Giá niêm yết")]
        public int Price { get; set; }
        [Required]

        [Display(Name = "Danh mục")]
        public int ProductCatId { get; set; }
        [Display(Name = "Có giảm giá")]
        public bool IsGiamGia { get; set; }

        [Display(Name = "Hot?")]
        public bool Hot { get; set; }

        [Display(Name = "New?")]
        public bool New { get; set; }

        [Display(Name = "Giá khác")]

        public int SoLuongEdit { get; set; }
        public List<BangGiaCTCRUD> BangGiaCT { get; set; } 

        //
        public ProductCat ProductCat { get; set; }
    }

    public class BangGiaCTCRUD
    {
        public int Id { get; set; }
        //tên giá
        [Display(Name = "Tên giá")]
        public string Ten { get; set; }
        //price
        [Display(Name = "Giá bán")]
        public int? Price { get; set; }
    }
}