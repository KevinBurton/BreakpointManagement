using System;

namespace BreakpointManagement.Shared.Models
{
    public class OrganismGenus
    {
        public int GenusId { get; set; }
        public string GenusName { get; set; }
        public int? OrganismFamilyId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
    }
}
