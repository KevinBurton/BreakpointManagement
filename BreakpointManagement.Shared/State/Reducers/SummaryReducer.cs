using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;
using BreakpointManagement.Shared.State.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakpointManagement.Shared.State.Reducers
{
    public class SummaryReducer : IReducer<BreakpointSummary>
    {
        public BreakpointSummary Reduce(BreakpointSummary state, IAction action)
        {
            switch (action)
            {
                case UpdateSummaryAction:
                    return ((UpdateSummaryAction) action).Summary;
                default:
                    return state;
            }
        }
    }
}
