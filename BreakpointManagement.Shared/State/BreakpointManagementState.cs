using BreakpointManagement.Shared.Models;

namespace BreakpointManagement.Shared.State.BreakpointManagement
{
    public class BreakpointManagementState
    {
        public Project Project { get; private set; }
        public Drug Drug { get; private set; }
        public BreakpointStandard Standard { get; private set; }
        public OrganismName Organism { get; private set; }
        public Breakpointgroup Group { get; private set; }
        public BreakpointProjectSummary BreakpointProject { get; set; }
        public BreakpointSummary BreakpointGroup { get; set; }
        public BreakpointSummary BreakpointOrganism { get; set; }
        public BreakpointSummary BreakpointDrug { get; set; }
        public string Location { get; private set; }

    }
}
