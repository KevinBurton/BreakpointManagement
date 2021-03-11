using BlazorTable;
using BlazorTable.Components.ServerSide;
using BlazorTable.Interfaces;
using BreakpointManagement.Services;
using BreakpointManagement.Shared.Features.BreakpointManagement;
using BreakpointManagement.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreakpointManagement.ComponentLibrary
{
    public partial class BreakpointStandardPicker
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }
        [Inject]
        private IMediator Mediator { get; set; }

        private IDataLoader<BreakpointStandard> _loader;

        private IEnumerable<BreakpointStandard> data;

        private BreakpointStandard selected;

        private SelectionType selectionType = SelectionType.Single;

        private List<BreakpointStandard> selectedItems = new List<BreakpointStandard>();

        protected override async Task OnInitializedAsync()
        {
            _loader = new BreakpointStandardDataLoader(dataService);
            data = (await _loader.LoadDataAsync(null)).Records;
        }
        public void RowClick(BreakpointStandard data)
        {
            selected = data;
            StateHasChanged();
            Mediator.Send(new BreakpointManagementState.UpdateStandardAction { Standard = data });
        }
    }

    public class BreakpointStandardDataLoader : IDataLoader<BreakpointStandard>
    {
        private readonly IBreakpointManagementDataService _dataService;
        public BreakpointStandardDataLoader(IBreakpointManagementDataService dataService)
        {
            _dataService = dataService;
        }
        public async Task<PaginationResult<BreakpointStandard>> LoadDataAsync(FilterData parameters)
        {
            IList<BreakpointStandard> results;
            if (parameters == null) return new PaginationResult<BreakpointStandard>();
            if (parameters == null)
            {
                results = await _dataService.GetAllBreakpointStandards();
            }
            else if (parameters.Top == null)
            {
                results = await _dataService.GetAllBreakpointStandards();
            }
            else if (string.IsNullOrWhiteSpace(parameters.OrderBy))
            {
                results = await _dataService.GetAllBreakpointStandards(parameters.Top.Value, parameters.Skip.Value);
            }
            else
            {
                var order = parameters.OrderBy.Split(" ");
                if (order.Length >= 2)
                {
                    results = await _dataService.GetAllBreakpointStandards(parameters.Top.Value, parameters.Skip.Value, order[0]);
                }
                else
                {
                    results = await _dataService.GetAllBreakpointStandards(parameters.Top.Value, parameters.Skip.Value);
                }
            }
            var count = await _dataService.GetBreakpointStandardCount();
            return new PaginationResult<BreakpointStandard>
            {
                Records = results,
                Skip = parameters?.Skip ?? 0,
                Total = int.Parse(count),
                Top = parameters?.Top ?? 0
            };
        }
    }
}
