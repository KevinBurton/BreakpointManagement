using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;
using BreakpointManagement.Shared.State.Actions;

namespace BreakpointManagement.Shared.State.Reducers
{
    public class ProjectReducer : IReducer<Project>
    {
        public Project Reduce(Project state, IAction action)
        {
            switch (action)
            {
                case UpdateProjectAction:
                    return ((UpdateProjectAction)action).Project;
                default:
                    return state;
            }
        }
    }
}
