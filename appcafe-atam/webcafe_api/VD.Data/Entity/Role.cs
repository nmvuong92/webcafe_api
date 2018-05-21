using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VD.Data.Entity
{

 
    public  class Role
    {
        public Role()
        {
            this.Users = new HashSet<User>();
            this.Permissions = new HashSet<Permission>();
        }
        [Key]
        //[DatabaseGenerated(databaseGeneratedOption:DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
   
        public virtual ICollection<User> Users { get; set; }
        
        public virtual ICollection<Permission> Permissions { get; set; }

        public static Role[] seed()
        {
            return new Role[]
            {
                new Role() {Id = 1, Name = "Quản trị viên"},
                new Role() {Id = 2, Name = "Chủ quán"},
                new Role() {Id = 3, Name = "Nhân viên quán"}
            };
        }
    }
}
