using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataModel.DTO
{
    public partial class UserSystemCustom
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public int UserID { get; set; }
    }
}
