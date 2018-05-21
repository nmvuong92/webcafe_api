using System.ComponentModel.DataAnnotations;

namespace VD.Data.Temp
{
    public class RoleVM
    {
        public int ID { get; set; }
       
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Tên quyền")]
        public string RoleName { get; set; }
    }
}
