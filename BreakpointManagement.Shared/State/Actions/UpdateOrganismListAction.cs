using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Actions
{
    public class UpdateOrganismListAction : IAction
    {
        public IList<OrganismName> OrganismList { get; set; }
    }
}
