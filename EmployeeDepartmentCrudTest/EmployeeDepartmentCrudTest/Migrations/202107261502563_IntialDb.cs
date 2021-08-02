namespace EmployeeDepartmentCrudTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DeptId = c.Int(nullable: false, identity: true),
                        DeptName = c.String(nullable: false, maxLength: 40),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DeptId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        DeptId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 40),
                        DOJ = c.DateTime(nullable: false),
                        Mobile = c.Long(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Departments", t => t.DeptId, cascadeDelete: true)
                .Index(t => t.DeptId);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        SalaryAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete : true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salaries", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "DeptId", "dbo.Departments");
            DropIndex("dbo.Salaries", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "DeptId" });
            DropTable("dbo.Salaries");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
