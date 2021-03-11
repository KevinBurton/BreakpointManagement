using System;
using System.Collections.Generic;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    public partial class TblProjectStatus
    {
        public long ProjectStatusId { get; set; }
        public int ProjectId { get; set; }
        public long IsolateId { get; set; }
        public short SusceptibilityStatus { get; set; }
        public short? MolecularStatus { get; set; }
        public string Comments { get; set; }
    }
}
