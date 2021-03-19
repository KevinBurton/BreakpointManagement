using AutoMapper;
using BreakpointManagement.Data;
using BreakpointManagement.Data.Models;
using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreakpointManagement.API.Controllers
{
    public class BreakpointController : Controller
    {
        IBreakpointManagementRepository _repository;
        IMapper _mapper;
        public BreakpointController(IBreakpointManagementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("api/breakpoint")]
        // GET: BreakpointController
        public async IAsyncEnumerable<Breakpoint> Index()
        {
            var queryResults = _repository.GetAllBreakpoints();
            int count = 100;
            await foreach(var result in queryResults.ConfigureAwait(false))
            {
                if (count-- >= 0) break;
                yield return _mapper.Map<TblBreakpoint, Breakpoint>(result);
            }
        }

        [HttpGet("api/breakpoint/count")]
        public async Task<int> BreakpointCount()
        {
            return await _repository.BreakpointCount();
        }
        [HttpGet("api/breakpoint/breakpointproject")]
        public async Task<Project[]> GetBreakpointProject(int top = 100, int skip = 0, string sort = null)
        {
            var result = await _repository.GetBreakpointProject(top, skip, sort);
            return _mapper.Map<TblProject[], Project[]>(result);
        }
        [HttpGet("api/breakpoint/breakpointproject/count")]
        public async Task<int> GetBreakpointProjectCount()
        {
            return await _repository.GetBreakpointProjectCount();
        }
        [HttpGet("api/breakpoint/project/{projectId:int}")]
        public async Task<Breakpoint[]> GetBreakpointByProject(int projectId, int top = 100, int skip = 0, string sort = null)
        {
            var queryResults = await _repository.GetBreakpointByProject(projectId, top, skip, sort);
            return _mapper.Map<TblBreakpoint[], Breakpoint[]>(queryResults);
        }
        [HttpGet("api/breakpoint/project/{projectId:int}/count")]
        public async Task<int> GetBreakpointByProjectCount(int projectId)
        {
            return await _repository.GetBreakpointByProjectCount(projectId);
        }
        [HttpGet("api/breakpoint/project/{projectId:int}/group/{groupId:int}")]
        public async Task<OrganismName[]> GetOrganismByProjectGroup(int projectId, int groupId, int top = 100, int skip = 0, string sort = null)
        {
            var queryResults = await _repository.GetOrganismByProjectGroup(projectId, groupId, top, skip, sort);
            return _mapper.Map<TblOrganismName[], OrganismName[]>(queryResults);
        }
        [HttpGet("api/breakpoint/project/{projectId:int}/group/{groupId:int}/count")]
        public async Task<int> GetOrganismByProjectGroupCount(int projectId, int groupId)
        {
            return await _repository.GetOrganismByProjectGroupCount(projectId, groupId);
        }
        [HttpGet("api/breakpoint/project/report")]
        public async Task<BreakpointProjectReport[]> GetBreakpointProjectReport(int top = 100, int skip = 0, string sort = null)
        {
            return await _repository.GetBreakpointProjectReport(top, skip, sort);
        }
        [HttpGet("api/breakpoint/project/report/count")]
        public async Task<int> GetBreakpointProjectReportCount()
        {
            return await _repository.GetBreakpointProjectReportCount();
        }
        [HttpGet("api/breakpoint/standard/{standardId:int}/project/{projectId:int}/group/{groupId:int}/type/{resultType}")]
        public async Task<Breakpoint[]> GetBreakpointByStandardProjectGroupResultType(int standardId, int projectId, int groupId, string resultType, int top = 100, int skip = 0, string sort = null)
        {
            var result = await _repository.GetBreakpointByStandardProjectGroupResultType(standardId, projectId, groupId, resultType, top, skip, sort);
            return _mapper.Map<TblBreakpoint[], Breakpoint[]>(result);
        }
        [HttpGet("api/breakpoint/standard/{standardId:int}/project/{projectId:int}/group/{groupId:int}/type/{resultType}/count")]
        public async Task<int> GetBreakpointByStandardProjectGroupResultTypeCount(int standardId, int projectId, int groupId, string resultType)
        {
            return await _repository.GetBreakpointByStandardProjectGroupResultTypeCount(standardId, projectId, groupId, resultType);
        }

        // GET: BreakpointController/Details/5
        [HttpGet("api/breakpoint/breakpointbugroup/{id:int}")]
        public async Task<Breakpoint> Details(int id)
        {
            var queryResult = await _repository.GetBreakpoint(id).ConfigureAwait(false);
            return _mapper.Map<TblBreakpoint, Breakpoint>(queryResult);
        }

        // GET: BreakpointController/Create
        public ActionResult Create()
        {
            throw new NotImplementedException();
        }

        // POST: BreakpointController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        // GET: BreakpointController/Edit/5
        public ActionResult Edit(int id)
        {
            throw new NotImplementedException();
        }

        // POST: BreakpointController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        // GET: BreakpointController/Delete/5
        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        // POST: BreakpointController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
