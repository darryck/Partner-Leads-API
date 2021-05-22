
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Partner_Leads_API.Repositories;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Partner_Leads_API.Models;
using Microsoft.AspNetCore.Authorization;
using static Partner_Leads_API.MessageHandlers.ApiKeyMessageHandler;

namespace Partner_Leads_API.Controllers
{
    [ApiKey]
    public class LeadsController : ControllerBase
    {
        private readonly LeadRepository _leadRepository = new();

        [HttpGet("/GetAllLeads")]
        
        public List<Lead> GetAllLeads() => _leadRepository.GetAllLeads();

        [HttpGet("/GetLeadByName/")]
        public IEnumerable<Lead> GetLeadsByCustomerName(string CustomerName) => _leadRepository.GetLeadsByCustomerName(CustomerName);

        [HttpGet("/GetLeadsByAddress")]
        public IEnumerable<Lead> GetLeadsByAddress(AddressModel addressModel) => _leadRepository.GetLeadsByAddress(addressModel);

        [HttpGet("/GetLeadsBySalesRepName/")]
        public IEnumerable<Lead> GetLeadsBySalesRepName(string SalesRepName) => _leadRepository.GetRepIdFromRepName(SalesRepName);
        [HttpGet("/GetLeadsByManagerName/")]
        public IEnumerable<Lead> GetLeadsByManagerName(string ManagerName) => _leadRepository.GetLeadsByManagerName(ManagerName);

        [HttpGet("/GetLeadsTwoWeeksBack/")]
        public IEnumerable<Lead> GetLeadsTwoWeeksBack() => _leadRepository.GetTwoWeekPeriodDateTime();

        [HttpGet("/GetLeadsMonthBack/")]
        public IEnumerable<Lead> GetLeadsMonthBack() => _leadRepository.GetLastMonthDateTime();
    }
}

