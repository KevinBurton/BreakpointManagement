using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BreakpointManagement.Shared.State.Props
{
    public class BreakpointOrganismProp
    {
        public BreakpointProjectSummary BreakpointProject { get; set; }
        public BreakpointSummary BreakpointGroup { get; set; }
        public BreakpointSummary BreakpointOrganism { get; set; }
        public EventCallback<BreakpointSummary> UpdateBreakpointOrganism { get; set; }
    }
}
