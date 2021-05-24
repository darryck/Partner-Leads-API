using Partner_Leads_API.Controllers;
using Partner_Leads_API.Models;
using Partner_Leads_API.Repositories;
using System.Collections.Generic;
using Xunit;

namespace LeadsTests
{    
    public class LeadsControllerTests
    {
        private static void Authentication()
        {
            LeadRepository.PartnerCompanyId = 3;
            PartnerLeadsContext.GetConnectionString("Server=24.2.16.24,1433;Database=PartnerLeads;User Id =Partner;Password=PartnerLeadsAPI123;");
        }
        [Fact]
        public void GetLeadsByCustomerName()
        {
            Authentication();
            LeadsController leadsController = new();
            var response = leadsController.GetLeadsByCustomerName("Testing Name");
            Assert.NotNull(response);
        }
        [Fact]
        public void GetLeadByAddress()
        {
            Authentication();
            LeadRepository.PartnerCompanyId = 3;
            AddressModel addressModel = new();
            addressModel.Address = "123 s main st.";
            addressModel.City = "Kansas City";
            addressModel.State = "MO";
            addressModel.Zip = "64116";
            LeadsController leadsController = new();
            var response = leadsController.GetLeadsByAddress(addressModel);
            Assert.NotNull(response);
        }
        [Fact]
        public void GetLeadsBySalesRepName()
        {
            Authentication();
            PartnerLeadsContext.GetConnectionString("Server=24.2.16.24,1433;Database=PartnerLeads;User Id =Partner;Password=PartnerLeadsAPI123;");
            LeadsController leadsController = new();
            var response = leadsController.GetLeadsBySalesRepName("Rep Name");
            Assert.NotNull(response);
        }
        [Fact]
        public void GetLeadsMonthBack()
        {
            Authentication();
            LeadsController leadsController = new();
            var response = leadsController.GetLeadsMonthBack();
            Assert.NotNull(response);
        }
        [Fact]
        public void GetLeadsByManagerName()
        {
            Authentication();
            LeadsController leadsController = new();
            var response = leadsController.GetLeadsByManagerName("Peter Parker");
            Assert.NotNull(response);
        }
        [Fact]
        public void GetAllReps()
        {
            Authentication();
            LeadsController leadsController = new();
            List<AllReps> response = (List<AllReps>)leadsController.GetAllReps();
            if (response.Count == 0) response = null;
            Assert.NotNull(response);
        }
        [Fact]
        public void GetLeadsTwoWeeksBack()
        {
            Authentication();
            LeadsController leadsController = new();
            var response = leadsController.GetLeadsTwoWeeksBack();
            Assert.NotNull(response);
        }
        [Fact]
        public void GetSalesRepLeadStatusCounts()
        {
            Authentication();
            LeadsController leadsController = new();
            var response = leadsController.GetSalesRepLeadStatusCounts();
            Assert.NotNull(response);
        }
        [Fact]
        public void GetAllLeads()
        {
            Authentication();
            LeadsController leadsController = new();
            var response = leadsController.GetAllLeads();
            if (response.Count == 0) response = null;
            Assert.NotNull(response);
        }
    }
}
