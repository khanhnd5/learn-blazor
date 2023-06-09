using EmployeeManagement.Models;

namespace BlazorWebDemo.Server.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
    }
}
