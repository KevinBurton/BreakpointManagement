using AutoMapper;
using BreakpointManagement.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BreakpointManagement.API.Controllers
{
    public class OrganismFamilyController : Controller
    {
        IBreakpointManagementRepository _repository;
        IMapper _mapper;
        public OrganismFamilyController(IBreakpointManagementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: OrganismFamilyController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrganismFamilyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrganismFamilyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrganismFamilyController/Create
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

        // GET: OrganismFamilyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrganismFamilyController/Edit/5
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

        // GET: OrganismFamilyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrganismFamilyController/Delete/5
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
