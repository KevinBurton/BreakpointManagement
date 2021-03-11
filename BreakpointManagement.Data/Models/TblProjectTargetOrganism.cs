using System;
using System.Collections.Generic;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    public partial class TblProjectTargetOrganism
    {
        public int ProjectTargetOrganismId { get; set; }
        public int? ProjectId { get; set; }
        public int? OrganismId { get; set; }
        public int? Include { get; set; }
        public string InsertUser { get; set; }
        public DateTime? InsertDatetime { get; set; }
    }
}
