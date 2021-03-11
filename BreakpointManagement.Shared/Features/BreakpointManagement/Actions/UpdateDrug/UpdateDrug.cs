using BlazorState;
using BreakpointManagement.Shared.Models;

namespace BreakpointManagement.Shared.Features.BreakpointManagement
{
    public partial class BreakpointManagementState
    {
        public class UpdateDrugAction : IAction
        {
            public Drug Drug { get; set; }
        }
    }
}
