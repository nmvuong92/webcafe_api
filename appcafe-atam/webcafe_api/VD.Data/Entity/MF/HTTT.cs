using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VD.Data.Entity.MF
{
    public class HTTT
    { 
        [Key]
        public int Id { get; set; }

        [Display(Name="Tên hình thức thanh toán")]
        public string Ten { get; set; }

        public static HTTT[] seed()
        {
            return new HTTT[]
            {
                new HTTT(){Id = 1,Ten = "Thanh toán khi nhận hàng"}, 
                new HTTT(){Id = 2,Ten = "Thanh toán qua ngân lượng"}
            };
        }
    }
}
