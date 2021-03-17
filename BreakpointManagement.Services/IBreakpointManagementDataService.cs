﻿using BreakpointManagement.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BreakpointManagement.Services
{
    public interface IBreakpointManagementDataService
    {
        HttpClient Client { get; }
        Task<IEnumerable<Breakpoint>> GetAllBreakpoints();
        Task<Breakpoint> GetBreakpointDetails(int breakpointId);
        Task<IList<BreakpointProjectSummary>> GetBreakpointProject(int top = 100, int skip = 0, string sort = null);
        Task<string> GetBreakpointProjectCount();
        Task<string> GetBreakpointCount(int projectId);
        Task<IList<BreakpointSummary>> GetBreakpointByProject(int projectId, int top = 100, int skip = 0, string sort = null);
        Task<string> GetBreakpointByProjectCount(int projectId);
        Task<IList<BreakpointSummary>> GetBreakpointByProjectGroup(int projectId, int groupId, int top = 100, int skip = 0, string sort = null);
        Task<string> GetBreakpointByProjectGroupCount(int projectId, int groupId);

        Task<IEnumerable<Breakpointgroup>> GetAllBreakpointGroups();
        Task<Breakpointgroup> GetBreadpointGroupDetails(int breakpointGroupId);

        Task<IList<Drug>> GetAllDrugs(int top = 100, int skip = 0, string sort = null);
        Task<string> GetDrugCount();

        Task<IList<OrganismName>> GetAllOrganisms(int top = 100, int skip = 0, string sort = null);
        Task<string> GetOrganismCount();

        Task<IList<BreakpointStandard>> GetAllBreakpointStandards(int top = 100, int skip = 0, string sort = null);
        Task<string> GetBreakpointStandardCount();

        Task<IList<Breakpointgroup>> GetBreakpointGroupByStandard(int standardId, int top = 100, int skip = 0, string sort = null);
        Task<string> GetBreakpointGroupByStandardCount(int standardId);

        Task<IList<OrganismName>> GetOrganismByGroup(int groupId, int top = 100, int skip = 0, string sort = null);
        Task<string> GetOrganismByGroupCount(int groupId);

        Task<IList<OrganismName>> GetOrganismByExcludedGroup(int groupId, int top = 100, int skip = 0, string sort = null);
        Task<string> GetOrganismByExcludedGroupCount(int groupId);
    }
}
