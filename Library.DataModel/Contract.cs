using System;
using System.Collections.Generic;

#nullable disable

namespace Library.DataModel
{
    public partial class Contract
    {
        public int ContractId { get; set; }
        public int? StudentId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public double? Total { get; set; }
        public double? AmountPaid { get; set; }
        public double? RestPaid { get; set; }
        public string Note { get; set; }
        public string Image { get; set; }
    }
}
