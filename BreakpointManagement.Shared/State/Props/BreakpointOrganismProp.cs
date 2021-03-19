using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BreakpointManagement.Shared.State.Props
{
    public class BreakpointOrganismProp
    {
        public Project Project { get; set; }
        public Breakpointgroup Group { get; set; }
        public OrganismName Organism { get; set; }
        public EventCallback<OrganismName> UpdateOrganism { get; set; }
    }
}
