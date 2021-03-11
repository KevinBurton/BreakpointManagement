using AutoMapper;
using BreakpointManagement.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BreakpointManagement.API.Controllers
{
    public class BreakpointGroupMemberController : Controller
    {
        IBreakpointManagementRepository _repository;
        IMapper _mapper;
        public BreakpointGroupMemberController(IBreakpointManagementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: BreakpointGroupMemberController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BreakpointGroupMemberController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BreakpointGroupMemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BreakpointGroupMemberController/Create
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

        // GET: BreakpointGroupMemberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BreakpointGroupMemberController/Edit/5
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

        // GET: BreakpointGroupMemberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BreakpointGroupMemberController/Delete/5
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
