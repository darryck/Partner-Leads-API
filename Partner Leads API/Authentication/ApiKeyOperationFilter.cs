using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Partner_Leads_API.Authentication
{
    internal class ApiKeyOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Piggy back off of SecurityRequirementsOperationFilter from Swashbuckle.AspNetCore.Filters which has oauth2 as the default security scheme.
            var filter = new SecurityRequirementsOperationFilter(securitySchemaName: ApiKeyAuthenticationOptions.DefaultScheme);
            filter.Apply(operation, context);
        }
    }
}
