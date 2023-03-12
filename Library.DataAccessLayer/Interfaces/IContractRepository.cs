using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataAccessLayer
{
    public partial interface IContractRepository
    {
        bool Create(Contract contract);
        bool Update(Contract contract);
        Contract GetByID(int id);
    }
}
