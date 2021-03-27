using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Props
{
    public class BreakpointGroupProps
    {
        public BreakpointStandard Standard { get; set; }
        public List<BreakpointStandard> StandardList { get; set; }
        public Breakpointgroup Group { get; set; }
        public EventCallback<Breakpointgroup> UpdateGroup { get; set; }
        public EventCallback<List<Breakpointgroup>> UpdateGroupList { get; set; }
    }
}
