using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BreakpointManagement.Shared.State.Props
{
    public class StandardProp
    {
        public BreakpointStandard Standard { get; set; }

        public EventCallback<BreakpointStandard> UpdateStandard { get; set; }
    }
}
