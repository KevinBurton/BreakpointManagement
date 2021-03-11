using AutoMapper;
using BreakpointManagement.Data;
using BreakpointManagement.Data.Models;
using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BreakpointManagement.API.Controllers
{
    public class OrganismNameController : Controller
    {
        IBreakpointManagementRepository _repository;
        IMapper _mapper;
        public OrganismNameController(IBreakpointManagementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: OrganismNameController
        [HttpGet("api/organismname")]
        public async Task<OrganismName[]> Index(int top = 100, int skip = 0, string sort = null)
        {
            return _mapper.Map<TblOrganismName[], OrganismName[]>(await _repository.GetAllOrganisms(top, skip, sort));
        }
        // GET: OrganismNameController/Count
        [HttpGet("api/organismname/count")]
        public async Task<int> Count()
        {
            return await _repository.GetOrganismCount();
        }

        // GET: OrganismNameController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrganismNameController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrganismNameController/Create
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

        // GET: OrganismNameController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrganismNameController/Edit/5
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

        // GET: OrganismNameController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrganismNameController/Delete/5
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
