using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VD.Data.Entity.MF
{
    public class BangGiaCT : BaseEntity
    {

        //product
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        //tên giá
        [Display(Name = "Tên giá")]
        public string Ten { get; set; }

        //price
        [Display(Name = "Giá bán")]
        public int Price { get; set; }

    }
}
