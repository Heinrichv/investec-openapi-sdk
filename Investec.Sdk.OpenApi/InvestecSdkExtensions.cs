using System;
using System.Collections.Generic;
using System.Text;
using Investec.Sdk.OpenApi.Clients;
using Investec.Sdk.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Investec.Sdk.OpenApi
{
    public static class InvestecSdkExtensions
    {
        public static IServiceCollection AddInvestecOpenApi(this IServiceCollection services, InvestecOpenApiConfiguration investecOpenApiConfiguration) 
        {
            services.AddSingleton(investecOpenApiConfiguration);

            services.AddScoped<IInvestecOpenApiService, InvestecOpenApiService>();
            services.AddLogging();
            services.AddScoped<InvestecOpenApiHttpClient>(client => new InvestecOpenApiHttpClient
            {
                BaseAddress = new Uri(investecOpenApiConfiguration.Url)
            });

            return services;
        }
    }
}
