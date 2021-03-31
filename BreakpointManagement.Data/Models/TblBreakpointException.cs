using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    [Table("tbl_BreakpointException")]
    public partial class TblBreakpointException
    {
        [Key]
        public int BreakpointExceptionId { get; set; }
        public int OrganismId { get; set; }
        public int DrugId { get; set; }
        public int? TestMethodId { get; set; }
        [Required]
        [StringLength(25)]
        public string BreakPointType { get; set; }
        public float Susceptible { get; set; }
        public float Intermediate { get; set; }
        public float Resistant { get; set; }
        public int BreakPointYear { get; set; }
        [StringLength(50)]
        public string Dosage { get; set; }
        [StringLength(255)]
        public string Comment { get; set; }
        [Required]
        [StringLength(75)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        public int BreakpointGroupId { get; set; }

        public TblBreakpointgroup Group { get; set; }
    }
}
