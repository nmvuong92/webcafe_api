
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using effts;
using VD.Lib;

namespace VD.Data.Entity.MF
{
    public class Product : BaseEntity
    {
        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; }


        [Display(Name = "Giá niêm yết")]
        public int Price { get; set; }



        [Display(Name = "Thông tin chi tiết")]
        public string Infomation { get; set; }
        [Display(Name = "Ảnh hiển thị")]
        public string ThumbnailImage { get; set; }

        [Display(Name = "KM?")]
        public bool IsGiamGia { get; set; }

        [Display(Name = "MaSo")]
        public string MaSo { get; set; }

        [Display(Name = "SP hot?")]
        public bool Hot { get; set; }

        [Display(Name = "SP new?")]
        public bool New { get; set; }

        //danh muc san pham
        [Display(Name = "Danh mục")]
        public int ProductCatId { get; set; }
        [ForeignKey("ProductCatId")]
        public virtual ProductCat ProductCat { get; set; }
        private static Random rd = new Random();

        public virtual ICollection<BangGiaCT> BangGiaCT { get; set; }
        [Display(Name = "Số lượng giá")]
        public int SoLuongGia { get; set; }


        public static Product[] seed()
        {

            List<Product> l = new List<Product>();
            for (int i = 1; i < 100; i++)
            {

                Product p = new Product();

                p.Id = i;

                p.ProductName = "Product name " + i;
                p.ProductCatId = rd.Next(1, 10);
                // p.ProductCatId2 = rd.Next(1, 4);
                p.ThumbnailImage = "/user-uploads/images/thuanhanh/" + myNumbers.GetRandomNumberFromTo(1, 5) + ".jpg";
                if (i % 2 == 0)
                {
                    p.IsGiamGia = true;

                }
                else
                {
                    p.IsGiamGia = false;
                }

                p.Infomation = "<b>Nội dung mô tả</b> <br/>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quaerat quod voluptate consequuntur ad quasi, dolores obcaecati ex aliquid, dolor provident accusamus omnis dolorum ipsam";
                p.Hot = myNumbers.GetRandomBoolean();
                p.New = myNumbers.GetRandomBoolean();
                l.Add(p);
            }
            return l.ToArray();
        }
    }
}
