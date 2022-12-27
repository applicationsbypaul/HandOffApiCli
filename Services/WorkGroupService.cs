using HandOffApiCli.Data.Entities;
using HandOffApiCli.Data;
using Microsoft.EntityFrameworkCore;

namespace HandOffApiCli.Services
{
    public interface IWorkGroupService
    {
        Task<List<WorkGroup>> GetAllWorkGroups();
        Task<WorkGroup?> AddEmployeeToWorkGroup(int id, Employee employee);

    }
    public class WorkGroupService : IWorkGroupService
    {
        private readonly HandOffContext _context;

        public WorkGroupService(HandOffContext context)
        {
            _context= context;
        }

        public async Task<List<WorkGroup>> GetAllWorkGroups()
        {
            return await _context.WorkGroups.ToListAsync();
        }

        public async Task<WorkGroup?> AddEmployeeToWorkGroup(int id, Employee employee)
        {
            var workgroup = await _context.WorkGroups.FindAsync(id);
            //var realEmployee = await _context.Employees.FindAsync(employee.EmployeeId);
            if (workgroup == null)
            {
                return null;
            }
            workgroup.Employees = employee;
            _context.SaveChanges();
            return workgroup;
        }
    }
}
