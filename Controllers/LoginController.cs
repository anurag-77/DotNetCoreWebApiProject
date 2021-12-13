using DotNetCoreWebApiAngular.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApiAngular.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly ILogin _iLogin;

        public LoginController(ILogin iLogin)
        {
            _iLogin = iLogin;
        }
    }
}
