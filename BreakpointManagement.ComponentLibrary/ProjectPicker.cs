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
    public partial class ProjectPicker
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }
        [Inject]
        private IMediator Mediator { get; set; }


        private IDataLoader<BreakpointProjectSummary> _loader;

        private IEnumerable<BreakpointProjectSummary> data;

        private BreakpointProjectSummary selected;

        private SelectionType selectionType = SelectionType.Single;

        private List<BreakpointProjectSummary> selectedItems = new List<BreakpointProjectSummary>();

        protected override async Task OnInitializedAsync()
        {
            _loader = new ProjectDataLoader(dataService);
            data = (await _loader.LoadDataAsync(null)).Records;
        }
        public void RowClick(BreakpointProjectSummary data)
        {
            selected = data;
            StateHasChanged();
            Mediator.Send(new BreakpointManagementState.UpdateProjectAction { Project = data });
        }
    }

    public class ProjectDataLoader : IDataLoader<BreakpointProjectSummary>
    {
        private readonly IBreakpointManagementDataService _dataService;
        public ProjectDataLoader(IBreakpointManagementDataService dataService)
        {
            _dataService = dataService;
        }
        public async Task<PaginationResult<BreakpointProjectSummary>> LoadDataAsync(FilterData parameters)
        {
            if (parameters == null) return new PaginationResult<BreakpointProjectSummary>();
            IList<BreakpointProjectSummary> results;
            if (parameters == null)
            {
                results = await _dataService.GetBreakpointProject();
            }
            else if (parameters.Top == null)
            {
                results = await _dataService.GetBreakpointProject();
            }
            else if (string.IsNullOrWhiteSpace(parameters.OrderBy))
            {
                results = await _dataService.GetBreakpointProject(parameters.Top.Value, parameters.Skip.Value);
            }
            else
            {
                var order = parameters.OrderBy.Split(" ");
                if (order.Length >= 2)
                {
                    results = await _dataService.GetBreakpointProject(parameters.Top.Value, parameters.Skip.Value, order[0]);
                }
                else
                {
                    results = await _dataService.GetBreakpointProject(parameters.Top.Value, parameters.Skip.Value);
                }
            }
            var count = await _dataService.GetBreakpointProjectCount();
            return new PaginationResult<BreakpointProjectSummary>
            {
                Records = results,
                Skip = parameters?.Skip ?? 0,
                Total = int.Parse(count),
                Top = parameters?.Top ?? 0
            };
        }
    }
}

