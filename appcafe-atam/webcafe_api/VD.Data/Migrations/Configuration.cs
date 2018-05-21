
using System.Data.Entity;
using System.Linq;
using VD.Data.Entity;
using VD.Data.Entity.MF;
using VD.Lib;

namespace VD.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using VD.Data.Base;
    using VD.Data.Entity.Logging;

    internal sealed class Configuration : DbMigrationsConfiguration<VD.Data.vuong_cms_context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(VD.Data.vuong_cms_context context)
        {
            CacheServ.ClearAll();
            return;
            context.HinhThucMuaHang.AddOrUpdate(HinhThucMuaHang.seed());
            context.SaveChanges();
           
            context.Roles.AddOrUpdate(Role.seed());
            context.SaveChanges();
           
            context.Quan.AddOrUpdate(Quan.seed());
            context.SaveChanges();
            //context.Ban.AddOrUpdate(Ban.seed());
            context.SaveChanges();
        
            
           
            context.TrangThaiGiaoHang.AddOrUpdate(TrangThaiGiaoHang.seed());
            context.SaveChanges();
            //
            context.TrangThaiThanhToan.AddOrUpdate(TrangThaiThanhToan.seed());
            context.SaveChanges();
            //httt
            context.HTTTs.AddOrUpdate(HTTT.seed());
            context.SaveChanges();

            //settings:
            context.Settings.AddOrUpdate(Setting.seed());
            context.SaveChanges();

            //role
            context.Roles.AddOrUpdate(Role.seed());
            context.SaveChanges();

            //flag
            context.Langs.AddOrUpdate(Lang.seed());
            context.SaveChanges();

            //Confs
            context.Confs.AddOrUpdate(Conf.seed());
            context.SaveChanges();


            //LogType
            context.LogType.AddOrUpdate(LogType.seed());
            context.SaveChanges();

            //UserStatus
            context.UserStatus.AddOrUpdate(UserStatus.seed());
            context.SaveChanges();

            //user
            context.Users.AddOrUpdate(User.seed());
            context.SaveChanges();
          
            //slider
            context.Slider.AddOrUpdate(Slider.seed());
            context.SaveChanges();

            //slider
            context.ProductCat.AddOrUpdate(ProductCat.seed());
            context.SaveChanges();

            //img
            context.ImgTmp.AddOrUpdate(ImgTmp.seed());
            context.SaveChanges();

            context.ImgTmpDetail.AddOrUpdate(ImgTmpDetail.seed());
            context.SaveChanges();
            //product
            context.Product.AddOrUpdate(Product.seed());
            context.SaveChanges();



            //contact
            context.ContactStatus.AddOrUpdate(ContactStatus.seed());
            context.SaveChanges();


            //article
            context.Category.AddOrUpdate(Category.seed());
            context.SaveChanges();

            context.Article.AddOrUpdate(Article.seed());
            context.SaveChanges();


        }
    }
}
