using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreWebApiAngular.Models;

namespace DotNetCoreWebApiAngular.DataLayer
{
    public class DLUser
    {
        //SqlHelper sqlHelper = null;
        string query = null;

        public List<clsUser> GetUsers()
        {
            List<clsUser> lstUsersList = new List<clsUser>();

            try
            {
                query = "SELECT * FROM tbl_user";

                using (SqlDataReader rdr = SqlHelper.ExecuteReader("", System.Data.CommandType.Text, query))
                {
                    while (rdr.Read())
                    {
                        clsUser user = new clsUser
                        {
                            Id = rdr["Id"].ToString(),
                            FullName = rdr["FullName"].ToString(),
                            UserName = rdr["UserName"].ToString(),
                            Password = rdr["Password"].ToString(),
                            Mobile = rdr["Mobile"].ToString(),
                            UserType = rdr["UserType"].ToString()
                        };

                        lstUsersList.Add(user);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return lstUsersList;
        }
    }
}