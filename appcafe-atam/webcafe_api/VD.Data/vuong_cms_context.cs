using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using VD.Data.Entity;
using VD.Data.Entity.BQC;
using VD.Data.Entity.Logging;
using VD.Data.Entity.MF;

namespace VD.Data
{
    public class vuong_cms_context : DbContext
    {
        public vuong_cms_context()
            : base("name=vuong_cms_context")
        {
            //Database.SetInitializer<vuong_cms_context>(new CreateDatabaseIfNotExists<vuong_cms_context>());
            //Database.SetInitializer<vuong_cms_context>(new DropCreateDatabaseIfModelChanges<vuong_cms_context>());
            //Database.SetInitializer<vuong_cms_context>(new DropCreateDatabaseAlways<vuong_cms_context>());
            //Database.Initialize(true);
            //Database.SetInitializer(new DatabaseInitializer());

            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }
        //configs
        
        public DbSet<Conf> Confs { get; set; }
       
        //
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Permission> Permissions { get; set; }
     
      
        public DbSet<VD.Data.Entity.Lang> Langs { get; set; }

        //user & role
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserStatus> UserStatus { get; set; }
        //nlog
        public DbSet<Log> Log { get; set; }
        public DbSet<LogType> LogType { get; set; }
        public DbSet<LogException> LogException { get; set; }

        //counter
        public DbSet<Counter> Counter { get; set; }

        public DbSet<PhacDoCuaToi> PhacDoCuaToi { get; set; }


        public DbSet<LichSuNapThe> LichSuNapThe { get; set; }
        public DbSet<LichSuGiaoDich> LichSuGiaoDich { get; set; }
        //
        public DbSet<Slider> Slider { get; set; }
        public DbSet<ProductCat> ProductCat { get; set; }
        public DbSet<Product> Product { get; set; }

        //contact
        public DbSet<ContactStatus> ContactStatus { get; set; }
        public DbSet<Contact> Contact { get; set; }

        //
        public DbSet<Article> Article { get; set; }
        public DbSet<Category> Category { get; set; }
        //
        public DbSet<ImgTmp> ImgTmp { get; set; }
        public DbSet<ImgTmpDetail> ImgTmpDetail { get; set; }
        public DbSet<Catalog> Catalog { get; set; }
        //
        public DbSet<HTTT> HTTTs { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<CTDonHang> CTDonHangs { get; set; }
        //
        public DbSet<Province> Province { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Ward> Ward { get; set; }
        //
        public DbSet<TrangThaiGiaoHang> TrangThaiGiaoHang { get; set; }
        public DbSet<TrangThaiThanhToan> TrangThaiThanhToan { get; set; }

        public DbSet<Quan> Quan { get; set; }
        //public DbSet<Ban> Ban { get; set; }
        public DbSet<UserQuan> UserQuan { get; set; }

        public DbSet<ThucDon> ThucDon { get; set; }
        public DbSet<ThucDonCT> ThucDonCT { get; set; }

        public DbSet<HinhThucMuaHang> HinhThucMuaHang { get; set; }
        public DbSet<BangGiaCT> BangGiaCT { get; set; }
        public DbSet<GopY> GopY { get; set; }
        public DbSet<GopYReply> GopYReply { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
      


            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
           .Where(type => !String.IsNullOrEmpty(type.Namespace))
           .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            //base.OnModelCreating(modelBuilder);  

            //Configure domain classes using modelBuilder here
            // modelBuilder.Configurations.Add(new RoleConfiguration());
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();





            base.OnModelCreating(modelBuilder);


          
        }


    }
}
