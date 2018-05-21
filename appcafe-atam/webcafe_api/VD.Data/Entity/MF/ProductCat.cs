using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;
using System.Runtime.InteropServices;
using VD.Lib;

namespace VD.Data.Entity.MF
{
    public class ProductCat : BaseEntity
    {
        public ProductCat()
        {
            this.Order = 1;
            this.Products = new Collection<Product>();
        }
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }
        [Display(Name = "Mô tả danh mục")]
        public string Description { get; set; }
        [Display(Name = "Thứ tự")]
        public int Order { get; set; }

        [Display(Name = "Ảnh thumnail")]
        public string ImageThumbnail { get; set; }
        public virtual ICollection<Product> Products { get; set; }


        //cat của quán nào?
        [Display(Name = "Quán")]
        public int QuanId { get; set; }
        [ForeignKey("QuanId")]
        public virtual Quan Quan { get; set; }


        public static ProductCat[] seed()
        {
            var parent = new List<ProductCat>();
            parent.Add(new ProductCat()
            {
                Id = 1,
                Name = "Kiếng dán",
               
                ImageThumbnail = "/user-uploads/images/thuanhanh/" + myNumbers.GetRandomNumberFromTo(1, 5) + ".jpg",

            });
            parent.Add(new ProductCat()
            {
                Id = 2,
                Name = "Kiếng xe",
               
                ImageThumbnail = "/user-uploads/images/thuanhanh/" + myNumbers.GetRandomNumberFromTo(1, 5) + ".jpg",
            });
            parent.Add(new ProductCat()
            {
                Id = 3,
                Name = "Gù tay lái",

                ImageThumbnail = "/user-uploads/images/thuanhanh/" + myNumbers.GetRandomNumberFromTo(1, 5) + ".jpg",
            });
           
            parent.Add(new ProductCat()
            {
                Id = 4,
                Name = "Bao ga xe máy",

                ImageThumbnail = "/user-uploads/images/thuanhanh/" + myNumbers.GetRandomNumberFromTo(1, 5) + ".jpg",
            });

            parent.Add(new ProductCat()
            {
                Id = 5,
                Name = "Ốc kiếngBao ga xe máy",
                ImageThumbnail = "/user-uploads/images/thuanhanh/" + myNumbers.GetRandomNumberFromTo(1, 5) + ".jpg",
            });
            parent.Add(new ProductCat()
            {
                Id = 6,
                Name = "Po E tăng tốc",
                ImageThumbnail = "/user-uploads/images/thuanhanh/" + myNumbers.GetRandomNumberFromTo(1, 5) + ".jpg",
            });
            parent.Add(new ProductCat()
            {
                Id = 7,
                Name = "Gác chân",
                ImageThumbnail = "/user-uploads/images/thuanhanh/" + myNumbers.GetRandomNumberFromTo(1, 5) + ".jpg",
            });
            parent.Add(new ProductCat()
            {
                Id = 8,
                Name = "Các loại phụ kiện",
                ImageThumbnail = "/user-uploads/images/thuanhanh/" + myNumbers.GetRandomNumberFromTo(1, 5) + ".jpg",
            });
            parent.Add(new ProductCat()
            {
                Id = 9,
                Name = "Đồ gia dụng",
                ImageThumbnail = "/user-uploads/images/thuanhanh/" + myNumbers.GetRandomNumberFromTo(1, 5) + ".jpg",
            });
            parent.Add(new ProductCat()
            {
                Id = 10,
                Name = "Kệ để hàng",
                ImageThumbnail = "/user-uploads/images/thuanhanh/" + myNumbers.GetRandomNumberFromTo(1, 5) + ".jpg",
            });
            return parent.ToArray();
        }
    }
}
