using System;

namespace BreakpointManagement.Shared.Models
{
    public class Drug
    {
        public int DrugId { get; set; }
        public int DrugSubclassId { get; set; }
        public string DrugName { get; set; }
        public string DrugAbbr { get; set; }
        public bool ForPublicUse { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? CombinationDrug { get; set; }
        public bool? FixedRatio { get; set; }
        public decimal? Proportion { get; set; }
        public bool Active { get; set; }
        public virtual DrugSubclass DrugSubclass { get; set; }
    }
}
