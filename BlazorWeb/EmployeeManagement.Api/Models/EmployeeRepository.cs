using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await appDbContext.Employees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var employee = await appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if(employee != null)
            {
                appDbContext.Employees.Remove(employee);
                await appDbContext.SaveChangesAsync();
                return employee;
            }
            return null;
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await appDbContext.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await appDbContext.Employees.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var employeeToUpdate = await appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);
            if(employeeToUpdate != null)
            {
                employeeToUpdate.FirstName= employee.FirstName;
                employeeToUpdate.LastName= employee.LastName;
                employeeToUpdate.Email= employee.Email;
                employeeToUpdate.DateOfBirth = employee.DateOfBirth;
                employeeToUpdate.Gender = employee.Gender;
                employeeToUpdate.DepartmentId = employee.DepartmentId;
                employeeToUpdate.PhotoPath = employee.PhotoPath;
                await appDbContext.SaveChangesAsync();
                return employeeToUpdate;
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = appDbContext.Employees;

            if(!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));
            }

            if(gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }
    }
}
