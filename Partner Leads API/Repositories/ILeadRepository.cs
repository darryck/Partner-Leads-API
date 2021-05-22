using Partner_Leads_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Partner_Leads_API.Repositories
{
    public interface ILeadRepository
    {
        List<Lead> GetAllLeads();
        IEnumerable<Lead> GetLeadsByCustomerName(string CustomerName);
        IEnumerable<Lead> GetRepIdFromRepName(string SalesRepName);
        IEnumerable<Lead> GetLeadsByManagerName(string ManagerName);
        IEnumerable<Lead> GetLeadsByAddress(AddressModel addressModel);
        IEnumerable<Lead> GetTwoWeekPeriodDateTime();
        IEnumerable<Lead> GetLastMonthDateTime();
        IEnumerable<SalesRepsLeadStatusCountsModel> GetSalesRepLeadStatusCounts();
        
    }
}
