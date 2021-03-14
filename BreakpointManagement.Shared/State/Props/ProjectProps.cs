using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BreakpointManagement.Shared.State.Props
{
    public class ProjectProps
    {
        public BreakpointProjectSummary Project;
        public EventCallback<BreakpointProjectSummary> UpdateProject { get; set; }
    }
}
