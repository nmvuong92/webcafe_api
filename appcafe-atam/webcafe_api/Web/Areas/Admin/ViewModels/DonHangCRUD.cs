using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VD.Data.Entity.MF;
using Web.ViewModels;

namespace Web.Areas.Admin.ViewModels
{
    public class DonHangCRUD:ThanhToanVM
    {
        public int Id { get; set; }
        //trạng thái giao hàng
        [Display(Name="Trạng thái giao hàng")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public int TrangThaiGiaoHangId { get; set; }

        //trạng thái thanh toán
        [Display(Name = "Trạng thái thanh toán")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public int TrangThaiThanhToanId { get; set; }
        public IEnumerable<SelectListItem> ddlTrangThaiGiaoHang { get; set; }
        public IEnumerable<SelectListItem> ddlTrangThaiThanhToan { get; set; }
        public DonHang entity { get; set; }

        [Display(Name = "Ghi chú đơn hàng")]
        public string GhiChuDonHang { get; set; }
    }
}