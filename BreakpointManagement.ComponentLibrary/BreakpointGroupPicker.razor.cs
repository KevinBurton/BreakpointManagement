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

        private IDataLoader<Breakpointgroup> _loader;

        private IEnumerable<Breakpointgroup> data;

        private Breakpointgroup selected;

        private SelectionType selectionType = SelectionType.Single;

        private List<Breakpointgroup> selectedItems = new List<Breakpointgroup>();

        protected override async Task OnParametersSetAsync()
        {
            _loader = new BreakpointGroupPickerDataLoader(dataService, Props.Standard);
            data = (await _loader.LoadDataAsync(null)).Records;
        }
        public void RowClick(Breakpointgroup data)
        {
            selected = data;
            StateHasChanged();
            if (Props != null)
            {
                Props.UpdateGroup.InvokeAsync(data);
            }
        }
    }

    public class BreakpointGroupPickerDataLoader : IDataLoader<Breakpointgroup>
    {
        private readonly IBreakpointManagementDataService _dataService;
        private readonly BreakpointStandard _currentStandard;
        public BreakpointGroupPickerDataLoader(IBreakpointManagementDataService dataService, BreakpointStandard currentStandard = null)
        {
            _dataService = dataService;
            _currentStandard = currentStandard;
        }
        public async Task<PaginationResult<Breakpointgroup>> LoadDataAsync(FilterData parameters)
        {

            int standardId = _currentStandard == null ? 0 : _currentStandard.BpstandardId;

            IList<Breakpointgroup> results;
            if (parameters == null || parameters.Top == null)
            {
                results = await _dataService.GetBreakpointGroupByStandard(standardId);
            }
            else if (string.IsNullOrWhiteSpace(parameters.OrderBy))
            {
                results = await _dataService.GetBreakpointGroupByStandard(standardId, parameters.Top.Value, parameters.Skip.Value);
            }
            else
            {
                results = await _dataService.GetBreakpointGroupByStandard(standardId, parameters.Top.Value, parameters.Skip.Value, parameters.OrderBy);
            }
            var count = await _dataService.GetBreakpointGroupByStandardCount(standardId);
            return new PaginationResult<Breakpointgroup>
            {
                Records = results,
                Skip = parameters?.Skip ?? 0,
                Total = int.Parse(count),
                Top = parameters?.Top ?? 0
            };
        }
    }
}
