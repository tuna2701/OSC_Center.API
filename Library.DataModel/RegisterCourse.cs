using System;
using System.Collections.Generic;

#nullable disable

namespace Library.DataModel
{
    public partial class RegisterCourse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime RegisterDay { get; set; }
    }
}
