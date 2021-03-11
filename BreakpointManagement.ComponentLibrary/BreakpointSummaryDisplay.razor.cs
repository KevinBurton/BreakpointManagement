using BlazorTable;
using BlazorTable.Components.ServerSide;
using BlazorTable.Interfaces;
using BreakpointManagement.Services;
using BreakpointManagement.Shared.Features.BreakpointManagement;
using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreakpointManagement.ComponentLibrary
{
    public partial class BreakpointSummaryDisplay
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }

        private IDataLoader<BreakpointSummary> _loader;

        private IEnumerable<BreakpointSummary> data;

        private BreakpointSummary selected;

        private SelectionType selectionType = SelectionType.Single;

        private List<BreakpointSummary> selectedItems = new List<BreakpointSummary>();

        private BreakpointManagementState BreakpointManagementStateState => GetState<BreakpointManagementState>();

        private BreakpointProjectSummary currentProject => BreakpointManagementStateState?.Project;


        protected override async Task OnInitializedAsync()
        {
            _loader = new BreakpointSummaryDataLoader(currentProject, dataService);
            data = (await _loader.LoadDataAsync(null)).Records;
        }
        public void RowClick(BreakpointSummary data)
        {
            selected = data;
            StateHasChanged();
            Mediator.Send(new BreakpointManagementState.UpdateBreakpointSummaryAction { Summary = data });
        }
    }

    public class BreakpointSummaryDataLoader : IDataLoader<BreakpointSummary>
    {
        private readonly IBreakpointManagementDataService _dataService;
        private readonly BreakpointProjectSummary _currentProject;
        public BreakpointSummaryDataLoader(BreakpointProjectSummary currentProject, IBreakpointManagementDataService dataService)
        {
            _dataService = dataService;
            _currentProject = currentProject;
        }
        public async Task<PaginationResult<BreakpointSummary>> LoadDataAsync(FilterData parameters)
        {

            int projectId = _currentProject == null ? 0 : _currentProject.ProjectId;

            IList<BreakpointSummary> results;
            if (parameters == null) return new PaginationResult<BreakpointSummary>();
            if (parameters == null)
            {
                results = await _dataService.GetBreakpointByProject(projectId);
            }
            else if (parameters.Top == null)
            {
                results = await _dataService.GetBreakpointByProject(projectId);
            }
            else if (string.IsNullOrWhiteSpace(parameters.OrderBy))
            {
                results = await _dataService.GetBreakpointByProject(projectId, parameters.Top.Value, parameters.Skip.Value);
            }
            else
            {
                var order = parameters.OrderBy.Split(" ");
                if (order.Length >= 2)
                {
                    results = await _dataService.GetBreakpointByProject(projectId, parameters.Top.Value, parameters.Skip.Value, order[0]);
                }
                else
                {
                    results = await _dataService.GetBreakpointByProject(projectId, parameters.Top.Value, parameters.Skip.Value);
                }
            }
            var count = await _dataService.GetBreakpointByProjectCount(projectId);
            return new PaginationResult<BreakpointSummary>
            {
                Records = results,
                Skip = parameters?.Skip ?? 0,
                Total = int.Parse(count),
                Top = parameters?.Top ?? 0
            };
        }
    }
}
