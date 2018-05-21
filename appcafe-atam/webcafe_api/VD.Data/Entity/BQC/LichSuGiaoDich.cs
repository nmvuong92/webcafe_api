
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VD.Data.Entity.BQC
{
    public class LichSuGiaoDich:BaseEntity
    {
        public string tengiaodich { get; set; }
        public int menhgia { get; set; }
        public DateTime ngaygiaodich { get; set; }


        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        
    }
}
