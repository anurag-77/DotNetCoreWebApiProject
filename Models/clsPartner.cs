using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApiAngular.Models
{
    public class clsPartner
    {
        public string UniqueID { get; set; }
        public string partnerName { get; set; }
        public string country { get; set; }
        public string countryId { get; set; }
        public string address { get; set; }
        public string phoneno { get; set; }
        public string conPerson { get; set; }
        public string conPersonEmail { get; set; }
        public string conPersonPhone { get; set; }
        public string website { get; set; }
        public string createdBy { get; set; }
        public string createdDate { get; set; }
        public Status isActive { get; set; }
    }

    public class clsCountry
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }
    }

    public interface IPartner
    {
        List<clsPartner> GetPartners();

        clsPartner GetSinglePartner(string Id);

        List<clsCountry> GetCountries();

        bool AddPartner(clsPartner Partner);

        bool DeleteSinglePartner(string Id);
    }

    public class PartnerRepository : IPartner
    {
        DataLayer.DLPartner dLPartner = new DataLayer.DLPartner();
        public List<clsPartner> GetPartners()
        {
            return dLPartner.GetPartners();
        }

        public clsPartner GetSinglePartner(string Id)
        {
            return dLPartner.GetSinglePartner(Id);
        }

        public List<clsCountry> GetCountries()
        {
            return dLPartner.GetCountries();
        }

        public bool AddPartner(clsPartner Partner)
        {
            return dLPartner.AddPartner(Partner);
        }

        public bool DeleteSinglePartner(string Id)
        {
            return dLPartner.DeleteSinglePartner(Id);
        }
    }
}
