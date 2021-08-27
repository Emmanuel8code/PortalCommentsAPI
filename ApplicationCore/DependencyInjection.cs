using ApplicationCore.Interfaces.IServices;
using ApplicationCore.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ApplicationCore
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPortalService, PortalService>();
            services.AddScoped<IRoleService, RoleService>();

            return services;
        }
    }
}
