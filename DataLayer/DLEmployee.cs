using DotNetCoreWebApiAngular.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApiAngular.DataLayer
{
    public class DLEmployee
    {
        //SqlHelper sqlHelper = null;
        string query = null;

        public List<clsEmployee> GetEmployees()
        {
            List<clsEmployee> lstEmployeesList = new List<clsEmployee>();

            try
            {
                query = "SELECT * FROM tbl_employee";

                using (SqlDataReader rdr = SqlHelper.ExecuteReader("", System.Data.CommandType.Text, query))
                {
                    while(rdr.Read())
                    {
                        clsEmployee employee = new clsEmployee
                        {
                            Id = rdr["Id"].ToString(),
                            FirstName = rdr["FirstName"].ToString(),
                            LastName = rdr["LastName"].ToString(),
                            Email = rdr["Email"].ToString(),
                            Mobile = rdr["Mobile"].ToString(),
                            Salary = rdr["Salary"].ToString()
                        };

                        lstEmployeesList.Add(employee);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return lstEmployeesList;
        }
    }
}
