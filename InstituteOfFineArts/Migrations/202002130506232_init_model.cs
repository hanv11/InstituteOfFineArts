namespace InstituteOfFineArts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Competitions",
                c => new
                    {
                        CompetitionId = c.Int(nullable: false, identity: true),
                        CompetitionName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Image = c.String(),
                        AwardDetails = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CompetitionId);
            
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        SubmissionId = c.Int(nullable: false, identity: true),
                        CompetionId = c.Int(nullable: false),
                        Picture = c.String(),
                        StudentId = c.Int(nullable: false),
                        Description = c.String(),
                        Awards_SubmissionId = c.Int(),
                        Competitions_CompetitionId = c.Int(),
                        Marks_SubmissionId = c.Int(),
                    })
                .PrimaryKey(t => t.SubmissionId)
                .ForeignKey("dbo.Awards", t => t.Awards_SubmissionId)
                .ForeignKey("dbo.Competitions", t => t.Competitions_CompetitionId)
                .ForeignKey("dbo.Marks", t => t.Marks_SubmissionId)
                .Index(t => t.Awards_SubmissionId)
                .Index(t => t.Competitions_CompetitionId)
                .Index(t => t.Marks_SubmissionId);
            
            CreateTable(
                "dbo.Awards",
                c => new
                    {
                        SubmissionId = c.Int(nullable: false, identity: true),
                        AwardName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubmissionId);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        SubmissionId = c.Int(nullable: false, identity: true),
                        Marks = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SubmissionId);
            
            AlterColumn("dbo.AspNetUsers", "AccountId", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Submissions", "Marks_SubmissionId", "dbo.Marks");
            DropForeignKey("dbo.Submissions", "Competitions_CompetitionId", "dbo.Competitions");
            DropForeignKey("dbo.Submissions", "Awards_SubmissionId", "dbo.Awards");
            DropIndex("dbo.Submissions", new[] { "Marks_SubmissionId" });
            DropIndex("dbo.Submissions", new[] { "Competitions_CompetitionId" });
            DropIndex("dbo.Submissions", new[] { "Awards_SubmissionId" });
            AlterColumn("dbo.AspNetUsers", "AccountId", c => c.Int(nullable: false));
            DropTable("dbo.Marks");
            DropTable("dbo.Awards");
            DropTable("dbo.Submissions");
            DropTable("dbo.Competitions");
        }
    }
}
