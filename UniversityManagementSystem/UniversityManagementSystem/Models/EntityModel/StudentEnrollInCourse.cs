using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class StudentEnrollInCourse
    {[Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int StudentId { get; set; }
        [Required]
        [Display(Name = "Course Code")]
        public int CourseId { get; set; }
        public string Date { get; set; }

        public bool IsAcTive { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}