using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Student
    {[Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Email { get; set; }
        public string RegNo { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int DepartmentId { get; set; }

    }
}