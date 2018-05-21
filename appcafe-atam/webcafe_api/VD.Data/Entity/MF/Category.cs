using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VD.Data.Entity.MF
{
    public class Category
    {
        public Category()
        {
            this.Order = 1;

        }
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }
        [Display(Name = "Thứ tự")]
        public int Order { get; set; }

        public static Category[] seed()
        {
            return new Category[]
            {
                new Category()
                {
                    Id=1,
                    Name = "Giới thiệu",
                    Order = 1
                }, 
                new Category()
                {
                    Id=2,
                    Name = "Tin tức",
                    Order = 2
                },
                new Category()
                {
                    Id=3,
                    Name = "Hướng dẫn mua hàng, chính sách và quy định",
                    Order = 3
                } 
            };
        }

    }
}
