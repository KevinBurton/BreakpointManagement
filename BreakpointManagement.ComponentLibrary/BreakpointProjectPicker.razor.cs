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
    public class BreakpointProjectPickerConnect
    {
        public static RenderFragment Get()
        {
            var c = new BreakpointProjectPickerConnect();
            return ComponentConnector.Connect<BreakpointProjectPicker, BreakpointManagementState, ProjectProps>(c.MapStateToProps, c.MapDispatchToProps);
        }

        private void MapStateToProps(BreakpointManagementState state, ProjectProps props)
        {
            props.Project = state?.Project ?? new Project();
        }

        private void MapDispatchToProps(IStore<BreakpointManagementState> store, ProjectProps props)
        {
            props.UpdateProject = EventCallback.Factory.Create<Project>(this, project =>
            {
                store.Dispatch(new UpdateProjectAction { Project = project });
            });
        }
    }
    public partial class BreakpointProjectPicker
    {
        static BreakpointProjectPicker()
        {
            BreakpointProjectPickerConnect.Get();
        }

        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }

        [Parameter] 
        public ProjectProps Props { get; set; }

        private IDataLoader<Project> _loader;

        private IEnumerable<Project> data;

        private Project selected;

        private SelectionType selectionType = SelectionType.Single;

        private List<Project> selectedItems = new List<Project>();

        protected override async Task OnInitializedAsync()
        {
            _loader = new BreakpointProjectPickerDataLoader(dataService);
            data = (await _loader.LoadDataAsync(new FilterData() { OrderBy = "", Skip = 0, Top = 10 })).Records;
        }
        public void RowClick(Project data)
        {
            selected = data;
            StateHasChanged();
            if (Props != null)
            {
                Props.UpdateProject.InvokeAsync(data);
            }
        }
    }

    public class BreakpointProjectPickerDataLoader : IDataLoader<Project>
    {
        private readonly IBreakpointManagementDataService _dataService;
        public BreakpointProjectPickerDataLoader(IBreakpointManagementDataService dataService)
        {
            _dataService = dataService;
        }
        public async Task<PaginationResult<Project>> LoadDataAsync(FilterData parameters)
        {
            if (parameters == null) return new PaginationResult<Project>();
            IList<Project> results;
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
            return new PaginationResult<Project>
            {
                Records = results,
                Skip = parameters?.Skip ?? 0,
                Total = int.Parse(count),
                Top = parameters?.Top ?? 0
            };
        }
    }
}

