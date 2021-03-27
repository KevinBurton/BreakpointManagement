using BreakpointManagement.Shared.Models;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.BreakpointManagement
{
    public class BreakpointManagementState
    {
        public List<Project> ProjectList { get; private set; }
        public Project Project { get; private set; }
        public List<Drug> DrugList { get; private set; }
        public Drug Drug { get; private set; }
        public List<BreakpointStandard> StandardList { get; private set; }
        public BreakpointStandard Standard { get; private set; }
        public List<OrganismName> OrganismList { get; private set; }
        public OrganismName Organism { get; private set; }
        public List<Breakpointgroup> GroupList { get; private set; }
        public Breakpointgroup Group { get; private set; }
        public string Location { get; private set; }
    }
}
