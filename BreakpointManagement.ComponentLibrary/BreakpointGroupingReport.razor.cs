using BreakpointManagement.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model = BreakpointManagement.Shared.Models;

namespace BreakpointManagement.ComponentLibrary
{
    public partial class BreakpointGroupingReport
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }

        private IEnumerable<Model.BreakpointGroupingReport> data;

        private Model.BreakpointGroupingReport selected;

        private List<Model.BreakpointGroupingReport> selectedItems = new List<Model.BreakpointGroupingReport>();

        protected override async Task OnInitializedAsync()
        {
            data = await dataService.GetBreakpointGroupingReport();
        }
        public void RowClick(Model.BreakpointGroupingReport data)
        {
            selected = data;
            StateHasChanged();
        }
    }
}
