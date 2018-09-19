using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNet.Identity.EntityFramework;
using UniversityManagementSystem.Models.EntityModel;
using System.Reflection.Emit;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace UniversityManagementSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    

    public class ApplicationDbContext:DbContext
    {
      
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherDesignation> TeacherDesignations { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public DbSet<CourseAssignTeacher> CourseAssignTeachers { get; set; }

        public DbSet<Day> Days { get; set; }
        public DbSet<AllocateClassRoom> AllocateClassRooms { get; set; }

        public DbSet<StudentEnrollInCourse> StideStudentEnrollInCourses { get; set; }
        public DbSet<Result> Results { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<AllocateClassRoom>().HasRequired(c => c.Department).WithMany().WillCascadeOnDelete(false);
           //modelBuilder.Entity<Student>().HasRequired(c => c.Department).WithMany().WillCascadeOnDelete(false);
           // modelBuilder.Entity<Course>().HasRequired(c => c.Department).WithMany().WillCascadeOnDelete(false);
           // modelBuilder.Entity<CourseAssignTeacher>().HasRequired(c => c.Department).WithMany().WillCascadeOnDelete(false);
           // modelBuilder.Entity<AllocateClassRoom>().HasRequired(c => c.Department).WithMany().WillCascadeOnDelete(false);

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}