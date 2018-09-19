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
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Registration No")]
        public string RegNo { get; set; }
        [Display(Name = "Contact Number")]
        [Required]
        public string ContactNo { get; set; }
        public string Address { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        public int DepartmentId { get; set; }

        public string Year { get; set; }

        public virtual Department Department { get; set; }

    }
}