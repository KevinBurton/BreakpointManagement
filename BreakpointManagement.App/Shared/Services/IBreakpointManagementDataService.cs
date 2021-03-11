using BreakpointManagement.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreakpointManagement.App.Shared.Services
{
    public interface IBreakpointManagementDataService
    {
        Task<IEnumerable<Breakpoint>> GetAllBreakpoints();
        Task<Breakpoint> GetBreakpointDetails(int breakpointId);
        Task<string> GetBreakpointCount(int projectId);
        Task<List<BreakpointSummary>> GetBreakpointByGroup(int projectId);
        Task<IEnumerable<Breakpointgroup>> GetAllBreakpointGroups();
        Task<Breakpointgroup> GetBreadpointGroupDetails(int breakpointGroupId);
    }
}
