using System;

namespace BreakpointManagement.Shared.Models
{
    public class OrganismSubfamilyLanguage
    {
        public string LanguageCode { get; set; }
        public int OrganismSubfamilyId { get; set; }
        public string OrganismSubfamilyName { get; set; }
        public int OrganismFamilyId { get; set; }
        public bool? Translated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
