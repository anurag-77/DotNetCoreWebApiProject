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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _iEmployee;

        public EmployeeController(IEmployee iEmployee)
        {
            _iEmployee = iEmployee;
        }
        
        [HttpGet]
        public string GetAllEmployees()
        {
            List<clsEmployee> lstEmployeesList = new List<clsEmployee>();

            lstEmployeesList = _iEmployee.GetEmployees();

            string strEmployeeList = JsonConvert.SerializeObject(lstEmployeesList);

            return strEmployeeList;
        }
    }
}
