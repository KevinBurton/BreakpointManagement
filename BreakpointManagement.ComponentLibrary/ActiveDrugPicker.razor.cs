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

        private IDataLoader<Drug> _loader;

        private IEnumerable<Drug> data;

        private Drug selected;

        private SelectionType selectionType = SelectionType.Single;

        private List<Drug> selectedItems = new List<Drug>();
        
        protected override async Task OnInitializedAsync()
        {
            _loader = new ActiveDrugPickerDrugDataLoader(dataService);
            data = (await _loader.LoadDataAsync(new FilterData() { OrderBy = "", Skip = 0, Top = 10 })).Records;
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

    public class ActiveDrugPickerDrugDataLoader : IDataLoader<Drug>
    {
        private readonly IBreakpointManagementDataService _dataService;
        public ActiveDrugPickerDrugDataLoader(IBreakpointManagementDataService dataService)
        {
            _dataService = dataService;
        }
        public async Task<PaginationResult<Drug>> LoadDataAsync(FilterData parameters)
        {
            IList<Drug> results;
            if (parameters == null) return new PaginationResult<Drug>();
            if (parameters == null)
            {
                results = await _dataService.GetAllDrugs();
            }
            else if (parameters.Top == null)
            {
                results = await _dataService.GetAllDrugs();
            }
            else if (string.IsNullOrWhiteSpace(parameters.OrderBy))
            {
                results = await _dataService.GetAllDrugs(parameters.Top.Value, parameters.Skip.Value);
            }
            else
            {
                var order = parameters.OrderBy.Split(" ");
                if (order.Length >= 2)
                {
                    results = await _dataService.GetAllDrugs(parameters.Top.Value, parameters.Skip.Value, order[0]);
                }
                else
                {
                    results = await _dataService.GetAllDrugs(parameters.Top.Value, parameters.Skip.Value);
                }
            }
            var count = await _dataService.GetDrugCount();
            return new PaginationResult<Drug>
            {
                Records = results,
                Skip = parameters?.Skip ?? 0,
                Total = int.Parse(count),
                Top = parameters?.Top ?? 0
            };
        }
    }
}