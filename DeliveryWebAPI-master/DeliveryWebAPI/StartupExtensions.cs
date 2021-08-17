using DeliveryWebAPI.Domain.Models;
using DeliveryWebAPI.Infrastructure;
using DeliveryWebAPI.Services.Abstractions;
using DeliveryWebAPI.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryWebAPI
{
    public static class StartupExtensions
    {
        public static void RegisterDIServices(this IServiceCollection services)
        {
            services.AddScoped<IUserValidator<User>, CustomUserValidator>();
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<IAdminServices, AdminServices>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<IStorageServices, StorageServices>();
        }
    }
}
