using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VD.Data.Entity;
using VD.Data.Temp;
using VD.Lib;

namespace Web.Models.BQC
{
    public class UserClient
    {
        public int UserId { get; set; }
        [Display(Name = "Họ và tên")]
       
        public string HoTen { get; set; }

        [Display(Name = "Số chứng minh nhân dân")]
  
        public string CMND { get; set; }

        [Display(Name = "Địa chỉ email")]
      
        public string Email { get; set; }

        [Display(Name = "Địa chỉ")]
      
        public string DiaChi { get; set; }


        [Display(Name = "Số điện thoại")]
     
        public string DienThoai { get; set; }

        public int DiemTichLuy { get; set; }
        public string JWTToken { get; set; }

        public int RoleId { get; set; }

        public int StatusId { get; set; }
        public string RoleName { get; set; }
        public string NgayDangKy { get; set; }
        public static UserClient map(loginVM data, string token)
        {
            return new UserClient()
            {
                UserId = data.ID,
                CMND = data.Username,
                DiaChi = data.Address,
                DienThoai = data.Phone,
                HoTen = data.FullName,
                Email = data.Email,
                JWTToken = token,
                RoleId = data.RoleId,
                StatusId = data.UserStatusId,
                RoleName = data.RoleName,
                NgayDangKy = data.NgayDangKy.XuatDate()
            };
        }

    }
}