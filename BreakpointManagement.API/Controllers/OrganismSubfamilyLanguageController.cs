using AutoMapper;
using BreakpointManagement.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BreakpointManagement.API.Controllers
{
    public class OrganismSubfamilyLanguageController : Controller
    {
        IBreakpointManagementRepository _repository;
        IMapper _mapper;
        public OrganismSubfamilyLanguageController(IBreakpointManagementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: OrganismSubfamilyLanguageController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrganismSubfamilyLanguageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrganismSubfamilyLanguageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrganismSubfamilyLanguageController/Create
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

        // GET: OrganismSubfamilyLanguageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrganismSubfamilyLanguageController/Edit/5
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

        // GET: OrganismSubfamilyLanguageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrganismSubfamilyLanguageController/Delete/5
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
