using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Actions
{
    public class UpdateDrugListAction : IAction
    {
        public List<Drug> DrugList { get; protected set; }
    }
}
