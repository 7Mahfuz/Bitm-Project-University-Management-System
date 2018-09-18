using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{[Serializable]
    public class StudentViewModel
    {
        
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name = "Contact Number")]
        public string ContactNo { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
    }
}