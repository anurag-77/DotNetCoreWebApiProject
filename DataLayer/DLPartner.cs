using DotNetCoreWebApiAngular.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebApiAngular.DataLayer
{
    public class DLPartner
    {
        //SqlHelper sqlHelper = null;
        string query = null;
        DataLayer DL = new DataLayer();

        public List<clsPartner> GetPartners()
        {
            List<clsPartner> lstPartnersList = new List<clsPartner>();

            try
            {
                query = "SELECT * FROM tblPartnerMaster";

                using (SqlDataReader rdr = SqlHelper.ExecuteReader("", System.Data.CommandType.Text, query))
                {
                    while (rdr.Read())
                    {
                        clsPartner partner = new clsPartner
                        {
                            UniqueID = Convert.ToString(rdr["Partner_ID"]),
                            partnerName = Convert.ToString(rdr["partnerName"]),
                            country = Convert.ToString(rdr["country"]),
                            address = Convert.ToString(rdr["address"]),
                            phoneno = Convert.ToString(rdr["phoneno"]),
                            website = Convert.ToString(rdr["website"]),
                            createdDate = DL.getEpochtoDateTime(Convert.ToInt32(rdr["CreatedDate"].ToString())).ToString(),
                            isActive = Convert.ToBoolean(rdr["isActive"]) == true ? Status.Active : Status.Deactive,
                        };

                        lstPartnersList.Add(partner);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return lstPartnersList;
        }

        public clsPartner GetSinglePartner(string Id)
        {
            clsPartner partner = null;

            try
            {
                query = $"SELECT * FROM tblPartnerMaster WHERE Partner_ID = '{Id}'";

                using (SqlDataReader rdr = SqlHelper.ExecuteReader("", System.Data.CommandType.Text, query))
                {
                    while (rdr.Read())
                    {
                        partner = new clsPartner
                        {
                            UniqueID = Convert.ToString(rdr["Partner_ID"]),
                            partnerName = Convert.ToString(rdr["partnerName"]),
                            country = Convert.ToString(rdr["country"]),
                            countryId = Convert.ToString(rdr["countryId"]),
                            address = Convert.ToString(rdr["address"]),
                            phoneno = Convert.ToString(rdr["phoneno"]),
                            website = Convert.ToString(rdr["website"]),
                            createdDate = DL.getEpochtoDateTime(Convert.ToInt32(rdr["CreatedDate"].ToString())).ToString(),
                            isActive = Convert.ToBoolean(rdr["isActive"]) == true ? Status.Active : Status.Deactive,
                            //contactPersonDetails = DL.getContactPersonDetails(id, "Partner")
                        };

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return partner;
        }

        public List<clsCountry> GetCountries()
        {
            List<clsCountry> lstCountriesList = new List<clsCountry>();

            try
            {
                query = "SELECT * FROM Country";

                using (SqlDataReader rdr = SqlHelper.ExecuteReader("", System.Data.CommandType.Text, query))
                {
                    while (rdr.Read())
                    {
                        clsCountry country = new clsCountry
                        {
                            CountryId = Convert.ToString(rdr["CountryId"]),
                            CountryName = Convert.ToString(rdr["CountryName"]),
                        };

                        lstCountriesList.Add(country);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return lstCountriesList;
        }

        public bool AddPartner(clsPartner Partner)
        {
            bool isSuccess = false;

            try
            {
                StringBuilder sb = new StringBuilder();
                string PartnerId = string.IsNullOrEmpty(Partner.UniqueID) ? Convert.ToString(Guid.NewGuid()) : Partner.UniqueID;

                SqlParameter[] _param = {
                    new SqlParameter("@Partner_ID",PartnerId),
                    new SqlParameter("@partnerName",Partner.partnerName),
                    new SqlParameter("@country",Partner.country),
                    new SqlParameter("@countryId",Partner.countryId),
                    new SqlParameter("@address",Partner.address),
                    new SqlParameter("@phoneno",Partner.phoneno),
                    new SqlParameter("@website",Partner.website),
                    //new SqlParameter("@isActive",Partner.isActive==Status.Active?"true":"false"),
                    new SqlParameter("@CreatedBy",Partner.createdBy)
                };

                string insQuery = "INSERT INTO [dbo].[tblPartnerMaster]" + Environment.NewLine +
                                    "           ([Partner_ID]" + Environment.NewLine +
                                    "           ,[partnerName]" + Environment.NewLine +
                                    "           ,[country]" + Environment.NewLine +
                                    "           ,[countryId]" + Environment.NewLine +
                                    "           ,[address]" + Environment.NewLine +
                                    "           ,[phoneno]" + Environment.NewLine +
                                    "           ,[isActive]" + Environment.NewLine +
                                    "           ,[CreatedDate]" + Environment.NewLine +
                                    "           ,[website])" + Environment.NewLine +
                                    "     VALUES" + Environment.NewLine +
                                    "           (@Partner_ID" + Environment.NewLine +
                                    "           ,@partnerName" + Environment.NewLine +
                                    "           ,@country" + Environment.NewLine +
                                    "           ,@countryId" + Environment.NewLine +
                                    "           ,@address" + Environment.NewLine +
                                    "           ,@phoneno" + Environment.NewLine +
                                    "           ,1" + Environment.NewLine +
                                    "           ,DATEDIFF(S, '1970-01-01', GETUTCDATE())" + Environment.NewLine +
                                    "           ,@website)";


                string upQuery = " UPDATE [tblPartnerMaster] " + Environment.NewLine +
                                " SET    [partnerName] = @partnerName, " + Environment.NewLine +
                                "       [country] = @country, " + Environment.NewLine +
                                "       [countryId] = @countryId, " + Environment.NewLine +
                                "       [address] = @address, " + Environment.NewLine +
                                "       [website] = @website, " + Environment.NewLine +
                                "       [phoneno] = @phoneno " + Environment.NewLine +
                                " WHERE  [Partner_ID] = @Partner_ID";

                sb.Append(" If not exists(select * from tblPartnerMaster where [Partner_ID] = @Partner_ID) ");
                sb.Append(" Begin ");
                sb.Append(insQuery);
                sb.Append(" End ");
                sb.Append(" Else Begin ");
                sb.Append(upQuery);
                sb.Append(" End ");

                int resultSet = SqlHelper.ExecuteNonQuery("", CommandType.Text, sb.ToString(), _param);

                if (resultSet > 0)
                {
                    isSuccess = true;
                }

                return isSuccess;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool DeleteSinglePartner(string Id)
        {
            try
            {
                query = $"DELETE FROM tblPartnerMaster WHERE Partner_ID = '{Id}'";

                int result = SqlHelper.ExecuteNonQuery("", CommandType.Text, query);

                if (result != 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                //throw ex;
                return false;
            }
        }
    }
}
