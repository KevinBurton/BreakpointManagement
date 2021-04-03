using BlazorState.Redux.Blazor;
using BlazorState.Redux.Interfaces;
using BreakpointManagement.Services;
using BreakpointManagement.Shared.Models;
using BreakpointManagement.Shared.State.Actions;
using BreakpointManagement.Shared.State.BreakpointManagement;
using BreakpointManagement.Shared.State.Props;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
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

        private IEnumerable<OrganismName> selectedIncludedOrganisms { get; set; } = Enumerable.Empty<OrganismName>();
        private IEnumerable<OrganismName> selectedExcludedOrganisms { get; set; } = Enumerable.Empty<OrganismName>();
        private IEnumerable<OrganismName> includedOrganisms { get; set; } = Enumerable.Empty<OrganismName>();
        private IEnumerable<OrganismName> excludedOrganisms { get; set; } = Enumerable.Empty<OrganismName>();

        RenderFragment ProjectPickerCmp;
        RenderFragment GroupPickerCmp;
        RenderFragment StandardPickerCmp;

        protected override void OnInitialized()
        {
            ProjectPickerCmp = BreakpointProjectPickerConnect.Get();
            GroupPickerCmp = BreakpointGroupPickerConnect.Get();
            StandardPickerCmp = BreakpointStandardPickerConnect.Get();
        }

        protected async override Task OnParametersSetAsync()
        {
            // Check to see that a group has been picked
            if (!string.IsNullOrWhiteSpace(Props.Group.BpgroupName) &&
                !string.IsNullOrWhiteSpace(Props.Standard.Bpstandard))
            {
                includedOrganisms = (await dataService.GetOrganismByGroup(Props.Group.BpgroupId)) ?? Enumerable.Empty<OrganismName>();
                excludedOrganisms = (await dataService.GetOrganismByExcludedGroup(Props.Group.BpgroupId)) ?? Enumerable.Empty<OrganismName>();
            }
        }
        void OnForwardClick()
        {
            StateHasChanged();
        }
        void OnReverseClick()
        {
            StateHasChanged();
        }
        protected void OnSelectIncluded(IEnumerable<OrganismName> selectedOrganisms)
        {
            selectedIncludedOrganisms = selectedOrganisms;
        }
        protected void OnSelectExcluded(IEnumerable<OrganismName> selectedOrganisms)
        {
            selectedExcludedOrganisms = selectedOrganisms;
        }
    }
}
