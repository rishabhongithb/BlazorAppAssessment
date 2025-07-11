using BlazorAppAssessmentLibrary;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppAssessmentApi.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base (options)
        {
                
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
