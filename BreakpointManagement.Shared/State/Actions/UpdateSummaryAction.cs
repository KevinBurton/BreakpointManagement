﻿using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;

namespace BreakpointManagement.Shared.State.Actions
{
    public class UpdateSummaryAction : IAction
    {
        public BreakpointSummary Summary { get; set; }
    }
}