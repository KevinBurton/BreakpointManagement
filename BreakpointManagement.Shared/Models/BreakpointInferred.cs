namespace BreakpointManagement.Shared.Models
{
    public class BreakpointInferred
    {
        public int BpgroupId { get; set; }
        public int DrugId { get; set; }
        public string ResultType { get; set; }
        public int DrugInferredFrom { get; set; }
    }
}
