using Library.DataAccessLayer;
using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;

namespace Library.BusinessLogicLayer
{
    public class IncomeBusiness : IIncomeBusiness
    {
        private IIncomeRepository _res;

        public IncomeBusiness(IIncomeRepository res)
        {
            _res = res;
        }

        public bool Create(Income model)
        {
            return _res.Create(model);
        }

        public List<Income> GetByID(int id)
        {
            return _res.GetByID(id);
        }

        public List<IncomeCustom> Search(int pageIndex, int pageSize, out long total, int student_id, string payment_type,
            DateTime date_payment, string payment_method)
        {
            return _res.Search(pageIndex, pageSize, out total, student_id, payment_type, date_payment, payment_method);
        }
    }
}
