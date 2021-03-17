using BlazorState.Redux.Blazor;
using BlazorState.Redux.Interfaces;
using BlazorTable;
using BlazorTable.Components.ServerSide;
using BlazorTable.Interfaces;
using BreakpointManagement.Services;
using BreakpointManagement.Shared.Models;
using BreakpointManagement.Shared.State.BreakpointManagement;
using BreakpointManagement.Shared.State.Props;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreakpointManagement.ComponentLibrary
{
    public class GroupingConnect
    {
        public static RenderFragment Get()
        {
            var c = new GroupingConnect();
            return ComponentConnector.Connect<Grouping, BreakpointManagementState, GroupingProps>(c.MapStateToProps, c.MapDispatchToProps);
        }

        private void MapStateToProps(BreakpointManagementState state, GroupingProps props)
        {
            props.Standard = state?.Standard ?? new BreakpointStandard();
            props.Group = state?.Group ?? new Breakpointgroup();
        }

        private void MapDispatchToProps(IStore<BreakpointManagementState> store, GroupingProps props)
        {
        }
    }

    // Blazor lifecycle methods
    // https://blazor-tutorial.net/lifecycle-methods
    // https://blazor-university.com/components/component-lifecycles/
    // OnInitialized
    // OnInitializedAsync
    // OnParametersSet
    // OnParametersSetAsync
    // OnAfterRender
    // OnAfterRenderAsync
    // ShouldRender

    public partial class Grouping
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }

        [Parameter]
        public GroupingProps Props { get; set; }

        private IDataLoader<OrganismName> _groupingLoader;

        private IEnumerable<OrganismName> _groupingData;

        private List<OrganismName> _selectedOrganisms;

        private IDataLoader<OrganismName> _groupingExcludedLoader;

        private IEnumerable<OrganismName> _groupingExcludedData;

        private List<OrganismName> _selectedExcludedOrganisms;

        private RenderFragment BreakpointStandardCmp;
        private RenderFragment BreakpointGroupPickerCmp;

        protected override void OnInitialized()
        {
            BreakpointStandardCmp = BreakpointStandardPickerConnect.Get();
            BreakpointGroupPickerCmp = BreakpointGroupPickerConnect.Get();

            _selectedOrganisms = new List<OrganismName>();
            _selectedExcludedOrganisms = new List<OrganismName>();
        }

        protected async override Task OnParametersSetAsync()
        {
            _groupingLoader = new OrgainismByGroupDataLoader(dataService, Props.Group);
            _groupingData = (await _groupingLoader.LoadDataAsync(new FilterData() { Skip = 0, Top = 10 })).Records;
            _groupingExcludedLoader = new OrgainismByExcludedGroupDataLoader(dataService, Props.Group);
            _groupingExcludedData = (await _groupingExcludedLoader.LoadDataAsync(new FilterData() { Skip = 0, Top = 10 })).Records;
        }
    }
    public class OrgainismByGroupDataLoader : IDataLoader<OrganismName>
    {
        private readonly IBreakpointManagementDataService _dataService;
        private readonly Breakpointgroup _currentGroup;
        public OrgainismByGroupDataLoader(IBreakpointManagementDataService dataService, Breakpointgroup currentGroup = null)
        {
            _dataService = dataService;
            _currentGroup = currentGroup;
        }
        public async Task<PaginationResult<OrganismName>> LoadDataAsync(FilterData parameters)
        {

            int groupId = _currentGroup == null ? 0 : _currentGroup.BpgroupId;

            int count;
            if (int.TryParse(await _dataService.GetOrganismByGroupCount(groupId), out count))
            {
                if(count > 0)
                {
                    IList<OrganismName> results;
                    if (parameters.Top == null)
                    {
                        results = await _dataService.GetOrganismByGroup(groupId);
                    }
                    else if (string.IsNullOrWhiteSpace(parameters.OrderBy))
                    {
                        results = await _dataService.GetOrganismByGroup(groupId, parameters.Top.Value, parameters.Skip.Value);
                    }
                    else
                    {
                        results = await _dataService.GetOrganismByGroup(groupId, parameters.Top.Value, parameters.Skip.Value, parameters.OrderBy);
                    }
                    return new PaginationResult<OrganismName>
                    {
                        Records = results,
                        Skip = parameters?.Skip ?? 0,
                        Total = count,
                        Top = parameters?.Top ?? 0
                    };

                }
            }
            return new PaginationResult<OrganismName>
            {
                Records = new List<OrganismName>(),
                Skip = parameters?.Skip ?? 0,
                Total = 0,
                Top = parameters?.Top ?? 0
            };
        }
    }
    public class OrgainismByExcludedGroupDataLoader : IDataLoader<OrganismName>
    {
        private readonly IBreakpointManagementDataService _dataService;
        private readonly Breakpointgroup _currentGroup;
        public OrgainismByExcludedGroupDataLoader(IBreakpointManagementDataService dataService, Breakpointgroup currentGroup = null)
        {
            _dataService = dataService;
            _currentGroup = currentGroup;
        }
        public async Task<PaginationResult<OrganismName>> LoadDataAsync(FilterData parameters)
        {

            int groupId = _currentGroup == null ? 0 : _currentGroup.BpgroupId;

            int count;
            if(int.TryParse(await _dataService.GetOrganismByExcludedGroupCount(groupId), out count))
            {
                if (count > 0)
                {
                    IList<OrganismName> results;
                    if (parameters.Top == null)
                    {
                        results = await _dataService.GetOrganismByExcludedGroup(groupId);
                    }
                    else if (string.IsNullOrWhiteSpace(parameters.OrderBy))
                    {
                        results = await _dataService.GetOrganismByExcludedGroup(groupId, parameters.Top.Value, parameters.Skip.Value);
                    }
                    else
                    {
                        results = await _dataService.GetOrganismByExcludedGroup(groupId, parameters.Top.Value, parameters.Skip.Value, parameters.OrderBy);
                    }
                    return new PaginationResult<OrganismName>
                    {
                        Records = results,
                        Skip = parameters?.Skip ?? 0,
                        Total = count,
                        Top = parameters?.Top ?? 0
                    };
                }
            }
            return new PaginationResult<OrganismName>
            {
                Records = new List<OrganismName>(),
                Skip = parameters?.Skip ?? 0,
                Total = 0,
                Top = parameters?.Top ?? 0
            };
        }
    }
}
