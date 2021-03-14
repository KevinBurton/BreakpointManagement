using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;

namespace BreakpointManagement.Shared.State.Actions
{
    public class UpdateOrganismAction : IAction
    {
        public OrganismName Organism { get; set; }
    }
}
