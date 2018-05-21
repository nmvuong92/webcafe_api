using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.ViewModels
{
    public class ContactCRUD : Input
    {
        [Required]
        public string HoTen { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string TieuDe { get; set; }
        [Required]
        public string NoiDung { get; set; }
        [Required]
        public string Captcha { get; set; }
        [Required]
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string CompanyName { get; set; }

        //
        public string GhiChu { get; set; }

        public int ContactStatusId { get; set; }

        public IEnumerable<SelectListItem> ddlContactStatus { get; set; }
    }
}