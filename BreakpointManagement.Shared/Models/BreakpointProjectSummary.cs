using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakpointManagement.Shared.Models
{
    public class BreakpointProjectSummary
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string CompanyName { get; set; }
        public string ClientType { get; set; }
    }
}
