using BreakpointManagement.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model = BreakpointManagement.Shared.Models;

using Telerik.Blazor.Components;

namespace BreakpointManagement.ComponentLibrary
{
    public partial class BreakpointGroupingReport
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }

        private IEnumerable<Model.BreakpointGroupingReport> groupingReportList;

        private Model.BreakpointGroupingReport selected;

        private List<Model.BreakpointGroupingReport> selectedItems = new List<Model.BreakpointGroupingReport>();

        protected override async Task OnInitializedAsync()
        {
            groupingReportList = await dataService.GetBreakpointGroupingReport();
        }
        async Task RowClick(GridRowClickEventArgs args)
        {
            var data = args.Item as Model.BreakpointGroupingReport;
            selected = data;
            StateHasChanged();
        }
    }
}
