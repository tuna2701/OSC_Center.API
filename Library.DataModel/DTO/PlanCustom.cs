using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataModel.DTO
{
    public partial class EducationPlanCustom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime? EDate { get; set; }
        public string Resolve { get; set; }
        public string Status { get; set; }
    }
}
