using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{[Serializable]
    public class CourseTeacherViewModel
    {[Required]
    public int DepartmentId { get; set; }
        [Required]
    public int TeacherId { get; set; }
    public double CreditToTake { get; set; }
    public double RemainingCredit { get; set; }
        [Required]
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public double CourseCredit { get; set; }

    }
}