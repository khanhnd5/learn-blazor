using BlazorWebDemo.Client.Services;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorWebDemo.Client.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();
        public Department Department { get; set; } = new Department();

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected string Coordinates { get; set; }

        protected string ButtonText { get; set; } = "Hide Footer";
        protected string CssClass { get; set; } = null;

        protected async override Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            Department = await DepartmentService.GetDepartment(Employee.DepartmentId);
        }

        protected void Button_Click()
        {
            if(ButtonText == "Hide Footer")
            {
                ButtonText = "Show Footer";
                CssClass = "HideFooter";
            }
            else
            {
                CssClass = null;
                ButtonText = "Hide Footer";
            }
        }
    }
}
