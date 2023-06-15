﻿using BlazorWebDemo.Client.Services;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorWebDemo.Client.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();
        public List<Department> Departments { get; set; } = new List<Department>();

        public string DepartmentId { get; set; }
        
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            Departments = (await DepartmentService.GetDepartments()).ToList();
            DepartmentId = Employee.DepartmentId.ToString();
        }

        protected async Task HandleValidSubmit()
        {
            Employee.Department = await DepartmentService.GetDepartment(Employee.DepartmentId);

            var result = await EmployeeService.UpdateEmployee(Employee);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
