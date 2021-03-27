using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Actions
{
    public class UpdateStandardListAction : IAction
    {
        public List<BreakpointStandard> StandardList { get; set; }
    }
}
