﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Teacher
    {    [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        public string ContactNo { get; set; }

        public int DesignationId { get; set; }

        public int DepartmentId { get; set; }
       
        public double CreditToBeTaken { get; set; }

    }
}