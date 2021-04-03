using BreakpointManagement.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model = BreakpointManagement.Shared.Models;
using Telerik.Blazor.Components;

namespace BreakpointManagement.ComponentLibrary
{
    public partial class BreakpointProjectReport
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }

        private IEnumerable<Model.BreakpointProjectReport> projectReportData;

        private Model.BreakpointProjectReport selected;

        private List<Model.BreakpointProjectReport> selectedItems = new List<Model.BreakpointProjectReport>();

        protected override async Task OnInitializedAsync()
        {
            projectReportData = await dataService.GetBreakpointProjectReport();
        }
        void RowClick(GridRowClickEventArgs args)
        {
            var data = args.Item as Model.BreakpointProjectReport;
            selected = data;
            StateHasChanged();
        }
    }
}
