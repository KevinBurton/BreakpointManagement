using BlazorState;
using BreakpointManagement.Shared.Models;

namespace BreakpointManagement.Shared.Features.BreakpointManagement
{
    public partial class BreakpointManagementState
    {
        public class UpdateProjectAction : IAction
        {
            public BreakpointProjectSummary Project { get; set; }
        }
    }
}
