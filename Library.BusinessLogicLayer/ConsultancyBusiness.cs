using Library.DataAccessLayer;
using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;

namespace Library.BusinessLogicLayer
{
    public class ConsultancyBusiness : IConsultancyBusiness
    {
        private IConsultancyRepository _res;

        public ConsultancyBusiness(IConsultancyRepository res)
        {
            _res = res;
        }
        //public bool Update(ConsultancyAddCustom Consultancy)
        //{
        //    return _res.Update(Consultancy);
        //}


        public bool Create(ConsultancyCustom model)
        {
            return _res.Create(model);
        }

        public ConsultancyCustom GetByID(int id)
        {
            return _res.GetByID(id);
        }
        public List<Consultancy> Search(int pageIndex, int pageSize, out long total, int student_id)
        {
            return _res.Search(pageIndex, pageSize, out total, student_id);
        }
    }
}
