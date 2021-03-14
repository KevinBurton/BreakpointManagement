using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;

namespace BreakpointManagement.Shared.State.Actions
{
    public class UpdateStandardAction : IAction
    {
        public BreakpointStandard Standard { get; set; }
    }
}
