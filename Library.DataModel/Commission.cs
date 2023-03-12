using System;
using System.Collections.Generic;

#nullable disable

namespace Library.DataModel
{
    public partial class Commission
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public double? Amount { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Status { get; set; }
        public string Content { get; set; }
    }
}
