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
            services.AddScoped<IPortalService, PortalService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentService, CommentService>();
            
            return services;
        }
    }
}
