using ECommerce.Core.Behaviors;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Core.Extensions
{
    public static class PipelineRegistration
    {
        public static IServiceCollection AddApplicationPipelines(
            this IServiceCollection services, IConfiguration config)
        {
            // Caching
            var redis = config.GetConnectionString("Redis");
            if (!string.IsNullOrWhiteSpace(redis))
            {
                services.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = redis;
                });

                services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            }

            // Validation
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Invalidation
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(InvalidationBehavior<,>));

            // Transaction
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));

            return services;
        }
    }
} 