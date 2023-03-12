using System;
using System.Collections.Generic;

#nullable disable

namespace Library.DataModel
{
    public partial class EducationPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? StudentId { get; set; }
        public DateTime? EDate { get; set; }
        public string Resolve { get; set; }
        public string Status { get; set; }
    }
}
