using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VD.Data.Entity.MF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("District")]
    public partial class District
    {
        public District()
        {
            Ward = new HashSet<Ward>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string LatiLongTude { get; set; }

        public int? ProvinceId { get; set; }

        public int? SortOrder { get; set; }

        public bool? IsPublished { get; set; }

        public bool? IsDeleted { get; set; }

        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set; }

        public virtual ICollection<Ward> Ward { get; set; }

        public int GiaShip { get; set; }
    }
}
