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
            props.Group = state?.Group ?? new Breakpointgroup();
            props.Project = state?.Project ?? new Project();
        }

        private void MapDispatchToProps(IStore<BreakpointManagementState> store, BreakpointOrganismProp props)
        {
            props.UpdateOrganism = EventCallback.Factory.Create<OrganismName>(this, organism =>
            {
                store.Dispatch(new UpdateOrganismAction { Organism = organism });
            });
        }
    }
    public partial class BreakpointOrganismPicker
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }

        [Parameter]
        public BreakpointOrganismProp Props { get; set; }

        private IDataLoader<OrganismName> _loader;

        private IEnumerable<OrganismName> data;

        private OrganismName selected;

        private SelectionType selectionType = SelectionType.Single;

        private List<OrganismName> selectedItems = new List<OrganismName>();

        protected override async Task OnInitializedAsync()
        {
            _loader = new BreakpointOrganismPickerDataLoader(dataService, Props.Project, Props.Group);
            data = (await _loader.LoadDataAsync(new FilterData() { OrderBy = "ProjectId asc", Skip = 0, Top = 10 })).Records;
        }
        public void RowClick(OrganismName data)
        {
            selected = data;
            StateHasChanged();
            if (Props != null)
            {
                Props.UpdateOrganism.InvokeAsync();
            }
        }
    }
    public class BreakpointOrganismPickerDataLoader : IDataLoader<OrganismName>
    {
        private readonly IBreakpointManagementDataService _dataService;
        private readonly Project _currentProject;
        private readonly Breakpointgroup _currentGroup;
        public BreakpointOrganismPickerDataLoader(IBreakpointManagementDataService dataService, Project currentProject = null, Breakpointgroup currentGroup = null)
        {
            _dataService = dataService;
            _currentProject = currentProject;
            _currentGroup = currentGroup;
        }
        public async Task<PaginationResult<OrganismName>> LoadDataAsync(FilterData parameters)
        {

            int projectId = _currentProject == null ? 0 : _currentProject.ProjectId;
            int groupId = _currentGroup == null ? 0 : _currentGroup.BpgroupId;
            IList<OrganismName> results;
            if (parameters.Top == null)
            {
                results = await _dataService.GetOrganismByProjectGroup(projectId, groupId);
            }
            else if (string.IsNullOrWhiteSpace(parameters.OrderBy))
            {
                results = await _dataService.GetOrganismByProjectGroup(projectId, groupId, parameters.Top.Value, parameters.Skip.Value);
            }
            else
            {
                results = await _dataService.GetOrganismByProjectGroup(projectId, groupId, parameters.Top.Value, parameters.Skip.Value, parameters.OrderBy);
            }
            var count = await _dataService.GetOrganismByProjectGroupCount(projectId, groupId);
            return new PaginationResult<OrganismName>
            {
                Records = results,
                Skip = parameters?.Skip ?? 0,
                Total = int.Parse(count),
                Top = parameters?.Top ?? 0
            };
        }
    }
}
