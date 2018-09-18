﻿using System;
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
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Code must between 2 to 7 leters")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
    }
}