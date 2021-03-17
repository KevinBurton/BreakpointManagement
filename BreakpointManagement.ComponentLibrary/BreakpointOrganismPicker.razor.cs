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
    public class BreakpointOrganismPickerConnect
    {
        public static RenderFragment Get()
        {
            var c = new BreakpointOrganismPickerConnect();
            return ComponentConnector.Connect<BreakpointOrganismPicker, BreakpointManagementState, BreakpointOrganismProp>(c.MapStateToProps, c.MapDispatchToProps);
        }

        private void MapStateToProps(BreakpointManagementState state, BreakpointOrganismProp props)
        {
            props.BreakpointGroup = state?.BreakpointGroup ?? new BreakpointSummary();
            props.BreakpointProject = state?.BreakpointProject ?? new BreakpointProjectSummary();
        }

        private void MapDispatchToProps(IStore<BreakpointManagementState> store, BreakpointOrganismProp props)
        {
            props.UpdateBreakpointOrganism = EventCallback.Factory.Create<BreakpointSummary>(this, organism =>
            {
                store.Dispatch(new UpdateBreakpointOrganismAction { BreakpointOrganism = organism });
            });
        }
    }
    public partial class BreakpointOrganismPicker
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }

        [Parameter]
        public BreakpointOrganismProp Props { get; set; }

        private IDataLoader<BreakpointSummary> _loader;

        private IEnumerable<BreakpointSummary> data;

        private BreakpointSummary selected;

        private SelectionType selectionType = SelectionType.Single;

        private List<BreakpointSummary> selectedItems = new List<BreakpointSummary>();

        protected override async Task OnInitializedAsync()
        {
            _loader = new BreakpointOrganismPickerDataLoader(dataService, Props.BreakpointProject, Props.BreakpointGroup);
            data = (await _loader.LoadDataAsync(new FilterData() { OrderBy = "ProjectId asc", Skip = 0, Top = 10 })).Records;
        }
        public void RowClick(BreakpointSummary data)
        {
            selected = data;
            StateHasChanged();
            if (Props != null)
            {
                Props.UpdateBreakpointOrganism.InvokeAsync();
            }
        }
    }
    public class BreakpointOrganismPickerDataLoader : IDataLoader<BreakpointSummary>
    {
        private readonly IBreakpointManagementDataService _dataService;
        private readonly BreakpointProjectSummary _currentProject;
        private readonly BreakpointSummary _currentGroup;
        public BreakpointOrganismPickerDataLoader(IBreakpointManagementDataService dataService, BreakpointProjectSummary currentProject = null, BreakpointSummary currentGroup = null)
        {
            _dataService = dataService;
            _currentProject = currentProject;
            _currentGroup = currentGroup;
        }
        public async Task<PaginationResult<BreakpointSummary>> LoadDataAsync(FilterData parameters)
        {

            int projectId = _currentProject == null ? 0 : _currentProject.ProjectId;
            int groupId = _currentGroup == null ? 0 : _currentGroup.GroupId;
            IList<BreakpointSummary> results;
            if (parameters.Top == null)
            {
                results = await _dataService.GetBreakpointByProjectGroup(projectId, groupId);
            }
            else if (string.IsNullOrWhiteSpace(parameters.OrderBy))
            {
                results = await _dataService.GetBreakpointByProjectGroup(projectId, groupId, parameters.Top.Value, parameters.Skip.Value);
            }
            else
            {
                results = await _dataService.GetBreakpointByProjectGroup(projectId, groupId, parameters.Top.Value, parameters.Skip.Value, parameters.OrderBy);
            }
            var count = await _dataService.GetBreakpointByProjectGroupCount(projectId, groupId);
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
