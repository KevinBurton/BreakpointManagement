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
using System.Linq;

namespace BreakpointManagement.ComponentLibrary
{
    public class BreakpointStandardPickerConnect
    {
        public static RenderFragment Get()
        {
            var c = new BreakpointStandardPickerConnect();
            return ComponentConnector.Connect<BreakpointStandardPicker, BreakpointManagementState, StandardProp>(c.MapStateToProps, c.MapDispatchToProps);
        }

        private void MapStateToProps(BreakpointManagementState state, StandardProp props)
        {
            props.Standard = state?.Standard ?? new BreakpointStandard();
        }

        private void MapDispatchToProps(IStore<BreakpointManagementState> store, StandardProp props)
        {
            props.UpdateStandard = EventCallback.Factory.Create<BreakpointStandard>(this, standard =>
            {
                store.Dispatch(new UpdateStandardAction { Standard = standard });
            });
            props.UpdateStandardList = EventCallback.Factory.Create<List<BreakpointStandard>>(this, standardList =>
            {
                store.Dispatch(new UpdateStandardListAction { StandardList = standardList });
            });
        }
    }
    public partial class BreakpointStandardPicker
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }

        [Parameter]
        public StandardProp Props { get; set; }

        private IList<BreakpointStandard> standardListData;

        private BreakpointStandard selected;

        protected override async Task OnParametersSetAsync()
        {
            standardListData = await dataService.GetAllBreakpointStandards();
        }
        public void RowClick(BreakpointStandard data)
        {
            selected = data;
            StateHasChanged();
            if (Props != null)
            {
                Props.UpdateStandard.InvokeAsync(data);
                Props.UpdateStandardList.InvokeAsync((standardListData.Where(s => s != null)).ToList());
            }
        }
    }
}
