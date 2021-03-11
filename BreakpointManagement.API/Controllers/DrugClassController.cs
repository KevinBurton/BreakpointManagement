using AutoMapper;
using BreakpointManagement.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BreakpointManagement.API.Controllers
{
    public class DrugClassController : Controller
    {
        IBreakpointManagementRepository _repository;
        IMapper _mapper;
        public DrugClassController(IBreakpointManagementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: DrugClassController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DrugClassController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DrugClassController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DrugClassController/Create
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

        // GET: DrugClassController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DrugClassController/Edit/5
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

        // GET: DrugClassController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DrugClassController/Delete/5
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
