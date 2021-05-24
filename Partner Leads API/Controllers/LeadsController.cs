using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Partner_Leads_API.Repositories;
using Partner_Leads_API.Models;
using static Partner_Leads_API.MessageHandlers.ApiKeyMessageHandler;

namespace Partner_Leads_API.Controllers
{
    [ApiKey]
    public class LeadsController : ControllerBase
    {
        private readonly LeadRepository _leadRepository = new();

        [HttpGet("/GetLeadsByAddress")]
        public IEnumerable<Lead> GetLeadsByAddress(AddressModel addressModel) => _leadRepository.GetLeadsByAddress(addressModel);

        [HttpGet("/GetLeadByCustomerName/")]
        public IEnumerable<Lead> GetLeadsByCustomerName(string CustomerName) => _leadRepository.GetLeadsByCustomerName(CustomerName);

        [HttpGet("/GetLeadsBySalesRepName/")]
        public IEnumerable<Lead> GetLeadsBySalesRepName(string SalesRepName) => _leadRepository.GetRepIdFromRepName(SalesRepName);

        [HttpGet("/GetLeadsMonthBack/")]
        public IEnumerable<Lead> GetLeadsMonthBack() => _leadRepository.GetLastMonthDateTime();

        [HttpGet("/GetLeadsByManagerName/")]
        public IEnumerable<Lead> GetLeadsByManagerName(string ManagerName) => _leadRepository.GetLeadsByManagerName(ManagerName);

        [HttpGet("/GetAllReps/")]
        public IEnumerable<AllReps> GetAllReps() => _leadRepository.GetAllReps();

        [HttpGet("/GetLeadsTwoWeeksBack/")]
        public IEnumerable<Lead> GetLeadsTwoWeeksBack() => _leadRepository.GetTwoWeekPeriodDateTime();

        [HttpGet("/GetSalesRepLeadStatusCounts/")]
        public IEnumerable<SalesRepsLeadStatusCountsModel> GetSalesRepLeadStatusCounts() => _leadRepository.GetSalesRepLeadStatusCounts();

        [HttpGet("/GetAllLeads")]
        public List<Lead> GetAllLeads() => _leadRepository.GetAllLeads();
    }
}

