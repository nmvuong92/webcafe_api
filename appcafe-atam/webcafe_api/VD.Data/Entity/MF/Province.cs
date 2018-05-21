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
    [Table("Province")]
    public partial class Province
    {
        public Province()
        {
            District = new HashSet<District>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Type { get; set; }

        public int? TelephoneCode { get; set; }

        [StringLength(20)]
        public string ZipCode { get; set; }

        [StringLength(2)]
        public string CountryCode { get; set; }

        public int? SortOrder { get; set; }

        public bool? IsPublished { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual ICollection<District> District { get; set; }

        public int GiaShip { get; set; }
    }
}
