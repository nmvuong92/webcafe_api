
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VD.Data.Entity.MF
{
    public class ThucDon:BaseEntity
    {
        public string TenThucDon { get; set; }
        public string Icon { get; set; }


        //quan 
        public int QuanId { get; set; }
        [ForeignKey("QuanId")]
        public virtual  Quan Quan { get; set; }

        //
        public ICollection<ThucDonCT> ThucDonCTs { get; set; }
    }
}
