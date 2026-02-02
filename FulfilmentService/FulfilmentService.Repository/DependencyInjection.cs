using FulfilmentService.Repository.DBModels;
using FulfilmentService.Repository.Interface;
using FulfilmentService.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FulfilmentService.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryLayer(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<FulfilmentDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("FulfillmentDBConnection")));
            // Repositories
            services.AddScoped<IFulfillmentCommandRepository, FulfillmentCommandRepository>();
            services.AddScoped<IFulfillmentQueryRepository, FulfillmentQueryRepository>();
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

            return services;
        }
    }
}
