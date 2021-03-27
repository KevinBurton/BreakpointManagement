using BreakpointManagement.Data.Context;
using BreakpointManagement.Data.Models;
using BreakpointManagement.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

namespace BreakpointManagement.Data
{
    public class BreakpointManagementRepository : IBreakpointManagementRepository
    {
        const int pageSize = 10;
        private BreakpointManagementDbContext _context;
        public BreakpointManagementRepository(BreakpointManagementDbContext context)
        {
            _context = context;
        }
        public async Task<int> BreakpointCount()
        {
            try
            {
                return await _context.TblBreakpoints.CountAsync().ConfigureAwait(false);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                throw;
            }
        }
        public async Task<TblBreakpoint[]> GetBreakpointByProject(int projectId, int top = 100, int skip = 0, string sort = null)
        {
            var query = from bkpt in _context.TblBreakpoints
                        where bkpt.ProjectId == projectId
                        orderby bkpt.BreakpointId
                        select bkpt;

            if (string.IsNullOrWhiteSpace(sort))
            {
                return await query.OrderBy("ProjectId").Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
            }
            return await query.OrderBy(sort).Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
        }
        public async Task<int> GetBreakpointByProjectCount(int projectId)
        {
            var query = from bkpt in _context.TblBreakpoints
                        join bkptgrp in _context.TblBreakpointgroups on bkpt.BpgroupId equals bkptgrp.BpgroupId
                        join bkptgrpmem in _context.TblBreakpointgroupmembers on bkpt.BpgroupId equals bkptgrpmem.BpgroupId
                        join bkptstd in _context.TblBreakpointStandards on bkptgrp.BpstandardId equals bkptstd.BpstandardId
                        join drug in _context.TblDrugs on bkpt.DrugId equals drug.DrugId
                        join orgnm in _context.TblOrganismNames on bkptgrpmem.OrganismId equals orgnm.OrganismId
                        where bkpt.ProjectId == projectId
                        orderby bkpt.BreakpointId
                        select bkpt;
            return await query.Distinct().CountAsync().ConfigureAwait(false);
        }
        public async Task<TblOrganismName[]> GetOrganismByProjectGroup(int projectId, int groupId, int top = 100, int skip = 0, string sort = null)
        {
            var query = from bkpt in _context.TblBreakpoints
                        join bkptgrp in _context.TblBreakpointgroups on bkpt.BpgroupId equals bkptgrp.BpgroupId
                        join bkptgrpmem in _context.TblBreakpointgroupmembers on bkpt.BpgroupId equals bkptgrpmem.BpgroupId
                        join bkptstd in _context.TblBreakpointStandards on bkptgrp.BpstandardId equals bkptstd.BpstandardId
                        join drug in _context.TblDrugs on bkpt.DrugId equals drug.DrugId
                        join orgnm in _context.TblOrganismNames on bkptgrpmem.OrganismId equals orgnm.OrganismId
                        where bkpt.ProjectId == projectId && bkpt.BpgroupId == groupId
                        orderby bkpt.BreakpointId
                        select orgnm;

            if (string.IsNullOrWhiteSpace(sort))
            {
                return await query.OrderBy("ProjectId").Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
            }
            return await query.OrderBy(sort).Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
        }
        public async Task<int> GetOrganismByProjectGroupCount(int projectId, int groupId)
        {
            var query = from bkpt in _context.TblBreakpoints
                        join bkptgrp in _context.TblBreakpointgroups on bkpt.BpgroupId equals bkptgrp.BpgroupId
                        join bkptgrpmem in _context.TblBreakpointgroupmembers on bkpt.BpgroupId equals bkptgrpmem.BpgroupId
                        join bkptstd in _context.TblBreakpointStandards on bkptgrp.BpstandardId equals bkptstd.BpstandardId
                        join drug in _context.TblDrugs on bkpt.DrugId equals drug.DrugId
                        join orgnm in _context.TblOrganismNames on bkptgrpmem.OrganismId equals orgnm.OrganismId
                        where bkpt.ProjectId == projectId && bkpt.BpgroupId == groupId
                        orderby bkpt.BreakpointId
                        select bkpt;
            return await query.Distinct().CountAsync().ConfigureAwait(false);
        }
        public PagedResult<TblBreakpoint> PagedBreakpoint(int projectId, int page = 1)
        {
            var query = from bkpt in _context.TblBreakpoints
                        where bkpt.ProjectId == projectId
                        orderby bkpt.BreakpointId
                        select bkpt;
            return query.GetPaged(page, pageSize);
        }
        public IAsyncEnumerable<TblBreakpoint> GetAllBreakpoints()
        {
            return _context.TblBreakpoints.AsAsyncEnumerable<TblBreakpoint>();
        }
        public async Task<TblBreakpoint> GetBreakpoint(int breakpointId)
        {
            return await _context.TblBreakpoints.SingleAsync<TblBreakpoint>(e => e.BreakpointId == breakpointId).ConfigureAwait(false);
        }

