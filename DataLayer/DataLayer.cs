using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApiAngular.DataLayer
{
    public class DataLayer
    {
        string query = null;

        public DateTime getEpochtoDateTime(int epoch)
        {
            try
            {
                //query = "SELECT DATEADD(mi, DATEDIFF(mi, GETUTCDATE(), GETDATE()), dateadd( second, " + epoch + ", CAST( '1970-01-01' as datetime )));";
                query = "SELECT dbo.GetEpochToDateTime(" + epoch + ")";

                return Convert.ToDateTime(SqlHelper.ExecuteScalar("", CommandType.Text, query));
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
