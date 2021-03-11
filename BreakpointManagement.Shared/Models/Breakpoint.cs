using System;

namespace BreakpointManagement.Shared.Models
{
    public class Breakpoint
    {
        public int BreakpointId { get; set; }
        public string ResultType { get; set; }
        public int BpgroupId { get; set; }
        public int DrugId { get; set; }
        public decimal Susceptible { get; set; }
        public decimal LowIntermediate { get; set; }
        public decimal Intermediate { get; set; }
        public decimal Resistant { get; set; }
        public string DisplayedAs { get; set; }
        public string Dosage { get; set; }
        public string DosageType { get; set; }
        public string Comment { get; set; }
        public int RepresentedBy { get; set; }
        public bool UseNotation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ScrSusceptible { get; set; }
        public string ScrLowIntermediate { get; set; }
        public string ScrHighIntermediate { get; set; }
        public string ScrResistant { get; set; }
        public int ProjectId { get; set; }
        public string Bpyear { get; set; }
    }
}
