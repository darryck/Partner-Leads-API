using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Partner_Leads_API.Models;
using Partner_Leads_API.Repositories;

namespace Partner_Leads_API.MessageHandlers
{
    public class ApiKeyMessageHandler : DelegatingHandler
    {

        [AttributeUsage(validOn: AttributeTargets.Class)]
        public class ApiKeyAttribute : Attribute, IAsyncActionFilter
        {
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if (!context.HttpContext.Request.Headers.TryGetValue("ApiKey", out var extractedApiKey))
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 401,
                        Content = "No Api Key provided"
                    };
                    return;
                }
                using var DbContext = new PartnerLeadsContext();
                var partnerComapnyId = DbContext.PartnerCompanies.Where(l => l.ApiKey == extractedApiKey.ToString()).Select(pc => pc.PartnerCompanyId).ToList();
                if (partnerComapnyId.Count == 0)
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 401,
                        Content = "ApiKey is invalid"
                    };
                    return;
                }
                int cleanedpartnerComapnyId = partnerComapnyId[0];
                LeadRepository.PartnerId(cleanedpartnerComapnyId);
                await next();
            }
        }
    }
}