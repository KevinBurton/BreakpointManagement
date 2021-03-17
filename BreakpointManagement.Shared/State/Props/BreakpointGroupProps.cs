using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BreakpointManagement.Shared.State.Props
{
    public class BreakpointGroupProps
    {
        public BreakpointStandard Standard { get; set; }
        public Breakpointgroup Group { get; set; }
        public EventCallback<Breakpointgroup> UpdateGroup { get; set; }
    }
}
