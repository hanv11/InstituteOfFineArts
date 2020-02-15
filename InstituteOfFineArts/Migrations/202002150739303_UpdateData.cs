namespace InstituteOfFineArts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Awards",
                c => new
                    {
                        SubmissionId = c.Int(nullable: false, identity: true),
                        AwardName = c.Int(nullable: false),
                        Competition_CompetitionId = c.Int(),
                    })
                .PrimaryKey(t => t.SubmissionId)
                .ForeignKey("dbo.Competitions", t => t.Competition_CompetitionId)
                .Index(t => t.Competition_CompetitionId);
            
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        SubmissionId = c.Int(nullable: false, identity: true),
                        CompetitionId = c.Int(nullable: false),
                        Picture = c.String(),
                        AccountId = c.Int(nullable: false),
                        Description = c.String(),
                        Awards_SubmissionId = c.Int(),
                        Marks_SubmissionId = c.Int(),
                    })
                .PrimaryKey(t => t.SubmissionId)
                .ForeignKey("dbo.Awards", t => t.Awards_SubmissionId)
                .ForeignKey("dbo.Competitions", t => t.CompetitionId, cascadeDelete: true)
                .ForeignKey("dbo.Marks", t => t.Marks_SubmissionId)
                .Index(t => t.CompetitionId)
                .Index(t => t.Awards_SubmissionId)
                .Index(t => t.Marks_SubmissionId);
            
            CreateTable(
                "dbo.Competitions",
                c => new
                    {
                        CompetitionId = c.Int(nullable: false, identity: true),
                        CompetitionName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Image = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CompetitionId);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        SubmissionId = c.Int(nullable: false, identity: true),
                        Marks = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SubmissionId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(maxLength: 256),
                        Birthday = c.DateTime(),
                        Gender = c.Int(nullable: false),
                        Avatar = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdateAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        Status = c.Int(nullable: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Submissions", "Marks_SubmissionId", "dbo.Marks");
            DropForeignKey("dbo.Submissions", "CompetitionId", "dbo.Competitions");
            DropForeignKey("dbo.Awards", "Competition_CompetitionId", "dbo.Competitions");
            DropForeignKey("dbo.Submissions", "Awards_SubmissionId", "dbo.Awards");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Submissions", new[] { "Marks_SubmissionId" });
            DropIndex("dbo.Submissions", new[] { "Awards_SubmissionId" });
            DropIndex("dbo.Submissions", new[] { "CompetitionId" });
            DropIndex("dbo.Awards", new[] { "Competition_CompetitionId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Marks");
            DropTable("dbo.Competitions");
            DropTable("dbo.Submissions");
            DropTable("dbo.Awards");
        }
    }
}
