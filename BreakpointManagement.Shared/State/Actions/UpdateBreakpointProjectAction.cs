using BlazorState.Redux.Interfaces;
using BreakpointManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakpointManagement.Shared.State.Actions
{
    public class UpdateBreakpointProjectAction : IAction
    {
        public BreakpointProjectSummary BreakpointProject { get; set; }
    }
}
