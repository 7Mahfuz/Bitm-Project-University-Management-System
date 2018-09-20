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
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Code must be start with Letter")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Code must be at least 5 charcter long")]
        [Display(Name = "Course Code")]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.5, 5.00, ErrorMessage = "Credit must be between 0.5 to 5.0")]
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