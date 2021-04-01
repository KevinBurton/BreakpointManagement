using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Props
{
    public class EditBreakpointProps
    {
        public BreakpointStandard Standard { get; set; }
        public Breakpointgroup Group { get; set; }
        public Project Project { get; set; }
        public Drug Drug { get; set; }
        public EventCallback<BreakpointStandard> UpdateStandard { get; set; }
        public EventCallback<Project> UpdateProject { get; set; }
    }
}
