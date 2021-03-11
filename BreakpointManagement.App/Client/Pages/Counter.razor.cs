using BreakpointManagement.Shared.Features.BreakpointManagement;
using BreakpointManagement.Shared.Models;

namespace BreakpointManagement.App.Client.Pages
{
    public partial class Counter
    {
        BreakpointManagementState BreakpointManagementState => GetState<BreakpointManagementState>();

        private BreakpointProjectSummary currentProject => BreakpointManagementState.Project;

        void IncrementCount()
        {
            //currentCount++;
        }
    }
}