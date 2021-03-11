using BreakpointManagement.Services;
using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreakpointManagement.App.Client.Pages
{
    public partial class FetchData
    {
        private IList<BreakpointSummary> BreakpointSummary { get; set; }

        [Inject]
        public IBreakpointManagementDataService BreakpointManagementService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            BreakpointSummary = await BreakpointManagementService.GetBreakpointByProject(0, 10, 0);
        }
    }
}
