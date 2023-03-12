using Library.BusinessLogicLayer;
using Library.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace OSC_Center.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserBusiness _itemBUS;

        public UsersController(IUserBusiness itemBUS)
        {
            _itemBUS = itemBUS;
        }

        [HttpGet]
        public string Test()
        {
            return "OK";
        }

        [Route("authenticate")]
        [HttpPost]
        public IActionResult Authentication([FromBody] AuthenticateModel model)
        {
            MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider();
            byte[] hashedBytes;
            UTF8Encoding encoder = new UTF8Encoding();
            hashedBytes = mD5.ComputeHash(encoder.GetBytes(model.Password));
            var md5_pass = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            var _data = _itemBUS.Authentication(model.Username, md5_pass);
            if (_data == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(_data);
        }

        [Route("change-password")]
        [HttpPost]
        public IActionResult ChangePassowrd([FromBody] AuthenticateModel model)
        {
            MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider();
            byte[] hashedBytes;
            UTF8Encoding encoder = new UTF8Encoding();
            hashedBytes = mD5.ComputeHash(encoder.GetBytes(model.Password));
            var md5_pass = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            var _data = _itemBUS.ChangePassword(model.Username, md5_pass);
            if (_data == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(_data);
        }

    }
}
