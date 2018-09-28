using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models.EntityModel;

namespace UniversityManagementSystem.Models
{
    public class Student
    {[Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name must be contain only letters")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Registration No")]
        public string RegNo { get; set; }
        [Display(Name = "Contact Number")]
        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Use only Digits")]
        public string ContactNo { get; set; }
        public string Address { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string Date { get; set; }
        [Required]
        public int DepartmentId { get; set; }

        public string Year { get; set; }

        public virtual Department Department { get; set; }

    }
}