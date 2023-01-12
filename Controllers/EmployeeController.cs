using HandOffApiCli.Data.Entities;
using HandOffApiCli.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HandOffApiCli.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees() => Ok(await _employeeService.GetAllEmployees());

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetSingleEmployee(int id)
        {
            var employee = await _employeeService.GetSingleEmployee(id);
            if (employee is null)
                return NotFound("The employee your trying retrieve does not exist");
            return Ok(await _employeeService.GetSingleEmployee(id));
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            return Ok(await _employeeService.AddEmployee(employee));
        }

        [HttpPut]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(int id, Employee request)
        {
            var result = await _employeeService.UpdateEmployee(id, request);
            if (result.IsNullOrEmpty())
                return NotFound("The employee your trying to update does not exist.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployee(id);
            if (result.IsNullOrEmpty())
                return NotFound("The Employee is not found");
            return Ok(result);
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<Employee?>> AddJobDetailToEmployee(int id, int detailId)
        {
            var result = await _employeeService.AddJobDetailToEmployee(id, detailId);
            if (result is null)
                return NotFound("The Employee is not found");
            return Ok(result);
        }
    }
}
