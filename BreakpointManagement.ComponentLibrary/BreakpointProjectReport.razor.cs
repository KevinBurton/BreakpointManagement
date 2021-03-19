using BlazorTable;
using BlazorTable.Components.ServerSide;
using BlazorTable.Interfaces;
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

        private IDataLoader<Model.BreakpointProjectReport> _loader;

        private IEnumerable<Model.BreakpointProjectReport> data;

        private Model.BreakpointProjectReport selected;

        private SelectionType selectionType = SelectionType.Single;

        private List<Model.BreakpointProjectReport> selectedItems = new List<Model.BreakpointProjectReport>();

        protected override async Task OnInitializedAsync()
        {
            _loader = new BreakpointProjectReportDataLoader(dataService);
            data = (await _loader.LoadDataAsync(new FilterData() { OrderBy = "", Skip = 0, Top = 10 })).Records;
        }
        public void RowClick(Model.BreakpointProjectReport data)
        {
            selected = data;
            StateHasChanged();
        }
    }
    public class BreakpointProjectReportDataLoader : IDataLoader<Model.BreakpointProjectReport>
    {
        private readonly IBreakpointManagementDataService _dataService;
        public BreakpointProjectReportDataLoader(IBreakpointManagementDataService dataService)
        {
            _dataService = dataService;
        }
        public async Task<PaginationResult<Model.BreakpointProjectReport>> LoadDataAsync(FilterData parameters)
        {
            IList<Model.BreakpointProjectReport> results;
            if (parameters == null || parameters.Top == null || parameters.Skip == null)
            {
                results = await _dataService.GetBreakpointProjectReport();
            }
            else
            {
                results = await _dataService.GetBreakpointProjectReport(parameters.Top.Value, parameters.Skip.Value, parameters.OrderBy);
            }
            var count = await _dataService.GetBreakpointProjectReportCount();
            return new PaginationResult<Model.BreakpointProjectReport>
            {
                Records = results,
                Skip = parameters?.Skip ?? 0,
                Total = int.Parse(count),
                Top = parameters?.Top ?? 0
            };
        }
    }
}
