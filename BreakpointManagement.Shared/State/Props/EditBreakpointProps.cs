using BreakpointManagement.Shared.Models;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.State.Props
{
    public class EditBreakpointProps
    {
        public Project Project { get; set; }
        public Drug Drug { get; set; }
        public List<Drug> DrugList { get; set; }
    }
}
