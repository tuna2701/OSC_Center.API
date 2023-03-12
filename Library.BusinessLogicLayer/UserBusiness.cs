using Library.DataAccessLayer;
using Library.DataModel;
using Library.DataModel.DTO;
using System;

namespace Library.BusinessLogicLayer
{
    public class UserBusiness : IUserBusiness
    {
        private IUserRepository _res;

        public UserBusiness(IUserRepository res)
        {
            _res = res;
        }

        public UserSystemCustom Authentication(string username, string password)
        {
            return _res.Authentication(username, password);
        }

        public UserSystem ChangePassword(string username, string password)
        {
            return _res.ChangePassword(username, password);
        }
    }
}
