using HandOffApiCli.Data.Entities;

namespace HandOffApiCli.Services.EmployeeService
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee GetSingleEmployee(int id);
        List<Employee> AddEmployee(Employee employee);
        List<Employee> UpdateEmployee(int id , Employee request);
        List<Employee> DeleteEmployee(int id);
    }
}
