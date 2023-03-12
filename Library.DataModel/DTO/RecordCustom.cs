using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataModel.DTO
{
    public partial class RecordCustom
    {
        public int RecordId { get; set; }
        public int StudentID { get; set; }
        public string Major { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public int? CourseId { get; set; }
        public string CourseName { get; set; }
        public List<Course> LstCourse { get; set; }
        public string Status { get; set; }
        public string EmailP { get; set; }
        public string EmailF { get; set; }
        public DateTime? SubmitDate { get; set; }
        public DateTime? RegisterDate { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public DateTime? LastContact { get; set; }
        public DateTime? NextContact { get; set; }
    }
}
