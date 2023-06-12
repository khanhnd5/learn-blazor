using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorWebDemo.Client.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }
        [Parameter]
        public bool ShowFooter { get; set; }
    }
}
