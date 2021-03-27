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
            props.StandardList = state?.StandardList ?? new List<BreakpointStandard>();
        }

        private void MapDispatchToProps(IStore<BreakpointManagementState> store, BreakpointGroupProps props)
        {
            props.UpdateGroup = EventCallback.Factory.Create<Breakpointgroup>(this, group =>
            {
                store.Dispatch(new UpdateGroupAction { Group = group });
            });
            props.UpdateGroupList = EventCallback.Factory.Create<List<Breakpointgroup>>(this, groupList =>
            {
                store.Dispatch(new UpdateGroupListAction { GroupList = groupList });
            });
        }
    }
    public partial class BreakpointGroupPicker
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }

        [Parameter]
        public BreakpointGroupProps Props { get; set; }

        private IList<Breakpointgroup> groupListData;

        private Breakpointgroup selected;

        private List<Breakpointgroup> selectedItems = new List<Breakpointgroup>();

        protected override async Task OnParametersSetAsync()
        {
            if(!string.IsNullOrWhiteSpace(Props.Standard.Bpstandard))
            {
                groupListData = await dataService.GetBreakpointGroupByStandard(Props.Standard.BpstandardId);
            }
        }
        public void RowClick(Breakpointgroup data)
        {
            selected = data;
            StateHasChanged();
            if (Props != null)
            {
                Props.UpdateGroup.InvokeAsync(data);
                Props.UpdateGroupList.InvokeAsync((groupListData.Where(g => g != null)).ToList());
            }
        }
    }
}
