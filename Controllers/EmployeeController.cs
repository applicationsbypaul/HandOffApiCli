using HandOffApiCli.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HandOffApiCli.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee
            {   Id = 1,
                EmployeeFirstName = "Paul",
                EmployeeLastName = "Ford"
            },
            new Employee
            {
                Id = 2,
                EmployeeFirstName = "Amy",
                EmployeeLastName = "Eisenberg"
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee employee)
        {
            employees.Add(employee);
            return Ok(employees);
        }

        [HttpPut]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(int id, Employee request)
        {
            var employee = employees.Find(e => e.Id==id);
            if (employee == null)
                return NotFound("Sorry, but this employee doesn't exist");

            employee.EmployeeFirstName = request.EmployeeFirstName;
            employee.EmployeeLastName = request.EmployeeLastName;
            
            return Ok(employees);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteHero(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            if (employee == null)
                return NotFound("Sorry, but this employee doesn't exist");

            employees.Remove(employee);
            return Ok(employees);
        }
    }
}
