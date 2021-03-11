using System;

namespace BreakpointManagement.Data.Models
{
    public partial class TblBreakpointHistory
    {
        public int BreakpointId { get; set; }
        public int BreakpointGroupId { get; set; }
        public int DrugId { get; set; }
        public int? TestMethodId { get; set; }
        public string BreakpointType { get; set; }
        public float Susceptible { get; set; }
        public float? Intermediate { get; set; }
        public float Resistant { get; set; }
        public int BreakpointYear { get; set; }
        public string DosageType { get; set; }
         public string Dosage { get; set; }
        public string DisplayValue { get; set; }
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
