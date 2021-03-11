using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    [Table("tbl_OrganismGenus")]
    public partial class TblOrganismGenus
    {
        [Key]
        public int GenusId { get; set; }
        [Required]
        [StringLength(50)]
        public string GenusName { get; set; }
        public int? OrganismFamilyId { get; set; }
        [Required]
        [StringLength(75)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
    }
}
