using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BreakpointManagement.Shared.Models
{
    public class BreakpointException
    {

        public int BreakpointExceptionId { get; set; }
        public int OrganismId { get; set; }
        public int DrugId { get; set; }
        public int? TestMethodId { get; set; }
        public string BreakPointType { get; set; }
        public float Susceptible { get; set; }
        public float Intermediate { get; set; }
        public float Resistant { get; set; }
        public int BreakPointYear { get; set; }
        public string Dosage { get; set; }
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public Breakpointgroup Group { get; set; }
    }
}
