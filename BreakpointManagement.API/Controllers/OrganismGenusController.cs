using AutoMapper;
using BreakpointManagement.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BreakpointManagement.API.Controllers
{
    public class OrganismGenusController : Controller
    {
        IBreakpointManagementRepository _repository;
        IMapper _mapper;
        public OrganismGenusController(IBreakpointManagementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: OrganismGenusController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrganismGenusController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrganismGenusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrganismGenusController/Create
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

        // GET: OrganismGenusController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrganismGenusController/Edit/5
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

        // GET: OrganismGenusController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrganismGenusController/Delete/5
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
