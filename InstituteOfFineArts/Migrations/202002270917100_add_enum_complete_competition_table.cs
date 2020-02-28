namespace InstituteOfFineArts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_enum_complete_competition_table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Submissions", "Awards_SubmissionId", "dbo.Awards");
            RenameColumn(table: "dbo.Submissions", name: "Awards_SubmissionId", newName: "Awards_AwardId");
            RenameIndex(table: "dbo.Submissions", name: "IX_Awards_SubmissionId", newName: "IX_Awards_AwardId");
            DropPrimaryKey("dbo.Awards");
            AddColumn("dbo.Awards", "AwardId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Awards", "AwardType", c => c.Int(nullable: false));
            AlterColumn("dbo.Awards", "AwardName", c => c.String());
            AddPrimaryKey("dbo.Awards", "AwardId");
            AddForeignKey("dbo.Submissions", "Awards_AwardId", "dbo.Awards", "AwardId");
            DropColumn("dbo.Awards", "SubmissionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Awards", "SubmissionId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Submissions", "Awards_AwardId", "dbo.Awards");
            DropPrimaryKey("dbo.Awards");
            AlterColumn("dbo.Awards", "AwardName", c => c.Int(nullable: false));
            DropColumn("dbo.Awards", "AwardType");
            DropColumn("dbo.Awards", "AwardId");
            AddPrimaryKey("dbo.Awards", "SubmissionId");
            RenameIndex(table: "dbo.Submissions", name: "IX_Awards_AwardId", newName: "IX_Awards_SubmissionId");
            RenameColumn(table: "dbo.Submissions", name: "Awards_AwardId", newName: "Awards_SubmissionId");
            AddForeignKey("dbo.Submissions", "Awards_SubmissionId", "dbo.Awards", "SubmissionId");
        }
    }
}
