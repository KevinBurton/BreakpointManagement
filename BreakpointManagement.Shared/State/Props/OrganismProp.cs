using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BreakpointManagement.Shared.State.Props
{
    public class OrganismProp
    {
        public OrganismName Organism { get; set; }
        public EventCallback<OrganismName> UpdateOrganism { get; set; }
    }
}
