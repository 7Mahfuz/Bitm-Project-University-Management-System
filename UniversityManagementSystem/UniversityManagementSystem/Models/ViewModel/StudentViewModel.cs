using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models.ViewModel
{
    public class StudentViewModel
    {
        
        public string Name { get; set; }
        public string Email { get; set; }
        
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }

        public int DepartmentId { get; set; }
    }
}