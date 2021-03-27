using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;
using BreakpointManagement.Shared.State.Actions;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Reducers
{
    public class StandardListReducer : IReducer<List<BreakpointStandard>>
    {
        public List<BreakpointStandard> Reduce(List<BreakpointStandard> state, IAction action)
        {
            switch (action)
            {
                case UpdateStandardListAction:
                    return ((UpdateStandardListAction)action).StandardList;
                default:
                    return state;
            }
        }
    }
}
