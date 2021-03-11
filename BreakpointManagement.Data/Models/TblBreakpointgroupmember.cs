using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    [Table("tbl_breakpointgroupmember")]
    public partial class TblBreakpointgroupmember
    {
        [Key]
        public int OrganismId { get; set; }
        [Key]
        [Column("BPGroupId")]
        public int BpgroupId { get; set; }
        [Required]
        [StringLength(75)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
    }
}
