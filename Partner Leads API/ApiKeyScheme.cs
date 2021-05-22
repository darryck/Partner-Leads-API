﻿using Microsoft.OpenApi.Models;

namespace Partner_Leads_API
{
    internal class ApiKeyScheme : OpenApiSecurityScheme
    {
        public string In { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}