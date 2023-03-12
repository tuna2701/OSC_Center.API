using Library.DataAccessLayer;
using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;

namespace Library.BusinessLogicLayer
{
    public class RecordBusiness : IRecordBusiness
    {
        private IRecordRepository _res;

        public RecordBusiness(IRecordRepository res)
        {
            _res = res;
        }
        public bool Update(Record model)
        {
            return _res.Update(model);
        }


        public bool Create(Record model)
        {
            return _res.Create(model);
        }

        public RecordCustom GetByID(int id)
        {
            return _res.GetByID(id);
        }
        //public List<Record> Search(int pageIndex, int pageSize, out long total, string Record_name, string cccd)
        //{
        //    return _res.Search(pageIndex, pageSize, out total, Record_name, cccd);
        //}
    }
}
