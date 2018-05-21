using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VD.Data.Entity.MF
{
    public class GopY:BaseEntity
    {
        public int DonHangId { get; set; }
        [ForeignKey("DonHangId")]
        public virtual DonHang DonHang { get; set; }
        public string NoiDungGopY { get; set; }
    }
}
