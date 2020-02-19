namespace InstituteOfFineArts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Submissions", "AccountId", "dbo.AspNetUsers");
            DropIndex("dbo.Submissions", new[] { "AccountId" });
            AlterColumn("dbo.Submissions", "AccountId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Submissions", "AccountId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Submissions", "AccountId");
            AddForeignKey("dbo.Submissions", "AccountId", "dbo.AspNetUsers", "Id");
        }
    }
}
