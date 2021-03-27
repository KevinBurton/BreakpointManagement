﻿using BlazorState.Redux.Blazor;
using BlazorState.Redux.Interfaces;
using BreakpointManagement.Services;
using BreakpointManagement.Shared.Models;
using BreakpointManagement.Shared.State.BreakpointManagement;
using BreakpointManagement.Shared.State.Props;
using Microsoft.AspNetCore.Components;
using Radzen;
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

        private IList<BreakpointStandard> standardList;

        private IList<Breakpoint> micData;
        private IList<Breakpoint> diskData;

        private List<Breakpoint> selectedMICItems = new List<Breakpoint>();
        private List<Breakpoint> selectedDiskItems = new List<Breakpoint>();

        Breakpointgroup currentBreakpointGroup;
        private RenderFragment BreakpointProjectCmp;

        protected override async Task OnInitializedAsync()
        {
            standardList = (await dataService.GetAllBreakpointStandards()) ?? new List<BreakpointStandard>();
            BreakpointProjectCmp = BreakpointProjectPickerConnect.Get();
        }

        protected override async Task OnParametersSetAsync()
        {
            micData = currentBreakpointGroup != null ? await dataService.GetBreakpointByStandardProjectGroupResultType(currentBreakpointGroup.BpstandardId,
                                                                                                                       Props.Project.ProjectId,
                                                                                                                       currentBreakpointGroup.BpgroupId,
                                                                                                                       "Microdilution") :
                                                       new List<Breakpoint>();
            diskData = currentBreakpointGroup != null ? await dataService.GetBreakpointByStandardProjectGroupResultType(currentBreakpointGroup.BpstandardId,
                                                                                                                        Props.Project.ProjectId,
                                                                                                                        currentBreakpointGroup.BpgroupId,
                                                                                                                        "Disk Diffusion") :
                                                        new List<Breakpoint>();
        }
        protected void OnChange(TreeEventArgs args)
        {
            currentBreakpointGroup = args.Value as Breakpointgroup;
        }
        protected void OnExpand(TreeExpandEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine(args.Text);
        }
        void OnLoad(TreeExpandEventArgs args)
        {
            var standard = args.Value as BreakpointStandard;

            args.Children.Data = standard.Groups ?? new List<Breakpointgroup>();
            args.Children.TextProperty = "BpgroupName";
            args.Children.HasChildren = (group) => false;

            OnExpand(args);
        }
    }
}
