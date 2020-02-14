namespace InstituteOfFineArts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "UpdateAt", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "DeletedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "DeletedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "UpdateAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
