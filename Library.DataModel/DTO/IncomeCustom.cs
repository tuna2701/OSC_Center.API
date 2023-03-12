using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataModel.DTO
{
    public partial class IncomeCustom
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime? DatePayment { get; set; }
        public string PaymentMethods { get; set; }
        public double? Amount { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
    }
}
