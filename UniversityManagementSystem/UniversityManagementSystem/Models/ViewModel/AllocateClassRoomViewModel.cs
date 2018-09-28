using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{[Serializable]
    public class AllocateClassRoomViewModel
    {
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [Required]
        [Display(Name = "Room Number")]
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
        public DateTime To { get; set; }

    
    }
}