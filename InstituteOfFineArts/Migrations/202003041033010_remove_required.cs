namespace InstituteOfFineArts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Competitions", "AwardDetail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Competitions", "AwardDetail", c => c.String(nullable: false));
        }
    }
}
