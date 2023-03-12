using System;
using System.Collections.Generic;

#nullable disable

namespace Library.DataModel
{
    public partial class Wish
    {
        public int WishId { get; set; }
        public int? StudentId { get; set; }
        public string MajorTo { get; set; }
        public string SchoolTo { get; set; }
        public string AddressTo { get; set; }
        public string Level { get; set; }
    }
}
