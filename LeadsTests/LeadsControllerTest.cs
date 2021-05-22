using Partner_Leads_API;
using Partner_Leads_API.Controllers;
using Partner_Leads_API.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace LeadsTests
{
    public class LeadsControllerTests
    {
        
        [Fact]
        public void GetAllLeads()
        {
            LeadsController leadsController = new();
            var response = leadsController.GetAllLeads();
            Assert.NotNull(response);
        }
        [Fact]
        public void GetLeadsByCustomerName()
        {
            LeadsController leadsController = new();
            var response = leadsController.GetLeadsByCustomerName("Testing Name");
            Assert.NotNull(response);
        }
        [Fact]
        public void GetLeadByAddress()
        {
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
            LeadsController leadsController = new();
            var response = leadsController.GetLeadsBySalesRepName("Rep Name");
            Assert.NotNull(response);
        }
        [Fact]
        public void GetLeadsByManagerName()
        {
            LeadsController leadsController = new();
            var response = leadsController.GetLeadsByManagerName("Peter Parker");
            Assert.NotNull(response);
        }
        [Fact]
        public void GetLeadsTwoWeeksBack()
        {
            LeadsController leadsController = new();
            var response = leadsController.GetLeadsTwoWeeksBack();
            Assert.NotNull(response);
        }
        [Fact]
        public void GetLeadsMonthBack()
        {
            LeadsController leadsController = new();
            var response = leadsController.GetLeadsMonthBack();
            Assert.NotNull(response);
        }

    }
}
