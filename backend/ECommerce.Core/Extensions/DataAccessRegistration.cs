using ECommerce.Core.Abstractions;
using ECommerce.Core.Crud;
using ECommerce.Core.Settings;
using ECommerce.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerce.Core.Extensions
{
    public static class DataAccessRegistration
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<DbSettings>(config.GetSection("ConnectionStrings"));

            var dataAccessAssembly = Assembly.Load("ECommerce.DataAccess");

            var dbContextType = dataAccessAssembly
                .GetTypes()
                .FirstOrDefault(t => typeof(DbContext).IsAssignableFrom(t) && !t.IsAbstract);

            if (dbContextType == null)
                throw new InvalidOperationException("AppDbContext bulunamadı!");

            services.AddScoped(dbContextType);


            var uowType = typeof(UnitOfWork<>).MakeGenericType(dbContextType);
            services.AddScoped(typeof(IUnitOfWork), uowType);

            services.AddScoped(typeof(ICrudDal<>), typeof(BaseCrudDal<>));

            return services;
        }
    }

}
