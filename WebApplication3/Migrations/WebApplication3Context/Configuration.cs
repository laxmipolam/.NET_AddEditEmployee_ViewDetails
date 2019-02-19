namespace WebApplication3.Migrations.WebApplication3Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication3.Models;


    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication3.Models.WebApplication3Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\WebApplication3Context";
        }

        protected override void Seed(WebApplication3.Models.WebApplication3Context context)
        {
            context.Colleges.AddOrUpdate(x => x.Id,
        new College() { Id = 1, Name = "Jane Austen" },
        new College() { Id = 2, Name = "Charles Dickens" },
        new College() { Id = 3, Name = "Miguel de Cervantes" }
        );
            context.Streams.AddOrUpdate(x => x.Id,
        new Stream() { Id = 1, Name = "Jane Austen" },
        new Stream() { Id = 2, Name = "Charles Dickens" },
        new Stream() { Id = 3, Name = "Miguel de Cervantes" }
        );
            context.Branches.AddOrUpdate(x => x.Id,
        new Branch() { Id = 1, Name = "Jane Austen" },
        new Branch() { Id = 2, Name = "Charles Dickens" },
        new Branch() { Id = 3, Name = "Miguel de Cervantes" }
        );
            context.Qualifications.AddOrUpdate(x => x.Id,
        new Qualification() { Id = 1, Name = "Jane Austen" },
        new Qualification() { Id = 2, Name = "Charles Dickens" },
        new Qualification() { Id = 3, Name = "3" }
        );

            context.Employees.AddOrUpdate(x => x.Id,
       new Employee()
       {
           Id = 1,
           FirstName = "Laxmi",
           LastName = "Polam",
           DateOfBirth = "15-03-1996",
           MobileNumber = "7036354051",
           Gender = "Female",
           Email = "lamipolam@gmail.com",
           YearOfGraduating = 2017,
           DateOfJoining = "26-06-2017",
           Language = "English",
           IsActive = true,
           StreamId = 1,
           BranchId =1,
           QualificationId = 2,
           CollegeId = 3,
           
       },
        new Employee()
        {
            Id = 2,
            FirstName = "Laxmi",
            LastName = "Polam",
            DateOfBirth = "15-03-1996",
            MobileNumber = "7036354051",
            Gender = "Female",
           Email = "laxmipolamf@gmail.com",
            YearOfGraduating = 2017,
            DateOfJoining = "26-06-2017",
            Language = "English",
            IsActive = true,
            StreamId = 1,
            BranchId = 1,
            QualificationId = 2,
            CollegeId = 3,

        },
        new Employee()
        {
            Id = 3,
            FirstName = "saketh",
            LastName = "G",
            DateOfBirth = "15-03-1996",
            MobileNumber = "7036354051",
            Gender = "Female",
           Email = "lfdff@gmail.com",
            YearOfGraduating = 2017,
            DateOfJoining = "26-06-2017",
            Language = "English",
            IsActive = true,
            StreamId = 1,
            BranchId = 1,
            QualificationId = 2,
            CollegeId = 3,

        },
        new Employee()
        {
            Id = 4,
            FirstName = "Akhil",
            LastName = "K",
            DateOfBirth = "15-03-1996",
            MobileNumber = "7036354051",
            Gender = "Female",
           Email = "lgfh@gmail.com",
            YearOfGraduating = 2017,
            DateOfJoining = "26-06-2017",
            Language = "English",
            IsActive = true,
            StreamId = 1,
            BranchId = 1,
            QualificationId = 2,
            CollegeId = 3,

        }
       );

        }
    }
}
