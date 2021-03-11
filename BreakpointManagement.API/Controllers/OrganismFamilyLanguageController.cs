using AutoMapper;
using BreakpointManagement.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BreakpointManagement.API.Controllers
{
    public class OrganismFamilyLanguageController : Controller
    {
        IBreakpointManagementRepository _repository;
        IMapper _mapper;
        public OrganismFamilyLanguageController(IBreakpointManagementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: OrganismFamilyLanguageController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrganismFamilyLanguageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrganismFamilyLanguageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrganismFamilyLanguageController/Create
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

        // GET: OrganismFamilyLanguageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrganismFamilyLanguageController/Edit/5
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

        // GET: OrganismFamilyLanguageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrganismFamilyLanguageController/Delete/5
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
