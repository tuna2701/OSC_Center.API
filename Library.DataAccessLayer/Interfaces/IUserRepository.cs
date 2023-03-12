using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataAccessLayer
{
    public partial interface IUserRepository
    {
        UserSystemCustom Authentication(string username, string password);
        UserSystem ChangePassword(string username, string password);
    }
}
