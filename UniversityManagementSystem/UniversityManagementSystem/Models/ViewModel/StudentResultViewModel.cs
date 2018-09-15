using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
  [Serializable]
  public class StudentResultViewModel
  {
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string DepartmentName { get; set; }
    public int CourseId { get; set; }
    public string Grade { get; set; }

  }
}