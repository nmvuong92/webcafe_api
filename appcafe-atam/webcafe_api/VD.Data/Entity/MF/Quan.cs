using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VD.Data.Entity.MF
{
    public class Quan : BaseEntity
    {
        [Display(Name = "Mã quán")]
        [MaxLength(100)]
        public string MaQuan { get; set; }


        [Display(Name = "Tên quán")]
        [Required]
        [MaxLength(200)]
        public string TenQuan { get; set; }
        [Display(Name = "Địa chỉ")]

        public string DiaChi { get; set; }

        [Display(Name = "Điện thoại")]
        public string DienThoai { get; set; }

        [Display(Name = "Ảnh thumnail")]
        public string ImageThumbnail { get; set; }

        public virtual ICollection<UserQuan> UserQuans { get; set; }

        //UserId
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        //
        public virtual ICollection<ProductCat> ProductCats { get; set; }
        //public virtual ICollection<Ban> Ban { get; set; }

        public string BanArr { get; set; }
        //seed
        public static Quan[] seed()
        {
            List<Quan> lst = new List<Quan>();
            lst.Add(new Quan()
            {
                Id = 1,
                MaQuan = "QUAN1",
                TenQuan = "Quán 1",
            });
            lst.Add(new Quan()
            {
                Id = 2,
                MaQuan = "QUAN2",
                TenQuan = "Quán 2",
            });
            lst.Add(new Quan()
            {
                Id = 3,
                MaQuan = "QUAN3",
                TenQuan = "Quán 3",
            });
            return lst.ToArray();
        }
    }

}
