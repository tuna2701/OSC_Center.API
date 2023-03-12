using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataModel.DTO
{
    public partial class CourseCustom
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public double? Price { get; set; }
        public int? NumberOfSession { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string DayToStudy { get; set; }
        public DateTime? OpeningDay { get; set; }

        public bool? IsRegisted { get; set; }

        public int StudentID { get; set; }
        public int? ActiveFlag { get; set; }
    }
}
