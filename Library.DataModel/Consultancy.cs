using System;
using System.Collections.Generic;

#nullable disable

namespace Library.DataModel
{
    public partial class Consultancy
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public string Status { get; set; }
        public string Content { get; set; }
        public DateTime? LastContact { get; set; }
        public DateTime? NextContact { get; set; }
    }
}
