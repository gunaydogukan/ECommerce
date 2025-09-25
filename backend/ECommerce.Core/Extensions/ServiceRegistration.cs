using ECommerce.Core.Helpers.Security;
using ECommerce.Core.HttpContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ECommerce.Core.Abstractions;

namespace ECommerce.Core.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<CookieHelper>();

            services.AddDataAccess(config);
            services.AddBusiness();
            services.AddJwt(config);
            services.AddSwaggerWithJwt();
            services.AddApplicationPipelines(config);

            return services;
        }
    }
}