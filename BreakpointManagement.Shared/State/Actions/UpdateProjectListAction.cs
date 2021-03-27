using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Actions
{
    public class UpdateProjectListAction : IAction
    {
        public List<Project> ProjectList { get; protected set; }
    }
}
