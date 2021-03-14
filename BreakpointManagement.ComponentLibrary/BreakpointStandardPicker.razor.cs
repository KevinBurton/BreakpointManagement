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
        }
    }
    public partial class BreakpointStandardPicker
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }

        [Parameter]
        public StandardProp Props { get; set; }

        private IDataLoader<BreakpointStandard> _loader;

        private IEnumerable<BreakpointStandard> data;

        private BreakpointStandard selected;

        private SelectionType selectionType = SelectionType.Single;

        private List<BreakpointStandard> selectedItems = new List<BreakpointStandard>();

        protected override async Task OnInitializedAsync()
        {
            _loader = new BreakpointStandardDataLoader(dataService);
            data = (await _loader.LoadDataAsync(new FilterData() { Skip = 0, Top = 10 })).Records;
        }
        public void RowClick(BreakpointStandard data)
        {
            selected = data;
            StateHasChanged();
            if (Props != null)
            {
                Props.UpdateStandard.InvokeAsync(data);
            }
        }
    }

    public class BreakpointStandardDataLoader : IDataLoader<BreakpointStandard>
    {
        private readonly IBreakpointManagementDataService _dataService;
        public BreakpointStandardDataLoader(IBreakpointManagementDataService dataService)
        {
            _dataService = dataService;
        }
        public async Task<PaginationResult<BreakpointStandard>> LoadDataAsync(FilterData parameters)
        {
            IList<BreakpointStandard> results;
            if (parameters == null) return new PaginationResult<BreakpointStandard>();
            if (parameters == null)
            {
                results = await _dataService.GetAllBreakpointStandards();
            }
            else if (parameters.Top == null)
            {
                results = await _dataService.GetAllBreakpointStandards();
            }
            else if (string.IsNullOrWhiteSpace(parameters.OrderBy))
            {
                results = await _dataService.GetAllBreakpointStandards(parameters.Top.Value, parameters.Skip.Value);
            }
            else
            {
                var order = parameters.OrderBy.Split(" ");
                if (order.Length >= 2)
                {
                    results = await _dataService.GetAllBreakpointStandards(parameters.Top.Value, parameters.Skip.Value, order[0]);
                }
                else
                {
                    results = await _dataService.GetAllBreakpointStandards(parameters.Top.Value, parameters.Skip.Value);
                }
            }
            var count = await _dataService.GetBreakpointStandardCount();
            return new PaginationResult<BreakpointStandard>
            {
                Records = results,
                Skip = parameters?.Skip ?? 0,
                Total = int.Parse(count),
                Top = parameters?.Top ?? 0
            };
        }
    }
}
