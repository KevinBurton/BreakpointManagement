using BlazorState;
using BreakpointManagement.Shared.Models;

namespace BreakpointManagement.Shared.Features.BreakpointManagement
{
    public partial class BreakpointManagementState
    {
        public class UpdateOrganismAction : IAction
        {
            public OrganismName Organism { get; set; }
        }
    }
}
