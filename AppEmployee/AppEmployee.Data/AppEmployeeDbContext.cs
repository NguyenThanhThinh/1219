using System.Data.Entity;

namespace AppEmployee.Data
{
    using AppEmployee.Domain.Entities;
    public class AppEmployeeDbContext : DbContext
    {
        public AppEmployeeDbContext() : base("AppEmployee")
        {

        }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
