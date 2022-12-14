using HandOffApiCli.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HandOffApiCli.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
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

        public List<Employee> AddEmployee(Employee employee)
        {
            employees.Add(employee);
            return (employees);
        }

        public List<Employee> DeleteEmployee(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            if (employee == null)
                return null;

            employees.Remove(employee);
            return (employees);
        }

        public List<Employee> GetAllEmployees()
        {
            return (employees);
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
