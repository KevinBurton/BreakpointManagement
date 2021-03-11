using AutoMapper;
using BreakpointManagement.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BreakpointManagement.API.Controllers
{
    public class OrganismNameLanguageController : Controller
    {
        IBreakpointManagementRepository _repository;
        IMapper _mapper;
        public OrganismNameLanguageController(IBreakpointManagementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: OrganismNameLanguageController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrganismNameLanguageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrganismNameLanguageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrganismNameLanguageController/Create
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

        // GET: OrganismNameLanguageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrganismNameLanguageController/Edit/5
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

        // GET: OrganismNameLanguageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrganismNameLanguageController/Delete/5
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
