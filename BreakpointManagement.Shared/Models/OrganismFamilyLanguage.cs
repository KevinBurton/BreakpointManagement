using System;

namespace BreakpointManagement.Shared.Models
{
    public class OrganismFamilyLanguage
    {
        public string LanguageCode { get; set; }
        public int OrganismFamilyId { get; set; }
        public string OrganismFamilyName { get; set; }
        public string OrganismGrouping { get; set; }
        public string GramType { get; set; }
        public bool? Translated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
