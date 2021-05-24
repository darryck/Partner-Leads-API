using Partner_Leads_API.Models;
using System.Collections.Generic;

namespace Partner_Leads_API.Repositories
{
    public interface ILeadRepository
    {
        
        IEnumerable<Lead> GetLeadsByAddress(AddressModel addressModel);
        IEnumerable<Lead> GetLeadsByCustomerName(string CustomerName);
        IEnumerable<Lead> GetRepIdFromRepName(string SalesRepName);
        IEnumerable<Lead> GetLastMonthDateTime();
        IEnumerable<Lead> GetLeadsByManagerName(string ManagerName);
        IEnumerable<AllReps> GetAllReps();
        IEnumerable<Lead> GetTwoWeekPeriodDateTime();
        IEnumerable<SalesRepsLeadStatusCountsModel> GetSalesRepLeadStatusCounts();        
        List<Lead> GetAllLeads();
    }
}
