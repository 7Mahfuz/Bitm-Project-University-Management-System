using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Teacher
    {    [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name must be contain only letters")]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Contact Number")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Use only Digits")]
        public string ContactNo { get; set; }
        [Required]
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Credit to Be Taken")]
        [Range(0,100, ErrorMessage = "Credit must be a Positive number")]
        public double CreditToBeTaken { get; set; }

         public virtual Department Department { get; set; }
        public virtual TeacherDesignation TeacherDesignation { get; set; }
    }
}