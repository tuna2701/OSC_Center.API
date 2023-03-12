using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataAccessLayer
{
    public partial interface IRecordRepository
    {
        bool Create(Record model);
        bool Update(Record model);
        RecordCustom GetByID(int id);
    }
}
