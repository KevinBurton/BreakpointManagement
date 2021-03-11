using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    [Table("tbl_OrganismSubfamilyLanguage")]
    public partial class TblOrganismSubfamilyLanguage
    {
        [Key]
        [StringLength(2)]
        public string LanguageCode { get; set; }
        [Key]
        public int OrganismSubfamilyId { get; set; }
        [StringLength(75)]
        public string OrganismSubfamilyName { get; set; }
        public int OrganismFamilyId { get; set; }
        public bool? Translated { get; set; }
        [Required]
        [StringLength(75)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
    }
}
