
using System.ComponentModel.DataAnnotations.Schema;

namespace VD.Data.Entity.MF
{
    public class ThucDonCT : BaseEntity
    {
        //thuc don
        public int ThucDonId { get; set; }
        [ForeignKey("ThucDonId")]
        public virtual ThucDon ThucDon { get; set; }


        //product

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }




      
    }
}
