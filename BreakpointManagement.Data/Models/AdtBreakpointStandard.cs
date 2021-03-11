using System;
using System.Collections.Generic;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    public partial class AdtBreakpointStandard
    {
        public long RecordId { get; set; }
        public int BpstandardId { get; set; }
        public string Bpstandard { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangeReason { get; set; }
        public string UserAudit { get; set; }
        public string RowState { get; set; }
    }
}
