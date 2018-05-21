
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VD.Data.Entity.BQC
{
    public class PhacDoCuaToi : BaseEntity
    {
        [Required(ErrorMessage = "Hãy nhập {0}")]
        [Display(Name = "Tên phác đồ (tên bệnh nhân)")]
        public string TenPhacDo { get; set; }
        [Required(ErrorMessage = "Hãy nhập {0}")]
        [Display(Name = "Danh sách huyệt")]
        public string Huyet { get; set; }

        [Display(Name = "Ghi chú")]
        public string MoTa { get; set; }
        //
        [Display(Name = "Người tạo")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
