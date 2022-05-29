using TestApp.DataAccess.Abstraction;
using TestApp.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestApp.DataAccess
{
    public static class ServiceInstaller
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TestAppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TestAppConnectionString")));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IContactRepository, ContactRepository>();

            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<IIncidentRepository, IncidentRepository>();


            return services;
        }
    }
}
