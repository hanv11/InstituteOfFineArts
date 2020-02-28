namespace InstituteOfFineArts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCompetitionModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Competitions", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Competitions", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Competitions", "CancelAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Competitions", "CancelAt");
            DropColumn("dbo.Competitions", "UpdatedAt");
            DropColumn("dbo.Competitions", "CreatedAt");
        }
    }
}
