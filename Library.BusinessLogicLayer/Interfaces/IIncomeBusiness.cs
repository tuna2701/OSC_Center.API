using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BusinessLogicLayer
{
    public partial interface IIncomeBusiness
    {
        bool Create(Income model);
        List<Income> GetByID(int id); 

        List<IncomeCustom> Search(int pageIndex, int pageSize, out long total, int student_id, string payment_type,
            DateTime date_payment, string payment_method);
    }
}
