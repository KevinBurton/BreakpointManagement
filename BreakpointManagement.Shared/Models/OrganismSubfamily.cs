using System;

namespace BreakpointManagement.Shared.Models
{
    public class OrganismSubfamily
    {
        public int OrganismSubfamilyId { get; set; }
        public string OrganismSubfamilyName { get; set; }
        public int OrganismFamilyId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual OrganismFamily OrganismFamily { get; set; }
    }
}
