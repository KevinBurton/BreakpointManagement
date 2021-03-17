using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;

namespace BreakpointManagement.Shared.State.Actions
{
    public class UpdateBreakpointGroupAction : IAction
    {
        public BreakpointSummary BreakpointGroup { get; set; }
    }
}
