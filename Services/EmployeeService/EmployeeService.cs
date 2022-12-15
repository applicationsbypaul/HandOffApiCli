using HandOffApiCli.Data;
using HandOffApiCli.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandOffApiCli.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HandOffContext _context;
        public EmployeeService(HandOffContext context)
        {
            _context = context;
        }

        private static List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
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

        public async Task <List<Employee>> AddEmployee(Employee employee)
        {
            await _context.AddAsync(employee);
            await _context.SaveChangesAsync();
            var result = await GetAllEmployees();
            return (result);
        }

        public List<Employee> DeleteEmployee(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            if (employee == null)
                return null;

            employees.Remove(employee);
            return (employees);
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var result = await _context.Employees.ToListAsync();
            return (result);
        }

        public Employee GetSingleEmployee(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            return (employee);
        }

        public List<Employee> UpdateEmployee(int id, Employee request)
        {
            var employee = employees.Find(e => e.Id == id);
            if (employee == null)
                return null;

            employee.EmployeeFirstName = request.EmployeeFirstName;
            employee.EmployeeLastName = request.EmployeeLastName;

            return (employees);
        }
    }
}
