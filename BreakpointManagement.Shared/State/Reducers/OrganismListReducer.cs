using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;
using BreakpointManagement.Shared.State.Actions;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Reducers
{
    public class OrganismListReducer : IReducer<IList<OrganismName>>
    {
        public IList<OrganismName> Reduce(IList<OrganismName> state, IAction action)
        {
            switch (action)
            {
                case UpdateOrganismListAction:
                    return ((UpdateOrganismListAction)action).OrganismList;
                default:
                    return state;
            }
        }
    }
}
