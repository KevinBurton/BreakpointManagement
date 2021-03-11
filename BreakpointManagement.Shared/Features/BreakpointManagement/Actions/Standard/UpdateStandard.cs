using BlazorState;
using BreakpointManagement.Shared.Models;

namespace BreakpointManagement.Shared.Features.BreakpointManagement
{
    public partial class BreakpointManagementState
    {
        public class UpdateStandardAction : IAction
        {
            public BreakpointStandard Standard { get; set; }
        }
    }
}
