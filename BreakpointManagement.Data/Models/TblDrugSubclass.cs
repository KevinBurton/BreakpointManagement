using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    [Table("tbl_DrugSubclass")]
    public partial class TblDrugSubclass
    {
        public TblDrugSubclass()
        {
            TblDrugs = new HashSet<TblDrug>();
        }

        [Key]
        [Column("DrugSubclassID")]
        public int DrugSubclassId { get; set; }
        [Column("DrugClassID")]
        public int DrugClassId { get; set; }
        [Required]
        [StringLength(50)]
        public string DrugSubclassName { get; set; }
        [Required]
        [StringLength(5)]
        public string DrugSubclassAbbr { get; set; }
        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(DrugClassId))]
        [InverseProperty(nameof(TblDrugClass.TblDrugSubclasses))]
        public virtual TblDrugClass DrugClass { get; set; }
        [InverseProperty(nameof(TblDrug.DrugSubclass))]
        public virtual ICollection<TblDrug> TblDrugs { get; set; }
    }
}
