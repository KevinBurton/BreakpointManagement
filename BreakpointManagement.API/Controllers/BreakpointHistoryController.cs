using AutoMapper;
using BreakpointManagement.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BreakpointManagement.API.Controllers
{
    public class BreakpointHistoryController : Controller
    {
        IBreakpointManagementRepository _repository;
        IMapper _mapper;
        public BreakpointHistoryController(IBreakpointManagementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: BreakpointHistoryController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BreakpointHistoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BreakpointHistoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BreakpointHistoryController/Create
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

        // GET: BreakpointHistoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BreakpointHistoryController/Edit/5
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

        // GET: BreakpointHistoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BreakpointHistoryController/Delete/5
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
