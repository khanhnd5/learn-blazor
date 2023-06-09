using BlazorWebDemo.Server.Services;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorWebDemo.Client.Pages
{
    public class EmployeeListBase:ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
        }
    }
}
