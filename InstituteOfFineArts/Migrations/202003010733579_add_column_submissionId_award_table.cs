namespace InstituteOfFineArts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_column_submissionId_award_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Awards", "SubmissionId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Awards", "SubmissionId");
        }
    }
}
