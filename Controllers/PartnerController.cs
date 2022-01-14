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
    public class PartnerController : ControllerBase
    {
        private readonly IPartner _iPartner;

        public PartnerController(IPartner iPartner)
        {
            _iPartner = iPartner;
        }

        [HttpGet]
        public string GetPartners()
        {
            List<clsPartner> lstPartnersList = new List<clsPartner>();

            lstPartnersList = _iPartner.GetPartners();

            string strPartnerList = JsonConvert.SerializeObject(lstPartnersList);

            return strPartnerList;
        }

        [Route("{id}")]
        [HttpGet]
        public string GetSinglePartner(string Id)
        {
            clsPartner employee = new clsPartner();

            employee = _iPartner.GetSinglePartner(Id);


            string strEmployee = "";

            if (employee != null)
            {
                strEmployee = JsonConvert.SerializeObject(employee);
            }
            else
            {
                strEmployee = "Employee Not Found";
            }

            return strEmployee;
        }

        [HttpGet]
        public string GetCountries()
        {
            List<clsCountry> lstCountriesList = new List<clsCountry>();

            lstCountriesList = _iPartner.GetCountries();

            string strCountriesList = JsonConvert.SerializeObject(lstCountriesList);

            return strCountriesList;
        }

        [HttpPost]
        public string AddPartner(clsPartner Partner)
        {
            //clsPartner Partner = (clsPartner)JsonConvert.DeserializeObject(strPartner);
            string result = "";

            bool isSuccess = _iPartner.AddPartner(Partner);

            if (isSuccess)
            {
                result = "Partner saved successfully!!";
            }
            else
            {
                result = "Partner not saved.";
            }

            return result;
        }

        [HttpPost]
        public string DeleteSinglePartner(clsPartner Partner)
        {
            string result = "";

            bool isSuccess = _iPartner.DeleteSinglePartner(Partner.UniqueID);

            if (isSuccess)
            {
                result = "Partner deleted successfully!!";
            }
            else
            {
                result = "Partner not deleted.";
                string test_git;
            }

            return result;
        }
    }
}
