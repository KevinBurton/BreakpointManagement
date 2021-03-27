using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Props
{
    public class StandardProp
    {
        public BreakpointStandard Standard { get; set; }
        public EventCallback<BreakpointStandard> UpdateStandard { get; set; }
        public EventCallback<List<BreakpointStandard>> UpdateStandardList { get; set; }
    }
}
