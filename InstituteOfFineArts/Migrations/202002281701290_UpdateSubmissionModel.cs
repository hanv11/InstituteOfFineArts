namespace InstituteOfFineArts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSubmissionModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Submissions", name: "AccountId", newName: "CreatorId");
            RenameIndex(table: "dbo.Submissions", name: "IX_AccountId", newName: "IX_CreatorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Submissions", name: "IX_CreatorId", newName: "IX_AccountId");
            RenameColumn(table: "dbo.Submissions", name: "CreatorId", newName: "AccountId");
        }
    }
}
