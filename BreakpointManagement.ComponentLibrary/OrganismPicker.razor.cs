using BlazorTable;
using BlazorTable.Components.ServerSide;
using BlazorTable.Interfaces;
using BreakpointManagement.Services;
using BreakpointManagement.Shared.Features.BreakpointManagement;
using BreakpointManagement.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreakpointManagement.ComponentLibrary
{
    public partial class OrganismPicker
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }
        [Inject]
        private IMediator Mediator { get; set; }

        private IDataLoader<OrganismName> _loader;

        private IEnumerable<OrganismName> data;

        private OrganismName selected;

        private SelectionType selectionType = SelectionType.Single;

        private List<OrganismName> selectedItems = new List<OrganismName>();

        protected override async Task OnInitializedAsync()
        {
            _loader = new OrganismDataLoader(dataService);
            data = (await _loader.LoadDataAsync(null)).Records;
        }
        public void RowClick(OrganismName data)
        {
            selected = data;
            StateHasChanged();
            Mediator.Send(new BreakpointManagementState.UpdateOrganismAction { Organism = data });
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
