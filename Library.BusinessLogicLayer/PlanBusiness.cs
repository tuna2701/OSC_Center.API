using Library.DataAccessLayer;
using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;

namespace Library.BusinessLogicLayer
{
    public class PlanBusiness : IPlanBusiness
    {
        private IPlanRepository _res;

        public PlanBusiness(IPlanRepository res)
        {
            _res = res;
        }

        public bool Create(EducationPlan model)
        {
            return _res.Create(model);
        }

        public bool Update(EducationPlan model)
        {
            return _res.Update(model);
        }
        public EducationPlan GetByID(int id)
        {
            return _res.GetByID(id);
        }

        public bool Complete(int id, string status)
        {
            return _res.Complete(id, status);
        }

        public List<EducationPlanCustom> Search(int pageIndex, int pageSize, out long total, int student_id, string status)
        {
            return _res.Search(pageIndex, pageSize, out total, student_id, status); 
        }

    }
}
