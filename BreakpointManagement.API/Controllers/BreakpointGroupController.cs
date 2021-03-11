using AutoMapper;
using BreakpointManagement.Data;
using BreakpointManagement.Data.Models;
using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreakpointManagement.API.Controllers
{
    public class BreakpointGroupController : Controller
    {
        IBreakpointManagementRepository _repository;
        IMapper _mapper;
        public BreakpointGroupController(IBreakpointManagementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: BreakpointGroupController
        public async IAsyncEnumerable<Breakpointgroup> Index()
        {
            var queryResults = _repository.GetAllBreakpointGroups();
            await foreach (var result in queryResults.ConfigureAwait(false))
            {
                yield return _mapper.Map<TblBreakpointgroup, Breakpointgroup>(result);
            }
        }

        // GET: BreakpointGroupController/Details/5
        public async Task<Breakpointgroup> Details(int id)
        {
            var queryResult = await _repository.GetBreakpointGroup(id).ConfigureAwait(false);
            return _mapper.Map<TblBreakpointgroup, Breakpointgroup>(queryResult);
        }

        // GET: BreakpointGroupController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BreakpointGroupController/Create
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

        // GET: BreakpointGroupController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BreakpointGroupController/Edit/5
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

        // GET: BreakpointGroupController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BreakpointGroupController/Delete/5
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
