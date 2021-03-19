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
        Task<TblBreakpoint[]> GetBreakpointByProject(int projectId, int top = 100, int skip = 0, string sort = null);
        Task<int> GetBreakpointByProjectCount(int projectId);
        Task<TblOrganismName[]> GetOrganismByProjectGroup(int projectId, int groupId, int top = 100, int skip = 0, string sort = null);
        Task<int> GetOrganismByProjectGroupCount(int projectId, int groupId);
        Task<int> BreakpointGroupCount();
        IAsyncEnumerable<TblBreakpointgroup> GetAllBreakpointGroups();
        Task<TblBreakpointgroup> GetBreakpointGroup(int breakpointGroupId);
        Task<TblDrug[]> GetAllDrugs(int top = 100, int skip = 0, string sort = null);
        Task<int> GetDrugCount();
        Task<TblOrganismName[]> GetAllOrganisms(int top = 100, int skip = 0, string sort = null);
        Task<int> GetOrganismCount();
        Task<TblBreakpointStandard[]> GetAllBreakpointStandards(int top = 100, int skip = 0, string sort = null);
        Task<int> GetBreakpointStandardCount();
        Task<TblBreakpointgroup[]> GetBreakpointGroupByStandard(int standardId, int top = 100, int skip = 0, string sort = null);
        Task<int> GetBreakpointGroupByStandardCount(int standardId);
        Task<TblOrganismName[]> GetOrganismByGroup(int groupId, int top = 100, int skip = 0, string sort = null);
        Task<int> GetOrganismByGroupCount(int groupId);
        Task<TblOrganismName[]> GetOrganismByExcludedGroup(int groupId, int top = 100, int skip = 0, string sort = null);
        Task<int> GetOrganismByExcludedGroupCount(int groupId);
        Task<BreakpointGroupingReport[]> GetBreakpointGroupingReport(int top = 100, int skip = 0, string sort = null);
        Task<int> GetBreakpointGroupingReportCount();
        Task<BreakpointProjectReport[]> GetBreakpointProjectReport(int top = 100, int skip = 0, string sort = null);
        Task<int> GetBreakpointProjectReportCount();
        Task<TblBreakpoint[]> GetBreakpointByStandardProjectGroupResultType(int standardId, int projectId, int groupId, string resultType, int top = 100, int skip = 0, string sort = null);
        Task<int> GetBreakpointByStandardProjectGroupResultTypeCount(int standardId, int projectId, int groupId, string resultType);
        Task<TblProject[]> GetBreakpointProject(int top = 100, int skip = 0, string sort = null);
        Task<int> GetBreakpointProjectCount();
    }
}
