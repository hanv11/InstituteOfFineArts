namespace InstituteOfFineArts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSildeBarToCompetition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Competitions", "IsSlide", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Competitions", "IsSlide");
        }
    }
}
