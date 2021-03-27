using BreakpointManagement.Shared.Models;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Props
{
    public class EditBreakpointProps
    {
        public Project Project { get; set; }
        public List<Project> ProjectList { get; set; }
        public Breakpointgroup Group { get; set; }
        public List<Breakpointgroup> GroupList { get; set; }
        public BreakpointStandard Standard { get; set; }
        public List<BreakpointStandard> StandardList { get; set; }
        public Drug Drug { get; set; }
        public List<Drug> DrugList { get; set; }
    }
}
