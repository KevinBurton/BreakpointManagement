using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BreakpointManagement.Shared.State.Props
{
    public class SummaryProps
    {
        public BreakpointSummary Summary { get; set; }

        public EventCallback<BreakpointSummary> UpdateSummary { get; set; }
    }
}
