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
    public class BreakpointStandardController : Controller
    {
        IBreakpointManagementRepository _repository;
        IMapper _mapper;
        public BreakpointStandardController(IBreakpointManagementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("api/breakpointstandard")]
        // GET: BreakpointStandardController
        public async Task<BreakpointStandard[]> Index(int top = 100, int skip = 0, string sort = null)
        {
            var queryResults = await _repository.GetAllBreakpointStandards(top, skip, sort).ConfigureAwait(false); ;
            return _mapper.Map<TblBreakpointStandard[], BreakpointStandard[]>(queryResults);
        }
        [HttpGet("api/breakpointstandard/count")]
        // GET: BreakpointStandardController/Count
        public async Task<int> Count()
        {
            return await _repository.GetBreakpointStandardCount();
        }

        [HttpGet("api/breakpointstandard/{id:int}")]
        // GET: BreakpointStandardController/5
        public async Task<BreakpointStandard> Details(int id)
        {
            var queryResults = await _repository.GetBreakpointStandardById(id).ConfigureAwait(false); ;
            return _mapper.Map<TblBreakpointStandard, BreakpointStandard>(queryResults);
        }

        // GET: BreakpointStandardController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BreakpointStandardController/Create
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

        // GET: BreakpointStandardController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BreakpointStandardController/Edit/5
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

        // GET: BreakpointStandardController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BreakpointStandardController/Delete/5
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
