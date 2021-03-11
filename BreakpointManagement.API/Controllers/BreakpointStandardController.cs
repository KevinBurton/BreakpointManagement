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
            return _mapper.Map<TblBreakpointStandard[], BreakpointStandard[]>(await _repository.GetAllBreakpointStandards(top, skip, sort));
        }
        [HttpGet("api/breakpointstandard/count")]
        // GET: BreakpointStandardController/Count
        public async Task<int> Count()
        {
            return await _repository.GetBreakpointStandardCount();
        }

        // GET: BreakpointStandardController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
