using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Department
    { [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Code must be contain only letters")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Code must between 2 to 7 leters")]
        public string Code { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name must be contain only letters")]
        public string Name { get; set; }
    }
}