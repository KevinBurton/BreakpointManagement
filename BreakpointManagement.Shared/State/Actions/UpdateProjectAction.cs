using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;

namespace BreakpointManagement.Shared.State.Actions
{
    public class UpdateProjectAction : IAction
    {
        public BreakpointProjectSummary Project { get; set; }
    }
}
