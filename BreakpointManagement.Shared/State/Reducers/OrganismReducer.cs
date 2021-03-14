using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;
using BreakpointManagement.Shared.State.Actions;

namespace BreakpointManagement.Shared.State.Reducers
{
    public class OrganismReducer : IReducer<OrganismName>
    {
        public OrganismName Reduce(OrganismName state, IAction action)
        {
            switch (action)
            {
                case UpdateOrganismAction:
                    return ((UpdateOrganismAction)action).Organism;
                default:
                    return state;
            }
        }
    }
}
