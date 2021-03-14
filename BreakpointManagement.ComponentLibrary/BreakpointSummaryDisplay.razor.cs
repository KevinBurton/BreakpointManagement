using BlazorState.Redux.Blazor;
using BlazorState.Redux.Interfaces;
using BlazorTable;
using BlazorTable.Components.ServerSide;
using BlazorTable.Interfaces;
using BreakpointManagement.Services;
using BreakpointManagement.Shared.Models;
using BreakpointManagement.Shared.State.Actions;
using BreakpointManagement.Shared.State.BreakpointManagement;
using BreakpointManagement.Shared.State.Props;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreakpointManagement.ComponentLibrary
{
    public class BreakpointSummaryDisplayConnect
    {
        public static RenderFragment Get()
        {
            var c = new BreakpointSummaryDisplayConnect();
            return ComponentConnector.Connect<BreakpointSummaryDisplay, BreakpointManagementState, SummaryProps>(c.MapStateToProps, c.MapDispatchToProps);
        }

        private void MapStateToProps(BreakpointManagementState state, SummaryProps props)
        {
            props.Summary = state?.Summary ?? new BreakpointSummary();
        }

        private void MapDispatchToProps(IStore<BreakpointManagementState> store, SummaryProps props)
        {
            props.UpdateSummary = EventCallback.Factory.Create<BreakpointSummary>(this, summary =>
            {
                store.Dispatch(new UpdateSummaryAction { Summary = summary });
            });
        }
    }
    public partial class BreakpointSummaryDisplay
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }

        [Parameter]
        public SummaryProps Props { get; set; }

        private IDataLoader<BreakpointSummary> _loader;

        private IEnumerable<BreakpointSummary> data;

        private BreakpointSummary selected;

        private SelectionType selectionType = SelectionType.Single;

        private List<BreakpointSummary> selectedItems = new List<BreakpointSummary>();

        private BreakpointManagementState BreakpointManagementStateState => null;//GetState<BreakpointManagementState>();

        private BreakpointProjectSummary currentProject => BreakpointManagementStateState?.Project;

        protected override async Task OnInitializedAsync()
        {
            _loader = new BreakpointSummaryDataLoader(dataService, currentProject);
            data = (await _loader.LoadDataAsync(new FilterData() { OrderBy = "ProjectId asc", Skip = 0, Top = 10 })).Records;
        }
        public void RowClick(BreakpointSummary data)
        {
            selected = data;
            StateHasChanged();
            if (Props != null)
            {
                Props.UpdateSummary.InvokeAsync(data);
            }
        }
    }

    public class BreakpointSummaryDataLoader : IDataLoader<BreakpointSummary>
    {
        private readonly IBreakpointManagementDataService _dataService;
        private readonly BreakpointProjectSummary _currentProject;
        public BreakpointSummaryDataLoader(IBreakpointManagementDataService dataService, BreakpointProjectSummary currentProject = null)
        {
            _dataService = dataService;
            _currentProject = currentProject;
        }
        public async Task<PaginationResult<BreakpointSummary>> LoadDataAsync(FilterData parameters)
        {

            int projectId = _currentProject == null ? 0 : _currentProject.ProjectId;

            IList<BreakpointSummary> results;
            if (parameters.Top == null)
            {
                results = await _dataService.GetBreakpointByProject(projectId);
            }
            else if (string.IsNullOrWhiteSpace(parameters.OrderBy))
            {
                results = await _dataService.GetBreakpointByProject(projectId, parameters.Top.Value, parameters.Skip.Value);
            }
            else
            {
                results = await _dataService.GetBreakpointByProject(projectId, parameters.Top.Value, parameters.Skip.Value, parameters.OrderBy);
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
