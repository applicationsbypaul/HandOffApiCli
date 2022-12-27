using HandOffApiCli.Data.Entities;
using HandOffApiCli.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace HandOffApiCli.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkGroupServiceController : Controller
    {
        private readonly IWorkGroupService _workGroupService;

        public WorkGroupServiceController(IWorkGroupService workGroupService)
        {
            _workGroupService = workGroupService;
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkGroup>>> GetAllWorkGroups()
        {
            return await _workGroupService.GetAllWorkGroups();
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<WorkGroup?>> AddEmployeeToWorkGroup(int id, Employee employee)
        {
            return await _workGroupService.AddEmployeeToWorkGroup(id, employee);
        }         

    }
}
