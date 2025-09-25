using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Core.Extensions
{
    public static class BusinessRegistration
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            // MediatR
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.Load("ECommerce.Business"));
            });

            // FluentValidation
            services.AddValidatorsFromAssembly(Assembly.Load("ECommerce.Business"));

            return services;
        }
    }
}