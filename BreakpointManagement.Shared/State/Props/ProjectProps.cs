using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Props
{
    public class ProjectProps
    {
        public Project Project;
        public List<Project> ProjectList;
        public EventCallback<Project> UpdateProject { get; set; }
        public EventCallback<List<Project>> UpdateProjectList { get; set; }
    }
}
