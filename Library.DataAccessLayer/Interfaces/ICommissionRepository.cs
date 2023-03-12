using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataAccessLayer
{
    public partial interface ICommissionRepository
    {
        bool Payment(Commission model);
        List<Commission> Search(int pageIndex, int pageSize, out long total, int student_id);
    }
}
