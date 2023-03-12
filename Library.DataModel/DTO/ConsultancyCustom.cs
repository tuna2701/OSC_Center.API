using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataModel.DTO
{
    public partial class ConsultancyCustom
    {
        public int ConsultancyId { get; set; }
        public int StudentID { get; set; }
        public string Status { get; set; }
        public string Content { get; set; }
        public string Email { get; set; }
        public DateTime? LastContact { get; set; }
        public DateTime? NextContact { get; set; }
    }
}
