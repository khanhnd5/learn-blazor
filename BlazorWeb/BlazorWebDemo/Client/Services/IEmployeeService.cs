using EmployeeManagement.Models;

namespace BlazorWebDemo.Server.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
    }
}
