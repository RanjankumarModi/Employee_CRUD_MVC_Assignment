namespace AssignmentCrudMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Salaries", "EmpId", "dbo.Employees");
            DropPrimaryKey("dbo.Salaries");
            AddPrimaryKey("dbo.Salaries", "EmpId");
            AddForeignKey("dbo.Salaries", "EmpId", "dbo.Employees", "Id");
            DropColumn("dbo.Salaries", "id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Salaries", "id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Salaries", "EmpId", "dbo.Employees");
            DropPrimaryKey("dbo.Salaries");
            AddPrimaryKey("dbo.Salaries", "id");
            AddForeignKey("dbo.Salaries", "EmpId", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
