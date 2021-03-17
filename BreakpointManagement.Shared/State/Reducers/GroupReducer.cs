using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;
using BreakpointManagement.Shared.State.Actions;

namespace BreakpointManagement.Shared.State.Reducers
{
    public class GroupReducer : IReducer<Breakpointgroup>
    {
        public Breakpointgroup Reduce(Breakpointgroup state, IAction action)
        {
            switch (action)
            {
                case UpdateGroupAction:
                    return ((UpdateGroupAction) action).Group;
                default:
                    return state;
            }
        }
    }
}
