using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    [Table("tbl_OrganismName")]
    public partial class TblOrganismName
    {
        [Key]
        public int OrganismId { get; set; }
        [Required]
        [StringLength(75)]
        public string OrganismName { get; set; }
        public int OrganismFamilyId { get; set; }
        public int? OrganismSubfamilyId { get; set; }
        public int? GenusId { get; set; }
        public bool PrintOnCodeList { get; set; }
        public int? RemapTo { get; set; }
        public bool Aerobic { get; set; }
        public bool Anaerobic { get; set; }
        public bool Fungal { get; set; }
        [Required]
        [StringLength(75)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        public byte[] TimeStamper { get; set; }
    }
}
