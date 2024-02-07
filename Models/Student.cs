using System;
using System.Collections.Generic;

namespace Attendance_Project.Models
{
    public partial class Student
    {
        public Student()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
