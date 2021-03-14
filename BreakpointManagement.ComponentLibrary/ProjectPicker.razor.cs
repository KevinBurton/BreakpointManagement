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
    public class ProjectPickerConnect
    {
        public static RenderFragment Get()
        {
            var c = new ProjectPickerConnect();
            return ComponentConnector.Connect<ProjectPicker, BreakpointManagementState, ProjectProps>(c.MapStateToProps, c.MapDispatchToProps);
        }

        private void MapStateToProps(BreakpointManagementState state, ProjectProps props)
        {
            props.Project = state?.Project ?? new BreakpointProjectSummary();
        }

        private void MapDispatchToProps(IStore<BreakpointManagementState> store, ProjectProps props)
        {
            props.UpdateProject = EventCallback.Factory.Create<BreakpointProjectSummary>(this, project =>
            {
                store.Dispatch(new UpdateProjectAction { Project = project });
            });
        }
    }
    public partial class ProjectPicker
    {
        static ProjectPicker()
        {
            ProjectPickerConnect.Get();
        }

        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }

        [Parameter] 
        public ProjectProps Props { get; set; }

        private IDataLoader<BreakpointProjectSummary> _loader;

        private IEnumerable<BreakpointProjectSummary> data;

        private BreakpointProjectSummary selected;

        private SelectionType selectionType = SelectionType.Single;

        private List<BreakpointProjectSummary> selectedItems = new List<BreakpointProjectSummary>();

        protected override async Task OnInitializedAsync()
        {
            _loader = new ProjectDataLoader(dataService);
            data = (await _loader.LoadDataAsync(new FilterData() { OrderBy = "", Skip = 0, Top = 10 })).Records;
        }
        public void RowClick(BreakpointProjectSummary data)
        {
            selected = data;
            StateHasChanged();
            if (Props != null)
            {
                Props.UpdateProject.InvokeAsync(data);
            }
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
                results = await _dataService.GetBreakpointProject(parameters.Top.Value, parameters.Skip.Value, parameters.OrderBy);
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

