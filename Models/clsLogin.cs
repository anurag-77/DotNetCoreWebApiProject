using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApiAngular.Models
{
    public class clsLogin
    {
    }

    public interface ILogin
    {

    }

    public class LoginReposiroty : ILogin
    {

    }

    public enum Status
    {
        Deactive,
        Active
    }
}