        public async Task<int> BreakpointGroupCount()
        {
            return await _context.TblBreakpointgroups.CountAsync().ConfigureAwait(false);
        }
        public PagedResult<TblBreakpointgroup> PagedBreakpointGroup(int page = 1)
        {
            return _context.TblBreakpointgroups.GetPaged(page, pageSize);
        }
        public IAsyncEnumerable<TblBreakpointgroup> GetAllBreakpointGroups()
        {
            return _context.TblBreakpointgroups.AsAsyncEnumerable<TblBreakpointgroup>();
        }
        public async Task<TblBreakpointgroup> GetBreakpointGroup(int breakpointGroupId)
        {
            return await _context.TblBreakpointgroups.SingleAsync<TblBreakpointgroup>(e => e.BpgroupId == breakpointGroupId).ConfigureAwait(false);
        }
        public async Task<TblDrug[]> GetAllDrugs(int top = 100, int skip = 0, string sort = null)
        {
            var query = (from drug in _context.TblDrugs
                         orderby drug.DrugId
                         select drug);
            if (string.IsNullOrWhiteSpace(sort))
            {
                return await query.OrderBy(b => b.DrugId).Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
            }
            return await query.OrderBy(sort).Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
        }
        public async Task<int> GetDrugCount()
        {
            return await _context.TblDrugs.CountAsync().ConfigureAwait(false);
        }
        public async Task<TblOrganismName[]> GetAllOrganisms(int top = 100, int skip = 0, string sort = null)
        {
            var query = (from organism in _context.TblOrganismNames
                         orderby organism.OrganismId
                         select organism);
            if (string.IsNullOrWhiteSpace(sort))
            {
                return await query.OrderBy(b => b.OrganismFamilyId).Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
            }
            return await query.OrderBy(sort).Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
        }
        public async Task<int> GetOrganismCount()
        {
            return await _context.TblOrganismNames.CountAsync().ConfigureAwait(false);
        }
        public async Task<TblBreakpointStandard[]> GetAllBreakpointStandards(int top = 100, int skip = 0, string sort = null)
        {
            var query = (from breakpoint in _context.TblBreakpointStandards
                        orderby breakpoint.BpstandardId
                        select breakpoint);
            if (string.IsNullOrWhiteSpace(sort))
            {
                return await query.OrderBy(b => b.BpstandardId).Include(s => s.Groups).Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
            }
            return await query.OrderBy(sort).Include(s => s.Groups).Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
        }
        public async Task<int> GetBreakpointStandardCount()
        {
            return await _context.TblBreakpointStandards.CountAsync().ConfigureAwait(false);
        }

        public async Task<TblBreakpointgroup[]> GetBreakpointGroupByStandard(int standardId, int top = 100, int skip = 0, string sort = null)
        {
            var query = (from gp in _context.TblBreakpointgroups
                         where gp.BpstandardId == standardId
                         select gp);
            if (string.IsNullOrWhiteSpace(sort))
            {
                return await query.OrderBy(b => b.BpgroupId).Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
            }
            return await query.OrderBy(sort).Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
        }

        public async Task<int> GetBreakpointGroupByStandardCount(int standardId)
        {
            var query = (from gp in _context.TblBreakpointgroups
                         where gp.BpstandardId == standardId
                         select gp);
            return await query.Distinct().CountAsync().ConfigureAwait(false);
        }

        public async Task<TblOrganismName[]> GetOrganismByGroup(int groupId, int top = 100, int skip = 0, string sort = null)
        {
            var query = (from bgm in _context.TblBreakpointgroupmembers
                         join organism in _context.TblOrganismNames on bgm.OrganismId equals organism.OrganismId
                         where bgm.BpgroupId == groupId
                         select organism);
            if (string.IsNullOrWhiteSpace(sort))
            {
                return await query.Distinct().OrderBy(b => b.OrganismId).Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
            }
            return await query.Distinct().OrderBy(sort).Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
        }

        public async Task<int> GetOrganismByGroupCount(int groupId)
        {
            var query = (from bgm in _context.TblBreakpointgroupmembers
                         join organism in _context.TblOrganismNames on bgm.OrganismId equals organism.OrganismId
                         where bgm.BpgroupId == groupId
                         select organism);
            return await query.Distinct().CountAsync().ConfigureAwait(false);
        }

        public async Task<TblOrganismName[]> GetOrganismByExcludedGroup(int groupId, int top = 100, int skip = 0, string sort = null)
        {
            var query = (from bgm in _context.TblBreakpointgroupmembers
                         join organism in _context.TblOrganismNames on bgm.OrganismId equals organism.OrganismId
                         where bgm.BpgroupId != groupId
                         select organism);
            if (string.IsNullOrWhiteSpace(sort))
            {
                return await query.Distinct().OrderBy(b => b.OrganismId).Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
            }
            return await query.Distinct().OrderBy(sort).Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
        }

