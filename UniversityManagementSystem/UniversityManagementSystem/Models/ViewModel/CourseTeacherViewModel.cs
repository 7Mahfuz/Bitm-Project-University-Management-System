using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{[Serializable]
    public class CourseTeacherViewModel
    {[Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }
      
        [Display(Name = "Credit to take")]
        public double CreditToTake { get; set; }
        [Display(Name = "Remaning Credit")]
        public double RemainingCredit { get; set; }
        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
    public string CourseName { get; set; }
    public double CourseCredit { get; set; }

    }
}