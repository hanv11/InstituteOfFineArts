namespace InstituteOfFineArts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Awards", "Competition_CompetitionId", c => c.Int());
            CreateIndex("dbo.Awards", "Competition_CompetitionId");
            AddForeignKey("dbo.Awards", "Competition_CompetitionId", "dbo.Competitions", "CompetitionId");
            DropColumn("dbo.Competitions", "AwardDetails");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Competitions", "AwardDetails", c => c.String());
            DropForeignKey("dbo.Awards", "Competition_CompetitionId", "dbo.Competitions");
            DropIndex("dbo.Awards", new[] { "Competition_CompetitionId" });
            DropColumn("dbo.Awards", "Competition_CompetitionId");
        }
    }
}
