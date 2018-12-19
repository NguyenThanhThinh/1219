namespace AppEmployee.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Departments", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Employees", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Employees", "ModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Departments", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Departments", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
