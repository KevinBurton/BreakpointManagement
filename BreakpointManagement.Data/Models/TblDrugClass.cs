using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    [Table("tbl_DrugClass")]
    public partial class TblDrugClass
    {
        public TblDrugClass()
        {
            TblDrugSubclasses = new HashSet<TblDrugSubclass>();
        }

        [Key]
        [Column("DrugCLassID")]
        public int DrugClassId { get; set; }
        [Required]
        [Column("DrugCLassName")]
        [StringLength(50)]
        public string DrugClassName { get; set; }
        [Required]
        [StringLength(5)]
        public string DrugClassAbbr { get; set; }
        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

        [InverseProperty(nameof(TblDrugSubclass.DrugClass))]
        public virtual ICollection<TblDrugSubclass> TblDrugSubclasses { get; set; }
    }
}
