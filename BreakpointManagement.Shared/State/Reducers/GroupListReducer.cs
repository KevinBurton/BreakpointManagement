using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;
using BreakpointManagement.Shared.State.Actions;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Reducers
{
    public class GroupListReducer : IReducer<List<Breakpointgroup>>
    {
        public List<Breakpointgroup> Reduce(List<Breakpointgroup> state, IAction action)
        {
            switch (action)
            {
                case UpdateGroupListAction:
                    return ((UpdateGroupListAction)action).GroupList;
                default:
                    return state;
            }
        }
    }
}

