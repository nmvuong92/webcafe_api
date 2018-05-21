using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ViewModels.Form;

namespace Web.Areas.Admin.ViewModels.MF
{
    public class BanCRUD:BaseInput
    {
        [Display(Name = "Mã bàn")]
        [MaxLength(200)]
        public string MaBan { get; set; }


        [Display(Name = "Tên bàn")]
        [Required(ErrorMessage = "Hãy nhập {0}")]
        [MaxLength(200)]
        public string TenBan { get; set; }


        [Display(Name = "STT")]
        public int STT { get; set; }

        //bàn thuộc quán nào
        [Required(ErrorMessage = "Hãy chọn {0}")]
        [Display(Name = "Quán")]
        public int QuanId { get; set; }
        //
        public IEnumerable<SelectListItem> ddlQuan { get; set; } 
    }
}