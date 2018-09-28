using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
  [Serializable]
  public class StudentEnrollViewModel
  {
        [Required]
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        [Display(Name = "Student Name")]
        public string Name { get; set; }
        [Display(Name = "Student's Email")]
        public string Email { get; set; }
        [Display(Name = "Department")]
        public string DepartmentName { get; set; }
        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [Required]
        [DataType(DataType.Date)]
    public DateTime Date { get; set; }


  }
}