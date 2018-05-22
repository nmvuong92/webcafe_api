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

        public virtual ICollection<GopYReply> GopYReplies { get; set; }
    }
    public class GopYReply : BaseEntity
    {
        public string NoiDung { get; set; }
        public int? UserReplyId { get; set; }
        [ForeignKey("UserReplyId")]
        public virtual User UserReply { get; set; }

        public int GopYId { get; set; }
        [ForeignKey("GopYId")]
        public virtual GopY GopY { get; set; }
    }
}
