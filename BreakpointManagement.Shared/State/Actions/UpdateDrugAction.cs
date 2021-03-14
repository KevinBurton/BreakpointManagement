using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;

namespace BreakpointManagement.Shared.State.Actions
{
    public class UpdateDrugAction : IAction
    {
        public Drug Drug { get; set; }
    }
}
