using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BusinessLogicLayer
{
    public partial interface IUserBusiness
    {
        UserSystemCustom Authentication(string username, string password);
        UserSystem ChangePassword(string username, string password);
    }
}
