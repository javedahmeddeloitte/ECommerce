using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Repository.DBModels;
using UserService.Repository.Interfaces;
using UserService.Repository.Repositories;

namespace UserService.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryLayer(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            //);
            services.AddDbContext<UserDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DBConnection")));


            // Repositories
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

            return services;
        }
    }
}
