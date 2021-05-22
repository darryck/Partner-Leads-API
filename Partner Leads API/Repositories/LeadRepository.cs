using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Partner_Leads_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Partner_Leads_API.Repositories
{

    public class LeadRepository: ILeadRepository
    {

        public List<Lead> GetAllLeads()
        {
            using var context = new PartnerLeadsContext();
            return context.Leads.ToList();
        }
        public IEnumerable<Lead> GetLeadsByCustomerName(string CustomerName)
        {
            using var context = new PartnerLeadsContext();
            return context.Leads.Where(l => l.CustomerFullName == CustomerName).ToList();
        }
        public IEnumerable<Lead> GetLeadsByAddress(AddressModel addressModel)
        {
            using var context = new PartnerLeadsContext();
            return context.Leads.Where(l => l.Address == addressModel.Address && l.City == addressModel.City && l.State == addressModel.State && l.Zip == addressModel.Zip).ToList();
        }
        public IEnumerable<Lead> GetRepIdFromRepName(string SalesRepName)
        {
            using var context = new PartnerLeadsContext();
            int SalesRepId = context.SalesReps.Where(sr => sr.RepFullName == SalesRepName).Select(sr => sr.SalesRepId).FirstOrDefault();
            if (SalesRepId == 0) return null;
            return context.Leads.Where(l => l.SalesRepId == SalesRepId);
        }
        public IEnumerable<Lead> GetLeadsByManagerName(string ManagerName)
        {
            using var context = new PartnerLeadsContext();
            int ManagerId = context.Managers.Where(m => m.ManagerFullName == ManagerName).Select(m => m.ManagerId).FirstOrDefault();
            if (ManagerId == 0) return null;
            List<int> SalesRepIds = context.SalesReps.Where(sr => sr.ManagerId == ManagerId).Select(sr => sr.SalesRepId).ToList();
            IEnumerable<Lead> response = null;
            foreach(int SalesRepId in SalesRepIds)
            {
                IEnumerable<Lead> leads = context.Leads.Where(l => l.SalesRepId == SalesRepId);
                //response.Add(leads);

            }
            return response;
        }
        public IEnumerable<Lead> GetTwoWeekPeriodDateTime()
        {
            DateTime today = DateTime.Now.Date;
            DateTime twoWeeksAgo = DateTime.Today.AddDays(-14);
            using var context = new PartnerLeadsContext();
            return context.Leads.Where(l => l.InstallDate >= today && l.InstallDate <= twoWeeksAgo);
        }
        public IEnumerable<Lead> GetLastMonthDateTime()
        {
            DateTime today = DateTime.Today;
            DateTime monthAgo = DateTime.Today.AddMonths(-1);
            using var context = new PartnerLeadsContext();
            return context.Leads.Where(l => l.InstallDate >= today && l.InstallDate >= monthAgo);

        }




        public bool CheckUser(string apikey)
        {
            throw new NotImplementedException();
        }
    }
}
