using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Props
{
    public class OrganismProp
    {
        public OrganismName Organism { get; set; }
        public IList<OrganismName> OrganismList { get; set; }
        public EventCallback<OrganismName> UpdateOrganism { get; set; }
        public EventCallback<IList<OrganismName>> UpdateOrganismList { get; set; }
    }
}
