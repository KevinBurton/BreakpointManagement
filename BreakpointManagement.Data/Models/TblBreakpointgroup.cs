using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    [Table("tbl_breakpointgroup")]
    public partial class TblBreakpointgroup
    {
        [Key]
        [Column("BPGroupId")]
        public int BpgroupId { get; set; }
        [Required]
        [Column("BPGroupName")]
        [StringLength(50)]
        public string BpgroupName { get; set; }
        [Column("BPStandardId")]
        public int BpstandardId { get; set; }
        [Required]
        [StringLength(75)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
    }
}
