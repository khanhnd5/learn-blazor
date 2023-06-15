using EmployeeManagement.Models;

namespace BlazorWebDemo.Client.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<HttpResponseMessage> UpdateEmployee(Employee updatedEmployee);
        Task<HttpResponseMessage> CreateEmployee(Employee newEmployee);
        Task DeleteEmployee(int id);
    }
}
