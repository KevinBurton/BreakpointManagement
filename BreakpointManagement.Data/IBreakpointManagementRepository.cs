using BreakpointManagement.Data.Models;
using BreakpointManagement.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreakpointManagement.Data
{
    public interface IBreakpointManagementRepository
    {
        Task<int> BreakpointCount();
        IAsyncEnumerable<TblBreakpoint> GetAllBreakpoints();
        Task<TblBreakpoint> GetBreakpoint(int breakpointId);
        PagedResult<TblBreakpoint> PagedBreakpoint(int projectId, int page = 1);
        Task<BreakpointProjectSummary[]> GetBreakpointProject(int top = 100, int skip = 0, string sort = null);
        Task<int> GetBreakpointProjectCount();
        Task<BreakpointSummary[]> GetBreakpointByProject(int projectId, int top = 100, int skip = 0, string sort = null);
        Task<int> GetBreakpointByProjectCount(int projectId);
        Task<int> BreakpointGroupCount();
        IAsyncEnumerable<TblBreakpointgroup> GetAllBreakpointGroups();
        Task<TblBreakpointgroup> GetBreakpointGroup(int breakpointGroupId);
        Task<TblDrug[]> GetAllDrugs(int top = 100, int skip = 0, string sort = null);
        Task<int> GetDrugCount();
        Task<TblOrganismName[]> GetAllOrganisms(int top = 100, int skip = 0, string sort = null);
        Task<int> GetOrganismCount();
        Task<TblBreakpointStandard[]> GetAllBreakpointStandards(int top = 100, int skip = 0, string sort = null);
        Task<int> GetBreakpointStandardCount();
    }
}
