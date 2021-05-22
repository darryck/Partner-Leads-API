using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Partner_Leads_API.MessageHandlers
{
    public class ApiKeyMessageHandler : DelegatingHandler
    {
        [AttributeUsage(validOn: AttributeTargets.Class)]
        public class ApiKeyAttribute : Attribute, IAsyncActionFilter
        {
            private const string APIKEYNAME = "ApiKey";
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 401,
                        Content = "No Api Key provided"
                    };
                    return;
                }

                var appSettings =
                    context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

                var apiKey = appSettings.GetValue<string>(APIKEYNAME);

                if (!apiKey.Equals(extractedApiKey))
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 401,
                        Content = "Api Key is invalid"
                    };
                    return;
                }

                await next();
            }
        }
    }
}
