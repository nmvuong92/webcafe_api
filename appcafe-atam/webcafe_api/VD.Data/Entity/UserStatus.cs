using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VD.Data.Entity
{
    public class UserStatus
    {
        [Key]
        //[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }


        public static UserStatus[] seed()
        {
            return new UserStatus[]
            {
                new UserStatus() {Id = -1,Name = "Xóa"},
                new UserStatus() {Id = 1,Name="Kích hoạt"},
                new UserStatus() {Id = 2,Name = "Vô hiệu hóa"},
            };
        }
    }
}
