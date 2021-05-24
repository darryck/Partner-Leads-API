using Partner_Leads_API.Models;
using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace Partner_Leads_API.Repositories
{
    public class LeadRepository: ILeadRepository
    {
        internal static void PartnerId(int partnerId)
        {
            PartnerCompanyId = partnerId;
        }
        public static int PartnerCompanyId { get; set; }
        public IEnumerable<Lead> GetLeadsByCustomerName(string CustomerName)
        {
            using var context = new PartnerLeadsContext();
            return context.Leads.Where(l => l.PartnerCompanyId == PartnerCompanyId && l.CustomerFullName == CustomerName).ToList();
        }
        public IEnumerable<Lead> GetLeadsByAddress(AddressModel addressModel)
        {
            using var context = new PartnerLeadsContext();
            return context.Leads.Where(l => l.PartnerCompanyId == PartnerCompanyId && l.Address == addressModel.Address && l.City == addressModel.City && l.State == addressModel.State && l.Zip == addressModel.Zip).ToList();
        }
        public IEnumerable<Lead> GetRepIdFromRepName(string SalesRepName)
        {
            using var context = new PartnerLeadsContext();
            int SalesRepId = context.SalesReps.Where(sr => sr.RepFullName == SalesRepName).Select(sr => sr.SalesRepId).FirstOrDefault();
            if (SalesRepId == 0) return null;
            return context.Leads.Where(l => l.PartnerCompanyId == PartnerCompanyId && l.SalesRepId == SalesRepId);
        }
        public IEnumerable<Lead> GetLastMonthDateTime()
        {
            DateTime today = DateTime.Today;
            DateTime monthAgo = DateTime.Today.AddMonths(-1);
            using var context = new PartnerLeadsContext();
            return context.Leads.Where(l => l.PartnerCompanyId == PartnerCompanyId && l.InstallDate <= today && l.InstallDate >= monthAgo).ToList();

        }
        public IEnumerable<Lead> GetLeadsByManagerName(string ManagerName)
        {
            using var context = new PartnerLeadsContext();
            int ManagerId = context.Managers.Where(m => m.ManagerFullName == ManagerName).Select(m => m.ManagerId).FirstOrDefault();
            if (ManagerId == 0) return null;
            List<int> SalesRepIds = context.SalesReps.Where(sr => sr.ManagerId == ManagerId).Select(sr => sr.SalesRepId).ToList();
            return context.Leads.Where(l => l.PartnerCompanyId == PartnerCompanyId && SalesRepIds.Contains(l.SalesRepId)).ToList(); ;
        }
        public IEnumerable<AllReps> GetAllReps()
        {
            using var context = new PartnerLeadsContext();
            IEnumerable<SalesRep> salesReps = context.Leads.Where(l => l.PartnerCompanyId == PartnerCompanyId).Select(l => l.SalesRep).ToList();
            List<AllReps> returnedReps = new();
            foreach(var sr in salesReps)
            {
                AllReps salesRep = new();
                salesRep.SalesRepId = sr.SalesRepId;
                salesRep.SalesRepName = sr.RepFullName;
                returnedReps.Add(salesRep);
            }
            return returnedReps;
        }
        public IEnumerable<Lead> GetTwoWeekPeriodDateTime()
        {
            DateTime today = DateTime.Now.Date;
            DateTime twoWeeksAgo = DateTime.Today.AddDays(-14);
            using var context = new PartnerLeadsContext();
            return context.Leads.Where(l => l.PartnerCompanyId == PartnerCompanyId && l.InstallDate <= today && l.InstallDate >= twoWeeksAgo).ToList();
        }
        public IEnumerable<SalesRepsLeadStatusCountsModel> GetSalesRepLeadStatusCounts()
        {
            using var context = new PartnerLeadsContext();
            List<SalesRepsLeadStatusCountsModel> response = new();
            var salesRepIds = context.Leads.Where(l => l.PartnerCompanyId == PartnerCompanyId).Select(l => l.SalesRepId).ToList();
            foreach(var salesRepId in salesRepIds)
            {              
                var repName = context.SalesReps.Where(sr => sr.SalesRepId == salesRepId).Select(sr => sr.RepFullName).ToList();
                SalesRepsLeadStatusCountsModel salesRep = new();
                salesRep.SalesRepId = salesRepId;
                salesRep.SalesRepName = repName[0];
                salesRep.CountOfCancelled = context.Leads.Where(l => l.SalesRepId == salesRepId && l.LeadStatus == "Cancelled").Count();
                salesRep.CountOfInstalled = context.Leads.Where(l => l.SalesRepId == salesRepId && l.LeadStatus == "Installed").Count();
                salesRep.CountOfTroubled = context.Leads.Where(l => l.SalesRepId == salesRepId && l.LeadStatus == "Troubled").Count();
                response.Add(salesRep);
            }
            return response;
        }
        public List<Lead> GetAllLeads()
        {
            using var context = new PartnerLeadsContext();
            return context.Leads.Where(l => l.PartnerCompanyId == PartnerCompanyId).ToList();
        }
    }
}
