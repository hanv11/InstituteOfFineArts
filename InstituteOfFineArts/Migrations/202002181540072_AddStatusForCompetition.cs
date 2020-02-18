namespace InstituteOfFineArts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusForCompetition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Competitions", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Competitions", "Status");
        }
    }
}
