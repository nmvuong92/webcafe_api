using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VD.Data;
using VD.Data.Entity.MF;
using Web.Controllers;
using Web.Security;

namespace Web.Areas.Admin.Controllers
{
    [myAuth]
    public class RolesController :BaseController
    {

        vuong_cms_context __db = new vuong_cms_context();
        [HttpGet]
        public JsonResult ajax_lay_quan_mac_dinh()
        {
            var __auth = MySsAuthUsers.GetAuth();
            int QuanDefaultId =__db.Users.Find(__auth.ID).QuanDefaultId??-1;
            return Json(QuanDefaultId, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ajax_auth_ddlquan()
        {
            var __auth = MySsAuthUsers.GetAuth();
            List<Quan> ddlQuan;

            var user = __db.Users.Find(__auth.ID);
            if (__auth.RoleId == 1)
            {
                ddlQuan = __db.Quan.ToList().Select(s => new Quan()
                {
                    Id = s.Id,
                    TenQuan = s.TenQuan,
                    ProductCats = s.ProductCats.ToList().Select(s2 => new ProductCat()
                    {
                        Id = s2.Id,
                        Name = s2.Name,
                    }).ToList(),
                    BanArr = s.BanArr
                }).ToList();

            }else if(__auth.IsOwner){
                ddlQuan = __db.Quan.Where(w => w.UserId == __auth.ID).ToList().Select(s => new Quan()
                {
                    Id = s.Id,
                    TenQuan = s.TenQuan,
                    ProductCats = s.ProductCats.ToList().Select(s2=>new ProductCat()
                    {
                      Id  = s2.Id,
                      Name = s2.Name,
                    }).ToList(),
                    BanArr = s.BanArr
                }).ToList();
            }
            else
            {
                ddlQuan = __db.UserQuan.Where(w => w.UserID == __auth.ID).Select(s => s.Quan).ToList().Select(s => new Quan()
                {
                    Id = s.Id,
                    TenQuan = s.TenQuan,
                    ProductCats = s.ProductCats.ToList().Select(s2 => new ProductCat()
                    {
                        Id = s2.Id,
                        Name = s2.Name,
                    }).ToList(),
                    BanArr = s.BanArr
                }).ToList();

            }
            return Json(ddlQuan, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult ajax_ddl_trangthaidonhang()
        {
            var ddlTrangThaiGiaoHang = __db.TrangThaiGiaoHang.ToList().Select(s => new SelectListItem()
            {
                Value = s.Id.ToString(),
                Text = s.Ten,
            }).ToList();
            var ddlTrangThaiThanhToan = __db.TrangThaiThanhToan.ToList().Select(s => new SelectListItem()
            {
                Value = s.Id.ToString(),
                Text = s.Ten,
            }).ToList();

            var ddlHinhThucMuaHang = __db.HinhThucMuaHang.ToList().Select(s => new SelectListItem()
            {
                Value = s.Id.ToString(),
                Text = s.Ten,
            }).ToList();
          
            return Json(new
            {
                ddlTrangThaiThanhToan,
                ddlTrangThaiGiaoHang,
                ddlHinhThucMuaHang
            }, JsonRequestBehavior.AllowGet);

        }
    }
    
}