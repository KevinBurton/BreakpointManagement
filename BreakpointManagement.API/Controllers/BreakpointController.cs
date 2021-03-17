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
        // GET: BreakpointController/BreakpointCount
        public async Task<int> BreakpointCount()
        {
            return await _repository.BreakpointCount();
        }
        [HttpGet("api/breakpoint/breakpointproject")]
        // GET: BreakpointController/BreakpointProject
        public Task<BreakpointProjectSummary[]> GetBreakpointProject(int top = 100, int skip = 0, string sort = null)
        {
            return _repository.GetBreakpointProject(top, skip, sort);
        }
        [HttpGet("api/breakpoint/breakpointproject/count")]
        // GET: BreakpointController/BreakpointProject/Count
        public async Task<int> GetBreakpointProjectCount(int projectId)
        {
            return await _repository.GetBreakpointProjectCount();
        }
        [HttpGet("api/breakpoint/project/{projectId:int}")]
        // GET: BreakpointController/Project/5
        public async Task<BreakpointSummary[]> GetBreakpointByProject(int projectId, int top = 100, int skip = 0, string sort = null)
        {
            return await _repository.GetBreakpointByProject(projectId, top, skip, sort);
        }
        [HttpGet("api/breakpoint/project/{projectId:int}/count")]
        // GET: BreakpointController/Project/5/Count
        public async Task<int> GetBreakpointByProjectCount(int projectId)
        {
            return await _repository.GetBreakpointByProjectCount(projectId);
        }
        [HttpGet("api/breakpoint/project/{projectId:int}/group/{groupId:int}")]
        // GET: BreakpointController/Project/5
        public async Task<BreakpointSummary[]> GetBreakpointByProjectGroup(int projectId, int groupId, int top = 100, int skip = 0, string sort = null)
        {
            return await _repository.GetBreakpointByProjectGroup(projectId, groupId, top, skip, sort);
        }
        [HttpGet("api/breakpoint/project/{projectId:int}/group/{groupId:int}/count")]
        // GET: BreakpointController/Project/5/Count
        public async Task<int> GetBreakpointByProjectGroupCount(int projectId, int groupId)
        {
            return await _repository.GetBreakpointByProjectGroupCount(projectId, groupId);
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
