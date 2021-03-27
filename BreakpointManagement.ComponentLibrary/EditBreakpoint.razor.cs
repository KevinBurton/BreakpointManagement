using BlazorState.Redux.Blazor;
using BlazorState.Redux.Interfaces;
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
            micData = await dataService.GetBreakpointByStandardProjectGroupResultType(Props.Standard.BpstandardId,
                Props.Project.ProjectId,
                Props.Group.BpgroupId,
                "Microdilution");
            diskData = await dataService.GetBreakpointByStandardProjectGroupResultType(Props.Standard.BpstandardId,
                Props.Project.ProjectId,
                Props.Group.BpgroupId,
                "Disk Diffusion");
        }
    }
}
