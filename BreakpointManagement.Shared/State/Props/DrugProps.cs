using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BreakpointManagement.Shared.State.Props
{
    public class DrugProps
    {
        public Drug Drug { get; set; }
        public EventCallback<Drug> UpdateDrug { get; set; }
    }
}