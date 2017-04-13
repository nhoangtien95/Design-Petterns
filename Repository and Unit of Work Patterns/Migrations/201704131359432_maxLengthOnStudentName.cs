namespace Repository_and_Unit_of_Work_Patterns.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maxLengthOnStudentName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Student", "FirstMidName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "FirstMidName", c => c.String());
            AlterColumn("dbo.Student", "LastName", c => c.String());
        }
    }
}
