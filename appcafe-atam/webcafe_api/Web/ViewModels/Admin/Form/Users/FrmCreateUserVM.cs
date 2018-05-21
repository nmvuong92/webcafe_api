using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VD.Data.Entity.MF;

namespace Web.ViewModels.Admin.Form.Users
{
    public class FrmCreateUserVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Hãy nhập {0}")]
        [Display(Name = "Tài khoản")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Hãy nhập {0}")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Hãy nhập {0}")]
        [Display(Name = "Họ và tên")]
        public string Fullname { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Điện thoại")]
        public string Phone { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string Image { get; set; }
        [Display(Name = "Quyền hạn")]
        public int RoleId { get; set; }
        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }


        public IEnumerable<SelectListItem> ddlGioiTinh { get; set; }


        public string[] QuanIds { get; set; }

        public List<int> QuanIntIDs
        {
            get
            {
                if (this.QuanIds != null)
                {
                    return Array.ConvertAll(this.QuanIds, int.Parse).ToList();
                }
                else
                {
                    return new List<int>();
                }
            }
        }

        //ddl usser
        public IEnumerable<Quan> DanhSachQuan { get; set; }
        public List<int> DanhSachQuanChon { get; set; }
    }
}