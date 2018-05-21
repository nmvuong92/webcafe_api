using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VD.Data.Entity.nongsan;

namespace Web.ViewModels.NongSan
{
    public class OrderProductFrm
    {
        [Required]
        [Display(Name = "Product")]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string HoTen { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string DiaChi { get; set; }
        [Required]
        [Display(Name = "Phone number")]
        public string SDT { get; set; }
        [EmailAddress]
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Other requirements")]
        public string YeuCauKhac { get; set; }

        //
        public Product Product { get; set; }

    }
}