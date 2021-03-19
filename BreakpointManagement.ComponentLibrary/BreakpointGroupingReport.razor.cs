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
    public partial class BreakpointGroupingReport
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }

        private IDataLoader<Model.BreakpointGroupingReport> _loader;

        private IEnumerable<Model.BreakpointGroupingReport> data;

        private Model.BreakpointGroupingReport selected;

        private SelectionType selectionType = SelectionType.Single;

        private List<Model.BreakpointGroupingReport> selectedItems = new List<Model.BreakpointGroupingReport>();

        protected override async Task OnInitializedAsync()
        {
            _loader = new BreakpointGroupingReportDataLoader(dataService);
            data = (await _loader.LoadDataAsync(new FilterData() { OrderBy = "", Skip = 0, Top = 10 })).Records;
        }
        public void RowClick(Model.BreakpointGroupingReport data)
        {
            selected = data;
            StateHasChanged();
        }
    }
    public class BreakpointGroupingReportDataLoader : IDataLoader<Model.BreakpointGroupingReport>
    {
        private readonly IBreakpointManagementDataService _dataService;
        public BreakpointGroupingReportDataLoader(IBreakpointManagementDataService dataService)
        {
            _dataService = dataService;
        }
        public async Task<PaginationResult<Model.BreakpointGroupingReport>> LoadDataAsync(FilterData parameters)
        {
            IList<Model.BreakpointGroupingReport> results;
            if (parameters == null)
            {
                results = await _dataService.GetBreakpointGroupingReport();
            }
            else if (parameters.Top == null)
            {
                results = await _dataService.GetBreakpointGroupingReport();
            }
            else if (string.IsNullOrWhiteSpace(parameters.OrderBy))
            {
                results = await _dataService.GetBreakpointGroupingReport(parameters.Top.Value, parameters.Skip.Value);
            }
            else
            {
                var order = parameters.OrderBy.Split(" ");
                if (order.Length >= 2)
                {
                    results = await _dataService.GetBreakpointGroupingReport(parameters.Top.Value, parameters.Skip.Value, order[0]);
                }
                else
                {
                    results = await _dataService.GetBreakpointGroupingReport(parameters.Top.Value, parameters.Skip.Value);
                }
            }
            var count = await _dataService.GetBreakpointGroupingReportCount();
            return new PaginationResult<Model.BreakpointGroupingReport>
            {
                Records = results,
                Skip = parameters?.Skip ?? 0,
                Total = int.Parse(count),
                Top = parameters?.Top ?? 0
            };
        }
    }
}
