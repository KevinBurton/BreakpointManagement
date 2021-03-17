using AutoMapper;
using BreakpointManagement.Data;
using BreakpointManagement.Data.Models;
using BreakpointManagement.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [HttpGet("api/breakpointgroupmember/group/{groupId:int}")]
        public async Task<OrganismName[]> GetOrganismByGroup(int groupId, int top = 100, int skip = 0, string sort = null)
        {
            var queryResult = await _repository.GetOrganismByGroup(groupId, top, skip, sort).ConfigureAwait(false);
            return _mapper.Map<TblOrganismName[], OrganismName[]>(queryResult);
        }
        [HttpGet("api/breakpointgroupmember/group/{groupId:int}/count")]
        public async Task<int> GetOrganismByGroupCount(int groupId)
        {
            return await _repository.GetOrganismByGroupCount(groupId);
        }

        [HttpGet("api/breakpointgroupmember/notgroup/{groupId:int}")]
        public async Task<OrganismName[]> GetOrganismByExcludedGroup(int groupId, int top = 100, int skip = 0, string sort = null)
        {
            var queryResult = await _repository.GetOrganismByExcludedGroup(groupId, top, skip, sort).ConfigureAwait(false);
            return _mapper.Map<TblOrganismName[], OrganismName[]>(queryResult);
        }
        [HttpGet("api/breakpointgroupmember/notgroup/{groupId:int}/count")]
        public async Task<int> GetOrganismByExcludedGroupCount(int groupId)
        {
            return await _repository.GetOrganismByExcludedGroupCount(groupId);
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
