using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models.EntityModel
{
    public class AllocateClassRoom
    {[Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [Required]
        [Display(Name = "Room")]
        public int RoomId { get; set; }
        [Required]
        [Display(Name = "Day")]

        public int DayId { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime From { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]

        public string TimeFrom { get; set; }
        public DateTime To { get; set; }
        public string TimeTo { get; set; }
        public bool IsAcTive { get; set; }

        public virtual Department Department { get; set; }
        public virtual Course Course { get; set; }
        public virtual Room Room { get; set; }
        public virtual Day Day { get; set; }

    }
}