using AutoMapper;
using BreakpointManagement.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BreakpointManagement.API.Controllers
{
    public class BreakpointExceptionController : Controller
    {
        IBreakpointManagementRepository _repository;
        IMapper _mapper;
        public BreakpointExceptionController(IBreakpointManagementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: BreakpointExceptionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BreakpointExceptionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BreakpointExceptionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BreakpointExceptionController/Create
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

        // GET: BreakpointExceptionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BreakpointExceptionController/Edit/5
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

        // GET: BreakpointExceptionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BreakpointExceptionController/Delete/5
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
