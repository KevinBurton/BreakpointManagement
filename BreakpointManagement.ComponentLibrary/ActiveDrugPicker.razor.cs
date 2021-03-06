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
    public class ActiveDrugPickerConnect
    {
        public static RenderFragment Get()
        {
            var c = new ActiveDrugPickerConnect();
            return ComponentConnector.Connect<ActiveDrugPicker, BreakpointManagementState, DrugProps>(c.MapStateToProps, c.MapDispatchToProps);
        }

        private void MapStateToProps(BreakpointManagementState state, DrugProps props)
        {
            props.Drug = state?.Drug ?? new Drug();
        }

        private void MapDispatchToProps(IStore<BreakpointManagementState> store, DrugProps props)
        {
            props.UpdateDrug = EventCallback.Factory.Create<Drug>(this, drug =>
            {
                store.Dispatch(new UpdateDrugAction { Drug = drug });
            });
        }
    }
    public partial class ActiveDrugPicker
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }

        [Parameter]
        public DrugProps Props { get; set; }

        private IEnumerable<Drug> data;

        private Drug selected;

        private List<Drug> selectedItems = new List<Drug>();
        
        protected override async Task OnInitializedAsync()
        {
            data = await dataService.GetAllDrugs();
        }
        public void RowClick(Drug data)
        {
            selected = data;
            StateHasChanged();
            if (Props != null)
            {
                Props.UpdateDrug.InvokeAsync(data);
            }
        }
    }
}