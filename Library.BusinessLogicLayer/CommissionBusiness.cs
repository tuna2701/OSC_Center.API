using Library.DataAccessLayer;
using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;

namespace Library.BusinessLogicLayer
{
    public class CommissionBusiness : ICommissionBusiness
    {
        private ICommissionRepository _res;

        public CommissionBusiness(ICommissionRepository res)
        {
            _res = res;
        }
  
        public bool Payment(Commission model)
        {
            return _res.Payment(model);
        }
        public List<Commission> Search(int pageIndex, int pageSize, out long total, int student_id)
        {
            return _res.Search(pageIndex, pageSize, out total, student_id);
        }
    }
}
