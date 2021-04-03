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
    public class BreakpointGroupPickerConnect
    {
        public static RenderFragment Get()
        {
            var c = new BreakpointGroupPickerConnect();
            return ComponentConnector.Connect<BreakpointGroupPicker, BreakpointManagementState, BreakpointGroupProps>(c.MapStateToProps, c.MapDispatchToProps);
        }

        private void MapStateToProps(BreakpointManagementState state, BreakpointGroupProps props)
        {
            props.Group = state?.Group ?? new Breakpointgroup();
            props.Standard = state?.Standard ?? new BreakpointStandard();
        }

        private void MapDispatchToProps(IStore<BreakpointManagementState> store, BreakpointGroupProps props)
        {
            props.UpdateGroup = EventCallback.Factory.Create<Breakpointgroup>(this, group =>
            {
                store.Dispatch(new UpdateGroupAction { Group = group });
            });
       }
    }
    public partial class BreakpointGroupPicker
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }

        [Parameter]
        public BreakpointGroupProps Props { get; set; }

        private List<Breakpointgroup> groupListData = new List<Breakpointgroup>();
        bool isLoading { get; set; } = true;

        private Breakpointgroup selected;

        protected override async Task OnParametersSetAsync()
        {
            if(!string.IsNullOrWhiteSpace(Props.Standard.Bpstandard))
            {
                groupListData = (await dataService.GetBreakpointGroupByStandard(Props.Standard.BpstandardId).ConfigureAwait(false)).ToList();
            }
            isLoading = false;
        }
        void RowClick(GridRowClickEventArgs args)
        {
            isLoading = true;
            var data = args.Item as Breakpointgroup;
            selected = data;
            StateHasChanged();
            if (Props != null)
            {
                Props.UpdateGroup.InvokeAsync(data);
            }
        }
        void ValueChange()
        {
            if(true)
            {
                if (Props != null)
                {
                }
            }
        }
    }
}
