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
    public class OrganismPickerConnect
    {
        public static RenderFragment Get()
        {
            var c = new OrganismPickerConnect();
            return ComponentConnector.Connect<OrganismPicker, BreakpointManagementState, OrganismProp>(c.MapStateToProps, c.MapDispatchToProps);
        }

        private void MapStateToProps(BreakpointManagementState state, OrganismProp props)
        {
            props.Organism = state?.Organism ?? new OrganismName();
        }

        private void MapDispatchToProps(IStore<BreakpointManagementState> store, OrganismProp props)
        {
            props.UpdateOrganism = EventCallback.Factory.Create<OrganismName>(this, organism =>
            {
                store.Dispatch(new UpdateOrganismAction { Organism = organism });
            });
            props.UpdateOrganismList = EventCallback.Factory.Create<IList<OrganismName>>(this, organismList =>
            {
                store.Dispatch(new UpdateOrganismListAction { OrganismList = organismList });
            });
        }
    }
    public partial class OrganismPicker
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }

        [Parameter]
        public OrganismProp Props { get; set; }

        private IList<OrganismName> organismList;

        private OrganismName selected;

        private List<OrganismName> selectedItems = new List<OrganismName>();

        protected override async Task OnInitializedAsync()
        {
            organismList = await dataService.GetAllOrganisms();
            await Props.UpdateOrganismList.InvokeAsync(organismList);
        }
        void RowClick(GridRowClickEventArgs args)
        {
            var data = args.Item as OrganismName;
            selected = data;
            StateHasChanged();
            if (Props != null)
            {
                Props.UpdateOrganism.InvokeAsync(data);
            }
        }
    }
}
