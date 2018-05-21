using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VD.Data.Entity.MF
{
    public class UserQuan
    { 
        /*VÌ CÓ 2 KHÓA CHÍNH NÊN BẮT BUỘC CF PHẢI CÀI ĐẶT THỨ TỰ CHO CÁC KHÓA*/
        [Key, Column(Order = 0)]
        public int UserID { get; set; }
        [Key, Column(Order = 1)]
        public int QuanID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        [ForeignKey("QuanID")]
        public virtual Quan Quan { get; set; }
    }
}
