using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Props
{
    public class GroupProps
    {
        public Breakpointgroup Group { get; set; }
        public Project Project { get; set; }
        public EventCallback<Breakpointgroup> UpdateGroup { get; set; }
        public EventCallback<List<Breakpointgroup>> UpdateGroupList { get; set; }
    }
}
