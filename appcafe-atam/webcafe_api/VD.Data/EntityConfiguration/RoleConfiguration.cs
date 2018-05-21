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
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
           //ToTable("tblRole").HasKey(c => c.Id);
            Property(c => c.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
