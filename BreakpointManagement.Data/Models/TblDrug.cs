using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    [Table("tbl_Drug")]
    public partial class TblDrug
    {
        [Key]
        [Column("DrugID")]
        public int DrugId { get; set; }
        [Column("DrugSubclassID")]
        public int DrugSubclassId { get; set; }
        [Required]
        [StringLength(50)]
        public string DrugName { get; set; }
        [StringLength(10)]
        public string DrugAbbr { get; set; }
        public bool ForPublicUse { get; set; }
        [Required]
        [StringLength(75)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [Column("Combination_Drug")]
        public bool? CombinationDrug { get; set; }
        [Column("Fixed_Ratio")]
        public bool? FixedRatio { get; set; }
        [Column(TypeName = "decimal(18, 11)")]
        public decimal? Proportion { get; set; }
        public bool Active { get; set; }

        [ForeignKey(nameof(DrugSubclassId))]
        [InverseProperty(nameof(TblDrugSubclass.TblDrugs))]
        public virtual TblDrugSubclass DrugSubclass { get; set; }
    }
}
