
namespace VD.Data.Entity.MF
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Ward")]
    public partial class Ward
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string LatiLongTude { get; set; }

        public int? DistrictID { get; set; }

        public int SortOrder { get; set; }

        public bool? IsPublished { get; set; }

        public bool? IsDeleted { get; set; }

        [ForeignKey("DistrictID")]
        public virtual District District { get; set; }
    }
}
