using Library.DataAccessLayer;
using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;

namespace Library.BusinessLogicLayer
{
    public class ContractBusiness : IContractBusiness
    {
        private IContractRepository _res;

        public ContractBusiness(IContractRepository res)
        {
            _res = res;
        }

        public bool Create(Contract contract)
        {
            return _res.Create(contract);
        }

        public bool Update(Contract contract)
        {
            return _res.Update(contract);
        }
        public Contract GetByID(int id)
        {
            return _res.GetByID(id);
        }

    }
}
