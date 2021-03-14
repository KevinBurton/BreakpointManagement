using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;
using BreakpointManagement.Shared.State.Actions;

namespace BreakpointManagement.Shared.State.Reducers
{
    public class DrugReducer : IReducer<Drug>
    {
        public Drug Reduce(Drug state, IAction action)
        {
            switch (action)
            {
                case UpdateDrugAction:
                    return ((UpdateDrugAction)action).Drug;
                default:
                    return state;
            }
        }
    }
}
