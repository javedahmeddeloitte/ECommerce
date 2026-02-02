using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Business.Interfaces;
using UserService.Business.Services;

namespace UserService.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            // Services
            services.AddScoped<IUserReadService, UserReadService>();
            services.AddScoped<IUserWriteService, UserWriteService>();

            return services;
        }
    }
}
