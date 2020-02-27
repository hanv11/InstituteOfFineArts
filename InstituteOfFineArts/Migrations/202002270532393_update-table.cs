namespace InstituteOfFineArts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Submissions", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Submissions", "Status");
            DropColumn("dbo.Submissions", "CreatedAt");
        }
    }
}
