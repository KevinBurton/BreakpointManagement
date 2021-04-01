using BlazorState.Redux.Blazor;
using BlazorState.Redux.Interfaces;
using BreakpointManagement.Services;
using BreakpointManagement.Shared.Models;
using BreakpointManagement.Shared.State.Actions;
using BreakpointManagement.Shared.State.BreakpointManagement;
using BreakpointManagement.Shared.State.Props;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

using Telerik.Blazor.Components;

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
            props.Project = state?.Project ?? new Project();
        }

        private void MapDispatchToProps(IStore<BreakpointManagementState> store, GroupingProps props)
        {
            props.UpdateStandard = EventCallback.Factory.Create<BreakpointStandard>(this, standard =>
            {
                store.Dispatch(new UpdateStandardAction { Standard = standard });
            });
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

        //private EventConsole console;
        
        [Parameter]
        public GroupingProps Props { get; set; }

        private IList<BreakpointStandard> standardList;
        private BreakpointStandard selectedStandard;

        private IList<Project> _breakpointProjects;
        private IList<OrganismName> _groupingData;
        private IList<OrganismName> _groupingExcludedData;

        BreakpointStandard breakpointStandardList;

        Breakpointgroup currentBreakpointGroup;
        RenderFragment ProjectPickerCmp;
        private List<OrganismName> _selectedOrganisms;
        private List<OrganismName> _selectedExcludedOrganisms;

        protected override void OnInitialized()
        {
            _selectedOrganisms = new List<OrganismName>();
            _selectedExcludedOrganisms = new List<OrganismName>();
            ProjectPickerCmp = BreakpointProjectPickerConnect.Get();

        }

        protected async override Task OnParametersSetAsync()
        {
            standardList = (await dataService.GetAllBreakpointStandards()) ?? new List<BreakpointStandard>();

            // Check to see that a group has been picked
            if (!string.IsNullOrWhiteSpace(Props.Group.BpgroupName) &&
               !string.IsNullOrWhiteSpace(Props.Standard.Bpstandard))
            {
                _groupingData = (await dataService.GetOrganismByGroup(Props.Group.BpgroupId)) ?? new List<OrganismName>();
                _groupingExcludedData = (await dataService.GetOrganismByExcludedGroup(Props.Group.BpgroupId)) ?? new List<OrganismName>();
            }
        }
        async Task RowClick(GridRowClickEventArgs args)
        {
            var data = args.Item as BreakpointStandard;
            selectedStandard = data;
            if (Props != null)
            {
                await Props.UpdateStandard.InvokeAsync(data).ConfigureAwait(false);
            }
            StateHasChanged();
        }
        async Task OnForwardClick()
        {

        }
        async Task OnReverseClick()
        {

        }
    }
}
