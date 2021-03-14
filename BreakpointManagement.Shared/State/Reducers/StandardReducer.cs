using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;
using BreakpointManagement.Shared.State.Actions;

namespace BreakpointManagement.Shared.State.Reducers
{
    public class StandardReducer : IReducer<BreakpointStandard>
    {
        public BreakpointStandard Reduce(BreakpointStandard state, IAction action)
        {
            switch (action)
            {
                case UpdateStandardAction:
                    return ((UpdateStandardAction)action).Standard;
                default:
                    return state;
            }
        }
    }
}
