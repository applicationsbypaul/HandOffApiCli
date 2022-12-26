using HandOffApiCli.Data;
using HandOffApiCli.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HandOffApiCli.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>?> GetAllEmployees();
        Task<Employee?> GetSingleEmployee(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task<List<Employee>?> UpdateEmployee(int id, Employee request);
        Task<List<Employee>?> DeleteEmployee(int id);
        Task<Employee?> AddJobDetailToEmployee(int id, JobDetail detail);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly HandOffContext _context;
        public EmployeeService(HandOffContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            await _context.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<List<Employee>?> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee is null)
                return null;

            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();
            return await GetAllEmployees();
        }

        public async Task<List<Employee>?> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync(); ;
        }

        public async Task<Employee?> GetSingleEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee is null)
                return null;
            return employee;
        }

        public async Task<List<Employee>?> UpdateEmployee(int id, Employee request)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee is null)
                return null;

            employee.EmployeeFirstName = request.EmployeeFirstName;
            employee.EmployeeLastName = request.EmployeeLastName;
            await _context.SaveChangesAsync();

            return await GetAllEmployees();
        }

        public async Task<Employee?> AddJobDetailToEmployee(int id, JobDetail detail)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee is null)
                return null;
            employee.JobDetailId = detail.JobDetailId;
            await _context.SaveChangesAsync();
            return employee;

        }
    }
}
