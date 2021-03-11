﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    public partial class AdtDrugClass
    {
        public int RecordId { get; set; }
        public int DrugClassId { get; set; }
        public string DrugClassName { get; set; }
        public string DrugClassAbbr { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UserAudit { get; set; }
        public string RowState { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangeReason { get; set; }
    }
}
