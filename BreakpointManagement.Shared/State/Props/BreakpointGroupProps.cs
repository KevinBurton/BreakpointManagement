using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Props
{
    public class BreakpointGroupProps
    {
        public BreakpointStandard Standard { get; set; }
        public Breakpointgroup Group { get; set; }
        public List<Breakpointgroup> GroupList { get; set; }
        public EventCallback<Breakpointgroup> UpdateGroup { get; set; }
    }
}
