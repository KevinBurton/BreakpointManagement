using System;
using System.Collections.Generic;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    public partial class AdtDrug
    {
        public int DrugId { get; set; }
        public int DrugSubclassId { get; set; }
        public string DrugName { get; set; }
        public string DrugAbbr { get; set; }
        public bool ForPublicUse { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserAudit { get; set; }
        public string RowState { get; set; }
        public DateTime ChangeDate { get; set; }
        public DateTime? ChangeReason { get; set; }
        public bool? Active { get; set; }
    }
}
