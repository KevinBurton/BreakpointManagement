using BlazorState;
using BreakpointManagement.Shared.Models;

namespace BreakpointManagement.Shared.Features.BreakpointManagement
{
    public partial class BreakpointManagementState : State<BreakpointManagementState>
    {
        public BreakpointProjectSummary Project { get; private set; }
        public Drug Drug { get; private set; }
        public BreakpointStandard Standard { get; private set; }
        public OrganismName Organism { get; private set; }
        public BreakpointSummary Summary { get; private set; }
        public override void Initialize()
        {
            Project = new BreakpointProjectSummary();
            Drug = new Drug();
            Standard = new BreakpointStandard();
            Organism = new OrganismName();
            Summary = new BreakpointSummary();
        }
    }
}
