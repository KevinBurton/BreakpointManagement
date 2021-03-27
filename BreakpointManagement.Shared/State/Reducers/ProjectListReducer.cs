using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;
using BreakpointManagement.Shared.State.Actions;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Reducers
{
    public class ProjectListReducer : IReducer<List<Project>>
    {
        public List<Project> Reduce(List<Project> state, IAction action)
        {
            switch (action)
            {
                case UpdateProjectListAction:
                    return ((UpdateProjectListAction)action).ProjectList;
                default:
                    return state;
            }
        }
    }
}
