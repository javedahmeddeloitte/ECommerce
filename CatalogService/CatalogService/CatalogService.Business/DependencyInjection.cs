using CatalogService.Business.Inteface;
using CatalogService.Business.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            // Services
            services.AddScoped<ICategoryCommandService, CategoryCommandService>();
            services.AddScoped<IProductCommandService, ProductCommandService>();
            services.AddScoped<ICatalogQueryService, CatalogQueryService>();
            return services;
        }
    }
}
