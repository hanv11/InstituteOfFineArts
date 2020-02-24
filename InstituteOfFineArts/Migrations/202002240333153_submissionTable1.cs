namespace InstituteOfFineArts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class submissionTable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Submissions", "UpdatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Submissions", "UpdatedAt", c => c.DateTime(nullable: false));
        }
    }
}
