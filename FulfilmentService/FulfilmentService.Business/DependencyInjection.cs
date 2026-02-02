using FulfilmentService.Business.Interface;
using FulfilmentService.Business.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FulfilmentService.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            // Services
            services.AddScoped<IFulfillmentCommandService, FulfillmentCommandService>();
            return services;
        }
    }
}
