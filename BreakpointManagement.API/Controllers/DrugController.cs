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
    public class DrugController : Controller
    {
        IBreakpointManagementRepository _repository;
        IMapper _mapper;
        public DrugController(IBreakpointManagementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: DrugController
        [HttpGet("api/drug")]
        public async Task<Drug[]> Index(int top = 100, int skip = 0, string sort = null)
        {
            return _mapper.Map<TblDrug[], Drug[]>(await _repository.GetAllDrugs(top, skip, sort));
        }
        // GET: DrugController
        [HttpGet("api/drug/count")]
        public async Task<int> Count()
        {
            return await _repository.GetDrugCount();
        }

        // GET: DrugController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DrugController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DrugController/Create
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

        // GET: DrugController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DrugController/Edit/5
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

        // GET: DrugController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DrugController/Delete/5
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
