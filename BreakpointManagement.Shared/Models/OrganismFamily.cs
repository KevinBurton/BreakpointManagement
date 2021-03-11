using System;
using System.Collections.Generic;

namespace BreakpointManagement.Shared.Models
{
    public class OrganismFamily
    {
        public OrganismFamily()
        {
            TblOrganismSubfamilies = new HashSet<OrganismSubfamily>();
        }
        public int OrganismFamilyId { get; set; }
        public string OrganismFamilyName { get; set; }
        public string OrganismGrouping { get; set; }
        public string GramType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual ICollection<OrganismSubfamily> TblOrganismSubfamilies { get; set; }
    }
}
