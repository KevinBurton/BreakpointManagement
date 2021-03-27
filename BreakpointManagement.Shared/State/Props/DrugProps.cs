using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Props
{
    public class DrugProps
    {
        public Drug Drug { get; set; }
        public List<Drug> DrugList { get; set; }
        public EventCallback<Drug> UpdateDrug { get; set; }
        public EventCallback<List<Drug>> UpdateDrugList { get; set; }
    }
}