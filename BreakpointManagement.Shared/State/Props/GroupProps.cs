using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BreakpointManagement.Shared.State.Props
{
    public class GroupProps
    {
        public Breakpointgroup Group { get; set; }
        public Project Project { get; set; }

        public EventCallback<Breakpointgroup> UpdateGroup { get; set; }
    }
}
