using BlazorAppAssessmentApi.Data;
using BlazorAppAssessmentLibrary;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppAssessmentApi.SQLOperatiion
{
    public class EmployeesSQL
    {
        private readonly ApplicationDBContext _context;
        public EmployeesSQL(ApplicationDBContext context) 
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {        
            return _context.Employees.AsNoTracking(); 
        }

        public bool CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return true;
        }
    }
}
