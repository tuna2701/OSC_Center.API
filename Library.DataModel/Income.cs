using System;
using System.Collections.Generic;

#nullable disable

namespace Library.DataModel
{
    public partial class Income
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public DateTime? DatePayment { get; set; }
        public string PaymentMethods { get; set; }
        public double? Amount { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
    }
}
