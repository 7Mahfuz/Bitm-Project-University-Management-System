using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNet.Identity.EntityFramework;

namespace UniversityManagementSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
           }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherDesignation> TeacherDesignations { get; set; }
    }
}