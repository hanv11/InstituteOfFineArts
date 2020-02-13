namespace InstituteOfFineArts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_model1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Submissions", "Competitions_CompetitionId", "dbo.Competitions");
            DropIndex("dbo.Submissions", new[] { "Competitions_CompetitionId" });
            RenameColumn(table: "dbo.Submissions", name: "Competitions_CompetitionId", newName: "CompetitionId");
            AddColumn("dbo.Submissions", "AccountId", c => c.Int(nullable: false));
            AlterColumn("dbo.Submissions", "CompetitionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Submissions", "CompetitionId");
            AddForeignKey("dbo.Submissions", "CompetitionId", "dbo.Competitions", "CompetitionId", cascadeDelete: true);
            DropColumn("dbo.Submissions", "CompetionId");
            DropColumn("dbo.Submissions", "StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Submissions", "StudentId", c => c.Int(nullable: false));
            AddColumn("dbo.Submissions", "CompetionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Submissions", "CompetitionId", "dbo.Competitions");
            DropIndex("dbo.Submissions", new[] { "CompetitionId" });
            AlterColumn("dbo.Submissions", "CompetitionId", c => c.Int());
            DropColumn("dbo.Submissions", "AccountId");
            RenameColumn(table: "dbo.Submissions", name: "CompetitionId", newName: "Competitions_CompetitionId");
            CreateIndex("dbo.Submissions", "Competitions_CompetitionId");
            AddForeignKey("dbo.Submissions", "Competitions_CompetitionId", "dbo.Competitions", "CompetitionId");
        }
    }
}
