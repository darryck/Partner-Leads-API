using Partner_Leads_API.Models;
using System.Collections.Generic;

namespace Partner_Leads_API.Repositories
{
    public interface ILeadRepository
    {
        List<Lead> GetAllLeads();
        IEnumerable<Lead> GetLeadsByCustomerName(string CustomerName);
        IEnumerable<Lead> GetLeadsByAddress(AddressModel addressModel);
        IEnumerable<Lead> GetRepIdFromRepName(string SalesRepName);
        IEnumerable<Lead> GetLeadsByManagerName(string ManagerName);
        IEnumerable<SalesRepsLeadStatusCountsModel> GetSalesRepLeadStatusCounts();
        IEnumerable<Lead> GetTwoWeekPeriodDateTime();
        IEnumerable<Lead> GetLastMonthDateTime();
    }
}
