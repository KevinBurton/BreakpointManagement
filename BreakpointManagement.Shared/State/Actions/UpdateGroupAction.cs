using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;

namespace BreakpointManagement.Shared.State.Actions
{
    public class UpdateGroupAction : IAction
    {
        public Breakpointgroup Group { get; set; }
    }
}
