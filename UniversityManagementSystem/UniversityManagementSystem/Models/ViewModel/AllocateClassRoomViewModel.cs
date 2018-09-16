using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{[Serializable]
    public class AllocateClassRoomViewModel
    {
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public int RoomId { get; set; }

        public int DayId { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime From { get; set; }

    public string TimeFrom { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime To { get; set; }

    public string TimeTo { get; set; }
    }
}