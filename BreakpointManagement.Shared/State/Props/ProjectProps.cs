using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BreakpointManagement.Shared.State.Props
{
    public class ProjectProps
    {
        public Project Project;
        public EventCallback<Project> UpdateProject { get; set; }
    }
}
