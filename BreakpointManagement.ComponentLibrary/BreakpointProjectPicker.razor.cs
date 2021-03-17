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
    public class BreakpointProjectPickerConnect
    {
        public static RenderFragment Get()
        {
            var c = new BreakpointProjectPickerConnect();
            return ComponentConnector.Connect<BreakpointProjectPicker, BreakpointManagementState, BreakpointProjectProps>(c.MapStateToProps, c.MapDispatchToProps);
        }

        private void MapStateToProps(BreakpointManagementState state, BreakpointProjectProps props)
        {
            props.BreakpointProject = state?.BreakpointProject ?? new BreakpointProjectSummary();
        }

        private void MapDispatchToProps(IStore<BreakpointManagementState> store, BreakpointProjectProps props)
        {
            props.UpdateBreakpointProject = EventCallback.Factory.Create<BreakpointProjectSummary>(this, project =>
            {
                store.Dispatch(new UpdateBreakpointProjectAction { BreakpointProject = project });
            });
        }
    }
    public partial class BreakpointProjectPicker
    {
        static BreakpointProjectPicker()
        {
            BreakpointProjectPickerConnect.Get();
        }

        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }

        [Parameter] 
        public BreakpointProjectProps Props { get; set; }

        private IDataLoader<BreakpointProjectSummary> _loader;

        private IEnumerable<BreakpointProjectSummary> data;

        private BreakpointProjectSummary selected;

        private SelectionType selectionType = SelectionType.Single;

        private List<BreakpointProjectSummary> selectedItems = new List<BreakpointProjectSummary>();

        protected override async Task OnInitializedAsync()
        {
            _loader = new BreakpointProjectPickerDataLoader(dataService);
            data = (await _loader.LoadDataAsync(new FilterData() { OrderBy = "", Skip = 0, Top = 10 })).Records;
        }
        public void RowClick(BreakpointProjectSummary data)
        {
            selected = data;
            StateHasChanged();
            if (Props != null)
            {
                Props.UpdateBreakpointProject.InvokeAsync(data);
            }
        }
    }

    public class BreakpointProjectPickerDataLoader : IDataLoader<BreakpointProjectSummary>
    {
        private readonly IBreakpointManagementDataService _dataService;
        public BreakpointProjectPickerDataLoader(IBreakpointManagementDataService dataService)
        {
            _dataService = dataService;
        }
        public async Task<PaginationResult<BreakpointProjectSummary>> LoadDataAsync(FilterData parameters)
        {
            if (parameters == null) return new PaginationResult<BreakpointProjectSummary>();
            IList<BreakpointProjectSummary> results;
            if (parameters == null)
            {
                results = await _dataService.GetBreakpointProject();
            }
            else if (parameters.Top == null)
            {
                results = await _dataService.GetBreakpointProject();
            }
            else if (string.IsNullOrWhiteSpace(parameters.OrderBy))
            {
                results = await _dataService.GetBreakpointProject(parameters.Top.Value, parameters.Skip.Value);
            }
            else
            {
                results = await _dataService.GetBreakpointProject(parameters.Top.Value, parameters.Skip.Value, parameters.OrderBy);
            }
            var count = await _dataService.GetBreakpointProjectCount();
            return new PaginationResult<BreakpointProjectSummary>
            {
                Records = results,
                Skip = parameters?.Skip ?? 0,
                Total = int.Parse(count),
                Top = parameters?.Top ?? 0
            };
        }
    }
}

