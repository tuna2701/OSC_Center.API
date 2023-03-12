using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BusinessLogicLayer
{
    public partial interface IContractBusiness
    {
        bool Create(Contract contract);
        bool Update(Contract contract);
        Contract GetByID(int id);
    }
}
