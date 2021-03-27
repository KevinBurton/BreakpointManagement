using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;
using BreakpointManagement.Shared.State.Actions;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Reducers
{
    public class DrugListReducer : IReducer<List<Drug>>
    {
        public List<Drug> Reduce(List<Drug> state, IAction action)
        {
            switch (action)
            {
                case UpdateDrugListAction:
                    return ((UpdateDrugListAction)action).DrugList;
                default:
                    return state;
            }
        }
    }
}
