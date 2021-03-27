using BreakpointManagement.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model = BreakpointManagement.Shared.Models;

namespace BreakpointManagement.ComponentLibrary
{
    public partial class BreakpointProjectReport
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }

        private IEnumerable<Model.BreakpointProjectReport> data;

        private Model.BreakpointProjectReport selected;

        private List<Model.BreakpointProjectReport> selectedItems = new List<Model.BreakpointProjectReport>();

        protected override async Task OnInitializedAsync()
        {
            data = await dataService.GetBreakpointProjectReport();
        }
        public void RowClick(Model.BreakpointProjectReport data)
        {
            selected = data;
            StateHasChanged();
        }
    }
}
