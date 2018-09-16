using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class CourseAssignTeacher
    {[Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }
        [Required]
        public double CreditTaken { get; set; }
        [Required]
        [Display(Name = "Course Code")]
        public int CourseId { get; set; }

        public bool IsActive { get; set; }

        public virtual Department Department { get; set; }
        public virtual Teacher Teacher { get; set; }

    }
}