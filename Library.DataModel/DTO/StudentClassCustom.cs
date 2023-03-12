using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataModel.DTO
{
    public partial class StudentClassCustom
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public DateTime? StudentDoB { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string TeacherName { get; set; }
    }
}