        public async Task<int> GetOrganismByExcludedGroupCount(int groupId)
        {
            var query = (from bgm in _context.TblBreakpointgroupmembers
                         join organism in _context.TblOrganismNames on bgm.OrganismId equals organism.OrganismId
                         where bgm.BpgroupId != groupId
                         select organism);
            return await query.Distinct().CountAsync().ConfigureAwait(false);
        }

        public async Task<BreakpointGroupingReport[]> GetBreakpointGroupingReport(int top = 100, int skip = 0, string sort = null)
        {
            var query = (from bg in _context.TblBreakpointgroups
                         join s in _context.TblBreakpointStandards on bg.BpstandardId equals s.BpstandardId
                         join m in _context.TblBreakpointgroupmembers on bg.BpgroupId equals m.BpgroupId
                         join o in _context.TblOrganismNames on m.OrganismId equals o.OrganismId
                         orderby s.BpstandardId, bg.BpgroupId, o.OrganismId
                         select new BreakpointGroupingReport { Standard = s.Bpstandard, Group = bg.BpgroupName, Organism = o.OrganismName });
            if (string.IsNullOrWhiteSpace(sort))
            {
                return await query.Distinct().OrderBy("Standard,Group,Organism").Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
            }
            return await query.Distinct().OrderBy(sort).Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
        }

        public async Task<int> GetBreakpointGroupingReportCount()
        {
            var query = (from bg in _context.TblBreakpointgroups
                         join s in _context.TblBreakpointStandards on bg.BpstandardId equals s.BpstandardId
                         join m in _context.TblBreakpointgroupmembers on bg.BpgroupId equals m.BpgroupId
                         join o in _context.TblOrganismNames on m.OrganismId equals o.OrganismId
                         select new BreakpointGroupingReport { Standard = s.Bpstandard, Group = bg.BpgroupName, Organism = o.OrganismName });
            return await query.Distinct().CountAsync().ConfigureAwait(false);
        }

        public async Task<BreakpointProjectReport[]> GetBreakpointProjectReport(int top = 100, int skip = 0, string sort = null)
        {
            var query = (from b in _context.TblBreakpoints
                         select new BreakpointProjectReport { Project = b.ProjectId, Comment = b.Bpyear });
            if (string.IsNullOrWhiteSpace(sort))
            {
                return await query.Distinct().OrderBy("Project asc").Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
            }
            return await query.Distinct().OrderBy(sort).Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
        }

        public async Task<int> GetBreakpointProjectReportCount()
        {
            var query = (from b in _context.TblBreakpoints
                         select new BreakpointProjectReport { Project = b.ProjectId, Comment = b.Bpyear });
            return await query.Distinct().CountAsync().ConfigureAwait(false);
        }

        public async Task<TblBreakpoint[]> GetBreakpointByStandardProjectGroupResultType(int standardId, int projectId, int groupId, string resultType, int top = 100, int skip = 0, string sort = null)
        {
            var query = (from b in _context.TblBreakpoints
                         join g in _context.TblBreakpointgroups on b.BpgroupId equals g.BpgroupId
                         where b.ResultType == resultType && 
                               b.BpgroupId == groupId &&
                               b.ProjectId == projectId &&
                               g.BpstandardId == standardId
                         select b);
            if (string.IsNullOrWhiteSpace(sort))
            {
                return await query.Distinct().OrderBy("BpgroupId asc").Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
            }
            var breakpoints = await query.Distinct().OrderBy(sort).Skip(skip).Take(top).Include("Drug").Include("Bpgroup").Include("Project").ToArrayAsync().ConfigureAwait(false);
            return breakpoints;
        }

        public async Task<int> GetBreakpointByStandardProjectGroupResultTypeCount(int standardId, int projectId, int groupId, string resultType)
        {
            var query = (from b in _context.TblBreakpoints
                         join g in _context.TblBreakpointgroups on b.BpgroupId equals g.BpgroupId
                         where b.ResultType == resultType &&
                               b.BpgroupId == groupId &&
                               b.ProjectId == projectId &&
                               g.BpstandardId == standardId
                         select b);
            return await query.Distinct().CountAsync().ConfigureAwait(false);
        }
        public async Task<TblProject[]> GetBreakpointProject(int top = 100, int skip = 0, string sort = null)
        {
            var query = from bkpt in _context.TblBreakpoints
                        join proj in _context.TblProjects on bkpt.ProjectId equals proj.ProjectId
                        orderby bkpt.ProjectId
                        select proj;
            if (string.IsNullOrWhiteSpace(sort))
            {
                return await query.Distinct().OrderBy("ProjectId").Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
            }
            return await query.Distinct().OrderBy(sort).Skip(skip).Take(top).ToArrayAsync().ConfigureAwait(false);
        }
        public async Task<int> GetBreakpointProjectCount()
        {
            var query = from bkpt in _context.TblBreakpoints
                        join proj in _context.TblProjects on bkpt.ProjectId equals proj.ProjectId
                        orderby bkpt.ProjectId
                        select proj;
            return await query.Distinct().CountAsync().ConfigureAwait(false);
        }
    }
}
