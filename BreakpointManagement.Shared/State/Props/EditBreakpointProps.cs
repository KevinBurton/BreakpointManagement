using BreakpointManagement.Shared.Models;

namespace BreakpointManagement.Shared.State.Props
{
    public class EditBreakpointProps
    {
        public Project Project { get; set; }
        public Breakpointgroup Group { get; set; }
        public BreakpointStandard Standard { get; set; }
        public Drug Drug { get; set; }
    }
}
