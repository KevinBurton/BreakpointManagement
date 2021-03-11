using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    [Table("tbl_OrganismFamily")]
    public partial class TblOrganismFamily
    {
        public TblOrganismFamily()
        {
            TblOrganismSubfamilies = new HashSet<TblOrganismSubfamily>();
        }

        [Key]
        public int OrganismFamilyId { get; set; }
        [Required]
        [StringLength(75)]
        public string OrganismFamilyName { get; set; }
        [StringLength(75)]
        public string OrganismGrouping { get; set; }
        [StringLength(1)]
        public string GramType { get; set; }
        [StringLength(75)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [InverseProperty(nameof(TblOrganismSubfamily.OrganismFamily))]
        public virtual ICollection<TblOrganismSubfamily> TblOrganismSubfamilies { get; set; }
    }
}
