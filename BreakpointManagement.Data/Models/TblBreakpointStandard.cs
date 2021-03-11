using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    [Table("tbl_BreakpointStandard")]
    public partial class TblBreakpointStandard
    {
        [Key]
        [Column("BPStandardId")]
        public int BpstandardId { get; set; }
        [Required]
        [Column("BPStandard")]
        [StringLength(75)]
        public string Bpstandard { get; set; }
        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
    }
}
