using System;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.Models
{
    public class Breakpointgroup
    {
        public int BpgroupId { get; set; }
        public string BpgroupName { get; set; }
        public int BpstandardId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public BreakpointStandard Standard { get; set; }
        public List<BreakpointException> Exceptions { get; set; }
    }
}
