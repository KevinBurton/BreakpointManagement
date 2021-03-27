using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Props
{
    public class BreakpointOrganismProp
    {
        public Project Project { get; set; }
        public Breakpointgroup Group { get; set; }
        public OrganismName Organism { get; set; }
        public EventCallback<OrganismName> UpdateOrganism { get; set; }
        public EventCallback<List<OrganismName>> UpdateOrganismList { get; set; }
    }
}
