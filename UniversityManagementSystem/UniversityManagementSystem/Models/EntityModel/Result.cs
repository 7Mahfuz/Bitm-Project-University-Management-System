using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models.EntityModel
{
    public class Result
    {[Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [Required]
        public string Grade { get; set; }

        public bool IsActive { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

    }
}