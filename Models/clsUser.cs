using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApiAngular.Models
{
    public class clsUser
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string UserType { get; set; }

    }

    public interface IUser
    {
        List<clsUser> GetUsers();
    }

    public class UserRepository : IUser
    {
        DataLayer.DLUser dLUser = new DataLayer.DLUser();
        public List<clsUser> GetUsers()
        {
            return dLUser.GetUsers();
        }
    }
    //TEST COMMIT FOR GIT TESTING
    //changes to be stashed
}
