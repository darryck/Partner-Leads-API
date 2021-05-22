//using Partner_Leads_API.Models;
using Partner_Leads_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Partner_Leads_API.Repositories
{
    public interface ILeadRepository
    {
        bool CheckUser(string apikey);
        List<Lead> GetAllLeads();
        IEnumerable<Lead> GetLeadsByCustomerName(string CustomerName);
        IEnumerable<Lead> GetTwoWeekPeriodDateTime();
        IEnumerable<Lead> GetLastMonthDateTime();
        IEnumerable<Lead> GetRepIdFromRepName(string SalesRepName);
        IEnumerable<Lead> GetLeadsByManagerName(string SalesRepName);
        IEnumerable<Lead> GetLeadsByAddress(AddressModel addressModel);
    }
}
