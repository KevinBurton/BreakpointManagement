using System;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.Models
{
    public class DrugClass
    {
        public DrugClass()
        {
            TblDrugSubclasses = new HashSet<DrugSubclass>();
        }
        public int DrugClassId { get; set; }
        public string DrugClassName { get; set; }
        public string DrugClassAbbr { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<DrugSubclass> TblDrugSubclasses { get; set; }
    }
}
