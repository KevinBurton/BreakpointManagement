using System;

namespace BreakpointManagement.Shared.Models
{
    public class OrganismNameLanguage
    {
        public string LanguageCode { get; set; }
        public int OrganismId { get; set; }
        public string OrganismName { get; set; }
        public int OrganismFamilyId { get; set; }
        public int? OrganismSubfamilyId { get; set; }
        public int? GenusId { get; set; }
        public bool PrintOnCodeList { get; set; }
        public int? RemapTo { get; set; }
        public bool? Aerobic { get; set; }
        public bool? Anaerobic { get; set; }
        public bool? Fungal { get; set; }
        public bool? Translated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
