using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    [Table("tbl_OrganismFamilyLanguage")]
    public partial class TblOrganismFamilyLanguage
    {
        [Key]
        [StringLength(2)]
        public string LanguageCode { get; set; }
        [Key]
        public int OrganismFamilyId { get; set; }
        [Required]
        [StringLength(75)]
        public string OrganismFamilyName { get; set; }
        [StringLength(75)]
        public string OrganismGrouping { get; set; }
        [StringLength(1)]
        public string GramType { get; set; }
        public bool? Translated { get; set; }
        [StringLength(75)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
    }
}
