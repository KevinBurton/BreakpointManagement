using System;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.Models
{
    public class BreakpointStandard
    {
        public int BpstandardId { get; set; }
        public string Bpstandard { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Breakpointgroup> Groups { get; set; }
    }
}
