using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository_and_Unit_of_Work_Patterns.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}