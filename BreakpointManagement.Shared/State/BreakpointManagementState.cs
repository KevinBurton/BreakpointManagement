using BreakpointManagement.Shared.Models;

namespace BreakpointManagement.Shared.State.BreakpointManagement
{
    public class BreakpointManagementState
    {
        public BreakpointProjectSummary Project { get; private set; }
        public Drug Drug { get; private set; }
        public BreakpointStandard Standard { get; private set; }
        public OrganismName Organism { get; private set; }
        public BreakpointSummary Summary { get; private set; }
        public string Location { get; private set; }

    }
}
