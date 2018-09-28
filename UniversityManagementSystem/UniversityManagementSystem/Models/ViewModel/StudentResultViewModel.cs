using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
  [Serializable]
  public class StudentResultViewModel
    {
        [Required]
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        [Display(Name = "Student's Name")]
        public string Name { get; set; }
        [Display(Name = "Student's Email")]
        public string Email { get; set; }
        [Display(Name = "Department")]
        public string DepartmentName { get; set; }
        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [Required]
        [Range(1,20, ErrorMessage = "Grade is Required")]
        public string Grade { get; set; }

  }
}