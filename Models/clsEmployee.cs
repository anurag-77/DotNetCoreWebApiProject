using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApiAngular.Models
{
    public class clsEmployee
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Salary { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }


    public interface IEmployee
    {
        List<clsEmployee> GetEmployees();
    }

    public class EmployeeRepository : IEmployee
    {
        DataLayer.DLEmployee dLEmployee = new DataLayer.DLEmployee();
        public List<clsEmployee> GetEmployees()
        {
            return dLEmployee.GetEmployees();
        }
    }
}
