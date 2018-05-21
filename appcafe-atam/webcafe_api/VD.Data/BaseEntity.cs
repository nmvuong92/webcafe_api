using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VD.Data.DataTrans;
using VD.Data.Entity;

namespace VD.Data
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            IsSys = false;
          
        }
        [Key]
        public int Id { get; set; }
        public bool IsSys { get; set; }
        [Required]
        [Display(Name = "Ngày tạo")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Display(Name = "Ngày cập nhật")]
        public DateTime ModifiedDate { get; set; }
    }
    public class BaseTranslateEntity : BaseEntity
    {
        public bool IsDefault { get; set; }
        //Lang
        public int LangId { get; set; }
        [ForeignKey("LangId")]
        public virtual VD.Data.Entity.Lang Lang { get; set; }

    }
}
