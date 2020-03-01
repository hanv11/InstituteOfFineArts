namespace InstituteOfFineArts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_column_slides_competition_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Competitions", "Slide", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Competitions", "Slide");
        }
    }
}
