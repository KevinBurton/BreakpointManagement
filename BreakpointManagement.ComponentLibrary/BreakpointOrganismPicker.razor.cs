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

        private IEnumerable<OrganismName> data;

        private OrganismName selected;

        private List<OrganismName> selectedItems = new List<OrganismName>();

        protected override async Task OnInitializedAsync()
        {
            data = await dataService.GetOrganismByProjectGroup(Props.Project.ProjectId, Props.Group.BpgroupId);
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
}
