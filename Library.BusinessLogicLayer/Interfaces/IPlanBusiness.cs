using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BusinessLogicLayer
{
    public partial interface IPlanBusiness
    {
        bool Create(EducationPlan plan);
        bool Update(EducationPlan plan);
        EducationPlan GetByID(int id);

        bool Complete(int id, string status);
        List<EducationPlanCustom> Search(int pageIndex, int pageSize, out long total, int student_id, string status);
    }
}
