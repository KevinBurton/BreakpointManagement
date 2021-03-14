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
        }
    }
    public partial class OrganismPicker
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }

        [Parameter]
        public OrganismProp Props { get; set; }

        private IDataLoader<OrganismName> _loader;

        private IEnumerable<OrganismName> data;

        private OrganismName selected;

        private SelectionType selectionType = SelectionType.Single;

        private List<OrganismName> selectedItems = new List<OrganismName>();

        protected override async Task OnInitializedAsync()
        {
            _loader = new OrganismDataLoader(dataService);
            data = (await _loader.LoadDataAsync(new FilterData() { Skip = 0, Top = 10 })).Records;
        }
        public void RowClick(OrganismName data)
        {
            selected = data;
            StateHasChanged();
            if (Props != null)
            {
                Props.UpdateOrganism.InvokeAsync(data);
            }
        }
    }

    public class OrganismDataLoader : IDataLoader<OrganismName>
    {
        private readonly IBreakpointManagementDataService _dataService;
        public OrganismDataLoader(IBreakpointManagementDataService dataService)
        {
            _dataService = dataService;
        }
        public async Task<PaginationResult<OrganismName>> LoadDataAsync(FilterData parameters)
        {
            IList<OrganismName> results;
            if (parameters == null) return new PaginationResult<OrganismName>();
            if (parameters == null)
            {
                results = await _dataService.GetAllOrganisms();
            }
            else if(parameters.Top == null)
            {
                results = await _dataService.GetAllOrganisms();
            }
            else if(string.IsNullOrWhiteSpace(parameters.OrderBy))
            {
                results = await _dataService.GetAllOrganisms(parameters.Top.Value, parameters.Skip.Value);
            }
            else
            {
                var order = parameters.OrderBy.Split(" ");
                if(order.Length >= 2)
                {
                    results = await _dataService.GetAllOrganisms(parameters.Top.Value, parameters.Skip.Value, order[0]);
                }
                else
                {
                    results = await _dataService.GetAllOrganisms(parameters.Top.Value, parameters.Skip.Value);
                }
            }
            var count = await _dataService.GetOrganismCount();
            return new PaginationResult<OrganismName>
            {
                Records = results,
                Skip = parameters?.Skip ?? 0,
                Total = int.Parse(count),
                Top = parameters?.Top ?? 0
            };
        }
    }
}
