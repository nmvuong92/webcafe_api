using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.ThuanHanhMobileApp.Post
{
    public class AuthToken
    {
        [Display(Name="User")]
        [Required(ErrorMessage = "Vui lòng nhập user")]
        public int UserId { get; set; }

        [Display(Name = "Token")]
        [Required(ErrorMessage = "Vui lòng nhập Token")]
        public string Token { get; set; }
    }
}