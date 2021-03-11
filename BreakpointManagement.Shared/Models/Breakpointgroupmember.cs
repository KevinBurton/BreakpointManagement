using System;

namespace BreakpointManagement.Shared.Models
{
    public class Breakpointgroupmember
    {
        public int OrganismId { get; set; }
        public int BpgroupId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
