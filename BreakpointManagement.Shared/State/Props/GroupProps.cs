using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BreakpointManagement.Shared.State.Props
{
    public class GroupProps
    {
        public BreakpointSummary Group { get; set; }
        public BreakpointProjectSummary Project { get; set; }

        public EventCallback<BreakpointSummary> UpdateGroup { get; set; }
    }
}
