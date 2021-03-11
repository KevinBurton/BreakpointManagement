using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    [Table("tbl_BreakpointInferred")]
    public partial class TblBreakpointInferred
    {
        [Key]
        [Column("BPGroupId")]
        public int BpgroupId { get; set; }
        [Key]
        public int DrugId { get; set; }
        [Key]
        [StringLength(25)]
        public string ResultType { get; set; }
        public int DrugInferredFrom { get; set; }
    }
}
