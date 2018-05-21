using System.Collections.Generic;
namespace VD.Data.Entity
{

   
    public partial class Permission : BaseEntity
    {
        public Permission()
        {
            this.Roles = new HashSet<Role>();
        }
    
        public string Name { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
