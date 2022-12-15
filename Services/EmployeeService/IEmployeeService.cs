using HandOffApiCli.Data.Entities;

namespace HandOffApiCli.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Employee GetSingleEmployee(int id);
        Task<Employee> AddEmployee(Employee employee);
        List<Employee> UpdateEmployee(int id , Employee request);
        Task<List<Employee>> DeleteEmployee(int id);
    }
}
