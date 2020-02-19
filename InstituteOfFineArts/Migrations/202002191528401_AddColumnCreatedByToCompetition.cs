namespace InstituteOfFineArts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnCreatedByToCompetition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Competitions", "CreatedBy", c => c.String(maxLength: 128));
            CreateIndex("dbo.Competitions", "CreatedBy");
            AddForeignKey("dbo.Competitions", "CreatedBy", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Competitions", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Competitions", new[] { "CreatedBy" });
            DropColumn("dbo.Competitions", "CreatedBy");
        }
    }
}
