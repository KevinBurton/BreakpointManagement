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
        public async Task<BreakpointProjectSummary[]> GetBreakpointProject(int top = 100, int skip = 0, string sort = null)
        {
            var query = from bkpt in _context.TblBreakpoints
                        join proj in _context.TblProjects on bkpt.ProjectId equals proj.ProjectId
                        join client in _context.TblClients on proj.ClientId equals client.CompanyId
                        orderby bkpt.BreakpointId
                        select new BreakpointProjectSummary
                        {
                            ProjectId = bkpt.ProjectId,
                            ProjectName = proj.ProjectName,
                            CompanyName = client.CompanyName,
                            ClientType = client.ClientType
                        };
            var pagedQuery = query.Distinct().Skip(skip).Take(top);
            if (string.IsNullOrWhiteSpace(sort))
            {
                return await pagedQuery.ToArrayAsync().ConfigureAwait(false);
            }
            return await pagedQuery.OrderBy(sort).ToArrayAsync().ConfigureAwait(false);
        }
        public async Task<int> GetBreakpointProjectCount()
        {
            return await _context.TblBreakpoints.Select(e => e.ProjectId).OrderBy(e => e).Distinct().CountAsync().ConfigureAwait(false);
        }
        public async Task<BreakpointSummary[]> GetBreakpointByProject(int projectId, int top = 100, int skip = 0, string sort = null)
        {
            var query = from bkpt in _context.TblBreakpoints
                        join bkptgrp in _context.TblBreakpointgroups on bkpt.BpgroupId equals bkptgrp.BpgroupId
                        join bkptgrpmem in _context.TblBreakpointgroupmembers on bkpt.BpgroupId equals bkptgrpmem.BpgroupId
                        join bkptstd in _context.TblBreakpointStandards on bkptgrp.BpstandardId equals bkptstd.BpstandardId
                        join drug in _context.TblDrugs on bkpt.DrugId equals drug.DrugId
                        join orgnm in _context.TblOrganismNames on bkptgrpmem.OrganismId equals orgnm.OrganismId
                        where bkpt.ProjectId == projectId
                        orderby bkpt.BreakpointId
                        select new BreakpointSummary
                        {
                            ProjectId = projectId,
                            OrganismName = orgnm.OrganismName,
                            Standard = bkptstd.Bpstandard,
                            GroupName = bkptgrp.BpgroupName,
                            Method = bkpt.ResultType,
                            DrugName = drug.DrugName,
                            Susceptible = bkpt.Susceptible,
                            LowIntermediate = bkpt.LowIntermediate,
                            Intermediate = bkpt.Intermediate,
                            Resistant = bkpt.Resistant
                        };

            var pagedQuery = query.Distinct().Skip(skip).Take(top);
            if (string.IsNullOrWhiteSpace(sort))
            {
                return await pagedQuery.ToArrayAsync().ConfigureAwait(false);
            }
            return await pagedQuery.OrderBy(sort).ToArrayAsync().ConfigureAwait(false);
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
            var pagedQuery = query.Skip(skip).Take(top);
            if (string.IsNullOrWhiteSpace(sort))
            {
                return await pagedQuery.ToArrayAsync().ConfigureAwait(false);
            }
            return await pagedQuery.OrderBy(sort).ToArrayAsync().ConfigureAwait(false);
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
            var pagedQuery = query.Skip(skip).Take(top);
            if (string.IsNullOrWhiteSpace(sort))
            {
                return await pagedQuery.ToArrayAsync().ConfigureAwait(false);
            }
            return await pagedQuery.OrderBy(sort).ToArrayAsync().ConfigureAwait(false);
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
            var pagedQuery = query.Skip(skip).Take(top);
            if (string.IsNullOrWhiteSpace(sort))
            {
                return await pagedQuery.ToArrayAsync().ConfigureAwait(false);
            }
            return await pagedQuery.OrderBy(sort).ToArrayAsync().ConfigureAwait(false);
        }
        public async Task<int> GetBreakpointStandardCount()
        {
            return await _context.TblBreakpointStandards.CountAsync().ConfigureAwait(false);
        }
    }
}
