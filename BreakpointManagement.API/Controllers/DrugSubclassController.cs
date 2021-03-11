using AutoMapper;
using BreakpointManagement.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BreakpointManagement.API.Controllers
{
    public class DrugSubclassController : Controller
    {
        IBreakpointManagementRepository _repository;
        IMapper _mapper;
        public DrugSubclassController(IBreakpointManagementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: DrugSubclassController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DrugSubclassController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DrugSubclassController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DrugSubclassController/Create
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

        // GET: DrugSubclassController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DrugSubclassController/Edit/5
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

        // GET: DrugSubclassController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DrugSubclassController/Delete/5
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
