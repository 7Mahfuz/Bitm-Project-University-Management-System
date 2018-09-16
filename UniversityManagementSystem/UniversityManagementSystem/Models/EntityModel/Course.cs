using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Course Code")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Credit { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name = "Department")]
      public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Semester")]
        public int SemesterId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Semester Semester { get; set; }

    }
}