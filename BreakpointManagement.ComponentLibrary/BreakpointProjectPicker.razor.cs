using BlazorState.Redux.Blazor;
using BlazorState.Redux.Interfaces;
using BreakpointManagement.Services;
using BreakpointManagement.Shared.Models;
using BreakpointManagement.Shared.State.Actions;
using BreakpointManagement.Shared.State.BreakpointManagement;
using BreakpointManagement.Shared.State.Props;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

using Telerik.Blazor.Components;

namespace BreakpointManagement.ComponentLibrary
{
    public class BreakpointProjectPickerConnect
    {
        public static RenderFragment Get()
        {
            var c = new BreakpointProjectPickerConnect();
            return ComponentConnector.Connect<BreakpointProjectPicker, BreakpointManagementState, ProjectProps>(c.MapStateToProps, c.MapDispatchToProps);
        }

        private void MapStateToProps(BreakpointManagementState state, ProjectProps props)
        {
            props.Project = state?.Project ?? new Project();
        }

        private void MapDispatchToProps(IStore<BreakpointManagementState> store, ProjectProps props)
        {
            props.UpdateProject = EventCallback.Factory.Create<Project>(this, project =>
            {
                store.Dispatch(new UpdateProjectAction { Project = project });
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
        public ProjectProps Props { get; set; }

        private IList<Project> breakpointProjects;

        private Project selected;

        private List<Project> selectedItems = new List<Project>();

        protected override async Task OnInitializedAsync()
        {
            breakpointProjects = await dataService.GetBreakpointProject();
        }
        async Task RowClick(GridRowClickEventArgs args)
        {
            var data = args.Item as Project;
            selected = data;
            StateHasChanged();
            if (Props != null)
            {
                Props.UpdateProject.InvokeAsync(data);
            }
        }
    }
}

