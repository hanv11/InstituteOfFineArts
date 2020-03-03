namespace InstituteOfFineArts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAccount : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Competition_CompetitionId", "dbo.Competitions");
            DropForeignKey("dbo.AspNetUsers", "Competition_CompetitionId1", "dbo.Competitions");
            DropIndex("dbo.AspNetUsers", new[] { "Competition_CompetitionId" });
            DropIndex("dbo.AspNetUsers", new[] { "Competition_CompetitionId1" });
            CreateTable(
                "dbo.CompetitionAccounts",
                c => new
                    {
                        Competition_CompetitionId = c.Int(nullable: false),
                        Account_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Competition_CompetitionId, t.Account_Id })
                .ForeignKey("dbo.Competitions", t => t.Competition_CompetitionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Account_Id, cascadeDelete: true)
                .Index(t => t.Competition_CompetitionId)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.CompetitionAccount1",
                c => new
                    {
                        Competition_CompetitionId = c.Int(nullable: false),
                        Account_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Competition_CompetitionId, t.Account_Id })
                .ForeignKey("dbo.Competitions", t => t.Competition_CompetitionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Account_Id, cascadeDelete: true)
                .Index(t => t.Competition_CompetitionId)
                .Index(t => t.Account_Id);
            
            DropColumn("dbo.AspNetUsers", "Competition_CompetitionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Competition_CompetitionId", c => c.Int());
            DropForeignKey("dbo.CompetitionAccount1", "Account_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CompetitionAccount1", "Competition_CompetitionId", "dbo.Competitions");
            DropForeignKey("dbo.CompetitionAccounts", "Account_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CompetitionAccounts", "Competition_CompetitionId", "dbo.Competitions");
            DropIndex("dbo.CompetitionAccount1", new[] { "Account_Id" });
            DropIndex("dbo.CompetitionAccount1", new[] { "Competition_CompetitionId" });
            DropIndex("dbo.CompetitionAccounts", new[] { "Account_Id" });
            DropIndex("dbo.CompetitionAccounts", new[] { "Competition_CompetitionId" });
            DropTable("dbo.CompetitionAccount1");
            DropTable("dbo.CompetitionAccounts");
            CreateIndex("dbo.AspNetUsers", "Competition_CompetitionId1");
            CreateIndex("dbo.AspNetUsers", "Competition_CompetitionId");
            AddForeignKey("dbo.AspNetUsers", "Competition_CompetitionId1", "dbo.Competitions", "CompetitionId");
            AddForeignKey("dbo.AspNetUsers", "Competition_CompetitionId", "dbo.Competitions", "CompetitionId");
        }
    }
}
