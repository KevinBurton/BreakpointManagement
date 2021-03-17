﻿using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;
using BreakpointManagement.Shared.State.Actions;

namespace BreakpointManagement.Shared.State.Reducers
{
    public class BreakpointProjectReducer : IReducer<BreakpointProjectSummary>
    {
        public BreakpointProjectSummary Reduce(BreakpointProjectSummary state, IAction action)
        {
            switch (action)
            {
                case UpdateBreakpointProjectAction:
                    return ((UpdateBreakpointProjectAction)action).BreakpointProject;
                default:
                    return state;
            }
        }
    }
}
