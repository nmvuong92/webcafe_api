using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VD.Data.Entity;

namespace VD.Data.EntityConfiguration
{
    public class UserStatusConfiguration:EntityTypeConfiguration<UserStatus>
    {
        public UserStatusConfiguration()
        {
            Property(c => c.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
