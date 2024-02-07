using System;
using System.Collections.Generic;

namespace Attendance_Project.Models
{
    public partial class Attendance
    {
        public int Attendance1 { get; set; }
        public int? StudentId { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public string? Status { get; set; }

        public virtual Student? Student { get; set; }
    }
}
