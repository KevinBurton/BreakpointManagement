using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    [Table("tbl_Breakpoint")]
    public partial class TblBreakpoint
    {
        [Key]
        public int BreakpointId { get; set; }
        [Required]
        [StringLength(25)]
        public string ResultType { get; set; }
        [Column("BPGroupId")]
        public int BpgroupId { get; set; }
        public int DrugId { get; set; }
        [Column(TypeName = "decimal(8, 4)")]
        public decimal Susceptible { get; set; }
        [Column(TypeName = "decimal(8, 4)")]
        public decimal LowIntermediate { get; set; }
        [Column(TypeName = "decimal(8, 4)")]
        public decimal Intermediate { get; set; }
        [Column(TypeName = "decimal(8, 4)")]
        public decimal Resistant { get; set; }
        [StringLength(50)]
        public string DisplayedAs { get; set; }
        [Required]
        [StringLength(50)]
        public string Dosage { get; set; }
        [StringLength(50)]
        public string DosageType { get; set; }
        [StringLength(255)]
        public string Comment { get; set; }
        public int RepresentedBy { get; set; }
        public bool UseNotation { get; set; }
        [Required]
        [StringLength(75)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [Column("scrSusceptible")]
        [StringLength(50)]
        public string ScrSusceptible { get; set; }
        [Column("scrLowIntermediate")]
        [StringLength(50)]
        public string ScrLowIntermediate { get; set; }
        [Column("scrHighIntermediate")]
        [StringLength(50)]
        public string ScrHighIntermediate { get; set; }
        [Column("scrResistant")]
        [StringLength(50)]
        public string ScrResistant { get; set; }
        public int ProjectId { get; set; }
        [Column("BPYear")]
        [StringLength(255)]
        public string Bpyear { get; set; }
    }
}
