namespace AppEmployee.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Domain.Entities;
    internal sealed class Configuration : DbMigrationsConfiguration<AppEmployee.Data.AppEmployeeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppEmployee.Data.AppEmployeeDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (context.Departments.Count()==0)
            {
                    context.Departments.AddOrUpdate(
                    new Department() {  Name = "Quan ly nhan su", TotalEmployee = 5 },
                     new Department() {  Name = "Ke toan", TotalEmployee = 5 },
                      new Department() { Name = "Ke Hoach", TotalEmployee = 5 }
                    );
            }


        }
    }
}
