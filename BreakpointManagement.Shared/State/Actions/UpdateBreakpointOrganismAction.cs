using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;

namespace BreakpointManagement.Shared.State.Actions
{
    public class UpdateBreakpointOrganismAction : IAction
    {
        public BreakpointSummary BreakpointOrganism { get; set; }
    }
}
