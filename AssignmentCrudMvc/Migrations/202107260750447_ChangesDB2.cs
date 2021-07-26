namespace AssignmentCrudMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesDB2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Mobile", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Mobile", c => c.Int(nullable: false));
        }
    }
}
