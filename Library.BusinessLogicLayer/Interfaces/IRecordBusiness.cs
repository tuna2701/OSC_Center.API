using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BusinessLogicLayer
{
    public partial interface IRecordBusiness
    {
        bool Create(Record model);
        bool Update(Record model);

        RecordCustom GetByID(int id);
        //List<Student> Search(int pageIndex, int pageSize, out long total, string student_name, string cccd);
    }
}
