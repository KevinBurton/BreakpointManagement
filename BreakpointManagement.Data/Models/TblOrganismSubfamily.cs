using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    [Table("tbl_OrganismSubfamily")]
    public partial class TblOrganismSubfamily
    {
        [Key]
        public int OrganismSubfamilyId { get; set; }
        [StringLength(75)]
        public string OrganismSubfamilyName { get; set; }
        public int OrganismFamilyId { get; set; }
        [Required]
        [StringLength(75)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(OrganismFamilyId))]
        [InverseProperty(nameof(TblOrganismFamily.TblOrganismSubfamilies))]
        public virtual TblOrganismFamily OrganismFamily { get; set; }
    }
}
