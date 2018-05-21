using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.ViewModels
{
    public class ThemSanPhamGioHangVM
    {
        [Required]
        public int SanPhamId { get; set; }
           [Required]
        public int SoLuong { get; set; }
    }
}