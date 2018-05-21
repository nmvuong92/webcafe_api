
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace VD.Data.Entity.BQC
{
    public class LichSuNapThe : BaseEntity
    {
        public string tenthe { get; set; }
        public int menhgia { get; set; }
        public DateTime ngay { get; set; }

        public  int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
