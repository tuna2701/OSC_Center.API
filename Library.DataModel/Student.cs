using System;
using System.Collections.Generic;

#nullable disable

namespace Library.DataModel
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime? StudentDob { get; set; }
        public string StudentPhone { get; set; }
        public string StudentAddress { get; set; }
        public string StudentSource { get; set; }
        public string StudentCccd { get; set; }
        public string StudentNote { get; set; }
        public int? ActiveFlag { get; set; }
        public Guid? UserId { get; set; }
    }
}
