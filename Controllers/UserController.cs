using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreWebApiAngular.Models;
using Newtonsoft.Json;


namespace DotNetCoreWebApiAngular.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUser _iUser;

        public UserController(IUser iUser)
        {
            _iUser = iUser;
        }

        [HttpGet]
        public string GetAllUsers()
        {
            List<clsUser> lstUsersList = new List<clsUser>();

            lstUsersList = _iUser.GetUsers();

            string strUserList = JsonConvert.SerializeObject(lstUsersList);

            return strUserList;
        }
    }
}
