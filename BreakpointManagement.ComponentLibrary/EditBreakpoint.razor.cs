using BlazorState.Redux.Blazor;
using BlazorState.Redux.Interfaces;
using BlazorTable.Components.ServerSide;
using BlazorTable.Interfaces;
using BreakpointManagement.Services;
using BreakpointManagement.Shared.Models;
using BreakpointManagement.Shared.State.BreakpointManagement;
using BreakpointManagement.Shared.State.Props;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreakpointManagement.ComponentLibrary
{
    public class EditBreakpointConnect
    {
        public static RenderFragment Get()
        {
            var c = new EditBreakpointConnect();
            return ComponentConnector.Connect<EditBreakpoint, BreakpointManagementState, EditBreakpointProps>(c.MapStateToProps, c.MapDispatchToProps);
        }

        private void MapStateToProps(BreakpointManagementState state, EditBreakpointProps props)
        {
            props.Group = state?.Group ?? new Breakpointgroup();
            props.Standard = state?.Standard ?? new BreakpointStandard();
            props.Project = state?.Project ?? new Project();
            props.Drug = state?.Drug ?? new Drug();
        }

        private void MapDispatchToProps(IStore<BreakpointManagementState> store, EditBreakpointProps props)
        {
        }
    }
    public partial class EditBreakpoint
    {
        [Inject]
        private IBreakpointManagementDataService dataService { get; set; }

        [Parameter]
        public EditBreakpointProps Props { get; set; }

        private IDataLoader<Breakpoint> _micLoader;
        private IDataLoader<Breakpoint> _diskLoader;
        private IEnumerable<Breakpoint> micData;
        private IEnumerable<Breakpoint> diskData;
        private List<Breakpoint> selectedMICItems = new List<Breakpoint>();
        private List<Breakpoint> selectedDiskItems = new List<Breakpoint>();

        private RenderFragment BreakpointStandardCmp;
        private RenderFragment BreakpointProjectCmp;
        private RenderFragment BreakpointGroupCmp;

        protected override void OnInitialized()
        {
            BreakpointStandardCmp = BreakpointStandardPickerConnect.Get();
            BreakpointProjectCmp = BreakpointProjectPickerConnect.Get();
            BreakpointGroupCmp = BreakpointGroupPickerConnect.Get();
        }

        protected override async Task OnParametersSetAsync()
        {
            _micLoader = new EditBreakpointDataLoader(dataService, "Microdilution", Props.Standard, Props.Project, Props.Group);
            _diskLoader = new EditBreakpointDataLoader(dataService, "Disk Diffusion", Props.Standard, Props.Project, Props.Group);
            micData = (await _micLoader.LoadDataAsync(new FilterData() { OrderBy = "BreakpointId", Skip = 0, Top = 10 })).Records;
            diskData = (await _diskLoader.LoadDataAsync(new FilterData() { OrderBy = "BreakpointId", Skip = 0, Top = 10 })).Records;
        }

    }
    public class EditBreakpointDataLoader : IDataLoader<Breakpoint>
    {
        private readonly IBreakpointManagementDataService _dataService;
        private readonly BreakpointStandard _currentStandard;
        private readonly Project _currentProject;
        private readonly Breakpointgroup _currentGroup;
        private readonly string _resultType;
        public EditBreakpointDataLoader(IBreakpointManagementDataService dataService,
                                        string resultType,
                                        BreakpointStandard currentStandard = null,
                                        Project currentProject = null,
                                        Breakpointgroup currentGroup = null)
        {
            _dataService = dataService;
            _resultType = resultType;
            _currentStandard = currentStandard;
            _currentProject = currentProject;
            _currentGroup = currentGroup;
        }
        public async Task<PaginationResult<Breakpoint>> LoadDataAsync(FilterData parameters)
        {

            int standardId = _currentStandard == null ? 0 : _currentStandard.BpstandardId;
            int projectId = _currentProject == null ? 0 : _currentProject.ProjectId;
            int groupId = _currentGroup == null ? 0 : _currentGroup.BpgroupId;

            IList<Breakpoint> results;
            if (parameters.Top == null)
            {
                results = await _dataService.GetBreakpointByStandardProjectGroupResultType(standardId, projectId, groupId, _resultType);
            }
            else if (string.IsNullOrWhiteSpace(parameters.OrderBy))
            {
                results = await _dataService.GetBreakpointByStandardProjectGroupResultType(standardId, projectId, groupId, _resultType, parameters.Top.Value, parameters.Skip.Value);
            }
            else
            {
                results = await _dataService.GetBreakpointByStandardProjectGroupResultType(standardId, projectId, groupId, _resultType, parameters.Top.Value, parameters.Skip.Value, parameters.OrderBy);
            }
            var count = await _dataService.GetBreakpointByStandardProjectGroupResultTypeCount(standardId, projectId, groupId, _resultType);
            return new PaginationResult<Breakpoint>
            {
                Records = results,
                Skip = parameters?.Skip ?? 0,
                Total = int.Parse(count),
                Top = parameters?.Top ?? 0
            };
        }
    }
}
