namespace InstituteOfFineArts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatetable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Submissions", "Picture", c => c.String(nullable: false));
            AlterColumn("dbo.Submissions", "SubmissionName", c => c.String(nullable: false));
            AlterColumn("dbo.Submissions", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Competitions", "CompetitionName", c => c.String(nullable: false));
            AlterColumn("dbo.Competitions", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.Competitions", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Competitions", "ShortDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Competitions", "AwardDetail", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "Birthday", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Avatar", c => c.String(nullable: false));
            AlterColumn("dbo.Marks", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Marks", "Description", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Avatar", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Birthday", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AlterColumn("dbo.Competitions", "AwardDetail", c => c.String());
            AlterColumn("dbo.Competitions", "ShortDescription", c => c.String());
            AlterColumn("dbo.Competitions", "Description", c => c.String());
            AlterColumn("dbo.Competitions", "Image", c => c.String());
            AlterColumn("dbo.Competitions", "CompetitionName", c => c.String());
            AlterColumn("dbo.Submissions", "Description", c => c.String());
            AlterColumn("dbo.Submissions", "SubmissionName", c => c.String());
            AlterColumn("dbo.Submissions", "Picture", c => c.String());
        }
    }
}
