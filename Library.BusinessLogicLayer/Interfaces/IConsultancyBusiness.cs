using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BusinessLogicLayer
{
    public partial interface IConsultancyBusiness
    {
        bool Create(ConsultancyCustom model);
        //bool Update(StudentAddCustom student);

        ConsultancyCustom GetByID(int id);
        List<Consultancy> Search(int pageIndex, int pageSize, out long total, int student_id);
    }
}
