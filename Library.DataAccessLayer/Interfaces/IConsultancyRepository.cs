using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataAccessLayer
{
    public partial interface IConsultancyRepository
    {
        bool Create(ConsultancyCustom model);
        ConsultancyCustom GetByID(int id);

        List<Consultancy> Search(int pageIndex, int pageSize, out long total, int student_id);
    }
}
