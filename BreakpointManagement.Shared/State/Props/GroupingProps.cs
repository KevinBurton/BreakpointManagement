using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Props
{
    public class GroupingProps
    {
        public BreakpointStandard Standard { get; set; }
        public Breakpointgroup Group { get; set; }
        public Project Project { get; set; }
        public EventCallback<BreakpointStandard> UpdateStandard { get; set; }
    }
}
