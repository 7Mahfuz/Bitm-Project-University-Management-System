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

        protected override void Seed(ApplicationDbContext context)
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
                new Semester { Name = "1st" },
                 new Semester { Name = "2nd" },
                 new Semester { Name = "3rd" },
                 new Semester { Name = "4th" },
                 new Semester { Name = "5th" },
                new Semester { Name = "6th" },
                 new Semester { Name = "7th" },
                new Semester { Name = "8th" }
                );

            context.TeacherDesignations.AddOrUpdate(
                x => x.Name,
                new TeacherDesignation { Name = "Math Teacher" },
                new TeacherDesignation { Name = "Physics Teacher" },
                new TeacherDesignation { Name = "Programming Teacher" },
                new TeacherDesignation { Name = "English Teacher" }

                );

            context.Rooms.AddOrUpdate(
                x => x.RoomNumber,
                new Room { RoomNumber = "A-101" },
                new Room { RoomNumber = "A-102" },
                new Room { RoomNumber = "A-103" },
                new Room { RoomNumber = "A-104" },
                new Room { RoomNumber = "A-105" },
                new Room { RoomNumber = "A-105" },
                new Room { RoomNumber = "A-106" },
                new Room { RoomNumber = "A-107" },
                new Room { RoomNumber = "A-108" },
                new Room { RoomNumber = "A-109" },
                new Room { RoomNumber = "A-110" }
                );

            context.Days.AddOrUpdate(x => x.Name,
                new Day { Name = "Saturday", ShortName = "Sat" },
                new Day { Name = "Sunday", ShortName = "Sun" },
                    new Day { Name = "Monday", ShortName = "Mon" },
                        new Day { Name = "Tuesday", ShortName = "Tue" },
                            new Day { Name = "Wednesday", ShortName = "Wed" },
                                new Day { Name = "Thursday", ShortName = "Thu" },
                                    new Day { Name = "Friday", ShortName = "Fri" }
                );
        }
    }
}
