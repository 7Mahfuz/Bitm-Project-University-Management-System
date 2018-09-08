using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UniversityManagementSystem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UniversityManagementSystem.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Semesters.AddOrUpdate(
                x => x.Name, 
                new Semester { Name = "1st"},
                 new Semester { Name = "2nd"},
                 new Semester { Name = "3rd"},
                 new Semester { Name = "4th"},
                 new Semester { Name = "5th"},
                new Semester { Name = "6th"},
                 new Semester { Name = "7th"},
                new Semester { Name = "8th"}
                );
        }
    }
}
