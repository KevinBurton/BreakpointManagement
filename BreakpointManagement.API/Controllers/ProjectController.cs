using AutoMapper;
using BreakpointManagement.Data;
using BreakpointManagement.Data.Models;
using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakpointManagement.API.Controllers
{
    public class ProjectController : Controller
    {
        IBreakpointManagementRepository _repository;
        IMapper _mapper;
        public ProjectController(IBreakpointManagementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: ProjectController
        [HttpGet("api/project")]
        public async IAsyncEnumerable<Project> Index()
        {
            var queryResults = _repository.GetAllProjects();
            int count = 100;
            await foreach (var result in queryResults.ConfigureAwait(false))
            {
                if (count-- >= 0) break;
                yield return _mapper.Map<TblProject, Project>(result);
            }
        }

        // GET: ProjectController/5
        [HttpGet("api/project/{id:int}")]
        public async Task<Project> Details(int id)
        {
            return _mapper.Map<TblProject, Project>(await _repository.GetProjectById(id).ConfigureAwait(false));
        }

        // GET: ProjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectController/Create
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
                return View();
            }
        }

        // GET: ProjectController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectController/Edit/5
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
                return View();
            }
        }

        // GET: ProjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectController/Delete/5
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
                return View();
            }
        }
    }
}
