using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Actions
{
    public class UpdateGroupListAction : IAction
    {
        public List<Breakpointgroup> GroupList { get; set; }
    }
}
