using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using OfficeOpenXml.FormulaParsing.Utilities;
using VD.Data.Entity;
using Web.ViewModels.Admin.Form.Users;
using Web.ViewModels.Form;

namespace Web.Areas.Admin.ViewModels.MF
{
    public class QuanCRUD:BaseInput
    {
        [MaxLength(100)]
        [Display(Name = "Mã quán")]
        public string MaQuan { get; set; }

        [Required(ErrorMessage = "Hãy nhập {0}")]
        [Display(Name = "Tên quán")]
        public string TenQuan { get; set; }


        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }


        [Display(Name = "Điện thoại")]
        public string DienThoai { get; set; }



        [Display(Name = "Ảnh")]
        public string ImageThumbnail { get; set; }
        [Display(Name = "Danh sách bàn")]
        public string BanArr { get; set; }
        public string[] NhanVienIDs { get; set; }

        [Required(ErrorMessage = "Vui lòng điền thông tin chủ quán")]
        public FrmCreateUserVM ChuQuan { get; set; }

        public  List<int> NhanVienIntIDs
        {
            get
            {
                if (this.NhanVienIDs!=null)
                {
                    return Array.ConvertAll(this.NhanVienIDs, int.Parse).ToList();
                }
                else
                {
                    return new List<int>();
                }
            }
        }
        //ddl usser
        public IEnumerable<User> DanhSachNhanVien { get; set; }
        public List<int> DanhSachNhanVienChon { get; set; }
    }
}