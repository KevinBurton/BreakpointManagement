using System;
using System.Collections.Generic;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    public partial class AdtBreakpointGroup
    {
        public long RecordId { get; set; }
        public int BpgroupId { get; set; }
        public string BpgroupName { get; set; }
        public int BpstandardId { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangeReason { get; set; }
        public string UserAudit { get; set; }
        public string RowState { get; set; }
    }
}
