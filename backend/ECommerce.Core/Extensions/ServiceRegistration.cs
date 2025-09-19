using ECommerce.Core.Helpers.Security;
using ECommerce.Core.HttpContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Core.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IUserAccessor, UserAccessor>();

            services.AddDataAccess(config);
            services.AddBusiness();
            services.AddJwt(config);
            services.AddSwaggerWithJwt();
            services.AddApplicationPipelines(config);

            return services;
        }
    }
}