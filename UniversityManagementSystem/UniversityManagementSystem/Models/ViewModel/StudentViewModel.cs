using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{[Serializable]
    public class StudentViewModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name must be contain only letters")]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Display(Name = "Contact Number")]
        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Use only Digits")]
        public string ContactNo { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
    }
}