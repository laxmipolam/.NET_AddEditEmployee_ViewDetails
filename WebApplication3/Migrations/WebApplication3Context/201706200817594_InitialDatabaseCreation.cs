namespace WebApplication3.Migrations.WebApplication3Context
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Colleges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        DateOfBirth = c.String(),
                        MobileNumber = c.String(),
                        Gender = c.String(),
                        Email = c.String(),
                        YearOfGraduating = c.Int(nullable: false),
                        DateOfJoining = c.String(),
                        Language = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CollegeId = c.Int(nullable: false),
                        StreamId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        QualificationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Colleges", t => t.CollegeId, cascadeDelete: true)
                .ForeignKey("dbo.Qualifications", t => t.QualificationId, cascadeDelete: true)
                .ForeignKey("dbo.Streams", t => t.StreamId, cascadeDelete: true)
                .Index(t => t.CollegeId)
                .Index(t => t.StreamId)
                .Index(t => t.BranchId)
                .Index(t => t.QualificationId);
            
            CreateTable(
                "dbo.Qualifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Streams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "StreamId", "dbo.Streams");
            DropForeignKey("dbo.Employees", "QualificationId", "dbo.Qualifications");
            DropForeignKey("dbo.Employees", "CollegeId", "dbo.Colleges");
            DropForeignKey("dbo.Employees", "BranchId", "dbo.Branches");
            DropIndex("dbo.Employees", new[] { "QualificationId" });
            DropIndex("dbo.Employees", new[] { "BranchId" });
            DropIndex("dbo.Employees", new[] { "StreamId" });
            DropIndex("dbo.Employees", new[] { "CollegeId" });
            DropTable("dbo.Streams");
            DropTable("dbo.Qualifications");
            DropTable("dbo.Employees");
            DropTable("dbo.Colleges");
            DropTable("dbo.Branches");
        }
    }
}
