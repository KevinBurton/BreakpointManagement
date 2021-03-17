using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BreakpointManagement.Shared.State.Props
{
    public class BreakpointProjectProps
    {
        public BreakpointProjectSummary BreakpointProject;
        public EventCallback<BreakpointProjectSummary> UpdateBreakpointProject { get; set; }
    }
}
