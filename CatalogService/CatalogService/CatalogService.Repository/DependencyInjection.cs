using CatalogService.Repository.DBModels;
using CatalogService.Repository.Inteface;
using CatalogService.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryLayer(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<CatalogDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CatalogDBConnection")));


            // Repositories
            services.AddScoped<ICatalogReadRepository, CatalogReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

            return services;
        }
    }
}
