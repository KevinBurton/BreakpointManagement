namespace BreakpointManagement.Shared.Models
{
    public class BreakpointSummary
    {
        public int ProjectId { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string Method { get; set; }
        public string DrugName { get; set; }
        public decimal Susceptible { get; set; }
        public decimal LowIntermediate { get; set; }
        public decimal Intermediate { get; set; }
        public decimal Resistant { get; set; }
        public string OrganismName { get; set; }
        public string Standard { get; set; }
    }
}
