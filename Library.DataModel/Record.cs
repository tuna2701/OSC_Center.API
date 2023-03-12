using System;
using System.Collections.Generic;

#nullable disable

namespace Library.DataModel
{
    public partial class Record
    {
        public int RecordId { get; set; }
        public int? StudentId { get; set; }
        public string Major { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public int? CourseId { get; set; }
        public string Status { get; set; }
        public DateTime? SubmitDate { get; set; }
        public DateTime? RegisterDate { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public DateTime? LastContact { get; set; }
        public DateTime? NextContact { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
    }
}
