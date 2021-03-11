using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BreakpointManagement.Shared.Models
{
    public class DrugSubclass
    {
        public DrugSubclass()
        {
            TblDrugs = new HashSet<Drug>();
        }
        public int DrugSubclassId { get; set; }
        public int DrugClassId { get; set; }
        public string DrugSubclassName { get; set; }
        public string DrugSubclassAbbr { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual DrugClass DrugClass { get; set; }
        public virtual ICollection<Drug> TblDrugs { get; set; }
    }
}
