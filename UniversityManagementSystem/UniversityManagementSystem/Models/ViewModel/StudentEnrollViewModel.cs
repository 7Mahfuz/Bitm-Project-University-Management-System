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
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string DepartmentName { get; set; }

    public int CourseId { get; set; }
        [DataType(DataType.Date)]
    public DateTime Date { get; set; }


  }
}