﻿using BlazorTable;
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
    public partial class ActiveDrugs
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }
        [Inject]
        private IMediator Mediator { get; set; }

        private IDataLoader<Drug> _loader;

        private IEnumerable<Drug> data;

        private Drug selected;

        private SelectionType selectionType = SelectionType.Single;

        private List<Drug> selectedItems = new List<Drug>();
        
        protected override async Task OnInitializedAsync()
        {
            _loader = new DrugDataLoader(dataService);
            data = (await _loader.LoadDataAsync(null)).Records;
        }
        public void RowClick(Drug data)
        {
            selected = data;
            StateHasChanged();
            Mediator.Send(new BreakpointManagementState.UpdateDrugAction { Drug = data });
        }
    }

    public class DrugDataLoader : IDataLoader<Drug>
    {
        private readonly IBreakpointManagementDataService _dataService;
        public DrugDataLoader(IBreakpointManagementDataService dataService)
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