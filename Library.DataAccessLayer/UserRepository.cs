using Library.DataModel;
using Library.DataModel.DTO;
using System;
using System.Linq;

namespace Library.DataAccessLayer
{
    public class UserRepository : IUserRepository
    {
        private osc_centerContext _context;

        public UserRepository(osc_centerContext context)
        {
            _context = context;
        }

        public UserSystemCustom Authentication(string username, string password)
        {
            try
            {

                UserSystem _user = _context.UserSystems.Where(u => u.UserName == username && u.Password == password).FirstOrDefault();
                int userID = _context.Students.Where(u => u.UserId == _user.Id).FirstOrDefault().StudentId;
                UserSystemCustom _userCustom = new UserSystemCustom
                {
                    Id = _user.Id,
                    FullName = _user.FullName,
                    UserName = _user.UserName,
                    Password = password,
                    Role = _user.Role,
                    Token = _user.Token,
                    UserID = userID
                };
                return _userCustom;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserSystem ChangePassword(string username, string password)
        {
            try
            {
                UserSystem _user = _context.UserSystems.Where(u => u.UserName == username).FirstOrDefault();
                if (_user == null)
                    return null;
                else
                    _user.UserName = username;
                    _user.Password = password;
                    _context.SaveChanges();
                return _user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
