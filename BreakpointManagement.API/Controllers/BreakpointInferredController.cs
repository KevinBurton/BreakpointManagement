using AutoMapper;
using BreakpointManagement.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BreakpointManagement.API.Controllers
{
    public class BreakpointInferredController : Controller
    {
        IBreakpointManagementRepository _repository;
        IMapper _mapper;
        public BreakpointInferredController(IBreakpointManagementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: BreakpointInferredController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BreakpointInferredController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BreakpointInferredController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BreakpointInferredController/Create
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

        // GET: BreakpointInferredController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BreakpointInferredController/Edit/5
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

        // GET: BreakpointInferredController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BreakpointInferredController/Delete/5
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
