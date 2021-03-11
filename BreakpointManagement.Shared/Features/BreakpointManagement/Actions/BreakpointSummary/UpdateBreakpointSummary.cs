using BlazorState;
using BreakpointManagement.Shared.Models;

namespace BreakpointManagement.Shared.Features.BreakpointManagement
{
    public partial class BreakpointManagementState
    {
        public class UpdateBreakpointSummaryAction : IAction
        {
            public BreakpointSummary Summary { get; set; }
        }
    }
}
