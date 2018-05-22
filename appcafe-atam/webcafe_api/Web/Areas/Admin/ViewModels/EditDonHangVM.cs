using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VD.Data.Entity.MF;

namespace Web.Areas.Admin.ViewModels
{
    public class DonHangVM : DonHang
    {
        public List<ThucDonCTSLVM> ThucDonVMs { get; set; }

        public List<GopYJson> DSGopYJson { get; set; } 
    }

    public class GopYJson
    {
        public int Id { get; set; }
        public string NoiDungGopY { get; set; }
        public string ThoiGian { get; set; }
        public string NoiDungPhanHoiMoi { get; set; }
        public List<GopYReplyJson> Replies { get; set; }
    }
      public class GopYReplyJson
    {
        public int Id { get; set; }
        public string NoiDung { get; set; }
        public string NguoiPhanHoi { get; set; }
        public string ThoiGian { get; set; }
       
    }
    public class ThucDonCTSLVM : ThucDonCT
    {
        public int GiaId { get; set; }
        public string TenGia { get; set; }
        public int SoLuong { get; set; }
    }

    public class ReplyPhanHoiForm
    {
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public int DonHangId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public int GopYId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Nội dung phản hồi")]
        public string NoiDungPhanHoi { get; set; }
    }
}