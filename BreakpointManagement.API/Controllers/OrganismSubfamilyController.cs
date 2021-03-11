using AutoMapper;
using BreakpointManagement.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BreakpointManagement.API.Controllers
{
    public class OrganismSubfamilyController : Controller
    {
        IBreakpointManagementRepository _repository;
        IMapper _mapper;
        public OrganismSubfamilyController(IBreakpointManagementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: OrganismSubfamilyController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrganismSubfamilyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrganismSubfamilyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrganismSubfamilyController/Create
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

        // GET: OrganismSubfamilyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrganismSubfamilyController/Edit/5
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

        // GET: OrganismSubfamilyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrganismSubfamilyController/Delete/5
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
