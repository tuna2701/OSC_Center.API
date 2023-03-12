using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataModel.DTO
{
    public partial class StudentAddCustom
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime? StudentDob { get; set; }
        public string StudentPhone { get; set; }
        public string StudentAddress { get; set; }
        public string StudentSource { get; set; }
        public string StudentCccd { get; set; }
        public string StudentNote { get; set; }
        public int? ActiveFlag { get; set; }
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
